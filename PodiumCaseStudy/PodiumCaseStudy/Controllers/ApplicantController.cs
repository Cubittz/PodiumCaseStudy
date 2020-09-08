using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PodiumCaseStudy.Data.Entities;
using PodiumCaseStudy.Services;

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
        private readonly IApplicantService _applicantService;

        public ApplicantController(ILogger<ApplicantController> logger, IApplicantService applicatService)
        {
            _logger = logger;
            _applicantService = applicatService;
        }

        [HttpGet]
        public Applicant Get(string id)
        {
            return _applicantService.GetById(id);
        }

        [HttpPost]
        public Applicant Post(Applicant applicant)
        {
            return _applicantService.CreateApplicant(applicant);
        }
    }
}
