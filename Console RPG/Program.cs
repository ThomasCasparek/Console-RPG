using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;


namespace Console_RPG
{
    class Program
    {
        public static void print(string output)
        {
            if (output is null)
            {
                return;
            }

            for (int i = 0; i < output.Length; ++i)
            {
                Console.Write(output[i]);
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }


        static void Main(string[] args)

        {
            Console.ForegroundColor = ConsoleColor.White;
            print("What do you call yourself?");
            string name = Console.ReadLine();
            Player.Player1.name = name;

            Locations.Cave.SetNearbyLocations(north: Locations.ForestOpening);
            Locations.ForestOpening.SetNearbyLocations(north: Locations.TrainingYard);
            Locations.ForestOpening.SetNearbyLocations(west: Locations.Graveyard);
            Locations.ForestOpening.SetNearbyLocations(east: Locations.Shop);

            Locations.Cave.resolve(new List<Player>() { Player.Player1 });





            // BattleSystem GoblinBattle1 = new BattleSystem (new List<Enemy>(){ Enemy.Goblin});
            // //THE GAME:D

            // Locations.Cave.resolve(new List<Player> { Player.Player1 });
            //print("Hello " +name+ ", What will you do now?");
            //Console.ForegroundColor = ConsoleColor.Red;
            //print("|Look around|   |Check the sack|");
            ////Looking around
            //if (Console.ReadLine().ToLower() == "look around")
            //{
            //    print("You see an an exit out of the cave. ");
            //    print("What will you do now?");
            //    print("|Exit the cave.|");
            //    string input = Console.ReadLine().ToLower();
            //    if (input == "exit the cave")
            //    {
            //        print("A foul Goblin jumps out from a bush. " +
            //            "It charges you with its rusty knife");
            //
            //        GoblinBattle1.Resolve(new List<Player>() { Player.Player1 });
            //
            //    }
            //    if (GoblinBattle1.enemies.TrueForAll(enemies => enemies.currentHP <= 0))
            //    {
            //        print("You breath a sigh of relief knowing you are out of danger  .  .  . for now.");
            //        print("What would you like to do now?");
            //        print("|Finaly exit the cave| |Nothing IDK|");
            //
            //    }
            //    
            //    string rob = Console.ReadLine().ToLower();
            //    if (rob == "finally exit the cave") 
            //    {
            //        print("You see a dim path surrounded by trees in front of you, with a small quaint shop to your right, how nice!");
            //        while (true)
            //        {
            //            print("What will you like to do now " + Player.Player1.name + "?");
            //            print("|Go down the path|   |Visit the shop|");
            //            string bor = Console.ReadLine().ToLower();
            //            if (bor == "visit the shop")
            //            {
            //                Locations.ForestOpening.feature.Resolve(new List<Player>() { Player.Player1 });
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }
            //    }
            //
            //    string fork = Console.ReadLine().ToLower();
            //    if (fork == "go down the path")
            //    {/* WHERE YOU START */
            //        Locations.ForestOpening.resolve(new List<Player>() { Player.Player1 });
            //        print("You come to a fork in the forest, to the left, you see a Graveyard, and to the right you spot a Trainingyard.");
            //        print("What would you like to do now " + Player.Player1.name + "?");
            //        
            //    }
            //    
            //    
            //
            //}
            //Checking the sack
            //else if (Console.ReadLine().ToLower() == "check the sack")
            //{
            //    Console.WriteLine("You check your bag and find two potions of lesser healing and some bread.");
            //}
            ////After Exiting the cave
            //Random location stuff]



            /* WHERE YOU START */




            //Players


            //enemies


            //Items


            //Locations





        }
        //Code for wrong answers
        public static string Answers (List<string> COREECT, string input)
            
        {
            while (true)
            if (COREECT.Contains(input))
            {
                return input;
            }
            else
            {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Program.print("ERROR:INVALID ANSWER!!!");
                    
                    input = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }

        }
        
    }
}
