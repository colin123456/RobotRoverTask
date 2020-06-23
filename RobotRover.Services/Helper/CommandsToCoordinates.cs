using RobotRover.Services.Enums;
using RobotRover.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRover.Services.Helper
{
    public class CommandsToCoordinates
    {

        public static IEnumerable<MoveCoordinate> ConvertCommandsToMoveCoordinates(string commands)
        {
            

            var coordinates = new List<MoveCoordinate>();

            int count = 0;
            while (count < commands.Length)
            {
                string posStringToMove = string.Empty;
                char rotationLetter = '\0';

                if (char.IsLetter(commands[count]))
                {
                    rotationLetter = commands[count];
                    count++;
                }

                while (char.IsNumber(commands[count]))
                {
                    posStringToMove = posStringToMove + commands[count];

                    count++;

                    if (count >= commands.Length || char.IsLetter(commands[count])) break;
                }

                var posIntToMove = int.Parse(posStringToMove);
                var rotation = rotationLetter == 'R' ? Rotation.Right : Rotation.Left;

                var moveCoordinate = new MoveCoordinate
                {
                    Rotation = rotation,
                    PositionToMove = posIntToMove
                };
                coordinates.Add(moveCoordinate);
            }

            return coordinates;
        }
    }
}
