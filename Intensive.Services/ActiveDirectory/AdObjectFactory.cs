using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.ActiveDirectory
{
    public class AdObjectFactory
    {
        private readonly IServiceProvider serviceProvider;

        public AdObjectFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public AdGroup CreateGroup()
        {
            return (AdGroup)serviceProvider.GetService(typeof(AdGroup));
        }

        public AdUser CreateUser()
        {
            return (AdUser)serviceProvider.GetService(typeof(AdUser));
        }

        public AdComputer CreateComputer()
        {
            return (AdComputer)serviceProvider.GetService(typeof(AdComputer));
        }
        public AdContainer CreateContainer()
        {
            return (AdContainer)serviceProvider.GetService(typeof(AdContainer));
        }
    }
}
