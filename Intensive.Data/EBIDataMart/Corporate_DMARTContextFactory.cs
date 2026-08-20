using System;
using Microsoft.EntityFrameworkCore;

namespace Intensive.Data.EBIDataMart
{
    public class Corporate_DMARTContextFactory
    {
        public string ConnectionString { get; set; }

        public Corporate_DMARTContextFactory() { }

        public Corporate_DMARTContextFactory(string connStr)
        {
            this.ConnectionString = connStr;
        }
        public Corporate_DMARTContext Create(string connectionString)
        {
            this.ConnectionString = connectionString;
            return this.Create();
        }
        public Corporate_DMARTContext Create()
        {
            if (!string.IsNullOrEmpty(this.ConnectionString))
            {
                var optionsBuilder = new DbContextOptionsBuilder<Corporate_DMARTContext>();
                optionsBuilder.UseSqlServer(this.ConnectionString);
                return new Corporate_DMARTContext(optionsBuilder.Options);
            }
            else
            {
                throw new ArgumentNullException("connectionString");
            }
        }
    }
}
