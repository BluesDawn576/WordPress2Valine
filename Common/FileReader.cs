using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WordPress2Valine.Common
{
    public class FileReader
    {
        public static JArray ReadJson(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JArray o = (JArray)JToken.ReadFrom(reader);
                    return o;
                }
            }
        }
        public static string ReadFileFromDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "WordPress Data(*.json)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return null;
        }
    }
}
