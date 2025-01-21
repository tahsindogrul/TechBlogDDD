using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Domain.Common;

namespace TechBlogDDD.Domain.Entity
{
    public class Comment: IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public  int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

    }
}
