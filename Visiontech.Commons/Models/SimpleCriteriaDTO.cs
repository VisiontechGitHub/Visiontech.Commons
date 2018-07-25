using Org.Visiontech.Commons.Dto.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Visiontech.Commons.Models
{
    public class SimpleCriteriaDTO<D> : FindCriteriaDTO<D> where D : IdentifiableDTO
    {

        public D criteria { get; set; }

    }
}
