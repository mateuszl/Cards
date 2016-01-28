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

        private void b_generate_Click(object sender, EventArgs e)
        {
            //generuje pdf
            float cardHeight = 0;
            float cardWidth = 0;
            try
            {
                cardHeight = mm2point((float.Parse(tb_height.Text)));
                cardWidth = mm2point((float.Parse(tb_width.Text)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Złe wymiary karty");
            }

            for (int i = 0; i < cards.Count; i++)
            {
                Card k = cards[i];
                k.height = cardHeight;
                k.width = cardWidth;
                cards[i] = k;
            }

            saveFileDialog1.ShowDialog();

            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.OpenOrCreate));

            doc.Open();
            iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
            doc.NewPage();
            int cardsInX = Convert.ToInt16(mm2point(210) / cardWidth);
            int cardsInY = Convert.ToInt16(mm2point(297) / cardHeight);

            float reverse_margin = mm2point(210) - cardsInX * cardWidth - doc.LeftMargin;

            int x = 0;
            int y = 0;

            List<Card> temp = new List<Card>();

            for (int i = 0; i < cards.Count; i++)
            {
                var img = iTextSharp.text.Image.GetInstance(cards[i].frontPath);
                img.SetAbsolutePosition(doc.LeftMargin + x * cards[i].width, y * cards[i].height);
                img.ScaleAbsolute(cardWidth, cardHeight);
                cb.AddImage(img);
                temp.Add(cards[i]);
                x++;

                /*
                if (temp.Count < cardsInX*cardsInY) //źle, ale musi byc jakis warunek że jak strona nie jest pelna to i tak dodaje tyly
                {
                    doc.NewPage();
                    y = 0;

                    for (int z = 0; z < temp.Count; z++)
                    {
                        var reverse = iTextSharp.text.Image.GetInstance(temp[z].reversePath);
                        reverse.SetAbsolutePosition(reverse_margin + x * temp[z].width, y * temp[z].height);
                        reverse.ScaleAbsolute(cardWidth, cardHeight);
                        cb.AddImage(reverse);
                        x++;
                        if (x >= cardsInX)
                        {
                            x = 0;
                            y++;
                            if (y >= cardsInY)
                            {
                                y = 0;
                                doc.NewPage();
                                break;
                            }
                        }
                    }
                }*/

                if (x >= cardsInX)
                {
                    x = 0;
                    y++;
                    if (y >= cardsInY)
                    {
                        y = 0;
                        doc.NewPage();

                        for (int z = 0; z < temp.Count; z++)
                        {
                            var reverse = iTextSharp.text.Image.GetInstance(temp[z].reversePath);
                            reverse.SetAbsolutePosition(reverse_margin + x * temp[z].width, y * temp[z].height);
                            reverse.ScaleAbsolute(cardWidth, cardHeight);
                            cb.AddImage(reverse);
                            x++;
                            if (x >= cardsInX)
                            {
                                x = 0;
                                y++;
                                if (y >= cardsInY)
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
            doc.Close();

            //image.RotationDegrees = 90;
            //za malo tyłów
            //dodac przerwy
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            //dodaje obiekt noewj karty do listy gotowych kart 
            Card c;
            c = new Card();
            c.frontPath = list_box.SelectedItem.ToString();
            c.reversePath = pic_back.ImageLocation;
            c.name = list_box.SelectedItem.ToString().TrimStart(frontsDefaultPath.ToCharArray());
            c.quantity = ud_quantity.Value;
            c.width = float.Parse(tb_width.Text, System.Globalization.CultureInfo.InvariantCulture);
            c.height = float.Parse(tb_height.Text, System.Globalization.CultureInfo.InvariantCulture);
            for (int i = 1; i <= c.quantity; i++)
            {
                cards.Add(c);
            }
            list_box_c.Items.Add(c); //wyswietlenie tworzonych obiektow na drugiej liscie
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            switch (MessageBox.Show(this, "Czy na pewno chcesz zamknąć program?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
    }
}
