namespace Curiosity.Core.Model.Exceptions;

public class UnknownRobotMovementException : InvalidInputException
{
    public UnknownRobotMovementException(char movement) : base($"wrong command: {movement}")
    {
    }
}