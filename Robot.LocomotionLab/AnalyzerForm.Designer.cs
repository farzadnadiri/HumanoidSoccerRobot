namespace Robot.Locomotion
{
    partial class AnalyzerForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_DarwinOP_Walk_Tuner_Right = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBox_Walk = new System.Windows.Forms.CheckBox();
            this.timer_Updater = new System.Windows.Forms.Timer(this.components);
            this.checkBox_IMU = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_DarwinOP_Walk_Tuner_Right)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_DarwinOP_Walk_Tuner_Right
            // 
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.AxisX.Interval = 50D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.Interval = 1D;
            chartArea1.AxisX.MajorTickMark.Interval = 10D;
            chartArea1.AxisX.Maximum = 250D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.MinorGrid.Interval = 50D;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.Interval = 20D;
            chartArea1.AxisY.MajorTickMark.Interval = 10D;
            chartArea1.AxisY.Maximum = 180D;
            chartArea1.AxisY.Minimum = -180D;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "MainArea";
            this.chart_DarwinOP_Walk_Tuner_Right.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_DarwinOP_Walk_Tuner_Right.Legends.Add(legend1);
            this.chart_DarwinOP_Walk_Tuner_Right.Location = new System.Drawing.Point(12, 12);
            this.chart_DarwinOP_Walk_Tuner_Right.Name = "chart_DarwinOP_Walk_Tuner_Right";
            series1.ChartArea = "MainArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Lime;
            series1.Legend = "Legend1";
            series1.Name = "HipYaw";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "MainArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DeepSkyBlue;
            series2.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series2.LabelBorderWidth = 6;
            series2.Legend = "Legend1";
            series2.Name = "HipRoll";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.ChartArea = "MainArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Yellow;
            series3.Legend = "Legend1";
            series3.Name = "HipPitch";
            series4.ChartArea = "MainArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Fuchsia;
            series4.Legend = "Legend1";
            series4.Name = "Knee";
            series5.ChartArea = "MainArea";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "AnklePitch";
            series6.ChartArea = "MainArea";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Green;
            series6.Legend = "Legend1";
            series6.Name = "AnkleRoll";
            series7.ChartArea = "MainArea";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "FilteredAnglePitch";
            series8.ChartArea = "MainArea";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "FilteredAngleRoll";
            series9.ChartArea = "MainArea";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Legend = "Legend1";
            series9.Name = "FilteredAngleYaw";
            series10.ChartArea = "MainArea";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.Name = "GyroX";
            series11.ChartArea = "MainArea";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.Name = "GyroY";
            series12.ChartArea = "MainArea";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.Name = "GyroZ";
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series1);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series2);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series3);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series4);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series5);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series6);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series7);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series8);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series9);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series10);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series11);
            this.chart_DarwinOP_Walk_Tuner_Right.Series.Add(series12);
            this.chart_DarwinOP_Walk_Tuner_Right.Size = new System.Drawing.Size(551, 308);
            this.chart_DarwinOP_Walk_Tuner_Right.TabIndex = 4;
            this.chart_DarwinOP_Walk_Tuner_Right.Text = "DarwinOP Walk Engin Tunner_Right";
            // 
            // checkBox_Walk
            // 
            this.checkBox_Walk.AutoSize = true;
            this.checkBox_Walk.Location = new System.Drawing.Point(587, 12);
            this.checkBox_Walk.Name = "checkBox_Walk";
            this.checkBox_Walk.Size = new System.Drawing.Size(51, 17);
            this.checkBox_Walk.TabIndex = 5;
            this.checkBox_Walk.Text = "Walk";
            this.checkBox_Walk.UseVisualStyleBackColor = true;
            this.checkBox_Walk.CheckedChanged += new System.EventHandler(this.checkBox_Walk_CheckedChanged);
            // 
            // timer_Updater
            // 
            this.timer_Updater.Enabled = true;
            this.timer_Updater.Interval = 10;
            this.timer_Updater.Tick += new System.EventHandler(this.timer_Updater_Tick);
            // 
            // checkBox_IMU
            // 
            this.checkBox_IMU.AutoSize = true;
            this.checkBox_IMU.Location = new System.Drawing.Point(587, 36);
            this.checkBox_IMU.Name = "checkBox_IMU";
            this.checkBox_IMU.Size = new System.Drawing.Size(46, 17);
            this.checkBox_IMU.TabIndex = 6;
            this.checkBox_IMU.Text = "IMU";
            this.checkBox_IMU.UseVisualStyleBackColor = true;
            this.checkBox_IMU.CheckedChanged += new System.EventHandler(this.checkBox_IMU_CheckedChanged);
            // 
            // AnalyzerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 334);
            this.Controls.Add(this.checkBox_IMU);
            this.Controls.Add(this.checkBox_Walk);
            this.Controls.Add(this.chart_DarwinOP_Walk_Tuner_Right);
            this.Name = "AnalyzerForm";
            this.Text = "AnalyzerForm";
            ((System.ComponentModel.ISupportInitialize)(this.chart_DarwinOP_Walk_Tuner_Right)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_DarwinOP_Walk_Tuner_Right;
        private System.Windows.Forms.CheckBox checkBox_Walk;
        private System.Windows.Forms.Timer timer_Updater;
        private System.Windows.Forms.CheckBox checkBox_IMU;
    }
}