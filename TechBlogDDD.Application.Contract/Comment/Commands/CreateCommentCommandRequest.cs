using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.Application.Contract.Comment.Commands
{
    [DataContract]
    public class CreateCommentCommandRequest:IRequest<GeneralResponse<CreateCommentCommandResponse>>
    {
        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int PostId { get; set; }

        [DataMember]
        public int UserId {  get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }
    }
}
