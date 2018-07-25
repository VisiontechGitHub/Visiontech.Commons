using Org.Visiontech.Commons.Dto.Api;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Org.Visiontech.Commons

{

    public interface ICreatedService<D> : IIdentifiableService<D> where D : CreatedDTO
    {

        Task<ICollection<D>> post(ICollection<D> resources);

    }

}