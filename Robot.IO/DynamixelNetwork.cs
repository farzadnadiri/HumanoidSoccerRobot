using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;

namespace Robot.IO
{
    public class DynamixelNetwork
    {
        private const int Header = 0xff;

        /// <summary>
        /// The types of instructions that can be sent to Dynamixels using WriteInstruction.
        /// </summary>
        /// <seealso cref="WriteInstruction"/>
        public enum Instruction : byte
        {
            /// <summary>
            /// Respond only with a status packet.
            /// </summary>
            Ping = 1,
            /// <summary>
            /// Read register data.
            /// </summary>
            ReadData = 2,
            /// <summary>
            /// Write register data.
            /// </summary>
            WriteData = 3,
            /// <summary>
            /// Delay writing register data
            /// until an Action instruction is received.
            /// </summary>
            RegWrite = 4,
            /// <summary>
            /// Perform pending RegWrite instructions.
            /// </summary>
            Action = 5,
            /// <summary>
            /// Reset all registers (including ID) to default values.
            /// </summary>
            Reset = 6,
            /// <summary>
            /// Write register data to multiple Dynamixels at once.
            /// </summary>
            SyncWrite = 0x83,
        }

        [Flags]
        public enum ErrorStatus : byte
        {
            /// <summary>
            /// Input Voltage Error
            /// </summary>
            [Description("Input Voltage Error")]
            InputVoltage = 1,
            /// <summary>
            /// Angle Limit Error
            /// </summary>
            [Description("Angle Limit Error")]
            AngleLimit = 2,
            /// <summary>
            /// Overheating Error
            /// </summary>
            [Description("Overheating Error")]
            Overheating = 4,
            /// <summary>
            /// Range Error
            /// </summary>
            [Description("Range Error")]
            Range = 8,
            /// <summary>
            /// Checksum Error
            /// </summary>
            [Description("Checksum Error")]
            Checksum = 0x10,
            /// <summary>
            /// Overload Error
            /// </summary>
            [Description("Overload Error")]
            Overload = 0x20,
            /// <summary>
            /// Instruction Error
            /// </summary>
            [Description("Instruction Error")]
            Instruction = 0x40,
        }

        public const int BroadcastId = 254;
        private object _key;

        private SerialPort _stream;
        protected SerialPort Stream
        {
            set
            {
                lock (_key)
                {
                    _stream = value;
                }
            }

            get
            {
                lock (_key)
                {
                    return _stream;
                }
            }
        }

        public bool IsOpen
        {
            protected set;
            get;
        }

        public DynamixelNetwork(string portName, int baudNum)
        {
            _key = new object();
            _stream = new SerialPort(portName)
            {
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DtrEnable = true,
                ReadBufferSize = 2048,
                WriteBufferSize = 2048,
                ReadTimeout = 50,
                WriteTimeout = 50
            };
            BaudNum = baudNum;
        }

        private int _baudnum;
        public int BaudNum
        {
            get
            {
                return _baudnum;
            }
            set
            {
                lock (_key)
                {
                    _baudnum = value;
                    _stream.BaudRate = 2000000 / (value + 1);
                }
            }
        }

        public int BaudRate
        {
            get
            {
                lock (_key)
                {
                    return _stream.BaudRate;
                }
            }
            set
            {
                lock (_key)
                {
                    _stream.BaudRate = value;
                    _baudnum = (2000000 / value) - 1;
                }
            }
        }

        public bool Open(string portname)
        {
            try
            {
                lock (_key)
                {
                    _stream.PortName = portname;
                    _stream.Open();
                    IsOpen = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                IsOpen = false;
            }
            return IsOpen;
        }

        public bool Open()
        {
            try
            {
                lock (_key)
                {
                    _stream.Open();
                    IsOpen = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                IsOpen = false;
            }
            return IsOpen;
        }

        public bool Close()
        {
            try
            {
                lock (_key)
                {
                    _stream.Close();
                    IsOpen = false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                IsOpen = true;
            }
            return !IsOpen;
        }

        private enum PacketState
        {
            FirstHeader,
            SecondHeader,
            Id,
            Length,
            Error,
            Parameters,
            Checksum
        }


        protected bool FetchPacket(out int id, out byte[] data)
        {
            lock (_key)
            {

                id = Header;
                int length = 0;
                int error = 0;
                int checksum = 0;
                data = null;
                var state = PacketState.FirstHeader;

                while (true)
                {
                    int newByte;
                    try
                    {
                        newByte = _stream.ReadByte();
                    }
                    catch
                    {
                        return false;
                    }

                    switch (state)
                    {
                        case PacketState.FirstHeader:
                            if (newByte == Header)
                            {
                                state = PacketState.SecondHeader;
                            }
                            break;

                        case PacketState.SecondHeader:
                            if (newByte == Header)
                            {
                                state = PacketState.Id;
                            }
                            break;

                        case PacketState.Id:
                            id = newByte;
                            state = PacketState.Length;
                            break;

                        case PacketState.Length:
                            length = newByte - 2;
                            state = PacketState.Error;
                            break;

                        case PacketState.Error:
                            error = newByte; // TODO: Call Some Events on error conditions 
                            if (length <= 0)
                            {
                                data = null;
                                state = PacketState.Checksum;
                            }
                            else
                            {
                                state = PacketState.Parameters;
                            }
                            break;

                        case PacketState.Parameters:
                            data = new byte[length];
                            data[0] = (byte)newByte;
                            length--;
                            int offset = 1;
                            int count;
                            while (length > 0)
                            {
                                try
                                {
                                    count = _stream.Read(data, offset, length);
                                    length -= count;
                                    offset += count;
                                }
                                catch
                                {
                                    return false;
                                }
                            }
                            state = PacketState.Checksum;
                            break;
                        case PacketState.Checksum:
                            checksum = newByte; // TODO: Calculate Checksum and return false if is not eqaul to recieved checksum
                            return true;
                    }

                }
            }
        }


        private int _packetId;
        private int _packetLength;

        protected bool GetPacket(int id, int length, out byte[] data)
        {
            lock (_key)
            {
                data = null;
                if (id == BroadcastId)
                    return false;

                var sw = new Stopwatch();
                sw.Start();
                do
                {
                    if (FetchPacket(out _packetId, out data))
                    {
                        _packetLength = data == null ? 0 : data.Length;
                        if (_packetId == id && _packetLength == length)
                            return true; // this is the normal return case
                    }

                } while (sw.ElapsedMilliseconds < _stream.ReadTimeout);

                return false;
            }
        }

        protected void WriteInstruction(int id, byte instruction, List<byte> parms)
        {
            lock (_key)
            {
                // command packet sent to Dynamixel servo:
                // [0xFF] [0xFF] [id] [length] [...data...] [checksum]
                var instructionPacket = new List<byte>
                           {
                               0xFF,
                               0xFF,
                               (byte) id,
                               (byte) (((parms != null) ? parms.Count : 0) + 2), // length is the data-length + 2
                               instruction
                           };

                if (parms != null && parms.Count != 0)
                    instructionPacket.AddRange(parms);

                var cheksum = 0;
                for (var i = 2; i < instructionPacket.Count; i++)
                {
                    cheksum += instructionPacket[i];
                }
                instructionPacket.Add((byte)(~(cheksum & 0xff)));

                try
                {
                    _stream.Write(instructionPacket.ToArray(), 0, instructionPacket.Count);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        public int ReadByte(int id, int address)
        {
            lock (_key)
            {
                byte[] data = ReadData(id, (byte)address, 1);

                if (data != null && data.Length == 1)
                {
                    return data[0];
                }

                return 0;

            }
        }

        public int ReadWord(int id, int address)
        {
            lock (_key)
            {
                byte[] data = ReadData(id, (byte)address, 2);
                if (data != null && data.Length == 2)
                {
                    return (data[1] << 8) + data[0];
                }
                return 0;
            }
        }

        public byte[] ReadData(int id, byte startAddress, int count)
        {
            lock (_key)
            {
                var parameters = new List<byte> { startAddress, (byte)count };
                WriteInstruction(id, (byte)Instruction.ReadData, parameters);
                byte[] data;
                GetPacket(id, count, out data);
                return data;
            }
        }

        public void WriteData(int id, int startAddress, List<byte> values, bool flush)
        {
            lock (_key)
            {
                var writePacket = new List<byte> { (byte)startAddress };
                writePacket.AddRange(values);
                WriteInstruction(id, flush ? (byte)Instruction.WriteData : (byte)Instruction.RegWrite, writePacket);
                //if (flush)
                //{
                //    byte[] data;
                //    GetPacket(id, 0, out data);
                //}
            }
        }

        public void WriteByte(int id, int registerAddress, int value, bool flush)
        {
            lock (_key)
            {
                WriteData(id, registerAddress, new List<byte> { (byte)value }, flush);
            }
        }

        public void WriteWord(int id, int registerAddress, int value, bool flush)
        {
            lock (_key)
            {
                WriteData(id, registerAddress, new List<byte> { (byte)(value & 0xFF), (byte)(value >> 8) }, flush);
            }
        }

        public List<int> ScanIds(int startId, int endId)
        {
            lock (_key)
            {
                if (endId > 253 || endId < 0)
                    return null;
                if (startId > endId || startId < 0)
                    return null;

                var ids = new List<int>();
                for (int id = startId; id <= endId; id++)
                {
                    if (Ping(id))
                        ids.Add(id);
                }
                return ids;
            }
        }

        public void Action()
        {
            lock (_key)
            {
                WriteInstruction(BroadcastId, (byte)Instruction.Action, null);
            }
        }

        public bool Ping(int id)
        {
            lock (_key)
            {
                WriteInstruction(id, (byte)Instruction.Ping, null);
                byte[] data;
                return GetPacket(id, 0, out data);
            }
        }

        public void SyncWriteByte(byte startAddress, int count, int[] parms)
        {
            lock (_key)
            {
                var byteStream = new List<byte>();
                int checksum = 0;

                byteStream.Add(0xFF);
                byteStream.Add(0xFF);

                checksum += BroadcastId;
                byteStream.Add(BroadcastId);

                var length = (byte)((1 + 1) * count + 4);
                checksum += length;
                byteStream.Add(length);
                // Length (L+1) X N + 4   (L: Data Length per actuator, N: the number acutuators)

                checksum += (byte)Instruction.SyncWrite;
                byteStream.Add((byte)Instruction.SyncWrite); // Instruction

                checksum += startAddress;
                byteStream.Add(startAddress); // Register Start Address

                checksum += 1;
                byteStream.Add(1); // Length of Data

                for (int i = 0; i < count; i++)
                {
                    checksum += i + 1;
                    byteStream.Add((byte)(i + 1));

                    checksum += (byte)(parms[i]);
                    byteStream.Add((byte)(parms[i]));
                }

                // the checksum is inverted
                byteStream.Add((byte)(~checksum & 0xff));

                _stream.Write(byteStream.ToArray(), 0, byteStream.Count);
            }
        }

        public void SyncWriteWord(byte startAddress, int count, int[] parms)
        {
            lock (_key)
            {
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

                checksum += startAddress;
                byteStream.Add(startAddress); // Register Start Address

                checksum += 2;
                byteStream.Add(2); // Length of Data

                for (int i = 0; i < count; i++)
                {
                    checksum += i + 1;
                    byteStream.Add((byte)(i + 1));

                    checksum += (byte)(parms[i]);
                    byteStream.Add((byte)(parms[i]));

                    checksum += (byte)(parms[i] >> 8);
                    byteStream.Add((byte)(parms[i] >> 8));

                }

                // the checksum is inverted
                byteStream.Add((byte)(~checksum & 0xff));

                _stream.Write(byteStream.ToArray(), 0, byteStream.Count);
            }
        }

        public void SyncWriteDoubleWord(byte startAddress, int count, int[] first, int[] second)
        {
            lock (_key)
            {
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

                checksum += startAddress;
                byteStream.Add(startAddress); // Register Start Address

                checksum += 4;
                byteStream.Add(4); // Length of Data

                for (int i = 0; i < count; i++)
                {
                    checksum += i + 1;
                    byteStream.Add((byte)(i + 1));

                    checksum += (byte)(first[i]);
                    byteStream.Add((byte)(first[i]));

                    checksum += (byte)(first[i] >> 8);
                    byteStream.Add((byte)(first[i] >> 8));

                    checksum += (byte)(second[i]);
                    byteStream.Add((byte)(second[i]));

                    checksum += (byte)(second[i] >> 8);
                    byteStream.Add((byte)(second[i] >> 8));
                }

                // the checksum is inverted
                byteStream.Add((byte)(~checksum & 0xff));

                _stream.Write(byteStream.ToArray(), 0, byteStream.Count);
            }
        }

    }
}
