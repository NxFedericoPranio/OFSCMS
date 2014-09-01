using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OFSCore.Util
{
    public class Log
    {

        private static List<LogItem> _list = new List<LogItem>();

        public static void AddLogEntry(string LogEntry)
        {
            LogItem l = (new LogItem());
            l.LogEntry=LogEntry;
            _list.Add(l);
        }

        public static bool SaveLog(string Logfile, bool AddDateTime)
        {
            string logMessage = string.Empty;
            //bool result = false;
            string Date = string.Empty;
            if(AddDateTime)
                Date = DateTime.Now.ToString() + " - ";
            if (_list.Count > 0)
            {
                foreach (LogItem logentry in _list)
                    logMessage += Date + logentry.LogEntry + "\r\n";

                bool restult = Util.AppendToFile(Logfile, logMessage, false);
                if(restult)
                    _list.Clear();
                return restult;
            }
            else
            {
                return true;
            }
        }

        public static bool LogEntry(string Logfile, string TextRow, bool AddDateTime){
            if (AddDateTime)
                TextRow = DateTime.Now.ToString() + " - " + TextRow;
            return Util.AppendToFile(Logfile,TextRow + "\r\n", false);
        }


        public static string GetLog(string NomeFile)
        {
            StreamReader sr = null;
            try
            {

                string result = string.Empty;
                //Pass the file path and file name to the StreamReader constructor
                sr = new StreamReader(NomeFile);

                //Read the first line of text
                result = sr.ReadToEnd();
                return result;
            }
            catch (System.Exception e)
            {
                return e.StackTrace;
            }
            finally
            {
                try
                {
                    sr.Close();
                    sr.Dispose();
                }
                catch
                {
                }
            }

        }

        public static bool DeleteLog(string NomeFile)
        {
            try
            {
                File.Delete(NomeFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetLogFileName()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }


    internal class LogItem
    {
        string _logEntry = string.Empty;

        internal string LogEntry
        {
            get { return _logEntry; }
            set { _logEntry = value; }
        }
    }
}
