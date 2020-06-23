using RobotRover.Services.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRover.Services.Models
{
    public class MoveCoordinate
    {
        public Rotation Rotation { get; set; }
        public int PositionToMove { get; set; }
    }
}
