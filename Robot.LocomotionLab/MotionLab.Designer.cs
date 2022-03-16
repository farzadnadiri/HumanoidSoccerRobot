using System.ComponentModel;
using System.Windows.Forms;

namespace Robot.Locomotion
{
    partial class MotionLab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotionLab));
            this.groupBox_MotionPage = new System.Windows.Forms.GroupBox();
            this.button_StopMotion = new System.Windows.Forms.Button();
            this.button_PlayMotion = new System.Windows.Forms.Button();
            this.button_Pastepage = new System.Windows.Forms.Button();
            this.button_CopyPage = new System.Windows.Forms.Button();
            this.dataGridView_MotionPage = new System.Windows.Forms.DataGridView();
            this.PageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageNext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageExit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip_MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_PageParametrs = new System.Windows.Forms.GroupBox();
            this.textBox_RealPlayTime = new System.Windows.Forms.TextBox();
            this.numericUpDown_CtrlInertialForce = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_SpeedRate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_RepeatTime = new System.Windows.Forms.NumericUpDown();
            this.label_RealPlayTime = new System.Windows.Forms.Label();
            this.label_InertialForce = new System.Windows.Forms.Label();
            this.label_SpeedRate = new System.Windows.Forms.Label();
            this.label_RepeatTime = new System.Windows.Forms.Label();
            this.groupBox_Positions = new System.Windows.Forms.GroupBox();
            this.button_LoadLastPose = new System.Windows.Forms.Button();
            this.button_Ping = new System.Windows.Forms.Button();
            this.button_MirrorExchange = new System.Windows.Forms.Button();
            this.button_ReadMotor = new System.Windows.Forms.Button();
            this.button_TurnOffActuators = new System.Windows.Forms.Button();
            this.button_TurnOnActuators = new System.Windows.Forms.Button();
            this.button_PlayStep = new System.Windows.Forms.Button();
            this.dataGridView_PoseOfMotor = new System.Windows.Forms.DataGridView();
            this.JointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_PoseOfSteps = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabControl_MotionEditor = new System.Windows.Forms.TabControl();
            this.Tab_MotionEditor = new System.Windows.Forms.TabPage();
            this.groupBox_PageSettings = new System.Windows.Forms.GroupBox();
            this.dataGridView_Page_SlopMargin = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_Steps = new System.Windows.Forms.GroupBox();
            this.button_WalkOffset = new System.Windows.Forms.Button();
            this.button_SaveStep = new System.Windows.Forms.Button();
            this.button_LoadStep = new System.Windows.Forms.Button();
            this.button_StepPaste = new System.Windows.Forms.Button();
            this.button_StepCopy = new System.Windows.Forms.Button();
            this.button_SetStandStyle = new System.Windows.Forms.Button();
            this.button_StepDown = new System.Windows.Forms.Button();
            this.button_StepUp = new System.Windows.Forms.Button();
            this.button_RemoveStep = new System.Windows.Forms.Button();
            this.button_AddStep = new System.Windows.Forms.Button();
            this.dataGridView_Steps = new System.Windows.Forms.DataGridView();
            this.StepID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StepTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StepPause = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_TrajectoryWalkEngine = new System.Windows.Forms.TabPage();
            this.groupBox_LocomotionFSM = new System.Windows.Forms.GroupBox();
            this.checkBox_JoyStick = new System.Windows.Forms.CheckBox();
            this.label_AInterval = new System.Windows.Forms.Label();
            this.AInterval = new System.Windows.Forms.NumericUpDown();
            this.label_ZInterval = new System.Windows.Forms.Label();
            this.ZInterval = new System.Windows.Forms.NumericUpDown();
            this.label_YInterval = new System.Windows.Forms.Label();
            this.YInterval = new System.Windows.Forms.NumericUpDown();
            this.label_XInterval = new System.Windows.Forms.Label();
            this.XInterval = new System.Windows.Forms.NumericUpDown();
            this.label_FSMInterval = new System.Windows.Forms.Label();
            this.FSMInterval = new System.Windows.Forms.NumericUpDown();
            this.button_WalkManagerStop = new System.Windows.Forms.Button();
            this.button_WalkManagerStart = new System.Windows.Forms.Button();
            this.label_AMax = new System.Windows.Forms.Label();
            this.AMax = new System.Windows.Forms.NumericUpDown();
            this.label_AMin = new System.Windows.Forms.Label();
            this.AMin = new System.Windows.Forms.NumericUpDown();
            this.label_ZMax = new System.Windows.Forms.Label();
            this.ZMax = new System.Windows.Forms.NumericUpDown();
            this.label_ZMin = new System.Windows.Forms.Label();
            this.ZMin = new System.Windows.Forms.NumericUpDown();
            this.label_Ymax = new System.Windows.Forms.Label();
            this.YMax = new System.Windows.Forms.NumericUpDown();
            this.label_YMin = new System.Windows.Forms.Label();
            this.YMin = new System.Windows.Forms.NumericUpDown();
            this.label_XMax = new System.Windows.Forms.Label();
            this.XMax = new System.Windows.Forms.NumericUpDown();
            this.label_XMin = new System.Windows.Forms.Label();
            this.XMin = new System.Windows.Forms.NumericUpDown();
            this.label_A = new System.Windows.Forms.Label();
            this.numericUpDown_A = new System.Windows.Forms.NumericUpDown();
            this.checkBox_ASmooth = new System.Windows.Forms.CheckBox();
            this.label_ATarget = new System.Windows.Forms.Label();
            this.A_Target = new System.Windows.Forms.NumericUpDown();
            this.label_Z = new System.Windows.Forms.Label();
            this.numericUpDown_Z = new System.Windows.Forms.NumericUpDown();
            this.checkBox_ZSmooth = new System.Windows.Forms.CheckBox();
            this.label_ZTarget = new System.Windows.Forms.Label();
            this.Z_Target = new System.Windows.Forms.NumericUpDown();
            this.label_Y = new System.Windows.Forms.Label();
            this.numericUpDown_Y = new System.Windows.Forms.NumericUpDown();
            this.checkBox_YSmooth = new System.Windows.Forms.CheckBox();
            this.label_YTarget = new System.Windows.Forms.Label();
            this.Y_Target = new System.Windows.Forms.NumericUpDown();
            this.label_X = new System.Windows.Forms.Label();
            this.numericUpDown_X = new System.Windows.Forms.NumericUpDown();
            this.checkBox_XSmooth = new System.Windows.Forms.CheckBox();
            this.label_XTarget = new System.Windows.Forms.Label();
            this.X_Target = new System.Windows.Forms.NumericUpDown();
            this.button_StopLocoMotionFSM = new System.Windows.Forms.Button();
            this.groupBox_MotionIndexs = new System.Windows.Forms.GroupBox();
            this.button_PlayFallBackMotion = new System.Windows.Forms.Button();
            this.button_PlayIsFallFrontMotion = new System.Windows.Forms.Button();
            this.button_PlayIsFallingMotion = new System.Windows.Forms.Button();
            this.IsFallingMotionIndex = new System.Windows.Forms.NumericUpDown();
            this.label_FallBackMotionIndex = new System.Windows.Forms.Label();
            this.FallFrontMotionIndex = new System.Windows.Forms.NumericUpDown();
            this.label_FallFrontMotionIndex = new System.Windows.Forms.Label();
            this.FallBackMotionIndex = new System.Windows.Forms.NumericUpDown();
            this.label_IsFallingMotionIndex = new System.Windows.Forms.Label();
            this.button_StartLocoMotionFSM = new System.Windows.Forms.Button();
            this.groupBox_WalkingParameters = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_ActuatorsSpeed = new System.Windows.Forms.NumericUpDown();
            this.label_HandPitchAmplitude = new System.Windows.Forms.Label();
            this.numericUpDown_ArmSwingGain = new System.Windows.Forms.NumericUpDown();
            this.labelFBRatio = new System.Windows.Forms.Label();
            this.label_DS_Ratio = new System.Windows.Forms.Label();
            this.FORWARDBACKWARDRATIO = new System.Windows.Forms.NumericUpDown();
            this.checkBox_WalkingchartEnable = new System.Windows.Forms.CheckBox();
            this.DOUBLESTANCERATIO = new System.Windows.Forms.NumericUpDown();
            this.checkBox_AMoveAimOn = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_LoadWalkSettings = new System.Windows.Forms.Button();
            this.button_SaveWalkSettings = new System.Windows.Forms.Button();
            this.label_pelvisoffset = new System.Windows.Forms.Label();
            this.checkBox_Control = new System.Windows.Forms.CheckBox();
            this.numericUpDown_PitchOffset = new System.Windows.Forms.NumericUpDown();
            this.button_DarwinWalkStop = new System.Windows.Forms.Button();
            this.button_DarwinWalkStart = new System.Windows.Forms.Button();
            this.numericUpDown_PelvisOffset = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.Z_SWAP_AMPLITUDE = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TIME_UNIT = new System.Windows.Forms.NumericUpDown();
            this.Y_MOVE_AMPLITUDE = new System.Windows.Forms.NumericUpDown();
            this.TIME_PERIOD = new System.Windows.Forms.NumericUpDown();
            this.X_OFFSET = new System.Windows.Forms.NumericUpDown();
            this.Z_OFFSET = new System.Windows.Forms.NumericUpDown();
            this.Y_OFFSET = new System.Windows.Forms.NumericUpDown();
            this.A_OFFSET = new System.Windows.Forms.NumericUpDown();
            this.label_ZOffset = new System.Windows.Forms.Label();
            this.label_YOffset = new System.Windows.Forms.Label();
            this.label_XOffset = new System.Windows.Forms.Label();
            this.label_AOffset = new System.Windows.Forms.Label();
            this.groupBox_RobotState = new System.Windows.Forms.GroupBox();
            this.label_InsuranceCounter = new System.Windows.Forms.Label();
            this.numericUpDown_InsuranceCounter = new System.Windows.Forms.NumericUpDown();
            this.label_RobotState = new System.Windows.Forms.Label();
            this.label_RobotStateLAble = new System.Windows.Forms.Label();
            this.checkBox_IMUChart = new System.Windows.Forms.CheckBox();
            this.button_CloseIMU = new System.Windows.Forms.Button();
            this.button_OpenIMU = new System.Windows.Forms.Button();
            this.button_RefreshPorts = new System.Windows.Forms.Button();
            this.label_PortName = new System.Windows.Forms.Label();
            this.comboBox_PortName = new System.Windows.Forms.ComboBox();
            this.checkBox_IMU_Timer = new System.Windows.Forms.CheckBox();
            this.label_FallSide_Left = new System.Windows.Forms.Label();
            this.numericUpDown_FallSide_Right = new System.Windows.Forms.NumericUpDown();
            this.label_FallSide_Right = new System.Windows.Forms.Label();
            this.numericUpDown_FallSide_Left = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_RollZeroOffset = new System.Windows.Forms.NumericUpDown();
            this.groupBox_IMUData = new System.Windows.Forms.GroupBox();
            this.label_CompassOffset = new System.Windows.Forms.Label();
            this.numericUpDown_CompassOffset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_IMU_Pitch = new System.Windows.Forms.NumericUpDown();
            this.label_IMU_Yaw = new System.Windows.Forms.Label();
            this.numericUpDown_IMU_Roll = new System.Windows.Forms.NumericUpDown();
            this.label_IMU_Roll = new System.Windows.Forms.Label();
            this.numericUpDown_IMU_Yaw = new System.Windows.Forms.NumericUpDown();
            this.label_IMU_pitch = new System.Windows.Forms.Label();
            this.numericUpDown_IsFalling = new System.Windows.Forms.NumericUpDown();
            this.label_RollZeroOffset = new System.Windows.Forms.Label();
            this.label_FallBack = new System.Windows.Forms.Label();
            this.numericUpDown_RollZero = new System.Windows.Forms.NumericUpDown();
            this.label_RollZero = new System.Windows.Forms.Label();
            this.numericUpDown_FallFront = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_PitchZeroOffset = new System.Windows.Forms.NumericUpDown();
            this.label_FallFront = new System.Windows.Forms.Label();
            this.numericUpDown_FallBack = new System.Windows.Forms.NumericUpDown();
            this.labelPitchZeroOffset = new System.Windows.Forms.Label();
            this.label_IsFalling = new System.Windows.Forms.Label();
            this.label_PitchZero = new System.Windows.Forms.Label();
            this.numericUpDown_PitchZero0 = new System.Windows.Forms.NumericUpDown();
            this.groupBox_Stabilization = new System.Windows.Forms.GroupBox();
            this.numericUpDown_HandLowPassGain = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_GyroD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_GyroP = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_AnkleLowPassGain = new System.Windows.Forms.NumericUpDown();
            this.label_PitchOffsetGain = new System.Windows.Forms.Label();
            this.numericUpDown_HandPitchGain = new System.Windows.Forms.NumericUpDown();
            this.label_HandPitchGain = new System.Windows.Forms.Label();
            this.checkBox_Stabilization = new System.Windows.Forms.CheckBox();
            this.dataGridView_ActuatorsDirection = new System.Windows.Forms.DataGridView();
            this.DirectionJointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JointDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog_XmlInput = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_XmlOutput = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip_MainToolbar = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_New = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Open = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_Port = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox_Port = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Connect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Disonnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTip_MainForm = new System.Windows.Forms.ToolTip(this.components);
            this.timer_IMU = new System.Windows.Forms.Timer(this.components);
            this.timer_WalkMove = new System.Windows.Forms.Timer(this.components);
            this.button_LeftKickLittle = new System.Windows.Forms.Button();
            this.button_LeftKick = new System.Windows.Forms.Button();
            this.button_Happy = new System.Windows.Forms.Button();
            this.HappyIndex = new System.Windows.Forms.NumericUpDown();
            this.label_LeftKickLittle = new System.Windows.Forms.Label();
            this.LeftKickIndex = new System.Windows.Forms.NumericUpDown();
            this.label_LeftKick = new System.Windows.Forms.Label();
            this.LeftKickLittleIndex = new System.Windows.Forms.NumericUpDown();
            this.label_Happy = new System.Windows.Forms.Label();
            this.button_RightKickLittle = new System.Windows.Forms.Button();
            this.button_RightKick = new System.Windows.Forms.Button();
            this.label_RightKickLittle = new System.Windows.Forms.Label();
            this.RightKick = new System.Windows.Forms.NumericUpDown();
            this.label_RightKick = new System.Windows.Forms.Label();
            this.RightKickLittle = new System.Windows.Forms.NumericUpDown();
            this.groupBox_MotionPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MotionPage)).BeginInit();
            this.menuStrip_MainMenu.SuspendLayout();
            this.groupBox_PageParametrs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CtrlInertialForce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SpeedRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RepeatTime)).BeginInit();
            this.groupBox_Positions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PoseOfMotor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PoseOfSteps)).BeginInit();
            this.TabControl_MotionEditor.SuspendLayout();
            this.Tab_MotionEditor.SuspendLayout();
            this.groupBox_PageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Page_SlopMargin)).BeginInit();
            this.groupBox_Steps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Steps)).BeginInit();
            this.tabPage_TrajectoryWalkEngine.SuspendLayout();
            this.groupBox_LocomotionFSM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FSMInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_Target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_Target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_Target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_Target)).BeginInit();
            this.groupBox_MotionIndexs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IsFallingMotionIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FallFrontMotionIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FallBackMotionIndex)).BeginInit();
            this.groupBox_WalkingParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ActuatorsSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ArmSwingGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FORWARDBACKWARDRATIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOUBLESTANCERATIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PitchOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PelvisOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_SWAP_AMPLITUDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME_UNIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_MOVE_AMPLITUDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME_PERIOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_OFFSET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_OFFSET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_OFFSET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_OFFSET)).BeginInit();
            this.groupBox_RobotState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InsuranceCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FallSide_Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FallSide_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RollZeroOffset)).BeginInit();
            this.groupBox_IMUData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CompassOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IMU_Pitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IMU_Roll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IMU_Yaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IsFalling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RollZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FallFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PitchZeroOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FallBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PitchZero0)).BeginInit();
            this.groupBox_Stabilization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HandLowPassGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GyroD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GyroP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AnkleLowPassGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HandPitchGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ActuatorsDirection)).BeginInit();
            this.toolStrip_MainToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HappyIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftKickIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftKickLittleIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightKick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightKickLittle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_MotionPage
            // 
            this.groupBox_MotionPage.Controls.Add(this.button_StopMotion);
            this.groupBox_MotionPage.Controls.Add(this.button_PlayMotion);
            this.groupBox_MotionPage.Controls.Add(this.button_Pastepage);
            this.groupBox_MotionPage.Controls.Add(this.button_CopyPage);
            this.groupBox_MotionPage.Controls.Add(this.dataGridView_MotionPage);
            this.groupBox_MotionPage.Location = new System.Drawing.Point(6, 6);
            this.groupBox_MotionPage.Name = "groupBox_MotionPage";
            this.groupBox_MotionPage.Size = new System.Drawing.Size(205, 524);
            this.groupBox_MotionPage.TabIndex = 0;
            this.groupBox_MotionPage.TabStop = false;
            this.groupBox_MotionPage.Text = "Motion Pages";
            // 
            // button_StopMotion
            // 
            this.button_StopMotion.BackColor = System.Drawing.SystemColors.Control;
            this.button_StopMotion.BackgroundImage = global::Robot.Locomotion.Properties.Resources.button_stop1;
            this.button_StopMotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_StopMotion.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_StopMotion.Location = new System.Drawing.Point(151, 16);
            this.button_StopMotion.Name = "button_StopMotion";
            this.button_StopMotion.Size = new System.Drawing.Size(45, 45);
            this.button_StopMotion.TabIndex = 16;
            this.button_StopMotion.UseVisualStyleBackColor = true;
            this.button_StopMotion.Click += new System.EventHandler(this.button_StopMotion_Click);
            // 
            // button_PlayMotion
            // 
            this.button_PlayMotion.BackColor = System.Drawing.SystemColors.Control;
            this.button_PlayMotion.BackgroundImage = global::Robot.Locomotion.Properties.Resources.button_play;
            this.button_PlayMotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_PlayMotion.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_PlayMotion.Location = new System.Drawing.Point(104, 16);
            this.button_PlayMotion.Name = "button_PlayMotion";
            this.button_PlayMotion.Size = new System.Drawing.Size(45, 45);
            this.button_PlayMotion.TabIndex = 15;
            this.button_PlayMotion.UseVisualStyleBackColor = true;
            this.button_PlayMotion.Click += new System.EventHandler(this.button_PlayMotion_Click);
            // 
            // button_Pastepage
            // 
            this.button_Pastepage.BackColor = System.Drawing.SystemColors.Control;
            this.button_Pastepage.BackgroundImage = global::Robot.Locomotion.Properties.Resources._32x32_past;
            this.button_Pastepage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Pastepage.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_Pastepage.Location = new System.Drawing.Point(52, 16);
            this.button_Pastepage.Name = "button_Pastepage";
            this.button_Pastepage.Size = new System.Drawing.Size(45, 45);
            this.button_Pastepage.TabIndex = 14;
            this.button_Pastepage.UseVisualStyleBackColor = true;
            // 
            // button_CopyPage
            // 
            this.button_CopyPage.BackColor = System.Drawing.SystemColors.Control;
            this.button_CopyPage.BackgroundImage = global::Robot.Locomotion.Properties.Resources._32x32_copy;
            this.button_CopyPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_CopyPage.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_CopyPage.Location = new System.Drawing.Point(5, 16);
            this.button_CopyPage.Name = "button_CopyPage";
            this.button_CopyPage.Size = new System.Drawing.Size(45, 45);
            this.button_CopyPage.TabIndex = 13;
            this.button_CopyPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView_MotionPage
            // 
            this.dataGridView_MotionPage.AllowUserToAddRows = false;
            this.dataGridView_MotionPage.AllowUserToDeleteRows = false;
            this.dataGridView_MotionPage.AllowUserToResizeColumns = false;
            this.dataGridView_MotionPage.AllowUserToResizeRows = false;
            this.dataGridView_MotionPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MotionPage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PageID,
            this.PageName,
            this.PageNext,
            this.PageExit});
            this.dataGridView_MotionPage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_MotionPage.Location = new System.Drawing.Point(8, 67);
            this.dataGridView_MotionPage.MultiSelect = false;
            this.dataGridView_MotionPage.Name = "dataGridView_MotionPage";
            this.dataGridView_MotionPage.RowHeadersVisible = false;
            this.dataGridView_MotionPage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_MotionPage.Size = new System.Drawing.Size(188, 448);
            this.dataGridView_MotionPage.TabIndex = 0;
            this.dataGridView_MotionPage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMotionPageCellClick);
            this.dataGridView_MotionPage.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMotionPageCellEndEdit);
            this.dataGridView_MotionPage.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMotionPageRowLeave);
            // 
            // PageID
            // 
            this.PageID.HeaderText = "ID";
            this.PageID.Name = "PageID";
            this.PageID.ReadOnly = true;
            this.PageID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PageID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PageID.Width = 22;
            // 
            // PageName
            // 
            this.PageName.HeaderText = "Name";
            this.PageName.Name = "PageName";
            this.PageName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PageName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PageName.Width = 60;
            // 
            // PageNext
            // 
            this.PageNext.HeaderText = "Next";
            this.PageNext.Name = "PageNext";
            this.PageNext.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PageNext.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PageNext.Width = 40;
            // 
            // PageExit
            // 
            this.PageExit.HeaderText = "Exit";
            this.PageExit.Name = "PageExit";
            this.PageExit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PageExit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PageExit.Width = 40;
            // 
            // menuStrip_MainMenu
            // 
            this.menuStrip_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_MainMenu.Name = "menuStrip_MainMenu";
            this.menuStrip_MainMenu.Size = new System.Drawing.Size(1090, 24);
            this.menuStrip_MainMenu.TabIndex = 1;
            this.menuStrip_MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.saveAsToolStripMenuItem.Text = "Save As ...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // groupBox_PageParametrs
            // 
            this.groupBox_PageParametrs.Controls.Add(this.textBox_RealPlayTime);
            this.groupBox_PageParametrs.Controls.Add(this.numericUpDown_CtrlInertialForce);
            this.groupBox_PageParametrs.Controls.Add(this.numericUpDown_SpeedRate);
            this.groupBox_PageParametrs.Controls.Add(this.numericUpDown_RepeatTime);
            this.groupBox_PageParametrs.Controls.Add(this.label_RealPlayTime);
            this.groupBox_PageParametrs.Controls.Add(this.label_InertialForce);
            this.groupBox_PageParametrs.Controls.Add(this.label_SpeedRate);
            this.groupBox_PageParametrs.Controls.Add(this.label_RepeatTime);
            this.groupBox_PageParametrs.Location = new System.Drawing.Point(6, 298);
            this.groupBox_PageParametrs.Name = "groupBox_PageParametrs";
            this.groupBox_PageParametrs.Size = new System.Drawing.Size(213, 220);
            this.groupBox_PageParametrs.TabIndex = 3;
            this.groupBox_PageParametrs.TabStop = false;
            this.groupBox_PageParametrs.Text = "Page Parametrs";
            // 
            // textBox_RealPlayTime
            // 
            this.textBox_RealPlayTime.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_RealPlayTime.Location = new System.Drawing.Point(19, 140);
            this.textBox_RealPlayTime.Multiline = true;
            this.textBox_RealPlayTime.Name = "textBox_RealPlayTime";
            this.textBox_RealPlayTime.Size = new System.Drawing.Size(148, 71);
            this.textBox_RealPlayTime.TabIndex = 4;
            // 
            // numericUpDown_CtrlInertialForce
            // 
            this.numericUpDown_CtrlInertialForce.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.numericUpDown_CtrlInertialForce.Enabled = false;
            this.numericUpDown_CtrlInertialForce.Location = new System.Drawing.Point(106, 95);
            this.numericUpDown_CtrlInertialForce.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDown_CtrlInertialForce.Name = "numericUpDown_CtrlInertialForce";
            this.numericUpDown_CtrlInertialForce.ReadOnly = true;
            this.numericUpDown_CtrlInertialForce.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_CtrlInertialForce.TabIndex = 3;
            this.numericUpDown_CtrlInertialForce.ValueChanged += new System.EventHandler(this.NumericUpDownCtrlInertialForceValueChanged);
            // 
            // numericUpDown_SpeedRate
            // 
            this.numericUpDown_SpeedRate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.numericUpDown_SpeedRate.Enabled = false;
            this.numericUpDown_SpeedRate.Location = new System.Drawing.Point(106, 59);
            this.numericUpDown_SpeedRate.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_SpeedRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_SpeedRate.Name = "numericUpDown_SpeedRate";
            this.numericUpDown_SpeedRate.ReadOnly = true;
            this.numericUpDown_SpeedRate.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_SpeedRate.TabIndex = 3;
            this.numericUpDown_SpeedRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_SpeedRate.ValueChanged += new System.EventHandler(this.NumericUpDownSpeedRateValueChanged);
            // 
            // numericUpDown_RepeatTime
            // 
            this.numericUpDown_RepeatTime.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.numericUpDown_RepeatTime.Location = new System.Drawing.Point(106, 20);
            this.numericUpDown_RepeatTime.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_RepeatTime.Name = "numericUpDown_RepeatTime";
            this.numericUpDown_RepeatTime.ReadOnly = true;
            this.numericUpDown_RepeatTime.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_RepeatTime.TabIndex = 3;
            this.numericUpDown_RepeatTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_RepeatTime.ValueChanged += new System.EventHandler(this.NumericUpDownRepeatTimeValueChanged);
            // 
            // label_RealPlayTime
            // 
            this.label_RealPlayTime.AutoSize = true;
            this.label_RealPlayTime.Location = new System.Drawing.Point(16, 122);
            this.label_RealPlayTime.Name = "label_RealPlayTime";
            this.label_RealPlayTime.Size = new System.Drawing.Size(84, 13);
            this.label_RealPlayTime.TabIndex = 0;
            this.label_RealPlayTime.Text = "Real Play Time :";
            // 
            // label_InertialForce
            // 
            this.label_InertialForce.AutoSize = true;
            this.label_InertialForce.Location = new System.Drawing.Point(8, 97);
            this.label_InertialForce.Name = "label_InertialForce";
            this.label_InertialForce.Size = new System.Drawing.Size(92, 13);
            this.label_InertialForce.TabIndex = 0;
            this.label_InertialForce.Text = "Ctrl Inertial Force :";
            // 
            // label_SpeedRate
            // 
            this.label_SpeedRate.AutoSize = true;
            this.label_SpeedRate.Location = new System.Drawing.Point(30, 62);
            this.label_SpeedRate.Name = "label_SpeedRate";
            this.label_SpeedRate.Size = new System.Drawing.Size(70, 13);
            this.label_SpeedRate.TabIndex = 0;
            this.label_SpeedRate.Text = "Speed Rate :";
            // 
            // label_RepeatTime
            // 
            this.label_RepeatTime.AutoSize = true;
            this.label_RepeatTime.Location = new System.Drawing.Point(26, 22);
            this.label_RepeatTime.Name = "label_RepeatTime";
            this.label_RepeatTime.Size = new System.Drawing.Size(74, 13);
            this.label_RepeatTime.TabIndex = 0;
            this.label_RepeatTime.Text = "Repeat Time :";
            // 
            // groupBox_Positions
            // 
            this.groupBox_Positions.Controls.Add(this.button_LoadLastPose);
            this.groupBox_Positions.Controls.Add(this.button_Ping);
            this.groupBox_Positions.Controls.Add(this.button_MirrorExchange);
            this.groupBox_Positions.Controls.Add(this.button_ReadMotor);
            this.groupBox_Positions.Controls.Add(this.button_TurnOffActuators);
            this.groupBox_Positions.Controls.Add(this.button_TurnOnActuators);
            this.groupBox_Positions.Controls.Add(this.button_PlayStep);
            this.groupBox_Positions.Controls.Add(this.dataGridView_PoseOfMotor);
            this.groupBox_Positions.Controls.Add(this.dataGridView_PoseOfSteps);
            this.groupBox_Positions.Location = new System.Drawing.Point(657, 6);
            this.groupBox_Positions.Name = "groupBox_Positions";
            this.groupBox_Positions.Size = new System.Drawing.Size(405, 525);
            this.groupBox_Positions.TabIndex = 4;
            this.groupBox_Positions.TabStop = false;
            this.groupBox_Positions.Text = "Positions";
            // 
            // button_LoadLastPose
            // 
            this.button_LoadLastPose.Location = new System.Drawing.Point(268, 467);
            this.button_LoadLastPose.Name = "button_LoadLastPose";
            this.button_LoadLastPose.Size = new System.Drawing.Size(104, 23);
            this.button_LoadLastPose.TabIndex = 6;
            this.button_LoadLastPose.Text = "Load Last Posture";
            this.button_LoadLastPose.UseVisualStyleBackColor = true;
            this.button_LoadLastPose.Click += new System.EventHandler(this.button_LoadLastPose_Click);
            // 
            // button_Ping
            // 
            this.button_Ping.Location = new System.Drawing.Point(176, 20);
            this.button_Ping.Name = "button_Ping";
            this.button_Ping.Size = new System.Drawing.Size(51, 30);
            this.button_Ping.TabIndex = 5;
            this.button_Ping.Text = "Ping";
            this.button_Ping.UseVisualStyleBackColor = true;
            this.button_Ping.Click += new System.EventHandler(this.ButtonPingClick);
            // 
            // button_MirrorExchange
            // 
            this.button_MirrorExchange.Image = global::Robot.Locomotion.Properties.Resources.mirror;
            this.button_MirrorExchange.Location = new System.Drawing.Point(181, 160);
            this.button_MirrorExchange.Name = "button_MirrorExchange";
            this.button_MirrorExchange.Size = new System.Drawing.Size(39, 35);
            this.button_MirrorExchange.TabIndex = 2;
            this.toolTip_MainForm.SetToolTip(this.button_MirrorExchange, "Mirror ( Exchange )");
            this.button_MirrorExchange.UseVisualStyleBackColor = true;
            this.button_MirrorExchange.Click += new System.EventHandler(this.ButtonMirrorExchangeClick);
            // 
            // button_ReadMotor
            // 
            this.button_ReadMotor.Image = global::Robot.Locomotion.Properties.Resources.previous;
            this.button_ReadMotor.Location = new System.Drawing.Point(175, 211);
            this.button_ReadMotor.Name = "button_ReadMotor";
            this.button_ReadMotor.Size = new System.Drawing.Size(52, 51);
            this.button_ReadMotor.TabIndex = 1;
            this.button_ReadMotor.UseVisualStyleBackColor = true;
            this.button_ReadMotor.Click += new System.EventHandler(this.ButtonReadMotorClick);
            // 
            // button_TurnOffActuators
            // 
            this.button_TurnOffActuators.Image = global::Robot.Locomotion.Properties.Resources.light;
            this.button_TurnOffActuators.Location = new System.Drawing.Point(176, 368);
            this.button_TurnOffActuators.Name = "button_TurnOffActuators";
            this.button_TurnOffActuators.Size = new System.Drawing.Size(52, 51);
            this.button_TurnOffActuators.TabIndex = 1;
            this.toolTip_MainForm.SetToolTip(this.button_TurnOffActuators, "Turn Off Selected Actuators ");
            this.button_TurnOffActuators.UseVisualStyleBackColor = true;
            this.button_TurnOffActuators.Click += new System.EventHandler(this.ButtonTurnOffActuatorsClick);
            // 
            // button_TurnOnActuators
            // 
            this.button_TurnOnActuators.Image = global::Robot.Locomotion.Properties.Resources.dialog_information;
            this.button_TurnOnActuators.Location = new System.Drawing.Point(176, 313);
            this.button_TurnOnActuators.Name = "button_TurnOnActuators";
            this.button_TurnOnActuators.Size = new System.Drawing.Size(52, 51);
            this.button_TurnOnActuators.TabIndex = 1;
            this.toolTip_MainForm.SetToolTip(this.button_TurnOnActuators, "Turn On Selected Actuators ");
            this.button_TurnOnActuators.UseVisualStyleBackColor = true;
            this.button_TurnOnActuators.Click += new System.EventHandler(this.ButtonTurnOnActuatorsClick);
            // 
            // button_PlayStep
            // 
            this.button_PlayStep.Image = global::Robot.Locomotion.Properties.Resources.next;
            this.button_PlayStep.Location = new System.Drawing.Point(175, 95);
            this.button_PlayStep.Name = "button_PlayStep";
            this.button_PlayStep.Size = new System.Drawing.Size(52, 51);
            this.button_PlayStep.TabIndex = 1;
            this.button_PlayStep.UseVisualStyleBackColor = true;
            this.button_PlayStep.Click += new System.EventHandler(this.ButtonPlayStepClick);
            // 
            // dataGridView_PoseOfMotor
            // 
            this.dataGridView_PoseOfMotor.AllowUserToAddRows = false;
            this.dataGridView_PoseOfMotor.AllowUserToDeleteRows = false;
            this.dataGridView_PoseOfMotor.AllowUserToResizeColumns = false;
            this.dataGridView_PoseOfMotor.AllowUserToResizeRows = false;
            this.dataGridView_PoseOfMotor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PoseOfMotor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JointName,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView_PoseOfMotor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_PoseOfMotor.Location = new System.Drawing.Point(231, 16);
            this.dataGridView_PoseOfMotor.Name = "dataGridView_PoseOfMotor";
            this.dataGridView_PoseOfMotor.RowHeadersVisible = false;
            this.dataGridView_PoseOfMotor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_PoseOfMotor.Size = new System.Drawing.Size(167, 445);
            this.dataGridView_PoseOfMotor.TabIndex = 0;
            this.dataGridView_PoseOfMotor.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPoseOfMotorCellEndEdit);
            this.dataGridView_PoseOfMotor.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPoseOfMotorCellEnter);
            // 
            // JointName
            // 
            this.JointName.Frozen = true;
            this.JointName.HeaderText = "Joint Name";
            this.JointName.Name = "JointName";
            this.JointName.ReadOnly = true;
            this.JointName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 55;
            // 
            // dataGridView_PoseOfSteps
            // 
            this.dataGridView_PoseOfSteps.AllowUserToAddRows = false;
            this.dataGridView_PoseOfSteps.AllowUserToDeleteRows = false;
            this.dataGridView_PoseOfSteps.AllowUserToResizeColumns = false;
            this.dataGridView_PoseOfSteps.AllowUserToResizeRows = false;
            this.dataGridView_PoseOfSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_PoseOfSteps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Value});
            this.dataGridView_PoseOfSteps.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_PoseOfSteps.Location = new System.Drawing.Point(4, 16);
            this.dataGridView_PoseOfSteps.Name = "dataGridView_PoseOfSteps";
            this.dataGridView_PoseOfSteps.RowHeadersVisible = false;
            this.dataGridView_PoseOfSteps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_PoseOfSteps.Size = new System.Drawing.Size(167, 445);
            this.dataGridView_PoseOfSteps.TabIndex = 0;
            this.dataGridView_PoseOfSteps.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPoseOfStepsCellEndEdit);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Joint Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.MaxInputLength = 1023;
            this.Value.Name = "Value";
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Value.Width = 55;
            // 
            // TabControl_MotionEditor
            // 
            this.TabControl_MotionEditor.Controls.Add(this.Tab_MotionEditor);
            this.TabControl_MotionEditor.Controls.Add(this.tabPage_TrajectoryWalkEngine);
            this.TabControl_MotionEditor.Location = new System.Drawing.Point(12, 52);
            this.TabControl_MotionEditor.Name = "TabControl_MotionEditor";
            this.TabControl_MotionEditor.SelectedIndex = 0;
            this.TabControl_MotionEditor.Size = new System.Drawing.Size(1078, 563);
            this.TabControl_MotionEditor.TabIndex = 10;
            // 
            // Tab_MotionEditor
            // 
            this.Tab_MotionEditor.Controls.Add(this.groupBox_PageSettings);
            this.Tab_MotionEditor.Controls.Add(this.groupBox_MotionPage);
            this.Tab_MotionEditor.Controls.Add(this.groupBox_Positions);
            this.Tab_MotionEditor.Location = new System.Drawing.Point(4, 22);
            this.Tab_MotionEditor.Name = "Tab_MotionEditor";
            this.Tab_MotionEditor.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_MotionEditor.Size = new System.Drawing.Size(1070, 537);
            this.Tab_MotionEditor.TabIndex = 0;
            this.Tab_MotionEditor.Text = "Motion Editor";
            this.Tab_MotionEditor.UseVisualStyleBackColor = true;
            // 
            // groupBox_PageSettings
            // 
            this.groupBox_PageSettings.Controls.Add(this.dataGridView_Page_SlopMargin);
            this.groupBox_PageSettings.Controls.Add(this.groupBox_Steps);
            this.groupBox_PageSettings.Controls.Add(this.groupBox_PageParametrs);
            this.groupBox_PageSettings.Location = new System.Drawing.Point(215, 6);
            this.groupBox_PageSettings.Name = "groupBox_PageSettings";
            this.groupBox_PageSettings.Size = new System.Drawing.Size(437, 524);
            this.groupBox_PageSettings.TabIndex = 5;
            this.groupBox_PageSettings.TabStop = false;
            this.groupBox_PageSettings.Text = "Page Setting";
            // 
            // dataGridView_Page_SlopMargin
            // 
            this.dataGridView_Page_SlopMargin.AllowUserToAddRows = false;
            this.dataGridView_Page_SlopMargin.AllowUserToDeleteRows = false;
            this.dataGridView_Page_SlopMargin.AllowUserToResizeColumns = false;
            this.dataGridView_Page_SlopMargin.AllowUserToResizeRows = false;
            this.dataGridView_Page_SlopMargin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Page_SlopMargin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.Column2});
            this.dataGridView_Page_SlopMargin.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_Page_SlopMargin.Location = new System.Drawing.Point(225, 17);
            this.dataGridView_Page_SlopMargin.Name = "dataGridView_Page_SlopMargin";
            this.dataGridView_Page_SlopMargin.RowHeadersVisible = false;
            this.dataGridView_Page_SlopMargin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Page_SlopMargin.Size = new System.Drawing.Size(205, 445);
            this.dataGridView_Page_SlopMargin.TabIndex = 4;
            this.dataGridView_Page_SlopMargin.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPageSlopMarginCellEndEdit);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Joint Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Slop";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 128;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 45;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Margin";
            this.Column2.MaxInputLength = 256;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 55;
            // 
            // groupBox_Steps
            // 
            this.groupBox_Steps.Controls.Add(this.button_WalkOffset);
            this.groupBox_Steps.Controls.Add(this.button_SaveStep);
            this.groupBox_Steps.Controls.Add(this.button_LoadStep);
            this.groupBox_Steps.Controls.Add(this.button_StepPaste);
            this.groupBox_Steps.Controls.Add(this.button_StepCopy);
            this.groupBox_Steps.Controls.Add(this.button_SetStandStyle);
            this.groupBox_Steps.Controls.Add(this.button_StepDown);
            this.groupBox_Steps.Controls.Add(this.button_StepUp);
            this.groupBox_Steps.Controls.Add(this.button_RemoveStep);
            this.groupBox_Steps.Controls.Add(this.button_AddStep);
            this.groupBox_Steps.Controls.Add(this.dataGridView_Steps);
            this.groupBox_Steps.Location = new System.Drawing.Point(6, 12);
            this.groupBox_Steps.Name = "groupBox_Steps";
            this.groupBox_Steps.Size = new System.Drawing.Size(213, 285);
            this.groupBox_Steps.TabIndex = 3;
            this.groupBox_Steps.TabStop = false;
            this.groupBox_Steps.Text = "Steps";
            // 
            // button_WalkOffset
            // 
            this.button_WalkOffset.Location = new System.Drawing.Point(95, 247);
            this.button_WalkOffset.Name = "button_WalkOffset";
            this.button_WalkOffset.Size = new System.Drawing.Size(25, 23);
            this.button_WalkOffset.TabIndex = 11;
            this.button_WalkOffset.Text = "W";
            this.button_WalkOffset.UseVisualStyleBackColor = true;
            this.button_WalkOffset.Click += new System.EventHandler(this.button_WalkOffset_Click);
            // 
            // button_SaveStep
            // 
            this.button_SaveStep.BackColor = System.Drawing.SystemColors.Control;
            this.button_SaveStep.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_SaveStep.Image = global::Robot.Locomotion.Properties.Resources._32x32_save;
            this.button_SaveStep.Location = new System.Drawing.Point(170, 238);
            this.button_SaveStep.Name = "button_SaveStep";
            this.button_SaveStep.Size = new System.Drawing.Size(40, 40);
            this.button_SaveStep.TabIndex = 10;
            this.toolTip_MainForm.SetToolTip(this.button_SaveStep, "Save Step");
            this.button_SaveStep.UseVisualStyleBackColor = false;
            this.button_SaveStep.Click += new System.EventHandler(this.ButtonSaveStepClick);
            // 
            // button_LoadStep
            // 
            this.button_LoadStep.BackColor = System.Drawing.SystemColors.Control;
            this.button_LoadStep.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_LoadStep.Image = global::Robot.Locomotion.Properties.Resources._32x32_save_as;
            this.button_LoadStep.Location = new System.Drawing.Point(127, 238);
            this.button_LoadStep.Name = "button_LoadStep";
            this.button_LoadStep.Size = new System.Drawing.Size(40, 40);
            this.button_LoadStep.TabIndex = 9;
            this.toolTip_MainForm.SetToolTip(this.button_LoadStep, "Load Step");
            this.button_LoadStep.UseVisualStyleBackColor = false;
            this.button_LoadStep.Click += new System.EventHandler(this.ButtonLoadStepClick);
            // 
            // button_StepPaste
            // 
            this.button_StepPaste.BackColor = System.Drawing.SystemColors.Control;
            this.button_StepPaste.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_StepPaste.Image = global::Robot.Locomotion.Properties.Resources._32x32_past;
            this.button_StepPaste.Location = new System.Drawing.Point(49, 238);
            this.button_StepPaste.Name = "button_StepPaste";
            this.button_StepPaste.Size = new System.Drawing.Size(40, 40);
            this.button_StepPaste.TabIndex = 8;
            this.toolTip_MainForm.SetToolTip(this.button_StepPaste, "Paste Step");
            this.button_StepPaste.UseVisualStyleBackColor = false;
            this.button_StepPaste.Click += new System.EventHandler(this.ButtonStepPasteClick);
            // 
            // button_StepCopy
            // 
            this.button_StepCopy.BackColor = System.Drawing.SystemColors.Control;
            this.button_StepCopy.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_StepCopy.Image = global::Robot.Locomotion.Properties.Resources._32x32_copy;
            this.button_StepCopy.Location = new System.Drawing.Point(6, 238);
            this.button_StepCopy.Name = "button_StepCopy";
            this.button_StepCopy.Size = new System.Drawing.Size(40, 40);
            this.button_StepCopy.TabIndex = 7;
            this.toolTip_MainForm.SetToolTip(this.button_StepCopy, "Copy Step");
            this.button_StepCopy.UseVisualStyleBackColor = false;
            this.button_StepCopy.Click += new System.EventHandler(this.ButtonStepCopyClick);
            // 
            // button_SetStandStyle
            // 
            this.button_SetStandStyle.BackColor = System.Drawing.SystemColors.Control;
            this.button_SetStandStyle.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_SetStandStyle.Image = global::Robot.Locomotion.Properties.Resources.standstill2;
            this.button_SetStandStyle.Location = new System.Drawing.Point(170, 170);
            this.button_SetStandStyle.Name = "button_SetStandStyle";
            this.button_SetStandStyle.Size = new System.Drawing.Size(40, 62);
            this.button_SetStandStyle.TabIndex = 6;
            this.toolTip_MainForm.SetToolTip(this.button_SetStandStyle, "Set Current Step as StandStyle");
            this.button_SetStandStyle.UseVisualStyleBackColor = false;
            this.button_SetStandStyle.Click += new System.EventHandler(this.ButtonSetStandStyleClick);
            // 
            // button_StepDown
            // 
            this.button_StepDown.BackColor = System.Drawing.SystemColors.Control;
            this.button_StepDown.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_StepDown.Image = global::Robot.Locomotion.Properties.Resources.Down_Arrow_Icon;
            this.button_StepDown.Location = new System.Drawing.Point(170, 129);
            this.button_StepDown.Name = "button_StepDown";
            this.button_StepDown.Size = new System.Drawing.Size(40, 35);
            this.button_StepDown.TabIndex = 5;
            this.toolTip_MainForm.SetToolTip(this.button_StepDown, "Move Down Step");
            this.button_StepDown.UseVisualStyleBackColor = false;
            this.button_StepDown.Click += new System.EventHandler(this.ButtonStepDownClick);
            // 
            // button_StepUp
            // 
            this.button_StepUp.BackColor = System.Drawing.SystemColors.Control;
            this.button_StepUp.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_StepUp.Image = global::Robot.Locomotion.Properties.Resources.Up_Arrow_Icon;
            this.button_StepUp.Location = new System.Drawing.Point(170, 91);
            this.button_StepUp.Name = "button_StepUp";
            this.button_StepUp.Size = new System.Drawing.Size(40, 35);
            this.button_StepUp.TabIndex = 4;
            this.toolTip_MainForm.SetToolTip(this.button_StepUp, "Move Up Step");
            this.button_StepUp.UseVisualStyleBackColor = false;
            this.button_StepUp.Click += new System.EventHandler(this.ButtonStepUpClick);
            // 
            // button_RemoveStep
            // 
            this.button_RemoveStep.ForeColor = System.Drawing.Color.Red;
            this.button_RemoveStep.Image = global::Robot.Locomotion.Properties.Resources.delete_1_;
            this.button_RemoveStep.Location = new System.Drawing.Point(170, 55);
            this.button_RemoveStep.Name = "button_RemoveStep";
            this.button_RemoveStep.Size = new System.Drawing.Size(40, 33);
            this.button_RemoveStep.TabIndex = 1;
            this.toolTip_MainForm.SetToolTip(this.button_RemoveStep, "Remove Step");
            this.button_RemoveStep.UseVisualStyleBackColor = true;
            this.button_RemoveStep.Click += new System.EventHandler(this.ButtonRemoveStepClick);
            // 
            // button_AddStep
            // 
            this.button_AddStep.ForeColor = System.Drawing.Color.ForestGreen;
            this.button_AddStep.Image = global::Robot.Locomotion.Properties.Resources.plus;
            this.button_AddStep.Location = new System.Drawing.Point(170, 18);
            this.button_AddStep.Name = "button_AddStep";
            this.button_AddStep.Size = new System.Drawing.Size(40, 35);
            this.button_AddStep.TabIndex = 1;
            this.toolTip_MainForm.SetToolTip(this.button_AddStep, "Add Step");
            this.button_AddStep.UseVisualStyleBackColor = true;
            this.button_AddStep.Click += new System.EventHandler(this.ButtonAddStepClick);
            // 
            // dataGridView_Steps
            // 
            this.dataGridView_Steps.AllowUserToAddRows = false;
            this.dataGridView_Steps.AllowUserToDeleteRows = false;
            this.dataGridView_Steps.AllowUserToResizeColumns = false;
            this.dataGridView_Steps.AllowUserToResizeRows = false;
            this.dataGridView_Steps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Steps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StepID,
            this.StepTime,
            this.StepPause});
            this.dataGridView_Steps.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_Steps.Location = new System.Drawing.Point(6, 16);
            this.dataGridView_Steps.MultiSelect = false;
            this.dataGridView_Steps.Name = "dataGridView_Steps";
            this.dataGridView_Steps.RowHeadersVisible = false;
            this.dataGridView_Steps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Steps.Size = new System.Drawing.Size(161, 216);
            this.dataGridView_Steps.TabIndex = 0;
            this.dataGridView_Steps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewStepsCellClick);
            this.dataGridView_Steps.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewStepsCellEndEdit);
            // 
            // StepID
            // 
            this.StepID.HeaderText = "ID";
            this.StepID.Name = "StepID";
            this.StepID.ReadOnly = true;
            this.StepID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StepID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StepID.Width = 25;
            // 
            // StepTime
            // 
            this.StepTime.HeaderText = "Time";
            this.StepTime.MaxInputLength = 4;
            this.StepTime.Name = "StepTime";
            this.StepTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StepTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StepTime.Width = 65;
            // 
            // StepPause
            // 
            this.StepPause.HeaderText = "Pause";
            this.StepPause.MaxInputLength = 4;
            this.StepPause.Name = "StepPause";
            this.StepPause.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StepPause.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StepPause.Width = 65;
            // 
            // tabPage_TrajectoryWalkEngine
            // 
            this.tabPage_TrajectoryWalkEngine.Controls.Add(this.groupBox_LocomotionFSM);
            this.tabPage_TrajectoryWalkEngine.Controls.Add(this.groupBox_WalkingParameters);
            this.tabPage_TrajectoryWalkEngine.Controls.Add(this.groupBox_RobotState);
            this.tabPage_TrajectoryWalkEngine.Controls.Add(this.groupBox_Stabilization);
            this.tabPage_TrajectoryWalkEngine.Controls.Add(this.dataGridView_ActuatorsDirection);
            this.tabPage_TrajectoryWalkEngine.Location = new System.Drawing.Point(4, 22);
            this.tabPage_TrajectoryWalkEngine.Name = "tabPage_TrajectoryWalkEngine";
            this.tabPage_TrajectoryWalkEngine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_TrajectoryWalkEngine.Size = new System.Drawing.Size(1070, 537);
            this.tabPage_TrajectoryWalkEngine.TabIndex = 4;
            this.tabPage_TrajectoryWalkEngine.Text = "Trajectory Walking";
            this.tabPage_TrajectoryWalkEngine.UseVisualStyleBackColor = true;
            // 
            // groupBox_LocomotionFSM
            // 
            this.groupBox_LocomotionFSM.Controls.Add(this.checkBox_JoyStick);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_AInterval);
            this.groupBox_LocomotionFSM.Controls.Add(this.AInterval);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_ZInterval);
            this.groupBox_LocomotionFSM.Controls.Add(this.ZInterval);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_YInterval);
            this.groupBox_LocomotionFSM.Controls.Add(this.YInterval);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_XInterval);
            this.groupBox_LocomotionFSM.Controls.Add(this.XInterval);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_FSMInterval);
            this.groupBox_LocomotionFSM.Controls.Add(this.FSMInterval);
            this.groupBox_LocomotionFSM.Controls.Add(this.button_WalkManagerStop);
            this.groupBox_LocomotionFSM.Controls.Add(this.button_WalkManagerStart);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_AMax);
            this.groupBox_LocomotionFSM.Controls.Add(this.AMax);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_AMin);
            this.groupBox_LocomotionFSM.Controls.Add(this.AMin);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_ZMax);
            this.groupBox_LocomotionFSM.Controls.Add(this.ZMax);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_ZMin);
            this.groupBox_LocomotionFSM.Controls.Add(this.ZMin);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_Ymax);
            this.groupBox_LocomotionFSM.Controls.Add(this.YMax);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_YMin);
            this.groupBox_LocomotionFSM.Controls.Add(this.YMin);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_XMax);
            this.groupBox_LocomotionFSM.Controls.Add(this.XMax);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_XMin);
            this.groupBox_LocomotionFSM.Controls.Add(this.XMin);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_A);
            this.groupBox_LocomotionFSM.Controls.Add(this.numericUpDown_A);
            this.groupBox_LocomotionFSM.Controls.Add(this.checkBox_ASmooth);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_ATarget);
            this.groupBox_LocomotionFSM.Controls.Add(this.A_Target);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_Z);
            this.groupBox_LocomotionFSM.Controls.Add(this.numericUpDown_Z);
            this.groupBox_LocomotionFSM.Controls.Add(this.checkBox_ZSmooth);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_ZTarget);
            this.groupBox_LocomotionFSM.Controls.Add(this.Z_Target);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_Y);
            this.groupBox_LocomotionFSM.Controls.Add(this.numericUpDown_Y);
            this.groupBox_LocomotionFSM.Controls.Add(this.checkBox_YSmooth);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_YTarget);
            this.groupBox_LocomotionFSM.Controls.Add(this.Y_Target);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_X);
            this.groupBox_LocomotionFSM.Controls.Add(this.numericUpDown_X);
            this.groupBox_LocomotionFSM.Controls.Add(this.checkBox_XSmooth);
            this.groupBox_LocomotionFSM.Controls.Add(this.label_XTarget);
            this.groupBox_LocomotionFSM.Controls.Add(this.X_Target);
            this.groupBox_LocomotionFSM.Controls.Add(this.button_StopLocoMotionFSM);
            this.groupBox_LocomotionFSM.Controls.Add(this.groupBox_MotionIndexs);
            this.groupBox_LocomotionFSM.Controls.Add(this.button_StartLocoMotionFSM);
            this.groupBox_LocomotionFSM.Location = new System.Drawing.Point(8, 305);
            this.groupBox_LocomotionFSM.Name = "groupBox_LocomotionFSM";
            this.groupBox_LocomotionFSM.Size = new System.Drawing.Size(632, 226);
            this.groupBox_LocomotionFSM.TabIndex = 148;
            this.groupBox_LocomotionFSM.TabStop = false;
            this.groupBox_LocomotionFSM.Text = "  Walk Manager  ";
            // 
            // checkBox_JoyStick
            // 
            this.checkBox_JoyStick.AutoSize = true;
            this.checkBox_JoyStick.Location = new System.Drawing.Point(547, 140);
            this.checkBox_JoyStick.Name = "checkBox_JoyStick";
            this.checkBox_JoyStick.Size = new System.Drawing.Size(66, 17);
            this.checkBox_JoyStick.TabIndex = 227;
            this.checkBox_JoyStick.Text = "JoyStick";
            this.checkBox_JoyStick.UseVisualStyleBackColor = true;
            this.checkBox_JoyStick.CheckedChanged += new System.EventHandler(this.checkBox_JoyStick_CheckedChanged);
            // 
            // label_AInterval
            // 
            this.label_AInterval.AutoSize = true;
            this.label_AInterval.Location = new System.Drawing.Point(497, 97);
            this.label_AInterval.Name = "label_AInterval";
            this.label_AInterval.Size = new System.Drawing.Size(49, 13);
            this.label_AInterval.TabIndex = 226;
            this.label_AInterval.Text = "AInterval";
            // 
            // AInterval
            // 
            this.AInterval.Location = new System.Drawing.Point(549, 94);
            this.AInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AInterval.Name = "AInterval";
            this.AInterval.Size = new System.Drawing.Size(50, 20);
            this.AInterval.TabIndex = 225;
            this.AInterval.ValueChanged += new System.EventHandler(this.AInterval_ValueChanged);
            // 
            // label_ZInterval
            // 
            this.label_ZInterval.AutoSize = true;
            this.label_ZInterval.Location = new System.Drawing.Point(497, 70);
            this.label_ZInterval.Name = "label_ZInterval";
            this.label_ZInterval.Size = new System.Drawing.Size(49, 13);
            this.label_ZInterval.TabIndex = 224;
            this.label_ZInterval.Text = "ZInterval";
            // 
            // ZInterval
            // 
            this.ZInterval.Location = new System.Drawing.Point(549, 67);
            this.ZInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ZInterval.Name = "ZInterval";
            this.ZInterval.Size = new System.Drawing.Size(50, 20);
            this.ZInterval.TabIndex = 223;
            this.ZInterval.ValueChanged += new System.EventHandler(this.ZInterval_ValueChanged);
            // 
            // label_YInterval
            // 
            this.label_YInterval.AutoSize = true;
            this.label_YInterval.Location = new System.Drawing.Point(497, 44);
            this.label_YInterval.Name = "label_YInterval";
            this.label_YInterval.Size = new System.Drawing.Size(49, 13);
            this.label_YInterval.TabIndex = 222;
            this.label_YInterval.Text = "YInterval";
            // 
            // YInterval
            // 
            this.YInterval.Location = new System.Drawing.Point(549, 41);
            this.YInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YInterval.Name = "YInterval";
            this.YInterval.Size = new System.Drawing.Size(50, 20);
            this.YInterval.TabIndex = 221;
            this.YInterval.ValueChanged += new System.EventHandler(this.YInterval_ValueChanged);
            // 
            // label_XInterval
            // 
            this.label_XInterval.AutoSize = true;
            this.label_XInterval.Location = new System.Drawing.Point(497, 19);
            this.label_XInterval.Name = "label_XInterval";
            this.label_XInterval.Size = new System.Drawing.Size(49, 13);
            this.label_XInterval.TabIndex = 220;
            this.label_XInterval.Text = "XInterval";
            // 
            // XInterval
            // 
            this.XInterval.Location = new System.Drawing.Point(549, 16);
            this.XInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XInterval.Name = "XInterval";
            this.XInterval.Size = new System.Drawing.Size(50, 20);
            this.XInterval.TabIndex = 219;
            this.XInterval.ValueChanged += new System.EventHandler(this.XInterval_ValueChanged);
            // 
            // label_FSMInterval
            // 
            this.label_FSMInterval.AutoSize = true;
            this.label_FSMInterval.Location = new System.Drawing.Point(540, 177);
            this.label_FSMInterval.Name = "label_FSMInterval";
            this.label_FSMInterval.Size = new System.Drawing.Size(67, 13);
            this.label_FSMInterval.TabIndex = 218;
            this.label_FSMInterval.Text = "FSM Interval";
            // 
            // FSMInterval
            // 
            this.FSMInterval.Location = new System.Drawing.Point(559, 194);
            this.FSMInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.FSMInterval.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.FSMInterval.Name = "FSMInterval";
            this.FSMInterval.Size = new System.Drawing.Size(50, 20);
            this.FSMInterval.TabIndex = 217;
            this.FSMInterval.ValueChanged += new System.EventHandler(this.FSMInterval_ValueChanged);
            // 
            // button_WalkManagerStop
            // 
            this.button_WalkManagerStop.Location = new System.Drawing.Point(477, 170);
            this.button_WalkManagerStop.Name = "button_WalkManagerStop";
            this.button_WalkManagerStop.Size = new System.Drawing.Size(48, 23);
            this.button_WalkManagerStop.TabIndex = 214;
            this.button_WalkManagerStop.Text = "Load";
            this.button_WalkManagerStop.UseVisualStyleBackColor = true;
            this.button_WalkManagerStop.Click += new System.EventHandler(this.button_WalkManagerStop_Click);
            // 
            // button_WalkManagerStart
            // 
            this.button_WalkManagerStart.Location = new System.Drawing.Point(477, 197);
            this.button_WalkManagerStart.Name = "button_WalkManagerStart";
            this.button_WalkManagerStart.Size = new System.Drawing.Size(48, 23);
            this.button_WalkManagerStart.TabIndex = 213;
            this.button_WalkManagerStart.Text = "Save";
            this.button_WalkManagerStart.UseVisualStyleBackColor = true;
            this.button_WalkManagerStart.Click += new System.EventHandler(this.button_WalkManagerStart_Click);
            // 
            // label_AMax
            // 
            this.label_AMax.AutoSize = true;
            this.label_AMax.Location = new System.Drawing.Point(389, 99);
            this.label_AMax.Name = "label_AMax";
            this.label_AMax.Size = new System.Drawing.Size(34, 13);
            this.label_AMax.TabIndex = 212;
            this.label_AMax.Text = "AMax";
            // 
            // AMax
            // 
            this.AMax.Location = new System.Drawing.Point(429, 94);
            this.AMax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.AMax.Name = "AMax";
            this.AMax.Size = new System.Drawing.Size(50, 20);
            this.AMax.TabIndex = 211;
            this.AMax.ValueChanged += new System.EventHandler(this.AMax_ValueChanged);
            // 
            // label_AMin
            // 
            this.label_AMin.AutoSize = true;
            this.label_AMin.Location = new System.Drawing.Point(292, 98);
            this.label_AMin.Name = "label_AMin";
            this.label_AMin.Size = new System.Drawing.Size(31, 13);
            this.label_AMin.TabIndex = 210;
            this.label_AMin.Text = "AMin";
            // 
            // AMin
            // 
            this.AMin.Location = new System.Drawing.Point(329, 94);
            this.AMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.AMin.Name = "AMin";
            this.AMin.Size = new System.Drawing.Size(50, 20);
            this.AMin.TabIndex = 209;
            this.AMin.ValueChanged += new System.EventHandler(this.AMin_ValueChanged);
            // 
            // label_ZMax
            // 
            this.label_ZMax.AutoSize = true;
            this.label_ZMax.Location = new System.Drawing.Point(389, 72);
            this.label_ZMax.Name = "label_ZMax";
            this.label_ZMax.Size = new System.Drawing.Size(34, 13);
            this.label_ZMax.TabIndex = 208;
            this.label_ZMax.Text = "ZMax";
            // 
            // ZMax
            // 
            this.ZMax.Location = new System.Drawing.Point(429, 67);
            this.ZMax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ZMax.Name = "ZMax";
            this.ZMax.Size = new System.Drawing.Size(50, 20);
            this.ZMax.TabIndex = 207;
            this.ZMax.ValueChanged += new System.EventHandler(this.ZMax_ValueChanged);
            // 
            // label_ZMin
            // 
            this.label_ZMin.AutoSize = true;
            this.label_ZMin.Location = new System.Drawing.Point(292, 71);
            this.label_ZMin.Name = "label_ZMin";
            this.label_ZMin.Size = new System.Drawing.Size(31, 13);
            this.label_ZMin.TabIndex = 206;
            this.label_ZMin.Text = "ZMin";
            // 
            // ZMin
            // 
            this.ZMin.Location = new System.Drawing.Point(329, 67);
            this.ZMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ZMin.Name = "ZMin";
            this.ZMin.Size = new System.Drawing.Size(50, 20);
            this.ZMin.TabIndex = 205;
            this.ZMin.ValueChanged += new System.EventHandler(this.ZMin_ValueChanged);
            // 
            // label_Ymax
            // 
            this.label_Ymax.AutoSize = true;
            this.label_Ymax.Location = new System.Drawing.Point(389, 46);
            this.label_Ymax.Name = "label_Ymax";
            this.label_Ymax.Size = new System.Drawing.Size(34, 13);
            this.label_Ymax.TabIndex = 204;
            this.label_Ymax.Text = "YMax";
            // 
            // YMax
            // 
            this.YMax.Location = new System.Drawing.Point(429, 41);
            this.YMax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.YMax.Name = "YMax";
            this.YMax.Size = new System.Drawing.Size(50, 20);
            this.YMax.TabIndex = 203;
            this.YMax.ValueChanged += new System.EventHandler(this.YMax_ValueChanged);
            // 
            // label_YMin
            // 
            this.label_YMin.AutoSize = true;
            this.label_YMin.Location = new System.Drawing.Point(292, 45);
            this.label_YMin.Name = "label_YMin";
            this.label_YMin.Size = new System.Drawing.Size(31, 13);
            this.label_YMin.TabIndex = 202;
            this.label_YMin.Text = "YMin";
            // 
            // YMin
            // 
            this.YMin.Location = new System.Drawing.Point(329, 41);
            this.YMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.YMin.Name = "YMin";
            this.YMin.Size = new System.Drawing.Size(50, 20);
            this.YMin.TabIndex = 201;
            this.YMin.ValueChanged += new System.EventHandler(this.YMin_ValueChanged);
            // 
            // label_XMax
            // 
            this.label_XMax.AutoSize = true;
            this.label_XMax.Location = new System.Drawing.Point(389, 21);
            this.label_XMax.Name = "label_XMax";
            this.label_XMax.Size = new System.Drawing.Size(34, 13);
            this.label_XMax.TabIndex = 200;
            this.label_XMax.Text = "XMax";
            // 
            // XMax
            // 
            this.XMax.Location = new System.Drawing.Point(429, 16);
            this.XMax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.XMax.Name = "XMax";
            this.XMax.Size = new System.Drawing.Size(50, 20);
            this.XMax.TabIndex = 199;
            this.XMax.ValueChanged += new System.EventHandler(this.XMax_ValueChanged);
            // 
            // label_XMin
            // 
            this.label_XMin.AutoSize = true;
            this.label_XMin.Location = new System.Drawing.Point(292, 20);
            this.label_XMin.Name = "label_XMin";
            this.label_XMin.Size = new System.Drawing.Size(31, 13);
            this.label_XMin.TabIndex = 198;
            this.label_XMin.Text = "XMin";
            // 
            // XMin
            // 
            this.XMin.Location = new System.Drawing.Point(329, 16);
            this.XMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.XMin.Name = "XMin";
            this.XMin.Size = new System.Drawing.Size(50, 20);
            this.XMin.TabIndex = 197;
            this.XMin.ValueChanged += new System.EventHandler(this.XMin_ValueChanged);
            // 
            // label_A
            // 
            this.label_A.AutoSize = true;
            this.label_A.Location = new System.Drawing.Point(127, 97);
            this.label_A.Name = "label_A";
            this.label_A.Size = new System.Drawing.Size(14, 13);
            this.label_A.TabIndex = 196;
            this.label_A.Text = "A";
            // 
            // numericUpDown_A
            // 
            this.numericUpDown_A.Location = new System.Drawing.Point(149, 95);
            this.numericUpDown_A.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_A.Name = "numericUpDown_A";
            this.numericUpDown_A.ReadOnly = true;
            this.numericUpDown_A.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_A.TabIndex = 195;
            // 
            // checkBox_ASmooth
            // 
            this.checkBox_ASmooth.AutoSize = true;
            this.checkBox_ASmooth.Location = new System.Drawing.Point(212, 97);
            this.checkBox_ASmooth.Name = "checkBox_ASmooth";
            this.checkBox_ASmooth.Size = new System.Drawing.Size(72, 17);
            this.checkBox_ASmooth.TabIndex = 194;
            this.checkBox_ASmooth.Text = "A Smooth";
            this.checkBox_ASmooth.UseVisualStyleBackColor = true;
            this.checkBox_ASmooth.CheckedChanged += new System.EventHandler(this.checkBox_ASmooth_CheckedChanged);
            // 
            // label_ATarget
            // 
            this.label_ATarget.AutoSize = true;
            this.label_ATarget.Location = new System.Drawing.Point(9, 97);
            this.label_ATarget.Name = "label_ATarget";
            this.label_ATarget.Size = new System.Drawing.Size(45, 13);
            this.label_ATarget.TabIndex = 193;
            this.label_ATarget.Text = "ATarget";
            // 
            // A_Target
            // 
            this.A_Target.Location = new System.Drawing.Point(61, 95);
            this.A_Target.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.A_Target.Name = "A_Target";
            this.A_Target.Size = new System.Drawing.Size(50, 20);
            this.A_Target.TabIndex = 192;
            this.A_Target.ValueChanged += new System.EventHandler(this.A_Target_ValueChanged);
            // 
            // label_Z
            // 
            this.label_Z.AutoSize = true;
            this.label_Z.Location = new System.Drawing.Point(127, 70);
            this.label_Z.Name = "label_Z";
            this.label_Z.Size = new System.Drawing.Size(14, 13);
            this.label_Z.TabIndex = 191;
            this.label_Z.Text = "Z";
            // 
            // numericUpDown_Z
            // 
            this.numericUpDown_Z.Location = new System.Drawing.Point(149, 68);
            this.numericUpDown_Z.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_Z.Name = "numericUpDown_Z";
            this.numericUpDown_Z.ReadOnly = true;
            this.numericUpDown_Z.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Z.TabIndex = 190;
            // 
            // checkBox_ZSmooth
            // 
            this.checkBox_ZSmooth.AutoSize = true;
            this.checkBox_ZSmooth.Location = new System.Drawing.Point(212, 70);
            this.checkBox_ZSmooth.Name = "checkBox_ZSmooth";
            this.checkBox_ZSmooth.Size = new System.Drawing.Size(72, 17);
            this.checkBox_ZSmooth.TabIndex = 189;
            this.checkBox_ZSmooth.Text = "Z Smooth";
            this.checkBox_ZSmooth.UseVisualStyleBackColor = true;
            this.checkBox_ZSmooth.CheckedChanged += new System.EventHandler(this.checkBox_ZSmooth_CheckedChanged);
            // 
            // label_ZTarget
            // 
            this.label_ZTarget.AutoSize = true;
            this.label_ZTarget.Location = new System.Drawing.Point(9, 70);
            this.label_ZTarget.Name = "label_ZTarget";
            this.label_ZTarget.Size = new System.Drawing.Size(45, 13);
            this.label_ZTarget.TabIndex = 188;
            this.label_ZTarget.Text = "ZTarget";
            // 
            // Z_Target
            // 
            this.Z_Target.Location = new System.Drawing.Point(61, 68);
            this.Z_Target.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.Z_Target.Name = "Z_Target";
            this.Z_Target.Size = new System.Drawing.Size(50, 20);
            this.Z_Target.TabIndex = 187;
            this.Z_Target.ValueChanged += new System.EventHandler(this.Z_Target_ValueChanged);
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(127, 44);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(14, 13);
            this.label_Y.TabIndex = 186;
            this.label_Y.Text = "Y";
            // 
            // numericUpDown_Y
            // 
            this.numericUpDown_Y.Location = new System.Drawing.Point(149, 42);
            this.numericUpDown_Y.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_Y.Name = "numericUpDown_Y";
            this.numericUpDown_Y.ReadOnly = true;
            this.numericUpDown_Y.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_Y.TabIndex = 185;
            // 
            // checkBox_YSmooth
            // 
            this.checkBox_YSmooth.AutoSize = true;
            this.checkBox_YSmooth.Location = new System.Drawing.Point(212, 44);
            this.checkBox_YSmooth.Name = "checkBox_YSmooth";
            this.checkBox_YSmooth.Size = new System.Drawing.Size(72, 17);
            this.checkBox_YSmooth.TabIndex = 184;
            this.checkBox_YSmooth.Text = "Y Smooth";
            this.checkBox_YSmooth.UseVisualStyleBackColor = true;
            this.checkBox_YSmooth.CheckedChanged += new System.EventHandler(this.checkBox_YSmooth_CheckedChanged);
            // 
            // label_YTarget
            // 
            this.label_YTarget.AutoSize = true;
            this.label_YTarget.Location = new System.Drawing.Point(9, 44);
            this.label_YTarget.Name = "label_YTarget";
            this.label_YTarget.Size = new System.Drawing.Size(45, 13);
            this.label_YTarget.TabIndex = 183;
            this.label_YTarget.Text = "YTarget";
            // 
            // Y_Target
            // 
            this.Y_Target.Location = new System.Drawing.Point(61, 42);
            this.Y_Target.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.Y_Target.Name = "Y_Target";
            this.Y_Target.Size = new System.Drawing.Size(50, 20);
            this.Y_Target.TabIndex = 182;
            this.Y_Target.ValueChanged += new System.EventHandler(this.Y_Target_ValueChanged);
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(127, 19);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(14, 13);
            this.label_X.TabIndex = 181;
            this.label_X.Text = "X";
            // 
            // numericUpDown_X
            // 
            this.numericUpDown_X.Location = new System.Drawing.Point(149, 17);
            this.numericUpDown_X.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_X.Name = "numericUpDown_X";
            this.numericUpDown_X.ReadOnly = true;
            this.numericUpDown_X.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown_X.TabIndex = 180;
            // 
            // checkBox_XSmooth
            // 
            this.checkBox_XSmooth.AutoSize = true;
            this.checkBox_XSmooth.Location = new System.Drawing.Point(212, 19);
            this.checkBox_XSmooth.Name = "checkBox_XSmooth";
            this.checkBox_XSmooth.Size = new System.Drawing.Size(72, 17);
            this.checkBox_XSmooth.TabIndex = 179;
            this.checkBox_XSmooth.Text = "X Smooth";
            this.checkBox_XSmooth.UseVisualStyleBackColor = true;
            this.checkBox_XSmooth.CheckedChanged += new System.EventHandler(this.checkBox_XSmooth_CheckedChanged);
            // 
            // label_XTarget
            // 
            this.label_XTarget.AutoSize = true;
            this.label_XTarget.Location = new System.Drawing.Point(9, 19);
            this.label_XTarget.Name = "label_XTarget";
            this.label_XTarget.Size = new System.Drawing.Size(45, 13);
            this.label_XTarget.TabIndex = 178;
            this.label_XTarget.Text = "XTarget";
            // 
            // X_Target
            // 
            this.X_Target.Location = new System.Drawing.Point(61, 17);
            this.X_Target.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.X_Target.Name = "X_Target";
            this.X_Target.Size = new System.Drawing.Size(50, 20);
            this.X_Target.TabIndex = 177;
            this.X_Target.ValueChanged += new System.EventHandler(this.X_Target_ValueChanged);
            // 
            // button_StopLocoMotionFSM
            // 
            this.button_StopLocoMotionFSM.Image = global::Robot.Locomotion.Properties.Resources.button_stop2;
            this.button_StopLocoMotionFSM.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_StopLocoMotionFSM.Location = new System.Drawing.Point(506, 131);
            this.button_StopLocoMotionFSM.Name = "button_StopLocoMotionFSM";
            this.button_StopLocoMotionFSM.Size = new System.Drawing.Size(33, 33);
            this.button_StopLocoMotionFSM.TabIndex = 77;
            this.button_StopLocoMotionFSM.UseVisualStyleBackColor = true;
            this.button_StopLocoMotionFSM.Click += new System.EventHandler(this.button_StopLocoMotionFSM_Click);
            // 
            // groupBox_MotionIndexs
            // 
            this.groupBox_MotionIndexs.Controls.Add(this.button_RightKickLittle);
            this.groupBox_MotionIndexs.Controls.Add(this.button_RightKick);
            this.groupBox_MotionIndexs.Controls.Add(this.label_RightKickLittle);
            this.groupBox_MotionIndexs.Controls.Add(this.RightKick);
            this.groupBox_MotionIndexs.Controls.Add(this.label_RightKick);
            this.groupBox_MotionIndexs.Controls.Add(this.RightKickLittle);
            this.groupBox_MotionIndexs.Controls.Add(this.button_LeftKickLittle);
            this.groupBox_MotionIndexs.Controls.Add(this.button_LeftKick);
            this.groupBox_MotionIndexs.Controls.Add(this.button_Happy);
            this.groupBox_MotionIndexs.Controls.Add(this.HappyIndex);
            this.groupBox_MotionIndexs.Controls.Add(this.label_LeftKickLittle);
            this.groupBox_MotionIndexs.Controls.Add(this.LeftKickIndex);
            this.groupBox_MotionIndexs.Controls.Add(this.label_LeftKick);
            this.groupBox_MotionIndexs.Controls.Add(this.LeftKickLittleIndex);
            this.groupBox_MotionIndexs.Controls.Add(this.label_Happy);
            this.groupBox_MotionIndexs.Controls.Add(this.button_PlayFallBackMotion);
            this.groupBox_MotionIndexs.Controls.Add(this.button_PlayIsFallFrontMotion);
            this.groupBox_MotionIndexs.Controls.Add(this.button_PlayIsFallingMotion);
            this.groupBox_MotionIndexs.Controls.Add(this.IsFallingMotionIndex);
            this.groupBox_MotionIndexs.Controls.Add(this.label_FallBackMotionIndex);
            this.groupBox_MotionIndexs.Controls.Add(this.FallFrontMotionIndex);
            this.groupBox_MotionIndexs.Controls.Add(this.label_FallFrontMotionIndex);
            this.groupBox_MotionIndexs.Controls.Add(this.FallBackMotionIndex);
            this.groupBox_MotionIndexs.Controls.Add(this.label_IsFallingMotionIndex);
            this.groupBox_MotionIndexs.Location = new System.Drawing.Point(6, 121);
            this.groupBox_MotionIndexs.Name = "groupBox_MotionIndexs";
            this.groupBox_MotionIndexs.Size = new System.Drawing.Size(458, 99);
            this.groupBox_MotionIndexs.TabIndex = 147;
            this.groupBox_MotionIndexs.TabStop = false;
            this.groupBox_MotionIndexs.Text = "  Motion Indexs";
            // 
            // button_PlayFallBackMotion
            // 
            this.button_PlayFallBackMotion.BackgroundImage = global::Robot.Locomotion.Properties.Resources.player_play;
            this.button_PlayFallBackMotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_PlayFallBackMotion.Location = new System.Drawing.Point(120, 46);
            this.button_PlayFallBackMotion.Name = "button_PlayFallBackMotion";
            this.button_PlayFallBackMotion.Size = new System.Drawing.Size(24, 22);
            this.button_PlayFallBackMotion.TabIndex = 152;
            this.button_PlayFallBackMotion.UseVisualStyleBackColor = true;
            this.button_PlayFallBackMotion.Click += new System.EventHandler(this.button_PlayFallBackMotion_Click);
            // 
            // button_PlayIsFallFrontMotion
            // 
            this.button_PlayIsFallFrontMotion.BackgroundImage = global::Robot.Locomotion.Properties.Resources.player_play;
            this.button_PlayIsFallFrontMotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_PlayIsFallFrontMotion.Location = new System.Drawing.Point(121, 21);
            this.button_PlayIsFallFrontMotion.Name = "button_PlayIsFallFrontMotion";
            this.button_PlayIsFallFrontMotion.Size = new System.Drawing.Size(24, 22);
            this.button_PlayIsFallFrontMotion.TabIndex = 151;
            this.button_PlayIsFallFrontMotion.UseVisualStyleBackColor = true;
            this.button_PlayIsFallFrontMotion.Click += new System.EventHandler(this.button_PlayIsFallFrontMotion_Click);
            // 
            // button_PlayIsFallingMotion
            // 
            this.button_PlayIsFallingMotion.BackgroundImage = global::Robot.Locomotion.Properties.Resources.player_play;
            this.button_PlayIsFallingMotion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_PlayIsFallingMotion.Location = new System.Drawing.Point(120, 73);
            this.button_PlayIsFallingMotion.Name = "button_PlayIsFallingMotion";
            this.button_PlayIsFallingMotion.Size = new System.Drawing.Size(24, 22);
            this.button_PlayIsFallingMotion.TabIndex = 150;
            this.button_PlayIsFallingMotion.UseVisualStyleBackColor = true;
            this.button_PlayIsFallingMotion.Click += new System.EventHandler(this.button_PlayIsFallingMotion_Click);
            // 
            // IsFallingMotionIndex
            // 
            this.IsFallingMotionIndex.Location = new System.Drawing.Point(68, 73);
            this.IsFallingMotionIndex.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.IsFallingMotionIndex.Name = "IsFallingMotionIndex";
            this.IsFallingMotionIndex.Size = new System.Drawing.Size(46, 20);
            this.IsFallingMotionIndex.TabIndex = 144;
            this.IsFallingMotionIndex.ValueChanged += new System.EventHandler(this.numericUpDown_IsFallingMotionIndex_ValueChanged);
            // 
            // label_FallBackMotionIndex
            // 
            this.label_FallBackMotionIndex.AutoSize = true;
            this.label_FallBackMotionIndex.Location = new System.Drawing.Point(11, 53);
            this.label_FallBackMotionIndex.Name = "label_FallBackMotionIndex";
            this.label_FallBackMotionIndex.Size = new System.Drawing.Size(51, 13);
            this.label_FallBackMotionIndex.TabIndex = 149;
            this.label_FallBackMotionIndex.Text = "Fall Back";
            // 
            // FallFrontMotionIndex
            // 
            this.FallFrontMotionIndex.Location = new System.Drawing.Point(68, 21);
            this.FallFrontMotionIndex.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.FallFrontMotionIndex.Name = "FallFrontMotionIndex";
            this.FallFrontMotionIndex.Size = new System.Drawing.Size(46, 20);
            this.FallFrontMotionIndex.TabIndex = 145;
            this.FallFrontMotionIndex.ValueChanged += new System.EventHandler(this.numericUpDown_FallFrontMotionIndex_ValueChanged);
            // 
            // label_FallFrontMotionIndex
            // 
            this.label_FallFrontMotionIndex.AutoSize = true;
            this.label_FallFrontMotionIndex.Location = new System.Drawing.Point(11, 26);
            this.label_FallFrontMotionIndex.Name = "label_FallFrontMotionIndex";
            this.label_FallFrontMotionIndex.Size = new System.Drawing.Size(50, 13);
            this.label_FallFrontMotionIndex.TabIndex = 148;
            this.label_FallFrontMotionIndex.Text = "Fall Front";
            // 
            // FallBackMotionIndex
            // 
            this.FallBackMotionIndex.Location = new System.Drawing.Point(68, 49);
            this.FallBackMotionIndex.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.FallBackMotionIndex.Name = "FallBackMotionIndex";
            this.FallBackMotionIndex.Size = new System.Drawing.Size(46, 20);
            this.FallBackMotionIndex.TabIndex = 146;
            this.FallBackMotionIndex.ValueChanged += new System.EventHandler(this.numericUpDown_FallBackMotionIndex_ValueChanged);
            // 
            // label_IsFallingMotionIndex
            // 
            this.label_IsFallingMotionIndex.AutoSize = true;
            this.label_IsFallingMotionIndex.Location = new System.Drawing.Point(11, 80);
            this.label_IsFallingMotionIndex.Name = "label_IsFallingMotionIndex";
            this.label_IsFallingMotionIndex.Size = new System.Drawing.Size(48, 13);
            this.label_IsFallingMotionIndex.TabIndex = 147;
            this.label_IsFallingMotionIndex.Text = "Is Falling";
            // 
            // button_StartLocoMotionFSM
            // 
            this.button_StartLocoMotionFSM.Image = global::Robot.Locomotion.Properties.Resources.player_play1;
            this.button_StartLocoMotionFSM.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_StartLocoMotionFSM.Location = new System.Drawing.Point(470, 131);
            this.button_StartLocoMotionFSM.Name = "button_StartLocoMotionFSM";
            this.button_StartLocoMotionFSM.Size = new System.Drawing.Size(33, 33);
            this.button_StartLocoMotionFSM.TabIndex = 76;
            this.button_StartLocoMotionFSM.UseVisualStyleBackColor = true;
            this.button_StartLocoMotionFSM.Click += new System.EventHandler(this.button_StartLocoMotionFSM_Click);
            // 
            // groupBox_WalkingParameters
            // 
            this.groupBox_WalkingParameters.Controls.Add(this.label4);
            this.groupBox_WalkingParameters.Controls.Add(this.numericUpDown_ActuatorsSpeed);
            this.groupBox_WalkingParameters.Controls.Add(this.label_HandPitchAmplitude);
            this.groupBox_WalkingParameters.Controls.Add(this.numericUpDown_ArmSwingGain);
            this.groupBox_WalkingParameters.Controls.Add(this.labelFBRatio);
            this.groupBox_WalkingParameters.Controls.Add(this.label_DS_Ratio);
            this.groupBox_WalkingParameters.Controls.Add(this.FORWARDBACKWARDRATIO);
            this.groupBox_WalkingParameters.Controls.Add(this.checkBox_WalkingchartEnable);
            this.groupBox_WalkingParameters.Controls.Add(this.DOUBLESTANCERATIO);
            this.groupBox_WalkingParameters.Controls.Add(this.checkBox_AMoveAimOn);
            this.groupBox_WalkingParameters.Controls.Add(this.label2);
            this.groupBox_WalkingParameters.Controls.Add(this.button_LoadWalkSettings);
            this.groupBox_WalkingParameters.Controls.Add(this.button_SaveWalkSettings);
            this.groupBox_WalkingParameters.Controls.Add(this.label_pelvisoffset);
            this.groupBox_WalkingParameters.Controls.Add(this.checkBox_Control);
            this.groupBox_WalkingParameters.Controls.Add(this.numericUpDown_PitchOffset);
            this.groupBox_WalkingParameters.Controls.Add(this.button_DarwinWalkStop);
            this.groupBox_WalkingParameters.Controls.Add(this.button_DarwinWalkStart);
            this.groupBox_WalkingParameters.Controls.Add(this.numericUpDown_PelvisOffset);
            this.groupBox_WalkingParameters.Controls.Add(this.label14);
            this.groupBox_WalkingParameters.Controls.Add(this.Z_SWAP_AMPLITUDE);
            this.groupBox_WalkingParameters.Controls.Add(this.label11);
            this.groupBox_WalkingParameters.Controls.Add(this.label7);
            this.groupBox_WalkingParameters.Controls.Add(this.label8);
            this.groupBox_WalkingParameters.Controls.Add(this.TIME_UNIT);
            this.groupBox_WalkingParameters.Controls.Add(this.Y_MOVE_AMPLITUDE);
            this.groupBox_WalkingParameters.Controls.Add(this.TIME_PERIOD);
            this.groupBox_WalkingParameters.Controls.Add(this.X_OFFSET);
            this.groupBox_WalkingParameters.Controls.Add(this.Z_OFFSET);
            this.groupBox_WalkingParameters.Controls.Add(this.Y_OFFSET);
            this.groupBox_WalkingParameters.Controls.Add(this.A_OFFSET);
            this.groupBox_WalkingParameters.Controls.Add(this.label_ZOffset);
            this.groupBox_WalkingParameters.Controls.Add(this.label_YOffset);
            this.groupBox_WalkingParameters.Controls.Add(this.label_XOffset);
            this.groupBox_WalkingParameters.Controls.Add(this.label_AOffset);
            this.groupBox_WalkingParameters.Location = new System.Drawing.Point(730, 6);
            this.groupBox_WalkingParameters.Name = "groupBox_WalkingParameters";
            this.groupBox_WalkingParameters.Size = new System.Drawing.Size(332, 293);
            this.groupBox_WalkingParameters.TabIndex = 146;
            this.groupBox_WalkingParameters.TabStop = false;
            this.groupBox_WalkingParameters.Text = "  Walking Parameters  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 158;
            this.label4.Text = "Actuators Speed";
            // 
            // numericUpDown_ActuatorsSpeed
            // 
            this.numericUpDown_ActuatorsSpeed.Location = new System.Drawing.Point(111, 161);
            this.numericUpDown_ActuatorsSpeed.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.numericUpDown_ActuatorsSpeed.Name = "numericUpDown_ActuatorsSpeed";
            this.numericUpDown_ActuatorsSpeed.Size = new System.Drawing.Size(55, 20);
            this.numericUpDown_ActuatorsSpeed.TabIndex = 149;
            this.numericUpDown_ActuatorsSpeed.ValueChanged += new System.EventHandler(this.numericUpDown_ActuatorsSpeed_ValueChanged);
            // 
            // label_HandPitchAmplitude
            // 
            this.label_HandPitchAmplitude.AutoSize = true;
            this.label_HandPitchAmplitude.Location = new System.Drawing.Point(20, 59);
            this.label_HandPitchAmplitude.Name = "label_HandPitchAmplitude";
            this.label_HandPitchAmplitude.Size = new System.Drawing.Size(76, 13);
            this.label_HandPitchAmplitude.TabIndex = 142;
            this.label_HandPitchAmplitude.Text = "ArmSwingGain";
            // 
            // numericUpDown_ArmSwingGain
            // 
            this.numericUpDown_ArmSwingGain.DecimalPlaces = 2;
            this.numericUpDown_ArmSwingGain.Location = new System.Drawing.Point(111, 55);
            this.numericUpDown_ArmSwingGain.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_ArmSwingGain.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_ArmSwingGain.Name = "numericUpDown_ArmSwingGain";
            this.numericUpDown_ArmSwingGain.Size = new System.Drawing.Size(65, 20);
            this.numericUpDown_ArmSwingGain.TabIndex = 141;
            this.numericUpDown_ArmSwingGain.ValueChanged += new System.EventHandler(this.numericUpDown_ArmSwingGain_ValueChanged);
            // 
            // labelFBRatio
            // 
            this.labelFBRatio.AutoSize = true;
            this.labelFBRatio.Location = new System.Drawing.Point(192, 225);
            this.labelFBRatio.Name = "labelFBRatio";
            this.labelFBRatio.Size = new System.Drawing.Size(53, 13);
            this.labelFBRatio.TabIndex = 102;
            this.labelFBRatio.Text = "F/B Ratio";
            // 
            // label_DS_Ratio
            // 
            this.label_DS_Ratio.AutoSize = true;
            this.label_DS_Ratio.Location = new System.Drawing.Point(193, 199);
            this.label_DS_Ratio.Name = "label_DS_Ratio";
            this.label_DS_Ratio.Size = new System.Drawing.Size(50, 13);
            this.label_DS_Ratio.TabIndex = 101;
            this.label_DS_Ratio.Text = "DS Ratio";
            // 
            // FORWARDBACKWARDRATIO
            // 
            this.FORWARDBACKWARDRATIO.DecimalPlaces = 2;
            this.FORWARDBACKWARDRATIO.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.FORWARDBACKWARDRATIO.Location = new System.Drawing.Point(251, 222);
            this.FORWARDBACKWARDRATIO.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.FORWARDBACKWARDRATIO.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.FORWARDBACKWARDRATIO.Name = "FORWARDBACKWARDRATIO";
            this.FORWARDBACKWARDRATIO.Size = new System.Drawing.Size(65, 20);
            this.FORWARDBACKWARDRATIO.TabIndex = 100;
            this.FORWARDBACKWARDRATIO.ValueChanged += new System.EventHandler(this.FORWARDBACKWARDRATIO_ValueChanged);
            // 
            // checkBox_WalkingchartEnable
            // 
            this.checkBox_WalkingchartEnable.AutoSize = true;
            this.checkBox_WalkingchartEnable.Location = new System.Drawing.Point(7, 199);
            this.checkBox_WalkingchartEnable.Name = "checkBox_WalkingchartEnable";
            this.checkBox_WalkingchartEnable.Size = new System.Drawing.Size(51, 17);
            this.checkBox_WalkingchartEnable.TabIndex = 140;
            this.checkBox_WalkingchartEnable.Text = "Chart";
            this.checkBox_WalkingchartEnable.UseVisualStyleBackColor = true;
            this.checkBox_WalkingchartEnable.CheckedChanged += new System.EventHandler(this.checkBox_WalkingchartEnable_CheckedChanged);
            // 
            // DOUBLESTANCERATIO
            // 
            this.DOUBLESTANCERATIO.DecimalPlaces = 2;
            this.DOUBLESTANCERATIO.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.DOUBLESTANCERATIO.Location = new System.Drawing.Point(251, 196);
            this.DOUBLESTANCERATIO.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DOUBLESTANCERATIO.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.DOUBLESTANCERATIO.Name = "DOUBLESTANCERATIO";
            this.DOUBLESTANCERATIO.Size = new System.Drawing.Size(65, 20);
            this.DOUBLESTANCERATIO.TabIndex = 99;
            this.DOUBLESTANCERATIO.ValueChanged += new System.EventHandler(this.DOUBLESTANCERATIO_ValueChanged);
            // 
            // checkBox_AMoveAimOn
            // 
            this.checkBox_AMoveAimOn.AutoSize = true;
            this.checkBox_AMoveAimOn.Location = new System.Drawing.Point(66, 199);
            this.checkBox_AMoveAimOn.Name = "checkBox_AMoveAimOn";
            this.checkBox_AMoveAimOn.Size = new System.Drawing.Size(100, 17);
            this.checkBox_AMoveAimOn.TabIndex = 90;
            this.checkBox_AMoveAimOn.Text = "A Move Aim On";
            this.checkBox_AMoveAimOn.UseVisualStyleBackColor = true;
            this.checkBox_AMoveAimOn.CheckedChanged += new System.EventHandler(this.checkBox_AMoveAimOn_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Pitch Offset";
            // 
            // button_LoadWalkSettings
            // 
            this.button_LoadWalkSettings.Location = new System.Drawing.Point(66, 229);
            this.button_LoadWalkSettings.Name = "button_LoadWalkSettings";
            this.button_LoadWalkSettings.Size = new System.Drawing.Size(48, 23);
            this.button_LoadWalkSettings.TabIndex = 82;
            this.button_LoadWalkSettings.Text = "Load";
            this.button_LoadWalkSettings.UseVisualStyleBackColor = true;
            this.button_LoadWalkSettings.Click += new System.EventHandler(this.button_LoadWalkSettings_Click);
            // 
            // button_SaveWalkSettings
            // 
            this.button_SaveWalkSettings.Location = new System.Drawing.Point(12, 229);
            this.button_SaveWalkSettings.Name = "button_SaveWalkSettings";
            this.button_SaveWalkSettings.Size = new System.Drawing.Size(48, 23);
            this.button_SaveWalkSettings.TabIndex = 81;
            this.button_SaveWalkSettings.Text = "Save";
            this.button_SaveWalkSettings.UseVisualStyleBackColor = true;
            this.button_SaveWalkSettings.Click += new System.EventHandler(this.button_SaveWalkSettings_Click);
            // 
            // label_pelvisoffset
            // 
            this.label_pelvisoffset.AutoSize = true;
            this.label_pelvisoffset.Location = new System.Drawing.Point(184, 136);
            this.label_pelvisoffset.Name = "label_pelvisoffset";
            this.label_pelvisoffset.Size = new System.Drawing.Size(66, 13);
            this.label_pelvisoffset.TabIndex = 93;
            this.label_pelvisoffset.Text = "Pelvis Offset";
            // 
            // checkBox_Control
            // 
            this.checkBox_Control.AutoSize = true;
            this.checkBox_Control.Location = new System.Drawing.Point(171, 260);
            this.checkBox_Control.Name = "checkBox_Control";
            this.checkBox_Control.Size = new System.Drawing.Size(73, 17);
            this.checkBox_Control.TabIndex = 80;
            this.checkBox_Control.Text = "JustStand";
            this.checkBox_Control.UseVisualStyleBackColor = true;
            this.checkBox_Control.CheckedChanged += new System.EventHandler(this.checkBox_Control_CheckedChanged);
            // 
            // numericUpDown_PitchOffset
            // 
            this.numericUpDown_PitchOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_PitchOffset.Location = new System.Drawing.Point(256, 160);
            this.numericUpDown_PitchOffset.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_PitchOffset.Name = "numericUpDown_PitchOffset";
            this.numericUpDown_PitchOffset.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown_PitchOffset.TabIndex = 92;
            this.numericUpDown_PitchOffset.ValueChanged += new System.EventHandler(this.numericUpDown_PitchOffset_ValueChanged_1);
            // 
            // button_DarwinWalkStop
            // 
            this.button_DarwinWalkStop.Image = global::Robot.Locomotion.Properties.Resources.button_stop2;
            this.button_DarwinWalkStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_DarwinWalkStop.Location = new System.Drawing.Point(295, 251);
            this.button_DarwinWalkStop.Name = "button_DarwinWalkStop";
            this.button_DarwinWalkStop.Size = new System.Drawing.Size(33, 33);
            this.button_DarwinWalkStop.TabIndex = 75;
            this.button_DarwinWalkStop.UseVisualStyleBackColor = true;
            this.button_DarwinWalkStop.Click += new System.EventHandler(this.button_DarwinWalkStop_Click);
            // 
            // button_DarwinWalkStart
            // 
            this.button_DarwinWalkStart.Image = global::Robot.Locomotion.Properties.Resources.player_play1;
            this.button_DarwinWalkStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_DarwinWalkStart.Location = new System.Drawing.Point(256, 251);
            this.button_DarwinWalkStart.Name = "button_DarwinWalkStart";
            this.button_DarwinWalkStart.Size = new System.Drawing.Size(33, 33);
            this.button_DarwinWalkStart.TabIndex = 74;
            this.button_DarwinWalkStart.UseVisualStyleBackColor = true;
            this.button_DarwinWalkStart.Click += new System.EventHandler(this.button_DarwinWalkStart_Click);
            // 
            // numericUpDown_PelvisOffset
            // 
            this.numericUpDown_PelvisOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_PelvisOffset.Location = new System.Drawing.Point(256, 134);
            this.numericUpDown_PelvisOffset.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_PelvisOffset.Name = "numericUpDown_PelvisOffset";
            this.numericUpDown_PelvisOffset.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown_PelvisOffset.TabIndex = 91;
            this.numericUpDown_PelvisOffset.ValueChanged += new System.EventHandler(this.numericUpDown_PelvisOffset_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 69;
            this.label14.Text = "Z Swap Amplitude";
            // 
            // Z_SWAP_AMPLITUDE
            // 
            this.Z_SWAP_AMPLITUDE.DecimalPlaces = 2;
            this.Z_SWAP_AMPLITUDE.Location = new System.Drawing.Point(111, 82);
            this.Z_SWAP_AMPLITUDE.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Z_SWAP_AMPLITUDE.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.Z_SWAP_AMPLITUDE.Name = "Z_SWAP_AMPLITUDE";
            this.Z_SWAP_AMPLITUDE.Size = new System.Drawing.Size(65, 20);
            this.Z_SWAP_AMPLITUDE.TabIndex = 67;
            this.Z_SWAP_AMPLITUDE.ValueChanged += new System.EventHandler(this.Z_SWAP_AMPLITUDE_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "Y Move Amplitude";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Time Unit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Time Period";
            // 
            // TIME_UNIT
            // 
            this.TIME_UNIT.Location = new System.Drawing.Point(111, 134);
            this.TIME_UNIT.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TIME_UNIT.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.TIME_UNIT.Name = "TIME_UNIT";
            this.TIME_UNIT.Size = new System.Drawing.Size(55, 20);
            this.TIME_UNIT.TabIndex = 54;
            this.TIME_UNIT.ValueChanged += new System.EventHandler(this.TIME_UNIT_ValueChanged);
            // 
            // Y_MOVE_AMPLITUDE
            // 
            this.Y_MOVE_AMPLITUDE.Location = new System.Drawing.Point(111, 27);
            this.Y_MOVE_AMPLITUDE.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.Y_MOVE_AMPLITUDE.Name = "Y_MOVE_AMPLITUDE";
            this.Y_MOVE_AMPLITUDE.Size = new System.Drawing.Size(65, 20);
            this.Y_MOVE_AMPLITUDE.TabIndex = 57;
            this.Y_MOVE_AMPLITUDE.ValueChanged += new System.EventHandler(this.Y_MOVE_AMPLITUDE_ValueChanged);
            // 
            // TIME_PERIOD
            // 
            this.TIME_PERIOD.Location = new System.Drawing.Point(111, 108);
            this.TIME_PERIOD.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.TIME_PERIOD.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.TIME_PERIOD.Name = "TIME_PERIOD";
            this.TIME_PERIOD.Size = new System.Drawing.Size(55, 20);
            this.TIME_PERIOD.TabIndex = 53;
            this.TIME_PERIOD.ValueChanged += new System.EventHandler(this.TIME_PERIOD_ValueChanged);
            // 
            // X_OFFSET
            // 
            this.X_OFFSET.Location = new System.Drawing.Point(256, 27);
            this.X_OFFSET.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.X_OFFSET.Name = "X_OFFSET";
            this.X_OFFSET.Size = new System.Drawing.Size(44, 20);
            this.X_OFFSET.TabIndex = 66;
            this.X_OFFSET.ValueChanged += new System.EventHandler(this.X_OFFSET_ValueChanged);
            // 
            // Z_OFFSET
            // 
            this.Z_OFFSET.Location = new System.Drawing.Point(256, 79);
            this.Z_OFFSET.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.Z_OFFSET.Name = "Z_OFFSET";
            this.Z_OFFSET.Size = new System.Drawing.Size(44, 20);
            this.Z_OFFSET.TabIndex = 67;
            this.Z_OFFSET.ValueChanged += new System.EventHandler(this.Z_OFFSET_ValueChanged);
            // 
            // Y_OFFSET
            // 
            this.Y_OFFSET.Location = new System.Drawing.Point(256, 53);
            this.Y_OFFSET.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.Y_OFFSET.Name = "Y_OFFSET";
            this.Y_OFFSET.Size = new System.Drawing.Size(44, 20);
            this.Y_OFFSET.TabIndex = 68;
            this.Y_OFFSET.ValueChanged += new System.EventHandler(this.Y_OFFSET_ValueChanged);
            // 
            // A_OFFSET
            // 
            this.A_OFFSET.Location = new System.Drawing.Point(256, 105);
            this.A_OFFSET.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.A_OFFSET.Name = "A_OFFSET";
            this.A_OFFSET.Size = new System.Drawing.Size(44, 20);
            this.A_OFFSET.TabIndex = 69;
            this.A_OFFSET.ValueChanged += new System.EventHandler(this.A_OFFSET_ValueChanged);
            // 
            // label_ZOffset
            // 
            this.label_ZOffset.AutoSize = true;
            this.label_ZOffset.Location = new System.Drawing.Point(205, 81);
            this.label_ZOffset.Name = "label_ZOffset";
            this.label_ZOffset.Size = new System.Drawing.Size(45, 13);
            this.label_ZOffset.TabIndex = 73;
            this.label_ZOffset.Text = "Z Offset";
            // 
            // label_YOffset
            // 
            this.label_YOffset.AutoSize = true;
            this.label_YOffset.Location = new System.Drawing.Point(205, 55);
            this.label_YOffset.Name = "label_YOffset";
            this.label_YOffset.Size = new System.Drawing.Size(45, 13);
            this.label_YOffset.TabIndex = 70;
            this.label_YOffset.Text = "Y Offset";
            // 
            // label_XOffset
            // 
            this.label_XOffset.AutoSize = true;
            this.label_XOffset.Location = new System.Drawing.Point(205, 29);
            this.label_XOffset.Name = "label_XOffset";
            this.label_XOffset.Size = new System.Drawing.Size(45, 13);
            this.label_XOffset.TabIndex = 72;
            this.label_XOffset.Text = "X Offset";
            // 
            // label_AOffset
            // 
            this.label_AOffset.AutoSize = true;
            this.label_AOffset.Location = new System.Drawing.Point(206, 107);
            this.label_AOffset.Name = "label_AOffset";
            this.label_AOffset.Size = new System.Drawing.Size(45, 13);
            this.label_AOffset.TabIndex = 71;
            this.label_AOffset.Text = "A Offset";
            // 
            // groupBox_RobotState
            // 
            this.groupBox_RobotState.Controls.Add(this.label_InsuranceCounter);
            this.groupBox_RobotState.Controls.Add(this.numericUpDown_InsuranceCounter);
            this.groupBox_RobotState.Controls.Add(this.label_RobotState);
            this.groupBox_RobotState.Controls.Add(this.label_RobotStateLAble);
            this.groupBox_RobotState.Controls.Add(this.checkBox_IMUChart);
            this.groupBox_RobotState.Controls.Add(this.button_CloseIMU);
            this.groupBox_RobotState.Controls.Add(this.button_OpenIMU);
            this.groupBox_RobotState.Controls.Add(this.button_RefreshPorts);
            this.groupBox_RobotState.Controls.Add(this.label_PortName);
            this.groupBox_RobotState.Controls.Add(this.comboBox_PortName);
            this.groupBox_RobotState.Controls.Add(this.checkBox_IMU_Timer);
            this.groupBox_RobotState.Controls.Add(this.label_FallSide_Left);
            this.groupBox_RobotState.Controls.Add(this.numericUpDown_FallSide_Right);
            this.groupBox_RobotState.Controls.Add(this.label_FallSide_Right);
            this.groupBox_RobotState.Controls.Add(this.numericUpDown_FallSide_Left);
            this.groupBox_RobotState.Controls.Add(this.numericUpDown_RollZeroOffset);
            this.groupBox_RobotState.Controls.Add(this.groupBox_IMUData);
            this.groupBox_RobotState.Controls.Add(this.numericUpDown_IsFalling);
            this.groupBox_RobotState.Controls.Add(this.label_RollZeroOffset);
            this.groupBox_RobotState.Controls.Add(this.label_FallBack);
            this.groupBox_RobotState.Controls.Add(this.numericUpDown_RollZero);
            this.groupBox_RobotState.Controls.Add(this.label_RollZero);
            this.groupBox_RobotState.Controls.Add(this.numericUpDown_FallFront);
            this.groupBox_RobotState.Controls.Add(this.numericUpDown_PitchZeroOffset);
            this.groupBox_RobotState.Controls.Add(this.label_FallFront);
            this.groupBox_RobotState.Controls.Add(this.numericUpDown_FallBack);
            this.groupBox_RobotState.Controls.Add(this.labelPitchZeroOffset);
            this.groupBox_RobotState.Controls.Add(this.label_IsFalling);
            this.groupBox_RobotState.Controls.Add(this.label_PitchZero);
            this.groupBox_RobotState.Controls.Add(this.numericUpDown_PitchZero0);
            this.groupBox_RobotState.Location = new System.Drawing.Point(6, 6);
            this.groupBox_RobotState.Name = "groupBox_RobotState";
            this.groupBox_RobotState.Size = new System.Drawing.Size(324, 293);
            this.groupBox_RobotState.TabIndex = 145;
            this.groupBox_RobotState.TabStop = false;
            this.groupBox_RobotState.Text = "Robot State";
            // 
            // label_InsuranceCounter
            // 
            this.label_InsuranceCounter.AutoSize = true;
            this.label_InsuranceCounter.Location = new System.Drawing.Point(180, 265);
            this.label_InsuranceCounter.Name = "label_InsuranceCounter";
            this.label_InsuranceCounter.Size = new System.Drawing.Size(63, 13);
            this.label_InsuranceCounter.TabIndex = 164;
            this.label_InsuranceCounter.Text = "Fall Counter";
            // 
            // numericUpDown_InsuranceCounter
            // 
            this.numericUpDown_InsuranceCounter.Location = new System.Drawing.Point(249, 262);
            this.numericUpDown_InsuranceCounter.Name = "numericUpDown_InsuranceCounter";
            this.numericUpDown_InsuranceCounter.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_InsuranceCounter.TabIndex = 163;
            this.numericUpDown_InsuranceCounter.ValueChanged += new System.EventHandler(this.numericUpDown_InsuranceCounter_ValueChanged);
            // 
            // label_RobotState
            // 
            this.label_RobotState.AutoSize = true;
            this.label_RobotState.Location = new System.Drawing.Point(93, 264);
            this.label_RobotState.Name = "label_RobotState";
            this.label_RobotState.Size = new System.Drawing.Size(64, 13);
            this.label_RobotState.TabIndex = 162;
            this.label_RobotState.Text = "Robot State";
            // 
            // label_RobotStateLAble
            // 
            this.label_RobotStateLAble.AutoSize = true;
            this.label_RobotStateLAble.Location = new System.Drawing.Point(15, 264);
            this.label_RobotStateLAble.Name = "label_RobotStateLAble";
            this.label_RobotStateLAble.Size = new System.Drawing.Size(73, 13);
            this.label_RobotStateLAble.TabIndex = 161;
            this.label_RobotStateLAble.Text = "Robot State : ";
            // 
            // checkBox_IMUChart
            // 
            this.checkBox_IMUChart.AutoSize = true;
            this.checkBox_IMUChart.Location = new System.Drawing.Point(269, 33);
            this.checkBox_IMUChart.Name = "checkBox_IMUChart";
            this.checkBox_IMUChart.Size = new System.Drawing.Size(51, 17);
            this.checkBox_IMUChart.TabIndex = 160;
            this.checkBox_IMUChart.Text = "Chart";
            this.checkBox_IMUChart.UseVisualStyleBackColor = true;
            this.checkBox_IMUChart.CheckedChanged += new System.EventHandler(this.checkBox_IMUChart_CheckedChanged);
            // 
            // button_CloseIMU
            // 
            this.button_CloseIMU.BackgroundImage = global::Robot.Locomotion.Properties.Resources.Disconnect;
            this.button_CloseIMU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_CloseIMU.Location = new System.Drawing.Point(237, 28);
            this.button_CloseIMU.Name = "button_CloseIMU";
            this.button_CloseIMU.Size = new System.Drawing.Size(25, 23);
            this.button_CloseIMU.TabIndex = 159;
            this.button_CloseIMU.UseVisualStyleBackColor = true;
            // 
            // button_OpenIMU
            // 
            this.button_OpenIMU.BackgroundImage = global::Robot.Locomotion.Properties.Resources.Connect;
            this.button_OpenIMU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OpenIMU.Location = new System.Drawing.Point(211, 28);
            this.button_OpenIMU.Name = "button_OpenIMU";
            this.button_OpenIMU.Size = new System.Drawing.Size(25, 23);
            this.button_OpenIMU.TabIndex = 158;
            this.button_OpenIMU.UseVisualStyleBackColor = true;
            // 
            // button_RefreshPorts
            // 
            this.button_RefreshPorts.BackgroundImage = global::Robot.Locomotion.Properties.Resources.refresh;
            this.button_RefreshPorts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_RefreshPorts.Location = new System.Drawing.Point(176, 28);
            this.button_RefreshPorts.Name = "button_RefreshPorts";
            this.button_RefreshPorts.Size = new System.Drawing.Size(25, 23);
            this.button_RefreshPorts.TabIndex = 157;
            this.button_RefreshPorts.UseVisualStyleBackColor = true;
            this.button_RefreshPorts.Click += new System.EventHandler(this.button_RefreshPorts_Click);
            // 
            // label_PortName
            // 
            this.label_PortName.AutoSize = true;
            this.label_PortName.Location = new System.Drawing.Point(108, 14);
            this.label_PortName.Name = "label_PortName";
            this.label_PortName.Size = new System.Drawing.Size(54, 13);
            this.label_PortName.TabIndex = 156;
            this.label_PortName.Text = "PortName";
            // 
            // comboBox_PortName
            // 
            this.comboBox_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PortName.FormattingEnabled = true;
            this.comboBox_PortName.Location = new System.Drawing.Point(94, 30);
            this.comboBox_PortName.Name = "comboBox_PortName";
            this.comboBox_PortName.Size = new System.Drawing.Size(77, 21);
            this.comboBox_PortName.TabIndex = 155;
            // 
            // checkBox_IMU_Timer
            // 
            this.checkBox_IMU_Timer.AutoSize = true;
            this.checkBox_IMU_Timer.Location = new System.Drawing.Point(16, 34);
            this.checkBox_IMU_Timer.Name = "checkBox_IMU_Timer";
            this.checkBox_IMU_Timer.Size = new System.Drawing.Size(72, 17);
            this.checkBox_IMU_Timer.TabIndex = 154;
            this.checkBox_IMU_Timer.Text = "IMU Data";
            this.checkBox_IMU_Timer.UseVisualStyleBackColor = true;
            this.checkBox_IMU_Timer.CheckedChanged += new System.EventHandler(this.checkBox_IMU_Timer_CheckedChanged);
            // 
            // label_FallSide_Left
            // 
            this.label_FallSide_Left.AutoSize = true;
            this.label_FallSide_Left.Location = new System.Drawing.Point(175, 173);
            this.label_FallSide_Left.Name = "label_FallSide_Left";
            this.label_FallSide_Left.Size = new System.Drawing.Size(68, 13);
            this.label_FallSide_Left.TabIndex = 153;
            this.label_FallSide_Left.Text = " FallSide Left";
            // 
            // numericUpDown_FallSide_Right
            // 
            this.numericUpDown_FallSide_Right.DecimalPlaces = 2;
            this.numericUpDown_FallSide_Right.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_FallSide_Right.Location = new System.Drawing.Point(248, 144);
            this.numericUpDown_FallSide_Right.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_FallSide_Right.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown_FallSide_Right.Name = "numericUpDown_FallSide_Right";
            this.numericUpDown_FallSide_Right.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown_FallSide_Right.TabIndex = 150;
            this.numericUpDown_FallSide_Right.ValueChanged += new System.EventHandler(this.numericUpDown_FallSide_Right_ValueChanged);
            // 
            // label_FallSide_Right
            // 
            this.label_FallSide_Right.AutoSize = true;
            this.label_FallSide_Right.Location = new System.Drawing.Point(172, 146);
            this.label_FallSide_Right.Name = "label_FallSide_Right";
            this.label_FallSide_Right.Size = new System.Drawing.Size(75, 13);
            this.label_FallSide_Right.TabIndex = 152;
            this.label_FallSide_Right.Text = " FallSide Right";
            // 
            // numericUpDown_FallSide_Left
            // 
            this.numericUpDown_FallSide_Left.DecimalPlaces = 2;
            this.numericUpDown_FallSide_Left.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_FallSide_Left.Location = new System.Drawing.Point(248, 170);
            this.numericUpDown_FallSide_Left.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_FallSide_Left.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown_FallSide_Left.Name = "numericUpDown_FallSide_Left";
            this.numericUpDown_FallSide_Left.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown_FallSide_Left.TabIndex = 151;
            this.numericUpDown_FallSide_Left.ValueChanged += new System.EventHandler(this.numericUpDown_FallSide_Left_ValueChanged);
            // 
            // numericUpDown_RollZeroOffset
            // 
            this.numericUpDown_RollZeroOffset.DecimalPlaces = 2;
            this.numericUpDown_RollZeroOffset.Location = new System.Drawing.Point(91, 226);
            this.numericUpDown_RollZeroOffset.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_RollZeroOffset.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown_RollZeroOffset.Name = "numericUpDown_RollZeroOffset";
            this.numericUpDown_RollZeroOffset.ReadOnly = true;
            this.numericUpDown_RollZeroOffset.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_RollZeroOffset.TabIndex = 148;
            // 
            // groupBox_IMUData
            // 
            this.groupBox_IMUData.Controls.Add(this.label_CompassOffset);
            this.groupBox_IMUData.Controls.Add(this.numericUpDown_CompassOffset);
            this.groupBox_IMUData.Controls.Add(this.numericUpDown_IMU_Pitch);
            this.groupBox_IMUData.Controls.Add(this.label_IMU_Yaw);
            this.groupBox_IMUData.Controls.Add(this.numericUpDown_IMU_Roll);
            this.groupBox_IMUData.Controls.Add(this.label_IMU_Roll);
            this.groupBox_IMUData.Controls.Add(this.numericUpDown_IMU_Yaw);
            this.groupBox_IMUData.Controls.Add(this.label_IMU_pitch);
            this.groupBox_IMUData.Location = new System.Drawing.Point(14, 55);
            this.groupBox_IMUData.Name = "groupBox_IMUData";
            this.groupBox_IMUData.Size = new System.Drawing.Size(155, 135);
            this.groupBox_IMUData.TabIndex = 144;
            this.groupBox_IMUData.TabStop = false;
            this.groupBox_IMUData.Text = "IMU";
            // 
            // label_CompassOffset
            // 
            this.label_CompassOffset.AutoSize = true;
            this.label_CompassOffset.Location = new System.Drawing.Point(8, 107);
            this.label_CompassOffset.Name = "label_CompassOffset";
            this.label_CompassOffset.Size = new System.Drawing.Size(59, 13);
            this.label_CompassOffset.TabIndex = 145;
            this.label_CompassOffset.Text = "Yaw-Offset";
            // 
            // numericUpDown_CompassOffset
            // 
            this.numericUpDown_CompassOffset.DecimalPlaces = 2;
            this.numericUpDown_CompassOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_CompassOffset.Location = new System.Drawing.Point(78, 105);
            this.numericUpDown_CompassOffset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_CompassOffset.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown_CompassOffset.Name = "numericUpDown_CompassOffset";
            this.numericUpDown_CompassOffset.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown_CompassOffset.TabIndex = 144;
            this.numericUpDown_CompassOffset.ValueChanged += new System.EventHandler(this.numericUpDown_CompassOffset_ValueChanged);
            // 
            // numericUpDown_IMU_Pitch
            // 
            this.numericUpDown_IMU_Pitch.DecimalPlaces = 2;
            this.numericUpDown_IMU_Pitch.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_IMU_Pitch.Location = new System.Drawing.Point(78, 17);
            this.numericUpDown_IMU_Pitch.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_IMU_Pitch.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown_IMU_Pitch.Name = "numericUpDown_IMU_Pitch";
            this.numericUpDown_IMU_Pitch.ReadOnly = true;
            this.numericUpDown_IMU_Pitch.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown_IMU_Pitch.TabIndex = 129;
            // 
            // label_IMU_Yaw
            // 
            this.label_IMU_Yaw.AutoSize = true;
            this.label_IMU_Yaw.Location = new System.Drawing.Point(14, 68);
            this.label_IMU_Yaw.Name = "label_IMU_Yaw";
            this.label_IMU_Yaw.Size = new System.Drawing.Size(28, 13);
            this.label_IMU_Yaw.TabIndex = 143;
            this.label_IMU_Yaw.Text = "Yaw";
            // 
            // numericUpDown_IMU_Roll
            // 
            this.numericUpDown_IMU_Roll.DecimalPlaces = 2;
            this.numericUpDown_IMU_Roll.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_IMU_Roll.Location = new System.Drawing.Point(78, 43);
            this.numericUpDown_IMU_Roll.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_IMU_Roll.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown_IMU_Roll.Name = "numericUpDown_IMU_Roll";
            this.numericUpDown_IMU_Roll.ReadOnly = true;
            this.numericUpDown_IMU_Roll.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown_IMU_Roll.TabIndex = 131;
            // 
            // label_IMU_Roll
            // 
            this.label_IMU_Roll.AutoSize = true;
            this.label_IMU_Roll.Location = new System.Drawing.Point(14, 43);
            this.label_IMU_Roll.Name = "label_IMU_Roll";
            this.label_IMU_Roll.Size = new System.Drawing.Size(25, 13);
            this.label_IMU_Roll.TabIndex = 142;
            this.label_IMU_Roll.Text = "Roll";
            // 
            // numericUpDown_IMU_Yaw
            // 
            this.numericUpDown_IMU_Yaw.DecimalPlaces = 2;
            this.numericUpDown_IMU_Yaw.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_IMU_Yaw.Location = new System.Drawing.Point(78, 69);
            this.numericUpDown_IMU_Yaw.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_IMU_Yaw.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown_IMU_Yaw.Name = "numericUpDown_IMU_Yaw";
            this.numericUpDown_IMU_Yaw.ReadOnly = true;
            this.numericUpDown_IMU_Yaw.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown_IMU_Yaw.TabIndex = 133;
            // 
            // label_IMU_pitch
            // 
            this.label_IMU_pitch.AutoSize = true;
            this.label_IMU_pitch.Location = new System.Drawing.Point(14, 19);
            this.label_IMU_pitch.Name = "label_IMU_pitch";
            this.label_IMU_pitch.Size = new System.Drawing.Size(31, 13);
            this.label_IMU_pitch.TabIndex = 141;
            this.label_IMU_pitch.Text = "Pitch";
            // 
            // numericUpDown_IsFalling
            // 
            this.numericUpDown_IsFalling.DecimalPlaces = 2;
            this.numericUpDown_IsFalling.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_IsFalling.Location = new System.Drawing.Point(248, 60);
            this.numericUpDown_IsFalling.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_IsFalling.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown_IsFalling.Name = "numericUpDown_IsFalling";
            this.numericUpDown_IsFalling.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown_IsFalling.TabIndex = 129;
            this.numericUpDown_IsFalling.ValueChanged += new System.EventHandler(this.numericUpDown_IsFalling_ValueChanged);
            // 
            // label_RollZeroOffset
            // 
            this.label_RollZeroOffset.AutoSize = true;
            this.label_RollZeroOffset.Location = new System.Drawing.Point(7, 229);
            this.label_RollZeroOffset.Name = "label_RollZeroOffset";
            this.label_RollZeroOffset.Size = new System.Drawing.Size(81, 13);
            this.label_RollZeroOffset.TabIndex = 149;
            this.label_RollZeroOffset.Text = "Roll Zero Offset";
            // 
            // label_FallBack
            // 
            this.label_FallBack.AutoSize = true;
            this.label_FallBack.Location = new System.Drawing.Point(181, 115);
            this.label_FallBack.Name = "label_FallBack";
            this.label_FallBack.Size = new System.Drawing.Size(51, 13);
            this.label_FallBack.TabIndex = 143;
            this.label_FallBack.Text = "Fall Back";
            // 
            // numericUpDown_RollZero
            // 
            this.numericUpDown_RollZero.DecimalPlaces = 2;
            this.numericUpDown_RollZero.Location = new System.Drawing.Point(91, 202);
            this.numericUpDown_RollZero.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_RollZero.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown_RollZero.Name = "numericUpDown_RollZero";
            this.numericUpDown_RollZero.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_RollZero.TabIndex = 146;
            this.numericUpDown_RollZero.ValueChanged += new System.EventHandler(this.numericUpDown_RollZero_ValueChanged);
            // 
            // label_RollZero
            // 
            this.label_RollZero.AutoSize = true;
            this.label_RollZero.Location = new System.Drawing.Point(32, 205);
            this.label_RollZero.Name = "label_RollZero";
            this.label_RollZero.Size = new System.Drawing.Size(50, 13);
            this.label_RollZero.TabIndex = 147;
            this.label_RollZero.Text = "Roll Zero";
            // 
            // numericUpDown_FallFront
            // 
            this.numericUpDown_FallFront.DecimalPlaces = 2;
            this.numericUpDown_FallFront.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_FallFront.Location = new System.Drawing.Point(248, 90);
            this.numericUpDown_FallFront.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_FallFront.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown_FallFront.Name = "numericUpDown_FallFront";
            this.numericUpDown_FallFront.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown_FallFront.TabIndex = 131;
            this.numericUpDown_FallFront.ValueChanged += new System.EventHandler(this.numericUpDown_FallFront_ValueChanged);
            // 
            // numericUpDown_PitchZeroOffset
            // 
            this.numericUpDown_PitchZeroOffset.DecimalPlaces = 2;
            this.numericUpDown_PitchZeroOffset.Location = new System.Drawing.Point(249, 226);
            this.numericUpDown_PitchZeroOffset.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_PitchZeroOffset.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown_PitchZeroOffset.Name = "numericUpDown_PitchZeroOffset";
            this.numericUpDown_PitchZeroOffset.ReadOnly = true;
            this.numericUpDown_PitchZeroOffset.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_PitchZeroOffset.TabIndex = 144;
            // 
            // label_FallFront
            // 
            this.label_FallFront.AutoSize = true;
            this.label_FallFront.Location = new System.Drawing.Point(181, 90);
            this.label_FallFront.Name = "label_FallFront";
            this.label_FallFront.Size = new System.Drawing.Size(50, 13);
            this.label_FallFront.TabIndex = 142;
            this.label_FallFront.Text = "Fall Front";
            // 
            // numericUpDown_FallBack
            // 
            this.numericUpDown_FallBack.DecimalPlaces = 2;
            this.numericUpDown_FallBack.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_FallBack.Location = new System.Drawing.Point(248, 116);
            this.numericUpDown_FallBack.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_FallBack.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown_FallBack.Name = "numericUpDown_FallBack";
            this.numericUpDown_FallBack.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown_FallBack.TabIndex = 133;
            this.numericUpDown_FallBack.ValueChanged += new System.EventHandler(this.numericUpDown_FallBack_ValueChanged);
            // 
            // labelPitchZeroOffset
            // 
            this.labelPitchZeroOffset.AutoSize = true;
            this.labelPitchZeroOffset.Location = new System.Drawing.Point(158, 229);
            this.labelPitchZeroOffset.Name = "labelPitchZeroOffset";
            this.labelPitchZeroOffset.Size = new System.Drawing.Size(87, 13);
            this.labelPitchZeroOffset.TabIndex = 145;
            this.labelPitchZeroOffset.Text = "Pitch Zero Offset";
            // 
            // label_IsFalling
            // 
            this.label_IsFalling.AutoSize = true;
            this.label_IsFalling.Location = new System.Drawing.Point(181, 62);
            this.label_IsFalling.Name = "label_IsFalling";
            this.label_IsFalling.Size = new System.Drawing.Size(48, 13);
            this.label_IsFalling.TabIndex = 141;
            this.label_IsFalling.Text = "Is Falling";
            // 
            // label_PitchZero
            // 
            this.label_PitchZero.AutoSize = true;
            this.label_PitchZero.Location = new System.Drawing.Point(183, 203);
            this.label_PitchZero.Name = "label_PitchZero";
            this.label_PitchZero.Size = new System.Drawing.Size(56, 13);
            this.label_PitchZero.TabIndex = 118;
            this.label_PitchZero.Text = "Pitch Zero";
            // 
            // numericUpDown_PitchZero0
            // 
            this.numericUpDown_PitchZero0.DecimalPlaces = 2;
            this.numericUpDown_PitchZero0.Location = new System.Drawing.Point(249, 200);
            this.numericUpDown_PitchZero0.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown_PitchZero0.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown_PitchZero0.Name = "numericUpDown_PitchZero0";
            this.numericUpDown_PitchZero0.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown_PitchZero0.TabIndex = 117;
            this.numericUpDown_PitchZero0.ValueChanged += new System.EventHandler(this.numericUpDown_PitchZero0_ValueChanged);
            // 
            // groupBox_Stabilization
            // 
            this.groupBox_Stabilization.Controls.Add(this.numericUpDown_HandLowPassGain);
            this.groupBox_Stabilization.Controls.Add(this.label6);
            this.groupBox_Stabilization.Controls.Add(this.numericUpDown_GyroD);
            this.groupBox_Stabilization.Controls.Add(this.label1);
            this.groupBox_Stabilization.Controls.Add(this.numericUpDown_GyroP);
            this.groupBox_Stabilization.Controls.Add(this.label3);
            this.groupBox_Stabilization.Controls.Add(this.numericUpDown_AnkleLowPassGain);
            this.groupBox_Stabilization.Controls.Add(this.label_PitchOffsetGain);
            this.groupBox_Stabilization.Controls.Add(this.numericUpDown_HandPitchGain);
            this.groupBox_Stabilization.Controls.Add(this.label_HandPitchGain);
            this.groupBox_Stabilization.Controls.Add(this.checkBox_Stabilization);
            this.groupBox_Stabilization.Location = new System.Drawing.Point(335, 12);
            this.groupBox_Stabilization.Name = "groupBox_Stabilization";
            this.groupBox_Stabilization.Size = new System.Drawing.Size(192, 218);
            this.groupBox_Stabilization.TabIndex = 135;
            this.groupBox_Stabilization.TabStop = false;
            this.groupBox_Stabilization.Text = "Stabilization";
            // 
            // numericUpDown_HandLowPassGain
            // 
            this.numericUpDown_HandLowPassGain.DecimalPlaces = 2;
            this.numericUpDown_HandLowPassGain.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_HandLowPassGain.Location = new System.Drawing.Point(125, 82);
            this.numericUpDown_HandLowPassGain.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_HandLowPassGain.Name = "numericUpDown_HandLowPassGain";
            this.numericUpDown_HandLowPassGain.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown_HandLowPassGain.TabIndex = 162;
            this.numericUpDown_HandLowPassGain.ValueChanged += new System.EventHandler(this.numericUpDown_HandLowPassGain_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 163;
            this.label6.Text = "HandLowPass Gain";
            // 
            // numericUpDown_GyroD
            // 
            this.numericUpDown_GyroD.DecimalPlaces = 2;
            this.numericUpDown_GyroD.Location = new System.Drawing.Point(116, 179);
            this.numericUpDown_GyroD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_GyroD.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_GyroD.Name = "numericUpDown_GyroD";
            this.numericUpDown_GyroD.Size = new System.Drawing.Size(70, 20);
            this.numericUpDown_GyroD.TabIndex = 156;
            this.numericUpDown_GyroD.ValueChanged += new System.EventHandler(this.numericUpDown_GyroD_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 157;
            this.label1.Text = "GyroD";
            // 
            // numericUpDown_GyroP
            // 
            this.numericUpDown_GyroP.DecimalPlaces = 2;
            this.numericUpDown_GyroP.Location = new System.Drawing.Point(116, 153);
            this.numericUpDown_GyroP.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_GyroP.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_GyroP.Name = "numericUpDown_GyroP";
            this.numericUpDown_GyroP.Size = new System.Drawing.Size(70, 20);
            this.numericUpDown_GyroP.TabIndex = 154;
            this.numericUpDown_GyroP.ValueChanged += new System.EventHandler(this.numericUpDown_GyroP_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 155;
            this.label3.Text = "GyroP";
            // 
            // numericUpDown_AnkleLowPassGain
            // 
            this.numericUpDown_AnkleLowPassGain.DecimalPlaces = 2;
            this.numericUpDown_AnkleLowPassGain.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_AnkleLowPassGain.Location = new System.Drawing.Point(139, 123);
            this.numericUpDown_AnkleLowPassGain.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_AnkleLowPassGain.Name = "numericUpDown_AnkleLowPassGain";
            this.numericUpDown_AnkleLowPassGain.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown_AnkleLowPassGain.TabIndex = 150;
            this.numericUpDown_AnkleLowPassGain.ValueChanged += new System.EventHandler(this.numericUpDown_AnkleLowPassGain_ValueChanged);
            // 
            // label_PitchOffsetGain
            // 
            this.label_PitchOffsetGain.AutoSize = true;
            this.label_PitchOffsetGain.Location = new System.Drawing.Point(12, 125);
            this.label_PitchOffsetGain.Name = "label_PitchOffsetGain";
            this.label_PitchOffsetGain.Size = new System.Drawing.Size(121, 13);
            this.label_PitchOffsetGain.TabIndex = 151;
            this.label_PitchOffsetGain.Text = "AnkleGyroLowPassGain";
            // 
            // numericUpDown_HandPitchGain
            // 
            this.numericUpDown_HandPitchGain.DecimalPlaces = 2;
            this.numericUpDown_HandPitchGain.Location = new System.Drawing.Point(125, 59);
            this.numericUpDown_HandPitchGain.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_HandPitchGain.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numericUpDown_HandPitchGain.Name = "numericUpDown_HandPitchGain";
            this.numericUpDown_HandPitchGain.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown_HandPitchGain.TabIndex = 148;
            this.numericUpDown_HandPitchGain.ValueChanged += new System.EventHandler(this.numericUpDown_HandPitchGain_ValueChanged);
            // 
            // label_HandPitchGain
            // 
            this.label_HandPitchGain.AutoSize = true;
            this.label_HandPitchGain.Location = new System.Drawing.Point(16, 61);
            this.label_HandPitchGain.Name = "label_HandPitchGain";
            this.label_HandPitchGain.Size = new System.Drawing.Size(79, 13);
            this.label_HandPitchGain.TabIndex = 149;
            this.label_HandPitchGain.Text = "HandPitchGain";
            // 
            // checkBox_Stabilization
            // 
            this.checkBox_Stabilization.AutoSize = true;
            this.checkBox_Stabilization.Location = new System.Drawing.Point(19, 31);
            this.checkBox_Stabilization.Name = "checkBox_Stabilization";
            this.checkBox_Stabilization.Size = new System.Drawing.Size(59, 17);
            this.checkBox_Stabilization.TabIndex = 139;
            this.checkBox_Stabilization.Text = "Enable";
            this.checkBox_Stabilization.UseVisualStyleBackColor = true;
            this.checkBox_Stabilization.CheckedChanged += new System.EventHandler(this.checkBox_Stabilization_CheckedChanged);
            // 
            // dataGridView_ActuatorsDirection
            // 
            this.dataGridView_ActuatorsDirection.AllowUserToAddRows = false;
            this.dataGridView_ActuatorsDirection.AllowUserToDeleteRows = false;
            this.dataGridView_ActuatorsDirection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ActuatorsDirection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DirectionJointName,
            this.JointDirection});
            this.dataGridView_ActuatorsDirection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_ActuatorsDirection.Location = new System.Drawing.Point(534, 12);
            this.dataGridView_ActuatorsDirection.Name = "dataGridView_ActuatorsDirection";
            this.dataGridView_ActuatorsDirection.RowHeadersVisible = false;
            this.dataGridView_ActuatorsDirection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ActuatorsDirection.Size = new System.Drawing.Size(173, 287);
            this.dataGridView_ActuatorsDirection.TabIndex = 79;
            this.dataGridView_ActuatorsDirection.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ActuatorsDirection_CellEndEdit);
            // 
            // DirectionJointName
            // 
            this.DirectionJointName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DirectionJointName.HeaderText = "Joint Name";
            this.DirectionJointName.Name = "DirectionJointName";
            this.DirectionJointName.ReadOnly = true;
            this.DirectionJointName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DirectionJointName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // JointDirection
            // 
            this.JointDirection.HeaderText = "Dir";
            this.JointDirection.Name = "JointDirection";
            this.JointDirection.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.JointDirection.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.JointDirection.Width = 50;
            // 
            // openFileDialog_XmlInput
            // 
            this.openFileDialog_XmlInput.Filter = "Xml Files|*.xml";
            // 
            // saveFileDialog_XmlOutput
            // 
            this.saveFileDialog_XmlOutput.Filter = "Xml Files|*.xml";
            // 
            // toolStrip_MainToolbar
            // 
            this.toolStrip_MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_New,
            this.ToolStripButton_Open,
            this.ToolStripButton_Save,
            this.toolStripSeparator,
            this.toolStripLabel_Port,
            this.toolStripComboBox_Port,
            this.toolStripButton_Refresh,
            this.toolStripButton_Connect,
            this.toolStripButton_Disonnect,
            this.toolStripSeparator1});
            this.toolStrip_MainToolbar.Location = new System.Drawing.Point(0, 24);
            this.toolStrip_MainToolbar.Name = "toolStrip_MainToolbar";
            this.toolStrip_MainToolbar.Size = new System.Drawing.Size(1090, 25);
            this.toolStrip_MainToolbar.TabIndex = 12;
            this.toolStrip_MainToolbar.Text = "toolStrip1";
            // 
            // ToolStripButton_New
            // 
            this.ToolStripButton_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_New.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_New.Image")));
            this.ToolStripButton_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_New.Name = "ToolStripButton_New";
            this.ToolStripButton_New.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton_New.Text = "New";
            this.ToolStripButton_New.Click += new System.EventHandler(this.ToolStripButtonNewClick);
            // 
            // ToolStripButton_Open
            // 
            this.ToolStripButton_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_Open.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Open.Image")));
            this.ToolStripButton_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Open.Name = "ToolStripButton_Open";
            this.ToolStripButton_Open.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton_Open.Text = "Open";
            this.ToolStripButton_Open.Click += new System.EventHandler(this.ToolStripButtonOpenClick);
            // 
            // ToolStripButton_Save
            // 
            this.ToolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_Save.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Save.Image")));
            this.ToolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Save.Name = "ToolStripButton_Save";
            this.ToolStripButton_Save.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton_Save.Text = "Save";
            this.ToolStripButton_Save.Click += new System.EventHandler(this.ToolStripButtonSaveClick);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_Port
            // 
            this.toolStripLabel_Port.Name = "toolStripLabel_Port";
            this.toolStripLabel_Port.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel_Port.Text = "Port : ";
            // 
            // toolStripComboBox_Port
            // 
            this.toolStripComboBox_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_Port.Name = "toolStripComboBox_Port";
            this.toolStripComboBox_Port.Size = new System.Drawing.Size(75, 25);
            this.toolStripComboBox_Port.Click += new System.EventHandler(this.toolStripComboBox_Port_Click);
            // 
            // toolStripButton_Refresh
            // 
            this.toolStripButton_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Refresh.Image = global::Robot.Locomotion.Properties.Resources.refresh;
            this.toolStripButton_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Refresh.Name = "toolStripButton_Refresh";
            this.toolStripButton_Refresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Refresh.Text = "toolStripButton_Refresh";
            this.toolStripButton_Refresh.Click += new System.EventHandler(this.ToolStripButtonRefreshPortsClick);
            // 
            // toolStripButton_Connect
            // 
            this.toolStripButton_Connect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Connect.Image = global::Robot.Locomotion.Properties.Resources.Connect;
            this.toolStripButton_Connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Connect.Name = "toolStripButton_Connect";
            this.toolStripButton_Connect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Connect.Text = "toolStripButton_Connect";
            this.toolStripButton_Connect.Click += new System.EventHandler(this.ToolStripButtonConnectClick);
            // 
            // toolStripButton_Disonnect
            // 
            this.toolStripButton_Disonnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Disonnect.Image = global::Robot.Locomotion.Properties.Resources.Disconnect;
            this.toolStripButton_Disonnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Disonnect.Name = "toolStripButton_Disonnect";
            this.toolStripButton_Disonnect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Disonnect.Text = "toolStripButton_Disconnect";
            this.toolStripButton_Disonnect.Click += new System.EventHandler(this.ToolStripButtonDisconnectClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // timer_IMU
            // 
            this.timer_IMU.Interval = 10;
            this.timer_IMU.Tick += new System.EventHandler(this.timer_IMU_Tick);
            // 
            // timer_WalkMove
            // 
            this.timer_WalkMove.Enabled = true;
            this.timer_WalkMove.Interval = 5;
            this.timer_WalkMove.Tick += new System.EventHandler(this.timer_WalkMove_Tick);
            // 
            // button_LeftKickLittle
            // 
            this.button_LeftKickLittle.BackgroundImage = global::Robot.Locomotion.Properties.Resources.player_play;
            this.button_LeftKickLittle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_LeftKickLittle.Location = new System.Drawing.Point(271, 43);
            this.button_LeftKickLittle.Name = "button_LeftKickLittle";
            this.button_LeftKickLittle.Size = new System.Drawing.Size(24, 22);
            this.button_LeftKickLittle.TabIndex = 161;
            this.button_LeftKickLittle.UseVisualStyleBackColor = true;
            this.button_LeftKickLittle.Click += new System.EventHandler(this.button_LeftKickLittle_Click);
            // 
            // button_LeftKick
            // 
            this.button_LeftKick.BackgroundImage = global::Robot.Locomotion.Properties.Resources.player_play;
            this.button_LeftKick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_LeftKick.Location = new System.Drawing.Point(272, 18);
            this.button_LeftKick.Name = "button_LeftKick";
            this.button_LeftKick.Size = new System.Drawing.Size(24, 22);
            this.button_LeftKick.TabIndex = 160;
            this.button_LeftKick.UseVisualStyleBackColor = true;
            this.button_LeftKick.Click += new System.EventHandler(this.button_LeftKick_Click);
            // 
            // button_Happy
            // 
            this.button_Happy.BackgroundImage = global::Robot.Locomotion.Properties.Resources.player_play;
            this.button_Happy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Happy.Location = new System.Drawing.Point(271, 70);
            this.button_Happy.Name = "button_Happy";
            this.button_Happy.Size = new System.Drawing.Size(24, 22);
            this.button_Happy.TabIndex = 159;
            this.button_Happy.UseVisualStyleBackColor = true;
            this.button_Happy.Click += new System.EventHandler(this.button_Happy_Click);
            // 
            // HappyIndex
            // 
            this.HappyIndex.Location = new System.Drawing.Point(219, 70);
            this.HappyIndex.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.HappyIndex.Name = "HappyIndex";
            this.HappyIndex.Size = new System.Drawing.Size(46, 20);
            this.HappyIndex.TabIndex = 153;
            this.HappyIndex.ValueChanged += new System.EventHandler(this.HappyIndex_ValueChanged);
            // 
            // label_LeftKickLittle
            // 
            this.label_LeftKickLittle.AutoSize = true;
            this.label_LeftKickLittle.Location = new System.Drawing.Point(150, 50);
            this.label_LeftKickLittle.Name = "label_LeftKickLittle";
            this.label_LeftKickLittle.Size = new System.Drawing.Size(68, 13);
            this.label_LeftKickLittle.TabIndex = 158;
            this.label_LeftKickLittle.Text = "LeftKickLittle";
            // 
            // LeftKickIndex
            // 
            this.LeftKickIndex.Location = new System.Drawing.Point(219, 18);
            this.LeftKickIndex.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.LeftKickIndex.Name = "LeftKickIndex";
            this.LeftKickIndex.Size = new System.Drawing.Size(46, 20);
            this.LeftKickIndex.TabIndex = 154;
            this.LeftKickIndex.ValueChanged += new System.EventHandler(this.LeftKickIndex_ValueChanged);
            // 
            // label_LeftKick
            // 
            this.label_LeftKick.AutoSize = true;
            this.label_LeftKick.Location = new System.Drawing.Point(162, 23);
            this.label_LeftKick.Name = "label_LeftKick";
            this.label_LeftKick.Size = new System.Drawing.Size(46, 13);
            this.label_LeftKick.TabIndex = 157;
            this.label_LeftKick.Text = "LeftKick";
            // 
            // LeftKickLittleIndex
            // 
            this.LeftKickLittleIndex.Location = new System.Drawing.Point(219, 46);
            this.LeftKickLittleIndex.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.LeftKickLittleIndex.Name = "LeftKickLittleIndex";
            this.LeftKickLittleIndex.Size = new System.Drawing.Size(46, 20);
            this.LeftKickLittleIndex.TabIndex = 155;
            this.LeftKickLittleIndex.ValueChanged += new System.EventHandler(this.LeftKickLittleIndex_ValueChanged);
            // 
            // label_Happy
            // 
            this.label_Happy.AutoSize = true;
            this.label_Happy.Location = new System.Drawing.Point(162, 77);
            this.label_Happy.Name = "label_Happy";
            this.label_Happy.Size = new System.Drawing.Size(38, 13);
            this.label_Happy.TabIndex = 156;
            this.label_Happy.Text = "Happy";
            // 
            // button_RightKickLittle
            // 
            this.button_RightKickLittle.BackgroundImage = global::Robot.Locomotion.Properties.Resources.player_play;
            this.button_RightKickLittle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_RightKickLittle.Location = new System.Drawing.Point(428, 44);
            this.button_RightKickLittle.Name = "button_RightKickLittle";
            this.button_RightKickLittle.Size = new System.Drawing.Size(24, 22);
            this.button_RightKickLittle.TabIndex = 167;
            this.button_RightKickLittle.UseVisualStyleBackColor = true;
            this.button_RightKickLittle.Click += new System.EventHandler(this.button_RightKickLittle_Click);
            // 
            // button_RightKick
            // 
            this.button_RightKick.BackgroundImage = global::Robot.Locomotion.Properties.Resources.player_play;
            this.button_RightKick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_RightKick.Location = new System.Drawing.Point(429, 19);
            this.button_RightKick.Name = "button_RightKick";
            this.button_RightKick.Size = new System.Drawing.Size(24, 22);
            this.button_RightKick.TabIndex = 166;
            this.button_RightKick.UseVisualStyleBackColor = true;
            this.button_RightKick.Click += new System.EventHandler(this.button_RightKick_Click);
            // 
            // label_RightKickLittle
            // 
            this.label_RightKickLittle.AutoSize = true;
            this.label_RightKickLittle.Location = new System.Drawing.Point(299, 51);
            this.label_RightKickLittle.Name = "label_RightKickLittle";
            this.label_RightKickLittle.Size = new System.Drawing.Size(75, 13);
            this.label_RightKickLittle.TabIndex = 165;
            this.label_RightKickLittle.Text = "RightKickLittle";
            // 
            // RightKick
            // 
            this.RightKick.Location = new System.Drawing.Point(376, 19);
            this.RightKick.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.RightKick.Name = "RightKick";
            this.RightKick.Size = new System.Drawing.Size(46, 20);
            this.RightKick.TabIndex = 162;
            this.RightKick.ValueChanged += new System.EventHandler(this.RightKick_ValueChanged);
            // 
            // label_RightKick
            // 
            this.label_RightKick.AutoSize = true;
            this.label_RightKick.Location = new System.Drawing.Point(319, 24);
            this.label_RightKick.Name = "label_RightKick";
            this.label_RightKick.Size = new System.Drawing.Size(53, 13);
            this.label_RightKick.TabIndex = 164;
            this.label_RightKick.Text = "RightKick";
            // 
            // RightKickLittle
            // 
            this.RightKickLittle.Location = new System.Drawing.Point(376, 47);
            this.RightKickLittle.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.RightKickLittle.Name = "RightKickLittle";
            this.RightKickLittle.Size = new System.Drawing.Size(46, 20);
            this.RightKickLittle.TabIndex = 163;
            this.RightKickLittle.ValueChanged += new System.EventHandler(this.RightKickLittle_ValueChanged);
            // 
            // MotionLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1090, 619);
            this.Controls.Add(this.toolStrip_MainToolbar);
            this.Controls.Add(this.TabControl_MotionEditor);
            this.Controls.Add(this.menuStrip_MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_MainMenu;
            this.Name = "MotionLab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parand Motion Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MotionLabFormClosing);
            this.groupBox_MotionPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MotionPage)).EndInit();
            this.menuStrip_MainMenu.ResumeLayout(false);
            this.menuStrip_MainMenu.PerformLayout();
            this.groupBox_PageParametrs.ResumeLayout(false);
            this.groupBox_PageParametrs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CtrlInertialForce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SpeedRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RepeatTime)).EndInit();
            this.groupBox_Positions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PoseOfMotor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PoseOfSteps)).EndInit();
            this.TabControl_MotionEditor.ResumeLayout(false);
            this.Tab_MotionEditor.ResumeLayout(false);
            this.groupBox_PageSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Page_SlopMargin)).EndInit();
            this.groupBox_Steps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Steps)).EndInit();
            this.tabPage_TrajectoryWalkEngine.ResumeLayout(false);
            this.groupBox_LocomotionFSM.ResumeLayout(false);
            this.groupBox_LocomotionFSM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FSMInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_Target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_Target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_Target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_Target)).EndInit();
            this.groupBox_MotionIndexs.ResumeLayout(false);
            this.groupBox_MotionIndexs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IsFallingMotionIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FallFrontMotionIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FallBackMotionIndex)).EndInit();
            this.groupBox_WalkingParameters.ResumeLayout(false);
            this.groupBox_WalkingParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ActuatorsSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ArmSwingGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FORWARDBACKWARDRATIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOUBLESTANCERATIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PitchOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PelvisOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_SWAP_AMPLITUDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME_UNIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_MOVE_AMPLITUDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME_PERIOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X_OFFSET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_OFFSET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_OFFSET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_OFFSET)).EndInit();
            this.groupBox_RobotState.ResumeLayout(false);
            this.groupBox_RobotState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_InsuranceCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FallSide_Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FallSide_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RollZeroOffset)).EndInit();
            this.groupBox_IMUData.ResumeLayout(false);
            this.groupBox_IMUData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CompassOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IMU_Pitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IMU_Roll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IMU_Yaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IsFalling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RollZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FallFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PitchZeroOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FallBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PitchZero0)).EndInit();
            this.groupBox_Stabilization.ResumeLayout(false);
            this.groupBox_Stabilization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HandLowPassGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GyroD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GyroP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AnkleLowPassGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HandPitchGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ActuatorsDirection)).EndInit();
            this.toolStrip_MainToolbar.ResumeLayout(false);
            this.toolStrip_MainToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HappyIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftKickIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftKickLittleIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightKick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightKickLittle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox_MotionPage;
        private MenuStrip menuStrip_MainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private DataGridView dataGridView_MotionPage;
        private GroupBox groupBox_PageParametrs;
        private Label label_InertialForce;
        private Label label_SpeedRate;
        private Label label_RepeatTime;
        private Label label_RealPlayTime;
        private GroupBox groupBox_Positions;
        private Button button_ReadMotor;
        private Button button_PlayStep;
        private DataGridView dataGridView_PoseOfSteps;
        private NumericUpDown numericUpDown_CtrlInertialForce;
        private NumericUpDown numericUpDown_RepeatTime;
        private DataGridView dataGridView_PoseOfMotor;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private TabControl TabControl_MotionEditor;
        private TabPage Tab_MotionEditor;
        private NumericUpDown numericUpDown_SpeedRate;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private OpenFileDialog openFileDialog_XmlInput;
        private SaveFileDialog saveFileDialog_XmlOutput;
        private TextBox textBox_RealPlayTime;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private Button button_Pastepage;
        private Button button_CopyPage;
        private Button button_MirrorExchange;
        private ToolStrip toolStrip_MainToolbar;
        private ToolStripButton ToolStripButton_New;
        private ToolStripButton ToolStripButton_Open;
        private ToolStripButton ToolStripButton_Save;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripLabel toolStripLabel_Port;
        private ToolStripComboBox toolStripComboBox_Port;
        private ToolStripSeparator toolStripSeparator1;
        private ToolTip toolTip_MainForm;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private GroupBox groupBox_PageSettings;
        private DataGridView dataGridView_Page_SlopMargin;
        private GroupBox groupBox_Steps;
        private Button button_SaveStep;
        private Button button_LoadStep;
        private Button button_StepPaste;
        private Button button_StepCopy;
        private Button button_SetStandStyle;
        private Button button_StepDown;
        private Button button_StepUp;
        private Button button_RemoveStep;
        private Button button_AddStep;
        public DataGridView dataGridView_Steps;
        private DataGridViewTextBoxColumn StepID;
        private DataGridViewTextBoxColumn StepTime;
        private DataGridViewTextBoxColumn StepPause;
        private DataGridViewTextBoxColumn PageID;
        private DataGridViewTextBoxColumn PageName;
        private DataGridViewTextBoxColumn PageNext;
        private DataGridViewTextBoxColumn PageExit;
        private Button button_TurnOffActuators;
        private Button button_TurnOnActuators;
        private DataGridViewTextBoxColumn JointName;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn Column2;
        private Button button_Ping;
        private ToolStripButton toolStripButton_Refresh;
        private ToolStripButton toolStripButton_Connect;
        private ToolStripButton toolStripButton_Disonnect;
        private TabPage tabPage_TrajectoryWalkEngine;
        private Label label_ZOffset;
        private Label label_XOffset;
        private Label label_AOffset;
        private Label label_YOffset;
        private NumericUpDown A_OFFSET;
        private NumericUpDown Y_OFFSET;
        private NumericUpDown Z_OFFSET;
        private NumericUpDown X_OFFSET;
        private Label label7;
        private Label label8;
        private NumericUpDown TIME_UNIT;
        private NumericUpDown TIME_PERIOD;
        private Button button_StopMotion;
        private Button button_PlayMotion;
        private Button button_DarwinWalkStop;
        private Button button_DarwinWalkStart;
        private DataGridView dataGridView_ActuatorsDirection;
        private Button button_LoadLastPose;
        private CheckBox checkBox_Control;
        private Button button_LoadWalkSettings;
        private Button button_SaveWalkSettings;
        private Button button_WalkOffset;
        private Label label2;
        private Label label_pelvisoffset;
        private NumericUpDown numericUpDown_PitchOffset;
        private NumericUpDown numericUpDown_PelvisOffset;
        private CheckBox checkBox_AMoveAimOn;
        private NumericUpDown numericUpDown_PitchZero0;
        private Label label_PitchZero;
        private GroupBox groupBox_Stabilization;
        private CheckBox checkBox_Stabilization;
        private CheckBox checkBox_WalkingchartEnable;
        private Label label_IMU_Yaw;
        private Label label_IMU_Roll;
        private Label label_IMU_pitch;
        private GroupBox groupBox_IMUData;
        private NumericUpDown numericUpDown_IMU_Pitch;
        private NumericUpDown numericUpDown_IMU_Roll;
        private NumericUpDown numericUpDown_IMU_Yaw;
        private GroupBox groupBox_RobotState;
        private NumericUpDown numericUpDown_IsFalling;
        private Label label_FallBack;
        private NumericUpDown numericUpDown_FallFront;
        private Label label_FallFront;
        private NumericUpDown numericUpDown_FallBack;
        private Label label_IsFalling;
        private NumericUpDown numericUpDown_PitchZeroOffset;
        private Label labelPitchZeroOffset;
        private NumericUpDown numericUpDown_RollZeroOffset;
        private Label label_RollZeroOffset;
        private NumericUpDown numericUpDown_RollZero;
        private Label label_RollZero;
        private GroupBox groupBox_WalkingParameters;
        private Label label14;
        private NumericUpDown Z_SWAP_AMPLITUDE;
        private Label labelFBRatio;
        private Label label_DS_Ratio;
        private NumericUpDown FORWARDBACKWARDRATIO;
        private NumericUpDown DOUBLESTANCERATIO;
        private Label label_FallSide_Left;
        private NumericUpDown numericUpDown_FallSide_Right;
        private Label label_FallSide_Right;
        private NumericUpDown numericUpDown_FallSide_Left;
        private Label label_CompassOffset;
        private NumericUpDown numericUpDown_CompassOffset;
        private Timer timer_IMU;
        private CheckBox checkBox_IMU_Timer;
        private Label label_HandPitchAmplitude;
        private NumericUpDown numericUpDown_ArmSwingGain;
        private DataGridViewTextBoxColumn DirectionJointName;
        private DataGridViewTextBoxColumn JointDirection;
        private Label label_PortName;
        private ComboBox comboBox_PortName;
        private Button button_RefreshPorts;
        private Button button_CloseIMU;
        private Button button_OpenIMU;
        private CheckBox checkBox_IMUChart;
        private NumericUpDown numericUpDown_AnkleLowPassGain;
        private Label label_PitchOffsetGain;
        private NumericUpDown numericUpDown_HandPitchGain;
        private Label label_HandPitchGain;
        private Label label_RobotStateLAble;
        private Label label_RobotState;
        private NumericUpDown numericUpDown_GyroD;
        private Label label1;
        private NumericUpDown numericUpDown_GyroP;
        private Label label3;
        private GroupBox groupBox_MotionIndexs;
        private NumericUpDown IsFallingMotionIndex;
        private Label label_FallBackMotionIndex;
        private NumericUpDown FallFrontMotionIndex;
        private Label label_FallFrontMotionIndex;
        private NumericUpDown FallBackMotionIndex;
        private Label label_IsFallingMotionIndex;
        private Button button_PlayFallBackMotion;
        private Button button_PlayIsFallFrontMotion;
        private Button button_PlayIsFallingMotion;
        private GroupBox groupBox_LocomotionFSM;
        private Button button_StopLocoMotionFSM;
        private Button button_StartLocoMotionFSM;
        private NumericUpDown numericUpDown_ActuatorsSpeed;
        private NumericUpDown numericUpDown_HandLowPassGain;
        private Label label6;
        private Label label4;
        private Label label_InsuranceCounter;
        private NumericUpDown numericUpDown_InsuranceCounter;
        private Timer timer_WalkMove;
        private Label label11;
        private NumericUpDown Y_MOVE_AMPLITUDE;
        private Label label_A;
        private NumericUpDown numericUpDown_A;
        private CheckBox checkBox_ASmooth;
        private Label label_ATarget;
        private NumericUpDown A_Target;
        private Label label_Z;
        private NumericUpDown numericUpDown_Z;
        private CheckBox checkBox_ZSmooth;
        private Label label_ZTarget;
        private NumericUpDown Z_Target;
        private Label label_Y;
        private NumericUpDown numericUpDown_Y;
        private CheckBox checkBox_YSmooth;
        private Label label_YTarget;
        private NumericUpDown Y_Target;
        private Label label_X;
        private NumericUpDown numericUpDown_X;
        private CheckBox checkBox_XSmooth;
        private Label label_XTarget;
        private NumericUpDown X_Target;
        private Label label_XMax;
        private NumericUpDown XMax;
        private Label label_XMin;
        private NumericUpDown XMin;
        private Label label_Ymax;
        private NumericUpDown YMax;
        private Label label_YMin;
        private NumericUpDown YMin;
        private Label label_AMax;
        private NumericUpDown AMax;
        private Label label_AMin;
        private NumericUpDown AMin;
        private Label label_ZMax;
        private NumericUpDown ZMax;
        private Label label_ZMin;
        private NumericUpDown ZMin;
        private Button button_WalkManagerStop;
        private Button button_WalkManagerStart;
        private Label label_FSMInterval;
        private NumericUpDown FSMInterval;
        private Label label_AInterval;
        private NumericUpDown AInterval;
        private Label label_ZInterval;
        private NumericUpDown ZInterval;
        private Label label_YInterval;
        private NumericUpDown YInterval;
        private Label label_XInterval;
        private NumericUpDown XInterval;
        private CheckBox checkBox_JoyStick;
        private Button button_LeftKickLittle;
        private Button button_LeftKick;
        private Button button_Happy;
        private NumericUpDown HappyIndex;
        private Label label_LeftKickLittle;
        private NumericUpDown LeftKickIndex;
        private Label label_LeftKick;
        private NumericUpDown LeftKickLittleIndex;
        private Label label_Happy;
        private Button button_RightKickLittle;
        private Button button_RightKick;
        private Label label_RightKickLittle;
        private NumericUpDown RightKick;
        private Label label_RightKick;
        private NumericUpDown RightKickLittle;
    }
}

