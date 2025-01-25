using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Domain.Common;
using TechBlogDDD.Domain.Entity;

namespace TechBlogDDD.Domain.Repository
{
    public interface IPostRepository:IRepositoryAsync<Post>
    {
        Task<GeneralResponse<List<Post>>> GetPostsByCategoryIdAsync(int categoryId);
        Task<GeneralResponse<int>> GetTotalPostCountAsync();

        Task<GeneralResponse<Post>> GetPostDetails(int id);



    }
}
