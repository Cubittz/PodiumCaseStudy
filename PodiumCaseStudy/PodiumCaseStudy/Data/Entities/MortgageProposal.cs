using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Entities
{
    public class MortgageProposal
    {
        public Guid Id { get; set; }

        public Guid MortgageRequirementId { get; set; }
        public virtual MortgageRequirement MortgageRequirement { get; set; }

        public IEnumerable<MortgageProposalProduct> Products { get; set; } = new List<MortgageProposalProduct>();

    }
}
