using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogDDD.Application.Contract.Post.Queries
{
    [DataContract]
    public class GetPostQueryResponse
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string CategoryId { get; set; }

        [DataMember]
        public string PhotoUrl { get; set; }
    }
}
