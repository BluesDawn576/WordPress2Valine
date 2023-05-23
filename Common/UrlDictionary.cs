using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace WordPress2Valine.Common
{
    class UrlDictionary
    {
        public static Dictionary<string, string> dic;
        
        private static void CreateDic()
        {
            dic = new Dictionary<string, string>();
        }
        public static void AutoAddDic(JArray o)
        {
            int c = o.Count;
            for (int i = 0; i < c; i++)
            {
                AddDic(o[i]["comment_post_ID"].ToString());
            }
        }
        public static void AddDic(string wordpressId)
        {
            AddDic(wordpressId, wordpressId);
        }
        public static void AddDic(string wordpressId, string hexoId)
        {
            if (dic == null)
            {
                CreateDic();
            }
            if (dic.ContainsKey(wordpressId))
            {
                if (dic[wordpressId] == "/" + hexoId + "/") return;
                dic[wordpressId] = "/" + hexoId + "/";
                Console.WriteLine("WordPress = {0} => Valine = {1}", wordpressId, dic[wordpressId]);
            }
            else
            {
                dic.Add(wordpressId, "/" + hexoId + "/");
            }
        }
        /// <summary>
        /// comment_post_ID 转 Hexo 链接后缀
        /// </summary>
        /// <param name="id">comment_post_ID</param>
        public static string GetDic(string id) 
        {
            if (dic == null)
            {
                CreateDic();
            }

            if (dic.ContainsKey(id))
            {
                return dic[id];
            }
            else
            {
                return null;
            }
        }
        public static void GetAllDic()
        {
            if (dic == null)
            {
                CreateDic();
            }
            Console.WriteLine("---------------");
            foreach (var d in dic)
            {
                Console.WriteLine("WordPress = {0} => Valine = {1}", d.Key, d.Value);
            }
            Console.WriteLine("---------------");
        }
    }
}
