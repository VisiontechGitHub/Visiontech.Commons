using Org.Visiontech.Commons.Dto.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Visiontech.Commons.Models
{
    public class RangeCriteriaDTO<D> : FindCriteriaDTO<D> where D : IdentifiableDTO
    {

        public D from { get; set; }
        public D to { get; set; }

    }
}
