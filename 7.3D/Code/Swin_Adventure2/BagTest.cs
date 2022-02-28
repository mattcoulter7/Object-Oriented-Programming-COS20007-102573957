using NUnit.Framework;
using System;

namespace Swin_Adventure2
{
    [TestFixture]
    public class BagTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //bagtests
        
        [Test]
        public void BagLocatesItems()
        {
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            Item Gun = new Item(new String[] { "Gun", "Weapon" }, "a gun", "M1911 pistol");
            bag1.Inventory.Put(Gun);
            Assert.AreEqual(bag1.Inventory.ItemList, "\ta gun (gun)\n");
        }
        [Test]
        public void BagLocatesItself()
        {
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            Assert.AreEqual(bag1.Locate("Bag"), bag1);
        }
        [Test]
        public void BagLocatesNothing()
        {
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            Item Gun = new Item(new String[] { "Gun", "Weapon" }, "a gun", "M1911 pistol");
            Assert.AreEqual(bag1.Inventory.ItemList, "");
        }
        [Test]
        public void BagFullDescription()
        {
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            Assert.AreEqual(bag1.FullDescription, "An item that can carry more items");
        }
        [Test]
        public void BagInBag()
        {
            Bag bag1 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            Bag bag2 = new Bag(new string[] { "Bag", "Backpack" }, "backpack", "An item that can carry more items");
            bag1.Inventory.Put(bag2);
            Assert.IsTrue(bag1.Inventory.HasItem("Bag"));
        }
        
    }
}