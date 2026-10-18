using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions
{
    public class SampleNotFoundException(string message)
        : AppException(ErrorKind.NotFound, "sample.not_found", message);
}
