using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projet2Appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
         [HttpGet]
         public IEnumerable<String>Get()
        {
            List<String> strings = new List<string> { "Hello", "world", "!" };
            return strings;
        }

    }
}
