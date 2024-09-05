using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Helpers
{
    public class GuidHelpers
    {
        public static string CreatGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
