using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recompensa
{
    public partial class Form1 : Form
    {
        public Button[] buttonArray = new Button[49];
        int jugador = 37;
        public int aux2;
        public Random random = new Random();
        public  Boolean alex=true;
        public int numeroRandom;
        public Form1()
        {
            InitializeComponent();
        }
        public int generarRandom()
        {
            Random rnd = new Random();
            int numeroRandom1 = rnd.Next(0, 4);
            if (numeroRandom1 == 0)
                numeroRandom1 = 7;
            if (numeroRandom1 == 1)
                numeroRandom1 = -7;
            if (numeroRandom1 == 2)
                numeroRandom1 = 1;
            if (numeroRandom1 == 3)
                numeroRandom1 = -1;
            return numeroRandom1;
        }
        public void mover(int posicion)
        {
            if (buttonArray[jugador + posicion].Text == "")
            {
                buttonArray[jugador + posicion].BackColor = Color.Red;
                buttonArray[jugador].BackColor = Color.Transparent;
                jugador = jugador + posicion;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "Jugador: " + jugador;
            int horizotal = 50;
            int vertical = 50;
            for (int i = 0; i < buttonArray.Length; i++)
            {
                buttonArray[i] = new Button();
                buttonArray[i].Size = new Size(50, 50);
                buttonArray[i].Location = new Point(horizotal, vertical);
                if ((i == 6) || (i == 13) || (i == 20) || (i == 27) || (i == 34) || (i == 41))
                {
                    vertical = 50;
                    horizotal = horizotal + 50;

                }
                else
                    vertical = vertical + 50;
                buttonArray[i].Text = "0";
                this.Controls.Add(buttonArray[i]);
            }
            for (int i = 0; i < buttonArray.Length; i++)
            {

                if ((i >= 0) && (i <= 6) || i >= 42 && i <= 48 || i == 7 || i == 14 || i == 21 || i == 28 || i == 35 || i == 13 || i == 20 || i == 27 || i == 34 || i == 41 || i == 10 || i == 18 || i == 17 || i == 32 || i == 33 || i == 16  || i == 30)
                {
                    buttonArray[i].Text = "-100";
                    buttonArray[i].BackColor = Color.Yellow;
                }
             
            }
            
            buttonArray[36].Text = "100";
            buttonArray[jugador].BackColor = Color.Red;
        }
        public int checarMayor(int posicion)
        {
            int res=0;
            int a = Int32.Parse(buttonArray[posicion + 1].Text);
            int b = Int32.Parse(buttonArray[posicion - 1].Text);
            int c= Int32.Parse(buttonArray[posicion + 7].Text);
            int d= Int32.Parse(buttonArray[posicion - 7].Text);
            if (a > b && a > c && a > d)
                res = +1;
            else if (b > a && b > c && b > d)
                res = -1;
            else if (c > b && c > a && c > d)
                res = +7;
            else if (d > a && d > c && d > b)
                res = -7;
            else
                res = -200;
            return res;



                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            

            //while (alex)
            //{
             //Task.Delay(1000).Wait();
            label2.Text = "Jugador: " + jugador;
                 
            int aux2 = checarMayor(jugador);
            if (aux2 == -200)
            {
                numeroRandom = random.Next(0, 4);
                if (numeroRandom == 0)
                    numeroRandom = 7;
                if (numeroRandom == 1)
                    numeroRandom = -7;
                if (numeroRandom == 2)
                    numeroRandom = 1;
                if (numeroRandom == 3)
                    numeroRandom = -1;
            }
            else
            {
                numeroRandom = aux2;
            }
                label1.Text = "Random: " + numeroRandom;
                if (buttonArray[jugador + numeroRandom].Text != "-100")
                {
                    if (buttonArray[jugador + numeroRandom].Text != "0")
                    {
                        if (buttonArray[jugador + numeroRandom].Text == "100")
                        {
                            buttonArray[jugador + numeroRandom].BackColor = Color.Red;
                            buttonArray[jugador].BackColor = Color.Transparent;
                            int aux = Int32.Parse(buttonArray[jugador + numeroRandom].Text);
                            aux = aux - 1;
                            buttonArray[jugador].Text = aux.ToString();
                            Task.Delay(1000).Wait();
                            buttonArray[jugador + numeroRandom].BackColor = Color.Transparent;
                            jugador = 12;
                            buttonArray[jugador].BackColor = Color.Red;
                        }
                        else
                        {
                            int aux = Int32.Parse(buttonArray[jugador + numeroRandom].Text);
                            aux = aux - 1;
                            buttonArray[jugador].Text = aux.ToString();
                            buttonArray[jugador + numeroRandom].BackColor = Color.Red;
                            buttonArray[jugador].BackColor = Color.Transparent;
                            jugador = jugador + numeroRandom;

                        }
                        
                    }
                    else
                    {
                        buttonArray[jugador + numeroRandom].BackColor = Color.Red;
                        buttonArray[jugador].BackColor = Color.Transparent;
                        jugador = jugador + numeroRandom;
                    }
                }

                label2.Text = "Jugador: " + jugador;
            

           //}
            
            
        }
    }
}
