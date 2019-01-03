using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TesteStore.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : Controller
    {
       
        [HttpGet]
        public ActionResult<object> Get()
        {
            return new { version = " Version 0.0.1 " };
        }

    }
}
