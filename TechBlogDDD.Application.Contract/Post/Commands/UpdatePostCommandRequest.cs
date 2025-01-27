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
    public class UpdatePostCommandRequest:IRequest<GeneralResponse<UpdatePostCommandResponse>>
    {
        [DataMember]
        public int PostId { get; set; }
        [DataMember]
        public string Title {  get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string PhotoUrl { get; set; }
    }
}
