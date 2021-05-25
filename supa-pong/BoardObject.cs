using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supa_pong
{
    public abstract class BoardObject
    {
        public double Velocity { get; set; } //units per second
        public (double x, double y) Position { get; set; }
        public (double x, double y) Size { get; set; }
        public (double x, double y) Direction { get; set; }
        public BoardObject((double x, double y) position, (double x, double y) size, (double x, double y) direction, double velocity = 1d)
        {
            Position = position;
            Size = size;
            Direction = direction;
            Velocity = velocity;
        }
        public virtual void Update(double timeElapsed)
        {
            Position = (Position.x + Velocity * Direction.x * timeElapsed, Position.y + Velocity * Direction.y * timeElapsed);
        }
    }
}
