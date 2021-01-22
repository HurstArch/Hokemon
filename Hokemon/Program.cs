using System;

namespace Hokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            Halor halHokemon1 = new Halor();
            halHokemon1.About();
            Hokemon hokemon2 = new Hokemon();
            battleArena battleArena1 = new battleArena();
            if (battleArena1.battleRequest(halHokemon1, hokemon2) == true)
            {
                battleArena1.fight(halHokemon1, hokemon2);
            }
        }
        public class Hokemon
        {
            public int random_int_generator(int minValue, int maxValue)
            {
                Random rnd = new Random();
                int randomValue;
                randomValue = rnd.Next(minValue, maxValue);
                return randomValue;
            }
            public double random_double_generator(double minValue, double maxValue)
            {
                Random rnd = new Random();
                return rnd.NextDouble() * (maxValue - minValue) + minValue;
            }
            void getName()
            {
                Console.WriteLine("Enter a name for your Hokemon");

                Name = Console.ReadLine();
            }
            void getDetails()
            {
                Console.WriteLine("Name: {0}\nHealth: {1}/{2}\nAttack: {3}\nDefence: {4}\nSpeed: {5}\n", name, health, maxHealth, attack, defence, speed);
            }
            public int attackValue(int attack,int speed)
            {
                int attackValue;
                attackValue = Convert.ToInt32(attack * speed * random_double_generator(0.75, 1.25));
                return attackValue;
            }
            
            public Hokemon() //constuctor
            {
               
               
                getName();
                maxHealth = 100;
                health = maxHealth;
                //health = random_int_generator(10, maxHealth);
                attack = random_int_generator(10, 100);
                speed = random_int_generator(10, 100);
                defence = random_int_generator(100, 200);
                ApparentHealth = Defence * 100;
                getDetails();
            }
            private string name;
            private int health;
            private int attack;
            private int maxHealth;
            private int speed;
            private int defence;
            private int apparentHealth;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int Health
            {
                get { return health; }
                set { health = value; }
            }
            public int Attack
            {
                get { return attack; }
                set { attack = value; }
            }
            public int MaxHealth
            {
                get { return maxHealth; }
                set { maxHealth = value; }
            }
            public int Speed
            {
                get { return speed; }
                set { speed = value; }
            }
            public int Defence
            {
                get { return defence; }
                set { defence = value; }
            }
            public int ApparentHealth
            {

                get { return apparentHealth; }
                set { apparentHealth = value; }
            }
            public void About()
            {
                Console.WriteLine("I am a hokemon");
                getDetails();
            }
        }
        public class battleArena
        {
            public battleArena() //constructor
            {

            }
            public void fight(Hokemon hokemon1, Hokemon hokemon2)
            {
                while (Convert.ToInt32(hokemon1.Health) >0 || Convert.ToInt32(hokemon2.Health) > 0)
                {
                    for (int i = 0; 1 < 2; i++)
                    {
                        int damage;
                        if (hokemon1.Speed >= hokemon2.Speed) 
                        {
                            damage = hokemon1.attackValue(hokemon1.Attack, hokemon1.Speed);
                            hokemon2.Health = Convert.ToInt32((hokemon2.ApparentHealth - damage) / hokemon2.Defence);
                            hokemon2.ApparentHealth -= damage;
                            Console.WriteLine("{0} attacks first \ndealing {1} damage to {2} \n{2} blocks some of it and is now at {3} health",hokemon1.Name, damage, hokemon2.Name, hokemon2.Health );
                            Console.ReadKey();
                        }
                        else
                        {
                            damage = hokemon2.attackValue(hokemon2.Attack, hokemon2.Speed);
                            hokemon1.Health = Convert.ToInt32((hokemon1.ApparentHealth - damage) / hokemon1.Defence);
                            hokemon1.ApparentHealth -= damage;
                            Console.WriteLine("{0} attacks first \ndealing {1} damage to {2} \n{2} blocks some of it and is now at {3} health", hokemon2.Name, damage, hokemon1.Name, hokemon1.Health);
                            Console.ReadKey();
                        }
                        Console.WriteLine("{}");
                        Console.WriteLine("2");
                    }

                }

            }
            public bool battleRequest(Hokemon challenger1, Hokemon challenger2)
            {
                string request;
                Console.WriteLine("{0} wants to fight {1}. do you accept?", challenger1.Name , challenger2.Name);
                request = Console.ReadLine();
                if (request.ToUpper() == "YES")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class Halor : Hokemon
        {
            private string team = "Halor";
            public void About() //polymorphism from hokemon "about" method
            {
                Console.WriteLine("my team is Halor");
                
            }
        }
    }



}
