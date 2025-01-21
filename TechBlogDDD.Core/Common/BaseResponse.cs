using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogDDD.Core.Common
{
    [Serializable]
    public abstract class BaseResponse
    {
        [NotMapped]
        public bool Success { get; set; }

        [NotMapped]
        public string? InfoMessage { get; set; }

        [NotMapped]
        public string? ErrorMessage { get; set; }
    }
}
