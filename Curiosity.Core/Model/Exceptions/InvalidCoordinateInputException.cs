namespace Curiosity.Core.Model.Exceptions;

public class InvalidCoordinateInputException : InvalidInputException
{
    public InvalidCoordinateInputException() : base("coordinate value should be under 50")
    {
    }
}