using System;
using System.Collections.Generic;

namespace ConsoleApplication {
    public class Player {
        public string name;
        private List<Card> playersHand;
        public Player(string myName)
        {
            playersHand = new List<Card>();
            name = myName;
        }

        // public bool checkCards(string cardGuess)
        // {
        //     for(int i = 0; i < playersHand.Count - 1; i++)
        //     {
        //         if(playersHand[i].ToString().Equals(cardGuess))
        //         {
        //             return true;
        //         }
        //     }
        //     return false;
        // }

        public KeyValuePair<bool, List<Card>> checkCardNum(string cardVal)
        {
            List<Card> newCardList = new List<Card>(); 
            bool doesHandContain = false;
            for(int i = playersHand.Count - 1; i >= 0; i--)
            {
                //System.Console.WriteLine("Card: " + playersHand[i] + " Card Val: " + playersHand[i].val);
                if(playersHand[i].val.ToString() == cardVal)
                {
                    //System.Console.WriteLine("HERE!");
                    newCardList.Add(playersHand[i]);
                    //System.Console.WriteLine("Added: " + playersHand[i]);
                    playersHand.Remove(playersHand[i]);
                    //System.Console.WriteLine("Removed: " + playersHand[i]);
                    doesHandContain = true;
                }
            }
            return new KeyValuePair<bool, List<Card>>(doesHandContain, newCardList);
        }

        public List<Card> getListObject()
        {
            return playersHand;
        }

        public void addToList(List<Card> l)
        {
            playersHand.AddRange(l);
            // foreach(var i in l)
            // {
            //     playersHand.Add(i);
            // }
        }

        // Pick the to most card from the deck and add it to the players cards
        public void DrawFromDeck(Deck currentDeck)
        {
            if(currentDeck.getCardCount() >= 0)
            {
                playersHand.Add(currentDeck.SelectTopMost());
            }
            else
            {
                System.Console.WriteLine("Thats too many cards to draw!!!");
            }
        }

        // Pick a certain number of cards from the deck
        public void DrawFromDeck(Deck currentDeck, int num)
        {
            if(currentDeck.getCardCount() >= num)
            {
                for(int i = 0; i < num; i++)
                {
                    playersHand.Add(currentDeck.SelectTopMost());
                }
            }
            else
            {
                System.Console.WriteLine("Thats too many cards to draw!!!");
            }
        }

        // discard the card at the current position.
        public Card Discard(int i)
        {
            Card myCard = playersHand[i];
            playersHand.RemoveAt(i);
            return myCard;
        }

        // Removes all Cards from players hands
        public void Discard()
        {
            playersHand.Clear();
        }

        public int numOfCardsInHand()
        {
            return playersHand.Count;
        }

        // Prints out all cards in the players hands
        public override string ToString()
        {
            string str = "";
            foreach(var card in playersHand)
            {
                str += card + ", ";
            }
            return str;
        }
    }
}