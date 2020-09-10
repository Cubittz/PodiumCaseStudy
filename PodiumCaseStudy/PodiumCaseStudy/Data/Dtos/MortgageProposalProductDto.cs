using PodiumCaseStudy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Dtos
{
    public class MortgageProposalProductDto
    {
        public Guid Id { get; set; }

        public Guid MortgageProposalId { get; set; }

        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
