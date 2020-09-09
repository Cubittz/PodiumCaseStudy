using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Dtos
{
    public class MortgageProposalDto
    {
        public string Id { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }

        public Guid ApplicantId { get; set; }
        public virtual ApplicantDto Applicant { get; set; }

        public Guid MortgageRequirementId { get; set; }
        public virtual MortgageRequirementDto MortgageRequirement { get; set; }
    }
}
