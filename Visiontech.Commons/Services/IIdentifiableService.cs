using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Org.Visiontech.Commons.Models;
using Org.Visiontech.Commons.Dto.Api;

namespace Org.Visiontech.Commons.Services
{

    public interface IIdentifiableService<D> where D : IdentifiableDTO
    {

        Task<FindResultDTO> Find(ICollection<FindCriteriaDTO<D>> criterias, long quantity, long offset);

    }

}