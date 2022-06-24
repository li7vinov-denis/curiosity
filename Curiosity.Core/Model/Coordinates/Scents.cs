using Curiosity.Core.Contracts.Coordinates;
using Curiosity.Core.Contracts.Robot;

namespace Curiosity.Core.Model.Coordinates;

public class Scents
{
    private readonly HashSet<Scent> _scents;

    public Scents()
    {
        _scents = new HashSet<Scent>();
    }

    public List<IRobot> this[IPosition position]
    {
        get
        {
            var entry = _scents.FirstOrDefault(entry => entry.Position.X == position.X && entry.Position.Y == position.Y);

            return entry?.Robots;
        }

        set => _scents.Add(new (position, value));
    }

    public bool IsThatPositionScent(IPosition position, IRobot robot)
    {
        if (this[position]?.Any() == true)
        {
            var lostRobot = this[position].FirstOrDefault(x => x.Id != robot.Id);

            return lostRobot is not null;
        }

        return false;
    }
    
    public void Add(IPosition position, IRobot robot)
    {
        var scent = this[position];

        if(scent == null || !scent.Any())
        {
            this[position] = new ()
            {
                robot
            };
        }
        else
        {
            scent.Add(robot);
        }
    }

    private record Scent(IPosition Position, List<IRobot> Robots);
}