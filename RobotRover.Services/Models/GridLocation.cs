using RobotRover.Services.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRover.Services.Models
{
    public class GridLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }
}
