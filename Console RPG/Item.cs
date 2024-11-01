using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        
        public static PotionI PotionI = new PotionI("Potion I", "Regain health.", 20, 20, 50 );
        public static ShortSword ShortSword1 = new ShortSword("ShortSword", "A moderatly decent sword.", 30, 20, 40);
        public string name;
        public string description;
        public int shopPrice;
        public int sellPrice;
      

        public Item(string name, string description, int shopPrice, int sellPrice)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.sellPrice = sellPrice;
           
        }

        public abstract void Use(Entity user, Entity target);

    }


    class ShortSword : Item

    {
        public int damage;

        public ShortSword(string name, string description, int shopPrice, int sellPrice, int damage) : base(name, description, shopPrice, sellPrice)
        {
            this.damage = damage;
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHP -= damage;
        }
    }


    class BoomStickItem : Item
    {
        public int damage;
        public int ammo;

        public BoomStickItem(string name, string description, int shopPrice, int sellPrice, int damage, int ammo) : base(name, description, shopPrice, sellPrice)
        {
            this.damage = damage;
            this.ammo = ammo;
        }

        public override void Use(Entity user, Entity target)
        {
            if (this.ammo == 0)
                return;

            target.currentHP -= damage;
            --ammo;
        }


    }
    class PotionI : Item
    {

        int HealAmount;

        public PotionI(string name, string description, int shopPrice, int sellPrice, int HealAmount) : base(name, description, shopPrice, sellPrice)
        {  
            this.HealAmount = HealAmount;
        }
        public override void Use (Entity user, Entity target)
        {
            user.currentHP += HealAmount;
            Program.print($"You used the potion and gained {HealAmount}");
            Program.print($"You are now at {user.currentHP}");
            
        }

        
            

        
    }
}
