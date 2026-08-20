using System;
using System.Collections.Generic;
using System.Linq;
using Intensive.Data;
using Intensive.Data.SSDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
//using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json.Linq;

namespace Intensive.API.Global
{
    public class DbConfigProvider : ConfigurationProvider
    {
        IDictionary<string, string> _data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        Stack<string> _context = new Stack<string>();
        string _currentPath;


        public DbConfigProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        Action<DbContextOptionsBuilder> OptionsAction { get; }

        // Load config data from EF DB.
        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<SSDatabaseContext>();
            OptionsAction(builder);

            using (var dbContext = new SSDatabaseContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();
                //Dictionary<string, string> sysConfigs = dbContext.TbConfig
                //                                                    .AsNoTracking()
                //                                                    .ToDictionary(c => c.ConfigKey, c => c.ConfigJson);

                //foreach (KeyValuePair<string, string> kvp in sysConfigs)
                //{
                //    JObject jsonConfig = JObject.Parse(kvp.Value);
                //    VisitJObject(jsonConfig);
                //    Data.Add(kvp.Key, _data)

                //}

                Data = dbContext.TbConfig.ToDictionary(c => c.ConfigKey, c => c.ConfigJson);
               
            }
        }

        private void VisitJObject(JObject jObject)
        {
            foreach (var property in jObject.Properties())
            {
                EnterContext(property.Name);
                VisitProperty(property);
                ExitContext();
            }
        }

        private void VisitProperty(JProperty property)
        {
            VisitToken(property.Value);
        }

        private void VisitToken(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    VisitJObject(token.Value<JObject>());
                    break;

                case JTokenType.Array:
                    VisitArray(token.Value<JArray>());
                    break;

                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.String:
                case JTokenType.Boolean:
                case JTokenType.Bytes:
                case JTokenType.Raw:
                case JTokenType.Null:
                    VisitPrimitive(token.Value<JValue>());
                    break;

                default:
                    throw new FormatException("Error Parsing JSON config data from the database");
            }
        }

        private void VisitArray(JArray array)
        {
            for (int index = 0; index < array.Count; index++)
            {
                EnterContext(index.ToString());
                VisitToken(array[index]);
                ExitContext();
            }
        }

        private void VisitPrimitive(JValue data)
        {
            var key = _currentPath;

            if (_data.ContainsKey(key))
            {
                throw new FormatException($"Duplicate Key '{key}'");
            }
            _data[key] = data.ToString();
        }

        private void EnterContext(string context)
        {
            _context.Push(context);
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }

        private void ExitContext()
        {
            _context.Pop();
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }
    }
}
