using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogDDD.Core.Common
{
    public class GeneralResponse <T>:BaseResponse
    {
        public T Value { get; set; }
    }
}
