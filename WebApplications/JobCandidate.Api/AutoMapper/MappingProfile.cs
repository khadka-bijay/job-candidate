using AutoMapper;
using JobCandidate.Api.Models;
using JobCandidate.Data.Entities;

namespace JobCandidate.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CandidateModel, Candidate>();
        }
    }
}
