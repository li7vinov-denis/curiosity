using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Contracts.Movement;
using Curiosity.Core.Contracts.Robot;
using Curiosity.Core.Model.Coordinates;
using Curiosity.Core.Model.Directions;
using Curiosity.Core.Model.Exceptions;
using Curiosity.Core.Model.Movements;

namespace Curiosity.Core.Model;

public class InputParser
{
    private const string InputSeparator = " ";
    private const int PositionLength = 2;
    private const int RobotPositionAndDirectionLength = 3;
    private const int RobotDirectionLength = 1;
    private const int MovementMaximumCount = Configuration.MovementMaximumCount;

    private readonly IDictionary<string, DirectionType> _directions = new Dictionary<string, DirectionType>
    {
        {"n", DirectionType.North},
        {"e", DirectionType.East},
        {"s", DirectionType.South},
        {"w", DirectionType.West},
    };

    private readonly IReadOnlyCollection<string> _movements = new[]
    {
        "r",
        "l",
        "f"
    };

    private enum ParseType
    {
        Polygon,
        Robot
    }

    private enum RobotParseType
    {
        Robot,
        Movements
    }

    private ParseType _parse;
    private RobotParseType _robotParseType;
    private readonly OutputModel _parserOutputModel;
    public OutputModel Model => _parserOutputModel;
    private readonly IParserInfoAdapter _adapter;
    private readonly IRobotInfoAdapter _robotInfoAdapter;

    public InputParser(IParserInfoAdapter adapter = null, IRobotInfoAdapter robotInfoAdapter = null)
    {
        _adapter = adapter;
        _robotInfoAdapter = robotInfoAdapter;

        _parse = ParseType.Polygon;
        _robotParseType = RobotParseType.Robot;
        _parserOutputModel = new OutputModel();
    }

    public void ParseInput(IReadOnlyCollection<string> commands)
    {
        foreach (var command in commands)
        {
            Parse(command);
        }
    }

    public void Parse(string input)
    {
        switch (_parse)
        {
            case ParseType.Polygon:
                ParsePolygon(input);
                break;
            case ParseType.Robot:
                ParseRobot(input);
                break;
        }
    }

    private void ParsePolygon(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new InvalidPolygonInputException();

        var coordinatesRaw = input.Split(InputSeparator);

        if (coordinatesRaw.Length != PositionLength)
            throw new InvalidPolygonInputException();

        if (coordinatesRaw.Any(coordinate => !int.TryParse(coordinate, out _)))
            throw new InvalidPolygonInputException();

        var coordinates = coordinatesRaw.Select(int.Parse).ToArray();

        _parserOutputModel.Polygon =
            new Polygon(new Position(coordinates.FirstOrDefault(), coordinates.LastOrDefault()), _robotInfoAdapter);

        _parse = ParseType.Robot;
        _adapter?.RobotInputInfo();
    }

    private void ParseRobot(string input)
    {
        switch (_robotParseType)
        {
            case RobotParseType.Robot:
                ParseRobotInternal(input);
                break;
            case RobotParseType.Movements:
                ParseMovements(input);
                break;
        }
    }

    private void ParseRobotInternal(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new InvalidRobotInputException();

        var robotRaw = input.Split(InputSeparator);

        if (robotRaw.Length != RobotPositionAndDirectionLength)
            throw new InvalidRobotInputException();

        if (robotRaw.Take(PositionLength).Any(coordinate => !int.TryParse(coordinate, out _)))
            throw new InvalidRobotInputException();

        if (robotRaw.Skip(PositionLength).Take(RobotDirectionLength)
            .Any(direction => !_directions.ContainsKey(direction.ToLower())))
            throw new InvalidRobotInputException();

        var coordinates = robotRaw.Take(PositionLength).Select(int.Parse).ToArray();
        var direction = robotRaw.Skip(PositionLength).Take(RobotDirectionLength).FirstOrDefault();

        _parserOutputModel.Robots.Add(
            new Robot(Guid.NewGuid(), new Position(coordinates.FirstOrDefault(), coordinates.LastOrDefault()),
                ParseDirectionType(direction)), new List<IMovement>());

        _robotParseType = RobotParseType.Movements;
        _adapter?.MovementInputInfo();
    }

    private void ParseMovements(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new InvalidRobotMovementsException();

        var movementList = input.Split(InputSeparator);

        if (!movementList.Any())
            throw new InvalidRobotMovementsException();

        if (movementList.Length > MovementMaximumCount)
            throw new RobotMovementsMaximumCountOverflowException();

        if (input.Any(x => !_movements.Contains(x.ToString().ToLower())))
            throw new InvalidRobotMovementsException();

        var inputValidation = _movements.ToDictionary(x => x, input.ToLower().Contains);

        if (inputValidation.All(x => !x.Value))
            throw new InvalidRobotMovementsException();

        foreach (var movementRaw in input)
        {
            _parserOutputModel.Robots.Last().Value.Add(ParseMovement(movementRaw));
        }

        _robotParseType = RobotParseType.Robot;

        _adapter?.RobotInputInfo();
    }

    private DirectionType ParseDirectionType(string input) => _directions[input.ToLower()];

    private IMovement ParseMovement(char input) =>
        input.ToString().ToLower() switch
        {
            "l" => new Left(),
            "r" => new Right(),
            "f" => new Forward(),
            _ => throw new UnknownRobotMovementException(input)
        };

    public class OutputModel
    {
        public IPolygon Polygon { get; internal set; }
        public Dictionary<IRobot, IList<IMovement>> Robots { get; }

        public OutputModel()
        {
            Robots = new Dictionary<IRobot, IList<IMovement>>();
        }
    }
    
    public interface IParserInfoAdapter
    {
        void RobotInputInfo();
        void MovementInputInfo();
    }
}