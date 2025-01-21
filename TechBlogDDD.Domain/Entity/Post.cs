using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Domain.Common;

namespace TechBlogDDD.Domain.Entity
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; } 
        public bool IsPublished { get; set; }
        public int UserId { get; set; }
        public int CategoryId {  get; set; }
        public string? PhotoUrl { get; set; }

        public bool IsActive {  get; set; }
        
    }
}
