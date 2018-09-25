using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Converter conv = new Converter();
        Transformation transformation = new Transformation();
        Histogram histogram = new Histogram();
        List<Point> points = new List<Point>();
        string path = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void chooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "bmp files (*.bmp)|*.bmp|yuv files (*.yuv)|*.yuv";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                toConvertLabel.Text = "File to convert: " + path;
            }
        }

        private void toYUVButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("bmp"))
                {
                    BMPFileInfo bmp = (BMPFileInfo)FileReader.ReadFile(path);
                    YUVFileInfo yuv = conv.GetYUVFromBMP(bmp);
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "yuv files (*.yuv)|*.yuv";
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        yuv.WriteToFile(sfd.FileName);
                    }
                }
                else
                    MessageBox.Show("Wrong file path!");
            }
            else
            {
                MessageBox.Show("Wrong file path!");
            }
        }

        private void toBMPButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("yuv"))
                {
                    int width, height;
                    bool parsed1 = Int32.TryParse(widthTextBox.Text, out width);
                    bool parsed2 = Int32.TryParse(heightBox.Text, out height);
                    if (parsed1 && parsed2)
                    {
                        try
                        {
                            YUVFileInfo yuv = (YUVFileInfo)FileReader.ReadFile(path);
                            BMPFileInfo bmp = conv.GetBMPFromYUV(yuv, width, height);
                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.Filter = "bmp files (*.bmp)|*.bmp";
                            sfd.RestoreDirectory = true;
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                bmp.WriteToFile(sfd.FileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Width and height allow only numbers");
                    }
                }
                else
                    MessageBox.Show("Wrong file path!");
            }
            else
            {
                MessageBox.Show("Wrong file path!");
            }
        }

        private void widthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void heightBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void gammaBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',';
        }

        private void negativeButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("bmp"))
                {
                    BMPFileInfo bmp = (BMPFileInfo)FileReader.ReadFile(path);
                    BMPFileInfo result = transformation.GetNegative(bmp);
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "bmp files (*.bmp)|*.bmp";
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        result.WriteToFile(sfd.FileName);
                    }
                }
                else
                    MessageBox.Show("File must have bmp extension!");
            }
            else
            {
                MessageBox.Show("Wrong file path!");
            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("bmp"))
                {
                        BMPFileInfo bmp = (BMPFileInfo)FileReader.ReadFile(path);
                        BMPFileInfo result = transformation.GetLogarithmic(bmp);
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "bmp files (*.bmp)|*.bmp";
                        sfd.RestoreDirectory = true;
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            result.WriteToFile(sfd.FileName);
                        }
                }
                else
                    MessageBox.Show("File must have bmp extension!");
            }
            else
            {
                MessageBox.Show("Wrong file path!");
            }
        }

        private void reverseLogButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("bmp"))
                {
                        BMPFileInfo bmp = (BMPFileInfo)FileReader.ReadFile(path);
                        BMPFileInfo result = transformation.GetReverseLogarithmic(bmp);
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "bmp files (*.bmp)|*.bmp";
                        sfd.RestoreDirectory = true;
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            result.WriteToFile(sfd.FileName);
                        }
                }
                else
                    MessageBox.Show("File must have bmp extension!");
            }
            else
            {
                MessageBox.Show("Wrong file path!");
            }
        }

        private void grayscaleButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("bmp"))
                {
                    BMPFileInfo bmp = (BMPFileInfo)FileReader.ReadFile(path);
                    BMPFileInfo result = transformation.GetGrayscale(bmp);
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "bmp files (*.bmp)|*.bmp";
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        result.WriteToFile(sfd.FileName);
                    }
                }
                else
                    MessageBox.Show("File must have bmp extension!");
            }
            else
            {
                MessageBox.Show("Wrong file path!");
            }
        }

        private void powerButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("bmp"))
                {
                    double gamma;
                    bool parsed = Double.TryParse(gammaTextBox.Text, out gamma);
                    if (parsed)
                    {
                        BMPFileInfo bmp = (BMPFileInfo)FileReader.ReadFile(path);
                        BMPFileInfo result = transformation.GetPower(bmp, gamma);
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "bmp files (*.bmp)|*.bmp";
                        sfd.RestoreDirectory = true;
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            result.WriteToFile(sfd.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong gamma value!");
                    }
                }
                else
                    MessageBox.Show("File must have bmp extension!");
            }
            else
            {
                MessageBox.Show("Wrong file path!");
            }
        }

        private void piecewiseButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("bmp"))
                {
                        BMPFileInfo bmp = (BMPFileInfo)FileReader.ReadFile(path);
                        BMPFileInfo result = transformation.GetPiecewiseLinear(bmp, points);
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "bmp files (*.bmp)|*.bmp";
                        sfd.RestoreDirectory = true;
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            result.WriteToFile(sfd.FileName);
                        }
                }
                else
                    MessageBox.Show("File must have bmp extension!");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int x, y;
            bool parsed1 = Int32.TryParse(xBox.Text, out x);
            bool parsed2 = Int32.TryParse(yBox.Text, out y);
            if (parsed1 && parsed2 && x >= 0 && x <= 255 && y >= 0 && y <= 255)
            {
                    Point point = new Point((byte)x, (byte)y);
                    points.Add(point);
                    pointsLabel.Text = pointsLabel.Text + "X:" + x + " Y:" + y + "; ";
            }
            else
            {
                MessageBox.Show("Wrong X and Y values");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            pointsLabel.Text = "Points: ";
        }

        private void buildHistogramButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("bmp"))
                {
                    BMPFileInfo bmp = (BMPFileInfo)FileReader.ReadFile(path);
                    var result = histogram.BuildHistogram(bmp);
                    histogramChart.Series[0].Points.Clear();
                    for (int i = 0; i < result.Length; i++)
                    {
                        histogramChart.Series[0].Points.AddXY(i, result[i]);
                    }
                    histogramChart.Series[0].Name = "Histogram";
                }
                else
                    MessageBox.Show("File must have bmp extension!");
            }
        }

        private void equalizeButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("bmp"))
                {
                    BMPFileInfo bmp = (BMPFileInfo)FileReader.ReadFile(path);
                    BMPFileInfo result = histogram.EqualizeHistogram(bmp);
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "bmp files (*.bmp)|*.bmp";
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        result.WriteToFile(sfd.FileName);
                    }
                }
                else
                    MessageBox.Show("File must have bmp extension!");
            }
        }

        private void equalizeButton2_Click(object sender, EventArgs e)
        {
            if (path.Length > 3)
            {
                string ext = path.Substring(Math.Max(0, path.Length - 3)).ToLower();
                if (ext.Equals("bmp"))
                {
                    BMPFileInfo bmp = (BMPFileInfo)FileReader.ReadFile(path);
                    BMPFileInfo result = histogram.EqualizeHistogramByYUV(bmp);
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "bmp files (*.bmp)|*.bmp";
                    sfd.RestoreDirectory = true;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        result.WriteToFile(sfd.FileName);
                    }
                }
                else
                    MessageBox.Show("File must have bmp extension!");
            }
        }

        private void xBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void yBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
