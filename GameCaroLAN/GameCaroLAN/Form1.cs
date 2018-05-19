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

            Control.CheckForIllegalCrossThreadCalls = false;

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
                socketManager.isServer = true;
                panelChessBoad.Enabled = true;
                socketManager.CreateServer();
                //Thread listernThread = new Thread(() =>
                //{
                //    while (true)
                //    {
                //        try
                //        {
                //            Listern();
                //            break;
                //        }
                //        catch
                //        {

                //        }
                //        Thread.Sleep(10);
                //    }
                //});
                //listernThread.IsBackground = true;
                //listernThread.Start();
            }
            else
            {
                socketManager.isServer = false;
                panelChessBoad.Enabled = false;
                Listern();

                //socketManager.Send(new SocketData((int) SocketCommand.NOTIFY, "Client đã kết nối"));
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
            Thread listernThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        SocketData data = (SocketData)socketManager.Receive();
                        ProcessData(data);
                        //break;
                    }
                    catch (Exception e)
                    {

                    }
                    Thread.Sleep(10);
                }
            });
            listernThread.IsBackground = true;
            listernThread.Start();
            

            //MessageBox.Show(data);
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    //MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() => {
                        progressBarCoolDown.Value = 0;
                        panelChessBoad.Enabled = true;
                        tmCoolDown.Start();
                        chessBoardManager.OtherPlayerMark(data.Point);
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    break;
                case (int)SocketCommand.END_GAME:
                    break;
                case (int)SocketCommand.QUIT:
                    break;
                default:
                    break;
            }

            Listern();
        }

        void NewGame()
        {
            //stop process bar
            progressBarCoolDown.Value = 0;
            tmCoolDown.Stop();
            undoToolStripMenuItem.Enabled = true;
            chessBoardManager.DrawChessBoard();
        }

        void EndGame()
        {
            tmCoolDown.Stop();
            panelChessBoad.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            MessageBox.Show("Kết thúc game");
        }

        void Quit()
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                Application.Exit();
        }

        void Undo()
        {
            chessBoardManager.Undo();
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

        
        private void ChessBoard_PlayerMarked(object sender, ButtonClickEvent e)
        {
            tmCoolDown.Start();
            panelChessBoad.Enabled = false;
            progressBarCoolDown.Value = 0;

            socketManager.Send(new SocketData((int)SocketCommand.SEND_POINT,"" ,e.ClickedPoint));

            Listern();
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
