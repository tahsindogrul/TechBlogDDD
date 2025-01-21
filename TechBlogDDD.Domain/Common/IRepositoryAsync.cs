using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;

namespace TechBlogDDD.Domain.Common
{
    public interface IRepositoryAsync<T>
    {
        Task<GeneralResponse<List<T>>> GetAllAsync();

        Task<GeneralResponse<T>> GetAsync(T request);

        Task<GeneralResponse<T>> AddAsync(T request);
        Task<GeneralResponse<T>> UpdateAsync(T request);
        Task<GeneralResponse<T>> DeleteAsync(T request);



    }
}
