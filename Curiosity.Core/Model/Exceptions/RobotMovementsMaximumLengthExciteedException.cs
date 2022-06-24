namespace Curiosity.Core.Model.Exceptions;

public class RobotMovementsMaximumCountOverflowException : InvalidInputException
{
    public RobotMovementsMaximumCountOverflowException() : base($"maximum commands count is {Configuration.MovementMaximumCount}")
    {
    }
}