using System.Collections.Generic;

namespace Casino.Domain
{
    public class Reels
    {
        public Dictionary<int, string> Symbols { get; set; }
        public ReelFaceUp Face { get; set; }

        public Reels(int faceUpIndex)
        {
            SymbolsInitialization();
            this.Face = new ReelFaceUp(faceUpIndex, Symbols[faceUpIndex]);
        }

        private void SymbolsInitialization()
        {
            this.Symbols = new Dictionary<int, string>();

            this.Symbols[0] = "Bar";
            this.Symbols[1] = "Bell";
            this.Symbols[2] = "Cherry";
            this.Symbols[3] = "Clover";
            this.Symbols[4] = "Diamond";
            this.Symbols[5] = "HorseShoe";
            this.Symbols[6] = "Lemon";
            this.Symbols[7] = "Orange";
            this.Symbols[8] = "Plum";
            this.Symbols[9] = "Seven";
            this.Symbols[10] = "Strawberry";
            this.Symbols[11] = "Watermellon";
        }
    }
}
