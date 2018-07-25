using Microsoft.Extensions.DependencyInjection;
using Org.Visiontech.Optoplus.Dto.Entity;
using VisiontechCommons;

namespace Org.Visiontech.Commons.Services
{

    public class PersonService : DeletableService<PersonDTO>, IDeletableService<PersonDTO>
    {

        static PersonService()
        {
            Container.services.AddSingleton<IDeletableService<PersonDTO>, PersonService>();
        }

        public PersonService() : base("person")
        {
        }

    }

}