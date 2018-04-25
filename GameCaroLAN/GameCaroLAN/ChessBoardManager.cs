using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaroLAN
{
    class ChessBoardManager
    {
        #region Porperties
        private Panel chessBoard;
        private List<Player> players;
        public List<Player> Players { get => players; set => players = value; }
        
        private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        
        private TextBox playerName;
        public TextBox PlayerName { get => playerName; set => playerName = value; }
        
        private PictureBox playerMark;
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }

        #endregion;

        #region Initialize
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox mark)
        {
            this.chessBoard = chessBoard;
            this.Players = new List<Player>()
            {
                new Player("ManhThang", Image.FromFile(Application.StartupPath + "\\Resources\\o.png")),
                new Player("VanManh", Image.FromFile(Application.StartupPath + "\\Resources\\x.png"))
            };
            this.PlayerName = playerName;
            this.PlayerMark = mark;

            CurrentPlayer = 0;
            ChangePlayer();
        }

        
        #endregion



        #region Methods
        public void DrawChessBoard()
        {
            Button oldButton = new Button()
            {
                Width = 0,
                Height = 0,
                Location = new Point(0, 0)
            };

            for (int i = 0; i < Cons.CHESS_BOARD_ROWS; i++)
            {
                for (int j = 0; j < Cons.CHESS_BOARD_COLS; j++)
                {
                    Button button = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    button.Click += Button_Click;

                    chessBoard.Controls.Add(button);
                    oldButton = button;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.BackgroundImage != null)
            {
                return;
            }

            Mark(button);
            ChangePlayer();

            
        }

        private void Mark(Button button)
        {
            button.BackgroundImage = Players[CurrentPlayer].Mark;

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
        }

        private void ChangePlayer()
        {
            PlayerName.Text = Players[CurrentPlayer].Name;

            PlayerMark.Image = Players[CurrentPlayer].Mark;
        }
        #endregion
    }
}
