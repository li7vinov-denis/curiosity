namespace Curiosity.Core.Model.Exceptions;

public class InvalidPolygonInputException : InvalidInputException
{
    public InvalidPolygonInputException() : base("two digits separated by space, e.g. \"5 3\"")
    {
    }
}