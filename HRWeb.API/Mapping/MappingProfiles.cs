using AutoMapper;
using HRWeb.API.Models;
using HRWeb.Data.Entities;
using System.Net;

namespace HRWeb.API.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RecruiterInfo, Recruiter>();
        }
    }
}
