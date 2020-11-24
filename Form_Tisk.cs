using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Zakazkovy_system
{
    public partial class Form_Tisk : Form
    {
        private Bitmap bitmap;
        private string cislo_zakazky;

        public Form_Tisk(string _cislo_zakazky)
        {
            InitializeComponent();
            cislo_zakazky = _cislo_zakazky;
            Find();
        
        }

        private void Find()
        {
            DataRow zakazka = null;
            DataRow zakaznik = null;
            DataRow zarizeni = null;

            foreach (DataRow row in Form_Mainwindow.Data.Tables[0].Rows)
            {
                if (row[0].ToString().Contains(cislo_zakazky))
                {
                    zakazka = row;
                    foreach (DataRow row1 in Form_Mainwindow.Data.Tables[1].Rows)
                    {
                        if (row1[0].ToString() == zakazka[4].ToString())
                        {
                            zakaznik = row1;
                            break;
                        }
                    }

                    foreach (DataRow row2 in Form_Mainwindow.Data.Tables[2].Rows)
                    {
                        if (row2[2].ToString() == zakazka[3].ToString())
                        {
                            zarizeni = row2;
                            break;
                        }
                    }
                    break;
                }
            }
            if (zakazka != null && zakaznik != null && zarizeni != null)
            {
                textBox_Cislo_zakazky.Text = zakazka[0].ToString();
                textBox_Vizualni_stav.Text = zakazka[5].ToString();
                textBox_Popis_zavady.Text = zakazka[6].ToString();
                textBox_Cenovy_limit.Text = zakazka[7].ToString();
                textBox_Reklamace.Text = zakazka[8].ToString();
                textBox_Prijem.Text = zakazka[9].ToString();
                textBox_Diagnostika.Text = zakazka[10].ToString();
                textBox_Vyjadreni_k_oprave.Text = zakazka[11].ToString();
                textBox_Ukonceni.Text = zakazka[12].ToString();
                textBox_Expedice.Text = zakazka[13].ToString();
                textBox_Oprava.Text = zakazka[14].ToString();
                textBox_Diagnostika_datum.Text = zakazka[15].ToString();
                textBox_Dalsi_identifikace.Text = zakazka[16].ToString();
                textBox_SN.Text = zakazka[17].ToString();

                textBox_Spolecnost.Text = zakaznik[1].ToString();
                textBox_Jmeno.Text = zakaznik[2].ToString();
                textBox_Prijmeni.Text = zakaznik[3].ToString();
                textBox_Ulice.Text = zakaznik[4].ToString();
                textBox_Mesto.Text = zakaznik[5].ToString();
                textBox_PSC.Text = zakaznik[6].ToString();
                textBox_Tel.Text = zakaznik[7].ToString();
                textBox_email.Text = zakaznik[8].ToString();
                textBox_ICO.Text = zakaznik[9].ToString();
                textBox_DIC.Text = zakaznik[10].ToString();

                textBox_Vyrobce.Text = zarizeni[0].ToString();
                textBox_Typ_zarizeni.Text = zarizeni[1].ToString();
                textBox_Model.Text = zarizeni[2].ToString();
            }
        }

        private void tisk()
        {
            Graphics grp = this.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            grp.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, formSize);

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();

        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            //memoryImage.SetResolution(600, 600);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height - 40, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
            Resizing(780, 950);
            //DrawOutCropArea(0, 0, 750, 1110);
            Crop(0, 0, 766, 880);

        }
        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void Resizing(int newWidth, int newHeight)
        {
            if (newWidth != 0 && newHeight != 0)
            {
                Bitmap temp = (Bitmap)memoryImage;
                Bitmap bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)newWidth;
                double nHeightFactor = (double)temp.Height / (double)newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb
                (255, nRed, nGreen, nBlue));
                    }
                }
                memoryImage = (Bitmap)bmap.Clone();
            }
        }

        public void DrawOutCropArea(int xPosition, int yPosition, int width, int height)
        {
            Bitmap _bitmapPrevCropArea = (Bitmap)memoryImage;
            Bitmap bmap = (Bitmap)_bitmapPrevCropArea.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            Brush cBrush = new Pen(Color.FromArgb(150, Color.White)).Brush;
            Rectangle rect1 = new Rectangle(0, 0, memoryImage.Width, yPosition);
            Rectangle rect2 = new Rectangle(0, yPosition, xPosition, height);
            Rectangle rect3 = new Rectangle
            (0, (yPosition + height), memoryImage.Width, memoryImage.Height);
            Rectangle rect4 = new Rectangle((xPosition + width),
        yPosition, (memoryImage.Width - xPosition - width), height);
            gr.FillRectangle(cBrush, rect1);
            gr.FillRectangle(cBrush, rect2);
            gr.FillRectangle(cBrush, rect3);
            gr.FillRectangle(cBrush, rect4);
            memoryImage = (Bitmap)bmap.Clone();
        }

        public void Crop(int xPosition, int yPosition, int width, int height)
        {
            Bitmap temp = (Bitmap)memoryImage;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (xPosition + width > memoryImage.Width)
                width = memoryImage.Width - xPosition;
            if (yPosition + height > memoryImage.Height)
                height = memoryImage.Height - yPosition;
            Rectangle rect = new Rectangle(xPosition, yPosition, width, height);
            memoryImage = (Bitmap)bmap.Clone(rect, bmap.PixelFormat);
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            memoryImage.Save(@"C:\Users\eredmad\Desktop\aaaPix.png", System.Drawing.Imaging.ImageFormat.Png);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            printDocument1.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind = PrinterResolutionKind.High;
            printDocument1.Print();
            
        }

    }
}
