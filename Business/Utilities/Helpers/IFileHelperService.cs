﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Helpers
{
    public interface IFileHelperService
    {
        string Upload(IFormFile file, string root);
        void Delete(string filepath);
        string Update(IFormFile file, string filePath, string root);
    }
}
