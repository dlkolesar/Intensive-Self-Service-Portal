using Intensive.Services.CTKAPIWrapper.CTKObjects;
using Intensive.Services.CTKAPIWrapper.Exceptions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intensive.Services.CTKAPIWrapper.CTKObjects
{
    public class CTKCluster:CTKObject
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<int> PhysicalNodes { get; set; }
        public List<int> ClusterDevices { get; set; }

        public CTKCluster() : base()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.PhysicalNodes = new List<int>();
            this.ClusterDevices = new List<int>();
        }
   
        public CTKCluster(CTKAPI instance, int number) : base()
        {
            GetCluster(instance, number);
        }

        private void GetCluster(CTKAPI instance, int deviceNumber)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"class\":\"DevContainer.DeviceContents\",");
            sb.Append("\"load_method\":\"loadList\",");
            sb.Append($" \"load_arg\":{{\"server\":{deviceNumber}}},");
            sb.Append("\"attributes\":[\"container.id\", \"container.name\",\"container.connected_servers.number\", \"container.contents.server.number\"]");
            sb.Append("}");
            string json = sb.ToString();

            CTKResponse resp = instance.Submit(json);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
 
            if (rd.Count == 0)
            {
                throw new CTKNotFoundException($"Device {deviceNumber} is not a cluster or was not found in CORE");
            }
            //CTKCluster ctkCluster = new CTKCluster();
            this.Id = Convert.ToInt32(rd[0]["container.id"]);
            this.Name = rd[0]["container.name"].ToString();
            //int[] arr = (int[])rd[0]["container.connected_servers.number"];
            JArray ja = JArray.Parse(rd[0]["container.connected_servers.number"].ToString());
            int[] arr = ja.Select(jv => (int)jv).ToArray();
            this.PhysicalNodes.AddRange(arr);

            //arr = (int[])rd[0]["container.contents.server.number"];
            ja = JArray.Parse(rd[0]["container.contents.server.number"].ToString());
            arr = ja.Select(jv => (int)jv).ToArray();
            this.ClusterDevices.AddRange(arr);

            this.Properties = new Dictionary<string, object>();
        }
    }
}
