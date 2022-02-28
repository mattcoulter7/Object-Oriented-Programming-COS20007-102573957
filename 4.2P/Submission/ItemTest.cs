using NUnit.Framework;
using System;

namespace Swin_Adventure2
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ItemIsIdentifiable()
        {
            Item Shovel = new Item(new String[] { "Shovel", "Spade" }, "a shovel", "This is used for digging up dirt out of the ground");
            Assert.IsTrue(Shovel.AreYou("Shovel"));
            Assert.IsTrue(Shovel.AreYou("Spade"));
        }
        [Test]
        public void ShortDescription()
        {
            Item Shovel = new Item(new String[] { "Shovel", "Spade" }, "a shovel", "This is used for digging up dirt out of the ground");
            Assert.IsTrue(Equals(Shovel.ShortDescription, Shovel.Name + " " + "(" + Shovel.FirstId + ")"));
        }
        [Test]
        public void FullDescription()
        {
            Item Shovel = new Item(new String[] { "Shovel", "Spade" }, "a shovel", "This is used for digging up dirt out of the ground");
            Assert.IsTrue(Equals(Shovel.FullDescription, "This is used for digging up dirt out of the ground"));
        }
    }
}