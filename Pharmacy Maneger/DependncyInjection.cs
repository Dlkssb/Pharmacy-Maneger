using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy_Maneger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Maneger
{
    public class DependncyInjection
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Data Source=mydb.sqlite;Version=3;";
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
            services.AddSingleton<MyService>();
        }
    }
}
