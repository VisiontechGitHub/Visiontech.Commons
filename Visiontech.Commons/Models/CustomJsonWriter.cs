using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Org.Visiontech.Commons.Models
{
    public class CustomJsonWriter : JsonTextWriter
    {
        public CustomJsonWriter(TextWriter writer) : base(writer)
        {
        }

        public override void WritePropertyName(string name, bool escape)
        {
            if (name == "$type") name = "@type";
            base.WritePropertyName(name, escape);
        }
    }
}
