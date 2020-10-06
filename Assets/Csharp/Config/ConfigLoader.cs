using System.Collections;
using System.Collections.Generic;
using System.IO;
using Csharp.Model.Config;
using Csharp.Util;
using UnityEngine;

namespace Csharp.Config {
    public class ConfigLoader
    {
        private const string ConfigPath = "Data/Config/";
        private const string GeneralConfigFile = "general_config.json";
        private static ConfigLoader instance;
        private static string DefaultConfigJson 
            = "{\"musicVolume\":70,\"sfxVolume\":100,\"voiceVolume\":100,\"fullScreen\":false,\"screenResolution\":0}";
        
        public GeneralConfig GeneralConfig { get; private set; }
        
        private ConfigLoader()
        {
            SetupConfigs();
        }
        
        public static ConfigLoader GetInstance()
        {
            return instance ?? (instance = new ConfigLoader());
        }

        private void SetupConfigs()
        {
            ReadConfigs();
            SaveConfigs();
        }

        private void ReadConfigs()
        {
            var configText = FileReaderUtil.ReadFile(ConfigPath, GeneralConfigFile);
            if(string.IsNullOrEmpty(configText)) {

            }
            GeneralConfig = JsonUtility.FromJson<GeneralConfig>(configText);
        }

        private void SaveConfigs()
        {
            var configText = JsonUtility.ToJson(GeneralConfig);
            FileWriterUtil.WriteFile(ConfigPath, GeneralConfigFile, configText);
        }
    }
}