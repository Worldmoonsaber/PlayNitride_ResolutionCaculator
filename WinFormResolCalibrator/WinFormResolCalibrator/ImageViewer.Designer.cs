namespace KaiwaProjects
{
    partial class KpImageViewer
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
            DisposeControl();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnMode = new Button();
            btnPreview = new Button();
            cbZoom = new ComboBox();
            btnZoomIn = new Button();
            btnZoomOut = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelNavigation = new Panel();
            lblNavigation = new Label();
            tbNavigation = new TextBox();
            btnBack = new Button();
            btnNext = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnOpen = new Button();
            pbFull = new PanelDoubleBuffered();
            cms = new ContextMenuStrip(components);
            openImageToolStripMenuItem = new ToolStripMenuItem();
            fitImageToolStripMenuItem = new ToolStripMenuItem();
            previewWindowToolStripMenuItem = new ToolStripMenuItem();
            selectModeToolStripMenuItem = new ToolStripMenuItem();
            tsmiDrag = new ToolStripMenuItem();
            tsmiMeasure = new ToolStripMenuItem();
            measureParameterToolStripMenuItem = new ToolStripMenuItem();
            pnlParameter = new Panel();
            groupBox1 = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            tlpColorDifferent = new TableLayoutPanel();
            tbcMethod = new TabControl();
            tpEdge = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            label4 = new Label();
            nudLineSize = new NumericUpDown();
            label3 = new Label();
            cbbSelectSide = new ComboBox();
            tpLineCenter = new TabPage();
            tableLayoutPanel6 = new TableLayoutPanel();
            label1 = new Label();
            nudLineWidthFilter = new NumericUpDown();
            lbThreholdValue = new Label();
            label2 = new Label();
            trbThreshold = new TrackBar();
            cbInvertThreshold = new CheckBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            rbColorisSimiliar = new RadioButton();
            rbColorDifferent = new RadioButton();
            sbVert = new VScrollBar();
            sbHoriz = new HScrollBar();
            sbPanel = new Panel();
            pbPanel = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            panelNavigation.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pbFull.SuspendLayout();
            cms.SuspendLayout();
            pnlParameter.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tlpColorDifferent.SuspendLayout();
            tbcMethod.SuspendLayout();
            tpEdge.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudLineSize).BeginInit();
            tpLineCenter.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudLineWidthFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbThreshold).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPanel).BeginInit();
            SuspendLayout();
            // 
            // btnMode
            // 
            btnMode.Location = new Point(-34, 4);
            btnMode.Margin = new Padding(4);
            btnMode.Name = "btnMode";
            btnMode.Size = new Size(12, 1);
            btnMode.TabIndex = 16;
            btnMode.Text = "Mode";
            btnMode.UseVisualStyleBackColor = true;
            btnMode.Click += btnMode_Click;
            // 
            // btnPreview
            // 
            btnPreview.Location = new Point(-7, 4);
            btnPreview.Margin = new Padding(4);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(1, 1);
            btnPreview.TabIndex = 15;
            btnPreview.Text = "Privew";
            btnPreview.UseVisualStyleBackColor = true;
            btnPreview.Visible = false;
            btnPreview.Click += btnPreview_Click;
            // 
            // cbZoom
            // 
            cbZoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbZoom.FormattingEnabled = true;
            cbZoom.Location = new Point(-14, 4);
            cbZoom.Margin = new Padding(4);
            cbZoom.Name = "cbZoom";
            cbZoom.Size = new Size(12, 23);
            cbZoom.TabIndex = 14;
            cbZoom.SelectedIndexChanged += cbZoom_SelectedIndexChanged;
            cbZoom.KeyPress += cbZoom_KeyPress;
            // 
            // btnZoomIn
            // 
            btnZoomIn.Location = new Point(-74, 4);
            btnZoomIn.Margin = new Padding(4);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new Size(12, 1);
            btnZoomIn.TabIndex = 12;
            btnZoomIn.Text = "ZoomIn";
            btnZoomIn.UseVisualStyleBackColor = true;
            btnZoomIn.Click += btnZoomIn_Click;
            // 
            // btnZoomOut
            // 
            btnZoomOut.Location = new Point(-54, 4);
            btnZoomOut.Margin = new Padding(4);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new Size(12, 1);
            btnZoomOut.TabIndex = 11;
            btnZoomOut.Text = "ZoomOut";
            btnZoomOut.UseVisualStyleBackColor = true;
            btnZoomOut.Click += btnZoomOut_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F));
            tableLayoutPanel1.Controls.Add(panelNavigation, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(pbFull, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
            tableLayoutPanel1.Size = new Size(530, 358);
            tableLayoutPanel1.TabIndex = 17;
            // 
            // panelNavigation
            // 
            panelNavigation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelNavigation.BackColor = Color.LightSteelBlue;
            panelNavigation.BorderStyle = BorderStyle.FixedSingle;
            panelNavigation.Controls.Add(lblNavigation);
            panelNavigation.Controls.Add(tbNavigation);
            panelNavigation.Controls.Add(btnBack);
            panelNavigation.Controls.Add(btnNext);
            panelNavigation.Location = new Point(350, 361);
            panelNavigation.Margin = new Padding(4);
            panelNavigation.Name = "panelNavigation";
            panelNavigation.Size = new Size(175, 1);
            panelNavigation.TabIndex = 13;
            panelNavigation.Visible = false;
            // 
            // lblNavigation
            // 
            lblNavigation.AutoSize = true;
            lblNavigation.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNavigation.ForeColor = SystemColors.ButtonHighlight;
            lblNavigation.Location = new Point(48, 6);
            lblNavigation.Margin = new Padding(4, 0, 4, 0);
            lblNavigation.Name = "lblNavigation";
            lblNavigation.Size = new Size(24, 18);
            lblNavigation.TabIndex = 1;
            lblNavigation.Text = "/ 0";
            // 
            // tbNavigation
            // 
            tbNavigation.Location = new Point(5, 5);
            tbNavigation.Margin = new Padding(4);
            tbNavigation.Name = "tbNavigation";
            tbNavigation.Size = new Size(38, 23);
            tbNavigation.TabIndex = 19;
            tbNavigation.Text = "0";
            tbNavigation.TextAlign = HorizontalAlignment.Center;
            tbNavigation.KeyPress += tbNavigation_KeyPress;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(108, 1);
            btnBack.Margin = new Padding(4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(29, 29);
            btnBack.TabIndex = 18;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(141, 1);
            btnNext.Margin = new Padding(4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(29, 29);
            btnNext.TabIndex = 17;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(cbZoom, 5, 0);
            tableLayoutPanel2.Controls.Add(btnMode, 4, 0);
            tableLayoutPanel2.Controls.Add(btnOpen, 0, 0);
            tableLayoutPanel2.Controls.Add(btnPreview, 1, 0);
            tableLayoutPanel2.Controls.Add(btnZoomOut, 3, 0);
            tableLayoutPanel2.Controls.Add(btnZoomIn, 2, 0);
            tableLayoutPanel2.Location = new Point(532, 360);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1, 1);
            tableLayoutPanel2.TabIndex = 14;
            tableLayoutPanel2.Visible = false;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(3, 3);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(1, 1);
            btnOpen.TabIndex = 0;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            // 
            // pbFull
            // 
            pbFull.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbFull.BackColor = SystemColors.ControlLight;
            pbFull.BorderStyle = BorderStyle.FixedSingle;
            pbFull.ContextMenuStrip = cms;
            pbFull.Controls.Add(pnlParameter);
            pbFull.Controls.Add(sbVert);
            pbFull.Controls.Add(sbHoriz);
            pbFull.Controls.Add(sbPanel);
            pbFull.Controls.Add(pbPanel);
            pbFull.Location = new Point(4, 4);
            pbFull.Margin = new Padding(4);
            pbFull.Name = "pbFull";
            pbFull.Size = new Size(521, 349);
            pbFull.TabIndex = 13;
            pbFull.Click += pbFull_Click;
            pbFull.DragDrop += pbFull_DragDrop;
            pbFull.DragEnter += pbFull_DragEnter;
            pbFull.Paint += pbFull_Paint;
            pbFull.MouseDoubleClick += pbFull_MouseDoubleClick;
            pbFull.MouseDown += pbFull_MouseDown;
            pbFull.MouseEnter += pbFull_MouseEnter;
            pbFull.MouseLeave += pbFull_MouseLeave;
            pbFull.MouseHover += pbFull_MouseHover;
            pbFull.MouseMove += pbFull_MouseMove;
            pbFull.MouseUp += pbFull_MouseUp;
            // 
            // cms
            // 
            cms.Items.AddRange(new ToolStripItem[] { openImageToolStripMenuItem, fitImageToolStripMenuItem, previewWindowToolStripMenuItem, selectModeToolStripMenuItem, measureParameterToolStripMenuItem });
            cms.Name = "cms";
            cms.Size = new Size(168, 114);
            // 
            // openImageToolStripMenuItem
            // 
            openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            openImageToolStripMenuItem.Size = new Size(167, 22);
            openImageToolStripMenuItem.Text = "Open Image";
            openImageToolStripMenuItem.Click += btnOpen_Click;
            // 
            // fitImageToolStripMenuItem
            // 
            fitImageToolStripMenuItem.Name = "fitImageToolStripMenuItem";
            fitImageToolStripMenuItem.Size = new Size(167, 22);
            fitImageToolStripMenuItem.Text = "Fit Image";
            fitImageToolStripMenuItem.Click += btnFitToScreen_Click;
            // 
            // previewWindowToolStripMenuItem
            // 
            previewWindowToolStripMenuItem.Checked = true;
            previewWindowToolStripMenuItem.CheckOnClick = true;
            previewWindowToolStripMenuItem.CheckState = CheckState.Checked;
            previewWindowToolStripMenuItem.Name = "previewWindowToolStripMenuItem";
            previewWindowToolStripMenuItem.Size = new Size(167, 22);
            previewWindowToolStripMenuItem.Text = "Preview Window";
            previewWindowToolStripMenuItem.Click += btnPreview_Click;
            // 
            // selectModeToolStripMenuItem
            // 
            selectModeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiDrag, tsmiMeasure });
            selectModeToolStripMenuItem.Name = "selectModeToolStripMenuItem";
            selectModeToolStripMenuItem.Size = new Size(167, 22);
            selectModeToolStripMenuItem.Text = "Select Mode";
            selectModeToolStripMenuItem.Click += btnMode_Click;
            // 
            // tsmiDrag
            // 
            tsmiDrag.Checked = true;
            tsmiDrag.CheckOnClick = true;
            tsmiDrag.CheckState = CheckState.Checked;
            tsmiDrag.Name = "tsmiDrag";
            tsmiDrag.Size = new Size(123, 22);
            tsmiDrag.Text = "Drag";
            tsmiDrag.Click += tsmiStatusChange_Click;
            // 
            // tsmiMeasure
            // 
            tsmiMeasure.CheckOnClick = true;
            tsmiMeasure.Name = "tsmiMeasure";
            tsmiMeasure.Size = new Size(123, 22);
            tsmiMeasure.Text = "Measure";
            tsmiMeasure.Click += tsmiStatusChange_Click;
            // 
            // measureParameterToolStripMenuItem
            // 
            measureParameterToolStripMenuItem.CheckOnClick = true;
            measureParameterToolStripMenuItem.Name = "measureParameterToolStripMenuItem";
            measureParameterToolStripMenuItem.Size = new Size(167, 22);
            measureParameterToolStripMenuItem.Text = "Measure Setting";
            measureParameterToolStripMenuItem.Click += measureParameterToolStripMenuItem_Click;
            // 
            // pnlParameter
            // 
            pnlParameter.Controls.Add(groupBox1);
            pnlParameter.Location = new Point(216, 146);
            pnlParameter.Name = "pnlParameter";
            pnlParameter.Size = new Size(309, 205);
            pnlParameter.TabIndex = 11;
            pnlParameter.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel3);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(309, 205);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Parameter";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.04762F));
            tableLayoutPanel3.Controls.Add(tlpColorDifferent, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 19);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 4.371585F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 95.62842F));
            tableLayoutPanel3.Size = new Size(303, 183);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // tlpColorDifferent
            // 
            tlpColorDifferent.ColumnCount = 3;
            tlpColorDifferent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.19774F));
            tlpColorDifferent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.80226F));
            tlpColorDifferent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 77F));
            tlpColorDifferent.Controls.Add(tbcMethod, 0, 2);
            tlpColorDifferent.Controls.Add(lbThreholdValue, 2, 0);
            tlpColorDifferent.Controls.Add(label2, 0, 0);
            tlpColorDifferent.Controls.Add(trbThreshold, 1, 0);
            tlpColorDifferent.Controls.Add(cbInvertThreshold, 0, 1);
            tlpColorDifferent.Dock = DockStyle.Fill;
            tlpColorDifferent.Location = new Point(3, 11);
            tlpColorDifferent.Name = "tlpColorDifferent";
            tlpColorDifferent.RowCount = 4;
            tlpColorDifferent.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpColorDifferent.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpColorDifferent.RowStyles.Add(new RowStyle(SizeType.Percent, 60.9699745F));
            tlpColorDifferent.RowStyles.Add(new RowStyle(SizeType.Percent, 39.0300255F));
            tlpColorDifferent.Size = new Size(297, 169);
            tlpColorDifferent.TabIndex = 0;
            // 
            // tbcMethod
            // 
            tlpColorDifferent.SetColumnSpan(tbcMethod, 3);
            tbcMethod.Controls.Add(tpEdge);
            tbcMethod.Controls.Add(tpLineCenter);
            tbcMethod.Dock = DockStyle.Fill;
            tbcMethod.Location = new Point(3, 63);
            tbcMethod.Name = "tbcMethod";
            tlpColorDifferent.SetRowSpan(tbcMethod, 2);
            tbcMethod.SelectedIndex = 0;
            tbcMethod.Size = new Size(291, 103);
            tbcMethod.TabIndex = 12;
            tbcMethod.SelectedIndexChanged += tbcMethod_SelectedIndexChanged;
            // 
            // tpEdge
            // 
            tpEdge.Controls.Add(tableLayoutPanel4);
            tpEdge.Location = new Point(4, 24);
            tpEdge.Name = "tpEdge";
            tpEdge.Padding = new Padding(3);
            tpEdge.Size = new Size(283, 75);
            tpEdge.TabIndex = 0;
            tpEdge.Text = "Edge Method";
            tpEdge.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(label4, 0, 0);
            tableLayoutPanel4.Controls.Add(nudLineSize, 1, 0);
            tableLayoutPanel4.Controls.Add(label3, 0, 1);
            tableLayoutPanel4.Controls.Add(cbbSelectSide, 1, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(277, 69);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(39, 9);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 11;
            label4.Text = "Filter Size";
            // 
            // nudLineSize
            // 
            nudLineSize.Dock = DockStyle.Fill;
            nudLineSize.Location = new Point(141, 3);
            nudLineSize.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudLineSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudLineSize.Name = "nudLineSize";
            nudLineSize.Size = new Size(133, 23);
            nudLineSize.TabIndex = 14;
            nudLineSize.Value = new decimal(new int[] { 10, 0, 0, 0 });
            nudLineSize.ValueChanged += nudLineSize_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(34, 44);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 12;
            label3.Text = "Select Side";
            // 
            // cbbSelectSide
            // 
            cbbSelectSide.Dock = DockStyle.Fill;
            cbbSelectSide.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbSelectSide.FormattingEnabled = true;
            cbbSelectSide.Items.AddRange(new object[] { "Right/Down", "Left/Up" });
            cbbSelectSide.Location = new Point(141, 37);
            cbbSelectSide.Name = "cbbSelectSide";
            cbbSelectSide.Size = new Size(133, 23);
            cbbSelectSide.TabIndex = 13;
            cbbSelectSide.SelectedIndexChanged += cbbSelectSide_SelectedIndexChanged;
            // 
            // tpLineCenter
            // 
            tpLineCenter.Controls.Add(tableLayoutPanel6);
            tpLineCenter.Location = new Point(4, 24);
            tpLineCenter.Name = "tpLineCenter";
            tpLineCenter.Padding = new Padding(3);
            tpLineCenter.Size = new Size(283, 75);
            tpLineCenter.TabIndex = 1;
            tpLineCenter.Text = "Center Method";
            tpLineCenter.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(label1, 0, 0);
            tableLayoutPanel6.Controls.Add(nudLineWidthFilter, 1, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(277, 69);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(20, 9);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Line Width Filter";
            // 
            // nudLineWidthFilter
            // 
            nudLineWidthFilter.Dock = DockStyle.Fill;
            nudLineWidthFilter.Location = new Point(141, 3);
            nudLineWidthFilter.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudLineWidthFilter.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            nudLineWidthFilter.Name = "nudLineWidthFilter";
            nudLineWidthFilter.Size = new Size(133, 23);
            nudLineWidthFilter.TabIndex = 2;
            nudLineWidthFilter.Value = new decimal(new int[] { 35, 0, 0, 0 });
            nudLineWidthFilter.ValueChanged += nudLineWidth_ValueChanged;
            // 
            // lbThreholdValue
            // 
            lbThreholdValue.Anchor = AnchorStyles.None;
            lbThreholdValue.AutoSize = true;
            lbThreholdValue.Location = new Point(244, 7);
            lbThreholdValue.Name = "lbThreholdValue";
            lbThreholdValue.Size = new Size(28, 15);
            lbThreholdValue.TabIndex = 5;
            lbThreholdValue.Text = "125";
            lbThreholdValue.Click += lbThreholdValue_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(18, 7);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Threshold";
            // 
            // trbThreshold
            // 
            trbThreshold.Dock = DockStyle.Fill;
            trbThreshold.Location = new Point(102, 3);
            trbThreshold.Maximum = 255;
            trbThreshold.Name = "trbThreshold";
            trbThreshold.Size = new Size(114, 24);
            trbThreshold.TabIndex = 1;
            trbThreshold.Value = 125;
            trbThreshold.Scroll += trbThreshold_Scroll;
            // 
            // cbInvertThreshold
            // 
            cbInvertThreshold.Anchor = AnchorStyles.None;
            cbInvertThreshold.AutoSize = true;
            cbInvertThreshold.Checked = true;
            cbInvertThreshold.CheckState = CheckState.Checked;
            tlpColorDifferent.SetColumnSpan(cbInvertThreshold, 2);
            cbInvertThreshold.Location = new Point(51, 35);
            cbInvertThreshold.Name = "cbInvertThreshold";
            cbInvertThreshold.Size = new Size(116, 19);
            cbInvertThreshold.TabIndex = 6;
            cbInvertThreshold.Text = "Invert Threshold";
            cbInvertThreshold.UseVisualStyleBackColor = true;
            cbInvertThreshold.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(rbColorisSimiliar, 1, 0);
            tableLayoutPanel5.Controls.Add(rbColorDifferent, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(297, 2);
            tableLayoutPanel5.TabIndex = 0;
            tableLayoutPanel5.Visible = false;
            // 
            // rbColorisSimiliar
            // 
            rbColorisSimiliar.AutoSize = true;
            rbColorisSimiliar.Location = new Point(151, 3);
            rbColorisSimiliar.Name = "rbColorisSimiliar";
            rbColorisSimiliar.Size = new Size(111, 1);
            rbColorisSimiliar.TabIndex = 1;
            rbColorisSimiliar.Text = "Color is Similiar";
            rbColorisSimiliar.UseVisualStyleBackColor = true;
            // 
            // rbColorDifferent
            // 
            rbColorDifferent.AutoSize = true;
            rbColorDifferent.Checked = true;
            rbColorDifferent.Location = new Point(3, 3);
            rbColorDifferent.Name = "rbColorDifferent";
            rbColorDifferent.Size = new Size(119, 1);
            rbColorDifferent.TabIndex = 0;
            rbColorDifferent.TabStop = true;
            rbColorDifferent.Text = "Color is Different";
            rbColorDifferent.UseVisualStyleBackColor = true;
            rbColorDifferent.CheckedChanged += rbColorDifferent_CheckedChanged;
            // 
            // sbVert
            // 
            sbVert.Dock = DockStyle.Right;
            sbVert.Location = new Point(502, 0);
            sbVert.Name = "sbVert";
            sbVert.Size = new Size(17, 330);
            sbVert.TabIndex = 0;
            sbVert.Scroll += sbVert_Scroll;
            // 
            // sbHoriz
            // 
            sbHoriz.Dock = DockStyle.Bottom;
            sbHoriz.Location = new Point(0, 330);
            sbHoriz.Name = "sbHoriz";
            sbHoriz.Size = new Size(519, 17);
            sbHoriz.TabIndex = 1;
            sbHoriz.Scroll += sbHoriz_Scroll;
            // 
            // sbPanel
            // 
            sbPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            sbPanel.BackColor = SystemColors.Info;
            sbPanel.Location = new Point(500, 329);
            sbPanel.Margin = new Padding(4);
            sbPanel.Name = "sbPanel";
            sbPanel.Size = new Size(19, 19);
            sbPanel.TabIndex = 2;
            // 
            // pbPanel
            // 
            pbPanel.BackColor = SystemColors.Window;
            pbPanel.Location = new Point(326, 4);
            pbPanel.Margin = new Padding(4);
            pbPanel.Name = "pbPanel";
            pbPanel.Size = new Size(173, 135);
            pbPanel.SizeMode = PictureBoxSizeMode.Zoom;
            pbPanel.TabIndex = 10;
            pbPanel.TabStop = false;
            pbPanel.MouseDown += pbPanel_MouseDown;
            pbPanel.MouseMove += pbPanel_MouseMove;
            pbPanel.MouseUp += pbPanel_MouseUp;
            // 
            // KpImageViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(4);
            MinimumSize = new Size(530, 181);
            Name = "KpImageViewer";
            Size = new Size(530, 358);
            Load += KP_ImageViewerV2_Load;
            Click += KpImageViewer_Click;
            MouseWheel += KP_ImageViewerV2_MouseWheel;
            Resize += KP_ImageViewerV2_Resize;
            tableLayoutPanel1.ResumeLayout(false);
            panelNavigation.ResumeLayout(false);
            panelNavigation.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            pbFull.ResumeLayout(false);
            cms.ResumeLayout(false);
            pnlParameter.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tlpColorDifferent.ResumeLayout(false);
            tlpColorDifferent.PerformLayout();
            tbcMethod.ResumeLayout(false);
            tpEdge.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudLineSize).EndInit();
            tpLineCenter.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudLineWidthFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbThreshold).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPanel).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox pbPanel;
        private PanelDoubleBuffered pbFull;
        private System.Windows.Forms.ComboBox cbZoom;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblNavigation;
        private System.Windows.Forms.TextBox tbNavigation;
        private System.Windows.Forms.Panel sbPanel;
        private System.Windows.Forms.HScrollBar sbHoriz;
        private System.Windows.Forms.VScrollBar sbVert;
        private TableLayoutPanel tableLayoutPanel1;
        private ContextMenuStrip cms;
        private ToolStripMenuItem fitImageToolStripMenuItem;
        private ToolStripMenuItem previewWindowToolStripMenuItem;
        private ToolStripMenuItem selectModeToolStripMenuItem;
        private ToolStripMenuItem tsmiDrag;
        private ToolStripMenuItem tsmiMeasure;
        private Button btnZoomIn;
        private Button btnZoomOut;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnOpen;
        private ToolStripMenuItem openImageToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem measureParameterToolStripMenuItem;
        private Panel pnlParameter;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lbThreholdValue;
        private TrackBar trbThreshold;
        private Label label2;
        private CheckBox cbInvertThreshold;
        private TableLayoutPanel tlpColorDifferent;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel5;
        private RadioButton rbColorisSimiliar;
        private RadioButton rbColorDifferent;
        private Label label4;
        private Label label3;
        private ComboBox cbbSelectSide;
        private NumericUpDown nudLineSize;
        private TabControl tbcMethod;
        private TabPage tpEdge;
        private TabPage tpLineCenter;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel6;
        private NumericUpDown nudLineWidthMax;
        private Label label1;
        private Label label5;
        private NumericUpDown nudLineWidthFilter;
    }
}
