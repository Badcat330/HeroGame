using System;

namespace HeroGame
{
    public abstract class Hero
    {
        const int MaxLevel = 10;
        
        protected string name;
        protected int level;
        protected int health;

        protected Hero(string name)
        {
            this.name = name;
            level = 1;
            health = 100;
        }

        public abstract void do_action(Hero otherHero);

        public abstract void special_ability(Hero othHero);

        public void levelUp()
        {
            if (level <= MaxLevel)
            {
                ++level;
                health = 100;
                Console.WriteLine($"{name} is now a level {level}.");
            }
        }

        public string Name
        {
            get => name;
        }

        public int Level
        {
            get => level;
        }

        virtual public int Health
        {
            get => health;
            set
            {
                if (value <= 100)
                {
                    health = value;
                }
                if (health == 0)
                {
                    Console.WriteLine($"{name} id dead!");
                }
                else
                {
                    health = 100;
                }
                
            }
        }

        public bool IsAlife()
        {
            return health > 0;
        }
    }
}