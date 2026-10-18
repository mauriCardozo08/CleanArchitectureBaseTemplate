using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions
{
    public class SampleAlreadyExistsException(string message)
        : AppException(ErrorKind.Conflict, "sample.already_exists", message);
}
