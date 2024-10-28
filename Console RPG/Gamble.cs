using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Gamble
       
    {
        public static void Resolve()
        {
            Random random = new Random();
            string[] symbols = { "Cherry", "Lemon", "Orange", "Bell", "Bar", "Seven" };

            while (true)
            {
                Console.WriteLine("Press Enter to spin the slot machine.");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                string[] result = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    result[i] = symbols[random.Next(symbols.Length)];
                }

                Console.WriteLine($"|{result[0]}|{result[1]}|{result[2]}");

                if (result[0] == result[1] && result[1] == result[2])
                {

                    Console.WriteLine("!JACKPOT!, You earned 100 coins!");
                    Console.WriteLine("exit to leave");
                    Player.coinCount += 100;
                }
                else
                {
                    Console.WriteLine("better luck next time");
                }

            }
        }
    }
}
       

  