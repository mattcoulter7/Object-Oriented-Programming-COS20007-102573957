using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    class Bag : Item, IHaveInventory
    {
        //private field
        private Inventory _inventory;

        //properties
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        //Constructor
        public Bag(string[] idents, string name, string desc): base(idents, name, desc)
        {
            _inventory = new Inventory();

        }

        //Methods
        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            else {
                return _inventory.Fetch(id);
            }
        }

    }
}
