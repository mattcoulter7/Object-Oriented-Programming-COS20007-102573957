using NUnit.Framework;
using System;

namespace Swin_Adventure2
{
    [TestFixture]
    public class InventoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FindItem()
        {
            Item Shovel = new Item(new String[] { "Shovel", "Spade" }, "a shovel", "This is used for digging up dirt out of the ground");
            Inventory inventory = new Inventory();
            inventory.Put(Shovel);
            Assert.IsTrue(inventory.HasItem("shovel"));
        }
        [Test]
        public void NoItemFind()
        {
            Item Shovel = new Item(new String[] { "Shovel", "Spade" }, "a shovel", "This is used for digging up dirt out of the ground");
            Inventory inventory = new Inventory();
            Assert.IsFalse(inventory.HasItem("shovel"));
        }
        [Test]
        public void FetchItem()
        {
            Item Shovel = new Item(new String[] { "Shovel", "Spade" }, "a shovel", "This is used for digging up dirt out of the ground");
            Inventory inventory = new Inventory();
            inventory.Put(Shovel);
            Assert.IsTrue(inventory.Fetch("Shovel") == Shovel);
        }
        [Test]
        public void TakeItem()
        {
            Item Shovel = new Item(new String[] { "Shovel", "Spade" }, "a shovel", "This is used for digging up dirt out of the ground");
            Inventory inventory = new Inventory();
            inventory.Take("Shovel");
            Assert.IsFalse(inventory.HasItem("Shovel"));
        }
        [Test]
        public void ItemList()
        {
            Item Shovel = new Item(new String[] { "Shovel", "Spade" }, "a shovel", "This is used for digging up dirt out of the ground");
            Item Gun = new Item(new String[] { "Gun", "Weapon" }, "a gun", "M1911 pistol");
            Inventory inventory = new Inventory();
            inventory.Put(Shovel);
            inventory.Put(Gun);
            Assert.IsTrue(Equals(inventory.ItemList, "\t" + Shovel.ShortDescription + "\n" + "\t" + Gun.ShortDescription + "\n"));
        }
    }
}