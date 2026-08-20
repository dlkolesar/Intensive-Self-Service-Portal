using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Intensive.API.Global
{
    public static class DbConfigProviderExtensions
    {
        public static IConfigurationBuilder AddDbConfiguration(
            this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> setup)
        {
            return builder.Add(new DbConfigSource(setup));
        }
    }
}
