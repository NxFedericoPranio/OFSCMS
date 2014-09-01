using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;

namespace DataClasses.OFS.PhotoGallery
{
    public class Util
    {
        public static List<string> ScanDir(string dir)
        {
            List<string> result = new List<string>();
            string[] dirs = System.IO.Directory.GetFiles(dir);
            foreach (string f in dirs)
            {
                result.Add(f);
            }
            return result;

        }

        public static List<string> ScanDirForDir(string dir)
        {
            List<string> result = new List<string>();
            string[] dirs = System.IO.Directory.GetDirectories(dir);
            foreach (string f in dirs)
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(f);
                result.Add(di.Name);
            }
            return result;

        }

        public static List<string> ArraySlice(List<string> List, int index1, int index2)
        {
            return List;
        }

        public static DateTime GetDateTime(string Timestamp)
        {
            if (Timestamp.Length == 8)
            {
                string Year = Timestamp.Substring(0, 4);
                string Day = Timestamp.Substring(6, 2);
                string Month = Timestamp.Substring(4, 2);

                return new DateTime(Convert.ToInt32(Year),
                    Convert.ToInt32(Month),
                    Convert.ToInt32(Day));
            }
            return new DateTime(1900, 1, 1);
        }

        public static DateTime GetDateTime(string DateStamp, string HourStamp)
        {
            if (DateStamp.Length == 8)
            {
                string Year = DateStamp.Substring(0, 4);
                string Day = DateStamp.Substring(6, 2);
                string Month = DateStamp.Substring(4, 2);

                string hours = "00";
                string minutes = "00";
                string seconds = "00";

                if (HourStamp.Length == 6)
                {
                    hours = HourStamp.Substring(0, 2);
                    minutes = HourStamp.Substring(2, 2);
                    seconds = HourStamp.Substring(4, 2);

                    return new DateTime(Convert.ToInt32(Year),
                        Convert.ToInt32(Month),
                        Convert.ToInt32(Day),
                        Convert.ToInt32(hours),
                        Convert.ToInt32(minutes),
                        Convert.ToInt32(seconds));
                }
                else
                    return new DateTime(Convert.ToInt32(Year),
                        Convert.ToInt32(Month),
                        Convert.ToInt32(Day));
            }
            return new DateTime(1900, 1, 1);
        }

        public static string GetDateStamp(DateTime Date)
        {
            string year = Convert.ToString(Date.Year);
            string day = (Date.Day < 10 ? "0" + Convert.ToString(Date.Day) : Convert.ToString(Date.Day));
            string month = (Date.Month < 10 ? "0" + Convert.ToString(Date.Month) : Convert.ToString(Date.Month));

            return year + month + day;
        }

        public static string GetDateStampIt(DateTime Date)
        {
            string year = Convert.ToString(Date.Year);
            string day = (Date.Day < 10 ? "0" + Convert.ToString(Date.Day) : Convert.ToString(Date.Day));
            string month = (Date.Month < 10 ? "0" + Convert.ToString(Date.Month) : Convert.ToString(Date.Month));

            return day + month + year;
        }

        public static string GetTimeStamp(DateTime Date)
        {
            string year = Convert.ToString(Date.Year);
            string day = (Date.Day < 10 ? "0" + Convert.ToString(Date.Day) : Convert.ToString(Date.Day));
            string month = (Date.Month < 10 ? "0" + Convert.ToString(Date.Month) : Convert.ToString(Date.Month));
            string hour = (Date.Hour < 10 ? "0" + Convert.ToString(Date.Hour) : Convert.ToString(Date.Hour));
            string minute = (Date.Minute < 10 ? "0" + Convert.ToString(Date.Minute) : Convert.ToString(Date.Minute));
            string second = (Date.Second < 10 ? "0" + Convert.ToString(Date.Second) : Convert.ToString(Date.Second));

            return year + month + day + hour + minute + second;
        }

        public static bool CheckAndCreateDirectory(string DirectoryName)
        {
            try
            {
                if (!System.IO.Directory.Exists(DirectoryName))
                    System.IO.Directory.CreateDirectory(DirectoryName);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public static string ReadFilePerInput(string NomeFile)
        {
            return ReadFilePerInput(NomeFile, Encoding.UTF8, "\n");
        }

        public static string ReadFilePerInput(string NomeFile, Encoding encod, string RowSep)
        {
            StreamReader sr = null;
            try
            {
                string line = string.Empty;
                string result = string.Empty;
                //Pass the file path and file name to the StreamReader constructor
                sr = new StreamReader(NomeFile, encod);

                //Read the first line of text
                line = sr.ReadLine();
                result += line + RowSep;

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //Read the next line
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        result += line + RowSep;
                    }
                }


                return result;
            }
            catch (System.Exception e)
            {
                return null;
            }
            finally
            {
                try
                {
                    sr.Close();
                }
                catch
                {
                }
            }

        }


        public static bool AppendToFile(string NomeFile, string Text, bool Delete)
        {
            if (File.Exists(NomeFile) && Delete)
                File.Delete(NomeFile);

            System.IO.StreamWriter sw = null;
            try
            {
                FileInfo filei = new FileInfo(NomeFile);
                DirectoryInfo d = filei.Directory;
                if (!d.Exists)
                    d.Create();
                //Pass the filepath and filename to the StreamWriter Constructor
                sw = new System.IO.StreamWriter(new System.IO.FileStream(NomeFile,
                    System.IO.FileMode.Append,
                    System.IO.FileAccess.Write,
                    System.IO.FileShare.None));

                //Write a line of text
                sw.Write(Text);


                return true;

            }
            catch (System.Exception e)
            {
                return false;
            }
            finally
            {
                //Close the file
                try
                {
                    sw.Close();
                }
                catch
                {
                    ;
                }
            }
        }

        public static string FormatAccCode(string AccCode)
        {
            StringBuilder sb = new StringBuilder(AccCode);
            int v = (sb.Length - 1) / 3;
            for (int j = v; j > 0; j--)
            {
                sb.Insert(sb.Length - (j * 3), '.');
            }
            return sb.ToString();
        }
    }
}