using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Location : GameObject, IHaveInventory
    {
        Inventory _inventory = new Inventory();
        List<Player> _players = new List<Player>();
        private float _x;
        private float _y;
        public Location(string[] ids, string name, string desc,float x, float y) : base(ids,name,desc)
        {
            _x = x;
            _y = y;
        }

        public Inventory Inventory { get => _inventory; set => _inventory = value; }
        public List<Player> Players { get => _players; set => _players = value; }
        public float X { get => _x; }
        public float Y { get => _y; }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            else
            {
                return _inventory.Fetch(id);
            }
        }
        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            _players.Remove(player);
        }

    }
}
