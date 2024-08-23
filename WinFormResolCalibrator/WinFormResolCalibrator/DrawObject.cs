using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using OpenCvSharp;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using System.Runtime.Intrinsics;
using System.Net.Sockets;
using System.Diagnostics;
using System.Collections.Generic;

namespace KaiwaProjects
{
    public class KP_DrawObject
    {
        private KpImageViewer KpViewer;
        private	Rectangle boundingRect;
		private	Point dragPoint;
		private	bool dragging;
        private Bitmap bmp;
        private Bitmap bmpPreview;
        private MultiPageImage multiBmp;
        private GifImage gifBmp;

        private bool isMeasuring = false;
        private Rectangle measureRectImg;
        private Rectangle measureRectWindow;
        private MeasurePms Pms;
        private OpenCvSharp.Point[][] Contour;
        List<Tuple<Point2f, Point2f, float>> _xMeasureResult;
        List<Tuple<Point2f, Point2f, float>> _yMeasureResult;
        List<OpenCvSharp.Point[]> lstContour = new List<OpenCvSharp.Point[]>();
        private double zoom = 1.0;
        private int panelWidth
        {
            get
            {
                return KpViewer.PanelWidth;
            }
        }
        private int panelHeight
        {
            get
            {
                return KpViewer.PanelHeight;
            }
        }
        private int rotation = 0;

        private bool multiFrame = false;
        private bool multiPage = false;
        private int pages = 1;
        private int currentPage = 0;

        public Rectangle BoundingBox
        {
            get { return boundingRect; }
        }

        public void Dispose()
        {
            if (this.Image != null)
            {
                this.Image.Dispose();
            }
        }

        public bool IsDragging
        {
            get { return dragging; }
        }

        public GifImage Gif
        {
            get { return gifBmp; }
        }

        public Size OriginalSize
        {
            get
            {
                if (this.Image != null)
                {
                    if (multiFrame == true)
                    {
                        if (this.gifBmp != null)
                        {
                            if (this.gifBmp.Rotation == 0 || this.gifBmp.Rotation == 180)
                            {
                                return this.gifBmp.CurrentFrameSize;
                            }
                            else
                            {
                                return new Size(this.gifBmp.CurrentFrameSize.Height, this.gifBmp.CurrentFrameSize.Width);
                            }
                        }

                        return Size.Empty;
                    }
                    else
                    {
                        return this.Image.Size;
                    }
                }
                else
                {
                    return Size.Empty;
                }
            }
        }

        public Size CurrentSize
        {
            get { if (boundingRect != null) { return new Size(boundingRect.Width, boundingRect.Height); } else { return Size.Empty; } }
        }

        public bool MultiPage
        {
            get { return multiPage; }
        }

        public int Pages
        {
            get { return pages; }
        }

        public int CurrentPage
        {
            get { return currentPage; }
        }

        public double Zoom
        {
            get { return zoom; }
        }

        public int Rotation
        {
            get { return rotation; }
            set
            {
                // Making sure that the rotation is only 0, 90, 180 or 270 degrees!
                if (value == 90 || value == 180 || value == 270 || value == 0)
                {
                    rotation = value;
                }
            }
        }

        public Bitmap GetPage(int pageNumber)
        {
            if (this.multiBmp == null)
            {
                return null;
            }

            int pages = this.multiBmp.Image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
            if (pages > pageNumber && pageNumber >= 0)
            {
                this.multiBmp.Image.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, pageNumber);
                return new Bitmap(this.multiBmp.Image);
            }

            return null;
        }
        public int ImageWidth
        {
            get
            {
                if (multiFrame == true)
                {
                    if (gifBmp != null)
                    {
                        if (gifBmp.Rotation == 0 || gifBmp.Rotation == 180)
                        {
                            return gifBmp.CurrentFrameSize.Width;
                        }
                        else
                        {
                            return gifBmp.CurrentFrameSize.Height;
                        }
                    }

                    return 0;
                }
                else
                {
                    return this.Image.Width;
                }
            }
        }

        public int ImageHeight
        {
            get
            {
                if (multiFrame == true)
                {
                    if (gifBmp != null)
                    {
                        if (gifBmp.Rotation == 0 || gifBmp.Rotation == 180)
                        {
                            return gifBmp.CurrentFrameSize.Height;
                        }
                        else
                        {
                            return gifBmp.CurrentFrameSize.Width;
                        }
                    }

                    return 0;
                }
                else
                {
                    return this.Image.Height;
                }
            }
        }

        public Bitmap Image
        {
            get 
            {
                if (this.multiFrame == true)
                {
                    return (Bitmap)gifBmp.CurrentFrame;
                }
                else if (this.multiPage == true)
                {
                    if (multiBmp != null)
                    {
                        return multiBmp.Page;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return bmp;
                }
            }
            set
            {
                try
                {
                    if (value != null)
                    {
                        currentPage = 0;

                        // No memory leaks here!
                        if (this.bmp != null)
                        {
                            this.bmp.Dispose();
                            this.bmp = null;
                        }

                        if (this.multiBmp != null)
                        {
                            this.multiBmp.Dispose();
                            this.multiBmp = null;
                        }

                        try
                        {
                            FrameDimension gifDimension = new FrameDimension(value.FrameDimensionsList[0]);
                            int gifFrames = value.GetFrameCount(gifDimension);

                            if (gifFrames > 1)
                            {
                                multiFrame = true;
                            }
                            else
                            {
                                multiFrame = false;
                            }

                            if (!multiFrame)
                            {
                                //Gets the total number of frames in the .tiff file
                                pages = value.GetFrameCount(FrameDimension.Page);
                                if (pages > 1) { multiPage = true; } else { multiPage = false; }
                            }
                        }
                        catch
                        {
                            multiPage = false;
                            pages = 1;
                        }

                        if (multiFrame == true)
                        {
                            this.gifBmp = new GifImage(this.KpViewer, value, this.KpViewer.GifAnimation, this.KpViewer.GifFPS);
                        }
                        else if (multiPage == true)
                        {
                            this.bmp = null;

                            this.multiBmp = new MultiPageImage(value);
                        }
                        else
                        {
                            this.bmp = value;
                            this.multiBmp = null;
                        }

                        // Initial rotation adjustments
                        if (rotation != 0)
                        {
                            if (rotation == 180)
                            {
                                this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                boundingRect = new Rectangle(0, 0, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));
                            }
                            else
                            {
                                if (rotation == 90)
                                {
                                    this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                                else if (rotation == 270)
                                {
                                    this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                }

                                // Flip the X and Y values
                                boundingRect = new Rectangle(0, 0, (int)(this.ImageHeight * zoom), (int)(this.ImageWidth * zoom));
                            }
                        }
                        else
                        {
                            this.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                            boundingRect = new Rectangle(0, 0, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));
                        }

                        zoom = 1.0;
                        bmpPreview = CreatePreviewImage();
                        FitToScreen();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
                }
            }
        }
        
        public Image PreviewImage
        {
            get { return bmpPreview; }
        }

        public string ImagePath
        {
            set
            {
                try
                {
                    // No memory leaks here!
                    if (this.bmp != null)
                    {
                        this.bmp.Dispose();
                        this.bmp = null;
                    }

                    if (this.multiBmp != null)
                    {
                        this.multiBmp.Dispose();
                        this.multiBmp = null;
                    }

                    Bitmap temp = null;

                    // Make sure it does not crash on incorrect image formats
                    try
                    {
                        //temp = (Bitmap)Bitmap.FromFile(value);
                        temp = new Bitmap(value);
                    }
                    catch
                    {
                        temp = null;
                        System.Windows.Forms.MessageBox.Show("ImageViewer error: Incorrect image format!");
                    }

                    if (temp != null)
                    {
                        currentPage = 0;

                        try
                        {
                            string extension = Path.GetExtension(value);

                            if (extension == ".gif")
                            {
                                FrameDimension gifDimension = new FrameDimension(temp.FrameDimensionsList[0]);
                                int gifFrames = temp.GetFrameCount(gifDimension);

                                if (gifFrames > 1)
                                {
                                    multiFrame = true;
                                }
                                else
                                {
                                    multiFrame = false;
                                }
                            }
                            else
                            {
                                multiFrame = false;

                                //Gets the total number of frames in the .tiff file
                                pages = temp.GetFrameCount(FrameDimension.Page);
                                if (pages > 1) { multiPage = true; } else { multiPage = false; }
                            }
                        }
                        catch
                        {
                            multiPage = false;
                            pages = 1;
                        }

                        if (multiFrame == true)
                        {
                            this.gifBmp = new GifImage(this.KpViewer, temp, this.KpViewer.GifAnimation, this.KpViewer.GifFPS);
                        }
                        else if (multiPage == true)
                        {
                            this.bmp = null;

                            this.multiBmp = new MultiPageImage(temp);
                        }
                        else
                        {
                            this.bmp = temp;
                            this.multiBmp = null;
                        }

                        // Initial rotation
                        if (rotation != 0)
                        {
                            if (rotation == 180)
                            {
                                this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                boundingRect = new Rectangle(0, 0, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));
                            }
                            else
                            {
                                if (rotation == 90)
                                {
                                    this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }
                                else if (rotation == 270)
                                {
                                    this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                }

                                // Flipping X and Y values!
                                boundingRect = new Rectangle(0, 0, (int)(this.ImageHeight * zoom), (int)(this.ImageWidth * zoom));
                            }
                        }
                        else
                        {
                            this.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                            boundingRect = new Rectangle(0, 0, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));
                        }

                        zoom = 1.0;
                        bmpPreview = CreatePreviewImage();
                        FitToScreen();
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
                }
            }
        }

        public KP_DrawObject(KpImageViewer KpViewer, Bitmap bmp)
        {
            try
            {
                this.KpViewer = KpViewer;

                // Initial dragging to false and an Image.
                dragging = false;
                this.Image = bmp;
                this.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);

                boundingRect = new Rectangle(0, 0, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        private System.Drawing.Imaging.ImageCodecInfo GetCodec(string type)
        {
            System.Drawing.Imaging.ImageCodecInfo[] info = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();

            for (int i = 0; i < info.Length; i++)
            {
                string EnumName = type.ToString();
                if (info[i].FormatDescription.Equals(EnumName))
                {
                    return info[i];
                }
            }
            return null;
        }

        public void SetPage(int page)
        {
            int p = page - 1;

            try
            {
                if (this.Image != null && this.multiPage == true)
                {
                    if (p < this.pages && p >= 0)
                    {
                        currentPage = p;

                        this.multiBmp.SetPage(p);
                        this.multiBmp.Rotate(this.rotation);

                        // No memory leaks here!
                        if (this.bmpPreview != null)
                        {
                            this.bmpPreview.Dispose();
                            this.bmpPreview = null;
                        }

                        this.bmpPreview = CreatePreviewImage();
                        AvoidOutOfScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void NextPage()
        {
            try
            {
                if (this.Image != null && this.multiPage == true)
                {
                    int nextPage = this.currentPage + 1;

                    if (nextPage < this.pages)
                    {
                        currentPage = nextPage;

                        this.multiBmp.SetPage(currentPage);
                        this.multiBmp.Rotate(this.rotation);

                        // No memory leaks here!
                        if (this.bmpPreview != null)
                        {
                            this.bmpPreview.Dispose();
                            this.bmpPreview = null;
                        }

                        this.bmpPreview = CreatePreviewImage();
                        AvoidOutOfScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void PreviousPage()
        {
            try
            {
                if (this.Image != null && this.multiPage == true)
                {
                    int prevPage = this.currentPage - 1;

                    if (prevPage >= 0)
                    {
                        currentPage = prevPage;

                        this.multiBmp.SetPage(currentPage);
                        this.multiBmp.Rotate(this.rotation);

                        // No memory leaks here!
                        if (this.bmpPreview != null)
                        {
                            this.bmpPreview.Dispose();
                            this.bmpPreview = null;
                        }

                        this.bmpPreview = CreatePreviewImage();
                        AvoidOutOfScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public KP_DrawObject(KpImageViewer KpViewer)
        {
            try
            {
                this.KpViewer = KpViewer;
                // Initial dragging to false and No image.
                dragging = false;
                this.bmp = null;
                this.multiBmp = null;
                this.gifBmp = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void Rotate90()
        {
            try
            {
                if (this.Image != null)
                {
                    int tempWidth = boundingRect.Width;
                    int tempHeight = boundingRect.Height;

                    boundingRect.Width = tempHeight;
                    boundingRect.Height = tempWidth;

                    rotation = (rotation + 90) % 360;

                    if (this.multiFrame == true)
                    {
                        this.gifBmp.Rotate(90);
                    }
                    else if (this.MultiPage == true)
                    {
                        if (this.multiBmp != null)
                        {
                            this.multiBmp.Rotate(90);
                        }
                    }
                    else
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }

                    AvoidOutOfScreen();

                    // No memory leaks here!
                    if (this.bmpPreview != null)
                    {
                        this.bmpPreview.Dispose();
                        this.bmpPreview = null;
                    }

                    this.bmpPreview = CreatePreviewImage();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void Rotate180()
        {
            try
            {
                if (this.Image != null)
                {
                    int tempWidth = boundingRect.Width;
                    int tempHeight = boundingRect.Height;

                    boundingRect.Width = tempHeight;
                    boundingRect.Height = tempWidth;

                    rotation = (rotation + 180) % 360;

                    if (this.multiFrame == true)
                    {
                        this.gifBmp.Rotate(180);
                    }
                    else if (this.MultiPage == true)
                    {
                        if (this.multiBmp != null)
                        {
                            this.multiBmp.Rotate(180);
                        }
                    }
                    else
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    }

                    AvoidOutOfScreen();

                    // No memory leaks here!
                    if (this.bmpPreview != null)
                    {
                        this.bmpPreview.Dispose();
                        this.bmpPreview = null;
                    }

                    this.bmpPreview = CreatePreviewImage();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void Rotate270()
        {
            try
            {
                if (this.Image != null)
                {
                    int tempWidth = boundingRect.Width;
                    int tempHeight = boundingRect.Height;

                    boundingRect.Width = tempHeight;
                    boundingRect.Height = tempWidth;

                    rotation = (rotation + 270) % 360;

                    if (this.multiFrame == true)
                    {
                        this.gifBmp.Rotate(270);
                    }
                    else if (this.MultiPage == true)
                    {
                        if (this.multiBmp != null)
                        {
                            this.multiBmp.Rotate(270);
                        }
                    }
                    else
                    {
                        this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }

                    AvoidOutOfScreen();

                    // No memory leaks here!
                    if (this.bmpPreview != null)
                    {
                        this.bmpPreview.Dispose();
                        this.bmpPreview = null;
                    }

                    this.bmpPreview = CreatePreviewImage();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        private Bitmap RotateCenter(Bitmap bmpSrc, float theta)
        {
            if(theta == 180.0f)
            {
                Bitmap bmpDest = new Bitmap(bmpSrc.Width, bmpSrc.Height);
                Graphics gDest = Graphics.FromImage(bmpDest);

                gDest.DrawImage(bmpSrc, new Point(0, 0));
                
                bmpDest.RotateFlip(RotateFlipType.Rotate180FlipNone);

                return bmpDest;
            }
            else
            {
                Matrix mRotate = new Matrix();
                mRotate.Translate(bmpSrc.Width / -2, bmpSrc.Height / -2, MatrixOrder.Append);
                mRotate.RotateAt(theta, new Point(0, 0), MatrixOrder.Append);

                GraphicsPath gp = new GraphicsPath();
                // transform image points by rotation matrix
                gp.AddPolygon(new Point[] { new Point(0, 0), new Point(bmpSrc.Width, 0), new Point(0, bmpSrc.Height) });
                gp.Transform(mRotate);
                PointF[] pts = gp.PathPoints;

                // create destination bitmap sized to contain rotated source image
                Rectangle bbox = RotateBoundingBox(bmpSrc, mRotate);
                Bitmap bmpDest = new Bitmap(bbox.Width, bbox.Height);

                Graphics gDest = Graphics.FromImage(bmpDest);
                Matrix mDest = new Matrix();
                mDest.Translate(bmpDest.Width / 2, bmpDest.Height / 2, MatrixOrder.Append);
                gDest.Transform = mDest;
                gDest.DrawImage(bmpSrc, pts);
                gDest.DrawRectangle(Pens.Red, bbox);
                gDest.Dispose();
                gp.Dispose();

                return bmpDest;
            }
        }

        private static Rectangle RotateBoundingBox(Image img, System.Drawing.Drawing2D.Matrix matrix)
        {
            GraphicsUnit gu = new GraphicsUnit();
            Rectangle rImg = Rectangle.Round(img.GetBounds(ref gu));

            // Transform the four points of the image, to get the resized bounding box.
            Point topLeft = new Point(rImg.Left, rImg.Top);
            Point topRight = new Point(rImg.Right, rImg.Top);
            Point bottomRight = new Point(rImg.Right, rImg.Bottom);
            Point bottomLeft = new Point(rImg.Left, rImg.Bottom);
            Point[] points = new Point[] { topLeft, topRight, bottomRight, bottomLeft };
            GraphicsPath gp = new GraphicsPath(points, new byte[] { (byte)PathPointType.Start, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line });
            gp.Transform(matrix);
            return Rectangle.Round(gp.GetBounds());
        }

        private Bitmap CreatePreviewImage()
        {
            // 148 && 117 as initial and default size for the preview panel.
            Rectangle previewRect = new Rectangle(0, 0, 148, 117);

            double x_ratio = (double)previewRect.Width / (double)this.BoundingBox.Width;
            double y_ratio = (double)previewRect.Height / (double)this.BoundingBox.Height;

            if ((this.BoundingBox.Width <= previewRect.Width) && (this.BoundingBox.Height <= previewRect.Height))
            {
                previewRect.Width = this.BoundingBox.Width;
                previewRect.Height = this.BoundingBox.Height;
            }
            else if ((x_ratio * this.BoundingBox.Height) < previewRect.Height)
            {
                previewRect.Height = Convert.ToInt32(Math.Ceiling(x_ratio * this.BoundingBox.Height));
                previewRect.Width = previewRect.Width;
            }
            else
            {
                previewRect.Width = Convert.ToInt32(Math.Ceiling(y_ratio * this.BoundingBox.Width));
                previewRect.Height = previewRect.Height;
            }

            Bitmap bmp = new Bitmap(previewRect.Width, previewRect.Height);

            if (multiFrame == true)
            {
                if (this.gifBmp != null)
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        if (this.gifBmp.Lock())
                        {
                            lock (this.gifBmp.CurrentFrame)
                            {
                                if (this.gifBmp.Rotation != 0)
                                {
                                    g.DrawImage(RotateCenter(this.gifBmp.CurrentFrame, this.gifBmp.Rotation), previewRect);
                                }
                                else
                                {
                                    g.DrawImage(this.gifBmp.CurrentFrame, previewRect);
                                }
                            }
                        }

                        this.gifBmp.Unlock();
                    }
                }
            }
            else
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    if (this.Image != null)
                    {
                        g.DrawImage(this.Image, previewRect);
                    }
                }
            }

            return bmp;
        }

        public void ZoomToSelection(Rectangle selection, Point ptPbFull)
        {
            int x = (selection.X - ptPbFull.X);
            int y = (selection.Y - ptPbFull.Y);
            int width = selection.Width;
            int height = selection.Height;

            // So, where did my selection start on the entire picture?
            int selectedX = (int)((double)(((double)boundingRect.X - ((double)boundingRect.X * 2)) + (double)x) / zoom);
            int selectedY = (int)((double)(((double)boundingRect.Y - ((double)boundingRect.Y * 2)) + (double)y) / zoom);
            int selectedWidth = width;
            int selectedHeight = height;

            // The selection width on the scale of the Original size!
            if (zoom < 1.0 || zoom > 1.0)
            {
                selectedWidth = Convert.ToInt32((double)width / zoom);
                selectedHeight = Convert.ToInt32((double)height / zoom);
            }

            // What is the highest possible zoomrate?
            double zoomX = ((double)panelWidth / (double)selectedWidth);
            double zoomY = ((double)panelHeight / (double)selectedHeight);

            double newZoom = Math.Min(zoomX, zoomY);

            // Avoid Int32 crashes!
            if (newZoom * 100 < Int32.MaxValue && newZoom * 100 > Int32.MinValue)
            {
                SetZoom(newZoom);

                selectedWidth = (int)((double)selectedWidth * newZoom);
                selectedHeight = (int)((double)selectedHeight * newZoom);

                // Center the selected area
                int offsetX = 0;
                int offsetY = 0;
                if (selectedWidth < panelWidth)
                {
                    offsetX = (panelWidth - selectedWidth) / 2;
                }
                if (selectedHeight < panelHeight)
                {
                    offsetY = (panelHeight - selectedHeight) / 2;
                }

                boundingRect.X = (int)((int)((double)selectedX * newZoom) - ((int)((double)selectedX * newZoom) * 2)) + offsetX;
                boundingRect.Y = (int)((int)((double)selectedY * newZoom) - ((int)((double)selectedY * newZoom) * 2)) + offsetY;

                AvoidOutOfScreen();
            }
        }

        public void SelectionToMeasure(Rectangle selection, Point ptPbFull)
        {


            //isMeasuring = false;
            //處理方式

            //STEP 1 繪圖測試
            //Image 為完整的圖

            // STEP 2 進行量測

            int x = (selection.X - ptPbFull.X);
            int y = (selection.Y - ptPbFull.Y);
            int width = selection.Width;
            int height = selection.Height;

            if (width * height == 0)
                return;
            // So, where did my selection start on the entire picture?
            int selectedX = (int)((double)(((double)boundingRect.X - ((double)boundingRect.X * 2)) + (double)x) / zoom);
            int selectedY = (int)((double)(((double)boundingRect.Y - ((double)boundingRect.Y * 2)) + (double)y) / zoom);
            int selectedWidth  = width;
            int selectedHeight = height;

            if (zoom < 1.0 || zoom > 1.0)
            {
                selectedWidth = Convert.ToInt32((double)width / zoom);
                selectedHeight = Convert.ToInt32((double)height / zoom);
            }

            if (selectedWidth * selectedHeight == 0)
                return;

            measureRectImg = new Rectangle(selectedX, selectedY, selectedWidth, selectedHeight);
            measureRectWindow = new Rectangle(x,y, width, height);

            if (Image == null)
                return;
            ////----ROI Crop 測試 位置是預期的位置
            Bitmap CroppedImage = Image.Clone(new System.Drawing.Rectangle(selectedX, selectedY, selectedWidth, selectedHeight), Image.PixelFormat);
            Mat tmp = BmpToMat(CroppedImage);


            if (Pms == null)
                Pms = new MeasurePms();

            

            LineIntervalMeasurement(tmp,out _xMeasureResult,out _yMeasureResult,out lstContour, Pms);

            CroppedImage.Dispose();
            isMeasuring = true;

        }


        public void JumpToOrigin(int x, int y, int width, int height, int pWidth, int pHeight)
        {
            try
            {
                double zoom = (double)boundingRect.Width / (double)width;

                int originX = (int)(x * zoom);
                int originY = (int)(y * zoom);

                originX = originX - (originX * 2);
                originY = originY - (originY * 2);

                boundingRect.X = originX + (pWidth / 2);
                boundingRect.Y = originY + (pHeight / 2);

                AvoidOutOfScreen();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void JumpToOrigin(int x, int y, int width, int height)
        {
            try
            {
                boundingRect.X = (x - (width / 2)) - ((x - (width / 2)) * 2);
                boundingRect.Y = (y - (height / 2)) - ((y - (height / 2)) * 2);

                AvoidOutOfScreen();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public Point PointToOrigin(int x, int y, int width, int height)
        {
            try
            {
                double zoomX = (double)width / (double)boundingRect.Width;
                double zoomY = (double)height / (double)boundingRect.Height;

                if (width > panelWidth)
                {
                    int oldX = (boundingRect.X - (boundingRect.X * 2)) + (panelWidth / 2);
                    int oldY = (boundingRect.Y - (boundingRect.Y * 2)) + (panelHeight / 2);

                    int newX = (int)(oldX * zoomX);
                    int newY = (int)(oldY * zoomY);

                    int originX = newX - (panelWidth / 2) - ((newX - (panelWidth / 2)) * 2);
                    int originY = newY - (panelHeight / 2) - ((newY - (panelHeight / 2)) * 2);

                    return new Point(originX, originY);
                }
                else
                {
                    if (height > panelHeight)
                    {
                        int oldY = (boundingRect.Y - (boundingRect.Y * 2)) + (panelHeight / 2);

                        int newY = (int)(oldY * zoomY);

                        int originY = newY - (panelHeight / 2) - ((newY - (panelHeight / 2)) * 2);

                        return new Point(0, originY);
                    }
                    else
                    {
                        return new Point(0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
                return new Point(0, 0);
            }
        }

        public void ZoomIn()
        {
            try
            {
                if (this.Image != null)
                {
                    // Make sure zoom steps are with 25%
                    double index = 0.25 - (zoom % 0.25);
                    
                    if(index != 0)
                    {
                        zoom += index;
                    }
                    else
                    {
                        zoom += 0.25;
                    }

                    Point p = PointToOrigin(boundingRect.X, boundingRect.Y, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));

                    boundingRect = new Rectangle(p.X, p.Y, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));
                    AvoidOutOfScreen();
                    
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void ZoomOut()
        {
            try
            {
                if (this.Image != null)
                {
                    // Make sure zoom steps are with 25% and higher than 0%
                    if (zoom - 0.25 > 0)
                    {
                        if (((zoom - 0.25) % 0.25) != 0)
                        {
                            zoom -= zoom % 0.25;
                        }
                        else
                        {
                            zoom -= 0.25;
                        }
                    }

                    Point p = PointToOrigin(boundingRect.X, boundingRect.Y, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));

                    boundingRect = new Rectangle(p.X, p.Y, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));
                    AvoidOutOfScreen();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void SetPosition(int x, int y)
        {
            boundingRect.X = -x;
            boundingRect.Y = -y;
        }

        public void SetPositionX(int x)
        {
            boundingRect.X = -x;
        }

        public void SetPositionY(int y)
        {
            boundingRect.Y = -y;
        }

        public void SetZoom(double z)
        {
            try
            {
                if (this.Image != null)
                {
                    zoom = z;

                    Point p = PointToOrigin(boundingRect.X, boundingRect.Y, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));

                    boundingRect = new Rectangle(p.X, p.Y, (int)(this.ImageWidth * zoom), (int)(this.ImageHeight * zoom));
                    AvoidOutOfScreen();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void Scroll(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                isMeasuring = false;

                if (this.Image != null)
                {
                    if (e.Delta < 0)
                    {
                        ZoomOut();
                    }
                    else
                    {
                        ZoomIn();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void FitToScreen()
        {
            try
            {
                isMeasuring = false;

                if (this.Image != null)
                {
                    double x_ratio = (double)panelWidth / (double)this.ImageWidth;
                    double y_ratio = (double)panelHeight / (double)this.ImageHeight;

                    if ((this.ImageWidth <= panelWidth) && (this.ImageHeight <= panelHeight))
                    {
                        boundingRect.Width = this.ImageWidth;
                        boundingRect.Height = this.ImageHeight;
                    }
                    else if ((x_ratio * this.ImageHeight) < panelHeight)
                    {
                        boundingRect.Height = Convert.ToInt32(Math.Ceiling(x_ratio * this.ImageHeight));
                        boundingRect.Width = panelWidth;
                    }
                    else
                    {
                        boundingRect.Width = Convert.ToInt32(Math.Ceiling(y_ratio * this.ImageWidth));
                        boundingRect.Height = panelHeight;
                    }

                    boundingRect.X = 0;
                    boundingRect.Y = 0;

                    zoom = ((double)boundingRect.Width / (double)this.ImageWidth);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

        public void AvoidOutOfScreen()
        {
            try
            {
                // Am I lined out to the left?
                if (boundingRect.X >= 0)
                {
                    boundingRect.X = 0;
                }
                else if ((boundingRect.X <= (boundingRect.Width - panelWidth) - ((boundingRect.Width - panelWidth) * 2)))
                {
                    if ((boundingRect.Width - panelWidth) - ((boundingRect.Width - panelWidth) * 2) <= 0)
                    {
                        // I am too far to the left!
                        boundingRect.X = (boundingRect.Width - panelWidth) - ((boundingRect.Width - panelWidth) * 2);
                    }
                    else
                    {
                        // I am too far to the right!
                        boundingRect.X = 0;
                    }
                }

                // Am I lined out to the top?
                if (boundingRect.Y >= 0)
                {
                    boundingRect.Y = 0;
                }
                else if ((boundingRect.Y <= (boundingRect.Height - panelHeight) - ((boundingRect.Height - panelHeight) * 2)))
                {
                    if ((boundingRect.Height - panelHeight) - ((boundingRect.Height - panelHeight) * 2) <= 0)
                    {
                        // I am too far to the top!
                        boundingRect.Y = (boundingRect.Height - panelHeight) - ((boundingRect.Height - panelHeight) * 2);
                    }
                    else
                    {
                        // I am too far to the bottom!
                        boundingRect.Y = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
        }

		public void Drag(Point pt)
		{
            try
            {
                if (this.Image != null)
                {
                    if (dragging == true)
                    {
                        // Am I dragging it outside of the panel?
                        if ((pt.X - dragPoint.X > (boundingRect.Width - panelWidth) - ((boundingRect.Width - panelWidth) * 2)) && (pt.X - dragPoint.X < 0))
                        {
                            // No, everything is just fine
                            boundingRect.X = pt.X - dragPoint.X;
                        }
                        else if ((pt.X - dragPoint.X > 0))
                        {
                            // Now don't drag it out of the panel please
                            boundingRect.X = 0;
                        }
                        else if((pt.X - dragPoint.X < (boundingRect.Width - panelWidth) - ((boundingRect.Width - panelWidth) * 2)))
                        {
                            // I am dragging it out of my panel. How many pixels do I have left?
                            if ((boundingRect.Width - panelWidth) - ((boundingRect.Width - panelWidth) * 2) <= 0)
                            {
                                // Make it fit perfectly
                                boundingRect.X = (boundingRect.Width - panelWidth) - ((boundingRect.Width - panelWidth) * 2);
                            }
                        }

                        // Am I dragging it outside of the panel?
                        if (pt.Y - dragPoint.Y > (boundingRect.Height - panelHeight) - ((boundingRect.Height - panelHeight) * 2) && (pt.Y - dragPoint.Y < 0))
                        {
                            // No, everything is just fine
                            boundingRect.Y = pt.Y - dragPoint.Y;
                        }
                        else if ((pt.Y - dragPoint.Y > 0))
                        {
                            // Now don't drag it out of the panel please
                            boundingRect.Y = 0;
                        }
                        else if (pt.Y - dragPoint.Y < (boundingRect.Height - panelHeight) - ((boundingRect.Height - panelHeight) * 2))
                        {
                            // I am dragging it out of my panel. How many pixels do I have left?
                            if ((boundingRect.Height - panelHeight) - ((boundingRect.Height - panelHeight) * 2) <= 0)
                            {
                                // Make it fit perfectly
                                boundingRect.Y = (boundingRect.Height - panelHeight) - ((boundingRect.Height - panelHeight) * 2);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
		}

		public void BeginDrag(Point pt)
		{
            try
            {
                if (this.Image != null)
                {
                    isMeasuring = false;
                    // Initial drag position
                    dragPoint.X = pt.X - boundingRect.X;
                    dragPoint.Y = pt.Y - boundingRect.Y;
                    dragging = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
		}

		public void EndDrag()
        {
            try
            {
                if (this.Image != null)
                {
                    dragging = false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
		}

		public void Draw(Graphics g)
		{
            try
            {
                if (this.bmp != null)
                {
                    g.DrawImage(this.bmp, boundingRect);

                    if (isMeasuring)
                    {
                        //繪圖
                        SolidBrush brush = new SolidBrush(Color.Black);
                        System.Drawing.Font font= new System.Drawing.Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);

                        double xRatio = (1.0 * measureRectWindow.Width) / (1.0 * measureRectImg.Width);
                        double yRatio = (1.0 * measureRectWindow.Height) / (1.0 * measureRectImg.Height);

                        for (int i = 0; i < _xMeasureResult.Count; i++)
                        {
                            Pen pen1 = new Pen(Color.Red, 1); //畫筆
                            pen1.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                            pen1.StartCap= System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                            Point2f p1 = _xMeasureResult[i].Item1;
                            Point2f p2 = _xMeasureResult[i].Item2;

                            Point pt1 = new Point(measureRectWindow.X + (int)(p1.X * xRatio), measureRectWindow.Y + (int)(p1.Y * yRatio));
                            Point pt2 = new Point(measureRectWindow.X + (int)(p2.X * xRatio), measureRectWindow.Y + (int)(p1.Y * yRatio));
                            g.DrawLine(pen1, pt1, pt2);

                            string drawString = _xMeasureResult[i].Item3.ToString("0.00");
                            float x = 0.5f*(pt1.X+pt2.X);
                            float y = 0.5f * (pt1.Y + pt2.Y);
                            g.DrawString(drawString, font, brush, x, y);

                            if (!Pms.IsEgeMode)
                            {
                                pen1.DashStyle = DashStyle.DashDotDot;
                                pen1.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                                pen1.StartCap = System.Drawing.Drawing2D.LineCap.Round;

                                Point pt1_1 = new Point(measureRectWindow.X + (int)(p1.X * xRatio), measureRectWindow.Y + (int)(p1.Y * yRatio) - 100);
                                Point pt1_2 = new Point(measureRectWindow.X + (int)(p1.X * xRatio), measureRectWindow.Y + (int)(p1.Y * yRatio) + 100);
                                Point pt2_1 = new Point(measureRectWindow.X + (int)(p2.X * xRatio), measureRectWindow.Y + (int)(p1.Y * yRatio) - 100);
                                Point pt2_2 = new Point(measureRectWindow.X + (int)(p2.X * xRatio), measureRectWindow.Y + (int)(p1.Y * yRatio) + 100);
                                g.DrawLine(pen1, pt1_1, pt1_2);
                                g.DrawLine(pen1, pt2_1, pt2_2);
                            }
                        }

                        for (int i = 0; i < _yMeasureResult.Count; i++)
                        {
                            Pen pen1 = new Pen(Color.Red, 1); //畫筆
                            pen1.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                            pen1.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                            Point2f p1 = _yMeasureResult[i].Item1;
                            Point2f p2 = _yMeasureResult[i].Item2;

                            Point pt1 = new Point(measureRectWindow.X + (int)(p1.X * xRatio), measureRectWindow.Y + (int)(p1.Y * yRatio));
                            Point pt2 = new Point(measureRectWindow.X + (int)(p1.X * xRatio), measureRectWindow.Y + (int)(p2.Y * yRatio));
                            g.DrawLine(pen1, pt1, pt2);

                            string drawString = _yMeasureResult[i].Item3.ToString("0.00");
                            float x = 0.5f * (pt1.X + pt2.X);
                            float y = 0.5f * (pt1.Y + pt2.Y);
                            g.DrawString(drawString, font, brush, x, y);

                            if (!Pms.IsEgeMode)
                            {
                                pen1.DashStyle = DashStyle.DashDotDot;
                                pen1.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                                pen1.StartCap = System.Drawing.Drawing2D.LineCap.Round;

                                Point pt1_1 = new Point(measureRectWindow.X + (int)(p1.X * xRatio) - 100, measureRectWindow.Y + (int)(p1.Y * yRatio));
                                Point pt1_2 = new Point(measureRectWindow.X + (int)(p1.X * xRatio) + 100, measureRectWindow.Y + (int)(p1.Y * yRatio));
                                Point pt2_1 = new Point(measureRectWindow.X + (int)(p1.X * xRatio) - 100, measureRectWindow.Y + (int)(p2.Y * yRatio));
                                Point pt2_2 = new Point(measureRectWindow.X + (int)(p1.X * xRatio) + 100, measureRectWindow.Y + (int)(p2.Y * yRatio));

                                g.DrawLine(pen1, pt1_1, pt1_2);
                                g.DrawLine(pen1, pt2_1, pt2_2);
                            }
                        }

                        Brush aBrush = (Brush)Brushes.DarkRed;


                        for (int i = 0; i < lstContour.Count; i++)
                            for (int j = 0; j < lstContour[i].Length; j++)
                            {
                                Point pt1 = new Point(measureRectWindow.X + (int)(lstContour[i][j].X * xRatio), measureRectWindow.Y + (int)(lstContour[i][j].Y * yRatio));
                                g.FillEllipse(aBrush, pt1.X, pt1.Y, 3, 3);
                            }

                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ImageViewer error: " + ex.ToString());
            }
		}


        private static void LineIntervalMeasurement(Mat Img, out List<Tuple<Point2f, Point2f, float>> xMeasureResult, out List<Tuple<Point2f, Point2f, float>> yMeasureResult, out List<OpenCvSharp.Point[]> SelectContour, MeasurePms Pm)
        {
            OpenCvSharp.Point[][] vContourForXMeasurement = null;
            OpenCvSharp.Point[][] vContourForYMeasurement = null;
            xMeasureResult = new List<Tuple<Point2f, Point2f, float>>();
            yMeasureResult = new List<Tuple<Point2f, Point2f, float>>();
            SelectContour = new List<OpenCvSharp.Point[]>();
            Mat result;

            if (Pm.IsThresholdInvert)
                result = Img.Threshold(Pm.ThresholdValue, 255, ThresholdTypes.BinaryInv);
            else
                result = Img.Threshold(Pm.ThresholdValue, 255, ThresholdTypes.Binary);

            if (Pm.IsEgeMode)
            {
                OpenCvSharp.Size sz = new OpenCvSharp.Size(Pm.Filter_Size, Pm.Filter_Size);
                Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, sz, new OpenCvSharp.Point(-1, -1));

                Cv2.MorphologyEx(result, result, MorphTypes.Close, element);
                Cv2.MorphologyEx(result, result, MorphTypes.Open, element);

                OpenCvSharp.Point[][] vContour = null;
                HierarchyIndex[] vhi = null;

                Cv2.FindContours(result, out vContour, out vhi, RetrievalModes.External, ContourApproximationModes.ApproxNone);
                Mat imgContour = new Mat(Img.Size(), MatType.CV_8UC1);

                for (int i = 0; i < vContour.Length; i++)
                    Cv2.DrawContours(imgContour, vContour, i, new Scalar(255, 255, 255), 1);

                Mat t_mat;
                Mat TranslationMat;

                t_mat = Mat.Zeros(2, 3, MatType.CV_32FC1);
                t_mat.Set<float>(0, 0, 1);
                t_mat.Set<float>(0, 2, Pm.SelectSide);
                t_mat.Set<float>(1, 1, 1);
                t_mat.Set<float>(1, 2, 0);

                if (Img.Size().Width > Img.Size().Height)
                {
                    TranslationMat = new Mat(result.Size(), MatType.CV_8UC1);
                    Cv2.WarpAffine(result, TranslationMat, t_mat, result.Size());

                    Mat X_DIR_Filter;
                    X_DIR_Filter = imgContour - TranslationMat;
                    X_DIR_Filter = X_DIR_Filter.Threshold(254, 255, ThresholdTypes.Binary);

                    vhi = null;
                    Cv2.FindContours(X_DIR_Filter, out vContourForXMeasurement, out vhi, RetrievalModes.External, ContourApproximationModes.ApproxNone, null);
                    GetMeasureResult(0, vContourForXMeasurement, out xMeasureResult, out SelectContour);
                }
                else
                {
                    t_mat = Mat.Zeros(2, 3, MatType.CV_32FC1);
                    t_mat.Set<float>(0, 0, 1);
                    t_mat.Set<float>(0, 2, 0);
                    t_mat.Set<float>(1, 1, 1);
                    t_mat.Set<float>(1, 2, Pm.SelectSide);

                    TranslationMat = new Mat(result.Size(), MatType.CV_8UC1);
                    Cv2.WarpAffine(result, TranslationMat, t_mat, result.Size());

                    Mat Y_DIR_Filter;
                    Y_DIR_Filter = imgContour - TranslationMat;
                    Y_DIR_Filter = Y_DIR_Filter.Threshold(254, 255, ThresholdTypes.Binary);

                    vhi = null;
                    Cv2.FindContours(Y_DIR_Filter, out vContourForYMeasurement, out vhi, RetrievalModes.External, ContourApproximationModes.ApproxNone, null);
                    GetMeasureResult(1, vContourForYMeasurement, out yMeasureResult, out SelectContour);
                }
            }
            else
            {
                OpenCvSharp.Size sz = new OpenCvSharp.Size(Pm.LineWidthFilter/3, Pm.LineWidthFilter/3);
                Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, sz, new OpenCvSharp.Point(-1, -1));

                Cv2.MorphologyEx(result, result, MorphTypes.Close, element);

                sz = new OpenCvSharp.Size(Pm.LineWidthFilter, Pm.LineWidthFilter);
                element = Cv2.GetStructuringElement(MorphShapes.Rect, sz, new OpenCvSharp.Point(-1, -1));

                Cv2.MorphologyEx(result, result, MorphTypes.Open, element);

                OpenCvSharp.Point[][] vContour = null;
                HierarchyIndex[] vhi = null;

                Cv2.FindContours(result, out vContour, out vhi, RetrievalModes.External, ContourApproximationModes.ApproxNone);
                Mat imgContour = new Mat(Img.Size(), MatType.CV_8UC1);

                List<Point2f> vPtC = new List<Point2f>();

                for (int u = 0; u < vContour.Length; u++)
                {
                    RotatedRect rRect = Cv2.MinAreaRect(vContour[u]);

                    //if (Img.Size().Width > Img.Size().Height)
                    //{
                    //    if (rRect.Size.Width > Pm.LineWidthMax)
                    //        continue;

                    //    if (rRect.Size.Width < Pm.LineWidthMin)
                    //        continue;
                    //}
    
                    vPtC.Add(rRect.Center);

                    SelectContour.Add(vContour[u].ToArray());
                }



                if (Img.Size().Width > Img.Size().Height)
                {

                    for (int i = 0; i < vPtC.Count-1; i++)
                    {
                        float dist = Math.Abs(vPtC[i].X - vPtC[i + 1].X);

                        xMeasureResult.Add(new Tuple<Point2f, Point2f, float>(vPtC[i], vPtC[i+1], dist));
                    }

                }
                else
                {

                    for (int i = 0; i < vPtC.Count-1; i++)
                    {
                        float dist = Math.Abs(vPtC[i].Y - vPtC[i + 1].Y);

                        yMeasureResult.Add(new Tuple<Point2f, Point2f, float>(vPtC[i], vPtC[i + 1], dist));
                    }

                }

            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir">0: X方向量測  1:Y方向量測</param>
        /// <param name="vContour"></param>
        /// <param name="result"></param>
        /// <param name="ContourSelected"></param>
        private static void GetMeasureResult(int dir, OpenCvSharp.Point[][] vContour, out List<Tuple<Point2f, Point2f, float>> result,out List<OpenCvSharp.Point[]> ContourSelected)
        {
            result = new List<Tuple<Point2f, Point2f, float>>();
            ContourSelected = new List<OpenCvSharp.Point[]>();

            List<OpenCvSharp.Point[]> vAccept=new List<OpenCvSharp.Point[]>();
            for (int i = 0; i < vContour.Length; i++)
            {
                if (vContour[i].Length == 1)
                    continue;

                vAccept.Add(vContour[i]);
            }

            List<Point2f> vPtRef=new List<Point2f>();
            for (int i = 0; i < vAccept.Count; i++)
            {
                float xx = 0; float yy = 0;
                for (int j = 0; j < vAccept[i].Length; j++)
                {
                    xx += vAccept[i][j].X;
                    yy += vAccept[i][j].Y;
                }

                vPtRef.Add(new Point2f(xx / vAccept[i].Length, yy / vAccept[i].Length));
            }

            Dictionary<int, OpenCvSharp.Point[]> dicPoints = new Dictionary<int, OpenCvSharp.Point[]>();

            for (int i = 0; i < vAccept.Count - 1; i++)
            {
                if (vAccept.Count == 1)
                    break;

                float dist;

                if (dir == 0)
                    dist = Math.Abs(vPtRef[i].X - vPtRef[i + 1].X);
                else
                    dist = Math.Abs(vPtRef[i].Y - vPtRef[i + 1].Y);

                if (dist < 1)
                    continue;

                if (!dicPoints.ContainsKey(i))
                    dicPoints.Add(i, vAccept[i]);

                if (!dicPoints.ContainsKey(i+1))
                    dicPoints.Add(i+1, vAccept[i+1]);


                result.Add(new Tuple<Point2f, Point2f, float>(vPtRef[i], vPtRef[i + 1], dist));
            }

            ContourSelected = (List<OpenCvSharp.Point[]>)dicPoints.Values.ToList();
        }
        


        public static Mat BmpToMat(Bitmap bitImg)
        {
            int height = bitImg.Height;
            int width = bitImg.Width;
            //鎖住Bitmap整個影像內容
            BitmapData bitmapData = bitImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            //取得影像資料的起始位置
            IntPtr imgPtr = bitmapData.Scan0;
            //影像scan的寬度
            int stride = bitmapData.Stride;
            //影像陣列的實際寬度

            int channels = stride / width;

            int widthByte = width * channels;
            //所Padding的Byte數
            int skipByte = stride - widthByte;
            //設定預定存放的rgb三維陣列
            //int[,,] rgbData = new int[width, height, channels];

            IntPtr ptr = Marshal.AllocHGlobal(width * height);
            
            #region 讀取RGB資料
            //注意C#的GDI+內的影像資料順序為BGR, 非一般熟悉的順序RGB
            //因此我們把順序調回原來的陣列順序排放BGR->RGB

            //for (int i = 0; i < selectedWidth; i++)
            //    for (int j = 0; j < selectedHeight; j++)
            //    { }

            unsafe
            {
                byte* p = (byte*)(void*)imgPtr;
                byte* bPtr = (byte*)(void*)ptr;

                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        int val = 0;

                        for (int k = 0; k < channels; k++)
                        {
                            val += p[0];
                            p++;

                        }

                        val /= channels;    
                        bPtr[i+j*width] = (byte)val;
                    }
                    p += skipByte;
                }
            }

            //解開記憶體鎖
            bitImg.UnlockBits(bitmapData);

            #endregion


            Mat result = Mat.FromPixelData(height,width, MatType.CV_8UC1, ptr);
            //FromPixelData(int rows, int cols, MatType type, IntPtr data
            //result.Data = ptr;

            return result;
        }


        public void AlogoParameterUpdate(MeasurePms _pm)
        {
            Pms = _pm;

            if (Image == null)
                return;

            if (measureRectImg.Width * measureRectImg.Height==0)
                return;

            Bitmap CroppedImage = Image.Clone(new System.Drawing.Rectangle(measureRectImg.X, measureRectImg.Y, measureRectImg.Width, measureRectImg.Height), Image.PixelFormat);
            Mat tmp = BmpToMat(CroppedImage);
            LineIntervalMeasurement(tmp, out _xMeasureResult, out _yMeasureResult,out lstContour, Pms);
            isMeasuring = true;
            CroppedImage.Dispose();
        }
    }


    public class MeasurePms
    {
        public MeasurePms()
        {
            IsColorDifferent = true;
            IsThresholdInvert = true;
            ThresholdValue = 125;
            Filter_Size = 10;
            SelectSide = -1;
            IsEgeMode = true;
            LineWidthFilter = 35;
        }

        public bool IsColorDifferent;
        public bool IsThresholdInvert;
        public int  ThresholdValue;
        public int  Filter_Size;
        public int  SelectSide;
        public bool IsEgeMode;
        public int LineWidthFilter;

    };

}
