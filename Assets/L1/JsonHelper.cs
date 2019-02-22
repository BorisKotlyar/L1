using System;
using UnityEngine;

namespace Lesson1.Utility
{
    /// <summary>
    /// Helper for json
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Parse json string
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="json">Json string that need to be parse</param>
        /// <returns>Object array class</returns>
        public static T[] FromJson<T>(string json)
        {
            var wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        /// <summary>
        /// Convert object array to json string
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="array">Array of objects</param>
        /// <returns></returns>
        public static string ToJson<T>(T[] array)
        {
            var wrapper = new Wrapper<T> { Items = array };
            return JsonUtility.ToJson(wrapper);
        }

        /// <summary>
        /// Helper wrapper for array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}