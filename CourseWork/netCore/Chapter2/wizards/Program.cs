using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Human human1 = new Human("Daniel");
            // Human human2 = new Human("Daniela", 500000, 100000,100,1);
            // System.Console.WriteLine(human1);
            // System.Console.WriteLine(human2);
            // System.Console.WriteLine("_________________________________________________");
            // Ninja ninja1 = new Ninja("Tom");
            // Ninja ninja2 = new Ninja("Rick");
            // Ninja ninja3 = new Ninja("Bill");
            // Ninja ninja4 = new Ninja("Serina");
            // ninja1.how_many();
            // System.Console.WriteLine("_________________________________________________");
            // Samurai samurai1 = new Samurai("MADGUY");
            // Samurai samurai2 = new Samurai("MADGUYFRIEND");
            // System.Console.WriteLine("_________________________________________________");
            // Wizard wizard1 = new Wizard("Chris");
            // Wizard wizard2 = new Wizard("NotChris");
            // System.Console.WriteLine(wizard1.ToString());
            // wizard1.fireball(human1);
            // wizard1.fireball(human2);
            // wizard1.fireball(ninja1);
            // wizard1.heal();

            // samurai1.death_blow(wizard2);
            // samurai1.meditate();

            // MAKE A GAME LOOP
            // WHILE GAMEGOING && HUMAN'S EXIST AND ENEMIES EXIST

            // INSIDE THE LOOK AS FOR INPUT FROM THE USER OF WHAT MOVE TO USE
            // WHEN ITS THE ENEMIES TURN RANDOMLY ATTACK
            // RANDOM ATTACK
            // MAKE MORE ATTACKS AND BASED ON THE NUMBER PICK THE ATTACK.
            // SPIDER - ATTACK() SILKATTACK() - dexterity * random  CRAWL() health * intellegence 
            // ZOMBIE - ATTACK() biteATTACK() SCRATCH()
            // WHILE(GAMEGOING && (zombie.health > 0 || spider.health > 0 || spider2.health > 0) && (ninja.health > 0 || samurai.health > 0 || wizard.health > 0))
            // TYPE(PLAY, END, RESTART, VIEWSTATS)
            // WHEN NO MORE ENEMIES OR HUMANS END LOOP ANNOUSE THE WINNER (WHO IS STILL ALIVE)
            // RETURN THE INSTANCES TO SEE HOW MANY EXIST
            // 
            
            Spider spider = new Spider("Spider");
            Spider spider2 = new Spider("Spider 2");
            Zombie zombie = new Zombie("Zombie");

            Ninja ninja = new Ninja("Larry the Ninja");
            Samurai samurai = new Samurai("Jerry the Samurai");
            Wizard wizard = new Wizard("Gary the Wizard");


            spider.silkAttack(ninja);
            spider.silkAttack(samurai);
            spider.silkAttack(wizard);
            zombie.biteAttack(wizard);
            spider2.silkAttack(wizard);

            ninja.attack(spider);
            samurai.attack(spider);
            wizard.fireball(zombie);
        }
    }
}
