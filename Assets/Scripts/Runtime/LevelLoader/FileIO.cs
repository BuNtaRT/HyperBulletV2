using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Runtime.LevelLoader
{
    public static class FileIO
    {
        public static T Load<T>(params string[] path)
        {
            string combinedPath = Path.Combine(Application.persistentDataPath, Path.Combine(path));

            if (File.Exists(combinedPath))
            {
                string json = File.ReadAllText(combinedPath);

                if (typeof(T) == typeof(string[]))
                    return (T)(object)JsonConvert.DeserializeObject<string[]>(json);

                T data = JsonUtility.FromJson<T>(json);
                return data;
            }
            else
            {
                Debug.LogWarning("File 404! " + path);
                return default;
            }
        }

        public static void Save<T>(T data, params string[] path)
        {
            string combinedPath = Path.Combine(Application.persistentDataPath, Path.Combine(path));
            string directory = Path.GetDirectoryName(combinedPath);
            string json;

            if (directory != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (typeof(T) == typeof(string[]))
                json = JsonConvert.SerializeObject(data, Formatting.Indented);
            else
                json = JsonUtility.ToJson(data);


            File.WriteAllText(combinedPath, json);
        }
    }
}