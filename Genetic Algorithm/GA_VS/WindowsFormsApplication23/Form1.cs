using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication23
{

    public partial class FormGA : System.Windows.Forms.Form
    {
        int generationnumb = 0;
        int PopulationSize = 10;
        int genomesize = 0;
        bool stop = false;
        int step = 0;
        int PSelec = 70;
        int PCross = 30;
        int PMutate = 1;

        Individual[] population;
        PictureBox[,] pictures;
        Labirinto labirinto;
       
        private static Random rnd;

        static FormGA()
        {
            rnd = new Random();
        }

        public FormGA()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            genomesize = Convert.ToInt16(textBoxPopulation.Text);
            PopulationSize = Convert.ToInt16(textBoxPopulation.Text);
            labelGeneration.Text = Convert.ToString(generationnumb);
            PSelec = Convert.ToInt16(textBoxCrossover.Text);
            PMutate = Convert.ToInt16(textBoxMutation.Text);
            step = Convert.ToInt16(textBoxStep.Text);


            //int[,] l = {
            //    //------------------------------------------------->y
            //    {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},//|
            //    {0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//|
            //    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},//|
            //    {0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//|
            //    {0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//|
            //    {0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//|
            //    {0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//|
            //    {0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//|
            //    {0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},//|
            //    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},//V
            //    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,3},//x

            //};
            //int[,] l = {
            //    //------------------------------------------------->y
            //    {0,0,0,2,0,0,0,0,0,},
            //    {0,1,1,1,0,0,0,0,0,},
            //    {0,1,0,1,0,0,0,0,0,},
            //    {0,1,0,1,1,1,1,1,0,},
            //    {0,1,0,0,0,0,1,0,0,},
            //    {0,1,0,1,1,1,1,1,0,},
            //    {0,0,0,0,1,0,0,0,0,},
            //    {0,1,1,1,1,0,0,0,0,},
            //    {0,0,0,0,3,0,0,0,0,},
            //};
            /*int[,] l = {
                    {0,0,0,2,0},
                    {0,1,1,1,0},
                    {0,1,0,0,0},
                    {0,1,1,1,0},
                    {0,0,0,3,0}


                };*/
            int[,] l = {
                //------------------------------------------------->y
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
              {2,1,1,1,1,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,0,},
              {0,1,0,0,0,0,0,0,0,1,0,1,0,0,0,1,0,0,0,0,0,},
              {0,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,0,},
              {0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,},
              {0,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,0,},
              {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,},
              {0,1,0,1,0,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,0,},
              {0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,1,0,0,0,1,0,},
              {0,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,0,},
              {0,1,0,1,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,},
              {0,1,0,1,1,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,0,},
              {0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,1,0,},
              {0,1,1,1,0,1,0,1,1,1,1,1,0,1,1,1,1,1,0,1,0,},
              {0,0,0,0,0,1,0,1,0,0,0,1,0,1,0,0,0,0,0,1,0,},
              {0,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,0,1,0,1,0,},
              {0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,},
              {0,1,0,1,0,1,1,1,0,1,1,1,1,1,1,1,0,1,1,1,0,},
              {0,1,0,0,0,0,0,0,0,1,0,1,0,0,0,1,0,0,0,1,0,},
              {0,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,1,1,1,3,},
              {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},

            };
            //labirinto = new Labirinto(l, new Point(0,3), new Point(4,3));
            //labirinto = new Labirinto(l, new Point(0, 4), new Point(4, 8));
            labirinto = new Labirinto(l, new Point(1, 0), new Point(20, 21));

            pictures = new PictureBox[labirinto.Height, labirinto.Width];
            population = new Individual[PopulationSize];
            
            panel1.Width = labirinto.Width*20;
            panel1.Height= labirinto.Height*20;

            labirinto.draw(panel1, pictures);
            
        }
        private void evolute()
        {
            //checkstep
            int rest = 0;
            rest = generationnumb % step;
            if (rest == 0)//Stop 
                stop = true;
            //dar continuidade à geração
            if (generationnumb == 0)
            {
                population = InitPopulation();
                generationnumb++;
                labelGeneration.Text = Convert.ToString(generationnumb);
            }
            else
            {
                generationnumb++;
                labelGeneration.Text = Convert.ToString(generationnumb);
            }

            FitnessEvalAndRanking(population);

            //representação gráfica
            DrawBestPlayer(population, pictures);

            //evolution
            population = Selection(population);
            population = Crossover(population);
            Mutation(population);
        }
        private void DrawBestPlayer(Individual[] pop, PictureBox[,] pictures)
        {
            labirinto.redraw(panel1, pictures);
            //First pos 
            Point position = labirinto.Entry;

            pictures[position.X, position.Y].BackColor = Color.Magenta;

            SuspendLayout();

            //get DNA
            for (int i = 0; i < pop[0].DNA.Length; i++)
            {
                switch (pop[0].DNA[i])
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
                
                pictures[position.X, position.Y].BackColor = Color.Magenta;

            }

            ResumeLayout();
        }

        private void radioButtonElement_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonPath_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void reset()
        {
            generationnumb = 0;
            population = new Individual[PopulationSize];
            evolute();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            evolute();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            stop = false;
            if (buttonContinue.Text.Equals("Stop")) stop = true;
            if (!stop)
            {
                buttonContinue.Text = "Stop";
                while (!stop)
                {
                    evolute();
                    //checkforstop
                    if (stop) buttonContinue.Text = "Continue";
                }
            }
            else buttonContinue.Text = "Continue";


        }

        Individual[] InitPopulation()
        {
            int MinGenomeSize = Convert.ToInt16(textBoxMinGenome.Text);
            int MaxGenomeSize = Convert.ToInt16(textBoxMaxGenome.Text);
            //reset population
            population = new Individual[PopulationSize];
            for (int i = 0; i < population.Length; i++)
            {
                Individual p = new Individual(MinGenomeSize, MaxGenomeSize);
                population[i] = p;
            }
            return population;
        }

        void FitnessEvalAndRanking(Individual[] pop)
        {
            foreach (Individual ind in pop)
                ind.evaluate(labirinto);

            Array.Sort(pop);
        }

        Individual[] Selection(Individual[] population)
        {
            Individual[] popselected = new Individual[PopulationSize];

            //ciclo que vai selecionar a próxima pop baseada no ranking
            for (int i = 0; i < popselected.Length; i++)
            {
                for (int j = 0; j < population.Length; j++)
                {
                    float prob = rnd.Next(0, 101);
                    if (prob < PSelec)
                    {
                        popselected[i] = population[j];
                        break;
                    }
                }
                if (popselected[i] == null) popselected[i] = population[population.Length - 1];


            }
            return popselected;
        }

        Individual[] Crossover(Individual[] matingPool)
        {
            List<Individual> mutationpool = new List<Individual>();
            Individual firstcross = null;
            foreach (Individual ind in matingPool)
            {
                //checkforcross
                float prob = rnd.Next(0, 101);

                if (prob < PCross)
                {
                    //check if some individual is in standby
                    if (firstcross == null)
                        firstcross = ind;

                    //cross
                    else
                    {
                        Individual[] results = firstcross.cross(ind);

                        //add results to pool
                        foreach (Individual i in results)
                        {
                            mutationpool.Add(i);
                        }
                        //reset firstcross
                        firstcross = null;
                    }
                }
                else
                    mutationpool.Add(ind);
            }
            return mutationpool.ToArray();
        }

        void Mutation(Individual[] pop)
        {
            foreach (Individual ind in pop)
            {
                float prob = rnd.Next(0, 101);
                if (prob <= PMutate) ind.mutate();
            }
        }

        private void textBoxStep_TextChanged(object sender, EventArgs e)
        {
            if (textBoxStep.Text == "") return;
            step = Convert.ToInt16(textBoxStep.Text);
            evolute();

        }

        private void textBoxPopulation_TextChanged(object sender, EventArgs e)
        {
            //reset PopulationSize
            PopulationSize = Convert.ToInt16(textBoxPopulation.Text);

            reset();
        }

        private void textBoxCrossover_TextChanged(object sender, EventArgs e)
        {
            PCross = Convert.ToInt16(textBoxCrossover);
            reset();
        }

        private void textBoxMutation_TextChanged(object sender, EventArgs e)
        {
            PMutate = Convert.ToInt16(textBoxMutation.Text);
            reset();
        }

        private void textBoxMinGenome_TextChanged(object sender, EventArgs e)
        {
            reset();
        }

        private void textBoxMaxGenome_TextChanged(object sender, EventArgs e)
        {
            reset();
        }
    }
}

