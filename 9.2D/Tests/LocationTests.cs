using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace Swin_Adventure2
{
    public class LocationTests
    {
        [TestFixture]
        public class BagTests
        {
            [SetUp]
            public void Setup()
            {
            }

            //LocationTests
            [Test]
            public void LocationIdentifiesItself()
            {
                Location farm = new Location(new string[] { "farm", "farmland"},"Farm","A big piece of land",0,0);
                Assert.IsTrue(farm.AreYou("farm"));
            }
            [Test]
            public void LocationLocatesItemsItHas()
            {
                Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
                Item sword = new Item(new string[] { "Sword", "Weapon" }, "Sword", "A Rusted Sword");
                farm.Inventory.Put(sword);
                Assert.AreEqual(farm.Locate("sword"),sword);
            }
            [Test]
            public void PlayerInLocation()
            {
                List<Path> _objectives = new List<Path>();
                Player player = new Player("Matt", "me", _objectives);
                Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land", 0, 0);
                farm.AddPlayer(player);
                Assert.IsTrue(farm.Players.Contains(player));
            }
            
        }
    }
}
