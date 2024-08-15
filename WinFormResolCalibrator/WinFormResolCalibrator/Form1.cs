using KaiwaProjects;
using OpenCvSharp;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WinFormResolCalibrator
{
    public partial class Form1 : Form
    {
        KpImageViewer _ucImgView = new KpImageViewer();
        Bitmap img;
        public Form1()
        {
            InitializeComponent();

            pnlViewer.Controls.Add(_ucImgView);
            _ucImgView.Dock = DockStyle.Fill;
           // _ucImgView.Initialize();
            _ucImgView.DoResize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
