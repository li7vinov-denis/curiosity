namespace Curiosity.Core.Model.Exceptions;

public class InvalidRobotMovementsException : InvalidInputException
{
    public InvalidRobotMovementsException() : base("commands(R,L,F), e.g. \"RFRFRFRF\"")
    {
    }
}