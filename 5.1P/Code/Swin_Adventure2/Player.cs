using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    public class Player : GameObject, IHaveInventory
    {
        //private field
        private Inventory _inventory;

        //property
        public Inventory Inventory
        {
            get { return _inventory; }
        }
        
        public override string FullDescription
        {
            get { return "You are " + ShortDescription + "\nYou are carrying:\n" + Inventory.ItemList; }
        }

        //constructor
        public Player(string name, string desc)
            : base(new string[] { "me", "inventory" },name,desc)
        {
            _inventory = new Inventory();
        }

        //methods
        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            else
            {
                return _inventory.Fetch(id);
            }
        }

    }
}
