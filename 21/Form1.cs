using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21
{
    public partial class Form1 : Form
    {
        public PictureBox[] tabla;
        public int db = 21;
        public int felhuzott = 0;
        public int[] fontos_mezok = new int[5];
        public int[] lepesek = new int[3];
        public Random r = new Random();
        public bool gepi = false;
        public int korok = 0;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                fontos_mezok[i] = i * 4;
                if (i < 3)
                {
                    lepesek[i] = i + 1;
                }
            }
            kezdes();
        }
        private void kezdes()
        {
            Bitmap gyufa = new Bitmap("gyufa.png");
           
            tabla = new PictureBox[21];
            for (int i = 0; i < 21; i++)
            {

                tabla[i] = new PictureBox();
                tabla[i].SizeMode = PictureBoxSizeMode.StretchImage;
                tabla[i].Image = (Image)gyufa;
                tabla[i].Left = 50 + i * 35;
                tabla[i].Top = 100;
                this.Controls.Add(tabla[i]);
                tabla[i].Width = 50;
                tabla[i].Height = 150;
            }
            label2.Text = ($"{db} gyufa van hátra");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Visible == false)
            {
                label1.Visible = true;

            }
            else
            {
                label1.Visible = false;
            }
        }

        private void ember_lepes(int tag)
        {
            if (db>=tag)
            {
                for (int i = 0; i < tag; i++)
                {

                    tabla[felhuzott].Visible = false;
                    felhuzott++;
                    db--;
                }
                korok++;
                vege();
            }
           
        }

        private void gep_lepes()
        {
            bool tipp = true;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (db - lepesek[j] == fontos_mezok[i])
                    {
                        for (int k = 0; k < lepesek[j]; k++)
                        {
                            tabla[felhuzott].Visible = false;
                            felhuzott++;
                            db--;
                        }
                        tipp = false;
                        label3.Text = ($"A gép {lepesek[j]} db gyufát szedett fel");
                    }
                }
            }
            if (tipp == true)
            {
                int random = r.Next(1, 4);
                for (int i = 0; i < random; i++)
                {
                    tabla[felhuzott].Visible = false;
                    felhuzott++;
                    db--;
                }
                label3.Text = ($"A gép {random} db gyufát szedett fel");
            }
            label2.Text = ($"{db} gyufa van hátra");
            korok++;
            vege();
        }

        public void vege()
        {
            if (db == 0)
            {
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = true;
                button7.Visible=true;
                if (gepi == true && korok % 2 == 0)
                {
                    label5.Text = "A gép nyert ;)";
                }

                if (gepi == false && korok % 2 == 0)
                {
                    label5.Text = "A második játékos nyert";
                }
                if (gepi == true && korok % 2 != 0)
                {
                    label5.Text = "Az ember nyert... :O";
                }
                if (gepi == false && korok % 2 != 0)
                {
                    label5.Text = "Az első játékos nyert";
                }

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            label2.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            gepi = true;
            button2.Visible = false;
            button3.Visible = false;
            label2.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32(button4.Tag);
            ember_lepes(tag);
            label2.Text = ($"{db} gyufa van hátra");
            if (gepi == true && db != 0)
            {
                gep_lepes();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32(button5.Tag);
            ember_lepes(tag);
            label2.Text = ($"{db} gyufa van hátra");
            if (gepi == true && db != 0)
            {
                gep_lepes();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32(button6.Tag);
            ember_lepes(tag);
            label2.Text = ($"{db} gyufa van hátra");
            if (gepi == true && db != 0)
            {
                gep_lepes();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            db = 21;
            felhuzott = 0;
            gepi = false;
            korok = 0;
            kezdes();
        }
    }
}
