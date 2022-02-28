using NUnit.Framework;
using System;
using System.Collections.Generic;

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
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Assert.IsTrue(player.AreYou("me"));
            Assert.IsTrue(player.AreYou("inventory"));
        }
        [Test]
        public void PlayerLocatesItems()
        {
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Item Gun = new Item(new String[] { "Gun", "Weapon" }, "a gun", "M1911 pistol");
            player.Inventory.Put(Gun);
            Assert.IsTrue(player.Locate("Gun") == Gun);
        }
        [Test]
        public void LocatesItself()
        {
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Assert.AreEqual(player.Locate("me"), player);
        }
        [Test]
        public void LocatesNothing()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            player.EnterLocation(farm);
            Assert.AreEqual(player.Locate("horse"),null);
        }
        [Test]
        public void PlayerFullDescription()
        {
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Item Gun = new Item(new String[] { "Gun", "Weapon" }, "a gun", "M1911 pistol");
            player.Inventory.Put(Gun);
            Assert.AreEqual(player.FullDescription, "You are Matt (me)\nYou are carrying:\n\ta gun (gun)\n");
        }
        [Test]
        public void PlayerLocationUpdates()
        {
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            player.EnterLocation(farm);
            Assert.IsTrue(farm.Players.Contains(player));
        }
    }
}