using System;
using System.Reflection.Metadata.Ecma335;
//using RobotRover.RobotRoverService;
//using RobotRover.RobotRoverService.Enums;
using RobotRover.Services;
using RobotRover.Services.Enums;
using RobotRover.Services.interfaces;

namespace RobotRover
{
    class Program
    {
        static void Main(string[] args)
        {
            IControlMovement controlMovement = new ControlMovement();
            controlMovement.SetPosition(10, 10, Direction.N);

            controlMovement.Move("R1R3L2L1");
            Console.WriteLine($"X:{controlMovement.GridLocation.X} Y:{controlMovement.GridLocation.Y} Direction:{controlMovement.GridLocation.Direction}");
        }
    }
}
