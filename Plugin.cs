using BepInEx;
using BepInEx.Configuration;
using CloseMenuOnDamage.Patches;

namespace CloseMenuOnDamage
{
    [BepInPlugin("com.redlaser42.CloseMenuOnDamage", "CloseMenuOnDamage", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool>? Enabled;

        private void Awake()
        {
        new InventoryScreenAwake_Patch().Enable();
        new HealthControllerOnDamage_Patch().Enable();



        Enabled = Config.Bind("General", "Enabled", true, "Activates the plugin.");

        }
    }   
}
