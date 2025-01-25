using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogDDD.Application.Contract.User.Queries
{
    [DataContract]

    public class GetUserQueryResponse
    {
        [DataMember]    
        public int Id { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string About {  get; set; }

        [DataMember]
        public string Gender { get; set; }
    }
}
