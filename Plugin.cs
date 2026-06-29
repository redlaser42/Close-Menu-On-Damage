using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;
using CloseMenuOnDamage.Patches;
using System.Reflection;
using UnityEngine;

namespace CloseMenuOnDamage
{
    [BepInPlugin("com.redlaser42.CloseMenuOnDamage", "CloseMenuOnDamage", "1.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool>? Enabled;

        public static BaseUnityPlugin? BepInExConfigManager = null;

        private void Awake()
        {
        Enabled = Config.Bind("General", "Enabled", true, "Activates the plugin.");

        new InventoryScreenAwake_Patch().Enable();
        new PlayerApplyDamageInfo_Patch().Enable();

        var configManagerInfo = Chainloader.PluginInfos.TryGetValue(
        "com.bepis.bepinex.configurationmanager",
        out PluginInfo pluginInfo);

        if (configManagerInfo)
        {
            BepInExConfigManager = pluginInfo.Instance;
            MethodInfo displayMethod = BepInExConfigManager.GetType().GetMethod(
                "ToggleWindow",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            displayMethod?.Invoke(BepInExConfigManager, null);
        }

        }
        public static void CloseBepInExConfig()
        {
            var prop = BepInExConfigManager.GetType().GetProperty("DisplayingWindow",BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (prop != null && (bool)prop.GetValue(BepInExConfigManager))
            {
                prop.SetValue(BepInExConfigManager, false);
                return;
            }
        }
    }   
}
