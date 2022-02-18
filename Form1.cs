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
        Queue<Label> colaPrincipal = new Queue<Label>(); //En esta cola se guardaran los objetos label

        Queue<String> colaTipoString = new Queue<string>(); //En esta cola se guardarran los números de los label´s

        int x = 530; //Valores preestablecidos de los ejes x e y
        int y = 80;

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
            Label nuevoLabel = new Label();
            //De aquí en adelante hasta el If se le asignan las propiedades que tendrá cada Label
            nuevoLabel.Text = valor.ToString();
            nuevoLabel.BackColor = Color.Transparent;
            nuevoLabel.Height = 50;
            nuevoLabel.Width = 50;
            nuevoLabel.TextAlign = ContentAlignment.MiddleCenter;
            nuevoLabel.BorderStyle = BorderStyle.FixedSingle;
            nuevoLabel.Location = new Point(0, 20);

            //If para verificar si el número ingresado es igual a uno que ya se encuentra en la cola que guarda solo números
            if (colaTipoString.Contains(nuevoLabel.Text)) 
            {
                MessageBox.Show("El valor ya existe en la cola, pruebe con otro valor","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                //Si eso no se cumple guarda tantos los números en su respectiva cola y de igual manera con los label´s
                colaTipoString.Enqueue(nuevoLabel.Text); //Cola Tipo String, guarda solo el número
                colaPrincipal.Enqueue(nuevoLabel); //Cola Tipo Label
                panel1.Controls.Add(nuevoLabel);
                timer1.Start();
            }

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnEncolar.Enabled = false; //Para evitar bug´s desabilitamos el boton para encolar
            Label PrimeroCola = colaPrincipal.Last();
            PrimeroCola.BackColor = Color.Transparent;


            //Como x = 530 hará este procedimiento hasta que llegué a 530 en el eje x
            if (PrimeroCola.Location.X < x) 
            {
                PrimeroCola.Location = new Point(PrimeroCola.Location.X + 5, PrimeroCola.Location.Y);
                return;
            }

            //Como y = 80 pasa exactamente lo mismo que con en el If anterior
            if(PrimeroCola.Location.Y < y)
            {
                PrimeroCola.Location = new Point(PrimeroCola.Location.X, PrimeroCola.Location.Y + 5);
                return;
            }

            x -= PrimeroCola.Width; //Restara en x el grosor del label
            timer1.Stop();
            PrimeroCola.BackColor = Color.White;
            btnEncolar.Enabled = true; //Se vuelve a habilitar el botón

        }

        private void btnDesencolar_Click(object sender, EventArgs e)
        {
            if(colaPrincipal.Count == 0) //Condición por si la cola esta vacía
            {
                MessageBox.Show("La Cola esta vacía","Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            timer2.Start();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            btnDesencolar.Enabled = false; //Desabilita el botón desencolar
            Label labelaEliminar = colaPrincipal.Peek(); //Agarra el primer objeto de la fila
            labelaEliminar.BackColor = Color.Transparent;

            if(labelaEliminar.Location.Y > 20) //Se creara un bucle hasta que el valor de y sea de 20
            {
                labelaEliminar.Location = new Point(labelaEliminar.Location.X, labelaEliminar.Location.Y - 5);
                return;
            }

            if(labelaEliminar.Location.X > -50) //Se creara un mismo bucle pero con la diferencia que se desarrollara en el eje x
            {
                labelaEliminar.Location = new Point(labelaEliminar.Location.X - 5, labelaEliminar.Location.Y);
                return;
            }

            colaTipoString.Dequeue(); //Elimina el primer número de la cola
            colaPrincipal.Dequeue(); //Eliminar el primer objeto de la cola


            panel1.Controls.Remove(labelaEliminar); //Remueve del panel1 el label que salio de la pantalla
            x += labelaEliminar.Width; //Suma en x su grosor para que el siguiente de la cola se coloque correctamente

            timer2.Stop(); 
            btnDesencolar.Enabled = true; //Habilita el botón desencolar que anteriormente se había desabilitado

        }
    }
}
