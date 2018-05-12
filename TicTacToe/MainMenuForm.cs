using System;
using System.Windows.Forms;

namespace TicTacToe {
    public partial class MainMenuForm : Form {

        GroupBox groupBoxControl;

        bool player1Added, player2Added = false;

        public MainMenuForm() {
            InitializeComponent();
            GameData.mainMenu = this;
            groupBoxControl = GameData.addPlayer.Controls["groupBox1"] as GroupBox;
        }

        private void btnPlayer1_Click(object sender, EventArgs e) {
            GameData.addPlayer.changePlayer = 1; // Set which player to change for the add player form to use

            if(!player1Added && player2Added) { // If player 2 has been selected and modified gray out player 2's symbol
                switch(GameData.player2.PlayerSymbol) {
                    case Player.PlayerPieces.X:
                        groupBoxControl.Controls["btnX"].Enabled = false;
                        break;
                    case Player.PlayerPieces.O:
                        groupBoxControl.Controls["btnO"].Enabled = false;
                        break;
                }
            } else if(player1Added) { // If player 1 has been selected, reset player 2 to allow changes in case it was previously set
                GameData.addPlayer.Controls["txtPlayerName"].Text = GameData.player1.PlayerName;
                groupBoxControl.Controls["btnX"].Enabled = true;
                groupBoxControl.Controls["btnO"].Enabled = true;
                GameData.player2.PlayerSymbol = Player.PlayerPieces.A;
                player2Added = false;
            }

            DialogResult result = GameData.addPlayer.ShowDialog();

            if(result == DialogResult.OK) {
                player1Added = true;
            } else {
                player1Added = false;
            }
        }

        private void btnPlayer2_Click(object sender, EventArgs e) {
            GameData.addPlayer.changePlayer = 2;

           if(!player2Added && player1Added) { // If player 1 has been selected and modified gray out player 1's symbol
                switch(GameData.player1.PlayerSymbol) {
                    case Player.PlayerPieces.X:
                        groupBoxControl.Controls["btnX"].Enabled = false;
                        break;
                    case Player.PlayerPieces.O:
                        groupBoxControl.Controls["btnO"].Enabled = false;
                        break;
                }
            } else if(player2Added) { // If player 1 has been selected, reset player 1 to allow changes in case it was previously set
                GameData.addPlayer.Controls["txtPlayerName"].Text = GameData.player2.PlayerName;
                groupBoxControl.Controls["btnX"].Enabled = true;
                groupBoxControl.Controls["btnO"].Enabled = true;
                GameData.player1.PlayerSymbol = Player.PlayerPieces.A;
                player1Added = false;
            }


            DialogResult result = GameData.addPlayer.ShowDialog();

            if(result == DialogResult.OK) {
                player2Added = true;
            } else {
                player2Added = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e) {
            if(player1Added && player2Added) {
                GameData.gameForm = new GameForm();
                GameData.gameForm.Show();
                this.Hide();
            } else {
                string playerNotSelected;
                playerNotSelected = (player1Added == true) ? "Player 2" : "Player 1";
                MessageBox.Show($"{playerNotSelected} is not has not been added or a player was modified.", $"{playerNotSelected} not added", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
