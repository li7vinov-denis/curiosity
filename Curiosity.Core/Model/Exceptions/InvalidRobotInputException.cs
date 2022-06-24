namespace Curiosity.Core.Model.Exceptions;

public class InvalidRobotInputException : InvalidInputException
{
    public InvalidRobotInputException() : base("two digits and one letter for direction(N,E,S,W) separated by space, e.g. \"5 3 E\"")
    {
    }
}