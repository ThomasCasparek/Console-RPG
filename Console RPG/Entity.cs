using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Entity
    {
        public string name;

        public int currentHP, maxHP;
        public int currentMani, maxMani;

        public Stats stats;

        public Entity(string name, int HP, int Mani, Stats stats)
        {
            this.name = name;
            this.currentHP = HP;
            this.maxHP = HP;
            this.currentMani = Mani;
            this.maxMani = Mani;
            this.stats = stats;
        }
        public abstract void Doturn(List<Player> Players, List<Enemy> enemies);
        public abstract Entity ChooseTarget(List <Entity> choices);

        public abstract void Attack(Entity target);

    }
}
