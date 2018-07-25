using System;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;
using Canvas = System.Windows.Controls.Canvas;

namespace Whiteboard
{
    class WhiteboardCanvas : Canvas
    {

        private double brushThickness = 1.0;
        private Color brushColor = Colors.Black;
        private InkCanvas inkCanvas;

        public WhiteboardCanvas()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            inkCanvas = new InkCanvas();
            inkCanvas.Background = Brushes.Transparent;
            SizeChanged += WhiteboardCanvas_SizeChanged;

            inkCanvas.UseCustomCursor = true;
            inkCanvas.Cursor = this.Cursor;

            this.Children.Add(inkCanvas);
        }

        private void WhiteboardCanvas_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            // make sure the ink canvas also changes
            inkCanvas.Width = this.Width;
            inkCanvas.Height = this.Height;
        }

        private void setPenAttributes(Color color, double size)
        {
            DrawingAttributes inkDA = new DrawingAttributes();
            inkDA.Width = size;
            inkDA.Height = size;
            inkDA.Color = color;
            inkCanvas.DefaultDrawingAttributes = inkDA;
        }

        public void SetPenColor(Color color)
        {
            brushColor = color;
            setPenAttributes(brushColor, brushThickness);
        }

        public void SetPenColor(Brush color)
        {
            var scb = (SolidColorBrush)color;
            SetPenColor(scb.Color);
        }

        public void SetPenThickness(double size)
        {
            brushThickness = size;
            setPenAttributes(brushColor, size);
        }


        public void Undo()
        {
            if (inkCanvas.Strokes.Count > 0)
            {
                inkCanvas.Strokes.RemoveAt(inkCanvas.Strokes.Count - 1);
            }
        }

        public void Clear()
        {
            inkCanvas.Strokes.Clear();
        }

    }
}
