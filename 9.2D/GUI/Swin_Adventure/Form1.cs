using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Swin_Adventure;


namespace Swin_Adventure2
{
    public partial class SwinAdventureForm : Form
    {
        private Item sword;
        private Item shoes;
        private Item umbrella;
        private Bag bag;
        private Item wheel;
        private Item mirror;
        private Item knife;
        private Item invisiblecloak;
        private List<Path> Objectives = new List<Path>();

        private Location Farm;
        private Location Barn;
        private Location Tractor;
        private Location Mine;
        private Location Hogwarts;

        private Player player;

        private LookCommand LookCommand;
        private MoveCommand MoveCommand;
        private PutCommand PutCommand;
        private TakeCommand TakeCommand;
        private CommandProcessor CommandProcessor;
        public SwinAdventureForm()
        {
            InitializeComponent();
        }
        private void SwinAdventureForm_Load(object sender, EventArgs e)
        {
            commandTxt.Visible = false;
            executeBtn.Visible = false;
            outputTxt.Text += "Welcome to Swin Adventure!\nBefore We Start, what is your Name?";
        }
        private void ExecuteBtn_Click(object sender, EventArgs e)
        {
            string command = commandTxt.Text.ToLower();
            string[] Acommand = command.Split(" ".ToCharArray());
            outputTxt.Text += "\r\n" + CommandProcessor.RunCommand(player, Acommand);
        }

        private void Initialise()
        {
            commandTxt.Visible = true;
            executeBtn.Visible = true;
            descTxt.Visible = false;
            userTxt.Visible = false;
            submitBtn.Visible = false;
            descLbl.Visible = false;
            userLbl.Visible = false;

            //locations and paths
            Farm = new Location(new string[] { "farm", "farmland" }, "Farm", "a big piece of flat sparse land.", 0, 0);
            Objectives.Add(new Path(new string[] { "north" }, Farm));
            Barn = new Location(new string[] { "barn" }, "Barn", "a haunted Red Barn that is pitch black inside.", 100, 100);
            Objectives.Add(new Path(new string[] { "east" }, Barn));
            Tractor = new Location(new string[] { "tractor" }, "Tractor", "an abandoned Tractor with fresh blood splatters over the front.", 20, -45);
            Objectives.Add(new Path(new string[] { "south" }, Tractor));
            Mine = new Location(new string[] { "barn" }, "Mine", "a deep underground mind with spooky noises.", 35, 170);
            Objectives.Add(new Path(new string[] { "west" }, Mine));
            Hogwarts = new Location(new string[] { "hogwarts" }, "Hogwarts", "a school of Witchcraft and Wizardry.", 1000, 1000);
            Objectives.Add(new Path(new string[] { "west" }, Hogwarts));

            //get name and desc
            string name = userTxt.Text;
            string desc = descTxt.Text;

            //items
            sword = new Item(new string[] { "Sword", "Weapon" }, "Sword", "a rusted Sword.");
            shoes = new Item(new string[] { "Shoes", "Sneakers" }, "Shoes", "a pair of white sneakers.");
            umbrella = new Item(new string[] { "Umbrella" }, "Umbrella", "a small black umbrella with a butterfly picture underneath.");
            bag = new Bag(new string[] { "Bag" }, "Bag", "a Leather Bag");
            wheel = new Item(new string[] { "wheel" }, "Wheel", "a heavy tractor wheel");
            mirror = new Item(new string[] { "mirror" }, "Mirror", "a small shard from a shattered mirror");
            knife = new Item(new string[] { "Knife", "Weapon" }, "Knife", "a sharp iron dagger.");
            invisiblecloak = new Item(new string[] { "invisible", "cloak" }, "Invisible Cloak", "a cloak that keeps you hidden from Snape");

            //placement of items
            Farm.Inventory.Put(bag);
            bag.Inventory.Put(umbrella);
            Farm.Inventory.Put(knife);
            Barn.Inventory.Put(sword);
            Barn.Inventory.Put(wheel);
            Tractor.Inventory.Put(mirror);
            Mine.Inventory.Put(invisiblecloak);

            //player
            player = new Player(name, desc, Objectives);
            player.Inventory.Put(shoes);
            outputTxt.Text += player.Path.CheckPlayerLocation(player);

            //commands
            LookCommand = new LookCommand(new string[] { "look", "examine" });
            MoveCommand = new MoveCommand(new string[] { "move", "go", "head", "leave" });
            PutCommand = new PutCommand(new string[] { "put", "drop" });
            TakeCommand = new TakeCommand(new string[] { "take", "pickup" });
            CommandProcessor = new CommandProcessor(LookCommand, MoveCommand, PutCommand, TakeCommand);
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            Initialise();
        }
    }
}
