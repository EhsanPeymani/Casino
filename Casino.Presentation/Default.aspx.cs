using System;
using System.Globalization;

namespace Casino.Presentation
{
    public partial class Default : System.Web.UI.Page
    {
        Domain.Game casinoGame;
        public CultureInfo USA = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                casinoGame = new Domain.Game();
                Session["Game"] = casinoGame;

                betTextBox.Text = casinoGame.Player.Bet.ToString("c", USA);
                playersMoneyLabel.Text = casinoGame.Player.Pot.ToString("c", USA);

                DisplayReelImages();

                dbGridView.Visible = false;
            }
        }

        protected void leverButton_Click(object sender, EventArgs e)
        {
            casinoGame = (Domain.Game) Session["Game"];
            dbGridView.Visible = false;
            betTextBox.Text = Display.FormatBet((int)double.Parse(betTextBox.Text, NumberStyles.Currency, USA), USA);
            casinoGame.PlayRound((int)double.Parse(betTextBox.Text, NumberStyles.Currency, USA));
            //Display.UpdateDatabase(casinoGame);
            DisplayReelImages();
            resultLabel.Text = Display.DisplayResult(casinoGame, USA) + "<br>" + resultLabel.Text;
            playersMoneyLabel.Text = casinoGame.Player.Pot.ToString("c", USA);
            Session["Game"] = casinoGame;
        }

        private void DisplayReelImages()
        {
            Reel0.ImageUrl = casinoGame.GameSlotMachine.ReelsOfMachine[0].Face.SymbolUrl;
            Reel1.ImageUrl = casinoGame.GameSlotMachine.ReelsOfMachine[1].Face.SymbolUrl;
            Reel2.ImageUrl = casinoGame.GameSlotMachine.ReelsOfMachine[2].Face.SymbolUrl;
        }

        protected void showDBButton_Click(object sender, EventArgs e)
        {
            var gameTableList = Casino.Domain.Game.GetDatabase();
            dbGridView.Visible = true;
            dbGridView.DataSource = gameTableList;
            dbGridView.DataBind();
        }

        protected void refillButton_Click(object sender, EventArgs e)
        {
            casinoGame = (Domain.Game)Session["Game"];
            casinoGame.Refill();
            playersMoneyLabel.Text = casinoGame.Player.Pot.ToString("c", USA);
            Session["Game"] = casinoGame;
        }
    }
}