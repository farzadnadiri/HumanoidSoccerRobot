using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using Robot.Environment;
using Robot.Environment.Interface;
using Robot.IO;
using Robot.Locomotion.TrajectoryWalk;
using Robot.Utils;

namespace Robot.Locomotion
{
    public partial class MotionLab : Form
    {
        private static int _currentPageIndex = -1;
        private static int _currentStepIndex;
        private string _currentMotionFilePath;
        private Step _stepRepository;

        private IBody _body;
        private MotionManager _motionManager;
        private FourStepWalkEngine _fourStepWalkEngin;
        private TrajectoryWalkEngine _trjectoryWalking;
        private DynamixelBus _bus;
        private Controll _controll;
        private WalkManager _walkmanager;
        public MotionLab(DynamixelBus bus, IBody body, MotionManager motionManager, FourStepWalkEngine fourStep, TrajectoryWalkEngine darwinWalking, Controll control, WalkManager walkmanger)
        {
            InitializeComponent();

            _controll = control;

            _bus = bus;
            _body = body;
            _motionManager = motionManager;
            _fourStepWalkEngin = fourStep;
            _trjectoryWalking = darwinWalking;
            _walkmanager = walkmanger;

            EnumerateComPorts();
            EnumerateComPortsIMU();
            InitialInterface();
            _stepRepository = new Step(-1, 0, 0, new Posture(_body.Joints.Count));


            if (_bus.IsOpen)
            {
                toolStripButton_Connect.Enabled = false;
                toolStripComboBox_Port.Enabled = false;
                toolStripButton_Refresh.Enabled = false;
                toolStripButton_Disonnect.Enabled = true;
            }

            LoadDirections();
            LoadWalkSettings();

            dataGridView_PoseOfMotor.MouseWheel += DataGridViewPoseOfMotorMouseWheel;
        }

        void DataGridViewPoseOfMotorMouseWheel(object sender, MouseEventArgs e)
        {
            if (dataGridView_PoseOfMotor.SelectedRows.Count >= 1)
            {
                for (int i = 0; i < dataGridView_PoseOfMotor.SelectedRows.Count; i++)
                {
                    _body[dataGridView_PoseOfMotor.SelectedRows[i].Index].AutoFlush = true;
                    _body[dataGridView_PoseOfMotor.SelectedRows[i].Index].Speed = 800;
                    if (e.Delta > 0)
                    {
                        _body[dataGridView_PoseOfMotor.SelectedRows[i].Index].Angle += 1;
                        dataGridView_PoseOfMotor.SelectedRows[i].Cells[1].Value =
                            _body[dataGridView_PoseOfMotor.SelectedRows[i].Index].Angle;
                    }
                    else
                    {
                        _body[dataGridView_PoseOfMotor.SelectedRows[i].Index].Angle -= 1;
                        dataGridView_PoseOfMotor.SelectedRows[i].Cells[1].Value =
                            _body[dataGridView_PoseOfMotor.SelectedRows[i].Index].Angle;
                    }
                    _body[dataGridView_PoseOfMotor.SelectedRows[i].Index].AutoFlush = false;
                }
            }
        }

        private void EnumerateComPorts()
        {
            toolStripComboBox_Port.Items.Clear();
            toolStripComboBox_Port.Text = string.Empty;
            toolStripComboBox_Port.Items.AddRange(SerialPort.GetPortNames());
            if (toolStripComboBox_Port.Items.Count > 0)
            {
                toolStripComboBox_Port.SelectedIndex = 0;
            }
        }


        private void EnumerateComPortsIMU()
        {
            comboBox_PortName.Items.Clear();
            comboBox_PortName.Text = string.Empty;
            comboBox_PortName.Items.AddRange(SerialPort.GetPortNames());
            if (comboBox_PortName.Items.Count > 0)
            {
                comboBox_PortName.SelectedIndex = 0;
            }
        }

        private void LoadMotionsToInterface()
        {
            int counter = 0;
            dataGridView_MotionPage.Rows.Clear();
            foreach (var page in _motionManager.Pages)
            {
                dataGridView_MotionPage.Rows.Add(new DataGridViewRow());
                dataGridView_MotionPage.Rows[counter].Cells[0].Value = page.Id;
                dataGridView_MotionPage.Rows[counter].Cells[1].Value = page.Name;
                dataGridView_MotionPage.Rows[counter].Cells[2].Value = page.Next;
                dataGridView_MotionPage.Rows[counter].Cells[3].Value = page.Exit;
                if (_motionManager.Pages[counter].Steps[0].Enable)
                {
                    dataGridView_MotionPage.Rows[counter].Cells[0].Style.BackColor = Color.SpringGreen;
                    dataGridView_MotionPage.Rows[counter].Cells[1].Style.BackColor = Color.SpringGreen;
                    dataGridView_MotionPage.Rows[counter].Cells[2].Style.BackColor = Color.SpringGreen;
                    dataGridView_MotionPage.Rows[counter].Cells[3].Style.BackColor = Color.SpringGreen;
                }
                counter++;
            }

        }

        private void LoadPageToInterface()
        {
            int counter = 0;
            dataGridView_Steps.Rows.Clear();

            foreach (var step in _motionManager.Pages[_currentPageIndex].Steps)
            {
                if (step.Enable)
                {
                    dataGridView_Steps.Rows.Add(new DataGridViewRow());
                    dataGridView_Steps.Rows[counter].Cells[0].Value = step.Id;
                    dataGridView_Steps.Rows[counter].Cells[1].Value = step.Time;
                    dataGridView_Steps.Rows[counter].Cells[2].Value = step.Pause;
                    counter++;
                }
            }
            LoadSlopMarginsToInterface(_currentPageIndex);
            numericUpDown_RepeatTime.Value = _motionManager.Pages[_currentPageIndex].RepeatTime;
            numericUpDown_SpeedRate.Text = _motionManager.Pages[_currentPageIndex].SpeedRate.ToString();
            numericUpDown_CtrlInertialForce.Text =
                _motionManager.Pages[_currentPageIndex].InertialForce.ToString();
            UpdateRealPlaytime();
        }

        private void LoadSlopMarginsToInterface(int index)
        {
            for (int i = 0; i < _body.Joints.Count; i++)
            {
                dataGridView_Page_SlopMargin.Rows[i].Cells[0].Value = _body[i].Name;
                dataGridView_Page_SlopMargin.Rows[i].Cells[1].Value = _motionManager.Pages[index].Slops[i];
                dataGridView_Page_SlopMargin.Rows[i].Cells[2].Value = _motionManager.Pages[index].Margins[i];
            }
        }

        private void LoadStepToInterface(int index)
        {
            if (index >= 0)
            {
                _currentStepIndex = index;
                for (int i = 0; i < _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Angels.Count; i++)
                {
                    dataGridView_PoseOfSteps.Rows[i].Cells[0].Value = _body[i].Name;
                    dataGridView_PoseOfSteps.Rows[i].Cells[1].Value = _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Angels[i];
                }
            }
        }

        private void LoadCurrentPositionsToInterface()
        {
            for (int i = 0; i < _body.Joints.Count; i++)
            {
                dataGridView_PoseOfMotor.Rows[i].Cells[0].Value = _body[i].Name;
                dataGridView_PoseOfMotor.Rows[i].Cells[1].Value = _body[i].Angle;
            }
        }

        private void DataGridViewMotionPageCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _currentPageIndex = e.RowIndex;
                LoadPageToInterface();

                if (dataGridView_Steps.Rows.Count > 0)
                {
                    dataGridView_Steps.Rows[0].Selected = true;
                    LoadStepToInterface(0);
                }
            }
        }

        private void UpdateRealPlaytime()
        {
            int counter = 0;
            double realplaytime = 0;
            if (_currentPageIndex >= 0)
            {
                foreach (var step in _motionManager.Pages[_currentPageIndex].Steps)
                {
                    if (step.Time > 0)
                    {
                        realplaytime += step.Time + step.Pause;
                        counter++;
                    }
                }

                textBox_RealPlayTime.Text = string.Format("({0}sec / 1) x {1} =  {2} sec ", realplaytime,
                                                          _motionManager.Pages[_currentPageIndex].RepeatTime,
                                            realplaytime * _motionManager.Pages[_currentPageIndex].RepeatTime);
            }
        }

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Are You Sure ?!", "Creat new motion list", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                _currentMotionFilePath = String.Empty;
                _motionManager.ClearPages();
                LoadMotionsToInterface();
            }
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_currentMotionFilePath != String.Empty)
            {
                //_motionManager.SaveMotions(_currentMotionFilePath);
            }
            else
            {
                saveAsToolStripMenuItem.PerformClick();
            }
        }

        private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog_XmlOutput.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _currentMotionFilePath = saveFileDialog_XmlOutput.FileName;
                _motionManager.Save(saveFileDialog_XmlOutput.FileName);
            }
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog_XmlInput.ShowDialog();
            if (dr == DialogResult.OK)
            {
                _currentMotionFilePath = openFileDialog_XmlInput.FileName;
                _motionManager.Load(_currentMotionFilePath);
                LoadMotionsToInterface();
            }
        }

        private void DataGridViewStepsCellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadStepToInterface(e.RowIndex);
        }

        private void ButtonAddStepClick(object sender, EventArgs e)
        {
            int index = dataGridView_Steps.Rows.Count;

            if (index >= 0 && index < 7 && _currentPageIndex >= 0)
            {
                _motionManager.Pages[_currentPageIndex].Steps[index].Time = 1;
                _motionManager.Pages[_currentPageIndex].Steps[index].Enable = true;
                dataGridView_Steps.Rows.Add(new DataGridViewRow());
                dataGridView_Steps.Rows[index].Cells[0].Value = _motionManager.Pages[_currentPageIndex].Steps[index].Id;
                dataGridView_Steps.Rows[index].Cells[1].Value = _motionManager.Pages[_currentPageIndex].Steps[index].Time;
                dataGridView_Steps.Rows[index].Cells[2].Value = _motionManager.Pages[_currentPageIndex].Steps[index].Pause;
            }
            UpdateRealPlaytime();
        }

        private void ButtonRemoveStepClick(object sender, EventArgs e)
        {
            _motionManager.Pages[_currentPageIndex].RemoveStep(dataGridView_Steps.CurrentRow.Index);
            LoadPageToInterface();
            UpdateRealPlaytime();
        }

        private void DataGridViewMotionPageRowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_motionManager.Pages[e.RowIndex].Steps[0].Enable)
            {
                dataGridView_MotionPage.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.SpringGreen;
                dataGridView_MotionPage.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.SpringGreen;
                dataGridView_MotionPage.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.SpringGreen;
                dataGridView_MotionPage.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.SpringGreen;
            }
            else
            {
                dataGridView_MotionPage.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.White;
                dataGridView_MotionPage.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                dataGridView_MotionPage.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.White;
                dataGridView_MotionPage.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.White;
            }
        }

        private void DataGridViewMotionPageCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _motionManager.Pages[e.RowIndex].Name = dataGridView_MotionPage.Rows[e.RowIndex].Cells[1].Value.ToString();
                _motionManager.Pages[e.RowIndex].Next =
                    Convert.ToInt32(dataGridView_MotionPage.Rows[e.RowIndex].Cells[2].Value);
                _motionManager.Pages[e.RowIndex].Exit =
                    Convert.ToInt32(dataGridView_MotionPage.Rows[e.RowIndex].Cells[3].Value);
            }
            catch
            {
            }
        }

        private void NumericUpDownRepeatTimeValueChanged(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0)
            {
                _motionManager.Pages[_currentPageIndex].RepeatTime = (int)numericUpDown_RepeatTime.Value;
                UpdateRealPlaytime();
            }
        }

        private void NumericUpDownSpeedRateValueChanged(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0)
            {
                _motionManager.Pages[_currentPageIndex].SpeedRate = Convert.ToDouble(numericUpDown_SpeedRate.Text);
            }
        }

        private void NumericUpDownCtrlInertialForceValueChanged(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0)
            {
                _motionManager.Pages[_currentPageIndex].InertialForce = (int)numericUpDown_CtrlInertialForce.Value;
            }
        }

        private void ButtonPlayStepClick(object sender, EventArgs e)
        {
            if (_currentStepIndex < dataGridView_Steps.Rows.Count)
            {
                //_motionManager.Pages[_currentPageIndex].SetSlops() ! 
                _body.HomogenizeSpeeds();
                double temp = _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Time;
                _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Time = 0.2;
                if (_bus.IsOpen)
                {
                    _motionManager.PlayStep(_currentPageIndex, _currentStepIndex);
                }
                _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Time = temp;
                LoadCurrentPositionsToInterface();
            }
        }

        private void DataGridViewPoseOfStepsCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Angels[e.RowIndex] =
                    Convert.ToInt32(dataGridView_PoseOfSteps.Rows[e.RowIndex].Cells[1].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridViewStepsCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Time =
                Convert.ToDouble(dataGridView_Steps.Rows[e.RowIndex].Cells[1].Value);

            _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Pause =
                Convert.ToDouble(dataGridView_Steps.Rows[e.RowIndex].Cells[2].Value);
            UpdateRealPlaytime();
        }

        private void ButtonTurnOnActuatorsClick(object sender, EventArgs e)
        {
            int counter = dataGridView_PoseOfMotor.SelectedRows.Count;
            for (int i = 0; i < counter; i++)
            {
                _body[dataGridView_PoseOfMotor.SelectedRows[i].Index].Enable = true;
                dataGridView_PoseOfMotor.SelectedRows[i].Cells[0].Style.BackColor = Color.White;
                dataGridView_PoseOfMotor.SelectedRows[i].Cells[1].Style.BackColor = Color.White;
            }
            LoadCurrentPositionsToInterface();
        }

        private void ButtonTurnOffActuatorsClick(object sender, EventArgs e)
        {
            int counter = dataGridView_PoseOfMotor.SelectedRows.Count;

            for (int i = 0; i < counter; i++)
            {
                _body[dataGridView_PoseOfMotor.SelectedRows[i].Index].Enable = false;
                dataGridView_PoseOfMotor.SelectedRows[i].Cells[0].Style.BackColor = Color.Tomato;
                dataGridView_PoseOfMotor.SelectedRows[i].Cells[1].Style.BackColor = Color.Tomato;
            }
        }

        private void ButtonReadMotorClick(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0)
            {
                for (int i = 0; i < _body.Joints.Count; i++)
                {
                    _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Angels[i] = (int)_body[i].Angle;
                }
                LoadStepToInterface(_currentStepIndex);
            }
        }

        private void ButtonStepUpClick(object sender, EventArgs e)
        {
            if (_currentStepIndex > 0)
            {
                Step.Exchange(_motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex],
                              _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex - 1]);
                LoadPageToInterface();
                LoadStepToInterface(_currentStepIndex);
            }
        }

        private void ButtonStepDownClick(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0 && _currentStepIndex < _motionManager.StepsPerPage - 1)
            {
                Step.Exchange(_motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex],
                              _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex + 1]);
                LoadPageToInterface();
                LoadStepToInterface(_currentStepIndex);
            }
        }

        private void ButtonSetStandStyleClick(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0)
            {
                _body.StandStyle = _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Angels;
            }
        }

        private void ButtonStepCopyClick(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0)
            {
                _stepRepository = _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Copy();
            }
        }

        private void ButtonStepPasteClick(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0)
            {
                _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex] = _stepRepository.Copy();
                _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Id = _currentStepIndex + 1;
                LoadPageToInterface();
                LoadStepToInterface(_currentStepIndex);
                dataGridView_Steps.Rows[_currentStepIndex].Selected = true;
            }
        }

        private void ButtonLoadStepClick(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0)
            {
                DialogResult dr = openFileDialog_XmlInput.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Load(openFileDialog_XmlInput.FileName);
                    LoadPageToInterface();
                    LoadStepToInterface(_currentStepIndex);
                    dataGridView_Steps.Rows[_currentStepIndex].Selected = true;
                }
            }
        }

        private void ButtonSaveStepClick(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0 && _currentStepIndex >= 0)
            {
                DialogResult dr = saveFileDialog_XmlOutput.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Save(saveFileDialog_XmlOutput.FileName);
                }
            }
        }

        private void DataGridViewPoseOfMotorCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _body[e.RowIndex].AutoFlush = true;
                _body[e.RowIndex].Speed = 400;
                _body[e.RowIndex].Angle =
                    Convert.ToInt32(dataGridView_PoseOfMotor.Rows[e.RowIndex].Cells[1].Value);
                dataGridView_PoseOfMotor.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.White;
                dataGridView_PoseOfMotor.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                _body[e.RowIndex].AutoFlush = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _body[e.RowIndex].AutoFlush = false;
            }
        }

        private void ButtonMirrorExchangeClick(object sender, EventArgs e)
        {
            _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Angels.Mirror();
            LoadStepToInterface(_currentStepIndex);
        }

        private void ToolStripButtonNewClick(object sender, EventArgs e)
        {
            newToolStripMenuItem.PerformClick();
        }

        private void ToolStripButtonOpenClick(object sender, EventArgs e)
        {
            openToolStripMenuItem.PerformClick();
        }

        private void ToolStripButtonSaveClick(object sender, EventArgs e)
        {
            saveToolStripMenuItem.PerformClick();
        }

        private void ToolStripButtonConnectClick(object sender, EventArgs e)
        {
            if (!_bus.IsOpen)
            {
                if (!String.IsNullOrEmpty(toolStripComboBox_Port.Text))
                {
                    //int devicenumber = Convert.ToInt32(toolStripComboBox_Port.SelectedItem.ToString().Remove(0, 3));
                    _bus.Open(toolStripComboBox_Port.SelectedItem.ToString());
                    if (_bus.IsOpen)
                    {
                        toolStripButton_Connect.Enabled = false;
                        toolStripComboBox_Port.Enabled = false;
                        toolStripButton_Disonnect.Enabled = true;
                    }
                }
            }
        }

        private void ToolStripButtonDisconnectClick(object sender, EventArgs e)
        {
            _bus.Close();
            toolStripButton_Disonnect.Enabled = false;
            toolStripButton_Connect.Enabled = true;
            toolStripComboBox_Port.Enabled = true;
            toolStripButton_Refresh.PerformClick();
        }

        private void ToolStripButtonRefreshPortsClick(object sender, EventArgs e)
        {
            EnumerateComPorts();
        }

        private void ExitToolStripMenuItem1Click(object sender, EventArgs e)
        {

            //JoyStickController.Stop();
            _fourStepWalkEngin.Stop();
            Application.Exit();
        }


        private void MotionLabFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.No == MessageBox.Show(
             "Recent changes have not been saved. Close the application anyway?",
             "Close Application?",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button2))
            {
                e.Cancel = true;
            }
        }

        private void DataGridViewPageSlopMarginCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _motionManager.Pages[_currentPageIndex].Slops[e.RowIndex] =
                    Convert.ToInt32(dataGridView_Page_SlopMargin.Rows[e.RowIndex].Cells[1].Value);
                _motionManager.Pages[_currentPageIndex].Margins[e.RowIndex] =
                    Convert.ToInt32(dataGridView_Page_SlopMargin.Rows[e.RowIndex].Cells[2].Value);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //_body.Save("Config/Body.xml");

        private void DataGridViewPoseOfMotorCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int count = dataGridView_PoseOfMotor.SelectedRows.Count;
                if (count >= 1)
                {
                    dataGridView_PoseOfMotor.SelectedRows[0].Cells[1].Value =
                        _body.Joints[dataGridView_PoseOfMotor.SelectedRows[0].Index].Angle;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonPingClick(object sender, EventArgs e)
        {
            for (int i = 0; i < _body.Joints.Count; i++)
            {
                if (_body[i].Ping())
                {
                    dataGridView_PoseOfSteps.Rows[i].Cells[0].Style.BackColor = Color.Green;
                    dataGridView_PoseOfSteps.Rows[i].Cells[1].Style.BackColor = Color.Green;
                }
                else
                {
                    dataGridView_PoseOfSteps.Rows[i].Cells[0].Style.BackColor = Color.Red;
                    dataGridView_PoseOfSteps.Rows[i].Cells[1].Style.BackColor = Color.Red;
                }
            }
        }

        private void InitialInterface()
        {
            for (int i = 0; i < _body.Joints.Count; i++)
            {
                dataGridView_Page_SlopMargin.Rows.Add(new DataGridViewRow());
                dataGridView_PoseOfSteps.Rows.Add(new DataGridViewRow());
                dataGridView_PoseOfMotor.Rows.Add(new DataGridViewRow());
            }
        }

        private void toolStripComboBox_Port_Click(object sender, EventArgs e)
        {
            EnumerateComPorts();
        }

        private void button_PlayMotion_Click(object sender, EventArgs e)
        {
            _body.HomogenizeSpeeds();
            _motionManager.PlayMotionAsync(_currentPageIndex);
        }

        private void button_StopMotion_Click(object sender, EventArgs e)
        {
            _motionManager.StopMotion();
        }

        private void X_OFFSET_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.XOffset = Convert.ToDouble(X_OFFSET.Value);
        }

        private void Y_OFFSET_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.YOffset = Convert.ToDouble(Y_OFFSET.Value);
        }

        private void Z_OFFSET_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.ZOffset = Convert.ToDouble(Z_OFFSET.Value);
        }

        private void A_OFFSET_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.AOffset = Convert.ToDouble(A_OFFSET.Value);
        }

        private void TIME_PERIOD_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.PeriodTime = Convert.ToDouble(TIME_PERIOD.Value);

        }

        private void TIME_UNIT_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.TimeUnit = Convert.ToInt32(TIME_UNIT.Value);
        }

        private void button_DarwinWalkStart_Click(object sender, EventArgs e)
        {
            _walkmanager.WalkStart();
        }

        private void button_DarwinWalkStop_Click(object sender, EventArgs e)
        {
            _walkmanager.WalkStop(false);
        }

        private void LoadDirections()
        {
            dataGridView_ActuatorsDirection.Rows.Clear();
            dataGridView_ActuatorsDirection.Rows.Add(_trjectoryWalking.Dir.Length);

            string[] names = { "R_HIP_YAW", "R_HIP_ROLL", "R_HIP_PITCH", "R_KNEE", "R_ANKLE_PITCH", "R_ANKLE_ROLL", "L_HIP_YAW", "L_HIP_ROLL", "L_HIP_PITCH", "L_KNEE", "L_ANKLE_PITCH", "L_ANKLE_ROLL", "R_ARM_SWING", "L_ARM_SWING" };

            for (int i = 0; i < _trjectoryWalking.Dir.Length; i++)
            {
                dataGridView_ActuatorsDirection.Rows[i].Cells["DirectionJointName"].Value = names[i];
                dataGridView_ActuatorsDirection.Rows[i].Cells["JointDirection"].Value = _trjectoryWalking.Dir[i];
            }
        }

        private void LoadWalkSettings()
        {
            X_OFFSET.Value = (decimal)_trjectoryWalking.XOffset;
            Y_OFFSET.Value = (decimal)_trjectoryWalking.YOffset;
            Z_OFFSET.Value = (decimal)_trjectoryWalking.ZOffset;
            A_OFFSET.Value = (decimal)_trjectoryWalking.AOffset;

            X_Target.Value = (decimal)_trjectoryWalking.XMoveAmplitude;
            Y_MOVE_AMPLITUDE.Value = (decimal)_trjectoryWalking.YMoveAmplitude;


            TIME_PERIOD.Value = (decimal)_trjectoryWalking.PeriodTime;
            TIME_UNIT.Value = _trjectoryWalking.TimeUnit;

            DOUBLESTANCERATIO.Value = (decimal)_trjectoryWalking.DoubleStancePeriodRatio;
            FORWARDBACKWARDRATIO.Value = (decimal)_trjectoryWalking.StepForwardBackwardRatio;


            Z_SWAP_AMPLITUDE.Value = (decimal)_trjectoryWalking.ZSwapAmplitude;
            numericUpDown_ArmSwingGain.Value = (decimal)_trjectoryWalking.ArmSwingGain;

            numericUpDown_PitchZero0.Value = _controll.PitchZero;
            numericUpDown_RollZero.Value = _controll.RollZero;

            numericUpDown_CompassOffset.Value = _controll.CompassOffset;

            numericUpDown_IsFalling.Value = (decimal)_controll.FallingBoundary;
            numericUpDown_FallBack.Value = (decimal)_controll.FallBackBoundary;
            numericUpDown_FallFront.Value = (decimal)_controll.FallFrontBoundary;
            numericUpDown_FallSide_Left.Value = (decimal)_controll.FallSideLeftBoundary;
            numericUpDown_FallSide_Right.Value = (decimal)_controll.FallSideRightBoundary;

            checkBox_Stabilization.Checked = _trjectoryWalking.StabilizationEnable;
            numericUpDown_GyroP.Value = (decimal)_trjectoryWalking.PIDGyro.Kp;
            numericUpDown_GyroD.Value = (decimal)_trjectoryWalking.PIDGyro.Kd;

            numericUpDown_ActuatorsSpeed.Value = _trjectoryWalking.ActuatorsSpeed;
            numericUpDown_HandPitchGain.Value = (decimal)_trjectoryWalking.HandPitchGain;

            numericUpDown_HandLowPassGain.Value = (decimal)_controll.HandLowpass.Gain;
            numericUpDown_AnkleLowPassGain.Value = (decimal)_controll.GyroAnklePitchLowPass.Gain;

            IsFallingMotionIndex.Value = _walkmanager.FallingMotionIndex;
            FallBackMotionIndex.Value = _walkmanager.BackStandUpIndex;
            FallFrontMotionIndex.Value = _walkmanager.FrontStandUpIndex;

            numericUpDown_InsuranceCounter.Value = _controll.FallCounter;

            LoadWalkMnagerParametrs();
        }

        private void dataGridView_ActuatorsDirection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _trjectoryWalking.Dir[e.RowIndex] =
                Convert.ToInt32(dataGridView_ActuatorsDirection.Rows[e.RowIndex].Cells["JointDirection"].Value);
        }

        private void button_LoadLastPose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _body.Joints.Count; i++)
            {
                dataGridView_PoseOfMotor.Rows[i].Cells[1].Value = (int)_body[i].Angle;
            }
        }

        private void checkBox_Control_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Control.Checked)
            {
                _trjectoryWalking.WalkStop(true);
            }
        }

        private void button_SaveWalkSettings_Click(object sender, EventArgs e)
        {
            _trjectoryWalking.Save("Config/TrajectoryWalk.xml");
            _controll.Save("Config/Controll.xml");
        }

        private void button_LoadWalkSettings_Click(object sender, EventArgs e)
        {
            _trjectoryWalking.Load("Config/TrajectoryWalk.xml");
            _controll.Load("Config/Controll.xml");
        }

        private void button_WalkOffset_Click(object sender, EventArgs e)
        {
            if (_currentPageIndex >= 0)
            {
                _trjectoryWalking.WalkOffset = _motionManager.Pages[_currentPageIndex].Steps[_currentStepIndex].Copy();
            }
        }

        private void checkBox_AMoveAimOn_CheckedChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.AMoveAimOn = checkBox_AMoveAimOn.Checked;
        }

        private void numericUpDown_PelvisOffset_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.PelvisOffset = Convert.ToDouble(numericUpDown_PelvisOffset.Value);
        }

        private void numericUpDown_PitchOffset_ValueChanged_1(object sender, EventArgs e)
        {
            _trjectoryWalking.PitchOffset = Convert.ToDouble(numericUpDown_PitchOffset.Value);
        }

        private void numericUpDown_PitchZero0_ValueChanged(object sender, EventArgs e)
        {

            _controll.PitchZero = Convert.ToInt32(numericUpDown_PitchZero0.Value);
        }

        private void checkBox_IMU_Timer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IMU_Timer.Checked)
            {
                timer_IMU.Start();
            }
            else
            {
                timer_IMU.Stop();
            }
        }

        private void timer_IMU_Tick(object sender, EventArgs e)
        {
            numericUpDown_IMU_Pitch.Value = (decimal)_controll.ActualPitch;
            numericUpDown_IMU_Roll.Value = (decimal)_controll.ActualRoll;
            numericUpDown_IMU_Yaw.Value = (decimal)_controll.Compass;
            numericUpDown_PitchZeroOffset.Value = (decimal)_controll.PitchZeroOffset;
            numericUpDown_RollZeroOffset.Value = (decimal)_controll.RollZeroOffset;

            label_RobotState.Text = _controll.RobotState.ToString();
        }

        private void numericUpDown_IsFalling_ValueChanged(object sender, EventArgs e)
        {
            _controll.FallingBoundary = Convert.ToDouble(numericUpDown_IsFalling.Value);
        }

        private void numericUpDown_FallBack_ValueChanged(object sender, EventArgs e)
        {
            _controll.FallBackBoundary = Convert.ToDouble(numericUpDown_FallBack.Value);
        }

        private void numericUpDown_FallFront_ValueChanged(object sender, EventArgs e)
        {
            _controll.FallFrontBoundary = Convert.ToDouble(numericUpDown_FallFront.Value);
        }

        private void numericUpDown_FallSide_Right_ValueChanged(object sender, EventArgs e)
        {
            _controll.FallSideRightBoundary = Convert.ToDouble(numericUpDown_FallSide_Right.Value);
        }

        private void numericUpDown_FallSide_Left_ValueChanged(object sender, EventArgs e)
        {
            _controll.FallSideLeftBoundary = Convert.ToDouble(numericUpDown_FallSide_Left.Value);
        }

        private void numericUpDown_RollZero_ValueChanged(object sender, EventArgs e)
        {
            _controll.RollZero = Convert.ToInt32(numericUpDown_RollZero.Value);
        }

        private void numericUpDown_CompassOffset_ValueChanged(object sender, EventArgs e)
        {
            _controll.CompassOffset = Convert.ToInt32(numericUpDown_CompassOffset.Value);
        }

        private void numericUpDown_ArmSwingGain_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.ArmSwingGain = Convert.ToDouble(numericUpDown_ArmSwingGain.Value);
        }

        private void button_RefreshPorts_Click(object sender, EventArgs e)
        {
            EnumerateComPortsIMU();
        }

        private void Y_MOVE_AMPLITUDE_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.YMoveAmplitude = Convert.ToDouble(Y_MOVE_AMPLITUDE.Value);
        }

        private void Z_SWAP_AMPLITUDE_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.ZSwapAmplitude = Convert.ToDouble(Z_SWAP_AMPLITUDE.Value);
        }

        private void DOUBLESTANCERATIO_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.DoubleStancePeriodRatio = Convert.ToDouble(DOUBLESTANCERATIO.Value);
        }

        private void FORWARDBACKWARDRATIO_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.StepForwardBackwardRatio = Convert.ToDouble(FORWARDBACKWARDRATIO.Value);
        }


        private void numericUpDown_HandPitchGain_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.HandPitchGain = Convert.ToDouble(numericUpDown_HandPitchGain.Value);
        }

        private void checkBox_Stabilization_CheckedChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.StabilizationEnable = checkBox_Stabilization.Checked;
        }

        private Form _form;
        private void checkBox_IMUChart_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IMUChart.Checked)
            {
                var form = new AnalyzerForm(_body, _controll);
                form.Show();
            }
        }

        private void checkBox_WalkingchartEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_WalkingchartEnable.Checked)
            {
                using (var form = new AnalyzerForm(_body, _controll))
                {
                    form.Show();
                }
            }
        }

        private void numericUpDown_GyroP_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.PIDGyro.Kp = Convert.ToDouble(numericUpDown_GyroP.Value);
        }

        private void numericUpDown_GyroD_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.PIDGyro.Kd = Convert.ToDouble(numericUpDown_GyroD.Value);
        }

        private void button_PlayIsFallingMotion_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(IsFallingMotionIndex.Value);
            _motionManager.PlayMotion(index);
        }

        private void button_PlayIsFallFrontMotion_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(FallFrontMotionIndex.Value);
            _motionManager.PlayMotion(index);
        }

        private void button_PlayFallBackMotion_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(FallBackMotionIndex.Value);
            _motionManager.PlayMotion(index);
        }

        private void button_StartLocoMotionFSM_Click(object sender, EventArgs e)
        {
            _walkmanager.StartFSM();
        }

        private void button_StopLocoMotionFSM_Click(object sender, EventArgs e)
        {
            _walkmanager.StopFSM();
        }

        private void numericUpDown_FallFrontMotionIndex_ValueChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(FallFrontMotionIndex.Value);
            _walkmanager.FrontStandUpIndex = index;
        }

        private void numericUpDown_FallBackMotionIndex_ValueChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(FallBackMotionIndex.Value);
            _walkmanager.BackStandUpIndex = index;
        }

        private void numericUpDown_IsFallingMotionIndex_ValueChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(IsFallingMotionIndex.Value);
            _walkmanager.FallingMotionIndex = index;
        }

        private void numericUpDown_InsuranceCounter_ValueChanged(object sender, EventArgs e)
        {
            _controll.FallCounter = Convert.ToInt32(numericUpDown_InsuranceCounter.Value);
        }

        private void numericUpDown_ActuatorsSpeed_ValueChanged(object sender, EventArgs e)
        {
            _trjectoryWalking.ActuatorsSpeed = Convert.ToInt32(numericUpDown_ActuatorsSpeed.Value);
        }

        private void numericUpDown_HandLowPassGain_ValueChanged(object sender, EventArgs e)
        {
            _controll.HandLowpass.Gain = Convert.ToDouble(numericUpDown_HandLowPassGain.Value);
        }
        private void numericUpDown_AnkleLowPassGain_ValueChanged(object sender, EventArgs e)
        {
            _controll.GyroAnklePitchLowPass.Gain = Convert.ToDouble(numericUpDown_AnkleLowPassGain.Value);
        }


        private void checkBox_XSmooth_CheckedChanged(object sender, EventArgs e)
        {
            _walkmanager.XSmoothEnable = checkBox_XSmooth.Checked;
        }

        private void checkBox_YSmooth_CheckedChanged(object sender, EventArgs e)
        {
            _walkmanager.YSmoothEnable = checkBox_YSmooth.Checked;
        }

        private void checkBox_ZSmooth_CheckedChanged(object sender, EventArgs e)
        {
            _walkmanager.ZSmoothEnable = checkBox_ZSmooth.Checked;
        }

        private void checkBox_ASmooth_CheckedChanged(object sender, EventArgs e)
        {
            _walkmanager.ASmoothEnable = checkBox_ASmooth.Checked;
        }

        private void X_Target_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.X = (int)X_Target.Value;
        }

        private void Y_Target_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.Y = (int)Y_Target.Value;
        }

        private void Z_Target_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.Z = (int)Z_Target.Value;
        }

        private void A_Target_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.A = (int)A_Target.Value;
        }

        private void XMin_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.XRange.Min = (int)XMin.Value;
        }

        private void XMax_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.XRange.Max = (int)XMax.Value;
        }

        private void YMin_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.YRange.Min = (int)YMin.Value;
        }

        private void YMax_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.YRange.Max = (int)YMax.Value;
        }

        private void ZMin_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.ZRange.Min = (int)ZMin.Value;
        }

        private void ZMax_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.ZRange.Max = (int)ZMax.Value;
        }

        private void AMin_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.ARange.Min = (int)AMin.Value;
        }

        private void AMax_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.ARange.Max = (int)AMax.Value;
        }


        private void button_WalkManagerStart_Click(object sender, EventArgs e)
        {
            _walkmanager.Save("Config/WalkManager.xml");
        }

        private void button_WalkManagerStop_Click(object sender, EventArgs e)
        {
            _walkmanager.Load("Config/WalkManager.xml");
        }

        private void LoadWalkMnagerParametrs()
        {
            XMax.Value = _walkmanager.XRange.Max;
            XMin.Value = _walkmanager.XRange.Min;

            YMax.Value = _walkmanager.YRange.Max;
            YMin.Value = _walkmanager.YRange.Min;

            ZMax.Value = _walkmanager.ZRange.Max;
            ZMin.Value = _walkmanager.ZRange.Min;

            AMax.Value = _walkmanager.ARange.Max;
            AMin.Value = _walkmanager.ARange.Min;

            FallBackMotionIndex.Value = _walkmanager.BackStandUpIndex;
            FallFrontMotionIndex.Value = _walkmanager.FrontStandUpIndex;
            IsFallingMotionIndex.Value = _walkmanager.FallingMotionIndex;

            HappyIndex.Value = _walkmanager.HappyIndex;
            LeftKickIndex.Value = _walkmanager.LeftKickIndex;
            LeftKickLittleIndex.Value = _walkmanager.LeftKickLittleIndex;
            RightKick.Value = _walkmanager.RightKickIndex;
            RightKickLittle.Value = _walkmanager.RightKickLittleIndex;


            FSMInterval.Value = _walkmanager.FSMInterval;

            XInterval.Value = _walkmanager.XUpdateInterval;
            YInterval.Value = _walkmanager.YUpdateInterval;
            ZInterval.Value = _walkmanager.ZUpdateInterval;
            AInterval.Value = _walkmanager.AUpdateInterval;

            checkBox_XSmooth.Checked = _walkmanager.XSmoothEnable;
            checkBox_YSmooth.Checked = _walkmanager.YSmoothEnable;
            checkBox_ZSmooth.Checked = _walkmanager.ZSmoothEnable;
            checkBox_ASmooth.Checked = _walkmanager.ASmoothEnable;
        }

        private void FSMInterval_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.FSMInterval = (int)FSMInterval.Value;
        }

        private void XInterval_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.XUpdateInterval = (int)XInterval.Value;
        }

        private void YInterval_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.YUpdateInterval = (int)YInterval.Value;
        }

        private void ZInterval_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.ZUpdateInterval = (int)ZInterval.Value;
        }

        private void AInterval_ValueChanged(object sender, EventArgs e)
        {
            _walkmanager.AUpdateInterval = (int)AInterval.Value;
        }

        private Joystick _joystick;

        private void checkBox_JoyStick_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_JoyStick.Checked)
            {
                _joystick = new Joystick();
                timer_WalkMove.Start();
            }
            else
            {
                _joystick = null;
            }
        }

        private void timer_WalkMove_Tick(object sender, EventArgs e)
        {
            numericUpDown_X.Value = (int)_walkmanager.X;
            numericUpDown_Y.Value = (int)_walkmanager.Y;
            numericUpDown_Z.Value = (int)_walkmanager.Z;
            numericUpDown_A.Value = (int)_walkmanager.A;
            if (_joystick != null)
            {
                if (_joystick.Initialized)
                {
                    _joystick.UpdateState();
                }
                if (_walkmanager.IsRunning)
                {

                    if (_joystick.Left)
                    {
                        _walkmanager.Y = _walkmanager.YRange.Max;
                    }

                    else if (_joystick.Right)
                    {
                        _walkmanager.Y = _walkmanager.YRange.Min;
                    }
                    else
                    {
                        _walkmanager.Y = 0;
                    }

                    if (_joystick.Up)
                    {
                        _walkmanager.X = _walkmanager.XRange.Max;
                    }
                    else if (_joystick.Down)
                    {
                        _walkmanager.X = _walkmanager.XRange.Min;
                    }
                    else
                    {
                        _walkmanager.X = 0;
                    }

                    if (_joystick.L1)
                    {
                        _walkmanager.A = _walkmanager.ARange.Max;
                    }
                    else if (_joystick.R1)
                    {
                        _walkmanager.A = _walkmanager.ARange.Min;
                    }
                    else
                    {
                        _walkmanager.A = 0;
                    }

                    if (_joystick.L2)
                    {
                        _walkmanager.A = _walkmanager.ARange.Max;
                        _walkmanager.Y = _walkmanager.YRange.Max;
                    }
                    else if (_joystick.R2)
                    {
                        _walkmanager.A = _walkmanager.ARange.Min;
                        _walkmanager.Y = _walkmanager.YRange.Min;
                    }
                    else
                    {
                        if (!_joystick.R1 && !_joystick.L1)
                        {
                            _walkmanager.A = 0;
                        }
                        if (!_joystick.Left && !_joystick.Right)
                        {
                            _walkmanager.Y = 0;
                        }

                    }

                }

                else
                {
                    if (_joystick.Number1)
                    {
                        _walkmanager.PlayMotion(WalkManager.Motion.LeftKick);
                    }

                    if (_joystick.Number2)
                    {
                        _walkmanager.PlayMotion(WalkManager.Motion.LeftKickLittle);
                    }

                    if (_joystick.Number3)
                    {
                        _walkmanager.PlayMotion(WalkManager.Motion.RightKick);
                    }

                    if (_joystick.Number4)
                    {
                        _walkmanager.PlayMotion(WalkManager.Motion.RightKickLittle);
                    }
                }

                if (!_walkmanager.IsMotionPlaying)
                {
                    if (_joystick.StartButton)
                    {
                        _walkmanager.WalkStart();
                    }

                    if (_joystick.StopButton)
                    {
                        _walkmanager.WalkStop(false);
                    }
                }
            }
        }

        private void LeftKickIndex_ValueChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(LeftKickIndex.Value);
            _walkmanager.LeftKickIndex = index;
        }

        private void LeftKickLittleIndex_ValueChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(LeftKickLittleIndex.Value);
            _walkmanager.LeftKickLittleIndex = index;
        }

        private void HappyIndex_ValueChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(HappyIndex.Value);
            _walkmanager.HappyIndex = index;
        }

        private void RightKick_ValueChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(RightKick.Value);
            _walkmanager.RightKickIndex = index;
        }

        private void RightKickLittle_ValueChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(RightKickLittle.Value);
            _walkmanager.RightKickLittleIndex = index;
        }

        private void button_LeftKick_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(LeftKickIndex.Value);
            _motionManager.PlayMotion(index);
        }

        private void button_LeftKickLittle_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(LeftKickLittleIndex.Value);
            _motionManager.PlayMotion(index);
        }

        private void button_Happy_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(HappyIndex.Value);
            _motionManager.PlayMotion(index);
        }

        private void button_RightKick_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(RightKick.Value);
            _motionManager.PlayMotion(index);
        }

        private void button_RightKickLittle_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(RightKickLittle.Value);
            _motionManager.PlayMotion(index);
        }


    }
}