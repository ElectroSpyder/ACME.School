using ACME.School.Core.Domain.Entities;
using ACME.School.Core.Models;
using AutoMapper;

namespace ACME.School.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contract, ContractModel>().ReverseMap();
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<Course, CourseModel>().ReverseMap();
        }
    }
}
