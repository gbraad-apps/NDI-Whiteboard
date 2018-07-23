using System;
using System.Windows.Input;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;
using Canvas = System.Windows.Controls.Canvas;

namespace Whiteboard
{
    class WhiteboardCanvas : Canvas
    {

        private double InitX = -1;
        private double InitY = -1;

        private bool paintOn;
        private double brushThickness;
        public System.Windows.Media.Brush BrushColor = Brushes.Black;

        public double BrushThickness { get => brushThickness; set => brushThickness = value; }
        public bool PaintOn { get => paintOn; set => paintOn = value; }

        public WhiteboardCanvas()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.MouseUp += WhiteboardCanvas_MouseUp;
            this.MouseDown += WhiteboardCanvas_MouseDown;
            this.MouseEnter += WhiteboardCanvas_MouseEnter;
            this.MouseLeave += WhiteboardCanvas_MouseLeave;
            this.MouseMove += WhiteboardCanvas_MouseMove;

            brushThickness = 1.0;
        }

        public void Paint(object sender, MouseEventArgs e)
        {
            if (PaintOn)
            {
                double X = e.GetPosition(this).X;
                double Y = e.GetPosition(this).Y;

                Line line = new Line()
                {
                    Stroke = BrushColor,
                    StrokeThickness = BrushThickness,
                    X1 = InitX,
                    Y1 = InitY,
                    X2 = X,
                    Y2 = Y
                };

                if (InitX == -1 || InitY == -1)
                {
                    line.X1 = X;
                    line.Y1 = Y;
                }

                this.Children.Add(line);

                InitX = X;
                InitY = Y;
            }
        }

        public void BeginPaint(object sender, MouseButtonEventArgs e)
        {
            PaintOn = true;
        }

        public void StopPaint(object sender, MouseButtonEventArgs e)
        {
            PaintOn = false;

            InitX = -1;
            InitY = -1;
        }


        private void WhiteboardCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BeginPaint(sender, e);
        }

        private void WhiteboardCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Paint(sender, e);
        }

        private void WhiteboardCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StopPaint(sender, e);
        }

        private void WhiteboardCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            StopPaint(sender, null);
        }

        private void WhiteboardCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                BeginPaint(sender, null);
            }
        }


        public void SetPenColor(System.Windows.Media.Brush color)
        {
            BrushColor = color;
        }

        public void Undo()
        {
            if (this.Children.Count > 0)
            {
                this.Children.RemoveAt(this.Children.Count - 1);
            }
        }

        public void Clear()
        {
            this.Children.Clear();
        }

    }
}
