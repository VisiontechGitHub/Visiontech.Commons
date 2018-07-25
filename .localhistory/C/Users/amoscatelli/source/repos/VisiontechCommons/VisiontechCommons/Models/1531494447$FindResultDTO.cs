using Org.Visiontech.Commons.Dto.Api;
using Org.Visiontech.Commons.Json.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace VisiontechCommons.Models
{
    public class FindResultDTO : JsonbPolimorphic
    {

        public long count { get; set; }
        public ICollection<IdentifiableDTO> results { get; set; }

    }
}
