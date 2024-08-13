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
            sbVert = new VScrollBar();
            sbHoriz = new HScrollBar();
            sbPanel = new Panel();
            pbPanel = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            panelNavigation.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pbFull.SuspendLayout();
            cms.SuspendLayout();
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
            cms.Size = new Size(185, 114);
            // 
            // openImageToolStripMenuItem
            // 
            openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            openImageToolStripMenuItem.Size = new Size(184, 22);
            openImageToolStripMenuItem.Text = "Open Image";
            openImageToolStripMenuItem.Click += btnOpen_Click;
            // 
            // fitImageToolStripMenuItem
            // 
            fitImageToolStripMenuItem.Name = "fitImageToolStripMenuItem";
            fitImageToolStripMenuItem.Size = new Size(184, 22);
            fitImageToolStripMenuItem.Text = "Fit Image";
            fitImageToolStripMenuItem.Click += btnFitToScreen_Click;
            // 
            // previewWindowToolStripMenuItem
            // 
            previewWindowToolStripMenuItem.Checked = true;
            previewWindowToolStripMenuItem.CheckOnClick = true;
            previewWindowToolStripMenuItem.CheckState = CheckState.Checked;
            previewWindowToolStripMenuItem.Name = "previewWindowToolStripMenuItem";
            previewWindowToolStripMenuItem.Size = new Size(184, 22);
            previewWindowToolStripMenuItem.Text = "Preview Window";
            previewWindowToolStripMenuItem.Click += btnPreview_Click;
            // 
            // selectModeToolStripMenuItem
            // 
            selectModeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiDrag, tsmiMeasure });
            selectModeToolStripMenuItem.Name = "selectModeToolStripMenuItem";
            selectModeToolStripMenuItem.Size = new Size(184, 22);
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
            measureParameterToolStripMenuItem.Name = "measureParameterToolStripMenuItem";
            measureParameterToolStripMenuItem.Size = new Size(184, 22);
            measureParameterToolStripMenuItem.Text = "Measure Parameter";
            // 
            // sbVert
            // 
            sbVert.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            sbVert.Location = new Point(499, 0);
            sbVert.Name = "sbVert";
            sbVert.Size = new Size(17, 329);
            sbVert.TabIndex = 0;
            sbVert.Scroll += sbVert_Scroll;
            // 
            // sbHoriz
            // 
            sbHoriz.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sbHoriz.Location = new Point(0, 328);
            sbHoriz.Name = "sbHoriz";
            sbHoriz.Size = new Size(499, 17);
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
    }
}
