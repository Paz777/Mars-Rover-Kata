using NUnit.Framework;
using FluentAssertions;
using MarsRover.Model;

namespace MarsRoverTests;

public class Tests
{
    private Plateau plateau1;
    private Rover rover1;

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Given_A_Rover_It_Is_Placed_In_A_Valid_Position_On_The_Plateau()
    {
        plateau1 = new Plateau(5, 5);
        rover1 = new Rover(plateau1);
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'N'));
        rover1.CurrentPosition.XPosition.Should().Be(1);
        rover1.CurrentPosition.YPosition.Should().Be(2);
        rover1.CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void Given_A_Rover_It_Is_Placed_In_A_Valid_Position_On_The_Plateau_2()
    {
        plateau1 = new Plateau(10, 10);
        rover1 = new Rover(plateau1);
        rover1.PlaceRoverOnPlateau(new Position(6, 7, 'N'));
        rover1.CurrentPosition.XPosition.Should().Be(6);
        rover1.CurrentPosition.YPosition.Should().Be(7);
        rover1.CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void Plateau_Throws_Exception_If_Construction_Has_Negative_Values()
    {
        var ex = Assert.Throws<ArgumentException>(() => plateau1 = new Plateau(-1, 3));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));

        ex = Assert.Throws<ArgumentException>(() => plateau1 = new Plateau(1, -1));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));
    }

    [Test]
    public void Position_Throws_Exception_If_Construction_Has_Invalid_Values()
    {
        Position position;
        var ex = Assert.Throws<ArgumentException>(() => position = new Position(-1, 2, 'N'));
        Assert.That(ex.Message, Is.EqualTo("Position can not have negative values or invalid direction."));

        ex = Assert.Throws<ArgumentException>(() => position = new Position(1, -1, 'E'));
        Assert.That(ex.Message, Is.EqualTo("Position can not have negative values or invalid direction."));

        ex = Assert.Throws<ArgumentException>(() => position = new Position(1, 1, 'P'));
        Assert.That(ex.Message, Is.EqualTo("Position can not have negative values or invalid direction."));
    }

    [Test]
    public void Given_A_Rover_It_Should_Throw_An_Exception_If_The_Position_For_Plateau_Is_Invalid()
    {
        plateau1 = new Plateau(4, 4);
        rover1 = new Rover(plateau1);
        var ex = Assert.Throws<ArgumentException>(() => rover1.PlaceRoverOnPlateau(new Position(6, 6, 'E')));
        Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
    }

    [Test]
    public void Given_A_Rover_It_Should_Throw_An_Exception_If_The_Position_For_Plateau_Is_Invalid_2()
    {
        plateau1 = new Plateau(2, 2);
        rover1 = new Rover(plateau1);
        var ex = Assert.Throws<ArgumentException>(() => rover1.PlaceRoverOnPlateau(new Position(3, 3, 'W')));
        Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
    }
}