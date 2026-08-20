using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.API.Global
{
    public static class Extensions
    {
        //public static IConfigurationBuilder AddEntityFrameworkConfig(
        //    this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> setup)
        //{
        //    return builder.Add(new EFConfigSource(setup));
        //}

        public static AuthenticationBuilder AddRackspaceIdentityAuthentication(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<RackspaceIdentityAuthenticationOptions> configureOptions)
        {
            return builder.AddScheme<RackspaceIdentityAuthenticationOptions, RackspaceIdentityAuthenticationHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
