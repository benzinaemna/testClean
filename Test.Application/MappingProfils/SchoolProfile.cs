using AutoMapper;
using Test.Application.Features.School.commands.CreateSchool;
using Test.Application.Features.School.commands.UpdateSchool;
using Test.Application.Features.School.Queries.GetAllSchools;
using Test.Application.Features.School.Queries.GetSchoolDetails;
using Test.Domain;

namespace Test.Application.MappingProfils;

public class SchoolProfile : Profile
{
    public SchoolProfile()
    {
        CreateMap<School, SchoolDto>().ReverseMap();
        CreateMap<School, SchoolDetailDto>().ReverseMap();
        CreateMap<CreateSchoolCommand, School>();
        CreateMap<UpdateSchoolCommand, School>();
    }

}
