namespace WindowsFormsApplication23
{
    partial class FormGA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxMaxGenome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.textBoxMutation = new System.Windows.Forms.TextBox();
            this.textBoxCrossover = new System.Windows.Forms.TextBox();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonRes = new System.Windows.Forms.Button();
            this.textBoxPopulation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMinGenome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonPath = new System.Windows.Forms.RadioButton();
            this.radioButtonElement = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.labelGeneration = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(11, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 415);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBoxMaxGenome);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxStep);
            this.panel2.Controls.Add(this.textBoxMutation);
            this.panel2.Controls.Add(this.textBoxCrossover);
            this.panel2.Controls.Add(this.buttonContinue);
            this.panel2.Controls.Add(this.buttonStart);
            this.panel2.Controls.Add(this.buttonRes);
            this.panel2.Controls.Add(this.textBoxPopulation);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxMinGenome);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.radioButtonPath);
            this.panel2.Controls.Add(this.radioButtonElement);
            this.panel2.Location = new System.Drawing.Point(11, 469);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 151);
            this.panel2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(170, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "MaxGenome Size";
            // 
            // textBoxMaxGenome
            // 
            this.textBoxMaxGenome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMaxGenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaxGenome.Location = new System.Drawing.Point(338, 22);
            this.textBoxMaxGenome.Name = "textBoxMaxGenome";
            this.textBoxMaxGenome.Size = new System.Drawing.Size(100, 23);
            this.textBoxMaxGenome.TabIndex = 17;
            this.textBoxMaxGenome.Text = "100";
            this.textBoxMaxGenome.TextChanged += new System.EventHandler(this.textBoxMaxGenome_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(170, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Step";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(170, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mutate Probability";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(170, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Crossover Probability";
            // 
            // textBoxStep
            // 
            this.textBoxStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStep.Location = new System.Drawing.Point(338, 128);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(100, 23);
            this.textBoxStep.TabIndex = 14;
            this.textBoxStep.Text = "1";
            this.textBoxStep.TextChanged += new System.EventHandler(this.textBoxStep_TextChanged);
            // 
            // textBoxMutation
            // 
            this.textBoxMutation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMutation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMutation.Location = new System.Drawing.Point(338, 102);
            this.textBoxMutation.Name = "textBoxMutation";
            this.textBoxMutation.Size = new System.Drawing.Size(100, 23);
            this.textBoxMutation.TabIndex = 14;
            this.textBoxMutation.Text = "1";
            this.textBoxMutation.TextChanged += new System.EventHandler(this.textBoxMutation_TextChanged);
            // 
            // textBoxCrossover
            // 
            this.textBoxCrossover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCrossover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCrossover.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCrossover.Location = new System.Drawing.Point(338, 73);
            this.textBoxCrossover.Name = "textBoxCrossover";
            this.textBoxCrossover.Size = new System.Drawing.Size(100, 23);
            this.textBoxCrossover.TabIndex = 13;
            this.textBoxCrossover.Text = "70";
            this.textBoxCrossover.TextChanged += new System.EventHandler(this.textBoxCrossover_TextChanged);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(457, 96);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(75, 23);
            this.buttonContinue.TabIndex = 12;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(457, 67);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonRes
            // 
            this.buttonRes.Location = new System.Drawing.Point(457, 125);
            this.buttonRes.Name = "buttonRes";
            this.buttonRes.Size = new System.Drawing.Size(75, 23);
            this.buttonRes.TabIndex = 7;
            this.buttonRes.Text = "Reset";
            this.buttonRes.UseVisualStyleBackColor = true;
            this.buttonRes.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBoxPopulation
            // 
            this.textBoxPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPopulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPopulation.Location = new System.Drawing.Point(338, 48);
            this.textBoxPopulation.Name = "textBoxPopulation";
            this.textBoxPopulation.Size = new System.Drawing.Size(100, 23);
            this.textBoxPopulation.TabIndex = 6;
            this.textBoxPopulation.Text = "100";
            this.textBoxPopulation.TextChanged += new System.EventHandler(this.textBoxPopulation_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(170, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Population Size";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "MinGenome Size";
            // 
            // textBoxMinGenome
            // 
            this.textBoxMinGenome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMinGenome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMinGenome.Location = new System.Drawing.Point(338, 1);
            this.textBoxMinGenome.Name = "textBoxMinGenome";
            this.textBoxMinGenome.Size = new System.Drawing.Size(100, 23);
            this.textBoxMinGenome.TabIndex = 3;
            this.textBoxMinGenome.Text = "50";
            this.textBoxMinGenome.TextChanged += new System.EventHandler(this.textBoxMinGenome_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Control Panel";
            // 
            // radioButtonPath
            // 
            this.radioButtonPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonPath.AutoSize = true;
            this.radioButtonPath.BackColor = System.Drawing.Color.White;
            this.radioButtonPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPath.Location = new System.Drawing.Point(12, 75);
            this.radioButtonPath.Name = "radioButtonPath";
            this.radioButtonPath.Size = new System.Drawing.Size(91, 21);
            this.radioButtonPath.TabIndex = 1;
            this.radioButtonPath.TabStop = true;
            this.radioButtonPath.Text = "Draw Path";
            this.radioButtonPath.UseVisualStyleBackColor = false;
            this.radioButtonPath.CheckedChanged += new System.EventHandler(this.radioButtonPath_CheckedChanged);
            // 
            // radioButtonElement
            // 
            this.radioButtonElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonElement.AutoSize = true;
            this.radioButtonElement.BackColor = System.Drawing.Color.White;
            this.radioButtonElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonElement.Location = new System.Drawing.Point(12, 41);
            this.radioButtonElement.Name = "radioButtonElement";
            this.radioButtonElement.Size = new System.Drawing.Size(102, 21);
            this.radioButtonElement.TabIndex = 0;
            this.radioButtonElement.TabStop = true;
            this.radioButtonElement.Text = "Draw Player";
            this.radioButtonElement.UseVisualStyleBackColor = false;
            this.radioButtonElement.CheckedChanged += new System.EventHandler(this.radioButtonElement_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "GENERATION:";
            // 
            // labelGeneration
            // 
            this.labelGeneration.AutoSize = true;
            this.labelGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGeneration.ForeColor = System.Drawing.Color.White;
            this.labelGeneration.Location = new System.Drawing.Point(166, 9);
            this.labelGeneration.Name = "labelGeneration";
            this.labelGeneration.Size = new System.Drawing.Size(23, 25);
            this.labelGeneration.TabIndex = 3;
            this.labelGeneration.Text = "0";
            // 
            // FormGA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(562, 632);
            this.Controls.Add(this.labelGeneration);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormGA";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonPath;
        private System.Windows.Forms.RadioButton radioButtonElement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMinGenome;
        private System.Windows.Forms.TextBox textBoxPopulation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelGeneration;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.TextBox textBoxMutation;
        private System.Windows.Forms.TextBox textBoxCrossover;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxMaxGenome;
    }
}

