using PodiumCaseStudy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Services
{
    public interface IMortgageService
    {
        Task<MortgageProposal> GetById(string id);

        Task<MortgageProposal> CreateProposal(MortgageRequirement requirement);
    }
}
