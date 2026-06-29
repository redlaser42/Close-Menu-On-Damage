using EFT.UI;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;

namespace CloseMenuOnDamage.Patches
{
    internal class InventoryScreenAwake_Patch : ModulePatch
    {
        public static InventoryScreen? inventoryScreen = null;
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(InventoryScreen), "Awake", new System.Type[] { });
        }

        [PatchPostfix]
        static void Postfix(InventoryScreen __instance)
        {
            if (__instance != null)
            {
                inventoryScreen = __instance;
            }
            else
            {
                Logger.LogError("Could not Set inventory screen reference");
            }
        }
    }
}