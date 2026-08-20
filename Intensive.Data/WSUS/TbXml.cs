using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbXml
    {
        public int XmlId { get; set; }
        public string RootElementXml { get; set; }
        public int RootElementType { get; set; }
        public int LanguageId { get; set; }
        public int RevisionId { get; set; }
        public byte[] RootElementXmlCompressed { get; set; }

        public virtual TbRevision Revision { get; set; }
    }
}
