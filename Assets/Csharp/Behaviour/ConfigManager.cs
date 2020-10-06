using UnityEngine;
using Csharp.Config;

public class ConfigManager : MonoBehaviour
{
    private ConfigLoader configsLoader;
    public ConfigManager()
    {  
        configsLoader = ConfigLoader.GetInstance();
    }
}