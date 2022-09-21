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
}