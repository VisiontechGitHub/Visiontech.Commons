using Org.Visiontech.Optoplus.Dto.Entity;

namespace Org.Visiontech.Commons.Services
{

    public class PersonService : DeletableService<PersonDTO>, IDeletableService<PersonDTO>
    {

        static PersonService()
        {
            Container.services.AddSingleton<IComputeLensService, ComputeLensService>();
        }

        public PersonService() : base("person")
        {
        }

    }

}