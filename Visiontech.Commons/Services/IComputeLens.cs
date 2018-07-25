using Org.Visiontech.Optoplus.Dto.Service;
using System.Threading.Tasks;

namespace Org.Visiontech.Commons.Services
{
    public interface IComputeLensService
    {

        Task<ComputeLensResponseDTO> Compute(ComputeLensRequestDTO request);

    }
}
