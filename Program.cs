using System;
using WordPress2Valine.Common;
using GetText;

namespace WordPress2Valine
{
    class Program
    {
        public static readonly string savePath = Environment.CurrentDirectory + "\\Comment";

        [STAThread]
        static void Main(string[] args)
        {
            var localization = new Catalog("message", "./I18n", I18n.GetLanguageResource());
            try
            {
                Console.WriteLine(localization.GetString("打开WordPress评论数据(.json)"));
                string wordpressComments = FileReader.ReadFileFromDialog();
                var content = FileReader.ReadJson(wordpressComments);
                UrlDictionary.AutoAddDic(content);
                UrlDictionary.GetAllDic();
                Console.Write(localization.GetString("输入要替换的文章/页面id") + "\n"
                                + localization.GetString("例如 42,friend (不要添加\"/\")") + "\n"
                                + localization.GetString("输入 end 结束")+ "\n\n");
                while (true)
                {
                    Console.Write(localization.GetString("替换："));
                    string value = Console.ReadLine();
                    if (value == "end") break;
                    else if (value.IndexOf(',') == -1) continue;
                    string[] vs = value.Split(',');
                    UrlDictionary.AddDic(vs[0], vs[1]);
                }
                var result = WordPressToValine.Convert(content, savePath);
                if (result)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(localization.GetString("转换完成"));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(localization.GetString("转换失败"));
                }
                Console.WriteLine(localization.GetString("请按任意键退出..."));
                Console.ReadKey(true);
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(localization.GetString("请按任意键退出..."));
                Console.ReadKey(true);
            }
        }
    }
}
