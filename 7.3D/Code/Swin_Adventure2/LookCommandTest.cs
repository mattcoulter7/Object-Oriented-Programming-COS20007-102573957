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
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Player player1 = new Player("Matt","Matt is 19 years old");
            Assert.AreEqual(LookCommand.Execute(player1, new string[3] { "Look", "at", "inventory" }, ToFarm), "You are Matt (me)\nYou are carrying:\n");
        }
        [Test]
        public void LookAtGem()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem"},"Gem","Shiny Object");
            Player player1 = new Player("Matt", "Matt is 19 years old");
            player1.Inventory.Put(Gem);
            Assert.AreEqual(LookCommand.Execute(player1, new string[5] { "Look", "at", "gem", "in","inventory" }, ToFarm), "Shiny Object");
        }
        [Test]
        public void LookAtUnk()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            Player player1 = new Player("Matt", "Matt is 19 years old");
            player1.EnterLocation(farm);
            Assert.AreEqual(LookCommand.Execute(player1, new string[5] { "Look", "at", "gem", "in", "inventory" }, ToFarm), "I cannot find the gem from the Matt");
        }
        [Test]
        public void LookAtGemInBag()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            Player player1 = new Player("Matt", "Matt is 19 years old");
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            player1.Inventory.Put(bag1);
            bag1.Inventory.Put(Gem);
            Assert.AreEqual(LookCommand.Execute(player1, new string[5] { "Look", "at", "gem", "in", "bag" }, ToFarm), "Shiny Object");
        }
        [Test]
        public void LookAtGemInNoBag()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            Player player1 = new Player("Matt", "Matt is 19 years old");
            player1.Inventory.Put(Gem);
            player1.EnterLocation(farm);
            Assert.AreEqual(LookCommand.Execute(player1, new string[5] { "Look", "at", "gem", "in", "bag" }, ToFarm), "I cannot find the bag");
        }
        [Test]
        public void LookAtNoGemInNoBag()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            Player player1 = new Player("Matt", "Matt is 19 years old");
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            player1.Inventory.Put(bag1);
            Assert.AreEqual(LookCommand.Execute(player1, new string[5] { "Look", "at", "gem", "in", "bag" }, ToFarm), "I cannot find the gem from the backpack");
        }
        [Test]
        public void InvalidLook1()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Player player1 = new Player("Matt", "Matt is 19 years old");
            player1.EnterLocation(farm);
            Assert.AreEqual(LookCommand.Execute(player1, new string[5] { "Look", "at", "a", "in", "b" }, ToFarm), "I cannot find the b");
        }
        [Test]
        public void InvalidLook2()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Player player1 = new Player("Matt", "Matt is 19 years old");
            Assert.AreEqual(LookCommand.Execute(player1, new string[2] { "Look", "around"}, ToFarm), "Command not found");
        }
        [Test]
        public void InvalidLook3()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Player player1 = new Player("Matt", "Matt is 19 years old");
            Assert.AreEqual(LookCommand.Execute(player1, new string[1] { "hello" }, ToFarm), "Command not found");
        }
        [Test]
        public void PlayerDoesNotFindItemOutsideOfTheirLocation()
        {
            Player player = new Player("Matt", "me");
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            Item sword = new Item(new string[] { "Sword", "Weapon" }, "Sword", "A Rusted Sword");
            farm.Inventory.Put(sword);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Assert.AreEqual(LookCommand.Execute(player, new string[] { "look", "at", "sword", "in", "farm" }, ToFarm), "I cannot find the farm");
        }
        [Test]
        public void PlayerFindsItemsInTheirLocation()
        {
            Player player = new Player("Matt", "me");
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
            Path ToFarm = new Path(new string[] { "farm" }, farm);
            Item sword = new Item(new string[] { "Sword", "Weapon" }, "Sword", "A Rusted Sword");
            farm.Inventory.Put(sword);
            player.EnterLocation(farm);
            LookCommand LookCommand = new LookCommand(new string[0]);
            Assert.AreEqual(LookCommand.Execute(player, new string[] { "look", "at", "sword", "in", "farm" }, ToFarm), "A Rusted Sword");
        }

    }
}
