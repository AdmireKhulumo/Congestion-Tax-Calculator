using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CongestionTaxCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CongestionTaxController : Controller
    {
        [HttpGet]
        public String Get()
        {
            return "workin";
        }
    }
}

