﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İmageProc
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Image file;
        Bitmap bitmap2; 
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                bitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = file;
            }
        }  

        private void button2_Click_1(object sender, EventArgs e)
        {
            int[,] Gx = new int[3, 3]{ {-1, 0, 1 }, 
                                       {-2, 0, 2 } , 
                                       {-1, 0, 1 } };

            int[,] Gy = new int[3, 3]{ {-1,-2,-1}, 
                                       { 0, 0, 0 }, 
                                       { 1, 2, 1}};

            int[,] TotalGx = new int[bitmap.Width, bitmap.Height];
            int[,] TotalGy = new int[bitmap.Width, bitmap.Height];
            int[,] GTotal = new int[bitmap.Width , bitmap.Height];

            bitmap2 = new Bitmap(bitmap.Width, bitmap.Height);

            for (int i = 1; i < bitmap.Width - 1; i++)
            {
                for (int j = 1; j < bitmap.Height - 1; j++)
                {
                    Color a = bitmap.GetPixel(i - 1, j - 1);//[0][0]
                    Color b = bitmap.GetPixel(i - 1, j);    //[0][1]
                    Color c = bitmap.GetPixel(i - 1, j + 1);//[0][2]

                    Color d = bitmap.GetPixel(i, j - 1);    //[1][0]
                    Color f = bitmap.GetPixel(i, j);        //[1][1]
                    Color g = bitmap.GetPixel(i, j + 1);    //[1][2]

                    Color h = bitmap.GetPixel(i + 1, j - 1);//[2][0]
                    Color l = bitmap.GetPixel(i + 1, j);    //[2][1]
                    Color n = bitmap.GetPixel(i + 1, j + 1); //[2][2]

                    TotalGx[i, j] = Gx[0, 0] * a.G + Gx[0, 1] * b.G + Gx[0, 2] * c.G
                                   + Gx[1, 0] * d.G + Gx[1, 1] * f.G + Gx[1, 2] * g.G
                                   + Gx[2, 0] * h.G + Gx[2, 1] * l.G + Gx[2, 2] * n.G;

                    if (TotalGx[i, j] < 0) { TotalGx[i, j] = 0; }
                    if (TotalGx[i, j] > 255) { TotalGx[i, j] = 255; }

                    TotalGy[i, j] = Gy[0, 0] * a.G + Gy[0, 1] * b.G + Gy[0, 2] * c.G
                                  + Gy[1, 0] * d.G + Gy[1, 1] * f.G + Gy[1, 2] * g.G
                                  + Gy[2, 0] * h.G + Gy[2, 1] * l.G + Gy[2, 2] * n.G;

                    if (TotalGy[i, j] < 0) { TotalGy[i, j] = 0; }
                    if (TotalGy[i, j] > 255) { TotalGy[i, j] = 255; }

                } 

                for (int k = 1; k < bitmap.Width - 1; k++)
                {
                    for (int j = 1; j < bitmap.Height - 1; j++)
                    {
                        GTotal[k, j] = TotalGx[k, j] + TotalGy[k, j];

                        if (GTotal[k, j] >= 255)
                        { GTotal[k, j] = 255; }

                        if (GTotal[k, j] < 0)
                        { GTotal[k, j] = 0; }

                        bitmap2.SetPixel(k, j, Color.FromArgb(GTotal[k, j], GTotal[k, j], GTotal[k, j]));
                    }
                }
                pictureBox2.Image = bitmap2;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
    }
}