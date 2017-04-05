namespace ConsoleApplication {
    public class Card {

        // Create the string with a getter method that returns the type of card based on the val recieved from the deck class.
        public string stringVal {
            get{
                if(val == 1)
                {
                    return "Ace";
                }
                else if(val == 11)
                {
                    return "Jack";
                }
                else if(val == 12)
                {
                    return "Queen";
                }
                else if(val == 13)
                {
                    return "King";
                }
                else
                {
                    return val.ToString();
                }
            }
        }


        // There are 4 set different suits (Hearts, Clubs, Spades, Diamonds)
        public string suit;

        // val is the value of the card (Ace,2,3-King)
        public int val;

        // Constructor to create a new card by passing through the suit and the val 
        public Card(string mySuit, int myVal)
        {
            suit = mySuit;
            val = myVal;
        }

        // Override the ToString method inorder to print out the Card Val (Ace-King) and print the suit.
        public override string ToString()
        {
            return stringVal + " of " + suit;
        }
    }
}