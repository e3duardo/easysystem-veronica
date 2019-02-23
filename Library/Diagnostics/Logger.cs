using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Library.Diagnostics
{
    public class Logger
    {

        private Logger()
        {
        }

        static public void Error(Exception ex)
        {
            Stream fs = null;
            try
            {
                if (!(System.IO.Directory.Exists(Application.StartupPath + "\\logs\\")))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\logs\\");
                }
                

                fs = new FileStream(Application.StartupPath + "\\logs\\errorlog.txt", FileMode.Append, FileAccess.Write);
                using (StreamWriter s = new StreamWriter(fs))
                {
                    fs = null;
                    s.Write("Title: " + ex.TargetSite + "\r\n");
                    s.Write("Message: " + ex.Message + "\r\n");
                    s.Write("StackTrace: " + ex.StackTrace + "\r\n");
                    s.Write("Date/Time: " + DateTime.Now.ToString() + "\r\n");
                    s.Write("===========================================================================================\r\n\r\n");
                }

                Console.WriteLine(ex);
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        public bool WriteToEventLog(string entry, string appName, EventLogEntryType eventType, string LogName)
        {
            EventLog objEventLog = new EventLog();
            try
            {
                if (!(EventLog.SourceExists(appName)))
                {
                    EventLog.CreateEventSource(appName, LogName);
                }
                objEventLog.Source = appName;
                objEventLog.WriteEntry(entry, eventType);
                return true;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                return false;
            }
            finally
            {
                objEventLog.Close();
            }
        }
    }
}
