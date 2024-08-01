using System;
using UnityEngine;

namespace Runtime
{
    public static class Instance
    {
        public static T GetByName<T>(string name, T defaultValue)
        {
            Type type = Type.GetType(name);

            T instance;

            if (type != null && typeof(T).IsAssignableFrom(type))
            {
                instance = (T)Activator.CreateInstance(type);
            }
            else
            {
                instance = defaultValue;
                Debug.LogError($"name '{name}' not found!!");
            }

            return instance;
        }
    }
}
