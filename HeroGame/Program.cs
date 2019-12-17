using System;

namespace HeroGame
{
    class Program
    {

        public static Random rnd = new Random();
        public static int Reading()
        {
            int n;
            bool flag = false;
            do
            {
                if (flag)
                    Console.WriteLine("Повторите ввод");
                flag = true;
            } while (!int.TryParse(Console.ReadLine(), out n));

            return n;
        }
        
        public static void PrintMenu()
        {
            Console.WriteLine("1. Start journey \n" +
                              "2. Rules\n" +
                              "3. Exit\n");
        }

        public static void PrintEctions()
        {
            Console.WriteLine("1. Attack by warrior \n" +
                              "2. Attack by healer \n" +
                              "3. Use special warrior ability \n" +
                              "4. Use special healer ability \n" +
                              "5. Heal warrior \n" +
                              "6. Heal healer \n");
        }

        public static bool Game()
        {
            Hero[] heroes =  {new Warrior("Thor"), new Healer("Freya"), new Enemy("Uraboras")};
            while (heroes[0].Level != 10 && heroes[1].Level != 10)
            {
                if (Fight(heroes))
                {
                    Array.ForEach(heroes, x => x.levelUp());
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        
        public static bool Fight(Hero[] heroes)
        {
            
            Console.WriteLine("You was attacked by Uraboras!");
            PrintEctions();
            Console.WriteLine();
            while (Array.TrueForAll(heroes, x => x.IsAlife()))
            {
                switch (Reading())
                {
                    case 1:
                        heroes[0].do_action(heroes[2]);
                        break;
                    case 2:
                        heroes[1].do_action(heroes[2]);
                        break;
                    case 3:
                        heroes[0].special_ability(heroes[2]);
                        break;
                    case 4:
                        heroes[1].special_ability(heroes[0]);
                        heroes[1].special_ability(heroes[1]);
                        break;
                    case 5:
                        heroes[1].do_action(heroes[0]);
                        break;
                    case 6:
                        heroes[1].do_action(heroes[1]);
                        break;
                }

                if (rnd.Next(2) == 1 || heroes[2].Level == 1)
                {
                    heroes[2].do_action(heroes[rnd.Next(2)]);
                }
                else
                {
                    heroes[2].special_ability(heroes[rnd.Next(2)]);
                }
            }

            return heroes[0].IsAlife() && heroes[1].IsAlife();
        }
        
        static void Main(string[] args)
        {
            //PrintMenu();
            Console.WriteLine(~-1);
        }
    }
}