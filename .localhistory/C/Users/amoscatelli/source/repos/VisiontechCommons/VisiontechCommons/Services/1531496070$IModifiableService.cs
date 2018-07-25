using Org.Visiontech.Commons.Dto.Api;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Org.Visiontech.Commons
{

    public interface IModifiableService<D> : ICreatedService<D> where D : ModifiableDTO
    {

        Task<ICollection<D>> put(ICollection<D> resources);

    }

}