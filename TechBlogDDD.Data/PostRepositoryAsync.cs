using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Core.Connection;
using TechBlogDDD.Domain.Entity;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Data
{
    public class PostRepositoryAsync : TechBlogDbConnection, IPostRepository
    {
        public async Task<GeneralResponse<Post>> AddAsync(Post request)
        {
            var data = new GeneralResponse<Post>();
            data.Value = new Post();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }
            try
            {
                var post = connection?.db?.QueryAsync<Int32>("AddPost", new
                {
                    request.Title,
                    request.Content,
                    request.PhotoUrl,
                    request.IsActive
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Post successfully created";

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


        public async Task<GeneralResponse<Post>> DeleteAsync(Post request)
        {
            var data = new GeneralResponse<Post>();
            data.Value = new Post();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@PostId", request.Id);

            try
            {
                var post = connection?.db?.QueryAsync("DeletePost", parameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Post successfully deleted";

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

        public async Task<GeneralResponse<List<Post>>> GetAllAsync()
        {

            var data = new GeneralResponse<List<Post>>();
            data.Value = new List<Post>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var post = await connection.db.QueryAsync<Post>("GetAllPost", CommandType.StoredProcedure);
                data.Value = post.ToList();
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

        public Task<GeneralResponse<Post>> GetAsync(Post request)
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralResponse<Post>> GetPostDetails(int id)
        {
            var data = new GeneralResponse<Post>();
            data.Value = new Post();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("PostId", id);

            try
            {
                var post = await connection.db.QueryFirstOrDefaultAsync<Post>("GetPostDetails", parameters, commandType: CommandType.StoredProcedure
                );
                if (post != null)
                {
                    data.Value = post;
                    data.Success = true;
                }
                else
                {
                    data.Success = false;
                    data.ErrorMessage = "Post details not found";
                }
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
            
            }
            finally
            {
                connection?.db?.Close();
            }
            return await Task.FromResult(data);
        }

        public async Task<GeneralResponse<List<Post>>> GetPostsByCategoryAsync(int categoryId)
        {
            var data = new GeneralResponse<List<Post>>();
            data.Value = new List<Post>();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);

            }

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", categoryId);

            try
            {
                var posts = await connection.db.QueryAsync<Post>("GetPostsByCategory", parameters, commandType: CommandType.StoredProcedure);
                data.Value = posts.ToList();
                data.Success = true;
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
            }
            finally
            {
                connection?.db?.Close();
            }

            return await Task.FromResult(data);

        }



        public async Task<GeneralResponse<int>> GetTotalPostCountAsync()
        {
            var data = new GeneralResponse<int>();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);

            }

            try
            {
                var totalCount = await connection.db.QueryFirstOrDefaultAsync<int>("GetTotalPostCount", commandType: CommandType.StoredProcedure);
                data.Value = totalCount;
                data.Success = true;
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
            }
            finally
            {
                connection?.db?.Close();
            }

            return await Task.FromResult(data);

        }

        public async Task<GeneralResponse<Post>> UpdateAsync(Post request)
        {
            var data = new GeneralResponse<Post>();
            data.Value = new Post();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var comment = connection?.db?.QueryAsync("UpdatePost", new
                {
                    request.Title,
                    request.Content,
                    request.PhotoUrl,
                    request.IsActive
                },
                commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "Post successfully updated";

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
    }
}
