<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Casino.Presentation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style.css" rel="stylesheet" type="text/css" />
    <title>Play Your Chance</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div style="width: 45%; display: inline; float: left">
                <h2>
                    <asp:Image ID="Reel0" runat="server" Height="150px" Width="150px" AlternateText="No Image Set" />
                    <asp:Image ID="Reel1" runat="server" Height="150px" Width="150px" AlternateText="No Image Set" />
                    <asp:Image ID="Reel2" runat="server" Height="150px" Width="150px" AlternateText="No Image Set" />
                </h2>
            </div>
            <div style="width: 45%; display: inline; float: right; background-color: blanchedalmond; padding-left: 15px; border: solid; border-radius: 15px 0px 15px 0px; margin: auto;">
                <h2>Game Rules</h2>
                <div style="position: center">
                    <ul style="list-style-type: circle">
                        <li>You get one cherry:  You win x2 your bet.</li>
                        <li>You get two cherries:  You win x3 your bet.</li>
                        <li>You get three cherries:  You win x4 your bet.</li>
                        <li style="list-style-type: georgian">You get three 7's:  It is jackpot and you win x100 your win.</li>
                        <li style="list-style-type: square">If you ever get one BAR:  You win nothing.</li>
                        <li>Minimum bet is $2.0.</li>
                    </ul>
                </div>
            </div>
        </div>

        <hr style="clear: both" />
        <div class="wrapper">
            <div style="width: 50%; float: left; display:inline">
                <h4 style="width: 40%; display: inline; margin-right: 20px;">Your Bet:
            <asp:TextBox ID="betTextBox" runat="server" Text="" Width="65px"></asp:TextBox>
                </h4>
                <h4 style="width: 40%; display: inline">Player&#39;s Money
            <asp:Label ID="playersMoneyLabel" runat="server" Text=""></asp:Label>
                </h4>
                <h2>
                    <asp:Button ID="leverButton" runat="server" Text="Pull the Lever!" OnClick="leverButton_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="refillButton" runat="server" OnClick="refillButton_Click" Text="Refill $100.0" />
                </h2>
                <p>
                    <asp:Label ID="resultLabel" runat="server" Text=""></asp:Label>
                </p>
            </div>
            
            <div style="width:55%; display:inline">
                <asp:Button ID="showDBButton" runat="server" Text="Get Database" OnClick="showDBButton_Click" />
                <p>&nbsp;</p>
                <asp:GridView ID="dbGridView" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
            </div>
        </div>
        <hr style="clear: both" />
    </form>
</body>
</html>
