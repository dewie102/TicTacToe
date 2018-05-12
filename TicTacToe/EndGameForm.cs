using System;
using System.Windows.Forms;

namespace TicTacToe {
    public partial class EndGameForm : Form {
        private string winnerName;
        private bool winner;

        public EndGameForm(string WinnerName, bool Winner = true) {
            InitializeComponent();
            this.winnerName = WinnerName;
            this.winner = Winner;
        }

        private void EndGameForm_Load(object sender, EventArgs e) {
            if(winner) {
                lblWinner.Text = $"{winnerName} is the Winner!";
            } else {
                lblWinner.Text = "There were no winners.";
            }
        }

        private void btnRestart_Click(object sender, EventArgs e) {
            GameData.gameForm = new GameForm();
            GameData.gameForm.Show();
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
