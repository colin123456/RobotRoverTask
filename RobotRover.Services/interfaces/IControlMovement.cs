using RobotRover.Services.Enums;
using RobotRover.Services.Models;

namespace RobotRover.Services.interfaces
{
    public interface IControlMovement
    {
        GridLocation GridLocation { get; }
        void SetPosition(int x, int y, Direction direction);
        GridLocation Move(string commands);
    }
}