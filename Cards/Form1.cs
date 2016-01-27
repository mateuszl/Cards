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

        public override string ToString()
        {
            return name.Substring(name.LastIndexOf("\\") + 1) + "   x " + quantity;
        }
    }

    public partial class Form1 : Form
    {
        List<Card> cards;

        //komp w pracy
        string frontsDefaultPath = @"C:\temp\fronts";
        string reversesPath = @"C:\temp\back";
        string defaultReversePath = @"C:\temp\back\back_default.png";

        // komp w domu
        //string frontsDefaultPath = @"D:\temp\fronts";
        //string reversesPath = @"D:\temp\back";
        //string defaultReversePath = @"D:\temp\back\back_default.png";

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
                MessageBox.Show("Coś się nie udało");
            }
        }

        private void b_katalog_Click(object sender, EventArgs e)
        {
            list_box.Items.Clear();

            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = frontsDefaultPath;
                DialogResult result = fbd.ShowDialog();
                string path = fbd.SelectedPath;
                string[] files = System.IO.Directory.GetFiles(path, "*.jpg");
                System.Windows.Forms.MessageBox.Show("Załadowano plików: " + files.Length.ToString(), "Message");
                list_box.Items.AddRange(files);
                list_box.DisplayMember.TrimStart(path.ToCharArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coś sie nie udało");
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
            //dodaje obiekt do listy gotowych kart - musi wziac front, back, rozmiar, ilosc
            Card c;
            c = new Card();
            c.frontPath = list_box.SelectedItem.ToString();
            c.reversePath = pic_back.ImageLocation;
            c.name = list_box.SelectedItem.ToString().TrimStart(frontsDefaultPath.ToCharArray());
            c.quantity = ud_quantity.Value;
            c.width = float.Parse(tb_width.Text, System.Globalization.CultureInfo.InvariantCulture);
            c.height = float.Parse(tb_height.Text, System.Globalization.CultureInfo.InvariantCulture);
            cards.Add(c);
            //wyswietlenie istniejacych obiektow na drugiej liscie
            list_box_c.Items.Add(c);
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

        private void b_customBack_Click(object sender, EventArgs e)
        {
            //dodac jakieś wyrzucenie tego co juz jest ustawione jako obrazek
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All files (*.*)|*.*|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                dialog.InitialDirectory = reversesPath;
                dialog.Title = "Wybierz rewers dla karty";
                DialogResult result = dialog.ShowDialog();
                string file = dialog.ToString();
                pic_back.ImageLocation = file;
                pic_back.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coś sie nie udało");
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (list_box_c.SelectedIndex != -1)
            {
                object item = list_box_c.SelectedItem;
                cards.RemoveAt(list_box_c.SelectedIndex);
                list_box_c.Items.Remove(item);
            }
        }
    }
}
