using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.Application.Contract.User.Queries
{
    [DataContract]

    public class GetUserQueryRequest:IRequest<GeneralResponse<GetUserQueryResponse>>
    {
        public int UserId { get; set; }
    }
}
