using PigDiceGame.Controllers;
using PigDiceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame.Presentation
{
    internal class GameUI
    {
        static int INITIAL_TURN = 1;
        public static void PlayGame()
        {
            int turn = INITIAL_TURN;
            bool activeStatus = true;
            
            // Instructions to user ...
            
            GeneralInstructions();
            Console.Write("\nEnter your name: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            Console.WriteLine("Game Is Started...!");
           
            while (activeStatus) 
            {
                GameController gameController = new GameController(player);
                PlayYourTurn(gameController,player,turn);
                if (gameController.IsWon())
                {
                    activeStatus = false;
                    Console.WriteLine($"\nCongratulations {player.PlayerName}! You Won The Game in {turn} Turns,  " +
                             $"Your Total Score is :{player.TotalScore}");
                }
                ++turn;
            }
            
            //User wanted to Play Again or not..
            
            Console.WriteLine("\nDo You Want to Play Again? Press Yes OR No using (y/n):");
            string userChoice = Console.ReadLine().ToLower();
            HandleGameState(userChoice);
        }
        

        // To Get User Wanted to Play Again Or Not ...
        
        public static void HandleGameState(string userChoice)
        {
            if(userChoice == "y")
                PlayGame();
            Console.WriteLine("\n Successfully Exited...Thank You So Much For Playing ...!");
            return;
        }


        // Playing the Turn in Pig Dice Game ...

        public static void PlayYourTurn(GameController gameController,Player player,int turn)
        {
            while (gameController.IsActive)
            {
                Console.WriteLine($"\nPlayer Name : {player.PlayerName}" +
                    $"\nTotal Score: {player.TotalScore} | Turn is : {turn}");
                Console.WriteLine("\nChoose an action: ['R' for Roll Dice AND 'H' for Hold]");

                string userChoice = Console.ReadLine().ToLower();
                HandleUserOperation(gameController,player, userChoice);    
            }
        }

        // Handles the user Inputs..
        
        public static void HandleUserOperation(GameController gameController,Player player, string userChoice)
        {
            switch (userChoice)
            {
                case "r":
                    Console.WriteLine(gameController.RollTheDice());
                    break;
                case "h":
                    Console.WriteLine(gameController.Hold());
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please press 'R' to Roll or 'H' to Hold.");
                    break;
            }
        }


        // Instructions for the PIG DICE GAME....
        
        public static void GeneralInstructions()
        {
            Console.WriteLine($"*********** Welcome to the Pig Dice Game! ***********\n" +
              $"INSTRUCTIONS...\n" +
              $"1.Roll the dice to earn points.\n" +
              $"2.If you roll a 1, your current score for that " +
              $"turn will be 0 and won’t count towards your total score. " +
              $"Your turn will end.\n" +
              $"3.If you roll a 2 to 6, your points will be added to your current turn score. " +
              $"You can then choose to:\n" +
              $"  i.  Roll again to try and earn more points.\n" +
              $"  ii. Hold to keep the points you earned in this turn and add them to your total score.\n");
        }
    }
}
