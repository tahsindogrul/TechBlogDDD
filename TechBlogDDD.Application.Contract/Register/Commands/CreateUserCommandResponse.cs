using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;
using System.Runtime.Serialization;

namespace TechBlogDDD.Application.Contract.Register.Commands
{
    [DataContract]

    public class CreateUserCommandResponse
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string? FullName { get; set; }

        [DataMember]
        public string? Token { get; set; }

        [DataMember]
        public List<string>? RoleList { get; set; }
    }
}
