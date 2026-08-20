using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.Aric
{
    public class AricRegistryKey
    {
        public string Path { get; set; }

        public AricRegistryKey() { }

        public AricRegistryKey(string path)
        {
            this.Path = path;
        }
    }

    public class AricRegistryKeyValue : AricRegistryKey
    {
        public string Property { get; set; }

        public AricRegistryKeyValue() { }

        public AricRegistryKeyValue(string path, string prop) : base(path)
        {
            this.Property = prop;
        }

    }

    public class AricRegistryKeyValueType : AricRegistryKey
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public AricRegistryKeyValueType() { }

        public AricRegistryKeyValueType(string path, string valType, string val) : base(path)
        {
            this.Type = valType;
            this.Value = val;
        }

    }
}
