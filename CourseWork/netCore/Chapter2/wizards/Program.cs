using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human human1 = new Human("Daniel");
            Human human2 = new Human("Daniela", 500000, 100000,100,1);
            System.Console.WriteLine(human1);
            System.Console.WriteLine(human2);
            System.Console.WriteLine("_________________________________________________");
            Ninja ninja1 = new Ninja("Tom");
            Ninja ninja2 = new Ninja("Rick");
            Ninja ninja3 = new Ninja("Bill");
            Ninja ninja4 = new Ninja("Serina");
            ninja1.how_many();
            System.Console.WriteLine("_________________________________________________");
            Samurai samurai1 = new Samurai("MADGUY");
            Samurai samurai2 = new Samurai("MADGUYFRIEND");
            System.Console.WriteLine("_________________________________________________");
            Wizard wizard1 = new Wizard("Chris");
            Wizard wizard2 = new Wizard("NotChris");
            System.Console.WriteLine(wizard1.ToString());
            wizard1.fireball(human1);
            wizard1.fireball(human2);
            wizard1.fireball(ninja1);
            wizard1.heal();

            samurai1.death_blow(wizard2);
            samurai1.meditate();
            
        }
    }
}
