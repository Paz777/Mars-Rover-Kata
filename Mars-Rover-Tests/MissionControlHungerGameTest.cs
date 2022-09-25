using NUnit.Framework;
using FluentAssertions;
using MarsRover.Model;
using MarsRover.Validator;
using MarsRover.Exceptions;
using MarsRover.Interface;
using System.Collections.ObjectModel;

namespace MarsRoverTests;

public class HungerGamesMissionControlTest
{
    private HungerGamesMissionControl missionControl1;

    [SetUp]
    public void Setup()
    {
        missionControl1 = new HungerGamesMissionControl();
    }

    [Test]
    public void Mission_Control_Can_Add_A_BattleRover()
    {
        missionControl1.AddPlateau("5 5");
        missionControl1.AddRover("Player1", "3 3 N");
        Dictionary<string, BattleRover> rovers = missionControl1.GetRovers();

        rovers["Player1"].CurrentPosition.XPosition.Should().Be(3);
        rovers["Player1"].CurrentPosition.YPosition.Should().Be(3);
        rovers["Player1"].CurrentPosition.Direction.Should().Be('N');
    }

    [Test]
    public void Given_Two_Rovers_The_Second_Has_Collision_With_First_Rover_Should_Throw_Exception_With_Position_Info()
    {
        missionControl1.AddPlateau("5 5");
        missionControl1.AddRover("Player1", "3 3 N");
        missionControl1.AddRover("Player2", "4 4 N");

        var ex = Assert.Throws<MoveException>(() => missionControl1.MoveRover("Player2","LMLMMMMMMMMMMMM"));
        Assert.That(ex.Message, Is.EqualTo("Move collides with another Rover at Position 3 3 - move aborted"));
    }

}