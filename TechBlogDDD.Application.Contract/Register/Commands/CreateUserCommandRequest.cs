using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.Application.Contract.Register.Commands
{
    [DataContract]
    public class CreateUserCommandRequest : IRequest<GeneralResponse<CreateUserCommandResponse>>
    {
        [DataMember]
        public string? FullName { get; set; }

        [DataMember]
        public string? Password { get; set; }

        [DataMember]
        public string? Email { get; set; }

        [DataMember]
        public string? RePassword { get; set; }



    }
}
