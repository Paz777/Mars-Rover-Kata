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
    public void Given_A_Rover_It_Should_Throw_An_Exception_If_The_Position_Is_Outside_The_Plateau()
    {
        plateau1 = new Plateau(4, 4);
        rover1 = new Rover(plateau1);
        var ex = Assert.Throws<ArgumentException>(() => rover1.PlaceRoverOnPlateau(new Position(6, 6, 'E')));
        Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
    }

    [Test]
    public void Given_A_Rover_It_Should_Throw_An_Exception_If_The_Position_Is_Outside_The_Plateau_2()
    {
        plateau1 = new Plateau(2, 2);
        rover1 = new Rover(plateau1);
        var ex = Assert.Throws<ArgumentException>(() => rover1.PlaceRoverOnPlateau(new Position(3, 3, 'W')));
        Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
    }

    [Test]
    public void When_Rover_Is_To_Spin_Right_And_Not_On_Plateau_It_Should_Throw_Exception()
    {
        rover1 = new Rover(new Plateau(5, 5));
        var ex = Assert.Throws<NullReferenceException>(() => rover1.SpinRight());
        Assert.That(ex.Message, Is.EqualTo("Rover has not been placed on the Plateau."));
    }

    [Test]
    public void When_Rover_Is_Facing_North_And_Instructed_To_Spin_Right_It_Should_Face_East()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'N'));
        rover1.SpinRight();
        rover1.CurrentPosition.Direction.Should().Be('E');
    }

    [Test]
    public void When_Rover_Is_Facing_East_And_Instructed_To_Spin_Right_It_Should_Face_South()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'E'));
        rover1.SpinRight();
        rover1.CurrentPosition.Direction.Should().Be('S');
    }

    [Test]
    public void When_Rover_Is_Facing_South_And_Instructed_To_Spin_Right_It_Should_Face_West()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'S'));
        rover1.SpinRight();
        rover1.CurrentPosition.Direction.Should().Be('W');
    }

    [Test]
    public void When_Rover_Is_Facing_West_And_Instructed_To_Spin_Right_It_Should_Face_North()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'W'));
        rover1.SpinRight();
        rover1.CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void When_Rover_Is_To_Spin_Left_And_Not_On_Plateau_It_Should_Throw_Exception()
    {
        rover1 = new Rover(new Plateau(5, 5));
        var ex = Assert.Throws<NullReferenceException>(() => rover1.SpinLeft());
        Assert.That(ex.Message, Is.EqualTo("Rover has not been placed on the Plateau."));
    }

    [Test]
    public void When_Rover_Is_Facing_North_And_Instructed_To_Spin_Left_It_Should_Face_West()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'N'));
        rover1.SpinLeft();
        rover1.CurrentPosition.Direction.Should().Be('W');
    }

    [Test]
    public void When_Rover_Is_Facing_West_And_Instructed_To_Spin_Left_It_Should_Face_South()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'W'));
        rover1.SpinLeft();
        rover1.CurrentPosition.Direction.Should().Be('S');
    }

    [Test]
    public void When_Rover_Is_Facing_South_And_Instructed_To_Spin_Left_It_Should_Face_East()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'S'));
        rover1.SpinLeft();
        rover1.CurrentPosition.Direction.Should().Be('E');
    }

    [Test]
    public void When_Rover_Is_Facing_East_And_Instructed_To_Spin_Left_It_Should_Face_North()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'E'));
        rover1.SpinLeft();
        rover1.CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void When_Rover_Is_To_Move_And_Not_On_Plateau_It_Should_Throw_Exception()
    {
        rover1 = new Rover(new Plateau(5, 5));
        var ex = Assert.Throws<NullReferenceException>(() => rover1.Move());
        Assert.That(ex.Message, Is.EqualTo("Rover has not been placed on the Plateau."));
    }

    [Test]
    public void When_Rover_Is_Facing_North_And_Instructed_To_Move_It_Should_Move_1_Grid_Position()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'N'));
        rover1.Move();
        rover1.CurrentPosition.XPosition.Should().Be(1);
        rover1.CurrentPosition.YPosition.Should().Be(3);
        rover1.CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void When_Rover_Is_Facing_East_And_Instructed_To_Move_It_Should_Move_1_Grid_Position()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'E'));
        rover1.Move();
        rover1.CurrentPosition.XPosition.Should().Be(2);
        rover1.CurrentPosition.YPosition.Should().Be(2);
        rover1.CurrentPosition.Direction.Should().Be('E');
    }

    [Test]
    public void When_Rover_Is_Facing_South_And_Instructed_To_Move_It_Should_Move_1_Grid_Position()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'S'));
        rover1.Move();
        rover1.CurrentPosition.XPosition.Should().Be(1);
        rover1.CurrentPosition.YPosition.Should().Be(1);
        rover1.CurrentPosition.Direction.Should().Be('S');
    }

    [Test]
    public void When_Rover_Is_Facing_West_And_Instructed_To_Move_It_Should_Move_1_Grid_Position()
    {
        rover1 = new Rover(new Plateau(5, 5));
        rover1.PlaceRoverOnPlateau(new Position(1, 2, 'W'));
        rover1.Move();
        rover1.CurrentPosition.XPosition.Should().Be(0);
        rover1.CurrentPosition.YPosition.Should().Be(2);
        rover1.CurrentPosition.Direction.Should().Be('W');
    }

    [TestCase("5 5", 5, 5)]
    [TestCase("0 0", 0, 0)]
    [TestCase("15 6", 15, 6)]
    [TestCase(" 1 4 ", 1, 4)]
    public void Set_A_Plateau_From_A_String_Input(string input, int plateauWidth, int plateauHeight)
    {
        MissionControl missionControl1 = new MissionControl();
        missionControl1.AddPlateau(input);
        missionControl1.GetPlateauWidth.Should().Be(plateauWidth);
        missionControl1.GetPlateauHeight.Should().Be(plateauHeight);
    }
}