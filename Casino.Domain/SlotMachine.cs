using System;

namespace Casino.Domain
{
    public class SlotMachine
    {
        public Random RndSlotMachine { get; set; }
        public int ReelsNumber { get; set; }
        public Reels[] ReelsOfMachine { get; set; }

        public SlotMachine(int numberOfReels)
        {
            this.RndSlotMachine = new Random();
            this.ReelsNumber = numberOfReels;
            this.ReelsOfMachine = new Reels[numberOfReels];

            for (int i = 0; i < numberOfReels; i++)
            {
                this.ReelsOfMachine[i] = new Reels(this.RndSlotMachine.Next(12));
            }
        }

        public void LeverPulled()
        {
            for (int i = 0; i < this.ReelsNumber; i++)
            {
                // we have 12 possibility for each reel. It is hard coded.
                // the better solution is to have it as a variable in userSettings in web.config
                ReelsOfMachine[i] = new Reels(this.RndSlotMachine.Next(12));
            }
        }
    }
}
