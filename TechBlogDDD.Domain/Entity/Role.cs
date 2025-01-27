using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TechBlogDDD.Domain.Common;

namespace TechBlogDDD.Domain.Entity
{
    [Serializable]

    public class Role : IEntity
    {
       public int Id { get; set; }
        public string? RoleName { get; set; }
        public bool IsActive { get; set; }
    }
}
