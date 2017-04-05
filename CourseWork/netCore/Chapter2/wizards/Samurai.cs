using System;

public class Samurai : Human
{
    public string samuraiName {get; set;}

    public Samurai(string samuraiName) : base(samuraiName, 3, 3, 3, 200)
    {
        System.Console.WriteLine("Created a new samurai Named " + samuraiName);
        this.samuraiName = samuraiName;
    }

    public void death_blow(object o)
    {
        if(o is Human)
        {
            Human target = o as Human;
            if(target.health <= 50)
            {
                target.health = 0;
                System.Console.WriteLine(target.name + " just got reduced to 0 health :(");
            }
        }
        else if(o is Ninja)
        {
            Ninja target = o as Ninja;
            if(target.health <= 50)
            {
                target.health = 0;
                System.Console.WriteLine(target.name + " just got reduced to 0 health :(");
            }
        }
        else if(o is Samurai)
        {
            Samurai target = o as Samurai;
            if(target.health <= 50)
            {
                target.health = 0;
                System.Console.WriteLine(target.name + " just got reduced to 0 health :(");
            }
        }
        else if(o is Wizard)
        {
            Wizard target = o as Wizard;
            if(target.health <= 50)
            {
                target.health = 0;
                System.Console.WriteLine(target.name + " just got reduced to 0 health :(");
            }
        }
        else
        {
            System.Console.WriteLine("Failed to attack!!!");
        }
    }

    public void meditate()
    {
        health = 200;
        System.Console.WriteLine(name + " meditated and now is fullhealth at " + health + " lifepoints!");
    }
}