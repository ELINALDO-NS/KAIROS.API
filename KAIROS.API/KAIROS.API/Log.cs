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

    }
}
