using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Common;
using TechBlogDDD.Core.Connection;
using TechBlogDDD.Domain.Common;
using TechBlogDDD.Domain.Entity;
using TechBlogDDD.Domain.Repository;

namespace TechBlogDDD.Data
{
    public class CommentRepositoryAsync : TechBlogDbConnection, ICommentRepository
    {
        public async Task<GeneralResponse<Comment>> AddAsync(Comment request)
        {
            var data = new GeneralResponse<Comment>();
            data.Value = new Comment();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }
            try
            {
                var comment = await connection?.db?.QueryAsync<Int32>("AddComment", new
                {
                    request.Content,
                    request.DateCreated,
                    request.IsActive

                }, commandType: CommandType.StoredProcedure);

                data.Value.Id = comment.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Comment successfully added";

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

        public async Task<GeneralResponse<Comment>> DeleteAsync(Comment request)
        {
            var data = new GeneralResponse<Comment>();
            data.Value = new Comment();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }
            var parameters = new DynamicParameters();
            parameters.Add("@CommentId", request.Id);

            try
            {
                var comment = connection?.db?.QueryAsync<Int32>("DeleteComment", parameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Comment successfully deleted";

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

        public Task<GeneralResponse<List<Comment>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<GeneralResponse<Comment>> GetAsync(Comment request)
        {

            throw new NotImplementedException();
        }

        public async Task<GeneralResponse<Comment>> UpdateAsync(Comment request)
        {
            var data = new GeneralResponse<Comment>();
            data.Value = new Comment();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var comment = connection?.db?.QueryAsync("UpdateComment", new
                {
                    request.Content,
                    request.IsActive,
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Comment successfully updated";
                connection?.db?.Close();
                return await Task.FromResult(data);
             
            }
            catch(Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection?.db?.Close();
                return await Task.FromResult(data);
            }
        }
    }
}
