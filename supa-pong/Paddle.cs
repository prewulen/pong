using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supa_pong
{
    public class Paddle : BoardObject
    {
        public Paddle((double x, double y) position, (double x, double y) size, (double x, double y) direction, double velocity = 1d) : base(position, size, direction, velocity)
        {
            
        }
        public void UpdateDirectionForComputer(Ball ball)
        {
            if (ball.Position.y + ball.Size.y / 2 > Position.y + Size.y / 2)
            {
                Direction = (Direction.x, 1);
            }
            else
            {
                Direction = (Direction.x, -1);
            }
        }
    }
}
