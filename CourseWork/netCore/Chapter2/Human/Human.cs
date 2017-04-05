namespace ConsoleApplication {
    public class Human {
        public string name;
        public int strength = 3;
        public int intellegence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(string myName)
        {
            name = myName;
        }
        public Human(string myName, int myStrength, int myIntellegence, int myDexterity, int myHealth)
        {
            name = myName;
            strength = myStrength;
            intellegence = myIntellegence;
            dexterity = myDexterity;
            health = myHealth;
        }

        public void Attack(Human h)
        {
            int damage = 5 * strength;
            h.health -= damage;
            System.Console.WriteLine(h.name + " lost " + damage + " Health! SHIT!!!");
        }

        public void AttackObject(object o)
        {
            Human h = o as Human;
            int damage = 5 * strength;
            h.health -= damage;
            System.Console.WriteLine(h.name + " lost " + damage + " Health! SHIT!!!");
        }

        public void PrintAttributes()
        {
            System.Console.WriteLine("Name:" + name + " Strength: " + strength + " Dexterity: " + dexterity + " Intellegence: " + intellegence + " Health: " + health);
        }
    }
}