
using FluentValidation.Results;

namespace Test.Application.Exceptions;

public class BadRequestException:Exception
{
    public IDictionary<string, string[]> validationErrors {  get; set; }
    public BadRequestException(string message):base(message)
    {
        
    }
    public BadRequestException(string message , ValidationResult validationResult):base(message)
    {
        validationErrors = validationResult.ToDictionary();
    }
}
