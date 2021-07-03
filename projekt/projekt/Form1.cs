using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            koniec.Visible = false; //przy rozpoczeciu gry niewidzialne
            restart.Visible = false;
            exit.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            poruszanie_tla(5);
            przeszkody(5);
            koniecgry();
            dolary(5);
            dolaryzbierane();
        }

        int dolaryzebrane = 0;

        Random r = new Random();
        int x;
        void przeszkody(int predkosc)
        {
            if (dziura1.Top >= 500)
            {
                x = r.Next(0, 150);

                dziura1.Location = new Point(x, 0);
            }
            else
            {
                dziura1.Top += predkosc;
            }

            if (dziura2.Top >= 500)
            {
                x = r.Next(160, 300);
                dziura2.Location = new Point(x, 0);
            }
            else
            {
                dziura2.Top += predkosc;
            }
            if(dziura3.Top >= 500)
            {
                x = r.Next(300, 480);
                dziura3.Location = new Point(x, 0);
            }
            else
            {
                dziura3.Top += predkosc;
            }
        }

        void dolary(int predkosc)
        {
            if (dolar1.Top >= 500)
            {
                x = r.Next(10, 130);

                dolar1.Location = new Point(x, 0);
            }
            else
            {
                dolar1.Top += predkosc;
            }

            if (dolar2.Top >= 500)
            {
                x = r.Next(100, 280);
                dolar2.Location = new Point(x, 0);
            }
            else
            {
                dolar2.Top += predkosc;
            }
            if (dolar3.Top >= 500)
            {
                x = r.Next(250, 360);
                dolar3.Location = new Point(x, 0);
            }
            else
            {
                dolar3.Top += predkosc;
            }
            if (dolar4.Top >= 500)
            {
                x = r.Next(300, 470);
                dolar4.Location = new Point(x, 0);
            }
            else
            {
                dolar4.Top += predkosc;
            }
        }

        void koniecgry()
        {
            if(bolid.Bounds.IntersectsWith(dziura1.Bounds))
            {
                timer1.Enabled = false;
                koniec.Visible = true;
                restart.Visible = true;
                exit.Visible = true;
            }
            if (bolid.Bounds.IntersectsWith(dziura2.Bounds))
            {
                timer1.Enabled = false;
                koniec.Visible = true;
                restart.Visible = true;
                exit.Visible = true;
            }
            if (bolid.Bounds.IntersectsWith(dziura3.Bounds))
            {
                timer1.Enabled = false;
                koniec.Visible = true;
                restart.Visible = true;
                exit.Visible = true;
            }
        }

        void poruszanie_tla(int predkosc)
        {
            if (pictureBox1.Top >= 500)
            {
                pictureBox1.Top = 0;
            }
            else
            {
                pictureBox1.Top += predkosc;
            }

            if (pictureBox2.Top >= 500)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += predkosc;
            }

            if (pictureBox3.Top >= 500)
            {
                pictureBox3.Top = 0;
            }
            else
            {
                pictureBox3.Top += predkosc;
            }

            if (pictureBox4.Top >= 500)
            {
                pictureBox4.Top = 0;
            }
            else
            {
                pictureBox4.Top += predkosc;
            }

            if (pictureBox5.Top >= 500)
            {
                pictureBox5.Top = 0;
            }
            else
            {
                pictureBox5.Top += predkosc;
            }

            if (pictureBox9.Top >= 500)
            {
                pictureBox9.Top = 0;
            }
            else
            {
                pictureBox9.Top += predkosc;
            }
        }

        void dolaryzbierane()
        {
            if(bolid.Bounds.IntersectsWith(dolar1.Bounds))
            {
                dolaryzebrane++;
                coins.Text = "Coins=" + dolaryzebrane.ToString();
                x = r.Next(20, 130);

                dolar1.Location = new Point(x, 0);
            }
            if (bolid.Bounds.IntersectsWith(dolar2.Bounds))
            {
                dolaryzebrane++;
                coins.Text = "Coins=" + dolaryzebrane.ToString();
                x = r.Next(100, 280);
                dolar2.Location = new Point(x, 0);
            }
            if (bolid.Bounds.IntersectsWith(dolar3.Bounds))
            {
                dolaryzebrane++;
                coins.Text = "Coins=" + dolaryzebrane.ToString();
                x = r.Next(250, 360);
                dolar3.Location = new Point(x, 0);
            }
            if (bolid.Bounds.IntersectsWith(dolar4.Bounds))
            {
                dolaryzebrane++;
                coins.Text = "Coins=" + dolaryzebrane.ToString();
                x = r.Next(300, 470);
                dolar4.Location = new Point(x, 0);
            }
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if(bolid.Left>20) //ograniczenie poruszania z lewej strony
                bolid.Left += -10;
            }
            if (e.KeyCode == Keys.Right)
            {
                if(bolid.Right<470) //ograniczenie poruszania z prawej strony
                bolid.Left += 10;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (bolid.Top > 10)
                    bolid.Top += -10;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (bolid.Top < 440)
                    bolid.Top += 10;
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
