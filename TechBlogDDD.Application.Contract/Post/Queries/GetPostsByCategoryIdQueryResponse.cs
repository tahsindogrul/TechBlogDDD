﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogDDD.Application.Contract.Post.Queries
{
    [DataContract]
    public class GetPostsByCategoryIdQueryResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string PhotoUrl { get; set; }
    }
}
