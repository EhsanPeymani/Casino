using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ReelsOfMachine[i] = new Reels(this.RndSlotMachine.Next(12));
            }
        }

        public void LeverPulled()
        {
            for (int i = 0; i < this.ReelsNumber; i++)
            {
                ReelsOfMachine[i] = new Reels(this.RndSlotMachine.Next(12));
            }
        }
    }
}
