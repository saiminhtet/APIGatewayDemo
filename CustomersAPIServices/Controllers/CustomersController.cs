using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomersAPIServices.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Catcher Wong", "James Li" };
        }

        //[Authorize]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Catcher Wong - {id}";
        }
    }
}
