using NUnit.Framework;
using FluentAssertions;
using MarsRover.Model;

namespace MarsRoverTests;

public class Tests
{
    private Rover rover1;
    private Plateau plateau;

    [SetUp]
    public void Setup()
    {
        plateau = new Plateau(5, 5);
        rover1 = new Rover(plateau);
    }

    [Test]
    public void Given_A_Rover_It_Is_Placed_In_A_Valid_Position_On_The_Plateau()
    {
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'N'));
        rover1.CurrentPosition.X.Should().Be(1);
        rover1.CurrentPosition.Y.Should().Be(2);
        rover1.CurrentPosition.Direction.Should().Be('N');
    }
}