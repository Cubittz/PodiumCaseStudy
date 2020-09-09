using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Entities
{
    public class MortgageProposal
    {
        public Guid Id { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public Guid ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }

        public Guid MortgageRequirementId { get; set; }
        public virtual MortgageRequirement MortgageRequirement { get; set; }
    }
}
