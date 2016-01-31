﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using iTextSharp;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;

namespace Cards
/* TODO:
 * 
 * wyjecie metod na zewnatrz?
 *
 * pierwotne .img wskazujace na wybor frontu i reversa?
 * 
 * progressbar?
 * 
 */
{
    [Serializable]
    public struct Card
    {
        public string name;
        public string frontPath;
        public string reversePath;
        public float width;
        public float height;
        public decimal quantity;

        public override string ToString()
        {
            return name;
            //return name.Substring(name.LastIndexOf("\\") + 1) + "   x " + quantity + " szt.";
        }
    }

    [Serializable]
    [XmlRoot("Form1")]
    [XmlInclude(typeof(Card))]
    public partial class Form1 : Form
    {
        [XmlArray("CardList"), XmlArrayItem(typeof(Card), ElementName = "Card")]
        public List<Card> cards { get; set; }

        //komp w pracy
        //string frontsDefaultPath = @"C:\temp\fronts";
        //string reversesPath = @"C:\temp\back";
        //string defaultReversePath = @"C:\temp\back\back_default.png";

        // komp w domu
        string frontsDefaultPath = @"D:\temp\fronts";
        string reversesPath = @"D:\temp\back";
        string defaultReversePath = @"D:\temp\back\back_default.png";
        string defaultPath = @"D:\temp";

        public Form1()
        {
            InitializeComponent();
            cards = new List<Card>();
        }

        private void list_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pic_front.ImageLocation = list_box.SelectedItem.ToString();
                pic_front.SizeMode = PictureBoxSizeMode.Zoom;
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
                string[] files = System.IO.Directory.GetFiles(path);
                System.Windows.Forms.MessageBox.Show("Załadowano plików: " + files.Length.ToString(), "Message");
                foreach (string file in files)
                {
                    if (file.Contains("jpg") | file.Contains("png"))
                    {
                        list_box.Items.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coś sie nie udało");
            }
        }

        private void b_generate_Click(object sender, EventArgs e)
        {
            //generuje pdf
            float cardHeight = 0;
            float cardWidth = 0;
            float space = mm2point(float.Parse(ud_spaces.Text));

            try
            {
                for (int i = 0; i < cards.Count; i++)
                {

                    cardHeight = mm2point((float.Parse(tb_height.Text)));
                    cardWidth = mm2point((float.Parse(tb_width.Text)));
                    Card k = cards[i];
                    k.height = cardHeight;
                    k.width = cardWidth;

                    cards[i] = k;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Złe wymiary karty!");
            }

            saveFileDialog1.ShowDialog();

            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 30, 30);

            try
            {
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.OpenOrCreate));
                doc.Open();
                iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;

                int cardsInX = Convert.ToInt16((mm2point(210) + space - doc.LeftMargin - doc.RightMargin) / (cardWidth + space));
                int cardsInY = Convert.ToInt16((mm2point(297) + space - doc.BottomMargin - doc.TopMargin) / (cardHeight + space));
                float reverse_margin = mm2point(210) + space - cardsInX * (cardWidth + space) - doc.LeftMargin;
                int x = 0;
                int y = 0;
                int a = (cards.Count - (cards.Count % (cardsInX * cardsInY)));

                List<Card> temp = new List<Card>();

                doc.NewPage();
                for (int i = 0; i < cards.Count; i++)
                {
                    var img = iTextSharp.text.Image.GetInstance(cards[i].frontPath);
                    img.SetAbsolutePosition(doc.LeftMargin + x * (cards[i].width + space), doc.BottomMargin + y * (cards[i].height + space)); //dodac spaces

                    if (Image.FromFile(cards[i].frontPath).Height > Image.FromFile(cards[i].frontPath).Width)
                    {
                        img.ScaleAbsolute(cardWidth, cardHeight);
                    }
                    else
                    {
                        img.RotationDegrees = 90;
                        img.ScaleAbsolute(cardHeight, cardWidth);
                    }

                    cb.AddImage(img);
                    temp.Add(cards[i]);
                    x++;

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
                                reverse.SetAbsolutePosition((mm2point(210) - doc.LeftMargin - temp[z].width - x * (temp[z].width + space)), doc.BottomMargin + y * (temp[z].height + space)); //dodac spaces
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
                    else if (i >= a && i == cards.Count - 1) //gdy aktualna strona jest niezapelniona i przeanalizowalismy ostatnia karte
                    {
                        doc.NewPage();
                        y = 0;
                        x = 0;
                        for (int z = 0; z < temp.Count; z++)
                        {
                            var reverse = iTextSharp.text.Image.GetInstance(temp[z].reversePath);
                            reverse.SetAbsolutePosition((mm2point(210) - doc.LeftMargin - temp[z].width - x * (temp[z].width + space)), doc.BottomMargin + y * (temp[z].height + space)); //dodac spaces
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
                    }
                }
                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Utworzenie pliku nie powiodło się.");
            }
            MessageBox.Show("Plik pdf został utworzony!");
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            //dodaje obiekt nowej karty do listy kart do druku
            if (list_box.SelectedIndex != -1)
            {
                if (pic_back.ImageLocation == null)
                {
                    pic_back.ImageLocation = defaultReversePath;
                    pic_back.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                try
                {
                    Card c;
                    c = new Card();
                    c.frontPath = list_box.SelectedItem.ToString();
                    c.reversePath = pic_back.ImageLocation;
                    c.name = list_box.SelectedItem.ToString().Substring(c.frontPath.LastIndexOf("\\") + 1);
                    c.quantity = ud_quantity.Value;
                    c.width = float.Parse(tb_width.Text, System.Globalization.CultureInfo.InvariantCulture);
                    c.height = float.Parse(tb_height.Text, System.Globalization.CultureInfo.InvariantCulture);
                    for (int i = 1; i <= c.quantity; i++)
                    {
                        cards.Add(c);
                        list_box_c.Items.Add(c); //wyswietlenie tworzonych obiektow na drugiej liscie
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie udało się dodać karty");
                }
            }
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (list_box_c.SelectedIndex != -1)
            {
                object item = list_box_c.SelectedItem;
                //cards.RemoveAll(s => s.ToString() == item.ToString());
                cards.Remove((Card)item);
                list_box_c.Items.Remove(item);
            }
        }

        private void b_default_Click(object sender, EventArgs e)
        {
            //dodac jakieś wyrzucenie tego co juz jest ustawione jako obrazek
            try
            {
                pic_back.ImageLocation = defaultReversePath;
                pic_back.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie znaleziono pliku w domyślnej lokalizacji");
                b_customBack_Click(b_customBack,EventArgs.Empty);
            }
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
                pic_back.ImageLocation = dialog.FileName;
                pic_back.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coś sie nie udało");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            switch (MessageBox.Show(this, "Czy chcesz zapisać przygotowany schemat wydruku?", "Zapisać?", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    b_save_Click(b_save, EventArgs.Empty);
                    break;
                default:
                    break;
            }
            switch (MessageBox.Show(this, "Czy na pewno chcesz zamknąć program?", "Zamykanie...", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private bool XML_export(List<Card> c)
        {
            //zapisuje status do xml
            try
            {
                saveFileDialog2.ShowDialog();
                FileStream fs = new FileStream(saveFileDialog2.FileName, FileMode.OpenOrCreate);
                System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(List<Card>));
                s.Serialize(fs, c);
                fs.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zapisano");
                return false;
            }
        }

        private void b_load_Click(object sender, EventArgs e)
        {
            //wczytuje zapisany status z xml

            cards.Clear();
            list_box_c.Items.Clear();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*|XML Files (*.xml)|*.xml";
            dialog.InitialDirectory = defaultPath;
            dialog.Title = "Wybierz plik xml do wczytania";
            DialogResult result = dialog.ShowDialog();

            FileStream fs = new FileStream(dialog.FileName, FileMode.Open);
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(List<Card>));
            cards = (List<Card>)s.Deserialize(fs);

            for (int i = 0; i < cards.Count; i++)
            {
                list_box_c.Items.Add(cards[i]);
            }
            MessageBox.Show("Wczytano listę plików");
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            //uruchamia metode zapisu do xml
            XML_export(cards);
            MessageBox.Show("Zapisano listę plików");
        }
    }
}