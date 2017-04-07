using System;

public class Enemy
{
    public string name;
    public int health {get; set;}
    public int strength {get;set;}
    public int intelligence {get;set;}
    public int dexterity {get;set;}

    public Enemy(string name)
    {
        this.name = name;
        health = 100;
        strength = 10;
        intelligence = 10;
        dexterity = 10;
    }
    public Enemy(string name, int health, int strength, int intelligence, int dexterity)
    {
        this.name = name;
        this.health = health;
        this.strength = strength;
        this.intelligence = intelligence;
        this.dexterity = dexterity;
    }

    public virtual void attack(object obj)
    {
        if(obj is Enemy)
        {
            Enemy target = obj as Enemy;
            target.health -= 10;
        }
        else
        {
            System.Console.WriteLine("Not a regignizable object!!!");
        }
    }

    public override string ToString()
    {
        string str = "";
        str += "Name: " + name + " Strength: " + strength + " Intelligence: " + intelligence + " Dexterity: " + dexterity + " Health: " + health;
        return str;
    }

}