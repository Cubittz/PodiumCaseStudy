using AutoMapper;
using PodiumCaseStudy.Data.Dtos;
using PodiumCaseStudy.Data.Entities;

namespace PodiumCaseStudy.Data
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Applicant, ApplicantDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<MortgageRequirement, MortgageRequirementDto>().ReverseMap();
            CreateMap<MortgageProposal, MortgageProposalDto>().ReverseMap();
            CreateMap<MortgageProposalProduct, MortgageProposalProductDto>().ReverseMap();

        }
    }
}
