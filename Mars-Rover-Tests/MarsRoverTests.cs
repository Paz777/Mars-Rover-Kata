using NUnit.Framework;
using FluentAssertions;
using MarsRover.Model;

namespace MarsRoverTests;

public class Tests
{
    private Plateau plateau;
    private Rover rover1;

    [SetUp]
    public void Setup()
    {
        //plateau = new Plateau(5, 5);
        //rover1 = new Rover(plateau);
    }

    [Test]
    public void Given_A_Rover_It_Is_Placed_In_A_Valid_Position_On_The_Plateau()
    {
        plateau = new Plateau(5, 5);
        rover1 = new Rover(plateau);
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'N'));
        rover1.CurrentPosition.X.Should().Be(1);
        rover1.CurrentPosition.Y.Should().Be(2);
        rover1.CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void Given_A_Rover_It_Is_Placed_In_A_Invalid_Position_On_The_Plateau()
    {
        var ex = Assert.Throws<ArgumentException>(() => plateau = new Plateau(-1, 3));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));

        ex = Assert.Throws<ArgumentException>(() => plateau = new Plateau(1, -1));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));

    }
}