using Test.Domain.Common;

namespace Test.Domain;

public class Student :BaseEntity
{
    public string StudentName { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public int SchoolID { get; set; }
    public School School { get; set; }
}
