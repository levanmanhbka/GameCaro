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
            chessBoardManager.DrawChessBoard();

            socketManager = new SocketManager();
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
    }
}
