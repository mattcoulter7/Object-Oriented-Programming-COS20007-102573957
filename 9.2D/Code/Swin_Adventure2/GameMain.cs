using System;
using System.Collections.Generic;
using Swin_Adventure;

namespace Swin_Adventure2
{
    public class GameMain
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Swin Adventure!\nBefore We Start, what is your Name?");
            Console.WriteLine("Username: ");
            var name = Console.ReadLine();
            Console.WriteLine("User Description: ");
            var desc = Console.ReadLine();

            //locations and paths
            List<Path> Objectives = new List<Path>();
            Location Farm = new Location(new string[] { "farm", "farmland" }, "Farm", "a big piece of flat sparse land.", 0, 0);
            Objectives.Add(new Path(new string[] { "" }, Farm));
            Location Barn = new Location(new string[] { "barn" }, "Barn", "a haunted Red Barn that is pitch black inside.", 100, 100);
            Objectives.Add(new Path(new string[] { "" }, Barn));
            Location Tractor = new Location(new string[] { "tractor" }, "Tractor", "an abandoned Tractor with fresh blood splatters over the front.", 20, -45);
            Objectives.Add(new Path(new string[] { "" }, Tractor));
            Location Mine = new Location(new string[] { "barn" }, "Mine", "a deep underground mind with spooky noises.", 35, 170);
            Objectives.Add(new Path(new string[] { "" }, Mine));
            Location Hogwarts = new Location(new string[] { "hogwarts" }, "Hogwarts", "a school of Witchcraft and Wizardry.", 1000, 1000);
            Objectives.Add(new Path(new string[] { "" }, Hogwarts));

            //items
            Item sword = new Item(new string[] { "Sword", "Weapon" }, "Sword", "a rusted Sword.");
            Item shoes = new Item(new string[] { "Shoes", "Sneakers" }, "Shoes", "a pair of white sneakers.");
            Item umbrella = new Item(new string[] { "Umbrella" }, "Umbrella", "a small black umbrella with a butterfly picture underneath.");
            Bag bag = new Bag(new string[] { "Bag" }, "Bag", "a Leather Bag");
            Item wheel = new Item(new string[] { "wheel" }, "Wheel", "a heavy tractor wheel");
            Item mirror = new Item(new string[] { "mirror" }, "Mirror", "a small shard from a shattered mirror");
            Item knife = new Item(new string[] { "Knife", "Weapon" }, "Knife", "a sharp iron dagger.");
            Item invisiblecloak = new Item(new string[] { "invisible", "cloak" }, "Invisible Cloak", "a cloak that keeps you hidden from Snape");

            //placement of items
            Farm.Inventory.Put(bag);
            bag.Inventory.Put(umbrella);
            Farm.Inventory.Put(knife);
            Barn.Inventory.Put(sword);
            Barn.Inventory.Put(wheel);
            Tractor.Inventory.Put(mirror);
            Mine.Inventory.Put(invisiblecloak);

            //player
            Player player = new Player(name, desc, Objectives);
            player.Inventory.Put(shoes);
            Console.WriteLine(player.Path.CheckPlayerLocation(player));


            //commands
            LookCommand LookCommand = new LookCommand(new string[] { "look", "examine" });
            MoveCommand MoveCommand = new MoveCommand(new string[] { "move", "go", "head", "leave" });
            PutCommand PutCommand = new PutCommand(new string[] { "put", "drop" });
            TakeCommand TakeCommand = new TakeCommand(new string[] { "take", "pickup" });
            CommandProcessor CommandProcessor = new CommandProcessor(LookCommand, MoveCommand, PutCommand, TakeCommand);

            //command loop
            while (true)
            {
                Console.WriteLine("Enter Command");
                string command = Console.ReadLine().ToLower();
                string[] Acommand = command.Split(" ");
                Console.WriteLine(CommandProcessor.RunCommand(player, Acommand));
            }

        }
    }
}

