using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supa_pong
{
    public partial class Form1 : Form
    {
        Board board;
        Paddle playerPaddle;
        Paddle computerPaddle;
        Ball ball;
        int points = 0;
        double frameTime;
        public Form1()
        {
            InitializeComponent();

            InitializeGameObjects();
            frameTime = 0.004d;
            timerFrame.Interval = (int)(frameTime * 1000);
            timerFrame.Start();
        }

        private void InitializeGameObjects()
        {
            board = new Board((200d, 100d));
            ball = new Ball((board.Size.x / 2, board.Size.y / 2), (10d, 10d), (1d, 0.8d), 300d);
            playerPaddle = new Paddle((0d, 0d), (10d, 40d), (0d, 0d), 200d);
            computerPaddle = new Paddle((board.Size.x - 10d, 0d), (10d, 40d), (0d, 0d), 130d);
        }

        private void timerFrame_Tick(object sender, EventArgs e)
        {
            ball.Update(frameTime);
            playerPaddle.Update(frameTime);
            computerPaddle.UpdateDirectionForComputer(ball);
            computerPaddle.Update(frameTime);

            if(board.checkBall(ball))
            {
                if (ball.Position.x <= 0)
                    points -= 1;
                else
                    points += 1;
                InitializeGameObjects();
                return;
            }
            board.checkPaddle(playerPaddle);
            board.checkPaddle(computerPaddle);
            ball.checkForPaddleCollision(playerPaddle);
            ball.checkForPaddleCollision(computerPaddle);

            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            double reduceFactorX = pictureBox1.Width / board.Size.x;
            double reduceFactorY = pictureBox1.Height / board.Size.y;
            double reduceFactor = reduceFactorX > reduceFactorY ? reduceFactorY : reduceFactorX;

            Pen penBlack = new Pen(Color.Black, 1);
            Rectangle rectBoard = new Rectangle(0, 0, (int)(board.Size.x * reduceFactor), (int)(board.Size.y * reduceFactor));
            e.Graphics.FillRectangle(penBlack.Brush, rectBoard);
            penBlack.Dispose();

            Pen penYellow = new Pen(Color.Yellow, 1);
            Rectangle rectBall = new Rectangle((int)(ball.Position.x * reduceFactor), (int)(ball.Position.y * reduceFactor), (int)(ball.Size.x * reduceFactor), (int)(ball.Size.y * reduceFactor));
            e.Graphics.FillRectangle(penYellow.Brush, rectBall);
            penYellow.Dispose();

            Pen penBlue = new Pen(Color.Blue, 1);
            Rectangle rectPlayerPaddle = new Rectangle((int)(playerPaddle.Position.x * reduceFactor), (int)(playerPaddle.Position.y * reduceFactor), (int)(playerPaddle.Size.x * reduceFactor), (int)(playerPaddle.Size.y * reduceFactor));
            e.Graphics.FillRectangle(penBlue.Brush, rectPlayerPaddle);

            Rectangle rectComputerPaddle = new Rectangle((int)(computerPaddle.Position.x * reduceFactor), (int)(computerPaddle.Position.y * reduceFactor), (int)(computerPaddle.Size.x * reduceFactor), (int)(computerPaddle.Size.y * reduceFactor));
            e.Graphics.FillRectangle(penBlue.Brush, rectComputerPaddle);
            penBlue.Dispose();

            Pen penWhite = new Pen(Color.White, 1);
            Font font = new Font(FontFamily.GenericMonospace, 24f);
            string pointsS = points.ToString();
            e.Graphics.DrawString(pointsS, font, penWhite.Brush, (float)(board.Size.x * reduceFactor / 2), 0f);
            penWhite.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                playerPaddle.Direction = (0d, 1d);
            }
            else if (e.KeyCode == Keys.W)
            {
                playerPaddle.Direction = (0d, -1d);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.W)
            {
                playerPaddle.Direction = (0d, 0d);
            }
        }
    }
}
