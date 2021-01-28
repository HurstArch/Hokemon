using System;

namespace Hokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            Hokemon hokemon1 = new Hokemon();
            Hokemon hokemon2 = new Hokemon();
            battleArena battleArena1 = new battleArena();
            if (battleArena1.battleRequest(hokemon1, hokemon2) == true)
            {
                battleArena1.battle(hokemon1, hokemon2);
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
            public void fight(Hokemon hokemon2)
            {
                int damage;
                damage = attackValue(attack, speed);
                hokemon2.health = Convert.ToInt32((hokemon2.apparentHealth - damage) / hokemon2.defence);
                hokemon2.apparentHealth -= damage;
                Console.WriteLine("{0} attacks \ndealing {1} damage to {2} \n{2} blocks some of it and is now at {3} health", name, damage, hokemon2.name, hokemon2.health);
                Console.WriteLine("pess any key to continue");
                Console.ReadKey();
            }
        }
        public class battleArena
        {
            public battleArena() //constructor
            {

            }
            public void battle(Hokemon hokemon1, Hokemon hokemon2)
            {
                while (hokemon1.Health >= 0 && hokemon2.Health >= 0)
                {
                    
                    
                    if (hokemon1.Speed >= hokemon2.Speed) 
                    {
                        Console.WriteLine("{0} has a higher speed so it attacks first", hokemon1.Name);
                        hokemon1.fight(hokemon2);
                        Console.WriteLine("*****************");
                        if (hokemon2.Health > 0)
                        {
                            hokemon2.fight(hokemon1);
                            Console.WriteLine("*****************");
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} has a higher speed so it attacks first", hokemon2.Name);
                        hokemon2.fight(hokemon1);
                        Console.WriteLine("*****************");
                        if (hokemon1.Health > 0)
                        {
                            hokemon1.fight(hokemon2);
                            Console.WriteLine("*****************");
                        }
                    }
                }
                if (hokemon1.Health <= 0)
                {
                    Console.WriteLine("{0} won", hokemon2.Name);
                }
                if (hokemon2.Health <= 0)
                {
                    Console.WriteLine("{0} won", hokemon1.Name);
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

        
        class firstAttacker : Hokemon
        {
            public void fight(Hokemon hokemon2) 
            {
                int damage;
                damage = attackValue(Attack, Speed);
                hokemon2.Health = Convert.ToInt32((hokemon2.ApparentHealth - damage) / hokemon2.Defence);
                hokemon2.ApparentHealth -= damage;
                Console.WriteLine("{0} attacks  \ndealing {1} damage to {2} \n{2} blocks some of it and is now at {3} health", Name, damage, hokemon2.Name, hokemon2.Health);
                Console.WriteLine("pess any key to continue");
                Console.ReadKey();
            }
        }
        class secondAttacker : Hokemon
        {
            public void fight(Hokemon hokemon1)
            {
                int damage;
                damage = attackValue(Attack, Speed);
                hokemon1.Health = Convert.ToInt32((hokemon1.ApparentHealth - damage) / hokemon1.Defence);
                hokemon1.ApparentHealth -= damage;
                Console.WriteLine("{0} attacks  \ndealing {1} damage to {2} \n{2} blocks some of it and is now at {3} health", Name, damage, hokemon1.Name, hokemon1.Health);
                Console.WriteLine("pess any key to continue");
                Console.ReadKey();
            }
        }
    }



}
