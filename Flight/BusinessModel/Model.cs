using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.BusinessModel
{
    public class Model
    {
        const double dt = 0.1;
        double k;
        double t;

        public Body body;
        public Environment environment;

        public Model(Body body, Environment environment)
        {
            this.body = body;
            this.environment = environment;
        }

        public void ThrowBody()
        {
            k = 0.5 * environment.C * body.S * environment.rho / body.m;
            body.vx = body.v0 * Math.Cos(body.a * Math.PI / 180);
            body.vy = body.v0 * Math.Sin(body.a * Math.PI / 180);
            t = 0;
            body.x = 0;
            body.y = body.y0;
        }

        public bool NextTick()
        {
            t += dt;
            body.vx = body.vx - k * body.vx * Math.Sqrt(body.vx * body.vx + body.vy * body.vy) * dt;
            body.vy = body.vy - (environment.g + k * body.vy * Math.Sqrt(body.vx * body.vx + body.vy * body.vy)) * dt;

            body.x = body.x + body.vx * dt;
            body.y = body.y + body.vy * dt;

            if (body.y <= 0) return false;

            return true;
        }
    }
}
