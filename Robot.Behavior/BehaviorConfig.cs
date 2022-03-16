using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Robot.Locomotion;

namespace Robot.Behavior
{
    public partial class BehaviorConfig : Form
    {
        private readonly BehaviorControl _behavior;
        private readonly Controll _controll;

        public BehaviorConfig(BehaviorControl behavior , Controll controll)
        {
            _behavior = behavior;
            _controll = controll;
            InitializeComponent();
        }


        private void LoadSettings()
        {
            #region Search Ball
            textBox_SearchBall_LittleWalkRate.Text = _behavior.LittleWalkRate.ToString();
            textBox_SearchBall_SecWalkAndSearch_Max.Text = _behavior.BallSecWalkAndSearchRange.Max.ToString();
            textBox_SearchBall_SecWalkAndSearch_Min.Text = _behavior.BallSecWalkAndSearchRange.Min.ToString();
            textBox_SearchBall_StopAndSearch_Max.Text = _behavior.BallStopAndSearchRange.Max.ToString();
            textBox_SearchBall_StopAndSearch_Min.Text = _behavior.BallStopAndSearchRange.Min.ToString();
            textBox_SearchBall_TurnAndSearch_Max.Text = _behavior.BallTurnAndSearchRange.Max.ToString();
            textBox_SearchBall_TurnAndSearch_Min.Text = _behavior.BallTurnAndSearchRange.Min.ToString();
            textBox_SearchBall_WalkAndSearch_Max.Text = _behavior.BallWalkAndSearchRange.Max.ToString();
            textBox_SearchBall_WalkAndSearch_Min.Text = _behavior.BallWalkAndSearchRange.Min.ToString();
            textBox_SearchBall_BallLostTimeToSearch.Text = _behavior.BallLostTimeToSearch.ToString();
            #endregion

            #region Walk To Ball

         
            textbox_WalkToBall_TurnHeadDirection_Max.Text = _behavior.TurnHeadDirection.Max.ToString();
            textbox_WalkToBall_TurnHeadDirection_Min.Text = _behavior.TurnHeadDirection.Min.ToString();
            textBox_WalkToBall_BallStopTiltBoundar_Min.Text = _behavior.BallStopTiltBounder.Min.ToString();
            textBox_WalkToBall_BallStopTiltBoundar_Max.Text = _behavior.BallStopTiltBounder.Max.ToString();

            textBox_StandAndTurnBounder_min.Text = _behavior.StandAndTurnBounder.Min.ToString();
            textBox_StandAndTurnBounder_max.Text = _behavior.StandAndTurnBounder.Max.ToString();

            textBox_WalkToBall_CommunicationDistance.Text = _behavior.CommunicationDistance.ToString();
            textBox_WalkToBall_PerseptionPresion.Text = _behavior.PerseptionPresionWalkToBall.ToString();


            #endregion

            #region Search Goal

            textBox_SearchGoal_PerseptionPresion.Text = _behavior.PerseptionPresionGoalSearch.ToString();
            textBox_SearchGoal_StopAndSearch_Max.Text = _behavior.GoalStopAndSearchRange.Max.ToString();
            textBox_SearchGoal_StopAndSearch_Min.Text = _behavior.GoalStopAndSearchRange.Min.ToString();
            textBox_SearchGoal_WalkAndSearch_Max.Text = _behavior.GoalWalkAndSearchRange.Max.ToString();
            textBox_SearchGoal_WalkAndSearch_Min.Text = _behavior.GoalWalkAndSearchRange.Min.ToString();
            textBox_SearchGoal_Interval.Text = _behavior.IntervalGoalSearch.ToString();
            textBox_SearchGoal_TurnX.Text = _behavior.SearchGoalFourStepLeftTurn[0].ToString();
            textBox_SearchGoal_TurnY.Text = _behavior.SearchGoalFourStepLeftTurn[1].ToString();
            textBox_SearchGoal_TurnZ.Text = _behavior.SearchGoalFourStepLeftTurn[2].ToString();
            textBox_SearchGoal_TurnA.Text = _behavior.SearchGoalFourStepLeftTurn[3].ToString();
            textBox_SearchGoal_TurnT.Text = _behavior.SearchGoalFourStepLeftTurn[4].ToString();

            #endregion

            #region TurnBall

            textBox_TurnBall_FourStepBackWard_X.Text = _behavior.FourStepBackWard[0].ToString();
            textBox_TurnBall_FourStepBackWard_Y.Text = _behavior.FourStepBackWard[1].ToString();
            textBox_TurnBall_FourStepBackWard_Z.Text = _behavior.FourStepBackWard[2].ToString();
            textBox_TurnBall_FourStepBackWard_A.Text = _behavior.FourStepBackWard[3].ToString();
            textBox_TurnBall_FourStepBackWard_T.Text = _behavior.FourStepBackWard[4].ToString();

            textBox_TurnBall_FourStepLeftTurn_X.Text = _behavior.FourStepLeftTurn[0].ToString();
            textBox_TurnBall_FourStepLeftTurn_Y.Text = _behavior.FourStepLeftTurn[1].ToString();
            textBox_TurnBall_FourStepLeftTurn_Z.Text = _behavior.FourStepLeftTurn[2].ToString();
            textBox_TurnBall_FourStepLeftTurn_A.Text = _behavior.FourStepLeftTurn[3].ToString();
            textBox_TurnBall_FourStepLeftTurn_T.Text = _behavior.FourStepLeftTurn[4].ToString();

            textBox_TurnBall_FourStepRightTurn_X.Text = _behavior.FourStepRightTurn[0].ToString();
            textBox_TurnBall_FourStepRightTurn_Y.Text = _behavior.FourStepRightTurn[1].ToString();
            textBox_TurnBall_FourStepRightTurn_Z.Text = _behavior.FourStepRightTurn[2].ToString();
            textBox_TurnBall_FourStepRightTurn_A.Text = _behavior.FourStepRightTurn[3].ToString();
            textBox_TurnBall_FourStepRightTurn_T.Text = _behavior.FourStepRightTurn[4].ToString();

            textBox_TurnBall_TurnPerseptionPresion.Text = _behavior.PerseptionPresionTurn.ToString();
            textBox_TurnBall_SightBoundary_Max.Text = _behavior.SightBoundaryRange.Max.ToString();
            textBox_TurnBall_SightBoundary_Min.Text = _behavior.SightBoundaryRange.Min.ToString();
            textBox_TurnBall_AimPresion.Text = _behavior.AimPerseptionPresion.ToString();
            textBox_turnBall_TurnPresion.Text = _behavior.TurnPresion.ToString();

            #endregion

            #region AimAndKick

            textBox_AimAndKick_RightOrLeftBoundar.Text = _behavior.RightOrLeftBoundar.ToString();
            textBox_AimAndKick_BackWard_X.Text = _behavior.LittleFourStepBackWard[0].ToString();
            textBox_AimAndKick_BackWard_Y.Text = _behavior.LittleFourStepBackWard[1].ToString();
            textBox_AimAndKick_BackWard_Z.Text = _behavior.LittleFourStepBackWard[2].ToString();
            textBox_AimAndKick_BackWard_A.Text = _behavior.LittleFourStepBackWard[3].ToString();
            textBox_AimAndKick_BackWard_T.Text = _behavior.LittleFourStepBackWard[4].ToString();

            textBox_AimAndKick_Forward_X.Text = _behavior.LittleFourStepForward[0].ToString();
            textBox_AimAndKick_Forward_Y.Text = _behavior.LittleFourStepForward[1].ToString();
            textBox_AimAndKick_Forward_Z.Text = _behavior.LittleFourStepForward[2].ToString();
            textBox_AimAndKick_Forward_A.Text = _behavior.LittleFourStepForward[3].ToString();
            textBox_AimAndKick_Forward_T.Text = _behavior.LittleFourStepForward[4].ToString();

            textBox_AimAndKick_LeftSide_X.Text = _behavior.LittleFourStepLeftSide[0].ToString();
            textBox_AimAndKick_LeftSide_Y.Text = _behavior.LittleFourStepLeftSide[1].ToString();
            textBox_AimAndKick_LeftSide_Z.Text = _behavior.LittleFourStepLeftSide[2].ToString();
            textBox_AimAndKick_LeftSide_A.Text = _behavior.LittleFourStepLeftSide[3].ToString();
            textBox_AimAndKick_LeftSide_T.Text = _behavior.LittleFourStepLeftSide[4].ToString();

            textBox_AimAndKick_RightSide_X.Text = _behavior.LittleFourStepRightSide[0].ToString();
            textBox_AimAndKick_RightSide_Y.Text = _behavior.LittleFourStepRightSide[1].ToString();
            textBox_AimAndKick_RightSide_Z.Text = _behavior.LittleFourStepRightSide[2].ToString();
            textBox_AimAndKick_RightSide_A.Text = _behavior.LittleFourStepRightSide[3].ToString();
            textBox_AimAndKick_RightSide_T.Text = _behavior.LittleFourStepRightSide[4].ToString();

            textBox_AimAndKick_SleepBeforeMotionPlay.Text = _behavior.SleepBeforeMotionPlay.ToString();
            textBox_AimAndKick_LeftKickMotionIndex.Text = _behavior.LeftKickMotionIndex.ToString();
            textBox_AimAndKick_RightKickMotionIndex.Text = _behavior.RightKickMotionIndex.ToString();
            textBox_AimAndKick_BallXPosLeft_Min.Text = _behavior.BallXposLeftLeg.Min.ToString();
            textBox_AimAndKick_BallXPosLeft_Max.Text = _behavior.BallXposLeftLeg.Max.ToString();
            textBox_AimAndKick_BallXPosRight_Min.Text = _behavior.BallXposRightLeg.Min.ToString();
            textBox_AimAndKick_BallXPosRight_Max.Text = _behavior.BallXposRightLeg.Max.ToString();
            textBox_AimAndKick_BallYPos_Min.Text = _behavior.BallYposLeg.Min.ToString();
            textBox_AimAndKick_BallYPos_Max.Text = _behavior.BallYposLeg.Max.ToString();
            #endregion

            #region Walk To Ball Awards Goal

            textBox_AwardsGoal_WalkTime.Text = _behavior.WalkTime.ToString();
            textBox_AwardsGoal_BallLocationXReange_Max.Text = _behavior.BallLocationXReange.Max.ToString();
            textBox_AwardsGoal_BallLocationXReange_Min.Text = _behavior.BallLocationXReange.Min.ToString();
            textBox_AwardsGoal_LeftWalkSetting_X.Text = _behavior.LeftWalkSettings[0].ToString();
            textBox_AwardsGoal_LeftWalkSetting_Y.Text = _behavior.LeftWalkSettings[1].ToString();
            textBox_AwardsGoal_LeftWalkSetting_A.Text = _behavior.LeftWalkSettings[2].ToString();
            textBox_AwardsGoal_LeftWalkSetting_P.Text = _behavior.LeftWalkSettings[3].ToString();

            textBox_AwardsGoal_RightWalkSetting_X.Text = _behavior.RightWalkSettings[0].ToString();
            textBox_AwardsGoal_RightWalkSetting_Y.Text = _behavior.RightWalkSettings[1].ToString();
            textBox_AwardsGoal_RightWalkSetting_A.Text = _behavior.RightWalkSettings[2].ToString();
            textBox_AwardsGoal_RightWalkSetting_P.Text = _behavior.RightWalkSettings[3].ToString();

            #endregion

            #region Test

            textBox_Test_Interval.Text = _behavior.Interval.ToString();
            textBox_Test_PanLeftPos.Text = _behavior.PanLeftPos.ToString();
            textBox_Test_PanRightPos.Text = _behavior.PanRightPos.ToString();
            textBox_Test_TiltPos.Text = _behavior.TiltPos.ToString();
            textBox_Test_TurnGain.Text = _behavior.TurnGain.ToString();

            #endregion

            #region Settings

            checkBoxGameController.Checked = _behavior.GameControllerEnabled;
            radioButtonKick.Checked = _behavior.AttackModeIsKick;
            radioButtonWalkToBall.Checked = !_behavior.AttackModeIsKick;
            radioButtonYellowToBlue.Checked = _behavior.RivalGoalIsBlue;
            radioButtonBlueToYellow.Checked = !_behavior.RivalGoalIsBlue;
            checkBox_IsGoalie.Checked = _behavior.isGoalie;
            checkBox_Communication.Checked = _behavior.CommunicationEnabled;

            #endregion

            textBoxCompassOffsetValue.Text = _controll.CompassOffset.ToString();

        }




        private void ApplySettings()
        {
            #region Search Ball
            _behavior.LittleWalkRate=Convert.ToDouble(textBox_SearchBall_LittleWalkRate.Text);
            _behavior.BallSecWalkAndSearchRange.Max = Convert.ToDouble(textBox_SearchBall_SecWalkAndSearch_Max.Text);
            _behavior.BallSecWalkAndSearchRange.Min = Convert.ToDouble(textBox_SearchBall_SecWalkAndSearch_Min.Text);
            _behavior.BallStopAndSearchRange.Max = Convert.ToDouble(textBox_SearchBall_StopAndSearch_Max.Text);
            _behavior.BallStopAndSearchRange.Min = Convert.ToDouble(textBox_SearchBall_StopAndSearch_Min.Text);
            _behavior.BallTurnAndSearchRange.Max = Convert.ToDouble(textBox_SearchBall_TurnAndSearch_Max.Text);
            _behavior.BallTurnAndSearchRange.Min = Convert.ToDouble(textBox_SearchBall_TurnAndSearch_Min.Text);
            _behavior.BallWalkAndSearchRange.Max = Convert.ToDouble(textBox_SearchBall_WalkAndSearch_Max.Text);
            _behavior.BallWalkAndSearchRange.Min =Convert.ToDouble(textBox_SearchBall_WalkAndSearch_Min.Text);
            _behavior.BallLostTimeToSearch = Convert.ToInt32(textBox_SearchBall_BallLostTimeToSearch.Text);
            #endregion

            #region Walk To Ball

            _behavior.TurnHeadDirection.Max = Convert.ToDouble(textbox_WalkToBall_TurnHeadDirection_Max.Text);
            _behavior.TurnHeadDirection.Min = Convert.ToDouble(textbox_WalkToBall_TurnHeadDirection_Min.Text);
            _behavior.BallStopTiltBounder.Min = Convert.ToInt32(textBox_WalkToBall_BallStopTiltBoundar_Min.Text);
            _behavior.BallStopTiltBounder.Max = Convert.ToInt32(textBox_WalkToBall_BallStopTiltBoundar_Max.Text);
         
            _behavior.StandAndTurnBounder.Min = Convert.ToInt32(textBox_StandAndTurnBounder_min.Text);
            _behavior.StandAndTurnBounder.Max = Convert.ToInt32(textBox_StandAndTurnBounder_max.Text);

            _behavior.CommunicationDistance = Convert.ToInt32(textBox_WalkToBall_CommunicationDistance.Text);
            _behavior.PerseptionPresionWalkToBall = Convert.ToInt32(textBox_WalkToBall_PerseptionPresion.Text);
            #endregion

            #region Search Goal

            _behavior.PerseptionPresionGoalSearch = Convert.ToInt32(textBox_SearchGoal_PerseptionPresion.Text);
            _behavior.GoalStopAndSearchRange.Max = Convert.ToDouble(textBox_SearchGoal_StopAndSearch_Max.Text);
            _behavior.GoalStopAndSearchRange.Min = Convert.ToDouble(textBox_SearchGoal_StopAndSearch_Min.Text);
            _behavior.GoalWalkAndSearchRange.Max=Convert.ToDouble(textBox_SearchGoal_WalkAndSearch_Max.Text);
            _behavior.GoalWalkAndSearchRange.Min = Convert.ToDouble(textBox_SearchGoal_WalkAndSearch_Min.Text);
            _behavior.IntervalGoalSearch = Convert.ToInt32(textBox_SearchGoal_Interval.Text);
            _behavior.SearchGoalFourStepLeftTurn[0] = Convert.ToDouble(textBox_SearchGoal_TurnX.Text);
            _behavior.SearchGoalFourStepLeftTurn[1] = Convert.ToDouble(textBox_SearchGoal_TurnY.Text); 
            _behavior.SearchGoalFourStepLeftTurn[2] = Convert.ToDouble(textBox_SearchGoal_TurnZ.Text);
            _behavior.SearchGoalFourStepLeftTurn[3] = Convert.ToDouble(textBox_SearchGoal_TurnA.Text);
            _behavior.SearchGoalFourStepLeftTurn[4] = Convert.ToDouble(textBox_SearchGoal_TurnT.Text);
            #endregion

            #region TurnBall

            _behavior.FourStepBackWard[0] = Convert.ToDouble(textBox_TurnBall_FourStepBackWard_X.Text);
            _behavior.FourStepBackWard[1] = Convert.ToDouble(textBox_TurnBall_FourStepBackWard_Y.Text);
            _behavior.FourStepBackWard[2] = Convert.ToDouble(textBox_TurnBall_FourStepBackWard_Z.Text);
            _behavior.FourStepBackWard[3]=Convert.ToDouble(textBox_TurnBall_FourStepBackWard_A.Text);
            _behavior.FourStepBackWard[4] = Convert.ToDouble(textBox_TurnBall_FourStepBackWard_T.Text);

            _behavior.FourStepLeftTurn[0] = Convert.ToDouble(textBox_TurnBall_FourStepLeftTurn_X.Text);
            _behavior.FourStepLeftTurn[1] = Convert.ToDouble(textBox_TurnBall_FourStepLeftTurn_Y.Text);
            _behavior.FourStepLeftTurn[2] = Convert.ToDouble(textBox_TurnBall_FourStepLeftTurn_Z.Text);
            _behavior.FourStepLeftTurn[3] = Convert.ToDouble(textBox_TurnBall_FourStepLeftTurn_A.Text);
            _behavior.FourStepLeftTurn[4] = Convert.ToDouble(textBox_TurnBall_FourStepLeftTurn_T.Text);

            _behavior.FourStepRightTurn[0] = Convert.ToDouble(textBox_TurnBall_FourStepRightTurn_X.Text);
            _behavior.FourStepRightTurn[1] = Convert.ToDouble(textBox_TurnBall_FourStepRightTurn_Y.Text);
            _behavior.FourStepRightTurn[2] = Convert.ToDouble(textBox_TurnBall_FourStepRightTurn_Z.Text);
            _behavior.FourStepRightTurn[3] = Convert.ToDouble(textBox_TurnBall_FourStepRightTurn_A.Text);
            _behavior.FourStepRightTurn[4] = Convert.ToDouble(textBox_TurnBall_FourStepRightTurn_T.Text);

            _behavior.PerseptionPresionTurn = Convert.ToDouble(textBox_TurnBall_TurnPerseptionPresion.Text);
            _behavior.SightBoundaryRange.Max = Convert.ToDouble(textBox_TurnBall_SightBoundary_Max.Text);
            _behavior.SightBoundaryRange.Min = Convert.ToDouble(textBox_TurnBall_SightBoundary_Min.Text);
            _behavior.AimPerseptionPresion = Convert.ToInt32(textBox_TurnBall_AimPresion.Text);
            _behavior.TurnPresion = Convert.ToInt32(textBox_turnBall_TurnPresion.Text);

            #endregion

            #region AimAndKick

            _behavior.RightOrLeftBoundar = Convert.ToInt32(textBox_AimAndKick_RightOrLeftBoundar.Text);
            _behavior.LittleFourStepBackWard[0] = Convert.ToDouble(textBox_AimAndKick_BackWard_X.Text);
            _behavior.LittleFourStepBackWard[1] = Convert.ToDouble(textBox_AimAndKick_BackWard_Y.Text);
            _behavior.LittleFourStepBackWard[2] = Convert.ToDouble(textBox_AimAndKick_BackWard_Z.Text);
            _behavior.LittleFourStepBackWard[3] = Convert.ToDouble(textBox_AimAndKick_BackWard_A.Text);
            _behavior.LittleFourStepBackWard[4] = Convert.ToDouble(textBox_AimAndKick_BackWard_T.Text);

            _behavior.LittleFourStepForward[0] = Convert.ToDouble(textBox_AimAndKick_Forward_X.Text);
            _behavior.LittleFourStepForward[1]=Convert.ToDouble(textBox_AimAndKick_Forward_Y.Text);
            _behavior.LittleFourStepForward[2] = Convert.ToDouble(textBox_AimAndKick_Forward_Z.Text);
            _behavior.LittleFourStepForward[3] = Convert.ToDouble(textBox_AimAndKick_Forward_A.Text);
            _behavior.LittleFourStepForward[4] = Convert.ToDouble(textBox_AimAndKick_Forward_T.Text);

            _behavior.LittleFourStepLeftSide[0] = Convert.ToDouble(textBox_AimAndKick_LeftSide_X.Text);
            _behavior.LittleFourStepLeftSide[1] = Convert.ToDouble(textBox_AimAndKick_LeftSide_Y.Text);
            _behavior.LittleFourStepLeftSide[2] = Convert.ToDouble(textBox_AimAndKick_LeftSide_Z.Text);
            _behavior.LittleFourStepLeftSide[3] = Convert.ToDouble(textBox_AimAndKick_LeftSide_A.Text);
            _behavior.LittleFourStepLeftSide[4] = Convert.ToDouble(textBox_AimAndKick_LeftSide_T.Text);

            _behavior.LittleFourStepRightSide[0] = Convert.ToDouble(textBox_AimAndKick_RightSide_X.Text);
            _behavior.LittleFourStepRightSide[1] = Convert.ToDouble(textBox_AimAndKick_RightSide_Y.Text);
            _behavior.LittleFourStepRightSide[2] = Convert.ToDouble(textBox_AimAndKick_RightSide_Z.Text);
            _behavior.LittleFourStepRightSide[3] = Convert.ToDouble(textBox_AimAndKick_RightSide_A.Text);
            _behavior.LittleFourStepRightSide[4] = Convert.ToDouble(textBox_AimAndKick_RightSide_T.Text);

            _behavior.SleepBeforeMotionPlay = Convert.ToInt32(textBox_AimAndKick_SleepBeforeMotionPlay.Text);
            _behavior.LeftKickMotionIndex = Convert.ToInt32(textBox_AimAndKick_LeftKickMotionIndex.Text);
            _behavior.RightKickMotionIndex = Convert.ToInt32(textBox_AimAndKick_RightKickMotionIndex.Text);
            _behavior.BallXposLeftLeg.Min = Convert.ToInt32(textBox_AimAndKick_BallXPosLeft_Min.Text);
            _behavior.BallXposLeftLeg.Max = Convert.ToInt32(textBox_AimAndKick_BallXPosLeft_Max.Text);
            _behavior.BallXposRightLeg.Min = Convert.ToInt32(textBox_AimAndKick_BallXPosRight_Min.Text);
            _behavior.BallXposRightLeg.Max = Convert.ToInt32(textBox_AimAndKick_BallXPosRight_Max.Text);
            _behavior.BallYposLeg.Min = Convert.ToInt32(textBox_AimAndKick_BallYPos_Min.Text);
            _behavior.BallYposLeg.Max = Convert.ToInt32(textBox_AimAndKick_BallYPos_Max.Text);






            #endregion

            #region Walk To Ball Awards Goal

            _behavior.WalkTime = Convert.ToInt32(textBox_AwardsGoal_WalkTime.Text);
            _behavior.BallLocationXReange.Max=Convert.ToDouble(textBox_AwardsGoal_BallLocationXReange_Max.Text);
            _behavior.BallLocationXReange.Min = Convert.ToDouble(textBox_AwardsGoal_BallLocationXReange_Min.Text);
            _behavior.LeftWalkSettings[0] = Convert.ToDouble(textBox_AwardsGoal_LeftWalkSetting_X.Text);
            _behavior.LeftWalkSettings[1] = Convert.ToDouble(textBox_AwardsGoal_LeftWalkSetting_Y.Text);
            _behavior.LeftWalkSettings[2] = Convert.ToDouble(textBox_AwardsGoal_LeftWalkSetting_A.Text);
            _behavior.LeftWalkSettings[3] = Convert.ToDouble(textBox_AwardsGoal_LeftWalkSetting_P.Text);

            _behavior.RightWalkSettings[0] = Convert.ToDouble(textBox_AwardsGoal_RightWalkSetting_X.Text);
            _behavior.RightWalkSettings[1] = Convert.ToDouble(textBox_AwardsGoal_RightWalkSetting_Y.Text);
            _behavior.RightWalkSettings[2] = Convert.ToDouble(textBox_AwardsGoal_RightWalkSetting_A.Text);
            _behavior.RightWalkSettings[3] = Convert.ToDouble(textBox_AwardsGoal_RightWalkSetting_P.Text);

            #endregion

            #region Test

            _behavior.Interval = Convert.ToInt32(textBox_Test_Interval.Text);
            _behavior.PanLeftPos = Convert.ToInt32(textBox_Test_PanLeftPos.Text);
            _behavior.PanRightPos = Convert.ToInt32(textBox_Test_PanRightPos.Text);
            _behavior.TiltPos = Convert.ToInt32(textBox_Test_TiltPos.Text);
            _behavior.TurnGain = Convert.ToInt32(textBox_Test_TurnGain.Text);

            #endregion

            #region Settings

            _behavior.GameControllerEnabled = checkBoxGameController.Checked;
            _behavior.AttackModeIsKick=radioButtonKick.Checked;
            _behavior.RivalGoalIsBlue = radioButtonYellowToBlue.Checked;
            _behavior.isGoalie = checkBox_IsGoalie.Checked;
            _behavior.CommunicationEnabled = checkBox_Communication.Checked;
            #endregion
        }


        private void BehaviorConfig_Load(object sender, EventArgs e)
        {
          LoadSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplySettings();
            _behavior.SaveConfig("Config/Behavior.xml");
        }

        private void timerCompass_Tick(object sender, EventArgs e)
        {
            textBoxCompassReal.Text = (_controll.ImuData.FilteredAngleYaw*180/Math.PI).ToString();
            textBoxCompassWithOffset.Text = _controll.Compass.ToString();

        }

        private void buttonApplyOffsetValue_Click(object sender, EventArgs e)
        {
           _controll.CompassOffset= Convert.ToInt32(textBoxCompassOffsetValue.Text);
        }

        private void radioButtonYellowToBlue_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string path = "Config/Controll.xml";
            var xmlElem = XElement.Load(path);
            xmlElem.SetAttributeValue("CompassOffset", textBoxCompassOffsetValue.Text);
            xmlElem.Save(path);
  
        }
    }
}
