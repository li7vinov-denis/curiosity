namespace Curiosity.Core.Model.Exceptions;

public abstract class InvalidInputException : Exception
{
    protected InvalidInputException(string pattern) : base($"Please enter valid data: {pattern}")
    {
    }
}