using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Intensive.Data.WSUS
{
    public class WSUSDBContextFactory
    {
        public SUSDBContext Create(string connStr)
        {
            if (!string.IsNullOrEmpty(connStr))
            {
                var optionsBuilder = new DbContextOptionsBuilder<SUSDBContext>();
                optionsBuilder.UseSqlServer(connStr);
                return new SUSDBContext(optionsBuilder.Options);
            }
            else
            {
                throw new ArgumentNullException("connStr");
            }
        }
    }
}
