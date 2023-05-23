using System;
using System.Globalization;
using System.Resources;

namespace WordPress2Valine.Common
{
    public static class I18n
    {
        public static CultureInfo GetLanguageResource()
        {
            switch (CultureInfo.CurrentCulture.Name)
            {
                case "zh-CN":
                    return new CultureInfo("zh-CN");
                default:
                    return new CultureInfo("en-US");
            }
        }
    }
}
