using PodiumCaseStudy.Data.Entities;
using PodiumCaseStudy.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Services
{
    public class ApplicantService  : IApplicantService
    {
        private readonly IApplicantRepository _repository;
        public ApplicantService(IApplicantRepository repository)
        {
            _repository = repository;
        }

        public async Task<Applicant> GetById(Guid id)
        {
            var applicant = await _repository.GetByIdAsync(id);
            return applicant;
        }

        public async Task<Applicant> CreateApplicant(Applicant applicant)
        {
            var newApplicant = await _repository.CreateAsync(applicant);
            return newApplicant;
        }
    }
}
