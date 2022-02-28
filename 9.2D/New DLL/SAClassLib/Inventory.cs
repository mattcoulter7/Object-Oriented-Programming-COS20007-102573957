using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class Inventory
    {
        //private field
        private List<Item> _items = new List<Item>();

        //property
        public string ItemList
        {
            get
            {
                string list = "\n";
                foreach (Item itm in _items)
                {
                    list = list + "\t" + itm.ShortDescription + "\n";
                }
                return list;
            }
        }

        //constructor
        public Inventory()
        {

        }

        //methods
        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm != null)
                {
                    if (itm.AreYou(id))
                    {
                        if (_items.Contains(itm))
                        {
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }
        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public Item Take(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    _items.Remove(itm);
                    return itm;
                }
            }

            return null;
        }

        public Item Fetch(string id)
        {
            foreach(Item itm in _items)
            {
                if (itm.AreYou(id)) return itm;
            }

            return null;
        }
    }
}
