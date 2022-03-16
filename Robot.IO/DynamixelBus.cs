

using System;
using System.Collections.Generic;

namespace Robot.IO
{
    public class DynamixelBus : DynamixelNetwork
    {
        public enum Registers : byte
        {
            ModelNumber = 0,
            FirmWareVersionInfo = 2,
            Id = 3,
            BuadRate = 4,
            ReturnDelayTime = 5,
            ClockWiseAngleLimit = 6,
            CounterClockWiseAngleLimit = 8,
            DriveMode = 10,
            LimitTemperature = 11,
            LimitVoltage = 12,
            MaxTorque = 14,
            StatusReturnLevel = 16,
            AlarmLed = 17,
            AlarmShutDown = 18,
            TorqueEnable = 24,
            Led = 25,
            CwComplianceMargin = 26,
            CcwComplianceMargin = 27,
            CwComplianceSlop = 28,
            D = 26,
            I = 27,
            P = 28,
            CcwComplianceSlop = 29,
            GoalPosition = 30,
            MovingSpeed = 32,
            TorqueLimit = 34,
            PresentPosition = 36,
            PresentSpeed = 38,
            PresentLoad = 40,
            PresentVoltage = 42,
            PresentTemperature = 43,
            Registered = 44,
            Moving = 46,
            Lock = 47,
            Punch = 48,
        }


        public DynamixelBus(string portName, int baudNum)
            : base(portName, baudNum)
        {

        }

        public void SetD(int id, int value)
        {

            WriteByte(id, (int)Registers.D, value, true);

        }

        public int GetD(int id)
        {

            return ReadByte(id, (int)Registers.D);

        }

        public void SetI(int id, int value)
        {

            WriteByte(id, (int)Registers.I, value, true);

        }

        public int GetI(int id)
        {

            return ReadByte(id, (int)Registers.I);

        }

        public void SetP(int id, int value)
        {

            WriteByte(id, (int)Registers.P, value, true);

        }

        public int GetP(int id)
        {

            return ReadByte(id, (int)Registers.P);

        }

        public void SetDriveMode(int id, int mode)
        {

            WriteByte(id, (int)Registers.DriveMode, mode, true);

        }

        public int GetDriveMode(int id)
        {

            return ReadByte(id, (int)Registers.DriveMode);

        }

        public int GetModelNumber(int id)
        {

            return ReadWord(id, (int)Registers.ModelNumber);

        }

        public void SetId(int id, int newid)
        {
            WriteByte(id, (int)Registers.Id, newid, true);
        }

        public bool Ping(int id)
        {
            return base.Ping(id);
        }

        public void SetGoalPosition(int id, int value)
        {

            WriteWord(id, (int)Registers.GoalPosition, value, true);

        }

        public int GetGoalPoistion(int id)
        {

            return ReadWord(id, (int)Registers.GoalPosition);

        }

        public void SetCwComplianceSlop(int id, int value)
        {

            WriteByte(id, (int)Registers.CwComplianceSlop, value, true);

        }

        public void SetCcwComplianceSlop(int id, int value)
        {

            WriteByte(id, (int)Registers.CcwComplianceSlop, value, true);

        }

        public void SetCwComplianceMargin(int id, int value)
        {

            WriteByte(id, (int)Registers.CwComplianceMargin, value, true);

        }

        public void SetCcwComplianceMargin(int id, int value)
        {

            WriteByte(id, (int)Registers.CcwComplianceMargin, value, true);

        }

        public int GetCwComplianceSlop(int id)
        {

            return ReadByte(id, (int)Registers.CwComplianceSlop);

        }


        public int GetCcwComplianceSlop(int id)
        {

            return ReadByte(id, (int)Registers.CcwComplianceSlop);

        }

        public void SetSpeed(int id, int value)
        {

            WriteWord(id, (int)Registers.MovingSpeed, value, true);

        }

        public int GetSpeed(int id)
        {

            return ReadWord(id, (int)Registers.MovingSpeed);

        }

        public void TurnOffAlarmShutdown(int id)
        {

            WriteByte(id, (int)Registers.AlarmShutDown, 0, true);

        }

        public int GetCwComplianceMargin(int id)
        {

            return ReadByte(id, (int)Registers.CwComplianceMargin);

        }

        public int GetCcwComplianceMargin(int id)
        {

            return ReadByte(id, (int)Registers.CcwComplianceMargin);

        }

        public void TurnOffActuator(int id)
        {

            WriteByte(id, (int)Registers.TorqueEnable, 0, true);

        }

        public void TurnOnActuator(int id)
        {

            WriteByte(id, (int)Registers.TorqueEnable, 1, true);

        }



        public void SetSpeedPosition(List<IActuator> joints)
        {

            int count = joints.Count;
            var byteStream = new List<byte>();
            int checksum = 0;

            byteStream.Add(0xFF);
            byteStream.Add(0xFF);

            checksum += BroadcastId;
            byteStream.Add(BroadcastId);

            var length = (byte)((4 + 1) * count + 4);
            checksum += length;
            byteStream.Add(length);
            // Length (L+1) X N + 4   (L: Data Length per actuator, N: the number acutuators)

            checksum += (byte)Instruction.SyncWrite;
            byteStream.Add((byte)Instruction.SyncWrite); // Instruction

            checksum += (byte)Registers.GoalPosition;
            byteStream.Add((byte)Registers.GoalPosition); // Register Start Address

            checksum += 4;
            byteStream.Add(4); // Length of Data

            for (int i = 0; i < count; i++)
            {
                checksum += joints[i].Id;
                byteStream.Add((byte)(joints[i].Id));

                checksum += (byte)(joints[i].RealPosition);
                byteStream.Add((byte)(joints[i].RealPosition));

                checksum += (byte)(joints[i].RealPosition >> 8);
                byteStream.Add((byte)(joints[i].RealPosition >> 8));

                checksum += (byte)(joints[i].Speed);
                byteStream.Add((byte)(joints[i].Speed));

                checksum += (byte)(joints[i].Speed >> 8);
                byteStream.Add((byte)(joints[i].Speed >> 8));
            }

            // the checksum is inverted
            byteStream.Add((byte)(~checksum & 0xff));

            try
            {
                if (IsOpen)
                {
                    Stream.Write(byteStream.ToArray(), 0, byteStream.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void SetSlopMargin(List<IActuator> joints)
        {

            int count = joints.Count;
            var byteStream = new List<byte>();
            int checksum = 0;

            byteStream.Add(0xFF);
            byteStream.Add(0xFF);

            checksum += BroadcastId;
            byteStream.Add(BroadcastId);

            var length = (byte)((4 + 1) * count + 4);
            checksum += length;
            byteStream.Add(length);
            // Length (L+1) X N + 4   (L: Data Length per actuator, N: the number acutuators)

            checksum += (byte)Instruction.SyncWrite;
            byteStream.Add((byte)Instruction.SyncWrite); // Instruction

            checksum += (byte)Registers.CwComplianceMargin;
            byteStream.Add((byte)Registers.CwComplianceMargin); // Register Start Address

            checksum += 4;
            byteStream.Add(4); // Length of Data

            for (int i = 0; i < count; i++)
            {
                checksum += joints[i].Id;
                byteStream.Add((byte)(joints[i].Id));

                checksum += (byte)(joints[i].Margin);
                byteStream.Add((byte)(joints[i].Margin));

                checksum += (byte)(joints[i].Margin >> 8);
                byteStream.Add((byte)(joints[i].Margin >> 8));

                checksum += (byte)(joints[i].Slop);
                byteStream.Add((byte)(joints[i].Slop));

                checksum += (byte)(joints[i].Slop >> 8);
                byteStream.Add((byte)(joints[i].Slop >> 8));
            }

            // the checksum is inverted
            byteStream.Add((byte)(~checksum & 0xff));

            try
            {
                if (IsOpen)
                {
                    Stream.Write(byteStream.ToArray(), 0, byteStream.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void SetPositions(List<IActuator> joints)
        {

            int count = joints.Count;
            var byteStream = new List<byte>();
            int checksum = 0;

            byteStream.Add(0xFF);
            byteStream.Add(0xFF);

            checksum += BroadcastId;
            byteStream.Add(BroadcastId);

            var length = (byte)((2 + 1) * count + 4);
            checksum += length;
            byteStream.Add(length);
            // Length (L+1) X N + 4   (L: Data Length per actuator, N: the number acutuators)

            checksum += (byte)Instruction.SyncWrite;
            byteStream.Add((byte)Instruction.SyncWrite); // Instruction

            checksum += (byte)Registers.GoalPosition;
            byteStream.Add((byte)Registers.GoalPosition); // Register Start Address

            checksum += 2;
            byteStream.Add(2); // Length of Data

            for (int i = 0; i < count; i++)
            {
                checksum += joints[i].Id;
                byteStream.Add((byte)joints[i].Id);

                checksum += (byte)(joints[i].RealPosition);
                byteStream.Add((byte)(joints[i].RealPosition));

                checksum += (byte)(joints[i].RealPosition >> 8);
                byteStream.Add((byte)(joints[i].RealPosition >> 8));

            }

            // the checksum is inverted
            byteStream.Add((byte)(~checksum & 0xff));

            try
            {
                if (IsOpen)
                {
                    Stream.Write(byteStream.ToArray(), 0, byteStream.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public void SetSpeeds(List<IActuator> joints)
        {

            int count = joints.Count;
            var byteStream = new List<byte>();
            int checksum = 0;

            byteStream.Add(0xFF);
            byteStream.Add(0xFF);

            checksum += BroadcastId;
            byteStream.Add(BroadcastId);

            var length = (byte)((2 + 1) * count + 4);
            checksum += length;
            byteStream.Add(length);
            // Length (L+1) X N + 4   (L: Data Length per actuator, N: the number acutuators)

            checksum += (byte)Instruction.SyncWrite;
            byteStream.Add((byte)Instruction.SyncWrite); // Instruction

            checksum += (byte)Registers.MovingSpeed;
            byteStream.Add((byte)Registers.MovingSpeed); // Register Start Address

            checksum += 2;
            byteStream.Add(2); // Length of Data

            for (int i = 0; i < count; i++)
            {
                checksum += joints[i].Id;
                byteStream.Add((byte)joints[i].Id);

                checksum += (byte)(joints[i].RealPosition);
                byteStream.Add((byte)(joints[i].RealPosition));

                checksum += (byte)(joints[i].RealPosition >> 8);
                byteStream.Add((byte)(joints[i].RealPosition >> 8));

            }

            // the checksum is inverted
            byteStream.Add((byte)(~checksum & 0xff));

            try
            {
                if (IsOpen)
                {
                    Stream.Write(byteStream.ToArray(), 0, byteStream.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void SetSlops(List<IActuator> joints)
        {


            int count = joints.Count;
            var byteStream = new List<byte>();
            int checksum = 0;

            byteStream.Add(0xFF);
            byteStream.Add(0xFF);

            checksum += BroadcastId;
            byteStream.Add(BroadcastId);

            var length = (byte)((2 + 1) * count + 4);
            checksum += length;
            byteStream.Add(length);
            // Length (L+1) X N + 4   (L: Data Length per actuator, N: the number acutuators)

            checksum += (byte)Instruction.SyncWrite;
            byteStream.Add((byte)Instruction.SyncWrite); // Instruction

            checksum += (byte)Registers.CwComplianceSlop;
            byteStream.Add((byte)Registers.CwComplianceSlop); // Register Start Address

            checksum += 2;
            byteStream.Add(2); // Length of Data

            for (int i = 0; i < count; i++)
            {
                checksum += joints[i].Id;
                byteStream.Add((byte)joints[i].Id);

                checksum += (byte)(joints[i].RealPosition);
                byteStream.Add((byte)(joints[i].RealPosition));

                checksum += (byte)(joints[i].RealPosition >> 8);
                byteStream.Add((byte)(joints[i].RealPosition >> 8));

            }

            // the checksum is inverted
            byteStream.Add((byte)(~checksum & 0xff));

            try
            {
                if (IsOpen)
                {
                    Stream.Write(byteStream.ToArray(), 0, byteStream.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void SetMargins(List<IActuator> joints)
        {

            int count = joints.Count;
            var byteStream = new List<byte>();
            int checksum = 0;

            byteStream.Add(0xFF);
            byteStream.Add(0xFF);

            checksum += BroadcastId;
            byteStream.Add(BroadcastId);

            var length = (byte)((2 + 1) * count + 4);
            checksum += length;
            byteStream.Add(length);
            // Length (L+1) X N + 4   (L: Data Length per actuator, N: the number acutuators)

            checksum += (byte)Instruction.SyncWrite;
            byteStream.Add((byte)Instruction.SyncWrite); // Instruction

            checksum += (byte)Registers.CwComplianceMargin;
            byteStream.Add((byte)Registers.CwComplianceMargin); // Register Start Address

            checksum += 2;
            byteStream.Add(2); // Length of Data

            for (int i = 0; i < count; i++)
            {
                checksum += joints[i].Id;
                byteStream.Add((byte)joints[i].Id);

                checksum += (byte)(joints[i].RealPosition);
                byteStream.Add((byte)(joints[i].RealPosition));

                checksum += (byte)(joints[i].RealPosition >> 8);
                byteStream.Add((byte)(joints[i].RealPosition >> 8));

            }

            // the checksum is inverted
            byteStream.Add((byte)(~checksum & 0xff));

            try
            {
                if (IsOpen)
                {
                    Stream.Write(byteStream.ToArray(), 0, byteStream.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
