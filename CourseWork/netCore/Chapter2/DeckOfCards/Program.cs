using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            System.Console.WriteLine("Ready to play Go Fish?");
            bool gameOn = true;
            System.Console.WriteLine("Please enter in a name player1!");
            string player1Name = Console.ReadLine();
            Player player1 = new Player(player1Name);
            System.Console.WriteLine("Please enter in a name player2!");
            string player2Name = Console.ReadLine();
            Player player2 = new Player(player2Name);
            int player1Points = 0;
            int player2Points = 0;
            
            Deck newDeck= new Deck();
            
            newDeck.Shuffle();

            player1.DrawFromDeck(newDeck, 5);
            System.Console.WriteLine(player1);

            player2.DrawFromDeck(newDeck, 5);
            System.Console.WriteLine(player2);

            System.Console.WriteLine(newDeck.getCardCount());


            while(gameOn)
            {
                System.Console.WriteLine("Please enter command ('Player1','Player2','Quit')");
                string gameStatus = Console.ReadLine();

                if(player1.numOfCardsInHand() == 0)
                {
                    player1.DrawFromDeck(newDeck, 5);
                }

                if(player2.numOfCardsInHand() == 0)
                {
                    player2.DrawFromDeck(newDeck, 5);
                }



                int[] pointfor1 = new int[13] {0,0,0,0,0,0,0,0,0,0,0,0,0};

                for(int y = player1.numOfCardsInHand()-1; y >= 0 ; y--)
                {
                    for(int i = 1; i < 13; i++)
                    {
                        if(player1.getListObject()[y].val == i)
                        {
                            pointfor1[i - 1] += 1;
                        }
                    }
                    for(int i = 1; i <= 13; i++)
                    {
                        if(pointfor1[i - 1] == 4)
                        {
                            player1Points++;
                        }
                    }
                }

                int[] pointfor2 = new int[13] {0,0,0,0,0,0,0,0,0,0,0,0,0};

                for(int y = player2.numOfCardsInHand()-1; y >= 0 ; y--)
                {
                    for(int i = 1; i < 13; i++)
                    {
                        if(player2.getListObject()[y].val == i)
                        {
                            pointfor2[i - 1] += 1;
                        }
                    }
                    for(int i = 1; i <= 13; i++)
                    {
                        if(pointfor2[i - 1] == 4)
                        {
                            player2Points++;
                        }
                    }
                }
               

                switch(gameStatus)
                {
                    case "Player1":
                        System.Console.Write("Showing " + player1.name + "'s hand: ");
                        System.Console.WriteLine(player1);
                        string guess = "";
                        bool winning = true;
                        while(winning)
                        {
                            System.Console.WriteLine("Please make a guess of these numbers: " + player1.shownumber());
                            System.Console.WriteLine("Player 2: " + player2.shownumber());
                            guess = Console.ReadLine();
                            System.Console.WriteLine("winning true");
                            for(int i = 0; i < player1.getListObject().Count; i++)
                            {  
                                if(player1.getListObject()[i].val.ToString().Equals(guess))
                                {
                                    winning = false;

                                }
                            }
                        }
                        bool correctone = false;
                        bool newguess = true;
                        var correctguess = player2.checkCardNum(guess);
                        if (correctguess.Key){
                            correctone = true;
                            while(correctguess.Key && newguess == true )
                            {
                                newguess = false;
                                player1.addToList(correctguess.Value); 
                                System.Console.WriteLine("");
                                System.Console.WriteLine("Total Num of Cards: " + newDeck.getCardCount());
                                System.Console.WriteLine("Player2 had this card: " + guess);

                                System.Console.WriteLine("Please make a guess of these numbers: " + player1.shownumber());
                                System.Console.WriteLine("Player 2: " + player2.shownumber());
                                guess = Console.ReadLine();

                                for(int i = 0; i < player1.getListObject().Count; i++)
                                {
                                    if  (player1.getListObject()[i].val.ToString().Equals(guess))
                                    {
                                        correctguess = player2.checkCardNum(guess);    
                                    }
                                }
                            }
                            System.Console.WriteLine("Dont draw new card!");
                        }
                        else if(!correctone)
                        {
                            System.Console.WriteLine("Draw New Card!");
                            player1.DrawFromDeck(newDeck, 1);
                        }
                        break;

                    case "Player2":
                        System.Console.Write("Showing " + player2.name + "'s hand: ");
                        System.Console.WriteLine(player2);

                        string guess2 = "";
                        bool winning2 = true;
                        while(winning2)
                        {
                          
                            System.Console.WriteLine("Please make a guess of these numbers: " + player2.shownumber());
                            System.Console.WriteLine("Player 1: " + player1.shownumber());
                            guess2 = Console.ReadLine();
                            System.Console.WriteLine("winning true");
                            for(int i = 0; i < player2.getListObject().Count; i++)
                            {  
                                System.Console.WriteLine(i);
                                System.Console.WriteLine(player2.getListObject().Count - 1);
                                if  (player2.getListObject()[i].val.ToString().Equals(guess2))
                                {
                                    winning2 = false;

                                }
                            }
                        }
                        bool correctone2 = false;
                        bool newguess2 = true;
                        var correctguess2 = player1.checkCardNum(guess2);
                        if (correctguess2.Key){
                            correctone2 = true;
                            while(correctguess2.Key && newguess2 == true )
                            {
                                newguess2 = false;
                                player2.addToList(correctguess2.Value); 
                                System.Console.WriteLine("");
                                System.Console.WriteLine("Total Num of Cards: " + newDeck.getCardCount());
                                System.Console.WriteLine("Player1 had this card: " + guess2);

                                System.Console.WriteLine("Please make a guess of these numbers: " + player2.shownumber());
                                System.Console.WriteLine("Player 1: " + player1.shownumber());
                                guess2 = Console.ReadLine();

                                for(int i = 0; i < player2.getListObject().Count; i++)
                                {
                                    if(player2.getListObject()[i].val.ToString().Equals(guess2))
                                    {
                                        correctguess2 = player1.checkCardNum(guess2);   
                                    }
                                }
                            }
                            System.Console.WriteLine("Dont draw new card!");
                        }
                        else if(!correctone2)
                        {
                            System.Console.WriteLine("Draw New Card!");
                            player2.DrawFromDeck(newDeck, 1);
                        }
                        break;

                    case "Quit":
                        gameOn = false;
                        int thing = 1;
                        foreach(var score in pointfor1)
                        {
                            System.Console.WriteLine(player1.name + " Here is a score for " + thing + " : " + score);
                            thing++;
                        }
                        int thing2 = 1;
                        foreach(var score in pointfor2)
                        {
                            System.Console.WriteLine(player2.name + " Here is a score for " + thing2 + " : " + score);
                            thing2++;
                        }
                        break;
                    
                    default:
                        System.Console.WriteLine("Not valid command");
                        break;
                }
            }
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
    }
}
