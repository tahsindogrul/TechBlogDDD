using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.Core.Connection
{
    public  class DbConnectionResult:BaseResponse
    {
        public IDbConnection? db {  get; set; }
    }
}
