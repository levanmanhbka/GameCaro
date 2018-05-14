using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaroLAN
{
    public partial class Form1 : Form
    {
        #region Porperties
        SocketManager socketManager;
        ChessBoardManager chessBoardManager;
        #endregion
        public Form1()
        {
            InitializeComponent();

            chessBoardManager = new ChessBoardManager(panelChessBoad, textBoxName, pictureBoxMark);

            chessBoardManager.EndedGame += ChessBoard_EndedGame;
            chessBoardManager.PlayerMarked += ChessBoard_PlayerMarked;

            progressBarCoolDown.Step = Cons.COOL_DOWN_STEP;
            progressBarCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            progressBarCoolDown.Value = 0;

            tmCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;

            NewGame();

            socketManager = new SocketManager();

            //tmCoolDown.Start();
        }

        private void buttonLan_Click(object sender, EventArgs e)
        {
            socketManager.IP = textBoxIP.Text;
            if (socketManager.ConnectServer() == false)
            {
                socketManager.CreateServer();
                Thread listernThread = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            Listern();

                        }
                        catch
                        {

                        }
                        Thread.Sleep(10);
                    }
                });
                listernThread.IsBackground = true;
                listernThread.Start();
            }
            else
            {
                socketManager.Send("Thong tin client");
                Thread listernThread = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            Listern();
                            break;
                        }
                        catch
                        {

                        }
                        Thread.Sleep(10);
                    }
                });
                listernThread.IsBackground = true;
                listernThread.Start();
            }

        }

        private void Form1_Show(object sender, EventArgs e)
        {
            textBoxIP.Text = socketManager.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(textBoxIP.Text))
            {
                textBoxIP.Text = socketManager.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        private void Listern()
        {
            String data = (String)socketManager.Receive();
            MessageBox.Show(data);
        }

        void NewGame()
        {
            //stop process bar
            chessBoardManager.DrawChessBoard();
        }

        void EndGame()
        {
            tmCoolDown.Stop();
            panelChessBoad.Enabled = false;
            MessageBox.Show("Kết thúc game");
        }

        void Quit()
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                Application.Exit();
        }

        void Undo()
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;

        }

        
        private void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            tmCoolDown.Start();
            progressBarCoolDown.Value = 0;
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            progressBarCoolDown.PerformStep();

            if (progressBarCoolDown.Value >= progressBarCoolDown.Maximum)
            {
                EndGame();
            }
        }
    }
}
