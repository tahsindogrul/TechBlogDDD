using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.Application.Contract.Comment.Commands
{
    [DataContract]
    public class DeleteCommentCommandRequest: IRequest<GeneralResponse<DeleteCommentCommandResponse>>
    {
        [DataMember]
        public int CommentId { get; set; }
    }
}
