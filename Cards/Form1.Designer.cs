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
            this.list_box = new System.Windows.Forms.ListBox();
            this.b_katalog = new System.Windows.Forms.Button();
            this.b_generate = new System.Windows.Forms.Button();
            this.b_load = new System.Windows.Forms.Button();
            this.b_save = new System.Windows.Forms.Button();
            this.l_width = new System.Windows.Forms.Label();
            this.l_height = new System.Windows.Forms.Label();
            this.l_space = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tb_space = new System.Windows.Forms.TextBox();
            this.pic_front = new System.Windows.Forms.PictureBox();
            this.pic_back = new System.Windows.Forms.PictureBox();
            this.ud_quantity = new System.Windows.Forms.NumericUpDown();
            this.l_quantity = new System.Windows.Forms.Label();
            this.l_revers = new System.Windows.Forms.Label();
            this.b_default = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.b_add = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_front)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // list_box
            // 
            this.list_box.FormattingEnabled = true;
            this.list_box.Location = new System.Drawing.Point(34, 132);
            this.list_box.Name = "list_box";
            this.list_box.Size = new System.Drawing.Size(242, 368);
            this.list_box.TabIndex = 0;
            this.list_box.SelectedIndexChanged += new System.EventHandler(this.list_box_SelectedIndexChanged);
            // 
            // b_katalog
            // 
            this.b_katalog.Location = new System.Drawing.Point(34, 32);
            this.b_katalog.Name = "b_katalog";
            this.b_katalog.Size = new System.Drawing.Size(75, 23);
            this.b_katalog.TabIndex = 1;
            this.b_katalog.Text = "Katalog";
            this.b_katalog.UseVisualStyleBackColor = true;
            this.b_katalog.Click += new System.EventHandler(this.b_katalog_Click);
            // 
            // b_generate
            // 
            this.b_generate.Location = new System.Drawing.Point(827, 520);
            this.b_generate.Name = "b_generate";
            this.b_generate.Size = new System.Drawing.Size(75, 23);
            this.b_generate.TabIndex = 2;
            this.b_generate.Text = "Generuj pdf";
            this.b_generate.UseVisualStyleBackColor = true;
            this.b_generate.Click += new System.EventHandler(this.b_generate_Click_1);
            // 
            // b_load
            // 
            this.b_load.Location = new System.Drawing.Point(141, 29);
            this.b_load.Name = "b_load";
            this.b_load.Size = new System.Drawing.Size(75, 23);
            this.b_load.TabIndex = 3;
            this.b_load.Text = "Wczytaj";
            this.b_load.UseVisualStyleBackColor = true;
            this.b_load.Click += new System.EventHandler(this.b_load_Click);
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(141, 59);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 4;
            this.b_save.Text = "Zapisz";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // l_width
            // 
            this.l_width.AutoSize = true;
            this.l_width.Location = new System.Drawing.Point(254, 33);
            this.l_width.Name = "l_width";
            this.l_width.Size = new System.Drawing.Size(57, 13);
            this.l_width.TabIndex = 5;
            this.l_width.Text = "Szerokość";
            // 
            // l_height
            // 
            this.l_height.AutoSize = true;
            this.l_height.Location = new System.Drawing.Point(254, 65);
            this.l_height.Name = "l_height";
            this.l_height.Size = new System.Drawing.Size(57, 13);
            this.l_height.TabIndex = 6;
            this.l_height.Text = "Wysokość";
            // 
            // l_space
            // 
            this.l_space.AutoSize = true;
            this.l_space.Location = new System.Drawing.Point(394, 32);
            this.l_space.Name = "l_space";
            this.l_space.Size = new System.Drawing.Size(41, 13);
            this.l_space.TabIndex = 7;
            this.l_space.Text = "Odstęp";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(317, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "63";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(317, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(51, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "89";
            // 
            // tb_space
            // 
            this.tb_space.Location = new System.Drawing.Point(441, 29);
            this.tb_space.Name = "tb_space";
            this.tb_space.Size = new System.Drawing.Size(57, 20);
            this.tb_space.TabIndex = 11;
            this.tb_space.Text = "10";
            // 
            // pic_front
            // 
            this.pic_front.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_front.Location = new System.Drawing.Point(317, 133);
            this.pic_front.Name = "pic_front";
            this.pic_front.Size = new System.Drawing.Size(252, 356);
            this.pic_front.TabIndex = 12;
            this.pic_front.TabStop = false;
            // 
            // pic_back
            // 
            this.pic_back.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_back.Location = new System.Drawing.Point(601, 132);
            this.pic_back.Name = "pic_back";
            this.pic_back.Size = new System.Drawing.Size(252, 356);
            this.pic_back.TabIndex = 13;
            this.pic_back.TabStop = false;
            // 
            // ud_quantity
            // 
            this.ud_quantity.Location = new System.Drawing.Point(718, 26);
            this.ud_quantity.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.ud_quantity.Name = "ud_quantity";
            this.ud_quantity.Size = new System.Drawing.Size(60, 20);
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
            this.l_quantity.Location = new System.Drawing.Point(680, 29);
            this.l_quantity.Name = "l_quantity";
            this.l_quantity.Size = new System.Drawing.Size(32, 13);
            this.l_quantity.TabIndex = 16;
            this.l_quantity.Text = "Ilość:";
            // 
            // l_revers
            // 
            this.l_revers.AutoSize = true;
            this.l_revers.Location = new System.Drawing.Point(524, 29);
            this.l_revers.Name = "l_revers";
            this.l_revers.Size = new System.Drawing.Size(46, 13);
            this.l_revers.TabIndex = 17;
            this.l_revers.Text = "Rewers:";
            // 
            // b_default
            // 
            this.b_default.Location = new System.Drawing.Point(576, 24);
            this.b_default.Name = "b_default";
            this.b_default.Size = new System.Drawing.Size(75, 23);
            this.b_default.TabIndex = 18;
            this.b_default.Text = "Domyślny";
            this.b_default.UseVisualStyleBackColor = true;
            this.b_default.Click += new System.EventHandler(this.b_default_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(576, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Wybierz inny";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // b_add
            // 
            this.b_add.Location = new System.Drawing.Point(842, 29);
            this.b_add.Name = "b_add";
            this.b_add.Size = new System.Drawing.Size(75, 23);
            this.b_add.TabIndex = 20;
            this.b_add.Text = "Dodaj";
            this.b_add.UseVisualStyleBackColor = true;
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(877, 133);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(259, 368);
            this.listBox1.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 666);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.b_add);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.b_default);
            this.Controls.Add(this.l_revers);
            this.Controls.Add(this.l_quantity);
            this.Controls.Add(this.ud_quantity);
            this.Controls.Add(this.pic_back);
            this.Controls.Add(this.pic_front);
            this.Controls.Add(this.tb_space);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.l_space);
            this.Controls.Add(this.l_height);
            this.Controls.Add(this.l_width);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.b_load);
            this.Controls.Add(this.b_generate);
            this.Controls.Add(this.b_katalog);
            this.Controls.Add(this.list_box);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic_front)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_quantity)).EndInit();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tb_space;
        private System.Windows.Forms.PictureBox pic_front;
        private System.Windows.Forms.PictureBox pic_back;
        private System.Windows.Forms.NumericUpDown ud_quantity;
        private System.Windows.Forms.Label l_quantity;
        private System.Windows.Forms.Label l_revers;
        private System.Windows.Forms.Button b_default;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button b_add;
        private System.Windows.Forms.ListBox listBox1;
    }
}

