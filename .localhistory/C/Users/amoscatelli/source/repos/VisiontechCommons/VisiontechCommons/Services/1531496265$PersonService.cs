﻿using Org.Visiontech.Commons;
using Newtonsoft.Json;
using Org.Visiontech.Optoplus.Dto.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Org.Visiontech.Commons.Services
{

    public class PersonService : DeletableService<PersonDTO>, IDeletableService<PersonDTO>
    {

        public PersonService() : base("person")
        {
        }

    }

}