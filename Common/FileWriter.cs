using System;
using System.IO;
using Newtonsoft.Json;

namespace WordPress2Valine.Common
{
    public class FileWriter
    {
        public static void SaveComment(string path, Valine[] v)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fp = string.Format("{0}\\Comment_{1}.json", path, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            if (!File.Exists(fp))
            {
                FileStream fs = new FileStream(fp, FileMode.Create, FileAccess.ReadWrite);
                fs.Close();
            }
            File.WriteAllText(fp, JsonConvert.SerializeObject(v));
            Console.WriteLine();
            Console.WriteLine(fp);
        }
    }
}
