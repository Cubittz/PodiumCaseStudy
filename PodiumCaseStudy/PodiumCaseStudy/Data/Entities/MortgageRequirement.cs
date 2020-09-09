using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Entities
{
    public class MortgageRequirement
    {
        public Guid Id { get; set; }

        public Guid ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }

        public int PropertyValue { get; set; }
        public int DepositAmount { get; set; }
    }
}
