﻿using System.Collections.Generic;
using System.IO;

namespace SevenDaysProfileEditor {

    /// <summary>
    /// Deals with configuration file.
    /// </summary>
    internal class Config {
        private static Dictionary<string, string> config = new Dictionary<string, string>();

        /// <summary>
        /// Gets the requested setting.
        /// </summary>
        /// <param name="key">Setting to get</param>
        /// <returns>Setting value or null if not found</returns>
        public static string GetSetting(string key) {
            config.TryGetValue(key, out string value);

            return value;
        }

        /// <summary>
        /// Loads the configuration file.
        /// </summary>
        public static void Load() {
            if (File.Exists("7DaysProfileEditor.config")) {
                using (StreamReader reader = new StreamReader("7DaysProfileEditor.config")) {
                    while (!reader.EndOfStream) {
                        string[] keyValue = reader.ReadLine().Split('=');

                        config.Add(keyValue[0], keyValue[1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the setting
        /// </summary>
        /// <param name="key">Setting to set</param>
        /// <param name="value">Value to set the setting to</param>
        public static void SetSetting(string key, string value) {
            config[key] = value;
            Save();
        }

        /// <summary>
        /// Saves the config file.
        /// </summary>
        private static void Save() {
            using (StreamWriter writer = new StreamWriter("7DaysProfileEditor.config")) {
                foreach (KeyValuePair<string, string> setting in config) {
                    writer.WriteLine(string.Format("{0}={1}", setting.Key, setting.Value));
                }
            }
        }
    }
}