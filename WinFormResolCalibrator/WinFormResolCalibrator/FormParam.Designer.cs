namespace WinFormResolCalibrator
{
    partial class FormParam
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lbThreholdValue = new Label();
            label1 = new Label();
            trbThreshold = new TrackBar();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbThreshold).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5838928F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.4161072F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 73F));
            tableLayoutPanel1.Controls.Add(lbThreholdValue, 2, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(trbThreshold, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(comboBox1, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45.3125F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 54.6875F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel1.Size = new Size(427, 106);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // lbThreholdValue
            // 
            lbThreholdValue.Anchor = AnchorStyles.None;
            lbThreholdValue.AutoSize = true;
            lbThreholdValue.Location = new Point(314, 37);
            lbThreholdValue.Name = "lbThreholdValue";
            lbThreholdValue.Size = new Size(28, 15);
            lbThreholdValue.TabIndex = 5;
            lbThreholdValue.Text = "125";
            lbThreholdValue.Click += lbThreholdValue_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 4);
            label1.Location = new Point(181, 6);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Parameter";
            // 
            // trbThreshold
            // 
            trbThreshold.Dock = DockStyle.Fill;
            trbThreshold.Location = new Point(117, 31);
            trbThreshold.Maximum = 255;
            trbThreshold.Name = "trbThreshold";
            trbThreshold.Size = new Size(183, 28);
            trbThreshold.TabIndex = 1;
            trbThreshold.Value = 125;
            trbThreshold.Scroll += trbThreshold_Scroll;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(25, 37);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Threshold";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(10, 76);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 3;
            label3.Text = "Datum Position";
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Edge", "Center" });
            comboBox1.Location = new Point(117, 65);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(183, 24);
            comboBox1.TabIndex = 4;
            // 
            // FormParam
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 106);
            Controls.Add(tableLayoutPanel1);
            Name = "FormParam";
            Text = "FormParam";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbThreshold).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TrackBar trbThreshold;
        private Label label2;
        private Label label3;
        private Label lbThreholdValue;
        private ComboBox comboBox1;
    }
}