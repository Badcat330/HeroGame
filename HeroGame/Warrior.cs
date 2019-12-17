using System;

namespace HeroGame
{
    public class Warrior : Hero
    {
        readonly Random _rnd = new Random();
        
        public Warrior(string name) : base(name)
        {
        }

        public override void do_action(Hero otherHero)
        {
            int damage = Math.Min(5 * Level, otherHero.Health);
            otherHero.Health -= damage;
            Console.WriteLine($"{Name} attacks {otherHero.Name}. Does {damage} damage");
        }

        public override void special_ability(Hero othHero)
        {
            if (Level > 1)
            {
                int damage = othHero.Health / 100 * 30;
                othHero.Health -= damage;
                Health += 20;
                Console.WriteLine($"{Name} crash {othHero.Name} head and do {damage}.");
            }
            else
            {
                Console.WriteLine("You have too low level for using special ability");
            }
        }

        public override int Health
        {
            set
            {
                if(value < health && _rnd.Next(10) < 2)
                    return;
                if (value <= 100 )
                {
                    health = value;
                    return;
                }
                
                if (health == 0)
                {
                    Console.WriteLine($"{name} id dead!");
                    return;
                }
                health = 100;
            }
        }
    }
}