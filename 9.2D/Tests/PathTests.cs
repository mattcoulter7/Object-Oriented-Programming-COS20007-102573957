using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Swin_Adventure2
{
    [TestFixture]
    public class PathTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //pathtest
        [Test]
        public void PathCanMovePlayerToDestination()
        {
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Location hogwarts = new Location(new string[] { "hogwarts" }, "Hogwarts", "A school of magic", 520, 399);
            Path ToHogwarts = new Path(new string[] { "hogwarts" }, hogwarts);
            ToHogwarts.MovePlayerToDestination(player);
            Assert.IsTrue(player.X == hogwarts.X && player.Y == hogwarts.Y);
        }
        [Test]
        public void PlayerCanLeaveLocation()
        {
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Location hogwarts = new Location(new string[] { "hogwarts" }, "Hogwarts", "A school of magic", 520, 399);
            player.EnterLocation(hogwarts);
            player.LeaveLocation();
            Assert.AreEqual(player.Location,null);
        }

    }
}