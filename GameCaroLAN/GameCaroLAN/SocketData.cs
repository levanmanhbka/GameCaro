using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaroLAN
{
    class SocketData
    {
        private int command;

        public int Command
        {
            get { return command; }
            set { command = value; }
        }

        private Point? point;

        public Point? Point
        {
            get { return point; }
            set { point = value; }
        }

        private String message;

        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        public SocketData(int command, String message, Point? point = null)
        {
            this.command = command;
            this.message = message;
            this.point = point;
        }
    }

    public enum SocketCommand
    {
        NOTIFI,
        SEND_POINT,
        NEW_GAME,
        UNDO,
        QUIT
    }
}
