namespace TicTacToe {
    public struct Player {
        public enum PlayerPieces {A = 0, X, O };

        private int playerNumber;
        private string playerName;
        private PlayerPieces playerSymbol;

        public string PlayerName {
            get { return playerName; }
            set { playerName = value; }
        }

        public PlayerPieces PlayerSymbol {
            get { return playerSymbol; }
            set { playerSymbol = value; }
        }

        public int PlayerNumber {
            get { return playerNumber; }
            set { playerNumber = value; }
        }

        public override bool Equals(object obj) {
            return obj is Player && this == (Player)obj;
        }

        public override int GetHashCode() {
            return PlayerName.GetHashCode() ^ playerNumber.GetHashCode() ^
                    playerSymbol.GetHashCode();
        }

        public static bool operator ==(Player x, Player y) {
            return x.playerName == y.playerName && x.playerNumber == y.playerNumber &&
                    x.playerSymbol == y.playerSymbol;
        }

        public static bool operator !=(Player x, Player y) {
            return !(x == y);
        }
    }
}
