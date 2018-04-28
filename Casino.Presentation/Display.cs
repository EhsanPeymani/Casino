using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Casino.Presentation
{
    public class Display
    {
        public static string DisplayResult(Domain.Game game, CultureInfo cultur)
        {
            string result = string.Empty;

            switch (game.Status)
            {
                case Domain.GameStatus.Win:
                    result = string.Format("You bet {0} and won {1}!", 
                        game.Player.Bet.ToString("c", cultur), 
                        game.WinAmount.ToString("c", cultur));
                    break;
                case Domain.GameStatus.Lose:
                    result = string.Format("Sorry, you lost {0}. Better luck next time.", game.Player.Bet.ToString("c", cultur));
                    break;
                case Domain.GameStatus.CannotPlay:
                    result = string.Format("You cannot play.");
                    break;
                default:
                    break;
            }
            return result;
        }

        public static string FormatBet(int bet, CultureInfo cultur)
        {
            return string.Format(cultur, "{0:C}", bet);
        }

    }
}