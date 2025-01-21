using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlogDDD.Core.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace TechBlogDDD.Core.Connection
{
    public abstract class TechBlogDbConnection
    {
        public DbConnectionResult connection;
        public TechBlogDbConnection()
        {
            connection = OpenConnection();
            
        }

        private DbConnectionResult OpenConnection()
        {
            var response = new DbConnectionResult();

            try
            {
                string connectionStr = AppSettings.GetConnectionString() ?? Domain.Shared.Constants.Connection.ConnectionString;

                IDbConnection _db = new SqlConnection(connectionStr);
                _db.Open();
                response.db = _db;
                response.Success = true;
                response.InfoMessage = "Success";
            }
            catch (Exception ex)
            {
                response.Success=false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
