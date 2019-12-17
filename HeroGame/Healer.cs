using System;

namespace HeroGame
{
    public class Healer: Hero
    {
        private int mana;
        
        public Random rnd = new Random();
        
        public Healer(string name) : base(name)
        {
            mana = 100;
        }

        public override void do_action(Hero otherHero)
        {
            if (mana >= 10)
            {
                int heal = Math.Min(5 * Level, otherHero.Health);
                otherHero.Health += heal;
                sun_strike(otherHero, heal);
                mana -= 10;
                Console.WriteLine($"{name} use his abilities and now has {mana} mana.");
            }
        }

        public override void special_ability(Hero othHero)
        {
            if (Level > 1)
            {
                othHero.Health = 100;
                mana -= 20;
                Console.WriteLine($"{name} heal all his team! Now have {mana} mana");
            }
            else
            {
                Console.WriteLine("You have too low level for using special ability");
            }
        }

        public void sun_strike(Hero otherHero, int heal)
        {
            if (otherHero is Enemy)
            {
                otherHero.Health -= heal;
                Console.WriteLine($"{Name} hit {otherHero.Name}. Does {heal} damage");
            }
            else
            {
                Console.WriteLine($"{Name} heal {otherHero.Name}. Does {heal} heal");
            }
        }
    }
}