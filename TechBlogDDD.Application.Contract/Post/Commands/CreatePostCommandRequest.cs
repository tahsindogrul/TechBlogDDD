using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.Application.Contract.Post.Commands
{
    [DataContract]
    public class CreatePostCommandRequest : IRequest<GeneralResponse<CreatePostCommandResponse>>
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string? PhotoUrl { get; set; }
    }
}
