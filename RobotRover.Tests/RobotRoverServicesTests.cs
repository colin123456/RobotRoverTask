using System;
using AutoFixture;
using Xunit;
using Moq;
using FluentAssertions;
using RobotRover.Services.interfaces;
using RobotRover.Services;
using RobotRover.Services.Enums;
using RobotRover.Services.Models;

namespace RobotRover.Tests
{
    public class RobotRoverServicesTests
    {
        private readonly Fixture _fixture;
        private readonly ControlMovement _sut;

        public RobotRoverServicesTests()
        {
            _fixture = new Fixture();
            _sut = new ControlMovement();
            _sut.SetPosition(10, 10, Direction.N);
        }
        [Fact]
        public void SetPosition_whenValidWithValidInputs_GridLocationIsSetWithSameVariables()
        {
            // Arrange
            var gridLocation = _fixture
                .Build<GridLocation>()
                .Create();

            // Act
            _sut.SetPosition(gridLocation.X, gridLocation.Y, gridLocation.Direction);

            // Assert
            gridLocation.Should().BeEquivalentTo(_sut.GridLocation);
        }

        [Fact]
        public void Move_WhenCalledWithValidR1CommandString_ReturnsGridLocationX11Y10DirectionE()
        {
            // Arrange
            string commands = "R1";
            
            var result = new GridLocation()
            {
                X = 11,
                Y = 10,
                Direction = Direction.E
            };

            // Act
            var gridLocation = _sut.Move(commands);

            // Assert
            gridLocation.Should()
                .BeOfType<GridLocation>()
                .And.BeEquivalentTo(result);
        }

        [Fact]
        public void Move_WhenCalledWithValidL1CommandString_ReturnsGridLocationX9Y10DirectionW()
        {
            // Arrange
            string commands = "L1";

            var result = new GridLocation()
            {
                X = 9,
                Y = 10,
                Direction = Direction.W
            };

            // Act
            var gridLocation = _sut.Move(commands);

            // Assert
            gridLocation.Should()
                .BeOfType<GridLocation>()
                .And.BeEquivalentTo(result);

        }

        [Fact]
        public void Move_WhenCalledWithValidL10CommandString_ReturnsGridLocationXMinus0Y10DirectionW()
        {
            // Arrange
            string commands = "L10";

            var result = new GridLocation()
            {
                X = 0,
                Y = 10,
                Direction = Direction.W
            };

            // Act
            var gridLocation = _sut.Move(commands);

            // Assert
            gridLocation.Should()
                .BeOfType<GridLocation>()
                .And.BeEquivalentTo(result);

        }

        [Fact]
        public void Move_WhenMCalledWithMultipleValidR1L1CommandStrings_ReturnsGridLocationX1Y1DirectionN()
        {
            // Arrange
            string commands = "R1L1";

            var result = new GridLocation()
            {
                X = 11,
                Y = 11,
                Direction = Direction.N
            };

            // Act
            var gridLocation = _sut.Move(commands);

            // Assert
            gridLocation.Should()
                .BeOfType<GridLocation>()
                .And.BeEquivalentTo(result);
        }
        
        [Fact]
        public void Move_WhenCalledWithMultipleValidL1R1Commands_ReturnGridLocationX9Y11DirectionN()
        {
            // Arrange
            string commands = "L1R1";

            var result = new GridLocation()
            {
                X = 9,
                Y = 11,
                Direction = Direction.N
            };

            // Act
            var gridLocation = _sut.Move(commands);

            // Assert
            gridLocation.Should()
                .BeOfType<GridLocation>()
                .And.BeEquivalentTo(result);
        }

        [Fact]
        public void Move_WhenCalledWithMultipleValidR1R3L2L1Commands_ReturnGridLocationX13Y8DirectionN()
        {
            // Arrange
            string commands = "R1R3L2L1";

            var result = new GridLocation()
            {
                X = 13,
                Y = 8,
                Direction = Direction.N
            };

            // Act
            var gridLocation = _sut.Move(commands);

            // Assert
            gridLocation.Should()
                .BeOfType<GridLocation>()
                .And.BeEquivalentTo(result);
        }

        [Fact]
        public void Move_WhenCalledWithNullLCommandString_ReturnArgumentNullException()
        {
            // Arrange
           

            // Act
            Action act = () => _sut.Move(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Move_WhenCalledWithEmptyString_ReturnArgumentException()
        {
            // Arrange

            // Act
            Action act = () => _sut.Move("");

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
