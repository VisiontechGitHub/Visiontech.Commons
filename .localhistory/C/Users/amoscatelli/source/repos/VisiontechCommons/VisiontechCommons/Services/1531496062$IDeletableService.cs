using Org.Visiontech.Commons.Dto.Api;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Org.Visiontech.Commons
{

    public interface IDeletableService<D> : IModifiableService<D> where D : DeletableDTO
    {

        Task delete(ICollection<D> resources);

    }

}