using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Intensive.Data.ADMT
{
    public class ADMTDBContextFactory
    {
        public string ConnectionString { get; set; }

        public ADMTDBContextFactory() { }

        public ADMTDBContextFactory(string connStr)
        {
            this.ConnectionString = connStr;
        }
        public ADMTContext Create(string connectionString)
        {
            this.ConnectionString = connectionString;
            return this.Create();
        }
        public ADMTContext Create()
        {
            if (!string.IsNullOrEmpty(this.ConnectionString))
            {
                var optionsBuilder = new DbContextOptionsBuilder<ADMTContext>();
                optionsBuilder.UseSqlServer(this.ConnectionString);
                return new ADMTContext(optionsBuilder.Options);
            }
            else
            {
                throw new ArgumentNullException("connectionString");
            }
        }
    }
}
