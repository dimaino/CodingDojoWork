using System;

public class Wizard : Human
{
    public string wizardName { get; set; }
    public Wizard(string wizardName) : base(wizardName, 3, 25, 3, 50)
    {
        System.Console.WriteLine("Created a new wizard Named " + wizardName);
        this.wizardName = wizardName;
    }

    public void heal()
    {
        health += 10 * intelligence;
        System.Console.WriteLine("Wizard Just Healed " + 10 * intelligence + " Health points and now has " + health + " health!");
    }

    public void fireball(object o)
    {
        // if(o is Human)
        // {
        //     Human target = o as Human;
        //     Random rand = new Random();
        //     int oldhealth = target.health;
        //     target.health -= rand.Next(20,51);
        //     int damage = oldhealth - target.health;
        //     System.Console.WriteLine("Wizard Attacked a Human Named: " + target.name + " who did " + damage + " damage current health " + target.health + " Starting health was " + oldhealth);
        // }
        // else if(o is Ninja)
        // {
        //     Ninja target = o as Ninja;
        //     Random rand = new Random();
        //     int oldhealth = target.health;
        //     target.health -= rand.Next(20,51);
        //     int damage = oldhealth - target.health;
        //     System.Console.WriteLine("Wizard Attacked a Ninja Named: " + target.name + " who did " + damage + " damage current health " + target.health + " Starting health was " + oldhealth);
        // }
        // else if(o is Samurai)
        // {
        //     Samurai target = o as Samurai;
        //     Random rand = new Random();
        //     int oldhealth = target.health;
        //     target.health -= rand.Next(20,51);
        //     int damage = oldhealth - target.health;
        //     System.Console.WriteLine("Wizard Attacked a Samurai Named: " + target.name + " who did " + damage + " damage current health " + target.health + " Starting health was " + oldhealth);
        // }
        // else if(o is Wizard)
        // {
        //     Wizard target = o as Wizard;
        //     Random rand = new Random();
        //     int oldhealth = target.health;
        //     target.health -= rand.Next(20,51);
        //     int damage = oldhealth - target.health;
        //     System.Console.WriteLine("Wizard Attacked a Wizard Named: " + target.name + " who did " + damage + " damage current health " + target.health + " Starting health was " + oldhealth);
        // }
        // else
        // {
        //     System.Console.WriteLine("Failed to attack!!!");
        // }
        if(o is Spider)
        {
            Spider target = o as Spider;
            target.health -= 10;
            System.Console.WriteLine("Attack a spider named " + target.name);
        }
        else if(o is Zombie)
        {
            Zombie target = o as Zombie;
            target.health -= 10;
            System.Console.WriteLine("Attack a zombie named " + target.name);
        }
        else
        {
            System.Console.WriteLine("Failed to attack!!!");
        }
    }
}