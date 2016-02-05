using System;
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
        }
    }

    [Serializable]
    [XmlRoot("Form1")]
    [XmlInclude(typeof(Card))]
    public partial class Form1 : Form
    {
        [XmlArray("CardList"), XmlArrayItem(typeof(Card), ElementName = "Card")]
        public List<Card> cards { get; set; }

        string frontsDefaultPath = Path.GetFullPath(Application.StartupPath.ToString() + @"..\..\..\..\resources\fronts").ToString();
        string reversesPath = Path.GetFullPath(Application.StartupPath.ToString() + @"..\..\..\..\resources\back").ToString();
        string defaultReversePath = Path.GetFullPath(Application.StartupPath.ToString() + @"..\..\..\..\resources\back\back_default.png").ToString();
        string defaultPath = @"C:\temp";

        public Form1()
        {
            InitializeComponent();
            cards = new List<Card>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b_catalog.Focus();
            pic_front.ImageLocation = Path.GetFullPath(Application.StartupPath.ToString() + @"..\..\..\..\resources\defaultFront.jpg").ToString();
            pic_front.SizeMode = PictureBoxSizeMode.Zoom;
            pic_back.ImageLocation = Path.GetFullPath(Application.StartupPath.ToString() + @"..\..\..\..\resources\defaultBack.jpg").ToString();
            pic_back.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void b_catalog_Click(object sender, EventArgs e)
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
                MessageBox.Show("Plik pdf został utworzony!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Utworzenie pliku nie powiodło się.");
            }
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
            //zapisuje status parsując do xml
            try
            {
                saveFileDialog2.ShowDialog();
                FileStream fs = new FileStream(saveFileDialog2.FileName, FileMode.OpenOrCreate);
                System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(List<Card>));
                s.Serialize(fs, c);
                fs.Dispose();
                MessageBox.Show("Zapisano listę plików");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie zapisano!");
                return false;
            }
        }

        private void b_load_Click(object sender, EventArgs e)
        {
            //wczytuje zapisany status deparsując z xml
            cards.Clear();
            list_box_c.Items.Clear();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*|XML Files (*.xml)|*.xml";
            dialog.InitialDirectory = defaultPath;
            dialog.Title = "Wybierz plik xml do wczytania";
            DialogResult result = dialog.ShowDialog();
            try
            {
                FileStream fs = new FileStream(dialog.FileName, FileMode.Open);
                System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(List<Card>));
                cards = (List<Card>)s.Deserialize(fs);
                MessageBox.Show("Wczytano listę plików");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania pliku");
            }

            for (int i = 0; i < cards.Count; i++)
            {
                list_box_c.Items.Add(cards[i]);
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            //uruchamia metode zapisu do xml
            XML_export(cards);
        }

        private void list_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && list_box.SelectedIndex != -1)
            {
                    b_add_Click(b_add, EventArgs.Empty);
            }
            if ((e.KeyCode == Keys.D1 | e.KeyCode == Keys.NumPad1) && list_box.SelectedIndex != -1)
            {
                ud_quantity.Value = 1;
            }
            if ((e.KeyCode == Keys.D2 | e.KeyCode == Keys.NumPad2) && list_box.SelectedIndex != -1)
            {
                ud_quantity.Value = 2;
            }
            if ((e.KeyCode == Keys.D3 | e.KeyCode == Keys.NumPad3) && list_box.SelectedIndex != -1)
            {
                ud_quantity.Value = 3;
            } 
            if ((e.KeyCode == Keys.D4 | e.KeyCode == Keys.NumPad4) && list_box.SelectedIndex != -1)
            {
                ud_quantity.Value = 4;
            }
            if ((e.KeyCode == Keys.D5 | e.KeyCode == Keys.NumPad5) && list_box.SelectedIndex != -1)
            {
                ud_quantity.Value = 5;
            }
            if ((e.KeyCode == Keys.D6 | e.KeyCode == Keys.NumPad6) && list_box.SelectedIndex != -1)
            {
                ud_quantity.Value = 6;
            }
            if ((e.KeyCode == Keys.D7 | e.KeyCode == Keys.NumPad7) && list_box.SelectedIndex != -1)
            {
                ud_quantity.Value = 7;
            }
            if ((e.KeyCode == Keys.D8 | e.KeyCode == Keys.NumPad8) && list_box.SelectedIndex != -1)
            {
                ud_quantity.Value = 8;
            }
            if ((e.KeyCode == Keys.D9 | e.KeyCode == Keys.NumPad9) && list_box.SelectedIndex != -1)
            {
                ud_quantity.Value = 9;
            }
        }

    }
}