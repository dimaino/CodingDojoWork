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

        public KeyValuePair<bool, List<Card>> checkCardNum(string cardVal)
        {
            List<Card> newCardList = new List<Card>(); 
            bool doesHandContain = false;
            for(int i = playersHand.Count - 1; i >= 0; i--)
            {
                
                if(playersHand[i].val.ToString() == cardVal)
                {
                 
                    newCardList.Add(playersHand[i]);
                    
                    playersHand.Remove(playersHand[i]);
                   
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
         
        }

        // Pick the to most card from the deck and add it to the players cards
        // public void DrawFromDeck(Deck currentDeck)
        // {
        //     if(currentDeck.getCardCount() >= 0)
        //     {
        //         playersHand.Add(currentDeck.SelectTopMost());
        //     }
        //     else
        //     {
        //         System.Console.WriteLine("Thats too many cards to draw!!!");
        //     }
        // }

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
            else if(currentDeck.getCardCount() > 0)
            {
                for(int i = 0; i < currentDeck.getCardCount(); i++)
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

        public string shownumber()
        {
            string str = "";
            foreach(var card in playersHand)
            {
                str += card.val + ", ";
            }
            return str;
        }

        // Prints out all cards in the players hands
        public override string ToString()
        {
            string str = "[";
            foreach(var card in playersHand)
            {
                str += card + ", ";
            }
            str += "]";
            return str;
        }
    }
}