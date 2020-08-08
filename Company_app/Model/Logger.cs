using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_app.Model
{
    public class Logger
    {
        private static readonly Logger _instance;
        private readonly string _filePath = @"..\Log.txt";
        private static readonly string managerFilePath = @"..\“ManagerAccess.txt";
        private static readonly Random random = new Random()

;        //a private constructor provides that constructor can be called only inside this class
        private Logger()
        {
            if (!File.Exists(_filePath))
                File.Create(_filePath).Close();
            if (!File.Exists(managerFilePath))
                File.Create(managerFilePath).Close();
        }
        //a static constructor is called only once, so we will have only one instance of this class
        static Logger()
        {
            _instance = new Logger();
            LogManagerAccess();
        }

        private static void LogManagerAccess()
        {
            using (StreamWriter sw = File.AppendText(managerFilePath))
            {
                sw.WriteLine(random.Next(10000000, 100000000));
            }
        }

        public static Logger Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Log actions to a file 
        /// </summary>
        /// <param name="message"></param>
        public void LogCRUD(string message)
        {
            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine(message);
            }
        }

        public List<string> GetManagerCodes()
        {
            try
            {
                return File.ReadAllLines(managerFilePath).ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
           
        }
    }
}
