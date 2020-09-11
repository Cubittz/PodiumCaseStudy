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
        Task<Applicant> GetById(Guid id);

        Task<Applicant> CreateApplicant(Applicant applicant);

        bool CheckApplicantAge(DateTime dateOfBirth);
    }
}
