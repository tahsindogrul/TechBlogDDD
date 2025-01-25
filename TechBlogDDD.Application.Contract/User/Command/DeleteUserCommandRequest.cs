using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.Application.Contract.User.Command
{
    [DataContract]

    public class DeleteUserCommandRequest : IRequest<GeneralResponse<DeleteUserCommandResponse>>
    {
        [DataMember]
        public int UserId { get; set; }
    }
}
