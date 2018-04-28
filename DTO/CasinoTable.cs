using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DTO
{
    public class CasinoTable
    {
        public int RoundID { get; set; }
        public int Pot { get; set; }
        public int Bet { get; set; }
        public string Reel1Symbol { get; set; }
        public string Reel2Symbol { get; set; }
        public string Reel3Symbol { get; set; }
        public string Status { get; set; }
    }
}
