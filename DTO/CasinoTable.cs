namespace Casino.DTO
{
    public class CasinoTable
    {
        public int RoundId { get; set; }
        public int Pot { get; set; }
        public int Bet { get; set; }
        public string Reel1Symbol { get; set; }
        public string Reel2Symbol { get; set; }
        public string Reel3Symbol { get; set; }
        public string Status { get; set; }
    }
}
