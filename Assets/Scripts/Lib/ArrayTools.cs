using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lib
{
    public static class ArrayTools
    {
        public static T GetRandom<T>(T[] array)
        {
            if (array == null || array.Length == 0)
                throw new System.Exception("GetRandom array null");

            return array[Random.Range(0, array.Length)];
        }

        public static T GetRandom<T>(List<T> array)
        {
            if (array == null || array.Count == 0)
                throw new System.Exception("GetRandom array null");

            return array[Random.Range(0, array.Count)];
        }

        public static TKey GetRandomByFalseValue<TKey>(Dictionary<TKey, bool> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0)
                throw new System.Exception("GetRandom entry null");

            var temp = dictionary
                .Where(x => x.Value == false)
                .Select(x => x)
                .ToDictionary(k => k.Key);
            if (temp.Count >= 1)
            {
                var finalPair = temp.ElementAt(Random.Range(0, temp.Count));
                dictionary[finalPair.Key] = false;
                return finalPair.Key;
            }
            throw new System.Exception("GetRandom fit entry not found");
        }
    }
}
