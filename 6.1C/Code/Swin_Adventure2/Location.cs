using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    public class Location : GameObject, IHaveInventory
    {
        Inventory _inventory = new Inventory();
        List<Player> _players = new List<Player>();
        public Location(string[] ids, string name, string desc) : base(ids,name,desc)
        {

        }

        public Inventory Inventory { get => _inventory; set => _inventory = value; }
        public List<Player> Players { get => _players; set => _players = value; }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            else
            {
                return _inventory.Fetch(id);
            }
        }
        public void AddPlayerHere(Player player)
        {
            _players.Add(player);
        }

    }
}
