using Org.Visiontech.Optoplus.Dto.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Org.Visiontech.Commons.Services
{
    public interface IComputeLensService
    {

        Task<ComputeLensResponseDTO> Compute(ComputeLensRequestDTO request);

    }
}
