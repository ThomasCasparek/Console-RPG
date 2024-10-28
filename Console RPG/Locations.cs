using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Console_RPG
{

    class Locations
    {
        //Locations
       public static Locations Cave = new Locations("Cave", "You are fallen over with only a ShortSword and a sack with very little supplies.\r\nA enemy goblin charges you with it's rusty knife.", new BattleSystem(new List<Enemy>() {Enemy. Goblin }));
       public static Locations Graveyard = new Locations("The graveyard.", "Dark and cold.", new BattleSystem(new List<Enemy>() { Enemy.SkeletonKing }));
       public static Locations TrainingYard = new Locations("TrainingYard", "The smell of preperation fills the air.", new BattleSystem(new List<Enemy>() { Enemy.LivingArmor }));
        public static Locations ForestOpening = new Locations("Forest Opening", "Looks peaceful, and there is a quaint little shop to your right");
        public static Locations Shop = new Locations("George's Shop!", "Smells of cheap mead", new Shop("George", new List<Item>() { Item.PotionI }));
        //random ass locations stuff



        public string name;
        public string description;
        public bool isdescriptionresolved;
        public LocationFeature feature;

        public Locations north, east, south, west;

        public Locations(string name, string description, LocationFeature feature = null)
        {
            this.name = name;
            this.description = description;
            this.feature = feature;
        }

        public void SetNearbyLocations(Locations north = null, Locations east = null, Locations south = null, Locations west = null)
        {
            if (!(north is null))
            {
                north.south = this;
                this.north = north;

            }


            if (!(east is null))
            {
                east.west = this;
                this.east = east;
            }


            if (!(south is null))
            {
                south.north = this;
                this.south = south;
            }


            if (!(west is null))
            {
                west.east = this;
                this.west = west;
            }




        }

        public void resolve(List<Player> Players)
        {
            List<string>options = new List<string>();

            if (!isdescriptionresolved)
            {
            Program.print(" You find yourself in the " + name);
                Program.print(description);
                isdescriptionresolved = true;
            }
            


            //NullChecking
            if (feature != null && !feature.isResloved)
                feature?.Resolve(Players);

            if (!(this.north is null))
            {
                Program.print("NORTH: " + this.north.name);
                options.Add("north");
            }

            if (!(this.south is null))
            {
                Program.print("SOUTH: " + this.south.name);
                options.Add("south");
            }
            if (!(this.east is null))
            {
                Program.print("EAST: " + this.east.name);
                options.Add("east");
            }
            if (!(this.west is null))
            {
                Program.print("WEST: " + this.west.name);
                options.Add("west");
            }
            string input = Console.ReadLine();
            string direction="";
            if (!Program.Inventory(input))
            {
             direction = Program.Answers(options, input);
            }

            Locations nextLocations = this;

            //What do I

            if (direction == "north")
                nextLocations = this.north;
            else if (direction == "south")
                nextLocations = this.south;
            else if (direction == "east")
                nextLocations = this.east;
            else if (direction == "west")
                nextLocations = this.west;
            
            nextLocations.resolve(Players);
        }
        

    }
}
