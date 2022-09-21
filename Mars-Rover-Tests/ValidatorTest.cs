using NUnit.Framework;
using FluentAssertions;
using MarsRover.Model;
using MarsRover.Validator;
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
        var ex = Assert.Throws<ArgumentException>(() => validator.ValidatePosition(roverPositionInput));
        Assert.That(ex.Message, Is.EqualTo("Position can not have negative values or invalid direction."));
    }

    [TestCase("-1 5")]
    [TestCase("3 -1")]
    public void Given_A_String_Input_With_An_Invalid_Plateau_Validator_Should_Throw_Exception(string plateauInput)
    {
        var ex = Assert.Throws<ArgumentException>(() => validator.ValidatePlateau(plateauInput));
        Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));
    }

    [TestCase("6 5 N")]
    [TestCase("5 6 E")]
    [TestCase("6 6 W")]
    public void Given_A_String_Input_For_A_Rover_Which_Is_Outside_Validator_Should_Throw_Exception(string roverPositionInput)
    {
        Plateau plateau = new Plateau(5, 5);
        var ex = Assert.Throws<ArgumentException>(() => validator.ValidateInitialPosition(roverPositionInput, plateau));
        Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
    }

    [TestCase("MMRMMPPPPRMRRM")]
    [TestCase("MMRMMPRMRRM")]
    [TestCase("MMRblahblahRM")]
    [TestCase("MMR123RM")]
    [TestCase("MMRrmlmlrRM")]
    public void Given_A_String_Input_For_An_Invalid_Move_Instruction_Validator_Should_Throw_Exception(string moveInstructions)
    {
        var ex = Assert.Throws<ArgumentException>(() => validator.ValidateMoveInstructions(moveInstructions));
        Assert.That(ex.Message, Is.EqualTo("Not a valid movement move aborted."));
    }
}