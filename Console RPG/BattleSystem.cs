using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_RPG
{
    class BattleSystem : LocationFeature
    {
        
        
        
        
        
        
        
        
        
        
        
        
        public List<Enemy> enemies;
        


        public BattleSystem(List<Enemy> enemies) : base(false)
        {
            this.enemies = enemies;
        }

        public override void Resolve(List<Player> Players)
        {
           while (true)
            {
                foreach (var player in Players)
                {
                    if (player.currentHP > 0)
                    {
                    Program.print ("It is " + player.name + "'s turn.");
                        Program.print("What would you like to do?");
                        
                   
                        player.Doturn(Players, enemies);
                    }
                    
                }    
                //If the player wins
                if (enemies.TrueForAll(enemies => enemies.currentHP <= 0))
                {
                    Player.coinCount += enemies.Sum(enemy => enemy.coinsDroppedOnDefeated);
                    Program.print("You have won, you live to see another day!");
                    break;
                }

                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                    Program.print ("It is " + enemy.name + "'s turn.");
                    enemy.Doturn(Players, enemies);
                        this.isResloved = true;
                    }
                    
                }
                 //If the player lose
                if (Players.TrueForAll(player => player.currentHP <= 0))
                {
                    Program.print("You have fallen");
                    break;
                }


            }

        }
    }
}
