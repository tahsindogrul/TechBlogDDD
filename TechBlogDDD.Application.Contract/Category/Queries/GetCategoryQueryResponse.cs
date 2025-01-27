using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogDDD.Application.Contract.Category.Queries
{
    [DataContract]
    public class GetCategoryQueryResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

    }
}
