using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Shop : LocationFeature
    {
        public string shopkeeperName;
        public List<Item> items;

        public Shop(string shopkeeperName, List<Item> items) : base(false)
        {
            this.shopkeeperName = shopkeeperName;
            this.items = items;
        }

        public override void Resolve(List<Player> players)
        {
            Program.print($"Geroge: ''Welcome to {shopkeeperName} 's shop! Buy my stuff!''");
            while (true)
            {
                Program.print("|BUY|   |LEAVE|   |SELL|   |!GAMBLE!|");
                string userChoice = Console.ReadLine().ToLower();

                if (userChoice == "buy")
                {


                    
                    {
                        Program.print("Geroge: ''What would you like to buy traveler?''");
                        
                        foreach (Item I in items)
                        {

                            Program.print($"{I.name} ({I.shopPrice})");

                        }
                        Item item = ChooseItem(this.items);
                            if (Player.coinCount < item.shopPrice)
                            {
                                Program.print("George: ''You can't buy this broke boy.''");
                            }
                        else
                        {
                        Player.coinCount -= item.shopPrice;
                        Player.Inventory.Add(item);
                        Program.print($"You purchased {item.name}!");

                        }




                    }


                   
               
                   



                }
                

                
                
                
                
                else if (userChoice == "sell")
                {
                    Item item = ChooseItem(Player.Inventory);
                    Player.coinCount += item.sellPrice;
                    Player.Inventory.Remove(item);

                    Program.print($"You sold {item.name}!");

                }
                else if (userChoice == "leave")
                {
                    break;
                }
                else if(userChoice == "gamble")
                {
                    Gamble.Resolve();
                }
            }
           
        }

        public Item ChooseItem(List<Item> choices)
            {
                Console.WriteLine("Type in the number corresponding to the item you'd like to buy!");

                for (int i = 0; i < choices.Count; i++)
                {
                    Program.print($"{i + 1}: {choices[i].name}");
                }

                int index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
    }
}
