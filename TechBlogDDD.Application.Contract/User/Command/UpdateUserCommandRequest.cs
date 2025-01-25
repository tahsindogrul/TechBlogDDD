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
    public class UpdateUserCommandRequest : IRequest<GeneralResponse<UpdateUserCommandResponse>>
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string? FullName { get; set; }

        [DataMember]
        public string? Password { get; set; }

        [DataMember]
        public string? Email { get; set; }

        [DataMember]
        public string? Gender { get; set; }

        [DataMember]
        public string About { get; set; }

    }
}
