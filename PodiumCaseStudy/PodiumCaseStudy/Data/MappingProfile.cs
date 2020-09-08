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
        }
    }
}
