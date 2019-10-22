using DrawLinesHelper.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DrawLinesHelper.View
{
    public partial class MainWindow : Window
    {
        private string _json { get; set; }
        private int _lineTickness { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new M
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                _json = File.ReadAllText(openFileDialog.FileName);

            DrawLines(_json);
        }

        private void btnClearJson_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();

        }

        private void btnSaveImage_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)myCanvas.Width, (int)myCanvas.Height, 96d, 96d, PixelFormats.Default);
            rtb.Render(myCanvas);

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                MessageBox.Show(saveFileDialog.FileName);
                BitmapEncoder encoder = new JpegBitmapEncoder();
                using (FileStream outStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    encoder.Frames.Add(BitmapFrame.Create(rtb));
                    encoder.Save(outStream);
                }
            }
        }

        private void DrawLines(string json)
        {
            List<CutsCoordinates> bb = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CutsCoordinates>>(json);

            foreach (var item in bb)
            {
                var line = new Line();
                line.Stroke = Brushes.HotPink;

                line.X1 = item.X1 / 2;
                line.X2 = item.X2 / 2;
                line.Y1 = item.Y1 / 2;
                line.Y2 = item.Y2 / 2;

                line.StrokeThickness = 2;
                myCanvas.Children.Add(line);
            }

            var shapeLine = new Rectangle() { Height = 1219 / 2, Width = 2438 / 2, VerticalAlignment = VerticalAlignment.Bottom, Stroke = Brushes.Black };

            myCanvas.Children.Add(shapeLine);
        }

        private void SliderLineThickness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newTickness = Convert.ToInt32(e.NewValue);

        }
    }
}
