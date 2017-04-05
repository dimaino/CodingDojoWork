using System;

public class Ninja : Human
{
    public string ninjaName { set; get; }

    static int instances = 0;

    public Ninja(string ninjaName) : base(ninjaName, 3, 3, 175, 100)
    {
        System.Console.WriteLine("Created a new ninja Named " + ninjaName);
        this.ninjaName = ninjaName;
        instances++;
    }

    ~Ninja()
    {
        instances--;
    }

    public void steal(object o)
    {
        if(o is Human)
        {
            Human target = o as Human;
            int oldhealth = target.health;
            target.health -= 10;
            int damage = oldhealth - target.health;
            System.Console.WriteLine("Ninja Attacked a Human Named: " + target.name + " who did " + damage + " damage current health " + target.health + " Starting health was " + oldhealth);
        }
        else if(o is Ninja)
        {
            Ninja target = o as Ninja;
            int oldhealth = target.health;
            target.health -= 10;
            int damage = oldhealth - target.health;
            System.Console.WriteLine("Ninja Attacked a Ninja Named: " + target.name + " who did " + damage + " damage current health " + target.health + " Starting health was " + oldhealth);
            
        }
        else if(o is Samurai)
        {
            Samurai target = o as Samurai;
            int oldhealth = target.health;
            target.health -= 10;
            int damage = oldhealth - target.health;
            System.Console.WriteLine("Ninja Attacked a Samurai Named: " + target.name + " who did " + damage + " damage current health " + target.health + " Starting health was " + oldhealth);
        }
        else if(o is Wizard)
        {
            Wizard target = o as Wizard;
            int oldhealth = target.health;
            target.health -= 10;
            int damage = oldhealth - target.health;
            System.Console.WriteLine("Ninja Attacked a Wizard Named: " + target.name + " who did " + damage + " damage current health " + target.health + " Starting health was " + oldhealth);
        }
        else
        {
            System.Console.WriteLine("Failed to attack!!!");
        }
        health += 10;
    }

    public void get_away()
    {
        health -= 15;
        System.Console.WriteLine(name + " the ninja ran away and lost 15 health. The current health is " + health);
    }

    public void how_many()
    {
        System.Console.WriteLine("There are " + instances + " Ninja");
    }
}