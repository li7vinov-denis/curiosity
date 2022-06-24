namespace Curiosity.Core.Contracts.Robot;

public interface IRobotInfoAdapter
{
    void EndMovementInfo(IRobot robot);
    void MovementInfo(string message);
}