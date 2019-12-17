using System;

namespace HeroGame
{
    public class Enemy : Hero
    {
        Random _random = new Random();
        
        public Enemy(string name) : base(name)
        {
        }

        public override void do_action(Hero otherHero)
        {
            int damage = Math.Min(5 * Level, otherHero.Health) + _random.Next(50);
            otherHero.Health -= damage;
            steal_health(damage);
            Console.WriteLine($"Enemy {Name} attacks {otherHero.Name}. Does {damage} damage");    
        }

        public override void special_ability(Hero othHero)
        {
            int damage = othHero.Health / 2;
            othHero.Health -= damage; 
            Console.WriteLine($"{Name} drink {othHero.Name} soul and do {damage}.");
            
        }

        public void steal_health(int damage)
        {
            if (_random.Next(10) > 2)
            {
                Health += damage / 10;
                Console.WriteLine($"{Name} steal {damage / 10} health.");
            }
        }
    }
}