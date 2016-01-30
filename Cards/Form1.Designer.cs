namespace Cards
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.list_box = new System.Windows.Forms.ListBox();
            this.b_katalog = new System.Windows.Forms.Button();
            this.b_generate = new System.Windows.Forms.Button();
            this.b_load = new System.Windows.Forms.Button();
            this.b_save = new System.Windows.Forms.Button();
            this.l_width = new System.Windows.Forms.Label();
            this.l_height = new System.Windows.Forms.Label();
            this.l_space = new System.Windows.Forms.Label();
            this.tb_width = new System.Windows.Forms.TextBox();
            this.tb_height = new System.Windows.Forms.TextBox();
            this.pic_front = new System.Windows.Forms.PictureBox();
            this.pic_back = new System.Windows.Forms.PictureBox();
            this.ud_quantity = new System.Windows.Forms.NumericUpDown();
            this.l_quantity = new System.Windows.Forms.Label();
            this.l_revers = new System.Windows.Forms.Label();
            this.b_default = new System.Windows.Forms.Button();
            this.b_customBack = new System.Windows.Forms.Button();
            this.b_add = new System.Windows.Forms.Button();
            this.list_box_c = new System.Windows.Forms.ListBox();
            this.b_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ud_spaces = new System.Windows.Forms.NumericUpDown();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pic_front)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_spaces)).BeginInit();
            this.SuspendLayout();
            // 
            // list_box
            // 
            this.list_box.FormattingEnabled = true;
            this.list_box.ItemHeight = 20;
            this.list_box.Location = new System.Drawing.Point(30, 106);
            this.list_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.list_box.Name = "list_box";
            this.list_box.Size = new System.Drawing.Size(319, 564);
            this.list_box.TabIndex = 0;
            this.list_box.SelectedIndexChanged += new System.EventHandler(this.list_box_SelectedIndexChanged);
            // 
            // b_katalog
            // 
            this.b_katalog.Location = new System.Drawing.Point(30, 25);
            this.b_katalog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.b_katalog.Name = "b_katalog";
            this.b_katalog.Size = new System.Drawing.Size(170, 68);
            this.b_katalog.TabIndex = 1;
            this.b_katalog.Text = "Wybierz katalog";
            this.b_katalog.UseVisualStyleBackColor = true;
            this.b_katalog.Click += new System.EventHandler(this.b_katalog_Click);
            // 
            // b_generate
            // 
            this.b_generate.Location = new System.Drawing.Point(1380, 592);
            this.b_generate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.b_generate.Name = "b_generate";
            this.b_generate.Size = new System.Drawing.Size(174, 80);
            this.b_generate.TabIndex = 2;
            this.b_generate.Text = "Generuj pdf";
            this.b_generate.UseVisualStyleBackColor = true;
            this.b_generate.Click += new System.EventHandler(this.b_generate_Click);
            // 
            // b_load
            // 
            this.b_load.Location = new System.Drawing.Point(1226, 592);
            this.b_load.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.b_load.Name = "b_load";
            this.b_load.Size = new System.Drawing.Size(146, 35);
            this.b_load.TabIndex = 3;
            this.b_load.Text = "Wczytaj układ";
            this.b_load.UseVisualStyleBackColor = true;
            this.b_load.Click += new System.EventHandler(this.b_load_Click);
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(1226, 637);
            this.b_save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(146, 35);
            this.b_save.TabIndex = 4;
            this.b_save.Text = "Zapisz układ";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // l_width
            // 
            this.l_width.AutoSize = true;
            this.l_width.Location = new System.Drawing.Point(386, 38);
            this.l_width.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_width.Name = "l_width";
            this.l_width.Size = new System.Drawing.Size(84, 20);
            this.l_width.TabIndex = 5;
            this.l_width.Text = "Szerokość";
            // 
            // l_height
            // 
            this.l_height.AutoSize = true;
            this.l_height.Location = new System.Drawing.Point(386, 77);
            this.l_height.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_height.Name = "l_height";
            this.l_height.Size = new System.Drawing.Size(81, 20);
            this.l_height.TabIndex = 6;
            this.l_height.Text = "Wysokość";
            // 
            // l_space
            // 
            this.l_space.AutoSize = true;
            this.l_space.Location = new System.Drawing.Point(608, 36);
            this.l_space.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_space.Name = "l_space";
            this.l_space.Size = new System.Drawing.Size(61, 20);
            this.l_space.TabIndex = 7;
            this.l_space.Text = "Odstęp";
            // 
            // tb_width
            // 
            this.tb_width.Location = new System.Drawing.Point(476, 34);
            this.tb_width.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_width.Name = "tb_width";
            this.tb_width.Size = new System.Drawing.Size(74, 26);
            this.tb_width.TabIndex = 9;
            this.tb_width.Text = "63";
            // 
            // tb_height
            // 
            this.tb_height.Location = new System.Drawing.Point(476, 68);
            this.tb_height.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_height.Name = "tb_height";
            this.tb_height.Size = new System.Drawing.Size(74, 26);
            this.tb_height.TabIndex = 10;
            this.tb_height.Text = "89";
            // 
            // pic_front
            // 
            this.pic_front.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_front.Location = new System.Drawing.Point(386, 108);
            this.pic_front.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_front.Name = "pic_front";
            this.pic_front.Size = new System.Drawing.Size(377, 547);
            this.pic_front.TabIndex = 12;
            this.pic_front.TabStop = false;
            // 
            // pic_back
            // 
            this.pic_back.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_back.Location = new System.Drawing.Point(812, 106);
            this.pic_back.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_back.Name = "pic_back";
            this.pic_back.Size = new System.Drawing.Size(377, 547);
            this.pic_back.TabIndex = 13;
            this.pic_back.TabStop = false;
            // 
            // ud_quantity
            // 
            this.ud_quantity.Location = new System.Drawing.Point(674, 68);
            this.ud_quantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ud_quantity.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.ud_quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_quantity.Name = "ud_quantity";
            this.ud_quantity.Size = new System.Drawing.Size(90, 26);
            this.ud_quantity.TabIndex = 15;
            this.ud_quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // l_quantity
            // 
            this.l_quantity.AutoSize = true;
            this.l_quantity.Location = new System.Drawing.Point(621, 80);
            this.l_quantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_quantity.Name = "l_quantity";
            this.l_quantity.Size = new System.Drawing.Size(42, 20);
            this.l_quantity.TabIndex = 16;
            this.l_quantity.Text = "Ilość";
            // 
            // l_revers
            // 
            this.l_revers.AutoSize = true;
            this.l_revers.Location = new System.Drawing.Point(812, 33);
            this.l_revers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_revers.Name = "l_revers";
            this.l_revers.Size = new System.Drawing.Size(67, 20);
            this.l_revers.TabIndex = 17;
            this.l_revers.Text = "Rewers:";
            // 
            // b_default
            // 
            this.b_default.Location = new System.Drawing.Point(885, 23);
            this.b_default.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.b_default.Name = "b_default";
            this.b_default.Size = new System.Drawing.Size(142, 55);
            this.b_default.TabIndex = 18;
            this.b_default.Text = "Domyślny";
            this.b_default.UseVisualStyleBackColor = true;
            this.b_default.Click += new System.EventHandler(this.b_default_Click);
            // 
            // b_customBack
            // 
            this.b_customBack.Location = new System.Drawing.Point(1036, 25);
            this.b_customBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.b_customBack.Name = "b_customBack";
            this.b_customBack.Size = new System.Drawing.Size(153, 54);
            this.b_customBack.TabIndex = 19;
            this.b_customBack.Text = "Wybierz inny";
            this.b_customBack.UseVisualStyleBackColor = true;
            this.b_customBack.Click += new System.EventHandler(this.b_customBack_Click);
            // 
            // b_add
            // 
            this.b_add.Location = new System.Drawing.Point(1230, 20);
            this.b_add.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(171, 58);
            this.b_add.TabIndex = 20;
            this.b_add.Text = "Dodaj pozycję";
            this.b_add.UseVisualStyleBackColor = true;
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // list_box_c
            // 
            this.list_box_c.FormattingEnabled = true;
            this.list_box_c.ItemHeight = 20;
            this.list_box_c.Location = new System.Drawing.Point(1226, 108);
            this.list_box_c.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.list_box_c.Name = "list_box_c";
            this.list_box_c.Size = new System.Drawing.Size(326, 464);
            this.list_box_c.TabIndex = 21;
            // 
            // b_delete
            // 
            this.b_delete.Location = new System.Drawing.Point(1410, 18);
            this.b_delete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(144, 60);
            this.b_delete.TabIndex = 22;
            this.b_delete.Text = "Usuń pozycję";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Znalezione pliki:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1231, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Pliki dodane do wydruku:";
            // 
            // ud_spaces
            // 
            this.ud_spaces.Location = new System.Drawing.Point(676, 35);
            this.ud_spaces.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ud_spaces.Name = "ud_spaces";
            this.ud_spaces.Size = new System.Drawing.Size(87, 26);
            this.ud_spaces.TabIndex = 25;
            this.toolTip1.SetToolTip(this.ud_spaces, "Przerwy między kartami na wydruku w mm (0-5)");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "\".pdf\"";
            this.saveFileDialog1.Filter = "\"Pdf files|*.pdf|All files|*.*\"";
            this.saveFileDialog1.InitialDirectory = "\"C/temp\"";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.DefaultExt = "\".xml\"";
            this.saveFileDialog2.Filter = "\"xml files|*.xml|All files|*.*\"";
            this.saveFileDialog2.InitialDirectory = "\"C/temp\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1588, 694);
            this.Controls.Add(this.ud_spaces);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_delete);
            this.Controls.Add(this.list_box_c);
            this.Controls.Add(this.b_add);
            this.Controls.Add(this.b_customBack);
            this.Controls.Add(this.b_default);
            this.Controls.Add(this.l_revers);
            this.Controls.Add(this.l_quantity);
            this.Controls.Add(this.ud_quantity);
            this.Controls.Add(this.pic_back);
            this.Controls.Add(this.pic_front);
            this.Controls.Add(this.tb_height);
            this.Controls.Add(this.tb_width);
            this.Controls.Add(this.l_space);
            this.Controls.Add(this.l_height);
            this.Controls.Add(this.l_width);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.b_load);
            this.Controls.Add(this.b_generate);
            this.Controls.Add(this.b_katalog);
            this.Controls.Add(this.list_box);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1610, 750);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Generator wydruku kart";
            ((System.ComponentModel.ISupportInitialize)(this.pic_front)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_spaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox list_box;
        private System.Windows.Forms.Button b_katalog;
        private System.Windows.Forms.Button b_generate;
        private System.Windows.Forms.Button b_load;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Label l_width;
        private System.Windows.Forms.Label l_height;
        private System.Windows.Forms.Label l_space;
        private System.Windows.Forms.TextBox tb_width;
        private System.Windows.Forms.TextBox tb_height;
        private System.Windows.Forms.PictureBox pic_front;
        private System.Windows.Forms.PictureBox pic_back;
        private System.Windows.Forms.NumericUpDown ud_quantity;
        private System.Windows.Forms.Label l_quantity;
        private System.Windows.Forms.Label l_revers;
        private System.Windows.Forms.Button b_default;
        private System.Windows.Forms.Button b_customBack;
        private System.Windows.Forms.Button b_add;
        private System.Windows.Forms.ListBox list_box_c;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NumericUpDown ud_spaces;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    }
}

