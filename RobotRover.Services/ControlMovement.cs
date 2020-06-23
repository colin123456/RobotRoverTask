using RobotRover.Services.Enums;
using RobotRover.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using RobotRover.Services.Helper;
using RobotRover.Services.interfaces;

namespace RobotRover.Services
{
    public class ControlMovement : IControlMovement
    {
        private readonly Dictionary<Direction, Direction> _directionsRight = null;
        private readonly Dictionary<Direction, Direction> _directionsLeft = null;

        public ControlMovement()
        {
            _directionsRight = new Dictionary<Direction, Direction>
            {
                {Direction.N, Direction.E},
                {Direction.E, Direction.S},
                {Direction.S, Direction.W},
                {Direction.W, Direction.N}
            };

            _directionsLeft = new Dictionary<Direction, Direction>
            {
                {Direction.N, Direction.W},
                {Direction.W, Direction.S},
                {Direction.S, Direction.E},
                {Direction.E, Direction.N}
            };
        }

        public GridLocation GridLocation { get; } = new GridLocation();

        public void SetPosition(int x, int y, Direction direction)
        {
            GridLocation.Direction = direction;
            GridLocation.X = x;
            GridLocation.Y = y;
        }

        public GridLocation Move(string commands)
        {
            try
            {
                if (commands == null) throw new ArgumentNullException(nameof(commands));
                if (commands.Length == 0) throw new ArgumentException("Zero-length string invalid");

                var moveCoordinates = CommandsToCoordinates.ConvertCommandsToMoveCoordinates(commands);

                foreach (var moveCoordinate in moveCoordinates)
                {
                    UpdateNextGridLocation(moveCoordinate);
                }

                return GridLocation;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
       
        private bool UpdateNextGridLocation(MoveCoordinate moveCoordinate)
        {
            if (moveCoordinate == null) throw new ArgumentNullException(nameof(moveCoordinate));
            
            var success = false;

            GridLocation.Direction = moveCoordinate.Rotation == Rotation.Right
                ? _directionsRight[GridLocation.Direction]
                : _directionsLeft[GridLocation.Direction];

            switch (GridLocation.Direction)
            {
                case Direction.N:
                    MoveNorth(moveCoordinate.PositionToMove);
                    success = true;
                    break;

                case Direction.E:
                    MoveEast(moveCoordinate.PositionToMove);
                    success = true;
                    break;

                case Direction.S:
                    MoveSouth(moveCoordinate.PositionToMove);
                    success = true;
                    break;

                case Direction.W:
                    MoveWest(moveCoordinate.PositionToMove);
                    success = true;
                    break;

                default:
                    success = false;
                    break;
            }

            return success;
        }

        private void MoveNorth(int positionToMove)
        {
            GridLocation.Y += positionToMove;
        }
        private void MoveEast(int positionToMove)
        {
            GridLocation.X += positionToMove;
        }
        private void MoveSouth(int positionToMove)
        {
            GridLocation.Y -= positionToMove;
        }
        private void MoveWest(int positionToMove)
        {
            GridLocation.X -= positionToMove;
        }
    }
}
