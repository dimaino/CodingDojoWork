using System;
using System.Collections.Generic;

namespace ConsoleApplication {
    public class Deck {

        // Create a new List of cards
        private List<Card> cards; 

        // Call the reset method inorder to get all the 52 cards
        public Deck()
        {
            Reset();
        }

        // Create a new Deck based off a list of cards
        public Deck(List<Card> myCards)
        {
            cards = myCards;
        }

        // Select the card and return that card. if there is no card return a null
        public Card SelectTopMost()
        {
            if(cards.Count > 0)
            {
                Card newCard = cards[0];
                cards.RemoveAt(0);
                return newCard;
            }
            return null;
        }

        // Reset method will Create all 52 cards in the deck and will need to be shuffled.
        public Deck Reset()
        {
            cards = new List<Card>();
            string[] suits = new string[4] {"Hearts", "Clubs", "Spades", "Diamonds"};
            foreach(string suit in suits)
            {
                for(int i = 1; i <= 13; i++)
                {
                    cards.Add(new Card(suit, i));
                }
            }
            return this;
        }

        // Take the current deck and shuffle to create a random ordering.
        public Deck Shuffle()
        {
            Random rand = new Random();

            // While a card exists shuffle the card
            for(int i = cards.Count - 1; i > 0; i--)
            {
                // Create a new Random int between the length - 1 through 0
                int randAti = rand.Next(i);
                // Create a temp Car at position of the random int
                Card temp = cards[randAti];
                // Set the randonly positioned card to the card of the current value
                cards[randAti] = cards[i];
                // Set the current card equal to the card of the randomly pick position
                cards[i] = temp;
            }
            return this;
        }

        public int getCardCount()
        {
            return cards.Count;
        }

        // Override the ToString method to print out all the cards currently in the deck.
        public override string ToString()
        {
            string str = "";
            foreach(Card card in cards)
            {
                str += card + ", ";
            }
            return str;
        }
    }
}