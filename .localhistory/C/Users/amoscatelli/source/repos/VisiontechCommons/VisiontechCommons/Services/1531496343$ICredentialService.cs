using Org.Visiontech.Optoplus.Dto.Entity;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Org.Visiontech.Commons

{

    public interface ICredentialService : IDeletableService<CredentialDTO>

    {

        Task<CredentialDTO> My();

    }

}