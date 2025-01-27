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
    public class UserRoleRepository : TechBlogDbConnection, IUserRoleRepositoryAsync
    {
        public async Task<GeneralResponse<UserRole>> AddAsync(UserRole request)
        {
            var data = new GeneralResponse<UserRole>();
            data.Value = new UserRole();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var result = connection?.db?.QueryAsync<Int32>("AddUserRole", new
                {
                    request.UserId,
                    request.RoleId,
                    request.IsActive,
                                  
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                data.Success = true;
                data.InfoMessage = "User was created!";

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

        public Task<GeneralResponse<UserRole>> DeleteAsync(UserRole request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<UserRole>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<UserRole>> GetAsync(UserRole request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<UserRole>> UpdateAsync(UserRole request)
        {
            throw new NotImplementedException();
        }
    }
}
