using PodiumCaseStudy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Repositories
{
    public class MortgageRequirementRepository : BaseRepository<MortgageRequirement>, IMortgageRequirementRepository
    {
        public MortgageRequirementRepository(PodiumDbContext dbContext) : base(dbContext)
        {

        }
    }
}
