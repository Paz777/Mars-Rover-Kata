using NUnit.Framework;
using FluentAssertions;
using MarsRover.Model;
using MarsRover.Validator;

namespace MarsRoverTests;

public class MissionControlTest
{
    private Plateau plateau1;
    private Rover rover1;
    private MissionControl missionControl1;


    [SetUp]
    public void Setup()
    {
        missionControl1 = new MissionControl();
    }

    [TestCase("5 5", 5, 5)]
    [TestCase("0 0", 0, 0)]
    [TestCase("15 6", 15, 6)]
    [TestCase(" 1 4 ", 1, 4)]
    public void Given_A_String_Input_It_Should_Set_A_Plateau(string input, int plateauWidth, int plateauHeight)
    {
        missionControl1.AddPlateau(input);
        missionControl1.GetPlateauWidth.Should().Be(plateauWidth);
        missionControl1.GetPlateauHeight.Should().Be(plateauHeight);
    }

    [TestCase("-1 5")]
    [TestCase("3 -1")]
    public void Given_An_Invalid_String_Input_For_Plateau_It_Should_Throw_An_Exception(string input)
    {
        var ex = Assert.Throws<ArgumentException>(() => missionControl1.AddPlateau(input));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));
    }

    [TestCase("1 2 N", 1, 2, 'N')]
    [TestCase("2 4 E", 2, 4, 'E')]
    [TestCase(" 3 3 W ", 3, 3, 'W')]
    public void Given_A_Plateau_And_A_Rover_It_Is_Positioned_On_The_Plateau(string input, int xPos, int yPos, char direction)
    {
        missionControl1.AddPlateau("5 5");
        missionControl1.AddRover(input);
        missionControl1.GetRoverPosition.XPosition.Should().Be(xPos);
        missionControl1.GetRoverPosition.YPosition.Should().Be(yPos);
        missionControl1.GetRoverPosition.Direction.Should().Be(direction);
    }

    [Test]
    public void Given_A_Rover_Without_A_Plateau_It_Should_Throw_An_Exception()
    {
        var ex = Assert.Throws<NullReferenceException>(() => missionControl1.AddRover("1 2 N"));
        Assert.That(ex.Message, Is.EqualTo("Rover can not be created without a plateau."));
    }

    [TestCase("-1 2 N")]
    [TestCase("1 -2 E")]
    [TestCase("1 2 P")]
    public void When_A_Rover_Is_Added_With_Invalid_Position_It_Should_Throw_An_Exception(string input)
    {
        missionControl1.AddPlateau("5 5");
        var ex = Assert.Throws<ArgumentException>(() => missionControl1.AddRover(input));
        Assert.That(ex.Message, Is.EqualTo("Position can not have negative values or invalid direction."));
    }

    [TestCase("6 5 N")]
    [TestCase("5 6 E")]
    [TestCase("6 6 W")]
    public void When_A_Rover_Is_Positioned_Outside_The_Plateau_It_Should_Throw_An_Exception(string input)
    {
        missionControl1.AddPlateau("5 5");
        var ex = Assert.Throws<ArgumentException>(() => missionControl1.AddRover(input));
        Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
    }

    [TestCase("LMLMLMLMM","1 2 N", 1, 3, 'N')]
    [TestCase("MMRMMRMRRM", "3 3 E" , 5, 1, 'E')]
    public void Given_A_Rover_With_Move_Instructions_It_Should_Be_In_The_Correct_Position(string moveInput, string roverInput,
        int xPos, int yPos, char direction)
    {
        missionControl1.AddPlateau("5 5");
        missionControl1.AddRover(roverInput);
        missionControl1.MoveRover(moveInput);
        missionControl1.GetRoverPosition.XPosition.Should().Be(xPos);
        missionControl1.GetRoverPosition.YPosition.Should().Be(yPos);
        missionControl1.GetRoverPosition.Direction.Should().Be(direction);
    }

    [Test]
    public void Given_A_Rover_With_An_Invalid_Move_It_Should_Throw_An_Exception()
    {
        missionControl1.AddPlateau("5 5");
        missionControl1.AddRover("3 3 E");
        var ex = Assert.Throws<ArgumentException>(() => missionControl1.MoveRover("MMRMMPRMRRM"));
        Assert.That(ex.Message, Is.EqualTo("Not a valid movement move aborted."));
    }

    [Test]
    public void Given_A_Rover_With_An_Invalid_Move_Rover_Should_Remain_In_Correct_Position()
    {
        missionControl1.AddPlateau("5 5");
        missionControl1.AddRover("3 3 E");
        try
        {
            missionControl1.MoveRover("MMRMMPPPPRMRRM");
        }
        catch (Exception ex) 
        {
        }
        missionControl1.GetRoverPosition.XPosition.Should().Be(3);
        missionControl1.GetRoverPosition.YPosition.Should().Be(3);
        missionControl1.GetRoverPosition.Direction.Should().Be('E');
    }

    [Test]
    public void Given_A_Rover_With_A_Valid_Move_Then_An_Invalid_Move_Rover_Should_Remain_In_Correct_Position()
    {
        missionControl1.AddPlateau("5 5");
        missionControl1.AddRover("1 2 N");
        missionControl1.MoveRover("LMLMLMLMM");
        try
        {
            missionControl1.MoveRover("MMRMMPRMRRM");
        }
        catch (Exception ex)
        {
        }
        missionControl1.GetRoverPosition.XPosition.Should().Be(1);
        missionControl1.GetRoverPosition.YPosition.Should().Be(3);
        missionControl1.GetRoverPosition.Direction.Should().Be('N');
    }
}