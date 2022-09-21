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
        rover1 = new Rover(new Position(1, 2, 'N'));
        rover1.CurrentPosition.XPosition.Should().Be(1);
        rover1.CurrentPosition.YPosition.Should().Be(2);
        rover1.CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void Given_A_Rover_It_Is_Placed_In_A_Valid_Position_On_The_Plateau_2()
    {
        plateau1 = new Plateau(10, 10);
        rover1 = new Rover(new Position(6, 7, 'N'));
        rover1.CurrentPosition.XPosition.Should().Be(6);
        rover1.CurrentPosition.YPosition.Should().Be(7);
        rover1.CurrentPosition.Direction.Should().Be('N');
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

    [TestCase("-1 5")]
    [TestCase("3 -1")]
    public void When_A_Plateau_Has_Invalid_String_Input_An_Exception_Is_Thrown(string input)
    {
        MissionControl missionControl1 = new MissionControl();
        var ex = Assert.Throws<ArgumentException>(() => missionControl1.AddPlateau(input));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));
    }

    [TestCase("1 2 N", 1, 2, 'N')]
    [TestCase("2 4 E", 2, 4, 'E')]
    [TestCase(" 3 3 W ", 3, 3, 'W')]
    public void Given_A_Rover_Place_It_On_A_Plateau(string input, int xPos, int yPos, char direction)
    {
        MissionControl missionControl1 = new MissionControl();
        missionControl1.AddPlateau("5 5");
        missionControl1.AddRover(input);
        missionControl1.GetRoverPosition.XPosition.Should().Be(xPos);
        missionControl1.GetRoverPosition.YPosition.Should().Be(yPos);
        missionControl1.GetRoverPosition.Direction.Should().Be(direction);
    }

    [Test]
    public void Given_A_Rover_Without_A_Plateau_Should_Throw_Exception()
    {
        MissionControl missionControl1 = new MissionControl();
        var ex = Assert.Throws<NullReferenceException>(() => missionControl1.AddRover("1 2 N"));
        Assert.That(ex.Message, Is.EqualTo("Rover can not be created without a plateau."));
    }

    [TestCase("-1 2 N")]
    [TestCase("1 -2 E")]
    [TestCase("1 2 P")]
    public void When_A_Rover_Is_Placed_On_A_Plateau_An_Exception_Is_Thrown(string input)
    {
        MissionControl missionControl1 = new MissionControl();
        missionControl1.AddPlateau("5 5");
        var ex = Assert.Throws<ArgumentException>(() => missionControl1.AddRover(input));
        Assert.That(ex.Message, Is.EqualTo("Position can not have negative values or invalid direction."));
    }

    [TestCase("6 5 N")]
    [TestCase("5 6 E")]
    [TestCase("6 6 W")]
    public void When_A_Rover_Is_Placed_Outside_The_Plateau_An_Exception_Is_Thrown(string input)
    {
        MissionControl missionControl1 = new MissionControl();
        missionControl1.AddPlateau("5 5");
        var ex = Assert.Throws<ArgumentException>(() => missionControl1.AddRover(input));
        Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
    }

    [TestCase("LMLMLMLMM","1 2 N", 1, 3, 'N')]
    [TestCase("MMRMMRMRRM", "3 3 E" , 5, 1, 'E')]
    public void Given_A_Rover_With_Move_Instructions_It_Should_Be_In_Correct_Position(string moveInput, string roverInput,
        int xPos, int yPos, char direction)
    {
        MissionControl missionControl = new MissionControl();
        missionControl.AddPlateau("5 5");
        missionControl.AddRover(roverInput);
        missionControl.MoveRover(moveInput);
        missionControl.GetRoverPosition.XPosition.Should().Be(xPos);
        missionControl.GetRoverPosition.YPosition.Should().Be(yPos);
        missionControl.GetRoverPosition.Direction.Should().Be(direction);
    }

    [Test]
    public void Given_A_Rover_With_An_Invalid_Move_It_Should_Throw_An_Exception()
    {
        MissionControl missionControl = new MissionControl();
        missionControl.AddPlateau("5 5");
        missionControl.AddRover("3 3 E");
        var ex = Assert.Throws<ArgumentException>(() => missionControl.MoveRover("MMRMMPRMRRM"));
        Assert.That(ex.Message, Is.EqualTo("Not a valid movement move aborted."));
    }

    [Test]
    public void Given_A_Rover_With_An_Invalid_Move_Rover_Should_Remain_In_Correct_Position()
    {
        MissionControl missionControl = new MissionControl();
        missionControl.AddPlateau("5 5");
        missionControl.AddRover("3 3 E");
        try
        {
            missionControl.MoveRover("MMRMMPPPPRMRRM");
        }
        catch (Exception ex) 
        {
        }
        missionControl.GetRoverPosition.XPosition.Should().Be(3);
        missionControl.GetRoverPosition.YPosition.Should().Be(3);
        missionControl.GetRoverPosition.Direction.Should().Be('E');
    }

    [Test]
    public void Given_A_Rover_With_A_Valid_Move_Then_An_Invalid_Move_Rover_Should_Remain_In_Correct_Position()
    {
        MissionControl missionControl = new MissionControl();
        missionControl.AddPlateau("5 5");
        missionControl.AddRover("1 2 N");
        missionControl.MoveRover("LMLMLMLMM");
        try
        {
            missionControl.MoveRover("MMRMMPRMRRM");
        }
        catch (Exception ex)
        {
        }
        missionControl.GetRoverPosition.XPosition.Should().Be(1);
        missionControl.GetRoverPosition.YPosition.Should().Be(3);
        missionControl.GetRoverPosition.Direction.Should().Be('N');
    }
}