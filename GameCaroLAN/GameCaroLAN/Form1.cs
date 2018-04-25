using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaroLAN
{
    public partial class Form1 : Form
    {
        #region Porperties
        ChessBoardManager chessBoardManager;
        #endregion
        public Form1()
        {
            InitializeComponent();

            chessBoardManager = new ChessBoardManager(panelChessBoad, textBoxName, pictureBoxMark);
            chessBoardManager.DrawChessBoard();
        }

        private void buttonLan_Click(object sender, EventArgs e)
        {

        }
    }
}
