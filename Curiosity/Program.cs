using Curiosity;
using Curiosity.Core.Model;
using Curiosity.Core.Model.Exceptions;

const string exitCommand = "exit";
const string stopRobotsInputCommand = "stop_robots";

Console.WriteLine("Please provide the input data");
Console.WriteLine($"For exit provide \"{exitCommand}\" command");
Console.WriteLine("First of all for rectangle, required input is: two digits, separated by space, e.g.(5 3)");

var inputParser = new InputParser(new ParserInfoAdapter(), new RobotInfoAdapter());

while (inputParser.Model?.Polygon is null)
{
    var command = Console.ReadLine();

    if (command == exitCommand)
        return;

    try
    {
        inputParser.Parse(command);
    }
    catch (InvalidInputException e)
    {
        Console.WriteLine(e.Message);
    }
}

Console.WriteLine($"If robots count for that rectangle is enough provide \"{stopRobotsInputCommand}\" command");

var isRun = true;

while (isRun)
{
    var command = Console.ReadLine();
    
    if (command == exitCommand)
        return;
    
    if (command == stopRobotsInputCommand)
    {
        isRun = false;
        break;
    }

    try
    {
        inputParser.Parse(command);
    }
    catch (InvalidInputException e)
    {
        Console.WriteLine(e.Message);
    }
}

var polygon = inputParser.Model.Polygon;
var robotMovements = inputParser.Model.Robots;

foreach (var (robot, movements) in robotMovements)
{
    polygon.MoveInside(robot, movements.ToArray());
}

Console.WriteLine("Enter any symbol to exit");
Console.ReadLine();