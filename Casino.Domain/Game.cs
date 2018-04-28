using System.Collections.Generic;

namespace Casino.Domain
{
    public enum GameStatus
    {
        Win, Lose, CannotPlay
    }
    public class Game
    {
        public Players Player { get; set; }
        public SlotMachine GameSlotMachine { get; set; }
        public int MoneyMultiplier { get; set; }
        public GameStatus Status { get; set; }
        public int WinAmount { get; set; }
        public int RoundCount { get; set; }

        public Game()
        {
            Player = new Players();
            GameSlotMachine = new SlotMachine(3);
            this.MoneyMultiplier = 0;
            this.Status = GameStatus.Lose;
            this.RoundCount = 0;
            Casino.Data.DataCollector.ClearDatabase();
        }

        private void DetermineGameMoneyMultiplier()
        {
            int[] ReelsImageIndex = new int[this.GameSlotMachine.ReelsNumber];
            ReelsImageIndex = GetReelsFaceIndex();

            if (IsBarAvailable(ReelsImageIndex))
            {
                this.MoneyMultiplier = 0;
                return;
            }

            if (AreAllSeven(ReelsImageIndex))
            {
                this.MoneyMultiplier = 100;
                return;
            }

            int numOfCherries = NumberOfCherries(ReelsImageIndex);

            this.MoneyMultiplier = (numOfCherries == 0) ? 0 : numOfCherries + 1;

        }

        private int[] GetReelsFaceIndex()
        {
            int[] result = new int[this.GameSlotMachine.ReelsNumber];
            for (int i = 0; i < this.GameSlotMachine.ReelsNumber; i++)
            {
                result[i] = this.GameSlotMachine.ReelsOfMachine[i].Face.SymbolIndex;
            }
            return result;
        }

        private bool IsBarAvailable(int[] array)
        {
            foreach (var item in array)
            {
                if (item == 0)
                    return true;
            }
            return false;
        }

        private bool AreAllSeven(int[] array)
        {
            foreach (var item in array)
            {
                if (item != 9)
                    return false;
            }
            return true;
        }

        private int NumberOfCherries(int[] array)
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item == 2)
                    count++;
            }
            return count;
        }

        private void UpdateGameStatus()
        {
            if (this.MoneyMultiplier == 0)
            {
                this.Status = GameStatus.Lose;
                this.Player.Lose();
            }
            else
            {
                this.Status = GameStatus.Win;
                this.Player.Win(this.MoneyMultiplier);
            }
        }

        public void PlayRound(int newBet)
        {
            this.UpdatePlayerBet(newBet);
            this.RoundCount++;

            if (this.CanPlayerPlay() && this.IsBetAboveLimit())
            {
                this.GameSlotMachine.LeverPulled();
                this.DetermineGameMoneyMultiplier();
                this.WinAmount = this.MoneyMultiplier * this.Player.Bet;
                this.UpdateGameStatus();
            }
            else
                this.Status = GameStatus.CannotPlay;
            this.UpdateDatabase();
        }

        private void UpdatePlayerBet(int newBet)
        {
            this.Player.Bet = newBet;
        }

        private bool CanPlayerPlay()
        {
            if (this.Player.Bet > this.Player.Pot || this.Player.Pot <= 0)
                return false;
            else
                return true;
        }

        private bool IsBetAboveLimit()
        {
            if (this.Player.Bet >= 2)
                return true;
            else
                return false;
        }

        public static List<Casino.DTO.CasinoTable> GetDatabase()
        {
            List<Casino.DTO.CasinoTable> gameTable = Casino.Data.DataCollector.GetDatabase();
            return gameTable;
        }

        private void UpdateDatabase()
        {
            Casino.Data.DataCollector.AddToDatabase(BuildDataTransferObject());
        }

        private Casino.DTO.CasinoTable BuildDataTransferObject()
        {
            Casino.DTO.CasinoTable dataRow = new DTO.CasinoTable();

            dataRow.RoundId = this.RoundCount;
            dataRow.Pot = this.Player.Pot;
            dataRow.Bet = this.Player.Bet;
            dataRow.Reel1Symbol = this.GameSlotMachine.ReelsOfMachine[0].Face.symbolName;
            dataRow.Reel2Symbol = this.GameSlotMachine.ReelsOfMachine[1].Face.symbolName;
            dataRow.Reel3Symbol = this.GameSlotMachine.ReelsOfMachine[2].Face.symbolName;
            dataRow.Status = this.Status.ToString();

            return dataRow;
        }

        public void Refill()
        {
            this.Player.Pot += 100;
        }

    }
}
