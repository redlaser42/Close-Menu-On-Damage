using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using CloseMenuOnDamage.Patches;
using HarmonyLib;
using System;
using System.Reflection;

namespace CloseMenuOnDamage
{
    [BepInPlugin("com.redlaser42.CloseMenuOnDamage", "CloseMenuOnDamage", "1.0.3")]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool>? Enabled;

        private void Awake()
        {
        Enabled = Config.Bind("General", "Enabled", true, "Activates the plugin.");

        new InventoryScreenAwake_Patch().Enable();
        new PlayerApplyDamageInfo_Patch().Enable();
        }
    }   
}
