using NUnit.Framework;
using System;

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
            Player Matt = new Player("Matt", "me");
            Location hogwarts = new Location(new string[] { "hogwarts" }, "Hogwarts", "A school of magic", 520, 399);
            Path ToHogwarts = new Path(new string[] { "hogwarts" }, hogwarts);
            ToHogwarts.MovePlayerToDestination(Matt);
            Assert.IsTrue(Matt.X == hogwarts.X && Matt.Y == hogwarts.Y);
        }
        [Test]
        public void PlayerCanLeaveLocation()
        {
            Player Matt = new Player("Matt", "me");
            Location hogwarts = new Location(new string[] { "hogwarts" }, "Hogwarts", "A school of magic", 520, 399);
            Matt.EnterLocation(hogwarts);
            Matt.LeaveLocation();
            Assert.AreEqual(Matt.Location,null);
        }

    }
}