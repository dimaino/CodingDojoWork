using System;

public class Spider : Enemy
{
    private string name;
    private int health {get; set;}
    private int strength {get;set;}
    private int intelligence {get;set;}
    private int dexterity {get;set;}

    public Spider(string name) : base(name)
    {
        this.name = name;
        health = 200;
        strength = 20;
        intelligence = 10;
        dexterity = 100;
    }
    public Spider(string name, int health, int strength, int intelligence, int dexterity) : base(name, health, strength, intelligence, dexterity)
    {
        this.name = name;
        this.health = health;
        this.strength = strength;
        this.intelligence = intelligence;
        this.dexterity = dexterity;
    }

    public void silkAttack(object obj)
    {
        // if(obj is Human && !(obj is Ninja) || )
        // {
        //     Human target = obj as Human;
        //     target.health -= 10;
        //     System.Console.WriteLine(target.name + " just lost 5 health and now is at " + target.health);
        // }
        if(obj is Ninja)
        {
            Ninja target = obj as Ninja;
            target.health -= 5;
            System.Console.WriteLine(target.name + " just lost 5 health and now is at " + target.health);
        }
        else if(obj is Wizard)
        {
            Wizard target = obj as Wizard;
            target.health -= 5;
            System.Console.WriteLine(target.name + " just lost 5 health and now is at " + target.health);
        }
        else if(obj is Samurai)
        {
            Samurai target = obj as Samurai;
            target.health -= 5;
            System.Console.WriteLine(target.name + " just lost 5 health and now is at " + target.health);
        }
        else
        {
            System.Console.WriteLine("Object can not be attacked!");
        }
    }
    public void heal()
    {
        this.health = 100;
        System.Console.WriteLine("Full Health!");
    }
    public override string ToString()
    {
        string str = "";
        str += "Name: " + name + " Strength: " + strength + " Intelligence: " + intelligence + " Dexterity: " + dexterity + " Health: " + health;
        return str;
    }
}