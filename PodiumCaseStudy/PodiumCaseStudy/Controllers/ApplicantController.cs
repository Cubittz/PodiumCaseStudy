﻿using System;
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
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly ILogger<ApplicantController> _logger;
        private readonly IApplicantService _applicantService;
        private readonly IMapper _mapper;


        public ApplicantController(ILogger<ApplicantController> logger, 
            IApplicantService applicantService,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _applicantService = applicantService;
        }

        [HttpGet]
        public async Task<ApplicantDto> GetApplicant(Guid id)
        {
            var applicant = await _applicantService.GetById(id);
            var applicantDto = _mapper.Map<ApplicantDto>(applicant);
            return applicantDto;
        }

        [HttpPost]
        public async Task<ActionResult<Applicant>> PostApplicant(ApplicantDto applicantDto)
        {
            var applicant = _mapper.Map<Applicant>(applicantDto);
            await _applicantService.CreateApplicant(applicant);

            return CreatedAtAction("PostApplicant", new { id = applicant.Id }, applicant);
        }
    }
}
