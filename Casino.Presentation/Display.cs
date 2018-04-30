using Casino.Domain;
using System.Globalization;

namespace Casino.Presentation
{
    public class Display
    {
        public static string DisplayResult(Game game, CultureInfo cultur)
        {
            string result = string.Empty;

            switch (game.Status)
            {
                case GameStatus.Win:
                    result = string.Format("You bet {0} and won {1}!", 
                        game.Player.Bet.ToString("c", cultur), 
                        game.WinAmount.ToString("c", cultur));
                    break;
                case GameStatus.Lose:
                    result = string.Format("Sorry, you lost {0}. Better luck next time.", 
                        game.Player.Bet.ToString("c", cultur));
                    break;
                case GameStatus.CannotPlay:
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