using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Intensive.Services.Aric
{
    internal class PatchingRegistryValues
    {
        internal string ErrorMessage { get; set; }
        internal string Server { get; set; }

        internal Dictionary<string, PatchingRegistryKeyValue> Registry { get; set; }

        private JArray ja;

        public PatchingRegistryValues()
        { }
        public PatchingRegistryValues(string json)
        {
            this.Registry = new Dictionary<string, PatchingRegistryKeyValue>();

            //byte[] ba = Convert.FromBase64String(json);
            //ja = JArray.Parse(Encoding.UTF8.GetString(ba));
            //
            ja = JArray.Parse(json);

            this.ErrorMessage = ja[0]["ScriptErrorMsg"].ToString();

            for (int i = 1; i < ja.Count; i++) //start with the 2nd element in the returned array
            {

                PatchingRegistryKeyValue rk = new PatchingRegistryKeyValue();

                // due to idiosyncracies with different versions of Powershell,
                // a custom JSON coverter was written by IAW for Powershell v2.
                // This custom converter will return the ErrorMsg property of each rk (above)
                // as an array with a single string in it.
                //
                // Whereas, newer versions of Powershell have a built-in JSON converter
                // that returns ErrorMsg as a simple string
                //
                // Code below is an attempt to handle either format
                if (ja[i]["ErrorMsg"] is JArray)
                {
                    JArray jErrors = (JArray)ja[i]["ErrorMsg"];
                    rk.ErrorMessages = jErrors.Select(e => e.ToString())?.ToList<string>();
                }
                else
                {
                    if (ja[i]["ErrorMsg"] is JValue)
                    {
                        string msg = ja[i]["ErrorMsg"].ToString();
                        rk.ErrorMessages.Add(msg);
                    }
                    else
                    {
                        throw new AricException($"[ErrorMsg] is not a known type.");
                    }
                }

                rk.Exists = ja[i]["KeyExists"].ToString().ToLower() == "true";
                rk.Value = ja[i]["Value"].ToString();
                this.Registry.Add(ja[i]["Path"].ToString(), rk);
            }

        }
    }

    internal class PatchingRegistryKeyValue
    {
        internal List<string> ErrorMessages { get; set; }
        internal bool Exists { get; set; }
        internal string Value { get; set; }

        internal PatchingRegistryKeyValue()
        {
            this.ErrorMessages = new List<string>();
        }


    }
}
