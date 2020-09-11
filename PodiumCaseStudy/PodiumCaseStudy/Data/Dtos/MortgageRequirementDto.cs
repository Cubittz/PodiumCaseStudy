using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Dtos
{
    public class MortgageRequirementDto
    {
        public string Id { get; set; }
        public string ApplicantId { get; set; }
        public decimal PropertyValue { get; set; }
        public decimal DepositAmount { get; set; }
    }
}
