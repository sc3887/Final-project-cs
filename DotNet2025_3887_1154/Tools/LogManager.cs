using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Tools
{
    public static class LogManager
    {
        private static readonly string path = "Log";
        public static string space = "";

        //פונקציה לקבלת ניתוב התיקיה הנוכחית
        public static string 
            getPathDirectory()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }
        public static string getPathCurrentDirectory()
        {
            string fileName = $"{DateTime.Now:yyy-MM}.Log";
            return Path.Combine(getPathDirectory(), fileName); 
        }

        //פונקציה לקבלת ניתוב לקובץ הנתון
        public static string getCurrentFilePath()
        {
            string fileName = $"{DateTime.Now:yyy-MM-dd}.Log";
            return Path.Combine(getPathCurrentDirectory(), fileName);
        }

        public static void writingToLog(string nameProject, string nameFunc, string message)
        {
            //קבלת ניתוב התיקיה הנוכחית
            string currentDirectoryPath = getPathCurrentDirectory();    
            //קבלת ניתוב הקובץ הנוכחי
            string currentFilePath = getCurrentFilePath();
            
            //יצירת תיקיה חדשה במקרה שלא קיימת התיקיה הנוכחית 
            if(!Directory.Exists(currentDirectoryPath))
            {
                Directory.CreateDirectory(currentDirectoryPath);
            }
            
            //יצירת קובץ חדש במקרה שלא קיים הקובץ הנוכחי 
            if (!File.Exists(currentFilePath))
            {
                File.Create(currentFilePath);
            }

            //יצירת התוכן שיכתב לקובץ
            string contentFile = $"{DateTime.Now}\t{nameProject}.{nameFunc}: \t{message}";

            //הכנסת התוכן לתוך הקובץ
            File.AppendAllText(currentFilePath, contentFile + Environment.NewLine);

        }
        
            //פונקציה לניקוי כל התיקיות שנוצרו לפני יותר מחודשיים
            public static void cleanOldFolders()
            {
                var directories = Directory.GetDirectories(getPathDirectory());
                foreach (var d in directories)
                    if (Directory.GetCreationTime(d) < DateTime.Now.AddMonths(-2))
                        Directory.Delete(d, true);
            }
    }
}
