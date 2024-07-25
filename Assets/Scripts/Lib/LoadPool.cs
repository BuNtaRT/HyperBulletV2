using System.Collections.Generic;
using UnityEngine;

namespace Lib
{
    public static class LoadPool
    {
        private static Dictionary<string, Object> _cache = new Dictionary<string, Object>();

        public static T Load<T>(string path)
            where T : Object
        {
            if (_cache.TryGetValue(path, out Object value))
                return value as T;

            T resource = Resources.Load<T>(path);
            if (resource != null)
            {
                _cache[path] = resource;
            }
            return resource;
        }

        public static void DropCache() => _cache = new Dictionary<string, Object>();
    }
}
