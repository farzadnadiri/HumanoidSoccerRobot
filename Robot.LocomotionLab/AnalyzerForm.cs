using System;
using System.Windows.Forms;
using Robot.Environment;
using Robot.Environment.Interface;

namespace Robot.Locomotion
{
    public partial class AnalyzerForm : Form
    {
        private IBody _body;
        private Controll _controll;

        public AnalyzerForm(IBody body, Controll controll)
        {
            _body = body;
            _controll = controll;
            InitializeComponent();
        }

        private void timer_Updater_Tick(object sender, EventArgs e)
        {
            if (checkBox_Walk.Checked)
            {
                chart_DarwinOP_Walk_Tuner_Right.Series["HipYaw"].Points.Add(_body.RightHipYaw.Angle);
                chart_DarwinOP_Walk_Tuner_Right.Series["HipRoll"].Points.Add(_body.RightHipRoll.Angle);
                chart_DarwinOP_Walk_Tuner_Right.Series["HipPitch"].Points.Add(_body.RightHipPitch.Angle);
                chart_DarwinOP_Walk_Tuner_Right.Series["Knee"].Points.Add(_body.RightKnee.Angle);
                chart_DarwinOP_Walk_Tuner_Right.Series["AnklePitch"].Points.Add(_body.RightAnklePitch.Angle);
                chart_DarwinOP_Walk_Tuner_Right.Series["AnkleRoll"].Points.Add(_body.RightAnkleRoll.Angle);

                if (chart_DarwinOP_Walk_Tuner_Right.Series["HipYaw"].Points.Count > 230)
                {

                    chart_DarwinOP_Walk_Tuner_Right.Series["HipYaw"].Points.RemoveAt(0);
                    chart_DarwinOP_Walk_Tuner_Right.Series["HipRoll"].Points.RemoveAt(0);
                    chart_DarwinOP_Walk_Tuner_Right.Series["HipPitch"].Points.RemoveAt(0);
                    chart_DarwinOP_Walk_Tuner_Right.Series["Knee"].Points.RemoveAt(0);
                    chart_DarwinOP_Walk_Tuner_Right.Series["AnklePitch"].Points.RemoveAt(0);
                    chart_DarwinOP_Walk_Tuner_Right.Series["AnkleRoll"].Points.RemoveAt(0);

                }
            }

            if (checkBox_IMU.Checked)
            {
                chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAnglePitch"].Points.Add(_controll.ActualPitch);
                chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAngleRoll"].Points.Add(_controll.ActualRoll);
                chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAngleYaw"].Points.Add(_controll.Compass);
                chart_DarwinOP_Walk_Tuner_Right.Series["GyroX"].Points.Add(_controll._newControl.GyroError);
                //chart_DarwinOP_Walk_Tuner_Right.Series["GyroY"].Points.Add(_body.RightAnklePitch.Angle);
                //chart_DarwinOP_Walk_Tuner_Right.Series["GyroZ"].Points.Add(_body.RightAnkleRoll.Angle);

                if (chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAnglePitch"].Points.Count > 230)
                {
                    chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAnglePitch"].Points.RemoveAt(0);
                    chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAngleRoll"].Points.RemoveAt(0);
                    chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAngleYaw"].Points.RemoveAt(0);
                    chart_DarwinOP_Walk_Tuner_Right.Series["GyroX"].Points.RemoveAt(0);
                    //chart_DarwinOP_Walk_Tuner_Right.Series["GyroY"].Points.RemoveAt(0);
                    //chart_DarwinOP_Walk_Tuner_Right.Series["GyroZ"].Points.RemoveAt(0);

                }
            }

        }

        private void checkBox_Walk_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Walk.Checked)
            {
                chart_DarwinOP_Walk_Tuner_Right.Series["HipYaw"].Enabled = true;
                chart_DarwinOP_Walk_Tuner_Right.Series["HipRoll"].Enabled = true;
                chart_DarwinOP_Walk_Tuner_Right.Series["HipPitch"].Enabled = true;
                chart_DarwinOP_Walk_Tuner_Right.Series["Knee"].Enabled = true;
                chart_DarwinOP_Walk_Tuner_Right.Series["AnklePitch"].Enabled = true;
                chart_DarwinOP_Walk_Tuner_Right.Series["AnkleRoll"].Enabled = true;
            }
            else
            {
                chart_DarwinOP_Walk_Tuner_Right.Series["HipYaw"].Enabled = false;
                chart_DarwinOP_Walk_Tuner_Right.Series["HipRoll"].Enabled = false;
                chart_DarwinOP_Walk_Tuner_Right.Series["HipPitch"].Enabled = false;
                chart_DarwinOP_Walk_Tuner_Right.Series["Knee"].Enabled = false;
                chart_DarwinOP_Walk_Tuner_Right.Series["AnklePitch"].Enabled = false;
                chart_DarwinOP_Walk_Tuner_Right.Series["AnkleRoll"].Enabled = false;
            }
        }

        private void checkBox_IMU_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IMU.Checked)
            {
                chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAnglePitch"].Enabled = true;
                chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAngleRoll"].Enabled = true;
                chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAngleYaw"].Enabled = true;
                chart_DarwinOP_Walk_Tuner_Right.Series["GyroX"].Enabled = true;
                //chart_DarwinOP_Walk_Tuner_Right.Series["GyroY"].Enabled = true;
                //chart_DarwinOP_Walk_Tuner_Right.Series["GyroZ"].Enabled = true;
            }
            else
            {
                chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAnglePitch"].Enabled = false;
                chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAngleRoll"].Enabled = false;
                chart_DarwinOP_Walk_Tuner_Right.Series["FilteredAngleYaw"].Enabled = false;
                chart_DarwinOP_Walk_Tuner_Right.Series["GyroX"].Enabled = false;
                //chart_DarwinOP_Walk_Tuner_Right.Series["GyroY"].Enabled = false;
                //chart_DarwinOP_Walk_Tuner_Right.Series["GyroZ"].Enabled = false;
            }
        }
    }
}
