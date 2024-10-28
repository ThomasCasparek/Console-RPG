using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Console_RPG
{
    class Player : Entity
    {
        //Inventory

        
        public static List<Item> Inventory = new List<Item>() { Item.PotionI };



        //Players
        public static Player Player1 = new Player("Player1", 200, 500, new Stats(50, 20, 50, 20));
        //players
        public Player(string name, int HP, int Mani, Stats stats) : base(name, HP, Mani, stats) { }
        

        public Armor headgear, chestwear, legwear;
        public Weapon mainWeapon;

        //Choosing Target
        public static int coinCount = 0;
        public override Entity ChooseTarget(List<Entity> choices)
        {
             //Program.print("Who do you choose to attack (Hint:Input the number.)");
           //prints list of who you can attack
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1} {choices[i].name}");
            }

            try
            {

                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }

            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Program.print("ERROR:INVALID ANSWER!!!");
                Console.ForegroundColor = ConsoleColor.White;
                return ChooseTarget(choices);
            }

        }
        public Item ChooseItem(List<Item> choices)
        {
            Program.print("Which item do you want to use?");
            //prints list of who you can attack
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1} {choices[i].name}");
            }





            try
            {

                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Program.print("ERROR:INVALID ANSWER!!!");
                Console.ForegroundColor = ConsoleColor.White;
                return ChooseItem(choices);
            }
        }

        //Attacking
        public override void Attack(Entity target)
        {
            Program.print(this.name + " attacked the " + target.name + "!");
            target.currentHP -= this.stats.Attack;
            Program.print(this.name + " did " + this.stats.Attack + " damage to " + target.name);
            Program.print("The " + target.name + " now has " + target.currentHP + " Left.");

        }
        public override void Doturn(List<Player> Players, List<Enemy> enemies)
        {

            Program.print("Do you choose to attack or use an item?");
            Program.print("|ATTACK| |ITEM|");
            string choice = Console.ReadLine().ToLower();
            Program.Inventory(choice);

            if (choice == "attack")
            {
            Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
            Attack(target);

            }
          
            else if(choice == "item")
            {
                Entity target = ChooseTarget(Players.Cast<Entity>().ToList());
                Item item = ChooseItem(Inventory);
                item.Use(Player1, target);
            }
            else
            {
                Doturn(Players, enemies);
            }





        }

        //Using Item
        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
       // public Item ChooseItem(List<Item> choices)
       // {
       //     Console.WriteLine("Type in the number of the item you want to use");
       //
       //     for (int i = 0; i < choices.Count; i++)
       //     {
       //         Program.print($"{i + 1}: {choices[i].name}");
       //     }
       //
       //     int index = Convert.ToInt32(Console.ReadLine());
       //     return choices[index - 1];
       // }
    }
}
