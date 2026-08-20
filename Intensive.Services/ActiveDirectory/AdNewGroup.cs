using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.ActiveDirectory
{
    public class AdNewGroup
    {
        public string Name { get; set; }
        public string GroupScope { get; set; }

        public AdNewGroup()
        {

        }

        public AdGroupType GetGroupType()
        {
            AdGroupType t = AdGroupType.SecurityEnabled;

            switch(this.GroupScope.ToLower().Trim())
            {
                case "universal":   t |= AdGroupType.UniversalGroup; break;
                case "global":      t |= AdGroupType.GlobalGroup; break;
                case "domain local":t |= AdGroupType.DomainLocalGroup; break;
            }

            return t;
        }

        public bool ValidData()
        {
            if(string.IsNullOrEmpty(Name))
            {
                return false;
            }

            if (string.IsNullOrEmpty(this.GroupScope))
            {
                return false;
            }
            if ( (this.GroupScope.ToLower().Trim() != "universal") &&
                 (this.GroupScope.ToLower().Trim() != "global") &&
                 (this.GroupScope.ToLower().Trim() != "domain local")  )
            {
                return false;
            }
            return true;
        }
    }
}
