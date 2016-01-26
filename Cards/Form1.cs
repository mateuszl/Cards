using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;

namespace Cards
{
    struct Card
    {
        public string  name;
        public string  path;
        public string  revers;
        public float width;
        public float height;
        public int quantity;
    };

    public partial class Form1 : Form
    {
        List<Card> cards;

        public Form1()
        {
            InitializeComponent();
            cards = new List<Card>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            comboBox1.Items.Clear();

            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;

            string[] imgs = System.IO.Directory.GetFiles(path);
            foreach (string file in imgs)
            {
                listBox1.Items.Add(file);
                comboBox1.Items.Add(file);

                Card k;
                k = new Card();
                k.path   = file;
                k.name     = file;

                k.quantity = 1;

                cards.Add(k);
            }
        }

        private void listBox1_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Load(listBox1.Items[listBox1.SelectedIndex].ToString());
                this.Text = cards[listBox1.SelectedIndex].path;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Card k = cards[i];
                k.revers = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                cards[i] = k;
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Load(comboBox1.Items[comboBox1.SelectedIndex].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong");
            }
        }

        private float mm2point(float mm)
        {
            return mm / .353F;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float HeightImage = mm2point(float.Parse(textBox1.Text));
            float WidthImage   = mm2point( float.Parse(textBox2.Text) );
            for (int i = 0; i < cards.Count; i++)
            {
                Card k = cards[i];
                k.height = HeightImage;
                k.width = WidthImage;
                cards[i] = k;
            }

            saveFileDialog1.ShowDialog();

            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.OpenOrCreate));

            doc.Open();
            iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
            doc.NewPage();
            int ile_X = Convert.ToInt16( mm2point(210) / WidthImage );
            int ile_Y = Convert.ToInt16( mm2point(297) / HeightImage);

            float revers_margin = mm2point(210) - ile_X * WidthImage - doc.LeftMargin;

            int x = 0;
            int y = 0;

            List<Card> temp = new List<Card>();

            for (int i = 0; i < cards.Count; i++)
            {

                var img = iTextSharp.text.Image.GetInstance(cards[i].path);
                img.SetAbsolutePosition(doc.LeftMargin + x*cards[i].width, y*cards[i].height);
                img.ScaleAbsolute(WidthImage, HeightImage);
                cb.AddImage(img);
                temp.Add(cards[i]);
                x++;
                if (x >= ile_X)
                {
                    x = 0;
                    y++;
                    if (y >= ile_Y)
                    {
                        y = 0;
                        doc.NewPage();
                        
                        for (int l = 0; l < temp.Count; l++)
                        {
                            var img_rew = iTextSharp.text.Image.GetInstance(temp[l].revers);
                            img_rew.SetAbsolutePosition(revers_margin + x * temp[l].width, y * temp[l].height);
                            img_rew.ScaleAbsolute(WidthImage, HeightImage);
                            cb.AddImage(img_rew);
                            x++;
                            if (x >= ile_X)
                            {
                                x = 0;
                                y++;
                                if (y >= ile_Y)
                                {
                                    y = 0;
                                    doc.NewPage();
                                    break;
                                }

                            }
                        }
                        temp.Clear();
                          
                    }
                }

            }

            //doc.NewPage();
            //var image = iTextSharp.text.Image.GetInstance(comboBox1.Items[comboBox1.SelectedIndex].ToString());
            //image.SetAbsolutePosition(doc.LeftMargin + 20, doc.TopMargin + 20);
            //image.ScaleAbsolute(WidthImage, HeightImage);
            //image.RotationDegrees = 90;
            //cb.AddImage(image);
            doc.Close();
        }
    }
}
