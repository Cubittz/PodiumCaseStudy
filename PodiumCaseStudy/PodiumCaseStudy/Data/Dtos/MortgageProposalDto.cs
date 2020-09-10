using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Dtos
{
    public class MortgageProposalDto
    {
        public Guid Id { get; set; }

        public Guid MortgageRequirementId { get; set; }
        public MortgageRequirementDto MortgageRequirement { get; set; }

        public IEnumerable<MortgageProposalProductDto> Products { get; set; }
    }
}
