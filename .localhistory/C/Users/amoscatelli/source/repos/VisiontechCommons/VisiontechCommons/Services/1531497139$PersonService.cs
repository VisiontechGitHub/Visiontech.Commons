using Org.Visiontech.Optoplus.Dto.Entity;

namespace Org.Visiontech.Commons.Services
{

    public class PersonService : DeletableService<PersonDTO>, IDeletableService<PersonDTO>
    {

        public PersonService() : base("person")
        {
        }

    }

}