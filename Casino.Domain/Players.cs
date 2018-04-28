using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Domain
{
    public class Players
    {
        public string Name { get; set; }
        public int Pot { get; set; }
        public int Bet { get; set; }
        public int Wins { get; set; }

        public Players()
        {
            this.Name = "Player Name";
            this.Pot = 100;
            this.Bet = 5;
            this.Wins = 0;
        }

        public void Lose()
        {
            this.Pot -= this.Bet;
        }

        public void Win(int multiplier)
        {
            this.Pot += this.Bet * multiplier;
            this.Wins++;
        }
    }
}
