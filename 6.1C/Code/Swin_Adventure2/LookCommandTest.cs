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
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            LookCommand LookCommand = new LookCommand(new string[0]);
            Player player1 = new Player("Matt","Matt is 19 years old");
            Assert.AreEqual(LookCommand.Execute(farm, player1, new string[3] { "Look", "at", "inventory" }), "You are Matt (me)\nYou are carrying:\n");
        }
        [Test]
        public void LookAtGem()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem"},"Gem","Shiny Object");
            Player player1 = new Player("Matt", "Matt is 19 years old");
            player1.Inventory.Put(Gem);
            Assert.AreEqual(LookCommand.Execute(farm, player1, new string[5] { "Look", "at", "gem", "in","inventory" }), "Shiny Object");
        }
        [Test]
        public void LookAtUnk()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            Player player1 = new Player("Matt", "Matt is 19 years old");
            player1.EnterLocation(farm);
            Assert.AreEqual(LookCommand.Execute(farm, player1, new string[5] { "Look", "at", "gem", "in", "inventory" }), "I cannot find the gem from the Matt");
        }
        [Test]
        public void LookAtGemInBag()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            Player player1 = new Player("Matt", "Matt is 19 years old");
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            player1.Inventory.Put(bag1);
            bag1.Inventory.Put(Gem);
            Assert.AreEqual(LookCommand.Execute(farm, player1, new string[5] { "Look", "at", "gem", "in", "bag" }), "Shiny Object");
        }
        [Test]
        public void LookAtGemInNoBag()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            Player player1 = new Player("Matt", "Matt is 19 years old");
            player1.Inventory.Put(Gem);
            player1.EnterLocation(farm);
            Assert.AreEqual(LookCommand.Execute(farm, player1, new string[5] { "Look", "at", "gem", "in", "bag" }), "I cannot find the bag");
        }
        [Test]
        public void LookAtNoGemInNoBag()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            LookCommand LookCommand = new LookCommand(new string[0]);
            Item Gem = new Item(new string[] { "Gem" }, "Gem", "Shiny Object");
            Player player1 = new Player("Matt", "Matt is 19 years old");
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            player1.Inventory.Put(bag1);
            Assert.AreEqual(LookCommand.Execute(farm, player1, new string[5] { "Look", "at", "gem", "in", "bag" }), "I cannot find the gem from the backpack");
        }
        [Test]
        public void InvalidLook1()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            LookCommand LookCommand = new LookCommand(new string[0]);
            Player player1 = new Player("Matt", "Matt is 19 years old");
            player1.EnterLocation(farm);
            Assert.AreEqual(LookCommand.Execute(farm, player1, new string[5] { "Look", "at", "a", "in", "b" }), "I cannot find the b");
        }
        [Test]
        public void InvalidLook2()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            LookCommand LookCommand = new LookCommand(new string[0]);
            Player player1 = new Player("Matt", "Matt is 19 years old");
            Assert.AreEqual(LookCommand.Execute(farm, player1, new string[2] { "Look", "around"}), "Command not found");
        }
        [Test]
        public void InvalidLook3()
        {
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            LookCommand LookCommand = new LookCommand(new string[0]);
            Player player1 = new Player("Matt", "Matt is 19 years old");
            Assert.AreEqual(LookCommand.Execute(farm, player1, new string[1] { "hello" }), "Command not found");
        }

    }
}
