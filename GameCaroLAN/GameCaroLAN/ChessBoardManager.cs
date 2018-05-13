﻿using System;
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

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }


        private int currentPlayer;

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        private TextBox playerName;

        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        private PictureBox playerMark;

        public PictureBox PlayerMark
        {
            get { return playerMark; }
            set { playerMark = value; }
        }


        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

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
        }


        #endregion



        #region Methods
        public void DrawChessBoard()
        {
            chessBoard.Enabled = true;
            chessBoard.Controls.Clear();
            CurrentPlayer = 0;
            ChangePlayer();

            Matrix = new List<List<Button>>();

            Button oldButton = new Button()
            {
                Width = 0,
                Height = 0,
                Location = new Point(0, 0)
            };

            for (int i = 0; i < Cons.CHESS_BOARD_ROWS; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.CHESS_BOARD_COLS; j++)
                {
                    Button button = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    };

                    button.Click += Button_Click;
                    Matrix[i].Add(button);
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

            if (IsEndGame(button))
            {
                EndGame();
            }
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

        private bool IsEndGame(Button btn)
        {

            return IsEndHorizontal(btn)
                || IsEndVertical(btn)
                || IsEndPrimary(btn)
                || IsEndSub(btn);
        }

        private Point GetButtonPoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag.ToString());
            int horizontal = Matrix[vertical].IndexOf(btn);
            Point point = new Point(horizontal, vertical);
            return point;
        }

        private bool IsEndHorizontal(Button btn)
        {
            Point point = GetButtonPoint(btn);
            int countLeft = 0;
            int countRight = 0;

            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    countLeft++;
                else
                    break;
            }

            for (int i = point.X + 1; i < Cons.CHESS_BOARD_COLS; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    countRight++;
                else
                    break;
            }
            return countLeft + countRight >= 5;
        }

        private bool IsEndVertical(Button btn)
        {
            Point point = GetButtonPoint(btn);
            int countTop = 0;
            int countBotton = 0;

            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else
                    break;
            }

            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_ROWS; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                    countBotton++;
                else
                    break;
            }
            return countTop + countBotton >= 5;
        }

        private bool IsEndPrimary(Button btn)
        {
            Point point = GetButtonPoint(btn);
            int countTop = 0;
            int countBotton = 0;

            for (int i = 0; i <= point.X; i++)
            {
                if (point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else
                    break;

            }

            for (int i = 1; i < Cons.CHESS_BOARD_COLS - point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_ROWS)
                    break;
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    countBotton++;
                else
                    break;

            }

            return countTop + countBotton >= 5;
        }

        private bool IsEndSub(Button btn)
        {
            Point point = GetButtonPoint(btn);
            int countTop = 0;
            int countBotton = 0;

            for (int i = 0; i <= point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_ROWS)
                    break;
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                    countBotton++;
                else
                    break;

            }

            for (int i = 1; i < Cons.CHESS_BOARD_COLS - point.X; i++)
            {
                if (point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else
                    break;

            }

            return countTop + countBotton >= 5;
        }

        private void EndGame()
        {
            MessageBox.Show("Ket thuc");
        }
        #endregion
    }
}
