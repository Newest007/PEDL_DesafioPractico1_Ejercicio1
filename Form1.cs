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

        Queue<String> colaTipoString = new Queue<string>();

        int x = 450;
        int y = 70;


        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) { }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e) { }

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


            if (colaTipoString.Contains(miLabel.Text))
            {
                MessageBox.Show("El valor ya existe en la cola, pruebe con otro valor","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                colaTipoString.Enqueue(miLabel.Text); //Cola Tipo String
                colaPrincipal.Enqueue(miLabel); //Cola Tipo Label
                panel1.Controls.Add(miLabel);
                timer1.Start();
            }

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnEncolar.Enabled = false;
            Label PrimeroCola = colaPrincipal.Last();
            PrimeroCola.BackColor = Color.Aqua;

            if (PrimeroCola.Location.X < x) 
            {
                PrimeroCola.Location = new Point(PrimeroCola.Location.X + 5, PrimeroCola.Location.Y);
                return;
            }

            if(PrimeroCola.Location.Y < y)
            {
                PrimeroCola.Location = new Point(PrimeroCola.Location.X, PrimeroCola.Location.Y + 5);
                return;
            }

            x -= PrimeroCola.Width;
            timer1.Stop();
            PrimeroCola.BackColor = Color.White;
            btnEncolar.Enabled = true;

        }
    }
}
