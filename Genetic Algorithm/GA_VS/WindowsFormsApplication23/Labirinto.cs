using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication23
{
    class Labirinto
    {
        //para a delimitação
        public int Width{ get; set; }
        public int Height{ get; set; }
        public Point Entry { get; set; }
        public Point Exit { get; set; }

        //array
        public int[,] grid{ get; set; }

        public Labirinto(int[,]labirinto, Point entry, Point exit)
        {
            grid = labirinto;
            Width = labirinto.GetLength(1);
            Height = labirinto.GetLength(0);
            Entry = entry;
            Exit = exit; 

        }
        public void draw(Panel panel, PictureBox[,]pictures) {
            //DRAW LABIRINTO
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(20, 20);
                    pb.Location = new Point(j * 20, i * 20);


                    switch (this.grid[i, j])
                    {
                        case 0: pb.BackColor = Color.Black; break;
                        case 1: pb.BackColor = Color.White; break;
                        case 2: pb.BackColor = Color.Blue; break;
                        case 3: pb.BackColor = Color.Red; break;
                    }

                    pictures[i, j] = pb;
                    panel.Controls.Add(pb);

                }
            }
        }

        public void redraw(Panel panel, PictureBox[,] pictures)
        {
            //DRAW LABIRINTO
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    switch (this.grid[i, j])
                    {
                        case 0: pictures[i, j].BackColor = Color.Black; break;
                        case 1: pictures[i, j].BackColor = Color.White; break;
                        case 2: pictures[i, j].BackColor = Color.Blue; break;
                        case 3: pictures[i, j].BackColor = Color.Red; break;
                    }
                }
            }
        }

    }
}
