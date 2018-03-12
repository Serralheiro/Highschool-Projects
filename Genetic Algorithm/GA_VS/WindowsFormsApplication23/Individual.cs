using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication23
{
    enum Gene { Left, Right, Up, Down, Stop };

    class Individual : IComparable
    {
        //location
        public Gene[] DNA { get; set; }
        public double fitness { get; set; }
        private static Random rnd;
        static Individual()
        {
            rnd = new Random();
        }

        public Individual(Gene[] DNA) {
            this.DNA = DNA;
        }

        public Individual(int minGenomeSize, int maxGenomeSize)
        {

            int genomeSize = rnd.Next(minGenomeSize, maxGenomeSize + 1);
            DNA = new Gene[genomeSize];

            for (int i = 0; i < genomeSize; i++)
            {
                int c = rnd.Next(1, 5);
                switch (c)
                {
                    case 1:
                        DNA[i] = Gene.Down;
                        break;
                    case 2:
                        DNA[i] = Gene.Left;
                        break;
                    case 3:
                        DNA[i] = Gene.Right;
                        break;
                    case 4:
                        DNA[i] = Gene.Up;
                        break;
                    case 5:
                        DNA[i] = Gene.Stop;
                        break;
                }
            }
        }

        public void evaluate(Labirinto labirinto)
        {
            //First pos 
            Point position = labirinto.Entry;

            //get DNA
            for (int i = 0; i < DNA.Length; i++)
            {
                switch (DNA[i])
                {
                    case Gene.Left:
                        if (position.Y == 0) break;
                        if (labirinto.grid[position.X, position.Y - 1] == 0) break;
                        position.Y--; break;

                    case Gene.Right:
                        if (position.Y == labirinto.Width - 1) break;
                        if (labirinto.grid[position.X, position.Y + 1] == 0) break;
                        position.Y++; break;

                    case Gene.Up:
                        if (position.X == 0) break;
                        if (labirinto.grid[position.X - 1, position.Y] == 0) break;
                        position.X--; break;

                    case Gene.Down:
                        if (position.X == labirinto.Height - 1) break;
                        if (labirinto.grid[position.X + 1, position.Y] == 0) break;
                        position.X++; break;

                }
            }
            double distance = Math.Sqrt(Math.Pow(labirinto.Exit.X - position.X, 2) 
                + (Math.Pow(labirinto.Exit.Y - position.Y, 2)));          
            fitness = 1 / distance;
        }

        public void mutate()
        {
            if (DNA.Length == 0) return;

            int geneposition = rnd.Next(0, DNA.Length);
            int anothergene = rnd.Next(0, 5);

            switch (anothergene)
            {
                case 0:
                    this.DNA[geneposition] = Gene.Left;
                    break;
                case 1:
                    this.DNA[geneposition] = Gene.Right;
                    break;
                case 2:
                    this.DNA[geneposition] = Gene.Up;
                    break;
                case 3:
                    this.DNA[geneposition] = Gene.Down;
                    break;
                case 4:
                    this.DNA[geneposition] = Gene.Stop;
                    break;
            }
        }
        public Individual[] cross(Individual ind)
        {
            int thisBreakPoint = rnd.Next(1, this.DNA.Length + 1);
            int indBreakPoint = rnd.Next(1, ind.DNA.Length + 1);

            Gene[] indA1B2 = this.DNA.Take(thisBreakPoint + 1).Concat(ind.DNA.Skip(indBreakPoint)).ToArray();
            Gene[] indA2B1 = ind.DNA.Take(thisBreakPoint + 1).Concat(this.DNA.Skip(indBreakPoint)).ToArray();

            return new Individual[] { new Individual(indA1B2), new Individual(indA2B1)};
            
        }
        public int CompareTo(object obj)
        {
            Individual other = obj as Individual;

            if (this.fitness > other.fitness) return -1;
            if (this.fitness < other.fitness) return 1;
            return 0;

        }
    }
}
