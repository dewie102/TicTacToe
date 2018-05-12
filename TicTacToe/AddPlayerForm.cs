using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe {
    public partial class AddPlayerForm : Form {

        public int changePlayer; // Indicates which player to add/ change, 1 or 2
        private Player newPlayer; // Temporary player to manipulate until finished

        public AddPlayerForm() {
            InitializeComponent();
        }

        private void ResetForm() {
            // Clear Text
            txtPlayerName.Clear();

            // Re-enable button and reset color
            btnX.Enabled = true;
            btnX.BackColor = SystemColors.Control;

            // Re-enable button and reset color
            btnO.Enabled = true;
            btnO.BackColor = SystemColors.Control;

            // Reset temporary player variable
            newPlayer.PlayerName = "";
            newPlayer.PlayerNumber = 0;
            newPlayer.PlayerSymbol = Player.PlayerPieces.A;
        }

        private void btnX_Click(object sender, EventArgs e) {
            btnX.BackColor = SystemColors.ActiveCaption; // Highlight button X blue
            btnO.BackColor = SystemColors.Control; // Change button O back to default
            newPlayer.PlayerSymbol = Player.PlayerPieces.X;
        }

        private void btnO_Click(object sender, EventArgs e) {
            btnO.BackColor = SystemColors.ActiveCaption; // Highlight button O blue
            btnX.BackColor = SystemColors.Control; // Change button O back to default
            newPlayer.PlayerSymbol = Player.PlayerPieces.O;

        }

        private void btnOkay_Click(object sender, EventArgs e) {
            if(txtPlayerName.Text != "") {
                newPlayer.PlayerName = txtPlayerName.Text;

                if(newPlayer.PlayerSymbol != Player.PlayerPieces.A) {
                    if(changePlayer == 1) {
                        GameData.player1 = newPlayer;
                        GameData.player1.PlayerNumber = 1;
                    } else if (changePlayer == 2) {
                        GameData.player2 = newPlayer;
                        GameData.player2.PlayerNumber = 2;
                    }

                    this.ResetForm();
                    this.Close();
                } else {
                    MessageBox.Show("Please select a symbol.", "Symbol not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
            } else {
                MessageBox.Show("Please type a name.", "Name not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.ResetForm();
            this.Close();
        }
    }
}
