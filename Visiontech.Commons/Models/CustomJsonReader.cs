using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Org.Visiontech.Commons.Models
{
    public class CustomJsonReader : JsonTextReader
    {

        public CustomJsonReader(TextReader reader) : base(reader) { }

        public override bool Read()
        {
            var hasToken = base.Read();

            if (hasToken && base.TokenType == JsonToken.PropertyName && base.Value != null && base.Value.Equals("@type"))
            {
                SetToken(JsonToken.PropertyName, "$type");
            }

            return hasToken;
        }

    }
}
