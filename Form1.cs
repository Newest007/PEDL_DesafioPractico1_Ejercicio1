using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_1_Desafio_Practico_1
{
    public partial class Form1 : Form
    {
        Queue<Label> colaPrincipal = new Queue<Label>();

        int x = 0;
        int y = 50;


        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEncolar_Click(object sender, EventArgs e)
        {

            int valor = Convert.ToInt32(numUpDown.Value);
            Label miLabel = new Label();
            miLabel.Text = valor.ToString();
            miLabel.BackColor = Color.White;
            miLabel.Height = 50;
            miLabel.Width = 50;
            miLabel.TextAlign = ContentAlignment.MiddleCenter;
            miLabel.BorderStyle = BorderStyle.FixedSingle;
            miLabel.Location = new Point(0, 0);

            if (colaPrincipal.Contains(miLabel))
            {
                MessageBox.Show("El valor ya se encuentra en la Cola, pruebe con otro valor", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            colaPrincipal.Enqueue(miLabel);
            
            /*if (colaPrincipal.Contains(miLabel))
            {
                MessageBox.Show("El valor ya se encuentra en la Cola, pruebe con otro valor", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            panel1.Controls.Add(miLabel);
            timer1.Start();
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnEncolar.Enabled = false;
            Label PrimeroCola = colaPrincipal.Peek();
            PrimeroCola.BackColor = Color.Aqua;

            if (PrimeroCola.Location.X < 450) 
            {
                PrimeroCola.Location = new Point(PrimeroCola.Location.X + 5, PrimeroCola.Location.Y);
                return;
            }
            
            




        }
    }
}
