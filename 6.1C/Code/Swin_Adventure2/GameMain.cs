﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    public class GameMain
    {
        static void Main()
        {
            Console.WriteLine("Username: ");
            var name = Console.ReadLine();
            Console.WriteLine("User Description: ");
            var desc = Console.ReadLine();
            Location farm = new Location(new string[] { "farm", "farmland" }, "Farm", "A big piece of land");
            Player player = new Player(name,desc);
            player.EnterLocation(farm);
            Item sword = new Item(new string[] { "Sword","Weapon"},"Sword","A Rusted Sword");
            Item shoes = new Item(new string[] { "Shoes", "Sneakers" }, "Shoes", "A Pair of White Sneakers");
            Item umbrella = new Item(new string[] { "Umbrella"}, "Umbrella", "A Small Black Umbrella with a Butterfly Picture Underneath");
            Bag bag = new Bag(new string[] { "Bag"}, "Bag", "A Leather Bag");
            farm.Inventory.Put(sword);
            player.Inventory.Put(shoes);
            farm.Inventory.Put(bag);
            bag.Inventory.Put(umbrella);
            LookCommand LookCommand = new LookCommand(new string[0]);
            while (true)
            {
                Console.WriteLine("Enter Command");
                string command = Console.ReadLine();
                string[] Acommand = command.Split(" ");
                Console.WriteLine(LookCommand.Execute(farm, player,Acommand));
            }
            
        }
    }
}
