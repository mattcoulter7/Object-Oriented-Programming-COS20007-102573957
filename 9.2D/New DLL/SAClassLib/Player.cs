using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Player : GameObject, IHaveInventory
    {
        //private field
        private Inventory _inventory;
        private Location _location;
        private float _x = 0;
        private float _y = 0;
        private Path _path;
        private List<Path> _objectives;
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
        public Path Path { get => _path; set => _path = value; }
        public List<Path> Objectives { get => _objectives; }

        //constructor
        public Player(string name, string desc,List<Path> objectives)
            : base(new string[] { "me", "inventory" },name,desc)
        {
            _inventory = new Inventory();
            _objectives = objectives;
            _path = _objectives[0];
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

        public string EnterLocation(Location l)
        {
            _location = l;
            l.AddPlayer(this);
            return "You have entered the " + _location.Name + "\nThis is a " + _location.FullDescription + "\nIn this location you can see: " + _location.Inventory.ItemList + "\n" + UpdateObjective();
        }

        public void LeaveLocation()
        {
            _location.RemovePlayer(this);
            _location = null;
        }

        public string UpdateObjective()
        {
            if (Objectives.IndexOf(_path) < Objectives.Count - 1)
            {
                _path = Objectives[Objectives.IndexOf(_path) + 1];
                return "You should pickup some items then make your way to the " + Path.Destination.Name + "\nThe " + Path.TestRemainingDistance(this);

            }
            return "You have survived Swin Adventure.";
        }

    }
}
