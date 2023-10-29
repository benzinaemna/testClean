using Test.Domain.Common;

namespace Test.Domain;

public class School : BaseEntity
{

    public string SchoolName { get; set; }
    public string SchoolAdress { get; set; }
    public ICollection<Student> Students { get; set; }
}
