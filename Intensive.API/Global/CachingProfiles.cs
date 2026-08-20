using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Intensive.API.Global
{
    public static class CachingProfiles
    {
        
        public static CacheProfile Cache_None = new CacheProfile()
        {
            Location = ResponseCacheLocation.None,
            Duration = 0
        };
        public static CacheProfile Cache_1Hour = new CacheProfile()
        {
            Location = ResponseCacheLocation.Any,
            Duration = 3600    //3600 seconds = 1 hour
        };

        public static CacheProfile Cache_4Hours = new CacheProfile()
        {
            Location = ResponseCacheLocation.Any,
            Duration = 14400    
        };

        public static CacheProfile Cache_8Hours = new CacheProfile()
        {
            Location = ResponseCacheLocation.Any,
            Duration = 28800    
        };

    }
}
