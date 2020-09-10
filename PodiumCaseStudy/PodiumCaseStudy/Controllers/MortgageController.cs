using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PodiumCaseStudy.Data.Dtos;
using PodiumCaseStudy.Data.Entities;
using PodiumCaseStudy.Services;

namespace PodiumCaseStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MortgageController : ControllerBase
    {
        private readonly ILogger<MortgageController> _logger;
        private readonly IMortgageService _mortgageService;
        private readonly IMapper _mapper;

        public MortgageController(ILogger<MortgageController> logger,
            IMortgageService mortgageService,
            IMapper mapper)
        {
            _logger = logger;
            _mortgageService = mortgageService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<MortgageProposal>> PostMortgageProposal(MortgageRequirementDto requirementDto)
        {
            var requirement = _mapper.Map<MortgageRequirement>(requirementDto);
            var proposal = await _mortgageService.CreateProposal(requirement);
            var proposalDto = _mapper.Map<MortgageProposalDto>(proposal);

            return CreatedAtAction("PostMortgageProposal", new { id = proposal.Id }, proposalDto);
        }
    }
}
