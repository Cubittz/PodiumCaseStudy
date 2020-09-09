using Microsoft.AspNetCore.Http.Connections;
using PodiumCaseStudy.Data.Entities;
using PodiumCaseStudy.Data.Repositories;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Services
{
    public class MortgageService  : IMortgageService
    {
        private readonly IMortgageProposalRepository _repository;

        public MortgageService(IMortgageProposalRepository repository)
        {
            _repository = repository;
        }

        public async Task<MortgageProposal> GetById(string id)
        {
            var proposal = await _repository.GetByIdAsync(id);
            return proposal;
        }

        public async Task<MortgageProposal> CreateProposal(MortgageRequirement requirement)
        {
            var proposal = await ProposalCalculator(requirement);
            var newProposal = await _repository.CreateAsync(proposal);
            return newProposal;
        }

        private async Task<MortgageProposal> ProposalCalculator(MortgageRequirement requirement)
        {
            return new MortgageProposal { };
        }
    }
}
