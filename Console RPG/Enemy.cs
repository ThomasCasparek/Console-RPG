using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
    {
        //Enemies
        public static Enemy Goblin = new Enemy("Goblin", 100, 0, new Stats(20, 10, 0, 0), 5);
        public static Enemy SkeletonKing = new Enemy("SkeletonKing", 200, 50, new Stats(30, 10, 5, 5), 500);
        public static Enemy LivingArmor = new Enemy("LivingArmor", 150, 80, new Stats(25, 20, 5, 5), 500);

        //Enemies
       
        public int coinsDroppedOnDefeated;

        public Enemy(string name, int HP, int Mani, Stats stats, int coinsDroppedOnDefeated ) :base(name, HP, Mani, stats)
        {
            this.coinsDroppedOnDefeated = coinsDroppedOnDefeated;
        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            Random random = new Random();
            return choices[random.Next(0,choices.Count)];
        }

        public override void Attack(Entity target)
        {
            Program.print(this.name + " attacked 5" + target.name + "!");
            target.currentHP -= this.stats.Attack;
            Program.print(this.name + " did " + this.stats.Attack + " to You!");
            Program.print("You now have " + target.currentHP + " Left.");
           
            

            //caculatye damage
            //subrtract damage from trgt hp
            //tell the user
        }

        public override void Doturn(List<Player> Players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(Players.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
