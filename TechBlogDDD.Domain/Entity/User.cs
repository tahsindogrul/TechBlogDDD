using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Domain.Common;

namespace TechBlogDDD.Domain.Entity
{
    [Serializable]
    public class User : IEntity
    {

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string About { get; set; }

        public bool IsActive { get; set; }
    }
}
