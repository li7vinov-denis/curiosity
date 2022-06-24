using Curiosity.Core.Model;

namespace Curiosity;

public class ParserInfoAdapter : InputParser.IParserInfoAdapter
{
    public void RobotInputInfo()
    {
        Console.WriteLine("");
        Console.WriteLine("Please enter robot parameters, e.g. \"5 4 E\"");
    }

    public void MovementInputInfo()
    {
        Console.WriteLine("");
        Console.WriteLine("Please enter robot command, e.g. \"RLRLFLRLRRL\"");
    }
}