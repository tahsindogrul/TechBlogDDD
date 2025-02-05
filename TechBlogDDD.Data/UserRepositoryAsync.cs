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
    public class UserRepositoryAsync : TechBlogDbConnection, IUserRepository
    {
        public async Task<GeneralResponse<User>> AddAsync(User request)
        {
            var data = new GeneralResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);

            }
            try
            {
                var user = connection?.db?.QueryAsync<Int32>("AddUser", new
                {
                    request.FullName,
                    request.Email,
                    request.Password,
                    request.Gender,
                    request.About,
                    request.IsActive

                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "User was created!";
                data.Value.Id = user.Value;
                data.Value.FullName = request.FullName;
                data.Value.Email = request.Email;
                data.Value.Gender = request.Gender;
                connection?.db?.Close();
                return await Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                return await Task.FromResult(data);
            }
        }

        public Task<GeneralResponse<User>> DeleteAsync(User request)
        {
            var data = new GeneralResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return Task.FromResult(data);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", request.Id);

            try
            {
                var user = connection?.db?.QueryAsync<Int32>("DeleteUser", parameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Operation finished successfully";
                connection?.db?.Close();
                return Task.FromResult(data);
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMessage = ex.Message;
                connection?.db?.Close();
                return Task.FromResult(data);
            }
        }

        public Task<GeneralResponse<List<User>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralResponse<User>> GetAsync(User request)
        {
            var data = new GeneralResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                data.Value = connection?.db?.QueryAsync<User>("GetUserByInfo", new
                {
                    request.Email,
                    request.Password
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
                if (data.Value != null)
                {
                    data.Success = true;
                    data.InfoMessage = "User found";
                }
                else
                {
                    data.Success = false;
                    data.ErrorMessage = "User not found";
                }
                connection?.db?.Close();
                return await Task.FromResult(data);
            }
            catch(Exception ex) 
            { 
                data.Success=false;
                data.ErrorMessage=ex.Message;
                connection?.db?.Close();
                return await Task.FromResult(data);
            }

        }

        public async Task<GeneralResponse<User>> UpdateAsync(User request)
        {
            var data = new GeneralResponse<User>();
            data.Value=new User();

            if(!connection.Success)
            {
                data.Success=false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }
            try
            {
                var user = connection?.db?.QueryAsync<Int32>("UpdateUser", new
                {
                    request.Id,
                    request.FullName,
                    request.Gender,
                    request.Email,
                    request.Password,
                    request.About,
                }, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
                data.Success = true;
                data.InfoMessage = "Operation finished successfully!";

                connection?.db?.Close();
                return await Task.FromResult(data);
            }
            catch(Exception ex)
            {
                data.Success = false;
                data.ErrorMessage=ex.Message;
                connection?.db?.Close();
                return await Task.FromResult(data);
            }
        }

        public async Task<GeneralResponse<User>> GetByIdAsync(int id)
        {
            var data = new GeneralResponse<User>();
            data.Value = new User();

            if (!connection.Success)
            {
                data.Success = false;
                data.ErrorMessage = connection.ErrorMessage;
                return await Task.FromResult(data);
            }

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", id);

                data.Value = connection?.db?.QueryAsync<User>("GetUserById", parameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();

                if (data.Value != null)
                {
                    data.Success = true;
                    data.InfoMessage = "User found";
                }
                else
                {
                    data.Success = false;
                    data.ErrorMessage = "User not found";
                }
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
