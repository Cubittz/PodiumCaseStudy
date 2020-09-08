using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PodiumCaseStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MortgageController : ControllerBase
    {
        private readonly ILogger<MortgageController> _logger;

        public MortgageController(ILogger<MortgageController> logger)
        {
            _logger = logger;
        }

    }
}
