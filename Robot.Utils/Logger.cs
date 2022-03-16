using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;


namespace Robot.Utils
{
    public class Logger
    {
        private readonly Thread _thread;
        private readonly Queue<string> _loglist;
        private string _logPath;
        private StreamWriter _logStream;
        private readonly object _locker = new object();

        public string LogPath
        {
            get { return _logPath; }
            set { _logPath = value; }
        }

        public int LogBufferSize
        {
            get;
            set;
        }

        public bool Enable
        {
            get
            {
                return _thread.IsEnable;
            }
            set
            {
                if (value)
                {
                    _thread.Start();
                }
                else
                {
                    _thread.Stop();
                    Flush();
                }
            }
        }

        private readonly bool _autoFlush;
        public Logger(string path, int buffersize = 100, bool autoFlush = true)
        {
            _thread = new Thread(WriteToFile, ThreadPriority.Lowest);
            _thread.Starting += OnStarting;
            _thread.Stopped += OnStopped;
            _logPath = path;
            _loglist = new Queue<string>();
            _autoFlush = autoFlush;
            LogBufferSize = buffersize;
        }

        void OnStopped()
        {
            Flush();
            _logStream.Close();
            _logStream = null;
        }

        void OnStarting()
        {
            if (_logStream == null)
            {
                _logStream = File.AppendText(_logPath);
                _logStream.AutoFlush = _autoFlush;
            }
        }
       
        public void Dispose()
        {
            _thread.Stop(true);
            Flush();
            _logStream.Close();
        }

        ~Logger()
        {
            _thread.Stop(true);
            if (_logStream != null)
            {
                Flush();
                _logStream.Close();
            }
        }

        private void Flush()
        {
            for (int i = 0; i < _loglist.Count; i++)
            {
                lock (_locker)
                {
                    _logStream.WriteLine(_loglist.Dequeue());
                }
            }
            _logStream.Flush();
        }

        public void WriteLine(string inputLogText)
        {
            if (!Enable) return;
            lock (_locker)
            {
                _loglist.Enqueue(inputLogText);
                Console.WriteLine(inputLogText);
            }
        }

        private void WriteToFile()
        {
            if (_loglist.Count > LogBufferSize)
            {
                for (int i = 0; i < LogBufferSize; i++)
                {
                    lock (_locker)
                    {
                        _logStream.WriteLine(_loglist.Dequeue());
                    }
                }
            }

        }
    }
}
