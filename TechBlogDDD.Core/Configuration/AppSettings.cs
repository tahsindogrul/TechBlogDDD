using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogDDD.Core.Configuration
{
    public class AppSettings
    {
        public static string? GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", true, false);
            IConfiguration configuration = builder.Build();
            return configuration.GetConnectionString("TechBlogDDD");
        }
    }
}
