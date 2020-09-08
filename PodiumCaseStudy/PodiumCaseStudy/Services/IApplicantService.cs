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
        Task<Applicant> GetById(string id);

        Task<Applicant> CreateApplicant(Applicant applicant);
    }
}
