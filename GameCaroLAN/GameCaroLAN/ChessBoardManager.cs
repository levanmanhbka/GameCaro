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
        #endregion;
        
        #region Initialize
        public ChessBoardManager(Panel chessBoard)
        {
            this.chessBoard = chessBoard;
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
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y)
                    };
                    chessBoard.Controls.Add(button);
                    oldButton = button;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }
        #endregion
    }
}
