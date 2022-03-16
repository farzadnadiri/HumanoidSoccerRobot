using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Robot.Environment.Color;
using Robot.Vision.HeadControl;
using Robot.Environment;
using Robot.Vision.ImageProcessing;
using Robot.Vision.Properties;
using Capture = Robot.Vision.ImageProcessing.Capture;

namespace Robot.Vision
{
    public partial class VisionLab : Form
    {
        private readonly ImageProcess _imageProcess;
        private readonly Capture _capture;
        private readonly Vision _vision;
        private readonly Head _head;
        private readonly Search _search;
        private readonly Tracker _tracker;
        public VisionLab(ImageProcess imageProcess, Capture capture, Vision vision, Head head, Search search, Tracker tracker)
        {
            _search = search;
            _tracker = tracker;
            _head = head;
            _imageProcess = imageProcess;
            _capture = capture;
            _vision = vision;
            imageProcess.AnalyzeFrameProcessed += OnAnalyzeFrame;
            imageProcess.OutputFrameProcessed += OnOutputFrame;
            imageProcess.GrayImageProcessed += OnGrayFrame;
            InitializeComponent();
        }

        private void OnGrayFrame(Image<Gray, byte> frame)
        {
            imageBox_ProcessedFrame.Image = frame;
        }

        private void OnOutputFrame(Image<Hsv, byte> frame)
        {
            imageBox_OtuputFrame.Image = frame;
        }

        private void OnAnalyzeFrame(Image<Hsv, byte> frame)
        {
            imageBox_ProcessedFrame.Image = frame;
        }


        private void SelectProcessedObjectPreview()
        {
            if (radioButton_Real.Checked)
            {
                _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.Real);
            }

            else if (radioButton_ContourBall.Checked)
            {
                _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);
            }
            else if (radioButton_ContourGoal.Checked)
            {
                _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourGoal);
            }
        }

        private void SelectImageProcessingPreview()
        {
            if (radioButton_GrabedReal.Checked)
            {
                _imageProcess.SelectImageProcessingFunction(ImageProcess.ImageProcessingFunctions.GrabedReal);
            }
            else if (radioButton_GrabedBlackRed.Checked)
            {
                _imageProcess.SelectImageProcessingFunction(ImageProcess.ImageProcessingFunctions.GrabedBlackRed);
            }
            else if (radioButton_GrabedMask.Checked)
            {
                _imageProcess.SelectImageProcessingFunction(ImageProcess.ImageProcessingFunctions.Masked);
            }
            else if (radioButton_Hue.Checked)
            {
                _imageProcess.SelectImageProcessingFunction(ImageProcess.ImageProcessingFunctions.Hue);
            }
            else if (radioButton_Saturation.Checked)
            {
                _imageProcess.SelectImageProcessingFunction(ImageProcess.ImageProcessingFunctions.Saturation);
            }
            else if (radioButton_Value.Checked)
            {
                _imageProcess.SelectImageProcessingFunction(ImageProcess.ImageProcessingFunctions.Value);
            }

        }


        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {

            _imageProcess.ProcessingMode = ImageProcess.Mode.Play;
            _capture.Stop();
            _tracker.Stop();

        }

        private void Changed()
        {
            _isChanged = true;
            button_SaveColorSpace.Text = Resources.VisionLab_Changed_Save__;
        }
        private void LoadColors()
        {
            label_HSVMinValue.Text = _imageProcess.GrabedColor.Min.ToString();
            label_HSVMaxValue.Text = _imageProcess.GrabedColor.Max.ToString();

        }

        private void Saved()
        {
            _isChanged = false;
            button_SaveColorSpace.Text = Resources.VisionLab_Saved_Save;
        }

        private bool _isChanged;
        private string _filename = string.Empty;


        private void SetTrackbars()
        {
            trackBar_Hmin.Value = (int)_imageProcess.GrabedColor.Min.Hue;
            trackBar_Smin.Value = (int)_imageProcess.GrabedColor.Min.Satuation;
            trackBar_Vmin.Value = (int)_imageProcess.GrabedColor.Min.Value;
            trackBar_Hmax.Value = (int)_imageProcess.GrabedColor.Max.Hue;
            trackBar_Smax.Value = (int)_imageProcess.GrabedColor.Max.Satuation;
            trackBar_Vmax.Value = (int)_imageProcess.GrabedColor.Max.Value;
        }


        private void SetNumericUpDowns()
        {

            numericUpDown_Hmin.Value = (int)_imageProcess.GrabedColor.Min.Hue;
            numericUpDown_Smin.Value = (int)_imageProcess.GrabedColor.Min.Satuation;
            numericUpDown_Vmin.Value = (int)_imageProcess.GrabedColor.Min.Value;
            numericUpDown_Hmax.Value = (int)_imageProcess.GrabedColor.Max.Hue;
            numericUpDown_Smax.Value = (int)_imageProcess.GrabedColor.Max.Satuation;
            numericUpDown_Vmax.Value = (int)_imageProcess.GrabedColor.Max.Value;
        }

        private void OpenFileDialogLoadFileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog_Load.FileName != string.Empty)
            {
                _filename = openFileDialog_Load.FileName;
            }
        }

        private void SaveFileDialogSaveAsFileOk(object sender, CancelEventArgs e)
        {
            _imageProcess.GrabedColorSpace.Save(saveFileDialog_SaveAs.FileName);
        }


        private bool _isMouseTrackEnable;


        private void MainFormLoad(object sender, EventArgs e)
        {

            InitControls();
            _imageProcess.ProcessingMode = ImageProcess.Mode.Laboratory;

        }

        private void InitControls()
        {

            trackBar_Hmax.Value = 180;
            trackBar_Smax.Value = trackBar_Vmax.Value = 255;
            numericUpDown_Hmax.Value = 180;
            numericUpDown_Smax.Value = numericUpDown_Vmax.Value = 255;
            numericUpDown_BallDilate.Value = _imageProcess.BallDilateValue;
            numericUpDown_BallErode.Value = _imageProcess.BallErodeValue;
            numericUpDown_GoalDilate.Value = _imageProcess.GoalDilateValue;
            numericUpDown_GoalErode.Value = _imageProcess.GoalErodeValue;
            numericUpDown_FieldDilate.Value = _imageProcess.FieldDilateValue;
            numericUpDown_FieldErode.Value = _imageProcess.FieldErodeValue;

            numericUpDown_TrackInterval.Value = _tracker.Interval;
            numericUpDownOnField.Value = _imageProcess.MinFieldPixels;
            numericUpDown_SearchInterval.Value = _search.Interval;
            comboBox_PanSlop.SelectedIndex = 0;
            comboBox_TiltSlop.SelectedIndex = 0;
            numericUpDown_SquareSide.Value = (decimal)_tracker.SquareSide;
            numericUpDown_PanSpeed.Value = _head.Pan.Speed;
            numericUpDown_TiltSpeed.Value = _head.Tilt.Speed;
            numericUpDown_DownTilt.Value = _search.DownTilt;
            numericUpDown_MiddleTilt.Value = _search.MiddleTilt;
            numericUpDown_upTilt.Value = _search.UpTilt;
            numericUpDown_MinPan.Value = _search.PanMin;
            numericUpDown_MaxPan.Value = _search.PanMax;
            numericUpDown_MovingUnit.Value = _search.MovingUnit;
            numericUpDown_PanSpeedCon.Value = (decimal)_tracker.PanSpeedCon;
            numericUpDown_TiltSpeedCon.Value = (decimal)_tracker.TiltSpeedCon;
            numericUpDown_HAngle.Value = (decimal)_tracker.CameraHorizontalAngel;
            numericUpDown_VAngle.Value = (decimal)_tracker.CameraVerticalAngle;
            numericUpDown_TiltPosCon.Value = (decimal)_tracker.TiltPosCon;
            numericUpDown_PanPosCon.Value = (decimal)_tracker.PanPosCon;

            numericUpDown1.Value = _imageProcess.minThersh;
            numericUpDown2.Value = _imageProcess.maxThersh;
            numericUpDown6.Value = _imageProcess.SwitchBoundary;
            numericUpDown3.Value = _imageProcess.HoghMax;
            numericUpDown4.Value = _imageProcess.HoghMin;
            numericUpDown5.Value = _imageProcess.Thersh;
        }

        private void ButtonCaptureStartPauseClick(object sender, EventArgs e)
        {
            if (!_capture.Enable)
            {
                _capture.Start();
                button_CaptureStartPause.Text = Resources.VisionLab_ButtonFpsStartClick_Pause;


            }
            else
            {
                _capture.Stop();

                button_CaptureStartPause.Text = Resources.VisionLab_ButtonFpsStartClick_Start;
            }
        }

        private void RadioButtonRealCheckedChanged(object sender, EventArgs e)
        {
            SelectProcessedObjectPreview();
        }
        private void RadioButtonContourGoalCheckedChanged(object sender, EventArgs e)
        {
            SelectProcessedObjectPreview();
        }
        private void RadioButtonContourBallCheckedChanged(object sender, EventArgs e)
        {
            SelectProcessedObjectPreview();
        }


        private void RadioButtonGrabedRealCheckedChanged(object sender, EventArgs e)
        {
            SelectImageProcessingPreview();
        }
        private void RadioButtonGrabedBlackWhiteCheckedChanged(object sender, EventArgs e)
        {
            SelectImageProcessingPreview();
        }
        private void RadioButtonValueCheckedChanged(object sender, EventArgs e)
        {
            SelectImageProcessingPreview();
        }
        private void RadioButtonSaturationCheckedChanged(object sender, EventArgs e)
        {
            SelectImageProcessingPreview();
        }
        private void RadioButtonHueCheckedChanged(object sender, EventArgs e)
        {
            SelectImageProcessingPreview();
        }
        private void RadioButtonGrabedMaskCheckedChanged(object sender, EventArgs e)
        {

            SelectImageProcessingPreview();

        }
        private void ButtonTrackStartPauseClick(object sender, EventArgs e)
        {
            if (button_TrackStartPause.Text == Resources.VisionLab_ButtonFpsStartClick_Start)
            {
                _tracker.Start();

                button_TrackStartPause.Text = Resources.VisionLab_ButtonFpsStartClick_Pause;
                groupBox_Pan.Enabled = groupBox_Tilt.Enabled = false;
            }
            else if (button_TrackStartPause.Text == Resources.VisionLab_ButtonFpsStartClick_Pause)
            {
                _tracker.Stop();
                button_TrackStartPause.Text = Resources.VisionLab_ButtonFpsStartClick_Start;
                groupBox_Pan.Enabled = groupBox_Tilt.Enabled = true;
            }
        }


        private void NumericUpDownPanValueChanged(object sender, EventArgs e)
        {
            trackBarImgProcPan.Value = (int)numericUpDown_Pan.Value;
            _head.Pan.Position = trackBarImgProcPan.Value;

        }


        private void NumericUpDownTiltValueChanged(object sender, EventArgs e)
        {
            trackBarImgProcTilt.Value = (int)numericUpDown_Tilt.Value;
            _head.Tilt.Position = trackBarImgProcTilt.Value;

        }


        private void ButtonSaveColorSpaceClick(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(_filename))
            {
                if (_isChanged)
                {

                    _imageProcess.GrabedColorSpace.Save(_filename);
                }
                Saved();
            }
            else
            {
                button_SaveAs.PerformClick();
            }
        }

        private void ButtonLoadClick(object sender, EventArgs e)
        {
            openFileDialog_Load.ShowDialog();
            _imageProcess.GrabedColorSpace.Load(_filename);
            Saved();

            label_HSVMinValue.Text = _imageProcess.GrabedColorSpace.GetColor().Min.ToString();
            label_HSVMaxValue.Text = _imageProcess.GrabedColorSpace.GetColor().Max.ToString();
            label_GrabedHSV_Value.Text = label_HSVMinValue.Text + Resources.VisionLab_ButtonLoadClick__ + label_HSVMaxValue.Text;
            button_Reload.PerformClick();
        }


        private void ButtonSaveAsClick(object sender, EventArgs e)
        {
            saveFileDialog_SaveAs.ShowDialog();
            Saved();
        }

        private void TrackBarHminScroll(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Min.Hue = trackBar_Hmin.Value;
            numericUpDown_Hmin.Value = trackBar_Hmin.Value;
            LoadColors();

        }

        private void TrackBarHmaxScroll(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Max.Hue = trackBar_Hmax.Value;
            numericUpDown_Hmax.Value = trackBar_Hmax.Value;
            LoadColors();

        }

        private void TrackBarSminScroll(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Min.Satuation = trackBar_Smin.Value;
            numericUpDown_Smin.Value = trackBar_Smin.Value;
            LoadColors();
            Changed();
        }

        private void TrackBarSmaxScroll(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Max.Satuation = trackBar_Smax.Value;
            numericUpDown_Smax.Value = trackBar_Smax.Value;
            Changed();
            LoadColors();
        }

        private void TrackBarVminScroll(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Min.Value = trackBar_Vmin.Value;
            numericUpDown_Vmin.Value = trackBar_Vmin.Value;
            LoadColors();
            Changed();
        }

        private void TrackBarVmaxScroll(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Max.Value = trackBar_Vmax.Value;
            numericUpDown_Vmax.Value = trackBar_Vmax.Value;
            LoadColors();
            Changed();
        }

        private void NumericUpDownHminValueChanged(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Min.Hue = (int)numericUpDown_Hmin.Value;
            trackBar_Hmin.Value = (int)numericUpDown_Hmin.Value;
            LoadColors();
            Changed();
        }

        private void NumericUpDownHmaxValueChanged(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Max.Hue = (int)numericUpDown_Hmax.Value;
            trackBar_Hmax.Value = (int)numericUpDown_Hmax.Value;
            LoadColors();
            Changed();
        }

        private void NumericUpDownSminValueChanged(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Min.Satuation = (int)numericUpDown_Smin.Value;
            trackBar_Smin.Value = (int)numericUpDown_Smin.Value;
            LoadColors();
            Changed();
        }

        private void NumericUpDownSmaxValueChanged(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Max.Satuation = (int)numericUpDown_Smax.Value;
            trackBar_Smax.Value = (int)numericUpDown_Smax.Value;
            LoadColors();
            Changed();
        }

        private void NumericUpDownVminValueChanged(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Min.Value = (int)numericUpDown_Vmin.Value;
            trackBar_Vmin.Value = (int)numericUpDown_Vmin.Value;
            LoadColors();
            Changed();
        }

        private void NumericUpDownVmaxValueChanged(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor.Max.Value = (int)numericUpDown_Vmax.Value;
            trackBar_Vmax.Value = (int)numericUpDown_Vmax.Value;
            LoadColors();
            Changed();
        }

        private void ImageBoxPreviewMouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
            if (_isMouseTrackEnable)
            {
                _vision.Ball.Location = e.Location;

                _vision.Ball.IsDetected = true;
            }
        }

        private void CheckBoxEnableMouseTrackerCheckedChanged(object sender, EventArgs e)
        {
            _isMouseTrackEnable = !_isMouseTrackEnable;
        }

        private void ButtonLoadColorsClick(object sender, EventArgs e)
        {
            _vision.LoadColors(Vision.RivalPlayerColor.Cyan);
        }


        private void NumericUpDownTrackIntervalValueChanged(object sender, EventArgs e)
        {
            _tracker.Interval = (int)numericUpDown_TrackInterval.Value;
        }


        private void ButtonPan512Click(object sender, EventArgs e)
        {
            _head.Pan.Position = 512;

            numericUpDown_Pan.Value = 512;
        }

        private void ButtonTilt512Click(object sender, EventArgs e)
        {
            _head.Tilt.Position = 512;

            numericUpDown_Tilt.Value = 512;
        }



        private void NumericUpDownSearchIntervalValueChanged(object sender, EventArgs e)
        {
            _search.Interval = (int)numericUpDown_SearchInterval.Value;
        }

        private void RadioButtonBallScanCheckedChanged(object sender, EventArgs e)
        {
            _search.SelectSearchMethod(Search.SearchMethod.Around);
        }

        private void RadioButtonGoalScanCheckedChanged(object sender, EventArgs e)
        {
            _search.SelectSearchMethod(Search.SearchMethod.Far);
        }

        private void ButtonSearchStartPauseClick(object sender, EventArgs e)
        {
            if (button_SearchStart.Text == "Start")
            {
                _search.SelectSearchMethod(radioButton_BallScan.Checked
                                               ? Search.SearchMethod.Around
                                               : Search.SearchMethod.Far);

                button_SearchStart.Text = "Pause";
                _search.Start();
            }
            else
            {
                button_SearchStart.Text = "Start";
                _search.Stop();
            }
        }



        private void TrackBarImgProcTiltScroll(object sender, EventArgs e)
        {
            numericUpDown_Tilt.Value = trackBarImgProcTilt.Value = trackBarImgProcTilt.Value;

            _head.Tilt.Position = trackBarImgProcTilt.Value;


        }

        private void TrackBarImgProcPanScroll(object sender, EventArgs e)
        {
            numericUpDown_Pan.Value = trackBarImgProcPan.Value = trackBarImgProcPan.Value;

            _head.Pan.Position = trackBarImgProcPan.Value;

        }

        private void ButtonReloadClick(object sender, EventArgs e)
        {
            _imageProcess.GrabedColor = _imageProcess.GrabedColorSpace.GetColor();
            SetNumericUpDowns();
            SetTrackbars();
        }




        private void NumericUpDownErodeValueChanged(object sender, EventArgs e)
        {
            _imageProcess.BallErodeValue = Convert.ToInt32(numericUpDown_BallErode.Value);
        }

        private void NumericUpDownDilateValueChanged(object sender, EventArgs e)
        {
            _imageProcess.BallDilateValue = Convert.ToInt32(numericUpDown_BallDilate.Value);
        }

        private void ButtonAddClick(object sender, EventArgs e)
        {
            label_GrabedHSV_Value.Text = _imageProcess.GrabedColor.Min.ToString() + Resources.VisionLab_ButtonAddClick__ + _imageProcess.GrabedColor.Max.ToString();
            _imageProcess.GrabedColorSpace.Add(new ColorPicker(_imageProcess.GrabedColor));
            Changed();
        }

        private void ButtonFpsStartClick(object sender, EventArgs e)
        {
            if (!Timer_FPS.Enabled)
            {
                Timer_FPS.Start();
                button_CaptureStartPause.Text = Resources.VisionLab_ButtonFpsStartClick_Pause;
            }
            else
            {
                Timer_FPS.Stop();
                button_CaptureStartPause.Text = Resources.VisionLab_ButtonFpsStartClick_Start;
            }

        }

        private void TimerFpsTick(object sender, EventArgs e)
        {
            Lable_RealTimeFPS.Text = _imageProcess.Fps.ToString(CultureInfo.InvariantCulture);
        }

        private void numericUpDown_TiltSpeed_ValueChanged(object sender, EventArgs e)
        {
            _head.Tilt.Speed = Convert.ToInt32(numericUpDown_TiltSpeed.Value);
        }

        private void comboBox_TiltSlop_SelectedIndexChanged(object sender, EventArgs e)
        {
            _head.Tilt.Slop = Convert.ToInt32(comboBox_TiltSlop.SelectedItem);
        }

        private void numericUpDown_PanSpeed_ValueChanged(object sender, EventArgs e)
        {
            _head.Pan.Speed = Convert.ToInt32(numericUpDown_PanSpeed.Value);
        }

        private void comboBox_PanSlop_SelectedIndexChanged(object sender, EventArgs e)
        {
            _head.Pan.Slop = Convert.ToInt32(comboBox_PanSlop.SelectedItem);
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox_Track_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown_SquareSide_ValueChanged(object sender, EventArgs e)
        {
            _tracker.SquareSide = (int)numericUpDown_SquareSide.Value;

        }

        private void numericUpDownOnField_ValueChanged(object sender, EventArgs e)
        {
            _imageProcess.MinFieldPixels = (int)numericUpDownOnField.Value;

        }

        private void numericUpDown_upTilt_ValueChanged(object sender, EventArgs e)
        {
            _search.UpTilt = (int)numericUpDown_upTilt.Value;
        }

        private void numericUpDown_MiddleTilt_ValueChanged(object sender, EventArgs e)
        {
            _search.MiddleTilt = (int)numericUpDown_MiddleTilt.Value;
        }

        private void numericUpDown_DownTilt_ValueChanged(object sender, EventArgs e)
        {
            _search.DownTilt = (int)numericUpDown_DownTilt.Value;
        }

        private void numericUpDown_MinPan_ValueChanged(object sender, EventArgs e)
        {
            _search.PanMin = (int)numericUpDown_MinPan.Value;
        }

        private void numericUpDown_MaxPan_ValueChanged(object sender, EventArgs e)
        {
            _search.PanMax = (int)numericUpDown_MaxPan.Value;
        }

        private void numericUpDown_MovingUnit_ValueChanged(object sender, EventArgs e)
        {
            _search.MovingUnit = (int)numericUpDown_MovingUnit.Value;
        }

        private void numericUpDown_GoalDilate_ValueChanged(object sender, EventArgs e)
        {
            _imageProcess.GoalDilateValue = Convert.ToInt32(numericUpDown_GoalDilate.Value);
        }

        private void numericUpDown_GoalErode_ValueChanged(object sender, EventArgs e)
        {
            _imageProcess.GoalErodeValue = Convert.ToInt32(numericUpDown_GoalErode.Value);
        }

        private void numericUpDown_FieldDilate_ValueChanged(object sender, EventArgs e)
        {
            _imageProcess.FieldDilateValue = Convert.ToInt32(numericUpDown_FieldDilate.Value);
        }

        private void numericUpDown_FieldErode_ValueChanged(object sender, EventArgs e)
        {
            _imageProcess.FieldErodeValue = Convert.ToInt32(numericUpDown_FieldErode.Value);
        }

        private void numericUpDown_VAngle_ValueChanged(object sender, EventArgs e)
        {
            _tracker.CameraVerticalAngle = (int)numericUpDown_VAngle.Value;
        }

        private void numericUpDown_HAngle_ValueChanged(object sender, EventArgs e)
        {
            _tracker.CameraHorizontalAngel = (int)numericUpDown_HAngle.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            _tracker.PanSpeedCon = (int)numericUpDown_PanSpeedCon.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _tracker.TiltSpeedCon = (int)numericUpDown_TiltSpeedCon.Value;
        }

        private void numericUpDown_PanPosCon_ValueChanged(object sender, EventArgs e)
        {
            _tracker.PanPosCon = (double)numericUpDown_PanPosCon.Value;
        }

        private void numericUpDown_TiltPosCon_ValueChanged(object sender, EventArgs e)
        {
            _tracker.TiltPosCon = (double)numericUpDown_TiltPosCon.Value;
        }

        private void imageBox_OtuputFrame_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            _imageProcess.minThersh = Convert.ToInt32(numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            _imageProcess.maxThersh = Convert.ToInt32(numericUpDown2.Value);
        }

        private void numericUpDown_BrightNess_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            _imageProcess.Thersh = Convert.ToInt32(numericUpDown5.Value);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            _imageProcess.HoghMin = Convert.ToInt32(numericUpDown4.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            _imageProcess.HoghMax = Convert.ToInt32(numericUpDown3.Value);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            _imageProcess.SwitchBoundary = Convert.ToInt32(numericUpDown6.Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                _imageProcess.ProcessingMode = ImageProcess.Mode.Play;
            }
            else
            {

                _imageProcess.ProcessingMode = ImageProcess.Mode.Laboratory;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var img = new Image<Hsv, byte>("test.jpg");
         
            var hist = Tools.HistogramHelper.GenerateHistograms(img,null,32);
            _imageProcess.ballHist = hist;


           
        }



    }
}
