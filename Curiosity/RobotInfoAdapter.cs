using Curiosity.Core.Contracts.Robot;

namespace Curiosity;

public class RobotInfoAdapter : IRobotInfoAdapter
{
    public void EndMovementInfo(IRobot robot)
    {
        Console.WriteLine($"Robot position is: {robot.CurrentPosition.X} {robot.CurrentPosition.Y} and direction is {robot.CurrentDirection}, state is {robot.State}");
    }

    public void MovementInfo(string message)
    {
        Console.WriteLine(message);
    }
}