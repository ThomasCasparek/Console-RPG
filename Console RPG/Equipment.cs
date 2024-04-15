using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public float durability;
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice, int sellPrice, int durability, bool isEquipped) : base(name, description, shopPrice, sellPrice)
        {
            this.durability = durability;
            this.isEquipped = isEquipped;
        }
    }

    class Armor : Equipment
    {
        public int defence;


        public Armor(string name, string description, int shopPrice, int sellPrice, int durability, bool isEquipped, int defence) : base(name, description, shopPrice, sellPrice, durability, isEquipped)
        {
            this.defence = defence;
        }

        public override void Use(Entity user, Entity target)
        {
            //flip weather or not its equipped
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                // if the armor is not eqiped, then equip it and increase the users defence stat
                target.stats.Defence += this.defence;
            }

            else
            {
                //if its already equipped, the unequip it and decrease defence
                target.stats.Defence -= this.defence;
            }
            
            
        }
    }

    class Weapon : Equipment
    {
        public int  damageMultiplier;


        public Weapon(string name, string description, int shopPrice, int sellPrice, int durability, bool isEquipped, int damageMultiplier) : base(name, description, shopPrice, sellPrice, durability, isEquipped)
        {
            this.damageMultiplier = damageMultiplier;
        }

        public override void Use(Entity user, Entity target)
        {
            //flip weather or not its equipped
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                // if the armor is not eqiped, then equip it and increase the users dm stat
                target.stats.Defence += damageMultiplier;
                Program.print($"You equipped the {this.name}");
            }

            else
            {
                //if its already equipped, the unequip it and decrease dm
                target.stats.Defence -= this.damageMultiplier;
                Program.print($"You unequipped the {this.name}");
            }


        }
    }
}
