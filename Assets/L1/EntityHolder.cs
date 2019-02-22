using System;
using System.Collections.Generic;
using System.Linq;
using Lesson1.Utility;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Lesson1.Model
{
    /// <summary>
    /// Basic static holder for all entities
    /// Controll save and load data
    /// </summary>
    public static class EntityHolder
    {
        private static List<DamagebleData> _entities = new List<DamagebleData>();
        private const string GAME_ID = "saveDataID";

        /// <summary>
        /// Register entity
        /// </summary>
        /// <param name="data">entity model data</param>
        public static void RegisterEntity(DamagebleData data)
        {
            _entities.Add(data);
        }

        /// <summary>
        /// Clear cached data
        /// </summary>
        public static void Clear()
        {
            _entities.Clear();
        }

        /// <summary>
        /// Save all entity data
        /// </summary>
        public static void Save()
        {
            // convert to Jason
            var jsonString = JsonHelper.ToJson(_entities.ToArray());

            // save to player prefs
            // maybe need add some player game id
            PlayerPrefs.SetString(GAME_ID, jsonString);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Load saved entity data
        /// </summary>
        public static void Load()
        {
            var savedJson = PlayerPrefs.GetString(GAME_ID);
            if (savedJson == null || savedJson.Length <= 0)
            {
                // generate default level data
                // ....

                var maxHealthValue = 100f;
                var maxArmorValue = 10f;

                Random.InitState(DateTime.Now.Second);
                for (var i = 0; i < Random.Range(1, 10); i++)
                {
                    var damagebleData = new DamagebleData(Random.Range(1f, maxHealthValue), Random.Range(1f, maxArmorValue), i);

                    // show debug information
                    damagebleData.DebugData();

                    // just for test
                    damagebleData.ApplyDamage(Random.Range(1f, maxHealthValue));
                }
            }
            else
            {
                var player = JsonHelper.FromJson<DamagebleData>(savedJson);
                _entities = player.ToList();

                // use some fabric to generate entity
                // ....

                // show debug information
                foreach (var damagebleData in _entities)
                {
                    damagebleData.DebugData();
                }
            }
        }
    }
}