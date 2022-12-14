using NUnit.Framework;
using FluentAssertions;
using MarsRover.Model;
using MarsRover.Validator;
using MarsRover.Exceptions;
using MarsRover.Interface;

namespace ValidatorTests;

public class ValidatorTest
{
    MarsRoverValidator validator;

    [SetUp]
    public void Setup()
    {
        validator = new MarsRoverValidator();
    }

    [TestCase("-1 2 N")]
    [TestCase("1 -2 E")]
    [TestCase("1 2 P")]
    public void Given_A_String_Input_With_An_Invalid_Position_Validator_Should_Throw_Exception(string roverPositionInput)
    {
        var ex = Assert.Throws<PositionException>(() => validator.ValidatePosition(roverPositionInput));
        Assert.That(ex.Message, Is.EqualTo("Position can not have negative values or invalid direction."));
    }

    [TestCase("-1 5")]
    [TestCase("3 -1")]
    public void Given_A_String_Input_With_An_Invalid_Plateau_Validator_Should_Throw_Exception(string plateauInput)
    {
        var ex = Assert.Throws<PlateauException>(() => validator.ValidatePlateau(plateauInput));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));
    }

    [Test]
    public void Given_An_Empty_String_Or_Null_Input_For_Plateau_Validator_Should_Throw_Exception()
    {
        var ex = Assert.Throws<PlateauException>(() => validator.ValidatePlateau(""));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with invalid input."));

        ex = Assert.Throws<PlateauException>(() => validator.ValidatePlateau(String.Empty));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with invalid input."));

        ex = Assert.Throws<PlateauException>(() => validator.ValidatePlateau(null));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with invalid input."));
    }

    [TestCase("6 5 N")]
    [TestCase("5 6 E")]
    [TestCase("6 6 W")]
    public void Given_A_String_Input_For_A_Rover_Which_Is_Outside_Validator_Should_Throw_Exception(string roverPositionInput)
    {
        Plateau plateau = new Plateau(5, 5);
        var ex = Assert.Throws<PositionException>(() => validator.ValidateInitialPosition(roverPositionInput, plateau));
        Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
    }

    [TestCase("MMRMMPPPPRMRRM")]
    [TestCase("MMRMMPRMRRM")]
    [TestCase("MMRblahblahRM")]
    [TestCase("MMR123RM")]
    [TestCase("MMRrmlmlrRM")]
    public void Given_A_String_Input_For_An_Invalid_Move_Instruction_Validator_Should_Throw_Exception(string moveInstructions)
    {
        var ex = Assert.Throws<MoveException>(() => validator.ValidateMoveInstructions(moveInstructions));
        Assert.That(ex.Message, Is.EqualTo("Not a valid movement - move aborted."));
    }

    [TestCase("MM")]
    public void Given_A_String_Input_For_Move_Instruction_That_Takes_Rover_Outside_Of_Plateau_Validator_Should_Throw_Exception(string moveInstructions)
    {
        Plateau plateau = new Plateau(5, 5);
        Rover rover = new Rover(new Position(5,5,'N'));
        rover.Move();
        var ex = Assert.Throws<MoveException>(() => validator.ValidateMovePosition(rover, plateau));
        Assert.That(ex.Message, Is.EqualTo("Move instructions takes Rover outside of Plateau - move aborted."));
    }

    [Test]
    public void Given_Two_Rovers_And_The_Second_Rover_Collides_With_The_First_Throw_Execption()
    {
        MarsRoverValidator marsRoverValidator1 = new MarsRoverValidator();
        BattleRover rover1 = new BattleRover("Player1", new Position(3, 3, 'N'));
        BattleRover rover2 = new BattleRover("Player2", new Position(3, 3, 'N'));
        Dictionary<string, BattleRover> rovers = new Dictionary<string, BattleRover>();
        rovers.Add(rover1.Name, rover1);
        rovers.Add(rover2.Name, rover2);

        var ex = Assert.Throws<MoveException>(() => marsRoverValidator1.ValidateMovePositionForCollision(rover2, rovers));
        Assert.That(ex.Message, Is.EqualTo("Move collides with another Rover at Position 3 3 - move aborted"));
    }
}