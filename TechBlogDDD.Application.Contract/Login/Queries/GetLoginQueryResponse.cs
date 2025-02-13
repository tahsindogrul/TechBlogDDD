using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogDDD.Application.Contract.Login.Queries
{
    [DataContract]
    public class GetLoginQueryResponse
    {
        [DataMember]
        public int UserId { get; set; }
       
        [DataMember]
        public string? Token { get; set; }

        [DataMember]
        public string? FullName { get; set; }

        [DataMember]
        public List<string> RoleList { get; set; }

    }
}
