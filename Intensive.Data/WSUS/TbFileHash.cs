using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbFileHash
    {
        public byte[] FileDigest { get; set; }
        public string DigestAlgorithm { get; set; }
        public byte[] AdditionalHash { get; set; }
    }
}
