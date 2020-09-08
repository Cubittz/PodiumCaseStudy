using PodiumCaseStudy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Services
{
    public interface IApplicantService
    {
        Applicant GetById(string id);

        Applicant CreateApplicant(Applicant applicant);
    }
}
