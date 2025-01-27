using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Domain.Common;

namespace TechBlogDDD.Domain.Entity

{
    [Serializable]
    public class UserRole:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }

    }
}
