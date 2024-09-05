using Business.Abstracts;
using Business.Constants;
using Business.Utilities.Helpers;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;


namespace Business.Concretes
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IFileHelperService _fileHelperService;
        public ProductImageService(IProductImageRepository productImageRepository, IFileHelperService fileHelperService)
        {
            _productImageRepository = productImageRepository;
            _fileHelperService = fileHelperService;
        }
        public void AddEntity(IFormFile file,ProductImage entity)
        {

            entity.ImagePath = _fileHelperService.Upload(file, PathConstants.ProductImagesPath);
            entity.ImageDate = DateTime.Now;
            _productImageRepository.AddEntity(entity);
        }

        public void DeleteImage(ProductImage productImage)
        {
            _fileHelperService.Delete(PathConstants.ProductImagesPath + productImage.ImagePath);
            _productImageRepository.DeleteImage(productImage);
        }

        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {

            return await _productImageRepository.GetAllAsync();
        }

        public async Task<ProductImage> GetByIdAsync(int id)
        {
            return await _productImageRepository.GetByIdAsync(id);
        }

        public async Task<ProductImage> GetByProductId(int id)
        {
            return await _productImageRepository.GetByProductId(id);
        }

        public void UpdateEntity(IFormFile file, ProductImage entity)
        {
            entity.ImagePath = _fileHelperService.Update(file, PathConstants.ProductImagesPath + entity.ImagePath,
               PathConstants.ProductImagesPath);
            //Then Update the Upload time for image.When they uploaded in the system.
            entity.ImageDate = DateTime.Now;
            _productImageRepository.UpdateEntity(entity);
        }   
    }
}
