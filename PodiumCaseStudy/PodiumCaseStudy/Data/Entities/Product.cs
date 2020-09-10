using PodiumCaseStudy.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Lender { get; set; }
        public decimal InterestRate { get; set; }
        public LoanType LoanType { get; set; }
        public decimal LoanToValue { get; set; }

    }
}
