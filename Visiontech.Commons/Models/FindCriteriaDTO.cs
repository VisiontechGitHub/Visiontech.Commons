using Org.Visiontech.Commons.Dto.Api;
using Org.Visiontech.Commons.Json.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Visiontech.Commons.Models
{
    public abstract class FindCriteriaDTO<D> : JsonbPolimorphic where D : IdentifiableDTO
    {

    }
}
