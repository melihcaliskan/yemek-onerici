namespace LoginApp
{
    partial class gununYemegi
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.isim_label = new System.Windows.Forms.Label();
            this.malzeme_label = new System.Windows.Forms.Label();
            this.selectDayComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yapilis_lbl = new System.Windows.Forms.Label();
            this.yapilis_text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(74, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(29, 117);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(202, 219);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 219);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // isim_label
            // 
            this.isim_label.AutoSize = true;
            this.isim_label.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isim_label.Location = new System.Drawing.Point(26, 70);
            this.isim_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.isim_label.Name = "isim_label";
            this.isim_label.Size = new System.Drawing.Size(51, 24);
            this.isim_label.TabIndex = 3;
            this.isim_label.Text = "İsim:";
            // 
            // malzeme_label
            // 
            this.malzeme_label.AutoSize = true;
            this.malzeme_label.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.malzeme_label.Location = new System.Drawing.Point(285, 117);
            this.malzeme_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.malzeme_label.Name = "malzeme_label";
            this.malzeme_label.Size = new System.Drawing.Size(102, 22);
            this.malzeme_label.TabIndex = 4;
            this.malzeme_label.Text = "Malzemeler:";
            // 
            // selectDayComboBox
            // 
            this.selectDayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectDayComboBox.FormattingEnabled = true;
            this.selectDayComboBox.Location = new System.Drawing.Point(91, 24);
            this.selectDayComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.selectDayComboBox.Name = "selectDayComboBox";
            this.selectDayComboBox.Size = new System.Drawing.Size(81, 21);
            this.selectDayComboBox.TabIndex = 5;
            this.selectDayComboBox.SelectedIndexChanged += new System.EventHandler(this.selectDayComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Gün seçin:";
            // 
            // yapilis_lbl
            // 
            this.yapilis_lbl.AutoSize = true;
            this.yapilis_lbl.Font = new System.Drawing.Font("Trebuchet MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yapilis_lbl.Location = new System.Drawing.Point(442, 117);
            this.yapilis_lbl.Name = "yapilis_lbl";
            this.yapilis_lbl.Size = new System.Drawing.Size(70, 23);
            this.yapilis_lbl.TabIndex = 7;
            this.yapilis_lbl.Text = "Yapılışı:";
            // 
            // yapilis_text
            // 
            this.yapilis_text.AutoSize = true;
            this.yapilis_text.Location = new System.Drawing.Point(452, 153);
            this.yapilis_text.Name = "yapilis_text";
            this.yapilis_text.Size = new System.Drawing.Size(35, 13);
            this.yapilis_text.TabIndex = 8;
            this.yapilis_text.Text = "label3";
            // 
            // gununYemegi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(784, 403);
            this.Controls.Add(this.yapilis_text);
            this.Controls.Add(this.yapilis_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectDayComboBox);
            this.Controls.Add(this.malzeme_label);
            this.Controls.Add(this.isim_label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "gununYemegi";
            this.Text = "Günün Yemeği";
            this.Load += new System.EventHandler(this.gununYemegi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label isim_label;
        private System.Windows.Forms.Label malzeme_label;
        private System.Windows.Forms.ComboBox selectDayComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label yapilis_lbl;
        private System.Windows.Forms.Label yapilis_text;
    }
}