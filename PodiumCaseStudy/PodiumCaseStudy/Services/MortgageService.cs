using Microsoft.AspNetCore.Http.Connections;
using PodiumCaseStudy.Data.Entities;
using PodiumCaseStudy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Services
{
    public class MortgageService  : IMortgageService
    {
        private readonly IMortgageProposalRepository _repository;
        private readonly IProductService _productService;

        public MortgageService(IMortgageProposalRepository repository,
            IProductService productService)
        {
            _repository = repository;
            _productService = productService;
        }

        public async Task<MortgageProposal> GetById(Guid id)
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
            var products = await _productService.GetAll();
            return new MortgageProposal {
                Id = new System.Guid(),
                MortgageRequirement = requirement,
                MortgageRequirementId = requirement.Id,
                Products = products
            };
        }
    }
}
