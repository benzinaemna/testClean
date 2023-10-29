using AutoMapper;
using Test.Application.Features.Student.Commands.CreateStudent;
using Test.Application.Features.Student.Commands.UpdateStudent;
using Test.Application.Features.Student.Queries.GetAllStudents;
using Test.Application.Features.Student.Queries.GetStudentDetails;
using Test.Domain;

namespace Test.Application.MappingProfils
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentDetailDto>().ReverseMap();
            CreateMap<CreateStudentCommand, Student>();  
            CreateMap<UpdateStudentCommand, Student>();
        }
    }
}
