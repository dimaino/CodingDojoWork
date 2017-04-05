using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Way 1
            // List<Card> c = new List<Card>();
            // string[] suits = new string[4] {"Hearts", "Clubs", "Spades", "Diamonds"};
            // foreach(string suit in suits)
            // {
            //     for(int i = 1; i <= 13; i++)
            //     {
            //         c.Add(new Card(suit, i));
            //     }
            // }
            // Deck someDeck = new Deck(c);
            // Player player1 = new Player("Bob");
            // someDeck.Shuffle();
            // player1.DrawFromDeck(someDeck);
            // player1.DrawFromDeck(someDeck);
            // player1.DrawFromDeck(someDeck);
            // player1.DrawFromDeck(someDeck);
            // player1.DrawFromDeck(someDeck);
            // System.Console.WriteLine(player1.ToString());
            
            // //Console.WriteLine(someDeck);
            // System.Console.WriteLine();
            // System.Console.WriteLine();
            // System.Console.WriteLine();
            
            // Way 2
            // System.Console.WriteLine("Create a new deck:");
            
            // Deck theDeck = new Deck();
            // Console.WriteLine(theDeck);
            // theDeck.Shuffle();
            // //System.Console.WriteLine(theDeck.SelectTopMost());
            // //Console.WriteLine(theDeck);

            // Player player1 = new Player("Daniel");
            // player1.DrawFromDeck(theDeck, 5);
            // Player player2 = new Player("Daniela");
            // player2.DrawFromDeck(theDeck, 5);
            // //bool lol = player1.checkCards("7 of Hearts");
            // bool lol = player2.checkCardNum("9");
            // if(lol == true)
            // {
            //     System.Console.WriteLine("WOW LOL");
            // }
            // else
            // {
            //     System.Console.WriteLine(":(");
            // }
            
            // System.Console.WriteLine(player1.name + "'s hand: " + player1.ToString());
            // System.Console.WriteLine(player2.name + "'s hand: " + player2.ToString());
            // System.Console.WriteLine(theDeck.getCardCount() + " Left in Deck");



            // GO FISH
            System.Console.WriteLine("Ready to play Go Fish?");
            System.Console.WriteLine("Type end to end the game");
            bool gameStatus = true;
            int player1Points = 0;
            int player2Points = 0;
            while(gameStatus)
            {

                System.Console.WriteLine("Please enter in a name player1!");
                string player1Name = Console.ReadLine();
                Player player1 = new Player(player1Name);
                if(player1Name.Equals("end"))
                {
                    break;
                }

                System.Console.WriteLine("Please enter in a name player2!");
                string player2Name = Console.ReadLine();
                Player player2 = new Player(player2Name);
                if(player2Name.Equals("end"))
                {
                    break;
                }

                Deck newDeck = new Deck();
                //System.Console.WriteLine(newDeck);
                //newDeck.Shuffle();
                System.Console.WriteLine("");

                System.Console.WriteLine("");
                player1.DrawFromDeck(newDeck, 5);
                System.Console.WriteLine(player1);
                player2.DrawFromDeck(newDeck, 5);
                System.Console.WriteLine(player2);
                //Console.Clear();
                //ConsoleColor red = ConsoleColor.Red;
                while(newDeck.getCardCount() != 0 && gameStatus)
                {
                    //Console.Clear();
                    if(player1.numOfCardsInHand() == 0)
                    {
                        player1.DrawFromDeck(newDeck, 5);
                    }
                    if(player2.numOfCardsInHand() == 0)
                    {
                        player2.DrawFromDeck(newDeck, 5);
                    }
                    System.Console.WriteLine("HERE!!!!!!!!!!!!!!!!!!!!!!!!");

                    System.Console.WriteLine("Player1 Count: " + player1.numOfCardsInHand());
                    for(int x = 0; x < player1.numOfCardsInHand(); x++)
                    {
                        System.Console.WriteLine("X: " + x);
                        int count = 0;
                        List<Card> nl = new List<Card>();
                        nl.AddRange(player1.getListObject());
                        while(nl[x].val.ToString().Equals(x.ToString()))
                        {
                            count++;
                            nl.RemoveAt(nl.Count - 1);
                        }
                        if(count == 4)
                        {
                            player1Points++;
                        }
                    }
                    System.Console.WriteLine("HERE!!!!!!!!!!!!!!!!!!!!!!!!");
                    System.Console.WriteLine("Player2 Count: " + player2.numOfCardsInHand());
                    for(int x = 0; x < player2.numOfCardsInHand(); x++)
                    {
                        System.Console.WriteLine("X: " + x);
                        int count = 0;
                        List<Card> nl = new List<Card>();
                        nl.AddRange(player2.getListObject());
                        while(nl[x].val.ToString().Equals(x.ToString()))
                        {
                            count++;
                            nl.RemoveAt(nl.Count - 1);
                        }
                        if(count == 4)
                        {
                            player2Points++;
                        }
                    }
                    System.Console.WriteLine("HERE!!!!!!!!!!!!!!!!!!!!!!!!");

                    // Player1's Turn
                    System.Console.WriteLine("");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("Showing " + player1.name + "'s hand: ");
                    System.Console.WriteLine(player1);

                    // System.Console.WriteLine("Please enter a number 1-13 (Ace, 2-10, Jack, Queen, King) to see if the other player has that rank: ");
                    string player1Guess = "";// = Console.ReadLine();
                    bool play1 = true;
                    while(play1 && !(player1Guess.Equals("end")))
                    {
                        System.Console.WriteLine("\nPlease " + player1.name + " enter a number 1-13 (Ace, 2-10, Jack, Queen, King) to see if the other player has that rank: ");
                        System.Console.WriteLine("Please enter a value in your list!");
                        player1Guess = Console.ReadLine();
                        int someVal = player1.getListObject().Count;
                        System.Console.Write("Pick one of these: ");
                        for(int i = 0; i <= someVal - 1; i++)
                        {
                            System.Console.Write(player1.getListObject()[i].val + ", ");
                        }
                        for(int i = 0; i <= someVal - 1; i++)
                        {
                            if(player1.getListObject()[i].val.ToString().Equals(player1Guess))
                            {
                                System.Console.WriteLine("Your guess: " + player1Guess);
                                play1 = false;
                                someVal = 0;
                            }
                        }
                        System.Console.WriteLine("Cards Left: " + newDeck.getCardCount());
                    }
                    var player1correct = player2.checkCardNum(player1Guess);
                    // if(player1Guess.Equals("end"))
                    // {
                    //     break;
                    // }
                    while(player1correct.Key)
                    {
                        
                        System.Console.WriteLine("Player 2 has: " + player1Guess);
                        player1.addToList(player1correct.Value);
                        System.Console.WriteLine(player1);
                        System.Console.WriteLine("Please enter a number 1-13 (Ace, 2-10, Jack, Queen, King) to see if the other player has that rank: ");
                        player1Guess = Console.ReadLine();
                        if(player1Guess.Equals("end"))
                        {
                            Environment.Exit(0);
                        }
                        player1correct = player2.checkCardNum(player1Guess);
                    }
                    player1.DrawFromDeck(newDeck);
                    System.Console.WriteLine(player2.name + " is not currently holding any " + player1Guess);

                    //Console.Clear();

                    
                    // Player2's Turn
                    System.Console.WriteLine("");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("Showing " + player2.name + "'s hand: ");
                    System.Console.WriteLine(player2);

                    string player2Guess = "";// = Console.ReadLine();
                    bool play2 = true;
                    while(play2 && !(player2Guess.Equals("end")))
                    {
                        System.Console.WriteLine("Please " + player2.name + " enter a number 1-13 (Ace, 2-10, Jack, Queen, King) to see if the other player has that rank: ");
                        System.Console.WriteLine("Please enter a value in your list!");
                        player2Guess = Console.ReadLine();
                        int someVal = player2.getListObject().Count;
                        System.Console.Write("Pick one of these: ");
                        for(int i = 0; i <= someVal - 1; i++)
                        {
                            System.Console.Write(player2.getListObject()[i].val + ", ");
                        }
                        for(int i = 0; i <= someVal - 1; i++)
                        {
                            if(player2.getListObject()[i].val.ToString().Equals(player2Guess))
                            {
                                System.Console.WriteLine("Your guess: " + player2Guess);
                                play2 = false;
                                someVal = 0;
                            }
                        }
                        System.Console.WriteLine("Cards Left: " + newDeck.getCardCount());
                    }
                    var player2correct = player1.checkCardNum(player2Guess);
                    // if(player2Guess.Equals("end"))
                    // {
                    //     break;
                    // }
                    while(player2correct.Key)
                    {
                        
                        System.Console.WriteLine("Player 1 has: " + player2Guess);
                        player2.addToList(player2correct.Value);
                        System.Console.WriteLine(player2);
                        System.Console.WriteLine("Please enter a number 1-13 (Ace, 2-10, Jack, Queen, King) to see if the other player has that rank: ");
                        player2Guess = Console.ReadLine();
                        if(player2Guess.Equals("end"))
                        {
                            Environment.Exit(0);
                        }
                        player2correct = player1.checkCardNum(player2Guess);
                    }
                    player2.DrawFromDeck(newDeck);
                    System.Console.WriteLine(player1.name + " is not currently holding any " + player2Guess);

                    
                }

                System.Console.WriteLine("Type to end to end the game!");
                string gameStatusString = Console.ReadLine();
                if(gameStatusString.Equals("end"))
                {
                    Environment.Exit(0);
                }
            }
            
        }
    }
}
