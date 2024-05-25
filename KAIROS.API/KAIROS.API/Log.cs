using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API
{
    public static class Log
    {
        private static readonly object lockObj = new object();
        public static void GravaLog(string Log)
        {

            string diretorio = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\Log");
            Directory.CreateDirectory(diretorio);
            StreamWriter writer;
            lock (lockObj)
            {
                using (writer = File.AppendText(diretorio + @"\Log.txt"))
                {
                    writer.WriteLine(Log);
                    writer.Close();
                }

            }
        }

        public static void LimparLog()
        {
            string diretorio = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\Log");
            if (File.Exists(diretorio + @"\Log.txt"))
            {
                File.Delete(diretorio + @"\Log.txt");
            }

        }
        public static void GravaBkp(string Log, string Cliente)
        {


            string diretorio = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\BKP");
            Directory.CreateDirectory(diretorio);
            string data = DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
            string path = diretorio + $"\\{Cliente}_{data}.json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            StreamWriter writer;
            lock (lockObj)
            {
                using (writer = File.AppendText(path))
                {
                    writer.Write(Log);
                    writer.Close();
                }

            }
        }

    }
}
