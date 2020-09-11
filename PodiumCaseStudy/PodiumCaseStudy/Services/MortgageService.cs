using Microsoft.AspNetCore.Http.Connections;
using Microsoft.VisualBasic.CompilerServices;
using PodiumCaseStudy.Data.Entities;
using PodiumCaseStudy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Services
{
    public class MortgageService  : IMortgageService
    {
        private readonly IMortgageProposalRepository _proposalRepository;
        private readonly IMortgageRequirementRepository _requirementRepository;
        private readonly IProductService _productService;
        private readonly IApplicantService _applicantService;


        public MortgageService(IMortgageProposalRepository proposalRepository,
            IMortgageRequirementRepository requirementRepository,
            IProductService productService,
            IApplicantService applicantService)
        {
            _proposalRepository = proposalRepository;
            _requirementRepository = requirementRepository;
            _productService = productService;
            _applicantService = applicantService;
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

            var applicant = await _applicantService.GetById(requirement.ApplicantId);
            if (!_applicantService.CheckApplicantAge(applicant.DateOfBirth))
            {
                return proposal;
            }

            foreach (var product in products)
            {
                var ltv = CalculateLTV(requirement.PropertyValue, requirement.DepositAmount);
                if (ltv <= product.LoanToValue)
                {
                    proposalProducts.Add(new MortgageProposalProduct
                    {
                        Id = Guid.NewGuid(),
                        MortgageProposalId = proposal.Id,
                        ProductId = product.Id,
                        Product = product
                    }); ;
                }
            }

            proposal.Products = proposalProducts;
            return proposal;
        }

        private decimal CalculateLTV(decimal propertyValue, decimal depositAmount)
        {
            var mortgage = propertyValue - depositAmount;
            return mortgage / propertyValue;
        }
    }
}
