using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supa_pong
{
    public class Ball : BoardObject
    {
        private double MaxVelocity = 600d;
        public Ball((double x, double y) position, (double x, double y) size, (double x, double y) direction, double velocity = 1d) : base(position, size, direction, velocity)
        {

        }
        public void checkForPaddleCollision(Paddle paddle)
        {
            if ((paddle.Position.x <= Position.x + Size.x && Position.x <= paddle.Position.x + paddle.Size.x) &&
                (paddle.Position.y <= Position.y + Size.y && Position.y <= paddle.Position.y + paddle.Size.y))
            {
                if (paddle.Position.x == 0)
                    Direction = (1, Direction.y);
                else
                    Direction = (-1, Direction.y);
            }
        }

        public void AddVelocity(double velocityToAdd = 20d)
        {
            Velocity += velocityToAdd;
            if (Velocity > MaxVelocity)
                Velocity = MaxVelocity;
        }
    }
}
