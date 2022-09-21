using NUnit.Framework;
using FluentAssertions;
using MarsRover.Model;
using MarsRover.Validator;

namespace MarsRoverTests;

public class RoverTest
{
    private Rover rover1;

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void When_Rover_Is_Facing_North_And_Instructed_To_Spin_Right_It_Should_Face_East()
    {
        rover1 = new Rover(new Position(1, 2, 'N'));
        rover1.SpinRight();
        rover1.CurrentPosition.Direction.Should().Be('E');
    }

    [Test]
    public void When_Rover_Is_Facing_East_And_Instructed_To_Spin_Right_It_Should_Face_South()
    {
        rover1 = new Rover(new Position(1, 2, 'E'));
        rover1.SpinRight();
        rover1.CurrentPosition.Direction.Should().Be('S');
    }

    [Test]
    public void When_Rover_Is_Facing_South_And_Instructed_To_Spin_Right_It_Should_Face_West()
    {
        rover1 = new Rover(new Position(1, 2, 'S'));
        rover1.SpinRight();
        rover1.CurrentPosition.Direction.Should().Be('W');
    }

    [Test]
    public void When_Rover_Is_Facing_West_And_Instructed_To_Spin_Right_It_Should_Face_North()
    {
        rover1 = new Rover(new Position(1, 2, 'W'));
        rover1.SpinRight();
        rover1.CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void When_Rover_Is_Facing_North_And_Instructed_To_Spin_Left_It_Should_Face_West()
    {
        rover1 = new Rover(new Position(1, 2, 'N'));
        rover1.SpinLeft();
        rover1.CurrentPosition.Direction.Should().Be('W');
    }

    [Test]
    public void When_Rover_Is_Facing_West_And_Instructed_To_Spin_Left_It_Should_Face_South()
    {
        rover1 = new Rover(new Position(1, 2, 'W'));
        rover1.SpinLeft();
        rover1.CurrentPosition.Direction.Should().Be('S');
    }

    [Test]
    public void When_Rover_Is_Facing_South_And_Instructed_To_Spin_Left_It_Should_Face_East()
    {
        rover1 = new Rover(new Position(1, 2, 'S'));
        rover1.SpinLeft();
        rover1.CurrentPosition.Direction.Should().Be('E');
    }

    [Test]
    public void When_Rover_Is_Facing_East_And_Instructed_To_Spin_Left_It_Should_Face_North()
    {
        rover1 = new Rover(new Position(1, 2, 'E'));
        rover1.SpinLeft();
        rover1.CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void When_Rover_Is_Facing_North_And_Instructed_To_Move_It_Should_Move_1_Grid_Position()
    {
        rover1 = new Rover(new Position(1, 2, 'N'));
        rover1.Move();
        rover1.CurrentPosition.XPosition.Should().Be(1);
        rover1.CurrentPosition.YPosition.Should().Be(3);
        rover1.CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void When_Rover_Is_Facing_East_And_Instructed_To_Move_It_Should_Move_1_Grid_Position()
    {
        rover1 = new Rover(new Position(1, 2, 'E'));
        rover1.Move();
        rover1.CurrentPosition.XPosition.Should().Be(2);
        rover1.CurrentPosition.YPosition.Should().Be(2);
        rover1.CurrentPosition.Direction.Should().Be('E');
    }

    [Test]
    public void When_Rover_Is_Facing_South_And_Instructed_To_Move_It_Should_Move_1_Grid_Position()
    {
        rover1 = new Rover(new Position(1, 2, 'S'));
        rover1.Move();
        rover1.CurrentPosition.XPosition.Should().Be(1);
        rover1.CurrentPosition.YPosition.Should().Be(1);
        rover1.CurrentPosition.Direction.Should().Be('S');
    }

    [Test]
    public void When_Rover_Is_Facing_West_And_Instructed_To_Move_It_Should_Move_1_Grid_Position()
    {
        rover1 = new Rover(new Position(1, 2, 'W'));
        rover1.Move();
        rover1.CurrentPosition.XPosition.Should().Be(0);
        rover1.CurrentPosition.YPosition.Should().Be(2);
        rover1.CurrentPosition.Direction.Should().Be('W');
    }
}