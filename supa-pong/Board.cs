using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supa_pong
{
    public class Board
    {
        public (double x, double y) Size { get; set; }
        public Board((double x, double y) size)
        {
            Size = size;
        }
        public bool checkBall(Ball ball)
        {
            if (ball.Position.y < 0d)
            {
                ball.Direction = (ball.Direction.x, -ball.Direction.y);
                ball.Position = (ball.Position.x, 0);
                ball.AddVelocity();
            }
            else if (ball.Position.y + ball.Size.y >= Size.y)
            {
                ball.Direction = (ball.Direction.x, -ball.Direction.y);
                ball.Position = (ball.Position.x, Size.y - ball.Size.y);
                ball.AddVelocity();
            }
            if (ball.Position.x < 0d)
            {
                ball.Direction = (-ball.Direction.x, ball.Direction.y);
                ball.Position = (0, ball.Position.y);
                return true;
            }
            else if (ball.Position.x + ball.Size.x >= Size.x)
            {
                ball.Direction = (-ball.Direction.x, ball.Direction.y);
                ball.Position = (Size.x - ball.Size.x, ball.Position.y);
                return true;
            }
            return false;
        }

        public void checkPaddle(Paddle paddle)
        {
            if (paddle.Position.y < 0d)
            {
                paddle.Position = (paddle.Position.x, 0);
            }
            else if (paddle.Position.y + paddle.Size.y >= Size.y)
            {
                paddle.Position = (paddle.Position.x, Size.y - paddle.Size.y);
            }
        }
    }
}
