using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame.Models
{
    internal class Player
    {
        public string PlayerName { get; set; }
        public int TotalScore { get; set; }

        // Constructor For Initializing Player
        
        public Player(string playerName)
        {
            PlayerName = playerName;
            TotalScore = 0;
        }
    }
}
