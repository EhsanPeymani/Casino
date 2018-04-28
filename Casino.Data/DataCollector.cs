using System.Collections.Generic;
using System.Linq;

namespace Casino.Data
{
    public class DataCollector
    {
        public static List<Casino.DTO.CasinoTable> GetDatabase()
        {
            GameDatabaseEntities db = new GameDatabaseEntities();
            var dbTable = db.CasinoTables.ToList();

            List<Casino.DTO.CasinoTable> dtoTable = new List<DTO.CasinoTable>();

            foreach (var dbData in dbTable)
            {
                var dtoData = new Casino.DTO.CasinoTable();

                dtoData.Bet = dbData.Bet;
                dtoData.Pot = dbData.Pot;
                dtoData.Reel1Symbol = dbData.Reel1Symbol;
                dtoData.Reel2Symbol = dbData.Reel2Symbol;
                dtoData.Reel3Symbol = dbData.Reel3Symbol;
                dtoData.RoundId = dbData.RoundID;
                dtoData.Status = dbData.Status;

                dtoTable.Add(dtoData);
            }

            return dtoTable;

        }

        public static void AddToDatabase(DTO.CasinoTable newDataRow)
        {
            GameDatabaseEntities db = new GameDatabaseEntities();
            var dbTable = db.CasinoTables;

            Data.CasinoTable dbData = new Data.CasinoTable();

            dbData.RoundID = newDataRow.RoundId;
            dbData.Pot = newDataRow.Pot;
            dbData.Bet = newDataRow.Bet;
            dbData.Reel1Symbol = newDataRow.Reel1Symbol;
            dbData.Reel2Symbol = newDataRow.Reel2Symbol;
            dbData.Reel3Symbol = newDataRow.Reel3Symbol;
            dbData.Status = newDataRow.Status;

            dbTable.Add(dbData);
            db.SaveChanges();            
        }

        public static void ClearDatabase()
        {
            GameDatabaseEntities db = new GameDatabaseEntities();
            var dbTable = db.CasinoTables;

            dbTable.RemoveRange(dbTable.Where(p => p.RoundID != -1));

            /*
            foreach (var item in dbTable)
            {
                dbTable.Remove(item);
            }
            */
            db.SaveChanges();
        }
    }
}
