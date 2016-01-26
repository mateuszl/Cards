using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;

namespace Cards
{
    struct Card
    {
        public string name;
        public string frontPath;
        public string reversePath;
        public float width;
        public float height;
        public decimal quantity;
    }

    public partial class Form1 : Form
    {
        List<Card> cards;

        string defaultReversePath = @"C:\TEMP\back\back_default.jpg";

        public Form1()
        {
            InitializeComponent();
            cards = new List<Card>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void list_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FileInfo fi = (FileInfo)list_box.SelectedItem;
            //pic_front.ImageLocation = fi.FullName;
            try
            {
                pic_front.ImageLocation = list_box.SelectedItem.ToString();
                pic_front.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong");
            }
        }

        private void b_katalog_Click(object sender, EventArgs e)
        {
            list_box.Items.Clear();
            //ud_quantity.

            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = @"C:\TEMP\fronts";
                DialogResult result = fbd.ShowDialog();
                string path = fbd.SelectedPath;
                string[] files = System.IO.Directory.GetFiles(path);
                System.Windows.Forms.MessageBox.Show("Załadowano plików: " + files.Length.ToString(), "Message");
                //            list_box.Items.AddRange(files);
                foreach (string file in files)
                {
                    list_box.Items.Add(file);
                    //comboBox1.Items.Add(file);

                    Card k;
                    k = new Card();
                    k.frontPath = file;
                    k.name = file;
                    k.quantity = 1; // ud_quantity.Value;
                    cards.Add(k);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong");
            }
        }

        private void b_load_Click(object sender, EventArgs e)
        {
            //wczytuje zapisany status z xml
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            //zapisuje status do xml
        }

        private void b_generate_Click_1(object sender, EventArgs e)
        {
            //generuje pdf
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            //dodaje karte do listy kreowania pdf
        }

        private void b_default_Click(object sender, EventArgs e)
        {
            //dodac jakieś wyrzucenie tego co juz jest ustawione jako obrazek
            pic_back.ImageLocation = defaultReversePath;
            pic_back.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private float mm2point(float mm)
        {
            return mm / .353F;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dodac jakieś wyrzucenie tego co juz jest ustawione jako obrazek
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            dialog.InitialDirectory = (@"C:\TEMP\back");
            dialog.Title = "Please select an image file for reverse.";
            DialogResult result = dialog.ShowDialog();
            string file = dialog.ToString();
            pic_back.ImageLocation = file;
            pic_back.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}
