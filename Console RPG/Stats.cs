namespace Console_RPG
{
    struct Stats
    {
        public int Attack;
        public int Defence;
        public int ManiAtk;
        public int ManiDef;

        public Stats(int attack, int defence, int maniAtk, int maniDef)
        {
            this.Attack = attack;
            this.Defence = defence;
            this.ManiAtk = maniAtk;
            this.ManiDef = maniDef;
        }
    }
}
