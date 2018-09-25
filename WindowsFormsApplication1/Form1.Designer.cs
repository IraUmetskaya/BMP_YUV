namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chooseFile = new System.Windows.Forms.Button();
            this.toYUVButton = new System.Windows.Forms.Button();
            this.toConvertLabel = new System.Windows.Forms.Label();
            this.toBMPButton = new System.Windows.Forms.Button();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.negativeButton = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.reverseLogButton = new System.Windows.Forms.Button();
            this.grayscaleButton = new System.Windows.Forms.Button();
            this.powerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gammaTextBox = new System.Windows.Forms.TextBox();
            this.piecewiseButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.xBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.yBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.buildHistogramButton = new System.Windows.Forms.Button();
            this.histogramChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.equalizeButton = new System.Windows.Forms.Button();
            this.equalizeButton2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.histogramChart)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseFile
            // 
            this.chooseFile.Location = new System.Drawing.Point(12, 12);
            this.chooseFile.Name = "chooseFile";
            this.chooseFile.Size = new System.Drawing.Size(117, 23);
            this.chooseFile.TabIndex = 0;
            this.chooseFile.Text = "Choose file";
            this.chooseFile.UseVisualStyleBackColor = true;
            this.chooseFile.Click += new System.EventHandler(this.chooseFile_Click);
            // 
            // toYUVButton
            // 
            this.toYUVButton.Location = new System.Drawing.Point(12, 41);
            this.toYUVButton.Name = "toYUVButton";
            this.toYUVButton.Size = new System.Drawing.Size(117, 23);
            this.toYUVButton.TabIndex = 1;
            this.toYUVButton.Text = "Convert to YUV";
            this.toYUVButton.UseVisualStyleBackColor = true;
            this.toYUVButton.Click += new System.EventHandler(this.toYUVButton_Click);
            // 
            // toConvertLabel
            // 
            this.toConvertLabel.AutoSize = true;
            this.toConvertLabel.Location = new System.Drawing.Point(135, 17);
            this.toConvertLabel.Name = "toConvertLabel";
            this.toConvertLabel.Size = new System.Drawing.Size(77, 13);
            this.toConvertLabel.TabIndex = 2;
            this.toConvertLabel.Text = "File to convert:";
            // 
            // toBMPButton
            // 
            this.toBMPButton.Location = new System.Drawing.Point(12, 70);
            this.toBMPButton.Name = "toBMPButton";
            this.toBMPButton.Size = new System.Drawing.Size(117, 23);
            this.toBMPButton.TabIndex = 4;
            this.toBMPButton.Text = "Convert to BMP";
            this.toBMPButton.UseVisualStyleBackColor = true;
            this.toBMPButton.Click += new System.EventHandler(this.toBMPButton_Click);
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(179, 72);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(70, 20);
            this.widthTextBox.TabIndex = 5;
            this.widthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.widthTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Width:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(255, 75);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(41, 13);
            this.heightLabel.TabIndex = 7;
            this.heightLabel.Text = "Height:";
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(302, 72);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(70, 20);
            this.heightBox.TabIndex = 8;
            this.heightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.heightBox_KeyPress);
            // 
            // negativeButton
            // 
            this.negativeButton.Location = new System.Drawing.Point(12, 148);
            this.negativeButton.Name = "negativeButton";
            this.negativeButton.Size = new System.Drawing.Size(117, 23);
            this.negativeButton.TabIndex = 9;
            this.negativeButton.Text = "Negative";
            this.negativeButton.UseVisualStyleBackColor = true;
            this.negativeButton.Click += new System.EventHandler(this.negativeButton_Click);
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(13, 177);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(116, 23);
            this.logButton.TabIndex = 10;
            this.logButton.Text = "Logarithmic";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // reverseLogButton
            // 
            this.reverseLogButton.Location = new System.Drawing.Point(133, 178);
            this.reverseLogButton.Name = "reverseLogButton";
            this.reverseLogButton.Size = new System.Drawing.Size(116, 23);
            this.reverseLogButton.TabIndex = 13;
            this.reverseLogButton.Text = "Reverse logarithmic";
            this.reverseLogButton.UseVisualStyleBackColor = true;
            this.reverseLogButton.Click += new System.EventHandler(this.reverseLogButton_Click);
            // 
            // grayscaleButton
            // 
            this.grayscaleButton.Location = new System.Drawing.Point(13, 119);
            this.grayscaleButton.Name = "grayscaleButton";
            this.grayscaleButton.Size = new System.Drawing.Size(116, 23);
            this.grayscaleButton.TabIndex = 14;
            this.grayscaleButton.Text = "Grayscale";
            this.grayscaleButton.UseVisualStyleBackColor = true;
            this.grayscaleButton.Click += new System.EventHandler(this.grayscaleButton_Click);
            // 
            // powerButton
            // 
            this.powerButton.Location = new System.Drawing.Point(13, 206);
            this.powerButton.Name = "powerButton";
            this.powerButton.Size = new System.Drawing.Size(116, 23);
            this.powerButton.TabIndex = 15;
            this.powerButton.Text = "Power";
            this.powerButton.UseVisualStyleBackColor = true;
            this.powerButton.Click += new System.EventHandler(this.powerButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Gamma:";
            // 
            // gammaTextBox
            // 
            this.gammaTextBox.Location = new System.Drawing.Point(179, 207);
            this.gammaTextBox.Name = "gammaTextBox";
            this.gammaTextBox.Size = new System.Drawing.Size(70, 20);
            this.gammaTextBox.TabIndex = 17;
            this.gammaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gammaBox_KeyPress);
            // 
            // piecewiseButton
            // 
            this.piecewiseButton.Location = new System.Drawing.Point(13, 236);
            this.piecewiseButton.Name = "piecewiseButton";
            this.piecewiseButton.Size = new System.Drawing.Size(116, 23);
            this.piecewiseButton.TabIndex = 18;
            this.piecewiseButton.Text = "Piecewise Linear";
            this.piecewiseButton.UseVisualStyleBackColor = true;
            this.piecewiseButton.Click += new System.EventHandler(this.piecewiseButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "X:";
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(158, 238);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(33, 20);
            this.xBox.TabIndex = 20;
            this.xBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Y:";
            // 
            // yBox
            // 
            this.yBox.Location = new System.Drawing.Point(216, 238);
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(33, 20);
            this.yBox.TabIndex = 22;
            this.yBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.yBox_KeyPress);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(13, 265);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 23;
            this.addButton.Text = "Add point";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(94, 265);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 24;
            this.clearButton.Text = "Clear points";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(175, 270);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(39, 13);
            this.pointsLabel.TabIndex = 25;
            this.pointsLabel.Text = "Points:";
            // 
            // buildHistogramButton
            // 
            this.buildHistogramButton.Location = new System.Drawing.Point(13, 314);
            this.buildHistogramButton.Name = "buildHistogramButton";
            this.buildHistogramButton.Size = new System.Drawing.Size(116, 23);
            this.buildHistogramButton.TabIndex = 26;
            this.buildHistogramButton.Text = "Build Histogram";
            this.buildHistogramButton.UseVisualStyleBackColor = true;
            this.buildHistogramButton.Click += new System.EventHandler(this.buildHistogramButton_Click);
            // 
            // histogramChart
            // 
            chartArea1.Name = "ChartArea1";
            this.histogramChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.histogramChart.Legends.Add(legend1);
            this.histogramChart.Location = new System.Drawing.Point(13, 344);
            this.histogramChart.Name = "histogramChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.histogramChart.Series.Add(series1);
            this.histogramChart.Size = new System.Drawing.Size(359, 233);
            this.histogramChart.TabIndex = 27;
            this.histogramChart.Text = "chart1";
            // 
            // equalizeButton
            // 
            this.equalizeButton.Location = new System.Drawing.Point(133, 314);
            this.equalizeButton.Name = "equalizeButton";
            this.equalizeButton.Size = new System.Drawing.Size(116, 23);
            this.equalizeButton.TabIndex = 28;
            this.equalizeButton.Text = "Equalize";
            this.equalizeButton.UseVisualStyleBackColor = true;
            this.equalizeButton.Click += new System.EventHandler(this.equalizeButton_Click);
            // 
            // equalizeButton2
            // 
            this.equalizeButton2.Location = new System.Drawing.Point(255, 314);
            this.equalizeButton2.Name = "equalizeButton2";
            this.equalizeButton2.Size = new System.Drawing.Size(116, 23);
            this.equalizeButton2.TabIndex = 29;
            this.equalizeButton2.Text = "Equalize (2-nd way)";
            this.equalizeButton2.UseVisualStyleBackColor = true;
            this.equalizeButton2.Click += new System.EventHandler(this.equalizeButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 589);
            this.Controls.Add(this.equalizeButton2);
            this.Controls.Add(this.equalizeButton);
            this.Controls.Add(this.histogramChart);
            this.Controls.Add(this.buildHistogramButton);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.yBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.xBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.piecewiseButton);
            this.Controls.Add(this.gammaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.powerButton);
            this.Controls.Add(this.grayscaleButton);
            this.Controls.Add(this.reverseLogButton);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.negativeButton);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.toBMPButton);
            this.Controls.Add(this.toConvertLabel);
            this.Controls.Add(this.toYUVButton);
            this.Controls.Add(this.chooseFile);
            this.Name = "Form1";
            this.Text = "Image Processing";
            ((System.ComponentModel.ISupportInitialize)(this.histogramChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseFile;
        private System.Windows.Forms.Button toYUVButton;
        private System.Windows.Forms.Label toConvertLabel;
        private System.Windows.Forms.Button toBMPButton;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Button negativeButton;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.Button reverseLogButton;
        private System.Windows.Forms.Button grayscaleButton;
        private System.Windows.Forms.Button powerButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gammaTextBox;
        private System.Windows.Forms.Button piecewiseButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox yBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Button buildHistogramButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogramChart;
        private System.Windows.Forms.Button equalizeButton;
        private System.Windows.Forms.Button equalizeButton2;
    }
}

