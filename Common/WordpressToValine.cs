using System;
using Newtonsoft.Json.Linq;
using WordPress2Valine.Utils;

namespace WordPress2Valine.Common
{
    public class WordPressToValine
    {
        public static bool Convert(JArray o, string path)
        {
            try
            {
                int c = o.Count;
                Valine[] va = new Valine[c];
                for (int i = 0; i < c; i++)
                {
                    va[i] = new Valine();
                    va[i].comment = string.Format("<p>{0}</p>", Unicode.Decode(o[i]["comment_content"].ToString()));
                    va[i].createdAt = TimeConvert.Format(o[i]["comment_date_gmt"].ToString());
                    va[i].insertedAt.iso = TimeConvert.Format(o[i]["comment_date_gmt"].ToString());
                    va[i].ip = o[i]["comment_author_IP"].ToString();
                    va[i].link = o[i]["comment_author_url"].ToString();
                    va[i].mail = o[i]["comment_author_email"].ToString();
                    va[i].nick = Unicode.Decode(o[i]["comment_author"].ToString());
                    va[i].objectId = o[i]["comment_ID"].ToString();
                    va[i].ua = o[i]["comment_agent"].ToString();
                    va[i].updatedAt = TimeConvert.Format(o[i]["comment_date_gmt"].ToString());
                    va[i].url = UrlDictionary.GetDic(o[i]["comment_post_ID"].ToString());
                    if (o[i]["comment_parent"].ToString() != "0")
                    {
                        va[i].rid = o[i]["comment_parent"].ToString();
                        //遍历评论id，寻找回复层对应的主评论
                        for (int j = 0; j < c; j++)
                        {
                            if (va[i].rid == o[j]["comment_ID"].ToString())
                            {
                                var parent_id = o[j]["comment_parent"].ToString();
                                if (parent_id == "0") break;
                                va[i].rid = parent_id;
                            }
                        }
                    }
                    Console.WriteLine(string.Format("[Info] Email: {0}, NickName: {1}, Comment: {2}", va[i].mail, va[i].nick, va[i].comment));
                }
                FileWriter.SaveComment(path, va);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
