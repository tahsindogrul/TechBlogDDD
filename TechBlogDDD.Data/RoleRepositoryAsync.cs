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
    public class RoleRepositoryAsync : TechBlogDbConnection, IRoleRepositoryAsync
    {
        public Task<GeneralResponse<Role>> AddAsync(Role request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<bool>> AddUserRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Role>> DeleteAsync(Role request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<List<Role>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralResponse<List<Role>>> GetAllByIdAsync(int id)
        {
            var data = new GeneralResponse<List<Role>>();
            data.Value = new List<Role>();
            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", id);

            try
            {
                data.Value = connection?.db?.QueryAsync<Role>("UserRolesByUserId", parameters, commandType: CommandType.StoredProcedure).Result.ToList();
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

        public Task<GeneralResponse<Role>> GetAsync(Role request)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse<Role>> UpdateAsync(Role request)
        {
            throw new NotImplementedException();
        }
    }
}
