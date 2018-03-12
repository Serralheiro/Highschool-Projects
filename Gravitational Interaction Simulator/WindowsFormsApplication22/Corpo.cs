using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace WindowsFormsApplication22
{

    class AstronomicalObject
    {

        // Physical properties
        public double Mass { get; set; }
        public Vector2D SpacialLocation { get; set; }
        public Vector2D Velocity { get; set; }
        public Vector2D Acceleration { get; set; }
        public Brush Brush { get; set; }
        public int DrawingRadius { get; set; }
        public List<Vector2D> Trajectory = new List<Vector2D>();

        //Desenhos
        public void DrawV(Graphics g)
        {
            // Desenho do corpo
            g.FillEllipse(Brush,
                (int)SpacialLocation.X - DrawingRadius,
                (int)SpacialLocation.Y - DrawingRadius,
                2 * DrawingRadius,
                2 * DrawingRadius);
            //
            //Desenho do vetor velocidade 
            Pen vectorV = new Pen(Color.ForestGreen, 4);
            vectorV.EndCap = LineCap.ArrowAnchor;
            Point Vi = new Point((int)SpacialLocation.X, (int)SpacialLocation.Y);
            Point Vf = new Point(Vi.X + ((int)Velocity.X) / 10, Vi.Y + ((int)Velocity.Y) / 10);
            g.DrawLine(vectorV, Vi, Vf);
            //
            //Desenho do vetor aceleração 
            Pen vectorA = new Pen(Color.Red, 4);
            vectorA.EndCap = LineCap.ArrowAnchor;
            Point Ai = new Point((int)SpacialLocation.X, (int)SpacialLocation.Y);
            Point Af = new Point(Ai.X + ((int)Acceleration.X) / 100, Ai.Y + ((int)Acceleration.Y) / 100);
            g.DrawLine(vectorA, Ai, Af);
        }

        public void Movimento(double t){
            //código do movimento
            double elapsed = t / 1000;
            Velocity.X += Acceleration.X * elapsed;
            Velocity.Y += Acceleration.Y * elapsed;
            SpacialLocation.X += Velocity.X * elapsed;
            SpacialLocation.Y += Velocity.Y * elapsed;
        }

        public void DrawSV(Graphics g)
        {
            //desenho dos corpos 
            g.FillEllipse(Brush,
               (int)SpacialLocation.X - DrawingRadius,
               (int)SpacialLocation.Y - DrawingRadius,
               2 * DrawingRadius,
               2 * DrawingRadius);
        }

        public void DrawTraj(Graphics g)
        {
            //condição inicial da trajetória
            if (Trajectory.Count < 2) return;
            //
            //código de desenho da trajetória
            Point[] points = new Point[Trajectory.Count];
            for (int i = 0; i < Trajectory.Count; i++)
            {
                points[i] = new Point((int)Trajectory[i].X, (int)Trajectory[i].Y);
            }
            Pen p = new Pen(Color.Black, 2);
            g.DrawLines(p, points);
        }

        

        }

    }



