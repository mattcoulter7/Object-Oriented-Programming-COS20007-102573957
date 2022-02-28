using NUnit.Framework;
using System;

namespace Swin_Adventure2
{
    [TestFixture]
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PlayerIsIdentifiable()
        {
            Player Matt = new Player("Matt","19 Years Old");
            Assert.IsTrue(Matt.AreYou("me"));
            Assert.IsTrue(Matt.AreYou("inventory"));
        }
        [Test]
        public void PlayerLocatesItems()
        {
            Player Matt = new Player("Matt", "19 Years Old");
            Item Gun = new Item(new String[] { "Gun", "Weapon" }, "a gun", "M1911 pistol");
            Matt.Inventory.Put(Gun);
            Assert.IsTrue(Matt.Locate("Gun") == Gun);
        }
        [Test]
        public void LocatesItself()
        {
            Player Matt = new Player("Matt", "19 Years Old");
            Assert.AreEqual(Matt.Locate("me"),Matt);
        }
        [Test]
        public void LocatesNothing()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            Player Matt = new Player("Matt", "19 Years Old");
            Matt.EnterLocation(farm);
            Assert.AreEqual(Matt.Locate("horse"),null);
        }
        [Test]
        public void PlayerFullDescription()
        {
            Player Matt = new Player("Matt", "19 Years Old");
            Item Gun = new Item(new String[] { "Gun", "Weapon" }, "a gun", "M1911 pistol");
            Matt.Inventory.Put(Gun);
            Assert.AreEqual(Matt.FullDescription, "You are Matt (me)\nYou are carrying:\n\ta gun (gun)\n");
        }
        [Test]
        public void PlayerLocationUpdates()
        {
            Player player = new Player("Matt", "me");
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            player.EnterLocation(farm);
            Assert.IsTrue(farm.Players.Contains(player));
        }
    }
}