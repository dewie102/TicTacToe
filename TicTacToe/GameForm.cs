using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe {
    public partial class GameForm : Form {
        private Player currPlayer;
        private char[] gameBoard = new char[9];
        private GroupBox gameBoardGB;
        private int numOfTurns = 0;

        private char[] gamePieces = { ' ', 'X', 'O' };

        private int[,] winningConditions = new int[,]
            { { 0, 1, 2 },
              { 3, 4, 5 },
              { 6, 7, 8 },
              { 0, 3, 6 },
              { 1, 4, 7 },
              { 2, 5, 8 },
              { 0, 4, 8 },
              { 2, 4, 6 } };

        public GameForm() {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e) {
            currPlayer = GameData.player1;
            lblPlayer1.Text += $"\n{GameData.player1.PlayerName}";
            lblPlayer2.Text += $"\n{GameData.player2.PlayerName}";
            gameBoardGB = this.Controls["gpbxGameBoard"] as GroupBox;
            ResetGameBoard();
        }

        private void lbl0_Click(object sender, EventArgs e) {
            if (CheckProperMove(0)) {
                MarkBoard(0, "lbl0");
                if (CheckForWinningCondition()) {
                    ShowEndForm(currPlayer.PlayerName);
                }

                ChangeTurns();
            }
        }

        private void lbl1_Click(object sender, EventArgs e) {
            if (CheckProperMove(1)) {
                MarkBoard(1, "lbl1");
                if (CheckForWinningCondition()) {
                    ShowEndForm(currPlayer.PlayerName);
                }

                ChangeTurns();
            }
        }

        private void lbl2_Click(object sender, EventArgs e) {
            if (CheckProperMove(2)) {
                MarkBoard(2, "lbl2");
                if (CheckForWinningCondition()) {
                    ShowEndForm(currPlayer.PlayerName);
                }

                ChangeTurns();
            }
        }

        private void lbl3_Click(object sender, EventArgs e) {
            if (CheckProperMove(3)) {
                MarkBoard(3, "lbl3");
                if (CheckForWinningCondition()) {
                    ShowEndForm(currPlayer.PlayerName);
                }

                ChangeTurns();
            }
        }

        private void lbl4_Click(object sender, EventArgs e) {
            if (CheckProperMove(4)) {
                MarkBoard(4, "lbl4");
                if (CheckForWinningCondition()) {
                    ShowEndForm(currPlayer.PlayerName);
                }

                ChangeTurns();
            }
        }

        private void lbl5_Click(object sender, EventArgs e) {
            if (CheckProperMove(5)) {
                MarkBoard(5, "lbl5");
                if (CheckForWinningCondition()) {
                    ShowEndForm(currPlayer.PlayerName);
                }

                ChangeTurns();
            }
        }

        private void lbl6_Click(object sender, EventArgs e) {
            if (CheckProperMove(6)) {
                MarkBoard(6, "lbl6");
                if (CheckForWinningCondition()) {
                    ShowEndForm(currPlayer.PlayerName);
                }

                ChangeTurns();
            }
        }

        private void lbl7_Click(object sender, EventArgs e) {
            if (CheckProperMove(7)) {
                MarkBoard(7, "lbl7");
                if (CheckForWinningCondition()) {
                    ShowEndForm(currPlayer.PlayerName);
                }

                ChangeTurns();
            }
        }

        private void lbl8_Click(object sender, EventArgs e) {
            if (CheckProperMove(8)) {
                MarkBoard(8, "lbl8");
                if (CheckForWinningCondition()) {
                    ShowEndForm(currPlayer.PlayerName);
                }

                ChangeTurns();
            }
        }

        private void ResetGameBoard() {
            var gameLabels = GetAllControls(gameBoardGB, typeof(Label));

            foreach (Label lbl in gameLabels) {
                lbl.Text = "";
            }

            for (int i = 0; i < gameBoard.Length; i++) {
                gameBoard[i] = '\0';
            }

            DisplayCurrPlayer();
        }

        private bool CheckProperMove(int Index) {
            if (gameBoard[Index] != 'X' && gameBoard[Index] != 'O') {
                return true;
            }

            return false;
        }

        private void MarkBoard(int index, string labelName) {
            if (index < gameBoard.Length) {
                char symbol = gamePieces[(int)currPlayer.PlayerSymbol];
                gameBoard[index] = symbol; // Change data map to proper symbol
                gameBoardGB.Controls[labelName].Text = symbol.ToString(); // Change graphical map to proper symbol
            }
        }

        private void ChangeTurns() {
            if (currPlayer == GameData.player1) {
                currPlayer = GameData.player2;
            } else if (currPlayer == GameData.player2) {
                currPlayer = GameData.player1;
            }

            DisplayCurrPlayer();
        }

        private void DisplayCurrPlayer() {
            if (currPlayer == GameData.player1) {
                lblPlayer2.BackColor = SystemColors.Control;
                lblPlayer1.BackColor = SystemColors.ActiveCaption;
            } else if (currPlayer == GameData.player2) {
                lblPlayer1.BackColor = SystemColors.Control;
                lblPlayer2.BackColor = SystemColors.ActiveCaption;
            }
        }

        private bool CheckForWinningCondition() {
            var result = false;
            var matchSymbol = gamePieces[(int)currPlayer.PlayerSymbol];
            var matchCount = 0;

            numOfTurns++;

            for (int r = 0; r <= winningConditions.GetUpperBound(0); r++) {
                for (int c = 0; c <= winningConditions.GetUpperBound(1); c++) {
                    if (gameBoard[winningConditions[r, c]] == matchSymbol) {
                        if (++matchCount == 3) {
                            result = true;
                            break;
                        }
                    }
                }
                matchCount = 0;
            }

            if (numOfTurns == 9 && result == false) {
                ShowEndForm("", result);
            }

            return result;
        }

        private void ShowEndForm(string WinnerName, bool Winner = true) {
            GameData.endGame = new EndGameForm(WinnerName, Winner);
            GameData.endGame.Show();
            this.Hide();
        }

        public IEnumerable<Control> GetAllControls(Control control, Type type) {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }
    }
}
