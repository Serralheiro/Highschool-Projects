using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;


namespace WindowsFormsApplication22
{
    public partial class Simulador : Form
    {
        //constante da lista da trajétoria
        private const int N = 10000;

        // operational parameters
        const double MassScale = 1E16;

        // Criar dois objetos da classe AstronomicalObject
        AstronomicalObject oA = new AstronomicalObject();
        AstronomicalObject oB = new AstronomicalObject();

        //criar a variável do tempo
        double t = 0;

        Bitmap b;

        public Simulador()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //definição dos objetos a ser tratados
            oA.Brush = Brushes.Pink;
            oB.Brush = Brushes.LightBlue;
            oA.SpacialLocation = new Vector2D();
            oB.SpacialLocation = new Vector2D();
            oA.Velocity = new Vector2D();
            oB.Velocity = new Vector2D();
            oA.Acceleration = new Vector2D();
            oB.Acceleration = new Vector2D();
            //
            // Inicia-los com os valores preenchidos pelo utilizador
            oA.DrawingRadius = (int)Convert.ToDouble(textBoxMassaA.Text) / 10;
            oB.DrawingRadius = (int)Convert.ToDouble(textBoxMassaB.Text) / 10;
            oA.Mass = Convert.ToDouble(textBoxMassaA.Text) * MassScale;
            oB.Mass = Convert.ToDouble(textBoxMassaB.Text) * MassScale;
            oA.SpacialLocation.X = Convert.ToDouble(textBoxXoA.Text);
            oB.SpacialLocation.X = Convert.ToDouble(textBoxXoB.Text);
            oA.SpacialLocation.Y = Convert.ToDouble(textBoxYoA.Text);
            oB.SpacialLocation.Y = Convert.ToDouble(textBoxYoB.Text);
            oA.Velocity.X = Convert.ToDouble(textBoxVoxA.Text);
            oB.Velocity.X = Convert.ToDouble(textBoxVoxB.Text);
            oA.Velocity.Y = Convert.ToDouble(textBoxVoyA.Text);
            oB.Velocity.Y = Convert.ToDouble(textBoxVoyB.Text);
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            if (this.t > 0)
            {
                this.t = 0;
            }
            //uma espécie de clear
            pictureBox1.Image = null;
            //condição universal para proteger o bitmap
            if (pictureBox1.Image == null)
                b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            else
                b = new Bitmap(pictureBox1.Image);
            ////limpar o panel
            //g.Clear(panelSimulação.BackColor); 

            //definição dos objetos a ser tratados
            oA.Brush = Brushes.Pink;
            oB.Brush = Brushes.LightBlue;
            oA.SpacialLocation = new Vector2D();
            oB.SpacialLocation = new Vector2D();
            oA.Velocity = new Vector2D();
            oB.Velocity = new Vector2D();
            oA.Acceleration = new Vector2D();
            oB.Acceleration = new Vector2D();
            //
            // Inicia-los com os valores preenchidos pelo utilizador
            oA.DrawingRadius = (int)Convert.ToDouble(textBoxMassaA.Text) / 10;
            oB.DrawingRadius = (int)Convert.ToDouble(textBoxMassaB.Text) / 10;
            oA.Mass = Convert.ToDouble(textBoxMassaA.Text) * MassScale;
            oB.Mass = Convert.ToDouble(textBoxMassaB.Text) * MassScale;
            oA.SpacialLocation.X = Convert.ToDouble(textBoxXoA.Text);
            oB.SpacialLocation.X = Convert.ToDouble(textBoxXoB.Text);
            oA.SpacialLocation.Y = Convert.ToDouble(textBoxYoA.Text);
            oB.SpacialLocation.Y = Convert.ToDouble(textBoxYoB.Text);
            oA.Velocity.X = Convert.ToDouble(textBoxVoxA.Text);
            oB.Velocity.X = Convert.ToDouble(textBoxVoxB.Text);
            oA.Velocity.Y = Convert.ToDouble(textBoxVoyA.Text);
            oB.Velocity.Y = Convert.ToDouble(textBoxVoyB.Text);
            //criação do contexto Gráfico do Panel
            Graphics g = Graphics.FromImage(b);

            //
            //Clear da Trajetória
            oA.Trajectory.Clear();
            oB.Trajectory.Clear();
            //
            // Desenhar os objetos 
            oA.DrawSV(g);
            oB.DrawSV(g);
            //
            //DISABLE DAS TEXTBOXES
            textBoxMassaA.Enabled = false;
            textBoxMassaB.Enabled = false;
            textBoxXoA.Enabled = false;
            textBoxYoA.Enabled = false;
            textBoxXoB.Enabled = false;
            textBoxYoB.Enabled = false;
            textBoxVoxA.Enabled = false;
            textBoxVoyA.Enabled = false;
            textBoxVoxB.Enabled = false;
            textBoxVoyB.Enabled = false;
            //
            Refresh();

            //inicio do tempo
            timer1.Start();
        }

        private void buttonParar_Click(object sender, EventArgs e)
        {
            //Parar o tempo
            timer1.Stop();
            //
            //ENABLED DAS TEXTBOXES
            textBoxMassaA.Enabled = true;
            textBoxMassaB.Enabled = true;
            textBoxXoA.Enabled = true;
            textBoxYoA.Enabled = true;
            textBoxXoB.Enabled = true;
            textBoxYoB.Enabled = true;
            textBoxVoxA.Enabled = true;
            textBoxVoyA.Enabled = true;
            textBoxVoxB.Enabled = true;
            textBoxVoyB.Enabled = true;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //uma espécie de clear
            pictureBox1.Image = null;
            //condição universal para proteger o bitmap
            if (pictureBox1.Image == null)
                b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            else
                b = new Bitmap(pictureBox1.Image);
            //definição do graphics no panelsimulação
            Graphics g = Graphics.FromImage(b);
            //
            ////limpar o panel
            //g.Clear(panelSimulação.BackColor);



            //
            //colocar na label do tempo, o cronómetro
            this.t += timer1.Interval;
            labelT.Text = (Convert.ToString(this.t / 1000) + "s");
            //
            //constantes
            double G = 6.67E-11;
            double r = Math.Sqrt(Math.Pow((oB.SpacialLocation.X - oA.SpacialLocation.X), 2) +
                Math.Pow((oB.SpacialLocation.Y - oA.SpacialLocation.Y), 2));
            double F = G * ((oB.Mass * oA.Mass) / Math.Pow(r, 2));
            //
            //colisão
            if (r < oA.DrawingRadius + oB.DrawingRadius)
            {
                timer1.Stop();
                MessageBox.Show("Ocorreu uma colisão entre os dois corpos!");
            }
            //
            //componentes escalares dos vetores aceleração            
            oA.Acceleration.escalar = F / oA.Mass;
            oB.Acceleration.escalar = F / oB.Mass;
            //

            //valores das componentes da aceleração dos corpos

            //corpo A
            oA.Acceleration.X = ((oB.SpacialLocation.X - oA.SpacialLocation.X) / r) * oA.Acceleration.escalar;
            oA.Acceleration.Y = ((oB.SpacialLocation.Y - oA.SpacialLocation.Y) / r) * oA.Acceleration.escalar;
            //corpo B
            oB.Acceleration.Y = ((oA.SpacialLocation.Y - oB.SpacialLocation.Y) / r) * oB.Acceleration.escalar;
            oB.Acceleration.X = ((oA.SpacialLocation.X - oB.SpacialLocation.X) / r) * oB.Acceleration.escalar;
            //
            //Condições para a Lista da Trajetória
            if (oA.Trajectory.Count > N)
            {
                oA.Trajectory.RemoveAt(0);
                oB.Trajectory.RemoveAt(0);
            }
            oA.Trajectory.Add(new Vector2D(oA.SpacialLocation));
            oB.Trajectory.Add(new Vector2D(oB.SpacialLocation));
            //
            //movimento 
            oA.Movimento(timer1.Interval);
            oB.Movimento(timer1.Interval);
            //
            //Desenho
            if (checkBoxTrajetória.Checked == true)
            {
                //código da trajetória
                oA.DrawTraj(g);
                oB.DrawTraj(g);
            }

            //desenho do movimento
            if (checkBoxVetores.Checked == true)
            {
                //Desenho com vetores
                oA.DrawV(g);
                oB.DrawV(g);
            }
            else
            {
                //desenho sem vetores
                oA.DrawSV(g);
                oB.DrawSV(g);
            }
            //Thread.Sleep(50);
            pictureBox1.Image = b;
        }
        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            //Reinício do tempo
            timer1.Start();
        }

        private void checkBoxTrajetória_CheckedChanged(object sender, EventArgs e)
        {
            ////contexto gráfico do panel
            //Graphics g = panelSimulação.CreateGraphics();
            //g.Clear(panelSimulação.BackColor);
            //uma espécie de clear
            pictureBox1.Image = null;
            //condição universal para proteger o bitmap
            if (pictureBox1.Image == null)
                b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            else
                b = new Bitmap(pictureBox1.Image);
            //definição do graphics no panelsimulação
            Graphics g = Graphics.FromImage(b);
            //
            //
            if (checkBoxTrajetória.Checked == true)
            {
                //código da trajetória
                oA.DrawTraj(g);
                oB.DrawTraj(g);
            }
            if (checkBoxVetores.Checked == true)
            {
                oA.DrawV(g);
                oB.DrawV(g);

            }
            else
            {
                oA.DrawSV(g);
                oB.DrawSV(g);
            }
            pictureBox1.Image = b;
        }
        private void checkBoxVetores_CheckedChanged(object sender, EventArgs e)
        {
            //Graphics g = panelSimulação.CreateGraphics();
            //g.Clear(panelSimulação.BackColor);
            pictureBox1.Image = null;
            //condição universal para proteger o bitmap
            if (pictureBox1.Image == null)
                b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            else
                b = new Bitmap(pictureBox1.Image);
            //definição do graphics no panelsimulação
            Graphics g = Graphics.FromImage(b);
            //
            //
            if (checkBoxTrajetória.Checked == true)
            {
                //código da trajetória
                oA.DrawTraj(g);
                oB.DrawTraj(g);
            }
            if (checkBoxVetores.Checked == true)
            {
                oA.DrawV(g);
                oB.DrawV(g);

            }
            else
            {
                oA.DrawSV(g);
                oB.DrawSV(g);
            }
            pictureBox1.Image = b;
        }

        private void textBoxMassaA_TextChanged(object sender, EventArgs e)
        {
            //código de proteção da textbox
            int n;
            bool isNumeric = int.TryParse(textBoxMassaA.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Insira Valor Numérico");
                if (textBoxMassaA.Text.Length == 0)
                {
                    buttonIniciar.Enabled = false;
                    buttonContinuar.Enabled = false;
                    buttonPausa.Enabled = false;
                    return;
                }
                //Apagar o último caracter
                textBoxMassaA.Text = textBoxMassaA.Text.Substring(0,
                    textBoxMassaA.Text.Length - 1);

            }
            else
            {
                buttonIniciar.Enabled = true;
                buttonContinuar.Enabled = true;
                buttonPausa.Enabled = true;
            }


        }

        private void textBoxMassaB_TextChanged(object sender, EventArgs e)
        {
            //código de proteção da textbox
            int n;
            bool isNumeric = int.TryParse(textBoxMassaB.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Insira Valor Numérico");
                if (textBoxMassaB.Text.Length == 0)
                {
                    buttonIniciar.Enabled = false;
                    buttonContinuar.Enabled = false;
                    buttonPausa.Enabled = false;
                    return;
                }
                //Apagar o último caracter
                textBoxMassaB.Text = textBoxMassaB.Text.Substring(0,
                    textBoxMassaB.Text.Length - 1);

            }
            else
            {
                buttonIniciar.Enabled = true;
                buttonContinuar.Enabled = true;
                buttonPausa.Enabled = true;
            }
        }

        private void textBoxXoA_TextChanged(object sender, EventArgs e)
        {
            //código de proteção da textbox
            int n;
            bool isNumeric = int.TryParse(textBoxXoA.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Insira Valor Numérico");
                if (textBoxXoA.Text.Length == 0)
                {
                    buttonIniciar.Enabled = false;
                    buttonContinuar.Enabled = false;
                    buttonPausa.Enabled = false;
                    return;
                }
                //Apagar o último caracter
                textBoxXoA.Text = textBoxXoA.Text.Substring(0,
                    textBoxXoA.Text.Length - 1);

            }
            else
            {
                buttonIniciar.Enabled = true;
                buttonContinuar.Enabled = true;
                buttonPausa.Enabled = true;
            }
        }

        private void textBoxXoB_TextChanged(object sender, EventArgs e)
        {
            //código de proteção da textbox
            int n;
            bool isNumeric = int.TryParse(textBoxXoB.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Insira Valor Numérico");
                if (textBoxXoB.Text.Length == 0)
                {
                    buttonIniciar.Enabled = false;
                    buttonContinuar.Enabled = false;
                    buttonPausa.Enabled = false;
                    return;
                }
                //Apagar o último caracter
                textBoxXoB.Text = textBoxXoB.Text.Substring(0,
                    textBoxXoB.Text.Length - 1);

            }
            else
            {
                buttonIniciar.Enabled = true;
                buttonContinuar.Enabled = true;
                buttonPausa.Enabled = true;
            }
        }

        private void textBoxYoA_TextChanged(object sender, EventArgs e)
        {
            //código de proteção da textbox
            int n;
            bool isNumeric = int.TryParse(textBoxYoA.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Insira Valor Numérico");
                if (textBoxYoA.Text.Length == 0)
                {
                    buttonIniciar.Enabled = false;
                    buttonContinuar.Enabled = false;
                    buttonPausa.Enabled = false;
                    return;
                }
                //Apagar o último caracter
                textBoxYoA.Text = textBoxYoA.Text.Substring(0,
                    textBoxYoA.Text.Length - 1);

            }
            else
            {
                buttonIniciar.Enabled = true;
                buttonContinuar.Enabled = true;
                buttonPausa.Enabled = true;
            }
        }

        private void textBoxYoB_TextChanged(object sender, EventArgs e)
        {
            //código de proteção da textbox
            int n;
            bool isNumeric = int.TryParse(textBoxYoB.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Insira Valor Numérico");
                if (textBoxYoB.Text.Length == 0)
                {
                    buttonIniciar.Enabled = false;
                    buttonContinuar.Enabled = false;
                    buttonPausa.Enabled = false;
                    return;
                }
                //Apagar o último caracter
                textBoxYoB.Text = textBoxYoB.Text.Substring(0,
                    textBoxYoB.Text.Length - 1);

            }
            else
            {
                buttonIniciar.Enabled = true;
                buttonContinuar.Enabled = true;
                buttonPausa.Enabled = true;
            }
        }

        private void textBoxVoxA_TextChanged(object sender, EventArgs e)
        {
            //código de proteção da textbox
            int n;
            bool isNumeric = int.TryParse(textBoxVoxA.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Insira Valor Numérico");
                if (textBoxVoxA.Text.Length == 0)
                {
                    buttonIniciar.Enabled = false;
                    buttonContinuar.Enabled = false;
                    buttonPausa.Enabled = false;
                    return;
                }
                //Apagar o último caracter
                textBoxVoxA.Text = textBoxVoxA.Text.Substring(0,
                    textBoxVoxA.Text.Length - 1);

            }
            else
            {
                buttonIniciar.Enabled = true;
                buttonContinuar.Enabled = true;
                buttonPausa.Enabled = true;
            }
        }



        private void textBoxVoxB_TextChanged(object sender, EventArgs e)
        {
            //código de proteção da textbox
            int n;
            bool isNumeric = int.TryParse(textBoxVoxB.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Insira Valor Numérico");
                if (textBoxVoxB.Text.Length == 0)
                {
                    buttonIniciar.Enabled = false;
                    buttonContinuar.Enabled = false;
                    buttonPausa.Enabled = false;
                    return;
                }
                //Apagar o último caracter
                textBoxVoxB.Text = textBoxVoxB.Text.Substring(0,
                    textBoxVoxB.Text.Length - 1);

            }
            else
            {
                buttonIniciar.Enabled = true;
                buttonContinuar.Enabled = true;
                buttonPausa.Enabled = true;
            }
        }

        private void textBoxVoyA_TextChanged(object sender, EventArgs e)
        {
            //código de proteção da textbox
            int n;
            bool isNumeric = int.TryParse(textBoxVoyA.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Insira Valor Numérico");
                if (textBoxVoyA.Text.Length == 0)
                {
                    buttonIniciar.Enabled = false;
                    buttonContinuar.Enabled = false;
                    buttonPausa.Enabled = false;
                    return;
                }
                //Apagar o último caracter
                textBoxVoyA.Text = textBoxVoyA.Text.Substring(0,
                    textBoxVoyA.Text.Length - 1);

            }
            else
            {
                buttonIniciar.Enabled = true;
                buttonContinuar.Enabled = true;
                buttonPausa.Enabled = true;
            }
        }

        private void textBoxVoyB_TextChanged(object sender, EventArgs e)
        {
            //código de proteção da textbox
            int n;
            bool isNumeric = int.TryParse(textBoxVoyB.Text, out n);
            if (isNumeric == false)
            {
                MessageBox.Show("Insira Valor Numérico");
                if (textBoxVoyB.Text.Length == 0)
                {
                    buttonIniciar.Enabled = false;
                    buttonContinuar.Enabled = false;
                    buttonPausa.Enabled = false;
                    return;
                }
                //Apagar o último caracter
                textBoxVoyB.Text = textBoxVoyB.Text.Substring(0,
                    textBoxVoyB.Text.Length - 1);

            }
            else
            {
                buttonIniciar.Enabled = true;
                buttonContinuar.Enabled = true;
                buttonPausa.Enabled = true;
            }
        }

    }

}
