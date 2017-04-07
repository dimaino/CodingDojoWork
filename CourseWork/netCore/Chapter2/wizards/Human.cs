using System;

public class Human
{
    public string name;

    //The { get; set; } format creates accessor methods for the field specified
    //This is done to allow flexibility
    public int health { get; set; }
    public int strength { get; set; }
    public int intelligence { get; set; }
    public int dexterity { get; set; }

    public Human(string person)
    {
        name = person;
        strength = 3;
        intelligence = 3;
        dexterity = 3;
        health = 100;
    }
    public Human(string person, int str, int intel, int dex, int hp)
    {
        name = person;
        strength = str;
        intelligence = intel;
        dexterity = dex;
        health = hp;
    }
    public void attack(object o)
    {
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
            System.Console.WriteLine("Failed to attack!");
        }
    }

    public override string ToString()
    {
        string str = "";
        str += "Name: " + name + " Strength: " + strength + " Intelligence: " + intelligence + " Dexterity: " + dexterity + " Health: " + health;
        return str;
    }
}
