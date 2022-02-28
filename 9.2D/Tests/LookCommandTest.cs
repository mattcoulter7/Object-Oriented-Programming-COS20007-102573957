using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Swin_Adventure2
{
    [TestFixture]
    public class LookCommandTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void LookAtMe()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            LookCommand LookCommand = new LookCommand(new string[0]);
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Assert.AreEqual(LookCommand.Execute(player, new string[3] { "Look", "at", "inventory" }), "You are Matt (me)\nYou are carrying:\n");
        }
        [Test]
        public void LookAtGem()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem"},"Gem","Shiny Object");
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            player.Inventory.Put(Gem);
            Assert.AreEqual(LookCommand.Execute(player, new string[5] { "Look", "at", "gem", "in","inventory" }), "Shiny Object");
        }
        [Test]
        public void LookAtUnk()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object"); List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            player.EnterLocation(farm);
            Assert.AreEqual(LookCommand.Execute(player, new string[5] { "Look", "at", "gem", "in", "inventory" }), "I cannot find the gem from the Matt");
        }
        [Test]
        public void LookAtGemInBag()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            player.Inventory.Put(bag1);
            bag1.Inventory.Put(Gem);
            Assert.AreEqual(LookCommand.Execute(player, new string[5] { "Look", "at", "gem", "in", "bag" }), "Shiny Object");
        }
        [Test]
        public void LookAtGemInNoBag()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            player.Inventory.Put(Gem);
            player.EnterLocation(farm);
            Assert.AreEqual(LookCommand.Execute(player, new string[5] { "Look", "at", "gem", "in", "bag" }), "I cannot find the bag");
        }
        [Test]
        public void LookAtNoGemInNoBag()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            player.Inventory.Put(bag1);
            Assert.AreEqual(LookCommand.Execute(player, new string[5] { "Look", "at", "gem", "in", "bag" }), "I cannot find the gem from the backpack");
        }
        [Test]
        public void InvalidLook1()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            LookCommand LookCommand = new LookCommand(new string[0]);
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            player.EnterLocation(farm);
            Assert.AreEqual(LookCommand.Execute(player, new string[5] { "Look", "at", "a", "in", "b" }), "I cannot find the b");
        }
        [Test]
        public void InvalidLook2()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            LookCommand LookCommand = new LookCommand(new string[0]);
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Assert.AreEqual(LookCommand.Execute(player, new string[2] { "Look", "around"}), "Command not found");
        }
        [Test]
        public void InvalidLook3()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            LookCommand LookCommand = new LookCommand(new string[0]);
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Assert.AreEqual(LookCommand.Execute(player, new string[1] { "hello" }), "Command not found");
        }
        [Test]
        public void PlayerDoesNotFindItemOutsideOfTheirLocation()
        {
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Item sword = new Item(new string[] { "Sword", "Weapon" }, "Sword", "A Rusted Sword");
            farm.Inventory.Put(sword);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Assert.AreEqual(LookCommand.Execute(player, new string[] { "look", "at", "sword", "in", "farm" }), "I cannot find the farm");
        }
        [Test]
        public void PlayerFindsItemsInTheirLocation()
        {
            List<Path> _objectives = new List<Path>();
            Player player = new Player("Matt", "me", _objectives);
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Item sword = new Item(new string[] { "Sword", "Weapon" }, "Sword", "A Rusted Sword");
            farm.Inventory.Put(sword);
            player.EnterLocation(farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Assert.AreEqual(LookCommand.Execute(player, new string[] { "look", "at", "sword", "in", "farm" }), "A Rusted Sword");
        }

    }
}
