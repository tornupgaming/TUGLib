using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TUGLib.Forms
{
    public delegate void LogAddedHandler(string msg);
    public delegate void ProgressBarHandler(int percent);

    public class LogHandler
    {
        public static event LogAddedHandler OnLogReceived;
        public static event ProgressBarHandler OnProgressBarChanged;

        private static void LogReceived(string msg)
        {
            if (OnLogReceived != null)
            {
                OnLogReceived(msg);
            }
        }

        private static void ProgressBarChanged(int percent)
        {
            if (OnProgressBarChanged != null)
            {
                OnProgressBarChanged(percent);
            }
        }

        public static void Log(string msg)
        {
            LogReceived("["+DateTime.Now.ToShortTimeString()+"]: " + msg);
            System.Diagnostics.Debug.WriteLine("Log: " + msg);
        }

        public static void ChangeProgressBar(int percent)
        {
            ProgressBarChanged(percent);
        }
    }
}