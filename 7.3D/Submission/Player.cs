using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    public class Player : GameObject, IHaveInventory
    {
        //private field
        private Inventory _inventory;
        private Location _location;
        private List<Location> _locationhistory;
        private float _x = 0;
        private float _y = 0;
        //property
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public Location Location { get => _location; set => _location = value; }

        public override string FullDescription
        {
            get { return "You are " + ShortDescription + "\nYou are carrying:\n" + Inventory.ItemList; }
        }

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public List<Location> LocationHistory { get => _locationhistory; set => _locationhistory = value; }

        //constructor
        public Player(string name, string desc)
            : base(new string[] { "me", "inventory" },name,desc)
        {
            _inventory = new Inventory();
            _locationhistory = new List<Location>();
        }

        //methods
        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else if(_location != null)
            {
                if (_location.AreYou(id))
                {
                    return _location;
                }
                
            }
                return null;
        }

        public void EnterLocation(Location l)
        {
            _location = l;
            l.AddPlayer(this);
        }

        public void LeaveLocation()
        {
            _location.RemovePlayer(this);
            _locationhistory.Add(_location);
            _location = null;
        }

    }
}
