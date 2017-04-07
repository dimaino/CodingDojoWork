using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create games main loop boolean
            System.Console.WriteLine("Ready to play Go Fish?");
            bool gameOn = true;

            // Read in the Player 1 input
            System.Console.WriteLine("Please enter in a name player1!");
            string player1Name = Console.ReadLine();
            Player player1 = new Player(player1Name);

            // Read in the Player 2 input
            System.Console.WriteLine("Please enter in a name player2!");
            string player2Name = Console.ReadLine();
            Player player2 = new Player(player2Name);
            
            // Initialize player scores to 0
            int player1Points = 0;
            int player2Points = 0;
            
            // Initialize a new Deck
            Deck newDeck= new Deck();
            
            // Shuffle the Deck
            newDeck.Shuffle();
            System.Console.WriteLine(newDeck.getCardCount());

            // Draw 5 cards from the Deck for player 1
            player1.DrawFromDeck(newDeck, 5);
            //System.Console.WriteLine(player1);

            // Draw 5 cards from the Deck for player 2
            player2.DrawFromDeck(newDeck, 5);
            //System.Console.WriteLine(player2);

            // Stay in the loop while player doesnt Type Quit
            while(gameOn)
            {
                if(newDeck.getCardCount() == 0 && player1.getListObject().Count == 0 && player2.getListObject().Count == 0)
                {
                    break;
                }
                // Read in options and get users input
                System.Console.WriteLine("Please enter a command [Not Case Sensitive!!!] ('OnePlayer','TwoPlayer','Restart','Quit')");
                string gameStatus = Console.ReadLine();
                gameStatus = gameStatus.ToLower();

                player1Points += returnScore(player1);
                player2Points += returnScore(player2);

                if(newDeck.getCardCount() != 0)
                {
                    // If Player 1's hand is empty draw 5 more cards from the deck
                    if(player1.numOfCardsInHand() == 0)
                    {
                        player1.DrawFromDeck(newDeck, 5);
                    }

                    // If Player 2's hand is empty draw 5 more cards from the deck
                    if(player2.numOfCardsInHand() == 0)
                    {
                        player2.DrawFromDeck(newDeck, 5);
                    }
                }
                
                // Start game loop while game status != Quit
                switch(gameStatus)
                {
                    // Impleament AI for single player mode
                    case "oneplayer":
                        bool start = true;
                        while(newDeck.getCardCount() != 0 || player1.getListObject().Count != 0 || player2.getListObject().Count != 0)
                        {
                            
                            if(start)
                            {
                                System.Console.WriteLine("________________________________________________________________________________________");
                                playersTurn(player1, player2, player1Points, newDeck);
                                start = false;
                            }
                            else
                            {
                                System.Console.WriteLine("________________________________________________________________________________________");
                                playersTurn(player2, player1, player2Points, newDeck);
                                start = true;
                            }
                            
                        }
                        break;

                    // Allows you to play 2 players
                    case "twoplayer":
                        break;
                    case "restart":
                        break;
                    case "quit":
                        gameOn = false;
                        break;
                    default:
                        LOL();
                        break;
                }
            }

            // If the loops ends find which player has more points and print the winner.
            System.Console.WriteLine("Leaving Game");
            if (player1Points > player2Points)
            {
                System.Console.WriteLine("Player1 wins!");
            
            }
            else if(player2Points > player1Points)
            {
                System.Console.WriteLine("Player2 wins!");
            }
            else 
            {
                System.Console.WriteLine("WE HAVE A TIE!");
            }
        }


        // Returns and integer of the number of points were scored by pair of 4's
        public static int returnScore(Player player)
        {
            int score = 0;
            int[] pointCounter = new int[13];

            // Loop through all player's cards
            for(int y = player.numOfCardsInHand() - 1; y >= 0 ; y--)
            {
                // Get the cards val for the players hand
                int cardval = player.getListObject()[y].val;

                // add to array counter 1 for the card's value
                pointCounter[cardval - 1]++;

                // if the array counter is equal to 4
                if(pointCounter[cardval - 1] == 4)
                {
                    // Add 1 point to player
                    score++;

                    // Remove from the player's hand all vals that contain 4 of them.
                    player.getListObject().RemoveAll(u => u.val.ToString().Equals(cardval.ToString()));
                }
            }
            return score;
        }

        //System.Threading.Thread.Sleep(5000); AI
        //int RandomNum = rand.Next(1,14); 
        //while random != player2.getListObject()
        //Check if random is the number in player2's hand
        public static void playersTurn(Player player1, Player player2, int score, Deck deck)
        {
            System.Console.Write("Showing " + player1.name + "'s hand: ");
            System.Console.WriteLine(player1);
            string guess = "";
            bool winning = true;
            while(winning)
            {
                score += returnScore(player1);
                System.Console.WriteLine("Your current score is :" + score);
                System.Console.WriteLine("Please make a guess of these numbers: " + player1.shownumber());
                System.Console.WriteLine("Player 2: " + player2.shownumber());
                System.Console.WriteLine("FIRST LOOP");
                guess = Console.ReadLine();
                for(int i = 0; i < player1.getListObject().Count; i++)
                {  
                    if(player1.getListObject()[i].val.ToString().Equals(guess))
                    {
                        winning = false;
                        if(player1.numOfCardsInHand() == 0)
                        {
                            player1.DrawFromDeck(deck, 5);
                        }
                        if(player2.numOfCardsInHand() == 0)
                        {
                            player2.DrawFromDeck(deck, 5);
                        }
                    }
                }
            }
            bool correctone = false;
            bool newguess = true;
            var correctguess = player2.checkCardNum(guess);
            
            bool inCorrect = false;



            if (correctguess.Key){
                correctone = true;
                player1.addToList(correctguess.Value);
                int guessToNum = Int32.Parse(guess); 
                score += returnScore(player1); 
                while((correctguess.Key && newguess == true) || inCorrect) 
                {
                    if(player1.numOfCardsInHand() == 0)
                    {
                        player1.DrawFromDeck(deck, 5);
                    }
                    if(player2.numOfCardsInHand() == 0)
                    {
                        player2.DrawFromDeck(deck, 5);
                    }
                    if(player2.getListObject().Count == 0 || player1.getListObject().Count == 0)
                    {
                        break;
                    }
                    inCorrect = false;
                    newguess = false;
                    
                    
                    System.Console.WriteLine("");
                    System.Console.WriteLine("Your current score is :" + score);
                    System.Console.WriteLine("SECOND LOOP");

                    System.Console.WriteLine("Please make a guess of these numbers: " + player1.shownumber());
                    System.Console.WriteLine("Player 2                            : " + player2.shownumber());
                    guess = Console.ReadLine();

                    int countCards = 0;
                    for(int i = 0; i < player1.getListObject().Count; i++)
                    {
                        if  (player1.getListObject()[i].val.ToString().Equals(guess))
                        {
                            System.Console.WriteLine("Player is holding this card!!!");
                            countCards++;
                            if(player2.getListObject().Except(player1.getListObject()).Any())
                            {
                                newguess = false;
                                inCorrect = false;
                                System.Console.WriteLine("Counter to -10!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                                //countCards = -10;
                                break;
                            }
                            correctguess = player2.checkCardNum(guess);
                            player1.addToList(correctguess.Value);
                            score += returnScore(player1); 
                            newguess = true; 
                            inCorrect = false;
                        }
                        else
                        {
                            inCorrect = true;
                        }
                    }
                    if(countCards > 0)
                    {
                        inCorrect = true;
                        correctguess = player2.checkCardNum(guess);
                        player1.addToList(correctguess.Value);
                        score += returnScore(player1); 
                        System.Console.WriteLine("GETEGERGERGERGERGERGERGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG");
                    }
                }
                System.Console.WriteLine("Dont draw new card!");
            }
            else if(!correctone)
            {
                if(deck.getCardCount() != 0)
                {
                    System.Console.WriteLine("Draw New Card!");
                    player1.DrawFromDeck(deck, 1);
                    System.Console.WriteLine("You just drew this card: " + player1.getListObject().Last());
                }
                else
                {
                    System.Console.WriteLine("Sad day the deck is empty :(");
                }
            }
        }
        public static void LOL()
        {
            string[] lines = System.IO.File.ReadAllLines(@"daniela.txt");
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
        }
    }
}
