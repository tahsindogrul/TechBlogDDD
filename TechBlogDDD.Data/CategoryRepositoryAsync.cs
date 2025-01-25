using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Core.Connection;
using TechBlogDDD.Domain.Entity;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Data
{
    public class CategoryRepositoryAsync : TechBlogDbConnection, ICategoryRepository
    {
        public async Task<GeneralResponse<Category>> AddAsync(Category request)
        {
            var data = new GeneralResponse<Category>();
            data.Value= new Category();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage= connection.ErrorMessage;
                return await Task.FromResult(data);
            }
            try
            {
                var category = connection?.db?.QueryAsync<Int32>("AddCategory", new
                {
                    request.Name,
                    request.IsActive

                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Success";
                connection?.db?.Close();
                return await Task.FromResult(data);

            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection?.db?.Close();
                return await Task.FromResult(data);
            }

        }

        public Task<GeneralResponse<Category>> DeleteAsync(Category request)
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralResponse<List<Category>>> GetAllAsync()
        {
           var data=new GeneralResponse<List<Category>>();
            data.Value= new List<Category>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage= connection.ErrorMessage;
                return await Task.FromResult(data);
            }
            try
            {
                var result = await connection?.db?.QueryAsync<Category>("GetAllCategories", CommandType.StoredProcedure);
                data.Value = result.ToList();
                data.Success = true;
                connection?.db?.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection?.db?.Close();
                return await Task.FromResult(data);


            }
        }
      

        public Task<GeneralResponse<Category>> GetAsync(Category request)
        {
            throw new NotImplementedException();
        }

       

        public Task<GeneralResponse<Category>> UpdateAsync(Category request)
        {
            throw new NotImplementedException();
        }
    }
}
