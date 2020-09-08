using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PodiumCaseStudy.Data.Entities;

namespace PodiumCaseStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ApplicantController> _logger;

        public ApplicantController(ILogger<ApplicantController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Applicant Get(string id)
        {
            return new Applicant
            {
                Id = id,
                FirstName = "Paul",
                LastName = "Cubitt",
                Email = "paul.cubitt@testdata.com",
                DateOfBirth = new DateTime(1973, 12, 28)
            };
        }

        [HttpPost]
        public Applicant Post(Applicant applicant)
        {
            return applicant;
        }
    }
}
