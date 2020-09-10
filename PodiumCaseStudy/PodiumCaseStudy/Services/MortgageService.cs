using Microsoft.AspNetCore.Http.Connections;
using PodiumCaseStudy.Data.Entities;
using PodiumCaseStudy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Services
{
    public class MortgageService  : IMortgageService
    {
        private readonly IMortgageProposalRepository _proposalRepository;
        private readonly IMortgageRequirementRepository _requirementRepository;
        private readonly IProductService _productService;

        public MortgageService(IMortgageProposalRepository proposalRepository,
            IMortgageRequirementRepository requirementRepository,
            IProductService productService)
        {
            _proposalRepository = proposalRepository;
            _requirementRepository = requirementRepository;
            _productService = productService;
        }

        public async Task<MortgageProposal> GetById(Guid id)
        {
            var proposal = await _proposalRepository.GetByIdAsync(id);
            return proposal;
        }

        public async Task<MortgageProposal> CreateProposal(MortgageRequirement requirement)
        {
            await _requirementRepository.CreateAsync(requirement);
            return await ProposalCalculator(requirement);
        }

        private async Task<MortgageProposal> ProposalCalculator(MortgageRequirement requirement)
        {
            var proposal = new MortgageProposal
            {
                Id = Guid.NewGuid(),
                MortgageRequirement = requirement,
                MortgageRequirementId = requirement.Id,
                Products = new List<MortgageProposalProduct>()
            };

            await _proposalRepository.CreateAsync(proposal);
            
            var products = await _productService.GetAll();
            var proposalProducts = new List<MortgageProposalProduct>();
            foreach(var product in products)
            {
                proposalProducts.Add(new MortgageProposalProduct
                {
                    Id = Guid.NewGuid(),
                    MortgageProposalId = proposal.Id,
                    ProductId = product.Id,
                    Product = product
                }); ;
            }

            proposal.Products = proposalProducts;
            return proposal;
        }
    }
}
