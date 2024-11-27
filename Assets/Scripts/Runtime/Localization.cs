using System.Collections.Generic;

namespace Runtime
{
    public static class Localization
    {
        private static Dictionary<string, string> stringKeys = new Dictionary<string, string>();

        static Localization()
        {
            stringKeys.Add("01", "Название снаряда");
            stringKeys.Add("02", "Описание снаряда");
        }

        public static string GetByKey(string key)
        {
            if (stringKeys.TryGetValue(key, out string value))
                return value;

            return "";
        }
    }
}
