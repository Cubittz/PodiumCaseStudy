using PodiumCaseStudy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Services
{
    public class ApplicantService  : IApplicantService
    {
        public Applicant GetById(string id)
        {
            var applicant = new Applicant
            {
                Id = id,
                FirstName = "Paul",
                LastName = "Cubitt",
                Email = "paul.cubitt@testdata.com",
                DateOfBirth = new DateTime(1973, 12, 28)
            };
            return applicant;
        }
        public Applicant CreateApplicant(Applicant applicant)
        {
            return applicant;
        }
    }
}
