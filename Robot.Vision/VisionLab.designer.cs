namespace Robot.Vision
{
    partial class VisionLab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisionLab));
            this.openFileDialog_Load = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_SaveAs = new System.Windows.Forms.SaveFileDialog();
            this.groupBox_Search = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown_MovingUnit = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown_MaxPan = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_MinPan = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_DownTilt = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_MiddleTilt = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_upTilt = new System.Windows.Forms.NumericUpDown();
            this.Lable_SearchInterval = new System.Windows.Forms.Label();
            this.radioButton_GoalScan = new System.Windows.Forms.RadioButton();
            this.radioButton_BallScan = new System.Windows.Forms.RadioButton();
            this.numericUpDown_SearchInterval = new System.Windows.Forms.NumericUpDown();
            this.button_SearchStart = new System.Windows.Forms.Button();
            this.groupBox_Track = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDown_TiltPosCon = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDown_PanPosCon = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDown_TiltSpeedCon = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_PanSpeedCon = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBox_EnableMouseTracker = new System.Windows.Forms.CheckBox();
            this.numericUpDown_VAngle = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown_HAngle = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_SquareSide = new System.Windows.Forms.NumericUpDown();
            this.label_TrackInterval = new System.Windows.Forms.Label();
            this.label_SquareSide = new System.Windows.Forms.Label();
            this.button_TrackStartPause = new System.Windows.Forms.Button();
            this.numericUpDown_TrackInterval = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox_Tilt = new System.Windows.Forms.GroupBox();
            this.label_TiltSlop = new System.Windows.Forms.Label();
            this.label_TiltSpeed = new System.Windows.Forms.Label();
            this.numericUpDown_TiltSpeed = new System.Windows.Forms.NumericUpDown();
            this.comboBox_TiltSlop = new System.Windows.Forms.ComboBox();
            this.numericUpDown_Tilt = new System.Windows.Forms.NumericUpDown();
            this.label_TiltGoalPosition = new System.Windows.Forms.Label();
            this.button_Tilt512 = new System.Windows.Forms.Button();
            this.groupBox_Pan = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_PanSpeed = new System.Windows.Forms.Label();
            this.numericUpDown_PanSpeed = new System.Windows.Forms.NumericUpDown();
            this.label_PanSlop = new System.Windows.Forms.Label();
            this.label_PanGoalPosition = new System.Windows.Forms.Label();
            this.comboBox_PanSlop = new System.Windows.Forms.ComboBox();
            this.numericUpDown_Pan = new System.Windows.Forms.NumericUpDown();
            this.button_Pan512 = new System.Windows.Forms.Button();
            this.groupBox_V = new System.Windows.Forms.GroupBox();
            this.trackBar_Vmax = new System.Windows.Forms.TrackBar();
            this.label_Vmin = new System.Windows.Forms.Label();
            this.label_Vmax = new System.Windows.Forms.Label();
            this.trackBar_Vmin = new System.Windows.Forms.TrackBar();
            this.numericUpDown_Vmin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Vmax = new System.Windows.Forms.NumericUpDown();
            this.groupBox_S = new System.Windows.Forms.GroupBox();
            this.trackBar_Smax = new System.Windows.Forms.TrackBar();
            this.label_Smin = new System.Windows.Forms.Label();
            this.label_Smax = new System.Windows.Forms.Label();
            this.trackBar_Smin = new System.Windows.Forms.TrackBar();
            this.numericUpDown_Smin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Smax = new System.Windows.Forms.NumericUpDown();
            this.groupBox_H = new System.Windows.Forms.GroupBox();
            this.trackBar_Hmax = new System.Windows.Forms.TrackBar();
            this.label_Hmin = new System.Windows.Forms.Label();
            this.label_Hmax = new System.Windows.Forms.Label();
            this.trackBar_Hmin = new System.Windows.Forms.TrackBar();
            this.numericUpDown_Hmin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Hmax = new System.Windows.Forms.NumericUpDown();
            this.button_Load = new System.Windows.Forms.Button();
            this.button_SaveAs = new System.Windows.Forms.Button();
            this.button_SaveColorSpace = new System.Windows.Forms.Button();
            this.imageBox_OtuputFrame = new Emgu.CV.UI.ImageBox();
            this.groupBox_SelectMode = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown_FieldDilate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_FieldErode = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_GoalDilate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_GoalErode = new System.Windows.Forms.NumericUpDown();
            this.radioButton_GrabedReal = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.radioButton_Value = new System.Windows.Forms.RadioButton();
            this.radioButton_Saturation = new System.Windows.Forms.RadioButton();
            this.radioButton_Hue = new System.Windows.Forms.RadioButton();
            this.numericUpDown_BallDilate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_BallErode = new System.Windows.Forms.NumericUpDown();
            this.radioButton_GrabedMask = new System.Windows.Forms.RadioButton();
            this.radioButton_GrabedBlackRed = new System.Windows.Forms.RadioButton();
            this.radioButton_Real = new System.Windows.Forms.RadioButton();
            this.button_CaptureStartPause = new System.Windows.Forms.Button();
            this.button_LoadColors = new System.Windows.Forms.Button();
            this.trackBarImgProcPan = new System.Windows.Forms.TrackBar();
            this.trackBarImgProcTilt = new System.Windows.Forms.TrackBar();
            this.groupBox_OutputFream = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox_ProcessedMode = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownOnField = new System.Windows.Forms.NumericUpDown();
            this.groupBox_RealTimeFpS = new System.Windows.Forms.GroupBox();
            this.button_FpsStart = new System.Windows.Forms.Button();
            this.Lable_RealTimeFPS = new System.Windows.Forms.Label();
            this.groupBox_ColorSpace = new System.Windows.Forms.GroupBox();
            this.label_GrabedHSV_Value = new System.Windows.Forms.Label();
            this.label_HSVGrabed = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Reload = new System.Windows.Forms.Button();
            this.label_HSVMinValue = new System.Windows.Forms.Label();
            this.label_HSVMaxValue = new System.Windows.Forms.Label();
            this.label_HSVmax = new System.Windows.Forms.Label();
            this.label_HSVmin = new System.Windows.Forms.Label();
            this.imageBox_ProcessedFrame = new Emgu.CV.UI.ImageBox();
            this.groupBox_HeadControlling = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton_ContourBall = new System.Windows.Forms.RadioButton();
            this.radioButton_ContourGoal = new System.Windows.Forms.RadioButton();
            this.Timer_FPS = new System.Windows.Forms.Timer(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.histogramBox1 = new Emgu.CV.UI.HistogramBox();
            this.groupBox_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MovingUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DownTilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MiddleTilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_upTilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SearchInterval)).BeginInit();
            this.groupBox_Track.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TiltPosCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PanPosCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TiltSpeedCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PanSpeedCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_VAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SquareSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TrackInterval)).BeginInit();
            this.groupBox_Tilt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TiltSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tilt)).BeginInit();
            this.groupBox_Pan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PanSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Pan)).BeginInit();
            this.groupBox_V.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Vmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Vmax)).BeginInit();
            this.groupBox_S.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Smax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Smin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Smin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Smax)).BeginInit();
            this.groupBox_H.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Hmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Hmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_OtuputFrame)).BeginInit();
            this.groupBox_SelectMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FieldDilate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FieldErode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GoalDilate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GoalErode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BallDilate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BallErode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImgProcPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImgProcTilt)).BeginInit();
            this.groupBox_OutputFream.SuspendLayout();
            this.groupBox_ProcessedMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOnField)).BeginInit();
            this.groupBox_RealTimeFpS.SuspendLayout();
            this.groupBox_ColorSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_ProcessedFrame)).BeginInit();
            this.groupBox_HeadControlling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog_Load
            // 
            this.openFileDialog_Load.Filter = "Xml Files|*.xml";
            this.openFileDialog_Load.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialogLoadFileOk);
            // 
            // saveFileDialog_SaveAs
            // 
            this.saveFileDialog_SaveAs.Filter = "Xml Files|*.xml";
            this.saveFileDialog_SaveAs.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialogSaveAsFileOk);
            // 
            // groupBox_Search
            // 
            this.groupBox_Search.Controls.Add(this.label10);
            this.groupBox_Search.Controls.Add(this.numericUpDown_MovingUnit);
            this.groupBox_Search.Controls.Add(this.label9);
            this.groupBox_Search.Controls.Add(this.numericUpDown_MaxPan);
            this.groupBox_Search.Controls.Add(this.label8);
            this.groupBox_Search.Controls.Add(this.numericUpDown_MinPan);
            this.groupBox_Search.Controls.Add(this.label7);
            this.groupBox_Search.Controls.Add(this.numericUpDown_DownTilt);
            this.groupBox_Search.Controls.Add(this.label6);
            this.groupBox_Search.Controls.Add(this.numericUpDown_MiddleTilt);
            this.groupBox_Search.Controls.Add(this.label5);
            this.groupBox_Search.Controls.Add(this.numericUpDown_upTilt);
            this.groupBox_Search.Controls.Add(this.Lable_SearchInterval);
            this.groupBox_Search.Controls.Add(this.radioButton_GoalScan);
            this.groupBox_Search.Controls.Add(this.radioButton_BallScan);
            this.groupBox_Search.Controls.Add(this.numericUpDown_SearchInterval);
            this.groupBox_Search.Controls.Add(this.button_SearchStart);
            this.groupBox_Search.Location = new System.Drawing.Point(151, 15);
            this.groupBox_Search.Name = "groupBox_Search";
            this.groupBox_Search.Size = new System.Drawing.Size(140, 252);
            this.groupBox_Search.TabIndex = 27;
            this.groupBox_Search.TabStop = false;
            this.groupBox_Search.Text = "Search";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 29;
            this.label10.Text = "Move Unit";
            // 
            // numericUpDown_MovingUnit
            // 
            this.numericUpDown_MovingUnit.Location = new System.Drawing.Point(77, 226);
            this.numericUpDown_MovingUnit.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_MovingUnit.Name = "numericUpDown_MovingUnit";
            this.numericUpDown_MovingUnit.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_MovingUnit.TabIndex = 28;
            this.numericUpDown_MovingUnit.ValueChanged += new System.EventHandler(this.numericUpDown_MovingUnit_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "Max Pan";
            // 
            // numericUpDown_MaxPan
            // 
            this.numericUpDown_MaxPan.Location = new System.Drawing.Point(77, 202);
            this.numericUpDown_MaxPan.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_MaxPan.Name = "numericUpDown_MaxPan";
            this.numericUpDown_MaxPan.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_MaxPan.TabIndex = 26;
            this.numericUpDown_MaxPan.ValueChanged += new System.EventHandler(this.numericUpDown_MaxPan_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Min Pan";
            // 
            // numericUpDown_MinPan
            // 
            this.numericUpDown_MinPan.Location = new System.Drawing.Point(77, 176);
            this.numericUpDown_MinPan.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_MinPan.Name = "numericUpDown_MinPan";
            this.numericUpDown_MinPan.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_MinPan.TabIndex = 24;
            this.numericUpDown_MinPan.ValueChanged += new System.EventHandler(this.numericUpDown_MinPan_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Down Tilt";
            // 
            // numericUpDown_DownTilt
            // 
            this.numericUpDown_DownTilt.Location = new System.Drawing.Point(77, 151);
            this.numericUpDown_DownTilt.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_DownTilt.Name = "numericUpDown_DownTilt";
            this.numericUpDown_DownTilt.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_DownTilt.TabIndex = 22;
            this.numericUpDown_DownTilt.ValueChanged += new System.EventHandler(this.numericUpDown_DownTilt_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Middle Tilt";
            // 
            // numericUpDown_MiddleTilt
            // 
            this.numericUpDown_MiddleTilt.Location = new System.Drawing.Point(78, 126);
            this.numericUpDown_MiddleTilt.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_MiddleTilt.Name = "numericUpDown_MiddleTilt";
            this.numericUpDown_MiddleTilt.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_MiddleTilt.TabIndex = 20;
            this.numericUpDown_MiddleTilt.ValueChanged += new System.EventHandler(this.numericUpDown_MiddleTilt_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "UpTilt";
            // 
            // numericUpDown_upTilt
            // 
            this.numericUpDown_upTilt.Location = new System.Drawing.Point(78, 102);
            this.numericUpDown_upTilt.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_upTilt.Name = "numericUpDown_upTilt";
            this.numericUpDown_upTilt.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_upTilt.TabIndex = 18;
            this.numericUpDown_upTilt.ValueChanged += new System.EventHandler(this.numericUpDown_upTilt_ValueChanged);
            // 
            // Lable_SearchInterval
            // 
            this.Lable_SearchInterval.AutoSize = true;
            this.Lable_SearchInterval.Location = new System.Drawing.Point(13, 80);
            this.Lable_SearchInterval.Name = "Lable_SearchInterval";
            this.Lable_SearchInterval.Size = new System.Drawing.Size(46, 15);
            this.Lable_SearchInterval.TabIndex = 17;
            this.Lable_SearchInterval.Text = "Interval";
            // 
            // radioButton_GoalScan
            // 
            this.radioButton_GoalScan.AutoSize = true;
            this.radioButton_GoalScan.Location = new System.Drawing.Point(81, 52);
            this.radioButton_GoalScan.Name = "radioButton_GoalScan";
            this.radioButton_GoalScan.Size = new System.Drawing.Size(54, 19);
            this.radioButton_GoalScan.TabIndex = 12;
            this.radioButton_GoalScan.Text = "Goal";
            this.radioButton_GoalScan.UseVisualStyleBackColor = true;
            this.radioButton_GoalScan.CheckedChanged += new System.EventHandler(this.RadioButtonGoalScanCheckedChanged);
            // 
            // radioButton_BallScan
            // 
            this.radioButton_BallScan.AutoSize = true;
            this.radioButton_BallScan.Checked = true;
            this.radioButton_BallScan.Location = new System.Drawing.Point(12, 52);
            this.radioButton_BallScan.Name = "radioButton_BallScan";
            this.radioButton_BallScan.Size = new System.Drawing.Size(49, 19);
            this.radioButton_BallScan.TabIndex = 11;
            this.radioButton_BallScan.TabStop = true;
            this.radioButton_BallScan.Text = "Ball";
            this.radioButton_BallScan.UseVisualStyleBackColor = true;
            this.radioButton_BallScan.CheckedChanged += new System.EventHandler(this.RadioButtonBallScanCheckedChanged);
            // 
            // numericUpDown_SearchInterval
            // 
            this.numericUpDown_SearchInterval.Location = new System.Drawing.Point(78, 78);
            this.numericUpDown_SearchInterval.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_SearchInterval.Name = "numericUpDown_SearchInterval";
            this.numericUpDown_SearchInterval.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_SearchInterval.TabIndex = 16;
            this.numericUpDown_SearchInterval.ValueChanged += new System.EventHandler(this.NumericUpDownSearchIntervalValueChanged);
            // 
            // button_SearchStart
            // 
            this.button_SearchStart.Location = new System.Drawing.Point(8, 15);
            this.button_SearchStart.Name = "button_SearchStart";
            this.button_SearchStart.Size = new System.Drawing.Size(123, 23);
            this.button_SearchStart.TabIndex = 10;
            this.button_SearchStart.Text = "Start";
            this.button_SearchStart.UseVisualStyleBackColor = true;
            this.button_SearchStart.Click += new System.EventHandler(this.ButtonSearchStartPauseClick);
            // 
            // groupBox_Track
            // 
            this.groupBox_Track.Controls.Add(this.label19);
            this.groupBox_Track.Controls.Add(this.numericUpDown_TiltPosCon);
            this.groupBox_Track.Controls.Add(this.label18);
            this.groupBox_Track.Controls.Add(this.numericUpDown_PanPosCon);
            this.groupBox_Track.Controls.Add(this.label16);
            this.groupBox_Track.Controls.Add(this.numericUpDown_TiltSpeedCon);
            this.groupBox_Track.Controls.Add(this.numericUpDown_PanSpeedCon);
            this.groupBox_Track.Controls.Add(this.label15);
            this.groupBox_Track.Controls.Add(this.checkBox_EnableMouseTracker);
            this.groupBox_Track.Controls.Add(this.numericUpDown_VAngle);
            this.groupBox_Track.Controls.Add(this.label14);
            this.groupBox_Track.Controls.Add(this.numericUpDown_HAngle);
            this.groupBox_Track.Controls.Add(this.numericUpDown_SquareSide);
            this.groupBox_Track.Controls.Add(this.label_TrackInterval);
            this.groupBox_Track.Controls.Add(this.label_SquareSide);
            this.groupBox_Track.Controls.Add(this.button_TrackStartPause);
            this.groupBox_Track.Controls.Add(this.numericUpDown_TrackInterval);
            this.groupBox_Track.Controls.Add(this.label17);
            this.groupBox_Track.Location = new System.Drawing.Point(7, 15);
            this.groupBox_Track.Name = "groupBox_Track";
            this.groupBox_Track.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_Track.Size = new System.Drawing.Size(140, 252);
            this.groupBox_Track.TabIndex = 17;
            this.groupBox_Track.TabStop = false;
            this.groupBox_Track.Text = "Track";
            this.groupBox_Track.Enter += new System.EventHandler(this.groupBox_Track_Enter);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 229);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 15);
            this.label19.TabIndex = 47;
            this.label19.Text = "TiltPosCon";
            // 
            // numericUpDown_TiltPosCon
            // 
            this.numericUpDown_TiltPosCon.DecimalPlaces = 2;
            this.numericUpDown_TiltPosCon.Location = new System.Drawing.Point(81, 226);
            this.numericUpDown_TiltPosCon.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_TiltPosCon.Name = "numericUpDown_TiltPosCon";
            this.numericUpDown_TiltPosCon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_TiltPosCon.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_TiltPosCon.TabIndex = 46;
            this.numericUpDown_TiltPosCon.ValueChanged += new System.EventHandler(this.numericUpDown_TiltPosCon_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 206);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 15);
            this.label18.TabIndex = 45;
            this.label18.Text = "PanPosCon";
            // 
            // numericUpDown_PanPosCon
            // 
            this.numericUpDown_PanPosCon.DecimalPlaces = 2;
            this.numericUpDown_PanPosCon.Location = new System.Drawing.Point(81, 203);
            this.numericUpDown_PanPosCon.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_PanPosCon.Name = "numericUpDown_PanPosCon";
            this.numericUpDown_PanPosCon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_PanPosCon.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_PanPosCon.TabIndex = 44;
            this.numericUpDown_PanPosCon.ValueChanged += new System.EventHandler(this.numericUpDown_PanPosCon_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 182);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 15);
            this.label16.TabIndex = 43;
            this.label16.Text = "TiltSpeedCon";
            // 
            // numericUpDown_TiltSpeedCon
            // 
            this.numericUpDown_TiltSpeedCon.DecimalPlaces = 2;
            this.numericUpDown_TiltSpeedCon.Location = new System.Drawing.Point(81, 179);
            this.numericUpDown_TiltSpeedCon.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_TiltSpeedCon.Name = "numericUpDown_TiltSpeedCon";
            this.numericUpDown_TiltSpeedCon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_TiltSpeedCon.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_TiltSpeedCon.TabIndex = 42;
            this.numericUpDown_TiltSpeedCon.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown_PanSpeedCon
            // 
            this.numericUpDown_PanSpeedCon.DecimalPlaces = 2;
            this.numericUpDown_PanSpeedCon.Location = new System.Drawing.Point(81, 156);
            this.numericUpDown_PanSpeedCon.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_PanSpeedCon.Name = "numericUpDown_PanSpeedCon";
            this.numericUpDown_PanSpeedCon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_PanSpeedCon.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_PanSpeedCon.TabIndex = 40;
            this.numericUpDown_PanSpeedCon.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 15);
            this.label15.TabIndex = 39;
            this.label15.Text = "V Angle";
            // 
            // checkBox_EnableMouseTracker
            // 
            this.checkBox_EnableMouseTracker.AutoSize = true;
            this.checkBox_EnableMouseTracker.Location = new System.Drawing.Point(6, 41);
            this.checkBox_EnableMouseTracker.Name = "checkBox_EnableMouseTracker";
            this.checkBox_EnableMouseTracker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox_EnableMouseTracker.Size = new System.Drawing.Size(147, 19);
            this.checkBox_EnableMouseTracker.TabIndex = 16;
            this.checkBox_EnableMouseTracker.Text = "EnableMouseTracker";
            this.checkBox_EnableMouseTracker.UseVisualStyleBackColor = true;
            this.checkBox_EnableMouseTracker.CheckedChanged += new System.EventHandler(this.CheckBoxEnableMouseTrackerCheckedChanged);
            // 
            // numericUpDown_VAngle
            // 
            this.numericUpDown_VAngle.DecimalPlaces = 2;
            this.numericUpDown_VAngle.Location = new System.Drawing.Point(81, 133);
            this.numericUpDown_VAngle.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_VAngle.Name = "numericUpDown_VAngle";
            this.numericUpDown_VAngle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_VAngle.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_VAngle.TabIndex = 38;
            this.numericUpDown_VAngle.ValueChanged += new System.EventHandler(this.numericUpDown_VAngle_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 15);
            this.label14.TabIndex = 37;
            this.label14.Text = "H Angle";
            // 
            // numericUpDown_HAngle
            // 
            this.numericUpDown_HAngle.DecimalPlaces = 2;
            this.numericUpDown_HAngle.Location = new System.Drawing.Point(81, 110);
            this.numericUpDown_HAngle.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_HAngle.Name = "numericUpDown_HAngle";
            this.numericUpDown_HAngle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_HAngle.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_HAngle.TabIndex = 36;
            this.numericUpDown_HAngle.ValueChanged += new System.EventHandler(this.numericUpDown_HAngle_ValueChanged);
            // 
            // numericUpDown_SquareSide
            // 
            this.numericUpDown_SquareSide.Location = new System.Drawing.Point(81, 63);
            this.numericUpDown_SquareSide.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown_SquareSide.Name = "numericUpDown_SquareSide";
            this.numericUpDown_SquareSide.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_SquareSide.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_SquareSide.TabIndex = 34;
            this.numericUpDown_SquareSide.ValueChanged += new System.EventHandler(this.numericUpDown_SquareSide_ValueChanged);
            // 
            // label_TrackInterval
            // 
            this.label_TrackInterval.AutoSize = true;
            this.label_TrackInterval.Location = new System.Drawing.Point(16, 90);
            this.label_TrackInterval.Name = "label_TrackInterval";
            this.label_TrackInterval.Size = new System.Drawing.Size(46, 15);
            this.label_TrackInterval.TabIndex = 16;
            this.label_TrackInterval.Text = "Interval";
            // 
            // label_SquareSide
            // 
            this.label_SquareSide.AutoSize = true;
            this.label_SquareSide.Location = new System.Drawing.Point(10, 68);
            this.label_SquareSide.Name = "label_SquareSide";
            this.label_SquareSide.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_SquareSide.Size = new System.Drawing.Size(75, 15);
            this.label_SquareSide.TabIndex = 35;
            this.label_SquareSide.Text = "Square Side";
            // 
            // button_TrackStartPause
            // 
            this.button_TrackStartPause.Location = new System.Drawing.Point(12, 15);
            this.button_TrackStartPause.Name = "button_TrackStartPause";
            this.button_TrackStartPause.Size = new System.Drawing.Size(122, 23);
            this.button_TrackStartPause.TabIndex = 7;
            this.button_TrackStartPause.Text = "Start";
            this.button_TrackStartPause.UseVisualStyleBackColor = true;
            this.button_TrackStartPause.Click += new System.EventHandler(this.ButtonTrackStartPauseClick);
            // 
            // numericUpDown_TrackInterval
            // 
            this.numericUpDown_TrackInterval.Location = new System.Drawing.Point(81, 87);
            this.numericUpDown_TrackInterval.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_TrackInterval.Name = "numericUpDown_TrackInterval";
            this.numericUpDown_TrackInterval.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_TrackInterval.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_TrackInterval.TabIndex = 12;
            this.numericUpDown_TrackInterval.ValueChanged += new System.EventHandler(this.NumericUpDownTrackIntervalValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 159);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 15);
            this.label17.TabIndex = 41;
            this.label17.Text = "PanSpeedCon";
            // 
            // groupBox_Tilt
            // 
            this.groupBox_Tilt.Controls.Add(this.label_TiltSlop);
            this.groupBox_Tilt.Controls.Add(this.label_TiltSpeed);
            this.groupBox_Tilt.Controls.Add(this.numericUpDown_TiltSpeed);
            this.groupBox_Tilt.Controls.Add(this.comboBox_TiltSlop);
            this.groupBox_Tilt.Controls.Add(this.numericUpDown_Tilt);
            this.groupBox_Tilt.Controls.Add(this.label_TiltGoalPosition);
            this.groupBox_Tilt.Controls.Add(this.button_Tilt512);
            this.groupBox_Tilt.Location = new System.Drawing.Point(154, 277);
            this.groupBox_Tilt.Name = "groupBox_Tilt";
            this.groupBox_Tilt.Size = new System.Drawing.Size(138, 125);
            this.groupBox_Tilt.TabIndex = 26;
            this.groupBox_Tilt.TabStop = false;
            this.groupBox_Tilt.Text = "Tilt";
            // 
            // label_TiltSlop
            // 
            this.label_TiltSlop.AutoSize = true;
            this.label_TiltSlop.Location = new System.Drawing.Point(7, 76);
            this.label_TiltSlop.Name = "label_TiltSlop";
            this.label_TiltSlop.Size = new System.Drawing.Size(32, 15);
            this.label_TiltSlop.TabIndex = 34;
            this.label_TiltSlop.Text = "Slop";
            // 
            // label_TiltSpeed
            // 
            this.label_TiltSpeed.AutoSize = true;
            this.label_TiltSpeed.Location = new System.Drawing.Point(7, 101);
            this.label_TiltSpeed.Name = "label_TiltSpeed";
            this.label_TiltSpeed.Size = new System.Drawing.Size(43, 15);
            this.label_TiltSpeed.TabIndex = 32;
            this.label_TiltSpeed.Text = "Speed";
            // 
            // numericUpDown_TiltSpeed
            // 
            this.numericUpDown_TiltSpeed.Location = new System.Drawing.Point(79, 99);
            this.numericUpDown_TiltSpeed.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_TiltSpeed.Name = "numericUpDown_TiltSpeed";
            this.numericUpDown_TiltSpeed.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_TiltSpeed.TabIndex = 31;
            this.numericUpDown_TiltSpeed.ValueChanged += new System.EventHandler(this.numericUpDown_TiltSpeed_ValueChanged);
            // 
            // comboBox_TiltSlop
            // 
            this.comboBox_TiltSlop.FormattingEnabled = true;
            this.comboBox_TiltSlop.Items.AddRange(new object[] {
            "128",
            "64",
            "32",
            "16",
            "8",
            "4",
            "2"});
            this.comboBox_TiltSlop.Location = new System.Drawing.Point(79, 72);
            this.comboBox_TiltSlop.Name = "comboBox_TiltSlop";
            this.comboBox_TiltSlop.Size = new System.Drawing.Size(50, 21);
            this.comboBox_TiltSlop.TabIndex = 29;
            this.comboBox_TiltSlop.SelectedIndexChanged += new System.EventHandler(this.comboBox_TiltSlop_SelectedIndexChanged);
            // 
            // numericUpDown_Tilt
            // 
            this.numericUpDown_Tilt.Location = new System.Drawing.Point(79, 46);
            this.numericUpDown_Tilt.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_Tilt.Name = "numericUpDown_Tilt";
            this.numericUpDown_Tilt.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Tilt.TabIndex = 13;
            this.numericUpDown_Tilt.ValueChanged += new System.EventHandler(this.NumericUpDownTiltValueChanged);
            // 
            // label_TiltGoalPosition
            // 
            this.label_TiltGoalPosition.AutoSize = true;
            this.label_TiltGoalPosition.Location = new System.Drawing.Point(6, 48);
            this.label_TiltGoalPosition.Name = "label_TiltGoalPosition";
            this.label_TiltGoalPosition.Size = new System.Drawing.Size(51, 15);
            this.label_TiltGoalPosition.TabIndex = 15;
            this.label_TiltGoalPosition.Text = "Position";
            // 
            // button_Tilt512
            // 
            this.button_Tilt512.Location = new System.Drawing.Point(6, 16);
            this.button_Tilt512.Name = "button_Tilt512";
            this.button_Tilt512.Size = new System.Drawing.Size(126, 23);
            this.button_Tilt512.TabIndex = 22;
            this.button_Tilt512.Text = "512";
            this.button_Tilt512.UseVisualStyleBackColor = true;
            this.button_Tilt512.Click += new System.EventHandler(this.ButtonTilt512Click);
            // 
            // groupBox_Pan
            // 
            this.groupBox_Pan.Controls.Add(this.groupBox2);
            this.groupBox_Pan.Controls.Add(this.label_PanSpeed);
            this.groupBox_Pan.Controls.Add(this.numericUpDown_PanSpeed);
            this.groupBox_Pan.Controls.Add(this.label_PanSlop);
            this.groupBox_Pan.Controls.Add(this.label_PanGoalPosition);
            this.groupBox_Pan.Controls.Add(this.comboBox_PanSlop);
            this.groupBox_Pan.Controls.Add(this.numericUpDown_Pan);
            this.groupBox_Pan.Controls.Add(this.button_Pan512);
            this.groupBox_Pan.Location = new System.Drawing.Point(8, 273);
            this.groupBox_Pan.Name = "groupBox_Pan";
            this.groupBox_Pan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox_Pan.Size = new System.Drawing.Size(140, 129);
            this.groupBox_Pan.TabIndex = 25;
            this.groupBox_Pan.TabStop = false;
            this.groupBox_Pan.Text = "Pan";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(15, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 27);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label_PanSpeed
            // 
            this.label_PanSpeed.AutoSize = true;
            this.label_PanSpeed.Location = new System.Drawing.Point(6, 102);
            this.label_PanSpeed.Name = "label_PanSpeed";
            this.label_PanSpeed.Size = new System.Drawing.Size(43, 15);
            this.label_PanSpeed.TabIndex = 27;
            this.label_PanSpeed.Text = "Speed";
            // 
            // numericUpDown_PanSpeed
            // 
            this.numericUpDown_PanSpeed.Location = new System.Drawing.Point(80, 100);
            this.numericUpDown_PanSpeed.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_PanSpeed.Name = "numericUpDown_PanSpeed";
            this.numericUpDown_PanSpeed.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_PanSpeed.TabIndex = 26;
            this.numericUpDown_PanSpeed.ValueChanged += new System.EventHandler(this.numericUpDown_PanSpeed_ValueChanged);
            // 
            // label_PanSlop
            // 
            this.label_PanSlop.AutoSize = true;
            this.label_PanSlop.Location = new System.Drawing.Point(6, 75);
            this.label_PanSlop.Name = "label_PanSlop";
            this.label_PanSlop.Size = new System.Drawing.Size(32, 15);
            this.label_PanSlop.TabIndex = 25;
            this.label_PanSlop.Text = "Slop";
            // 
            // label_PanGoalPosition
            // 
            this.label_PanGoalPosition.AutoSize = true;
            this.label_PanGoalPosition.Location = new System.Drawing.Point(6, 50);
            this.label_PanGoalPosition.Name = "label_PanGoalPosition";
            this.label_PanGoalPosition.Size = new System.Drawing.Size(51, 15);
            this.label_PanGoalPosition.TabIndex = 14;
            this.label_PanGoalPosition.Text = "Position";
            // 
            // comboBox_PanSlop
            // 
            this.comboBox_PanSlop.FormattingEnabled = true;
            this.comboBox_PanSlop.Items.AddRange(new object[] {
            "128",
            "64",
            "32",
            "16",
            "8",
            "4",
            "2"});
            this.comboBox_PanSlop.Location = new System.Drawing.Point(80, 73);
            this.comboBox_PanSlop.Name = "comboBox_PanSlop";
            this.comboBox_PanSlop.Size = new System.Drawing.Size(50, 21);
            this.comboBox_PanSlop.TabIndex = 23;
            this.comboBox_PanSlop.SelectedIndexChanged += new System.EventHandler(this.comboBox_PanSlop_SelectedIndexChanged);
            // 
            // numericUpDown_Pan
            // 
            this.numericUpDown_Pan.Location = new System.Drawing.Point(80, 47);
            this.numericUpDown_Pan.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_Pan.Name = "numericUpDown_Pan";
            this.numericUpDown_Pan.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Pan.TabIndex = 11;
            this.numericUpDown_Pan.ValueChanged += new System.EventHandler(this.NumericUpDownPanValueChanged);
            // 
            // button_Pan512
            // 
            this.button_Pan512.Location = new System.Drawing.Point(6, 17);
            this.button_Pan512.Name = "button_Pan512";
            this.button_Pan512.Size = new System.Drawing.Size(128, 23);
            this.button_Pan512.TabIndex = 21;
            this.button_Pan512.Text = "512";
            this.button_Pan512.UseVisualStyleBackColor = true;
            this.button_Pan512.Click += new System.EventHandler(this.ButtonPan512Click);
            // 
            // groupBox_V
            // 
            this.groupBox_V.Controls.Add(this.trackBar_Vmax);
            this.groupBox_V.Controls.Add(this.label_Vmin);
            this.groupBox_V.Controls.Add(this.label_Vmax);
            this.groupBox_V.Controls.Add(this.trackBar_Vmin);
            this.groupBox_V.Controls.Add(this.numericUpDown_Vmin);
            this.groupBox_V.Controls.Add(this.numericUpDown_Vmax);
            this.groupBox_V.Location = new System.Drawing.Point(396, 244);
            this.groupBox_V.Name = "groupBox_V";
            this.groupBox_V.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_V.Size = new System.Drawing.Size(292, 78);
            this.groupBox_V.TabIndex = 24;
            this.groupBox_V.TabStop = false;
            this.groupBox_V.Text = "V";
            // 
            // trackBar_Vmax
            // 
            this.trackBar_Vmax.Location = new System.Drawing.Point(32, 47);
            this.trackBar_Vmax.Maximum = 255;
            this.trackBar_Vmax.Name = "trackBar_Vmax";
            this.trackBar_Vmax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_Vmax.Size = new System.Drawing.Size(183, 56);
            this.trackBar_Vmax.TabIndex = 18;
            this.trackBar_Vmax.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Vmax.Scroll += new System.EventHandler(this.TrackBarVmaxScroll);
            // 
            // label_Vmin
            // 
            this.label_Vmin.AutoSize = true;
            this.label_Vmin.Location = new System.Drawing.Point(6, 23);
            this.label_Vmin.Name = "label_Vmin";
            this.label_Vmin.Size = new System.Drawing.Size(28, 15);
            this.label_Vmin.TabIndex = 20;
            this.label_Vmin.Text = "Min";
            // 
            // label_Vmax
            // 
            this.label_Vmax.AutoSize = true;
            this.label_Vmax.Location = new System.Drawing.Point(6, 49);
            this.label_Vmax.Name = "label_Vmax";
            this.label_Vmax.Size = new System.Drawing.Size(31, 15);
            this.label_Vmax.TabIndex = 21;
            this.label_Vmax.Text = "Max";
            // 
            // trackBar_Vmin
            // 
            this.trackBar_Vmin.Location = new System.Drawing.Point(32, 21);
            this.trackBar_Vmin.Maximum = 255;
            this.trackBar_Vmin.Name = "trackBar_Vmin";
            this.trackBar_Vmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_Vmin.Size = new System.Drawing.Size(183, 56);
            this.trackBar_Vmin.TabIndex = 16;
            this.trackBar_Vmin.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Vmin.Scroll += new System.EventHandler(this.TrackBarVminScroll);
            // 
            // numericUpDown_Vmin
            // 
            this.numericUpDown_Vmin.Location = new System.Drawing.Point(221, 19);
            this.numericUpDown_Vmin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_Vmin.Name = "numericUpDown_Vmin";
            this.numericUpDown_Vmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_Vmin.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Vmin.TabIndex = 17;
            this.numericUpDown_Vmin.ValueChanged += new System.EventHandler(this.NumericUpDownVminValueChanged);
            // 
            // numericUpDown_Vmax
            // 
            this.numericUpDown_Vmax.Location = new System.Drawing.Point(221, 47);
            this.numericUpDown_Vmax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_Vmax.Name = "numericUpDown_Vmax";
            this.numericUpDown_Vmax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_Vmax.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Vmax.TabIndex = 19;
            this.numericUpDown_Vmax.ValueChanged += new System.EventHandler(this.NumericUpDownVmaxValueChanged);
            // 
            // groupBox_S
            // 
            this.groupBox_S.Controls.Add(this.trackBar_Smax);
            this.groupBox_S.Controls.Add(this.label_Smin);
            this.groupBox_S.Controls.Add(this.label_Smax);
            this.groupBox_S.Controls.Add(this.trackBar_Smin);
            this.groupBox_S.Controls.Add(this.numericUpDown_Smin);
            this.groupBox_S.Controls.Add(this.numericUpDown_Smax);
            this.groupBox_S.Location = new System.Drawing.Point(398, 163);
            this.groupBox_S.Name = "groupBox_S";
            this.groupBox_S.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_S.Size = new System.Drawing.Size(290, 78);
            this.groupBox_S.TabIndex = 23;
            this.groupBox_S.TabStop = false;
            this.groupBox_S.Text = "S";
            // 
            // trackBar_Smax
            // 
            this.trackBar_Smax.Location = new System.Drawing.Point(34, 46);
            this.trackBar_Smax.Maximum = 255;
            this.trackBar_Smax.Name = "trackBar_Smax";
            this.trackBar_Smax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_Smax.Size = new System.Drawing.Size(183, 56);
            this.trackBar_Smax.TabIndex = 18;
            this.trackBar_Smax.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Smax.Scroll += new System.EventHandler(this.TrackBarSmaxScroll);
            // 
            // label_Smin
            // 
            this.label_Smin.AutoSize = true;
            this.label_Smin.Location = new System.Drawing.Point(8, 21);
            this.label_Smin.Name = "label_Smin";
            this.label_Smin.Size = new System.Drawing.Size(28, 15);
            this.label_Smin.TabIndex = 20;
            this.label_Smin.Text = "Min";
            // 
            // label_Smax
            // 
            this.label_Smax.AutoSize = true;
            this.label_Smax.Location = new System.Drawing.Point(8, 48);
            this.label_Smax.Name = "label_Smax";
            this.label_Smax.Size = new System.Drawing.Size(31, 15);
            this.label_Smax.TabIndex = 21;
            this.label_Smax.Text = "Max";
            // 
            // trackBar_Smin
            // 
            this.trackBar_Smin.Location = new System.Drawing.Point(34, 19);
            this.trackBar_Smin.Maximum = 255;
            this.trackBar_Smin.Name = "trackBar_Smin";
            this.trackBar_Smin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_Smin.Size = new System.Drawing.Size(183, 56);
            this.trackBar_Smin.TabIndex = 16;
            this.trackBar_Smin.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Smin.Scroll += new System.EventHandler(this.TrackBarSminScroll);
            // 
            // numericUpDown_Smin
            // 
            this.numericUpDown_Smin.Location = new System.Drawing.Point(223, 19);
            this.numericUpDown_Smin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_Smin.Name = "numericUpDown_Smin";
            this.numericUpDown_Smin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_Smin.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Smin.TabIndex = 17;
            this.numericUpDown_Smin.ValueChanged += new System.EventHandler(this.NumericUpDownSminValueChanged);
            // 
            // numericUpDown_Smax
            // 
            this.numericUpDown_Smax.Location = new System.Drawing.Point(223, 46);
            this.numericUpDown_Smax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_Smax.Name = "numericUpDown_Smax";
            this.numericUpDown_Smax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_Smax.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Smax.TabIndex = 19;
            this.numericUpDown_Smax.ValueChanged += new System.EventHandler(this.NumericUpDownSmaxValueChanged);
            // 
            // groupBox_H
            // 
            this.groupBox_H.Controls.Add(this.trackBar_Hmax);
            this.groupBox_H.Controls.Add(this.label_Hmin);
            this.groupBox_H.Controls.Add(this.label_Hmax);
            this.groupBox_H.Controls.Add(this.trackBar_Hmin);
            this.groupBox_H.Controls.Add(this.numericUpDown_Hmin);
            this.groupBox_H.Controls.Add(this.numericUpDown_Hmax);
            this.groupBox_H.Location = new System.Drawing.Point(398, 80);
            this.groupBox_H.Name = "groupBox_H";
            this.groupBox_H.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_H.Size = new System.Drawing.Size(290, 78);
            this.groupBox_H.TabIndex = 22;
            this.groupBox_H.TabStop = false;
            this.groupBox_H.Text = "H";
            // 
            // trackBar_Hmax
            // 
            this.trackBar_Hmax.Location = new System.Drawing.Point(34, 46);
            this.trackBar_Hmax.Maximum = 180;
            this.trackBar_Hmax.Name = "trackBar_Hmax";
            this.trackBar_Hmax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_Hmax.Size = new System.Drawing.Size(183, 56);
            this.trackBar_Hmax.TabIndex = 18;
            this.trackBar_Hmax.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Hmax.Scroll += new System.EventHandler(this.TrackBarHmaxScroll);
            // 
            // label_Hmin
            // 
            this.label_Hmin.AutoSize = true;
            this.label_Hmin.Location = new System.Drawing.Point(8, 23);
            this.label_Hmin.Name = "label_Hmin";
            this.label_Hmin.Size = new System.Drawing.Size(28, 15);
            this.label_Hmin.TabIndex = 20;
            this.label_Hmin.Text = "Min";
            // 
            // label_Hmax
            // 
            this.label_Hmax.AutoSize = true;
            this.label_Hmax.Location = new System.Drawing.Point(8, 48);
            this.label_Hmax.Name = "label_Hmax";
            this.label_Hmax.Size = new System.Drawing.Size(31, 15);
            this.label_Hmax.TabIndex = 21;
            this.label_Hmax.Text = "Max";
            // 
            // trackBar_Hmin
            // 
            this.trackBar_Hmin.Location = new System.Drawing.Point(34, 21);
            this.trackBar_Hmin.Maximum = 180;
            this.trackBar_Hmin.Name = "trackBar_Hmin";
            this.trackBar_Hmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_Hmin.Size = new System.Drawing.Size(183, 56);
            this.trackBar_Hmin.TabIndex = 16;
            this.trackBar_Hmin.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Hmin.Scroll += new System.EventHandler(this.TrackBarHminScroll);
            // 
            // numericUpDown_Hmin
            // 
            this.numericUpDown_Hmin.Location = new System.Drawing.Point(223, 21);
            this.numericUpDown_Hmin.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_Hmin.Name = "numericUpDown_Hmin";
            this.numericUpDown_Hmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_Hmin.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Hmin.TabIndex = 17;
            this.numericUpDown_Hmin.ValueChanged += new System.EventHandler(this.NumericUpDownHminValueChanged);
            // 
            // numericUpDown_Hmax
            // 
            this.numericUpDown_Hmax.Location = new System.Drawing.Point(223, 46);
            this.numericUpDown_Hmax.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_Hmax.Name = "numericUpDown_Hmax";
            this.numericUpDown_Hmax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_Hmax.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown_Hmax.TabIndex = 19;
            this.numericUpDown_Hmax.ValueChanged += new System.EventHandler(this.NumericUpDownHmaxValueChanged);
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(33, 28);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(60, 23);
            this.button_Load.TabIndex = 6;
            this.button_Load.Text = "Load";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.ButtonLoadClick);
            // 
            // button_SaveAs
            // 
            this.button_SaveAs.Location = new System.Drawing.Point(98, 52);
            this.button_SaveAs.Name = "button_SaveAs";
            this.button_SaveAs.Size = new System.Drawing.Size(60, 23);
            this.button_SaveAs.TabIndex = 4;
            this.button_SaveAs.Text = "Save as";
            this.button_SaveAs.UseVisualStyleBackColor = true;
            this.button_SaveAs.Click += new System.EventHandler(this.ButtonSaveAsClick);
            // 
            // button_SaveColorSpace
            // 
            this.button_SaveColorSpace.Location = new System.Drawing.Point(33, 52);
            this.button_SaveColorSpace.Name = "button_SaveColorSpace";
            this.button_SaveColorSpace.Size = new System.Drawing.Size(60, 23);
            this.button_SaveColorSpace.TabIndex = 3;
            this.button_SaveColorSpace.Text = "Save";
            this.button_SaveColorSpace.UseVisualStyleBackColor = true;
            this.button_SaveColorSpace.Click += new System.EventHandler(this.ButtonSaveColorSpaceClick);
            // 
            // imageBox_OtuputFrame
            // 
            this.imageBox_OtuputFrame.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.imageBox_OtuputFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox_OtuputFrame.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_OtuputFrame.Location = new System.Drawing.Point(6, 30);
            this.imageBox_OtuputFrame.Name = "imageBox_OtuputFrame";
            this.imageBox_OtuputFrame.Size = new System.Drawing.Size(321, 241);
            this.imageBox_OtuputFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox_OtuputFrame.TabIndex = 2;
            this.imageBox_OtuputFrame.TabStop = false;
            this.imageBox_OtuputFrame.Click += new System.EventHandler(this.imageBox_OtuputFrame_Click);
            this.imageBox_OtuputFrame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageBoxPreviewMouseDown);
            // 
            // groupBox_SelectMode
            // 
            this.groupBox_SelectMode.Controls.Add(this.label13);
            this.groupBox_SelectMode.Controls.Add(this.numericUpDown_FieldDilate);
            this.groupBox_SelectMode.Controls.Add(this.numericUpDown_FieldErode);
            this.groupBox_SelectMode.Controls.Add(this.numericUpDown_GoalDilate);
            this.groupBox_SelectMode.Controls.Add(this.numericUpDown_GoalErode);
            this.groupBox_SelectMode.Controls.Add(this.radioButton_GrabedReal);
            this.groupBox_SelectMode.Controls.Add(this.label12);
            this.groupBox_SelectMode.Controls.Add(this.label11);
            this.groupBox_SelectMode.Controls.Add(this.radioButton_Value);
            this.groupBox_SelectMode.Controls.Add(this.radioButton_Saturation);
            this.groupBox_SelectMode.Controls.Add(this.radioButton_Hue);
            this.groupBox_SelectMode.Controls.Add(this.numericUpDown_BallDilate);
            this.groupBox_SelectMode.Controls.Add(this.numericUpDown_BallErode);
            this.groupBox_SelectMode.Controls.Add(this.radioButton_GrabedMask);
            this.groupBox_SelectMode.Controls.Add(this.radioButton_GrabedBlackRed);
            this.groupBox_SelectMode.Location = new System.Drawing.Point(332, 84);
            this.groupBox_SelectMode.Name = "groupBox_SelectMode";
            this.groupBox_SelectMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_SelectMode.Size = new System.Drawing.Size(154, 182);
            this.groupBox_SelectMode.TabIndex = 19;
            this.groupBox_SelectMode.TabStop = false;
            this.groupBox_SelectMode.Text = "Process Mode";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 15);
            this.label13.TabIndex = 26;
            this.label13.Text = "Field";
            // 
            // numericUpDown_FieldDilate
            // 
            this.numericUpDown_FieldDilate.Location = new System.Drawing.Point(103, 70);
            this.numericUpDown_FieldDilate.Name = "numericUpDown_FieldDilate";
            this.numericUpDown_FieldDilate.ReadOnly = true;
            this.numericUpDown_FieldDilate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_FieldDilate.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown_FieldDilate.TabIndex = 25;
            this.numericUpDown_FieldDilate.ValueChanged += new System.EventHandler(this.numericUpDown_FieldDilate_ValueChanged);
            // 
            // numericUpDown_FieldErode
            // 
            this.numericUpDown_FieldErode.Location = new System.Drawing.Point(45, 70);
            this.numericUpDown_FieldErode.Name = "numericUpDown_FieldErode";
            this.numericUpDown_FieldErode.ReadOnly = true;
            this.numericUpDown_FieldErode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_FieldErode.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown_FieldErode.TabIndex = 24;
            this.numericUpDown_FieldErode.ValueChanged += new System.EventHandler(this.numericUpDown_FieldErode_ValueChanged);
            // 
            // numericUpDown_GoalDilate
            // 
            this.numericUpDown_GoalDilate.Location = new System.Drawing.Point(103, 47);
            this.numericUpDown_GoalDilate.Name = "numericUpDown_GoalDilate";
            this.numericUpDown_GoalDilate.ReadOnly = true;
            this.numericUpDown_GoalDilate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_GoalDilate.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown_GoalDilate.TabIndex = 23;
            this.numericUpDown_GoalDilate.ValueChanged += new System.EventHandler(this.numericUpDown_GoalDilate_ValueChanged);
            // 
            // numericUpDown_GoalErode
            // 
            this.numericUpDown_GoalErode.Location = new System.Drawing.Point(45, 47);
            this.numericUpDown_GoalErode.Name = "numericUpDown_GoalErode";
            this.numericUpDown_GoalErode.ReadOnly = true;
            this.numericUpDown_GoalErode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_GoalErode.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown_GoalErode.TabIndex = 22;
            this.numericUpDown_GoalErode.ValueChanged += new System.EventHandler(this.numericUpDown_GoalErode_ValueChanged);
            // 
            // radioButton_GrabedReal
            // 
            this.radioButton_GrabedReal.AutoSize = true;
            this.radioButton_GrabedReal.Location = new System.Drawing.Point(77, 102);
            this.radioButton_GrabedReal.Name = "radioButton_GrabedReal";
            this.radioButton_GrabedReal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton_GrabedReal.Size = new System.Drawing.Size(69, 19);
            this.radioButton_GrabedReal.TabIndex = 9;
            this.radioButton_GrabedReal.Text = "Grabed";
            this.radioButton_GrabedReal.UseVisualStyleBackColor = true;
            this.radioButton_GrabedReal.CheckedChanged += new System.EventHandler(this.RadioButtonGrabedRealCheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "Ball";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "Goal";
            // 
            // radioButton_Value
            // 
            this.radioButton_Value.AutoSize = true;
            this.radioButton_Value.Location = new System.Drawing.Point(105, 152);
            this.radioButton_Value.Name = "radioButton_Value";
            this.radioButton_Value.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton_Value.Size = new System.Drawing.Size(35, 19);
            this.radioButton_Value.TabIndex = 19;
            this.radioButton_Value.TabStop = true;
            this.radioButton_Value.Text = "V";
            this.radioButton_Value.UseVisualStyleBackColor = true;
            this.radioButton_Value.CheckedChanged += new System.EventHandler(this.RadioButtonValueCheckedChanged);
            // 
            // radioButton_Saturation
            // 
            this.radioButton_Saturation.AutoSize = true;
            this.radioButton_Saturation.Location = new System.Drawing.Point(60, 152);
            this.radioButton_Saturation.Name = "radioButton_Saturation";
            this.radioButton_Saturation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton_Saturation.Size = new System.Drawing.Size(36, 19);
            this.radioButton_Saturation.TabIndex = 18;
            this.radioButton_Saturation.TabStop = true;
            this.radioButton_Saturation.Text = "S";
            this.radioButton_Saturation.UseVisualStyleBackColor = true;
            this.radioButton_Saturation.CheckedChanged += new System.EventHandler(this.RadioButtonSaturationCheckedChanged);
            // 
            // radioButton_Hue
            // 
            this.radioButton_Hue.AutoSize = true;
            this.radioButton_Hue.Location = new System.Drawing.Point(17, 152);
            this.radioButton_Hue.Name = "radioButton_Hue";
            this.radioButton_Hue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton_Hue.Size = new System.Drawing.Size(37, 19);
            this.radioButton_Hue.TabIndex = 17;
            this.radioButton_Hue.TabStop = true;
            this.radioButton_Hue.Text = "H";
            this.radioButton_Hue.UseVisualStyleBackColor = true;
            this.radioButton_Hue.CheckedChanged += new System.EventHandler(this.RadioButtonHueCheckedChanged);
            // 
            // numericUpDown_BallDilate
            // 
            this.numericUpDown_BallDilate.Location = new System.Drawing.Point(103, 24);
            this.numericUpDown_BallDilate.Name = "numericUpDown_BallDilate";
            this.numericUpDown_BallDilate.ReadOnly = true;
            this.numericUpDown_BallDilate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_BallDilate.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown_BallDilate.TabIndex = 16;
            this.numericUpDown_BallDilate.ValueChanged += new System.EventHandler(this.NumericUpDownDilateValueChanged);
            // 
            // numericUpDown_BallErode
            // 
            this.numericUpDown_BallErode.Location = new System.Drawing.Point(45, 24);
            this.numericUpDown_BallErode.Name = "numericUpDown_BallErode";
            this.numericUpDown_BallErode.ReadOnly = true;
            this.numericUpDown_BallErode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_BallErode.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown_BallErode.TabIndex = 15;
            this.numericUpDown_BallErode.ValueChanged += new System.EventHandler(this.NumericUpDownErodeValueChanged);
            // 
            // radioButton_GrabedMask
            // 
            this.radioButton_GrabedMask.AutoSize = true;
            this.radioButton_GrabedMask.Checked = true;
            this.radioButton_GrabedMask.Location = new System.Drawing.Point(16, 102);
            this.radioButton_GrabedMask.Name = "radioButton_GrabedMask";
            this.radioButton_GrabedMask.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton_GrabedMask.Size = new System.Drawing.Size(72, 19);
            this.radioButton_GrabedMask.TabIndex = 12;
            this.radioButton_GrabedMask.TabStop = true;
            this.radioButton_GrabedMask.Text = "Masked";
            this.radioButton_GrabedMask.UseVisualStyleBackColor = true;
            this.radioButton_GrabedMask.CheckedChanged += new System.EventHandler(this.RadioButtonGrabedMaskCheckedChanged);
            // 
            // radioButton_GrabedBlackRed
            // 
            this.radioButton_GrabedBlackRed.AutoSize = true;
            this.radioButton_GrabedBlackRed.Location = new System.Drawing.Point(17, 125);
            this.radioButton_GrabedBlackRed.Name = "radioButton_GrabedBlackRed";
            this.radioButton_GrabedBlackRed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton_GrabedBlackRed.Size = new System.Drawing.Size(125, 19);
            this.radioButton_GrabedBlackRed.TabIndex = 11;
            this.radioButton_GrabedBlackRed.Text = "Grabed RedBlack";
            this.radioButton_GrabedBlackRed.UseVisualStyleBackColor = true;
            this.radioButton_GrabedBlackRed.CheckedChanged += new System.EventHandler(this.RadioButtonGrabedBlackWhiteCheckedChanged);
            // 
            // radioButton_Real
            // 
            this.radioButton_Real.AutoSize = true;
            this.radioButton_Real.Checked = true;
            this.radioButton_Real.Location = new System.Drawing.Point(116, 13);
            this.radioButton_Real.Name = "radioButton_Real";
            this.radioButton_Real.Size = new System.Drawing.Size(54, 19);
            this.radioButton_Real.TabIndex = 4;
            this.radioButton_Real.TabStop = true;
            this.radioButton_Real.Text = "Real";
            this.radioButton_Real.UseVisualStyleBackColor = true;
            this.radioButton_Real.CheckedChanged += new System.EventHandler(this.RadioButtonRealCheckedChanged);
            // 
            // button_CaptureStartPause
            // 
            this.button_CaptureStartPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CaptureStartPause.Location = new System.Drawing.Point(6, 18);
            this.button_CaptureStartPause.Name = "button_CaptureStartPause";
            this.button_CaptureStartPause.Size = new System.Drawing.Size(96, 41);
            this.button_CaptureStartPause.TabIndex = 6;
            this.button_CaptureStartPause.Text = "Start";
            this.button_CaptureStartPause.UseVisualStyleBackColor = true;
            this.button_CaptureStartPause.Click += new System.EventHandler(this.ButtonCaptureStartPauseClick);
            // 
            // button_LoadColors
            // 
            this.button_LoadColors.Location = new System.Drawing.Point(108, 36);
            this.button_LoadColors.Name = "button_LoadColors";
            this.button_LoadColors.Size = new System.Drawing.Size(171, 23);
            this.button_LoadColors.TabIndex = 10;
            this.button_LoadColors.Text = "Reload Colors";
            this.button_LoadColors.UseVisualStyleBackColor = true;
            this.button_LoadColors.Click += new System.EventHandler(this.ButtonLoadColorsClick);
            // 
            // trackBarImgProcPan
            // 
            this.trackBarImgProcPan.Location = new System.Drawing.Point(6, 277);
            this.trackBarImgProcPan.Maximum = 1023;
            this.trackBarImgProcPan.Name = "trackBarImgProcPan";
            this.trackBarImgProcPan.Size = new System.Drawing.Size(329, 56);
            this.trackBarImgProcPan.TabIndex = 39;
            this.trackBarImgProcPan.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarImgProcPan.Value = 512;
            this.trackBarImgProcPan.Scroll += new System.EventHandler(this.TrackBarImgProcPanScroll);
            // 
            // trackBarImgProcTilt
            // 
            this.trackBarImgProcTilt.Location = new System.Drawing.Point(333, 22);
            this.trackBarImgProcTilt.Maximum = 1023;
            this.trackBarImgProcTilt.Name = "trackBarImgProcTilt";
            this.trackBarImgProcTilt.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarImgProcTilt.Size = new System.Drawing.Size(56, 269);
            this.trackBarImgProcTilt.TabIndex = 40;
            this.trackBarImgProcTilt.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarImgProcTilt.Value = 512;
            this.trackBarImgProcTilt.Scroll += new System.EventHandler(this.TrackBarImgProcTiltScroll);
            // 
            // groupBox_OutputFream
            // 
            this.groupBox_OutputFream.Controls.Add(this.checkBox1);
            this.groupBox_OutputFream.Controls.Add(this.imageBox_OtuputFrame);
            this.groupBox_OutputFream.Controls.Add(this.trackBarImgProcTilt);
            this.groupBox_OutputFream.Controls.Add(this.trackBarImgProcPan);
            this.groupBox_OutputFream.Location = new System.Drawing.Point(12, 13);
            this.groupBox_OutputFream.Name = "groupBox_OutputFream";
            this.groupBox_OutputFream.Size = new System.Drawing.Size(380, 344);
            this.groupBox_OutputFream.TabIndex = 45;
            this.groupBox_OutputFream.TabStop = false;
            this.groupBox_OutputFream.Text = "OutputFream";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(246, 297);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 19);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox_ProcessedMode
            // 
            this.groupBox_ProcessedMode.Controls.Add(this.groupBox1);
            this.groupBox_ProcessedMode.Controls.Add(this.groupBox_RealTimeFpS);
            this.groupBox_ProcessedMode.Controls.Add(this.groupBox_ColorSpace);
            this.groupBox_ProcessedMode.Controls.Add(this.imageBox_ProcessedFrame);
            this.groupBox_ProcessedMode.Controls.Add(this.groupBox_SelectMode);
            this.groupBox_ProcessedMode.Location = new System.Drawing.Point(12, 324);
            this.groupBox_ProcessedMode.Name = "groupBox_ProcessedMode";
            this.groupBox_ProcessedMode.Size = new System.Drawing.Size(676, 272);
            this.groupBox_ProcessedMode.TabIndex = 46;
            this.groupBox_ProcessedMode.TabStop = false;
            this.groupBox_ProcessedMode.Text = "ProcessedMode";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDownOnField);
            this.groupBox1.Location = new System.Drawing.Point(490, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 64);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "On Field Filter";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "MinCountNoneZero";
            // 
            // numericUpDownOnField
            // 
            this.numericUpDownOnField.Location = new System.Drawing.Point(119, 29);
            this.numericUpDownOnField.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDownOnField.Name = "numericUpDownOnField";
            this.numericUpDownOnField.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownOnField.TabIndex = 15;
            this.numericUpDownOnField.ValueChanged += new System.EventHandler(this.numericUpDownOnField_ValueChanged);
            // 
            // groupBox_RealTimeFpS
            // 
            this.groupBox_RealTimeFpS.Controls.Add(this.button_FpsStart);
            this.groupBox_RealTimeFpS.Controls.Add(this.Lable_RealTimeFPS);
            this.groupBox_RealTimeFpS.Location = new System.Drawing.Point(333, 14);
            this.groupBox_RealTimeFpS.Name = "groupBox_RealTimeFpS";
            this.groupBox_RealTimeFpS.Size = new System.Drawing.Size(153, 64);
            this.groupBox_RealTimeFpS.TabIndex = 28;
            this.groupBox_RealTimeFpS.TabStop = false;
            this.groupBox_RealTimeFpS.Text = "RealTime FPS";
            // 
            // button_FpsStart
            // 
            this.button_FpsStart.Location = new System.Drawing.Point(48, 26);
            this.button_FpsStart.Name = "button_FpsStart";
            this.button_FpsStart.Size = new System.Drawing.Size(75, 23);
            this.button_FpsStart.TabIndex = 1;
            this.button_FpsStart.Text = "Start";
            this.button_FpsStart.UseVisualStyleBackColor = true;
            this.button_FpsStart.Click += new System.EventHandler(this.ButtonFpsStartClick);
            // 
            // Lable_RealTimeFPS
            // 
            this.Lable_RealTimeFPS.AutoSize = true;
            this.Lable_RealTimeFPS.Location = new System.Drawing.Point(13, 33);
            this.Lable_RealTimeFPS.Name = "Lable_RealTimeFPS";
            this.Lable_RealTimeFPS.Size = new System.Drawing.Size(21, 15);
            this.Lable_RealTimeFPS.TabIndex = 0;
            this.Lable_RealTimeFPS.Text = "00";
            // 
            // groupBox_ColorSpace
            // 
            this.groupBox_ColorSpace.Controls.Add(this.label_GrabedHSV_Value);
            this.groupBox_ColorSpace.Controls.Add(this.label_HSVGrabed);
            this.groupBox_ColorSpace.Controls.Add(this.button_Add);
            this.groupBox_ColorSpace.Controls.Add(this.button_Reload);
            this.groupBox_ColorSpace.Controls.Add(this.button_Load);
            this.groupBox_ColorSpace.Controls.Add(this.label_HSVMinValue);
            this.groupBox_ColorSpace.Controls.Add(this.label_HSVMaxValue);
            this.groupBox_ColorSpace.Controls.Add(this.button_SaveAs);
            this.groupBox_ColorSpace.Controls.Add(this.label_HSVmax);
            this.groupBox_ColorSpace.Controls.Add(this.button_SaveColorSpace);
            this.groupBox_ColorSpace.Controls.Add(this.label_HSVmin);
            this.groupBox_ColorSpace.Location = new System.Drawing.Point(488, 84);
            this.groupBox_ColorSpace.Name = "groupBox_ColorSpace";
            this.groupBox_ColorSpace.Size = new System.Drawing.Size(182, 182);
            this.groupBox_ColorSpace.TabIndex = 21;
            this.groupBox_ColorSpace.TabStop = false;
            this.groupBox_ColorSpace.Text = "ColorSpace";
            // 
            // label_GrabedHSV_Value
            // 
            this.label_GrabedHSV_Value.AutoSize = true;
            this.label_GrabedHSV_Value.Location = new System.Drawing.Point(49, 160);
            this.label_GrabedHSV_Value.Name = "label_GrabedHSV_Value";
            this.label_GrabedHSV_Value.Size = new System.Drawing.Size(39, 15);
            this.label_GrabedHSV_Value.TabIndex = 18;
            this.label_GrabedHSV_Value.Text = "--------";
            // 
            // label_HSVGrabed
            // 
            this.label_HSVGrabed.AutoSize = true;
            this.label_HSVGrabed.Location = new System.Drawing.Point(6, 160);
            this.label_HSVGrabed.Name = "label_HSVGrabed";
            this.label_HSVGrabed.Size = new System.Drawing.Size(51, 15);
            this.label_HSVGrabed.TabIndex = 17;
            this.label_HSVGrabed.Text = "Grabed:";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(31, 78);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(126, 23);
            this.button_Add.TabIndex = 16;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // button_Reload
            // 
            this.button_Reload.Location = new System.Drawing.Point(98, 28);
            this.button_Reload.Name = "button_Reload";
            this.button_Reload.Size = new System.Drawing.Size(60, 23);
            this.button_Reload.TabIndex = 15;
            this.button_Reload.Text = "Reload";
            this.button_Reload.UseVisualStyleBackColor = true;
            this.button_Reload.Click += new System.EventHandler(this.ButtonReloadClick);
            // 
            // label_HSVMinValue
            // 
            this.label_HSVMinValue.AutoSize = true;
            this.label_HSVMinValue.Location = new System.Drawing.Point(83, 116);
            this.label_HSVMinValue.Name = "label_HSVMinValue";
            this.label_HSVMinValue.Size = new System.Drawing.Size(39, 15);
            this.label_HSVMinValue.TabIndex = 14;
            this.label_HSVMinValue.Text = "--------";
            // 
            // label_HSVMaxValue
            // 
            this.label_HSVMaxValue.AutoSize = true;
            this.label_HSVMaxValue.Location = new System.Drawing.Point(83, 135);
            this.label_HSVMaxValue.Name = "label_HSVMaxValue";
            this.label_HSVMaxValue.Size = new System.Drawing.Size(39, 15);
            this.label_HSVMaxValue.TabIndex = 13;
            this.label_HSVMaxValue.Text = "--------";
            // 
            // label_HSVmax
            // 
            this.label_HSVmax.AutoSize = true;
            this.label_HSVmax.Location = new System.Drawing.Point(18, 135);
            this.label_HSVmax.Name = "label_HSVmax";
            this.label_HSVmax.Size = new System.Drawing.Size(34, 15);
            this.label_HSVmax.TabIndex = 12;
            this.label_HSVmax.Text = "Max:";
            // 
            // label_HSVmin
            // 
            this.label_HSVmin.AutoSize = true;
            this.label_HSVmin.Location = new System.Drawing.Point(18, 116);
            this.label_HSVmin.Name = "label_HSVmin";
            this.label_HSVmin.Size = new System.Drawing.Size(31, 15);
            this.label_HSVmin.TabIndex = 11;
            this.label_HSVmin.Text = "Min:";
            // 
            // imageBox_ProcessedFrame
            // 
            this.imageBox_ProcessedFrame.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.imageBox_ProcessedFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox_ProcessedFrame.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_ProcessedFrame.Location = new System.Drawing.Point(6, 20);
            this.imageBox_ProcessedFrame.Name = "imageBox_ProcessedFrame";
            this.imageBox_ProcessedFrame.Size = new System.Drawing.Size(321, 241);
            this.imageBox_ProcessedFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox_ProcessedFrame.TabIndex = 3;
            this.imageBox_ProcessedFrame.TabStop = false;
            // 
            // groupBox_HeadControlling
            // 
            this.groupBox_HeadControlling.Controls.Add(this.label21);
            this.groupBox_HeadControlling.Controls.Add(this.label20);
            this.groupBox_HeadControlling.Controls.Add(this.numericUpDown2);
            this.groupBox_HeadControlling.Controls.Add(this.numericUpDown1);
            this.groupBox_HeadControlling.Controls.Add(this.groupBox_Track);
            this.groupBox_HeadControlling.Controls.Add(this.groupBox_Pan);
            this.groupBox_HeadControlling.Controls.Add(this.groupBox_Search);
            this.groupBox_HeadControlling.Controls.Add(this.groupBox_Tilt);
            this.groupBox_HeadControlling.Location = new System.Drawing.Point(694, 13);
            this.groupBox_HeadControlling.Name = "groupBox_HeadControlling";
            this.groupBox_HeadControlling.Size = new System.Drawing.Size(299, 439);
            this.groupBox_HeadControlling.TabIndex = 47;
            this.groupBox_HeadControlling.TabStop = false;
            this.groupBox_HeadControlling.Text = "HeadControling";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(164, 412);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 15);
            this.label21.TabIndex = 34;
            this.label21.Text = "Thersh max";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 412);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 15);
            this.label20.TabIndex = 33;
            this.label20.Text = "Thersh min";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(233, 410);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown2.TabIndex = 29;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged_1);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(88, 410);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 28;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton_ContourBall);
            this.groupBox5.Controls.Add(this.radioButton_ContourGoal);
            this.groupBox5.Controls.Add(this.button_CaptureStartPause);
            this.groupBox5.Controls.Add(this.button_LoadColors);
            this.groupBox5.Controls.Add(this.radioButton_Real);
            this.groupBox5.Location = new System.Drawing.Point(398, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(290, 66);
            this.groupBox5.TabIndex = 48;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Processed Objects";
            // 
            // radioButton_ContourBall
            // 
            this.radioButton_ContourBall.AutoSize = true;
            this.radioButton_ContourBall.Location = new System.Drawing.Point(174, 13);
            this.radioButton_ContourBall.Name = "radioButton_ContourBall";
            this.radioButton_ContourBall.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton_ContourBall.Size = new System.Drawing.Size(49, 19);
            this.radioButton_ContourBall.TabIndex = 11;
            this.radioButton_ContourBall.Text = "Ball";
            this.radioButton_ContourBall.UseVisualStyleBackColor = true;
            this.radioButton_ContourBall.CheckedChanged += new System.EventHandler(this.RadioButtonContourBallCheckedChanged);
            // 
            // radioButton_ContourGoal
            // 
            this.radioButton_ContourGoal.AutoSize = true;
            this.radioButton_ContourGoal.Location = new System.Drawing.Point(232, 13);
            this.radioButton_ContourGoal.Name = "radioButton_ContourGoal";
            this.radioButton_ContourGoal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton_ContourGoal.Size = new System.Drawing.Size(54, 19);
            this.radioButton_ContourGoal.TabIndex = 12;
            this.radioButton_ContourGoal.Text = "Goal";
            this.radioButton_ContourGoal.UseVisualStyleBackColor = true;
            this.radioButton_ContourGoal.CheckedChanged += new System.EventHandler(this.RadioButtonContourGoalCheckedChanged);
            // 
            // Timer_FPS
            // 
            this.Timer_FPS.Tick += new System.EventHandler(this.TimerFpsTick);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 15);
            this.label22.TabIndex = 51;
            this.label22.Text = "thershMax";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(85, 51);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown3.TabIndex = 50;
            this.numericUpDown3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 15);
            this.label23.TabIndex = 53;
            this.label23.Text = "thershMin";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(84, 77);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown4.TabIndex = 52;
            this.numericUpDown4.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(10, 106);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(33, 15);
            this.label24.TabIndex = 55;
            this.label24.Text = "Acco";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(84, 103);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown5.TabIndex = 54;
            this.numericUpDown5.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.numericUpDown6);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numericUpDown3);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.numericUpDown5);
            this.groupBox3.Controls.Add(this.numericUpDown4);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Location = new System.Drawing.Point(694, 460);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 136);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ball Detection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 15);
            this.label3.TabIndex = 59;
            this.label3.Text = "SwitchBetweenAlghoritms";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(234, 51);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown6.TabIndex = 57;
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 58;
            this.label2.Text = "Tilt_Angle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 56;
            this.label1.Text = "Circle Detection";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 60;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // histogramBox1
            // 
            this.histogramBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.histogramBox1.Location = new System.Drawing.Point(1012, 103);
            this.histogramBox1.Name = "histogramBox1";
            this.histogramBox1.Size = new System.Drawing.Size(352, 230);
            this.histogramBox1.TabIndex = 57;
            // 
            // VisionLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 611);
            this.Controls.Add(this.histogramBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox_HeadControlling);
            this.Controls.Add(this.groupBox_V);
            this.Controls.Add(this.groupBox_ProcessedMode);
            this.Controls.Add(this.groupBox_S);
            this.Controls.Add(this.groupBox_OutputFream);
            this.Controls.Add(this.groupBox_H);
            this.Controls.Add(this.groupBox5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VisionLab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vision Lab (ParandRoboticResearchCenter)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.groupBox_Search.ResumeLayout(false);
            this.groupBox_Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MovingUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DownTilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MiddleTilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_upTilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SearchInterval)).EndInit();
            this.groupBox_Track.ResumeLayout(false);
            this.groupBox_Track.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TiltPosCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PanPosCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TiltSpeedCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PanSpeedCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_VAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SquareSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TrackInterval)).EndInit();
            this.groupBox_Tilt.ResumeLayout(false);
            this.groupBox_Tilt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TiltSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tilt)).EndInit();
            this.groupBox_Pan.ResumeLayout(false);
            this.groupBox_Pan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PanSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Pan)).EndInit();
            this.groupBox_V.ResumeLayout(false);
            this.groupBox_V.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Vmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Vmax)).EndInit();
            this.groupBox_S.ResumeLayout(false);
            this.groupBox_S.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Smax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Smin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Smin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Smax)).EndInit();
            this.groupBox_H.ResumeLayout(false);
            this.groupBox_H.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Hmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Hmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Hmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_OtuputFrame)).EndInit();
            this.groupBox_SelectMode.ResumeLayout(false);
            this.groupBox_SelectMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FieldDilate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FieldErode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GoalDilate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GoalErode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BallDilate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_BallErode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImgProcPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarImgProcTilt)).EndInit();
            this.groupBox_OutputFream.ResumeLayout(false);
            this.groupBox_OutputFream.PerformLayout();
            this.groupBox_ProcessedMode.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOnField)).EndInit();
            this.groupBox_RealTimeFpS.ResumeLayout(false);
            this.groupBox_RealTimeFpS.PerformLayout();
            this.groupBox_ColorSpace.ResumeLayout(false);
            this.groupBox_ColorSpace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_ProcessedFrame)).EndInit();
            this.groupBox_HeadControlling.ResumeLayout(false);
            this.groupBox_HeadControlling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_Load;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_SaveAs;
        private System.Windows.Forms.Label label_TrackInterval;
        private System.Windows.Forms.NumericUpDown numericUpDown_TrackInterval;
        private System.Windows.Forms.GroupBox groupBox_Track;
        private System.Windows.Forms.ComboBox comboBox_PanSlop;
        private System.Windows.Forms.Button button_Tilt512;
        private System.Windows.Forms.Button button_Pan512;
        private System.Windows.Forms.CheckBox checkBox_EnableMouseTracker;
        private System.Windows.Forms.Label label_TiltGoalPosition;
        private System.Windows.Forms.Label label_PanGoalPosition;
        private System.Windows.Forms.NumericUpDown numericUpDown_Tilt;
        private System.Windows.Forms.NumericUpDown numericUpDown_Pan;
        private System.Windows.Forms.Button button_TrackStartPause;
        private System.Windows.Forms.GroupBox groupBox_Pan;
        private System.Windows.Forms.Label label_PanSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDown_PanSpeed;
        private System.Windows.Forms.Label label_PanSlop;
        private System.Windows.Forms.GroupBox groupBox_Tilt;
        private System.Windows.Forms.Label label_TiltSlop;
        private System.Windows.Forms.Label label_TiltSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDown_TiltSpeed;
        private System.Windows.Forms.ComboBox comboBox_TiltSlop;
        private System.Windows.Forms.Label label_SquareSide;
        private System.Windows.Forms.NumericUpDown numericUpDown_SquareSide;
        private System.Windows.Forms.GroupBox groupBox_Search;
        private System.Windows.Forms.Label Lable_SearchInterval;
        private System.Windows.Forms.NumericUpDown numericUpDown_SearchInterval;
        private System.Windows.Forms.RadioButton radioButton_GoalScan;
        private System.Windows.Forms.RadioButton radioButton_BallScan;
        public System.Windows.Forms.Button button_SearchStart;
        private System.Windows.Forms.GroupBox groupBox_V;
        private System.Windows.Forms.Label label_Vmin;
        private System.Windows.Forms.Label label_Vmax;
        private System.Windows.Forms.TrackBar trackBar_Vmin;
        private System.Windows.Forms.NumericUpDown numericUpDown_Vmin;
        private System.Windows.Forms.NumericUpDown numericUpDown_Vmax;
        private System.Windows.Forms.TrackBar trackBar_Vmax;
        private System.Windows.Forms.GroupBox groupBox_S;
        private System.Windows.Forms.Label label_Smin;
        private System.Windows.Forms.Label label_Smax;
        private System.Windows.Forms.TrackBar trackBar_Smin;
        private System.Windows.Forms.NumericUpDown numericUpDown_Smin;
        private System.Windows.Forms.NumericUpDown numericUpDown_Smax;
        private System.Windows.Forms.TrackBar trackBar_Smax;
        private System.Windows.Forms.GroupBox groupBox_H;
        private System.Windows.Forms.Label label_Hmin;
        private System.Windows.Forms.Label label_Hmax;
        private System.Windows.Forms.TrackBar trackBar_Hmin;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hmin;
        private System.Windows.Forms.NumericUpDown numericUpDown_Hmax;
        private System.Windows.Forms.TrackBar trackBar_Hmax;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Button button_SaveAs;
        private System.Windows.Forms.Button button_SaveColorSpace;
        public Emgu.CV.UI.ImageBox imageBox_OtuputFrame;
        private System.Windows.Forms.GroupBox groupBox_SelectMode;
        private System.Windows.Forms.RadioButton radioButton_GrabedBlackRed;
        private System.Windows.Forms.Button button_LoadColors;
        private System.Windows.Forms.RadioButton radioButton_GrabedReal;
        private System.Windows.Forms.Button button_CaptureStartPause;
        private System.Windows.Forms.RadioButton radioButton_Real;
        private System.Windows.Forms.TrackBar trackBarImgProcPan;
        private System.Windows.Forms.TrackBar trackBarImgProcTilt;
        private System.Windows.Forms.GroupBox groupBox_OutputFream;
        private System.Windows.Forms.GroupBox groupBox_ProcessedMode;
        public Emgu.CV.UI.ImageBox imageBox_ProcessedFrame;
        private System.Windows.Forms.GroupBox groupBox_HeadControlling;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox_ColorSpace;
        private System.Windows.Forms.Label label_HSVMinValue;
        private System.Windows.Forms.Label label_HSVMaxValue;
        private System.Windows.Forms.Label label_HSVmax;
        private System.Windows.Forms.Label label_HSVmin;
        private System.Windows.Forms.Button button_Reload;
        private System.Windows.Forms.GroupBox groupBox_RealTimeFpS;
        private System.Windows.Forms.RadioButton radioButton_GrabedMask;
        private System.Windows.Forms.NumericUpDown numericUpDown_BallErode;
        private System.Windows.Forms.NumericUpDown numericUpDown_BallDilate;
        private System.Windows.Forms.RadioButton radioButton_ContourBall;
        private System.Windows.Forms.RadioButton radioButton_ContourGoal;
        private System.Windows.Forms.RadioButton radioButton_Value;
        private System.Windows.Forms.RadioButton radioButton_Saturation;
        private System.Windows.Forms.RadioButton radioButton_Hue;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label_HSVGrabed;
        private System.Windows.Forms.Label label_GrabedHSV_Value;
        private System.Windows.Forms.Label Lable_RealTimeFPS;
        private System.Windows.Forms.Timer Timer_FPS;
        private System.Windows.Forms.Button button_FpsStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownOnField;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown_MovingUnit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxPan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_MinPan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_DownTilt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_MiddleTilt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_upTilt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDown_FieldDilate;
        private System.Windows.Forms.NumericUpDown numericUpDown_FieldErode;
        private System.Windows.Forms.NumericUpDown numericUpDown_GoalDilate;
        private System.Windows.Forms.NumericUpDown numericUpDown_GoalErode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDown_VAngle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDown_HAngle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDown_TiltSpeedCon;
        private System.Windows.Forms.NumericUpDown numericUpDown_PanSpeedCon;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numericUpDown_TiltPosCon;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDown_PanPosCon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private Emgu.CV.UI.HistogramBox histogramBox1;


    }
}

