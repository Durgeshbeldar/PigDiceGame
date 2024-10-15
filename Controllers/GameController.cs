using PigDiceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame.Controllers
{
    // Game Controller class to control the game functionalities...
    
    internal class GameController
    {
        public Player Player {  get; set; }
        public int CurrentTurnScore {  get; set; }
        public bool IsActive { get; set; }
        const int MIN = 1;
        const int MAX = 7;
        const int tagetPoints = 20;
        public GameController(Player player) { 
            Player = player;
            CurrentTurnScore = 0;
            IsActive = true;
        }


        // Logic for Rolling the Dice...
        
        public string RollTheDice()
        {
            // Player is rolling the dice...
            
            Random random = new Random();
            int diceResult = random.Next(MIN, MAX);
            if (diceResult == MIN) 
            {
                CurrentTurnScore = 0;
                IsActive = false;
                return "\nOhh :( | Dice Result is : 1. No points for this turn!\n";
            }
            CurrentTurnScore = CurrentTurnScore + diceResult;
            return $"\nGreat...! :) | Dice Result is : {diceResult}\nYour Current Score is : {CurrentTurnScore}";
        }


        // The function Executed when user choose to hold the current turn
        
        public string Hold()
        {
            Player.TotalScore = Player.TotalScore + CurrentTurnScore;
            IsActive = false ;
            return $"You Hold the Score...!" +
                $"\nYour Total Score Now : {Player.TotalScore}";
        }


        // Return weather player Won or not ...
        
        public bool IsWon()
        {
            return (Player.TotalScore >= tagetPoints);
        }

    }
}
