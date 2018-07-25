using Microsoft.Extensions.DependencyInjection;
using Org.Visiontech.Optoplus.Dto.Entity;
using VisiontechCommons;

namespace Org.Visiontech.Commons.Services
{

    public class PersonService : DeletableService<PersonDTO>, IDeletableService<PersonDTO>
    {

        public PersonService() : base("person")
        {
        }

    }

}