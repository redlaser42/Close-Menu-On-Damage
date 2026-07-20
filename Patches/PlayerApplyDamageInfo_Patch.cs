using EFT;
using EFT.UI;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Collections;
using System.Reflection;

namespace CloseMenuOnDamage.Patches
{
    internal class PlayerApplyDamageInfo_Patch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(Player), "ApplyDamageInfo", new System.Type[] { typeof(DamageInfoStruct), typeof(EBodyPart), typeof(EBodyPartColliderType), typeof(float) });
        }

        [PatchPostfix]
        static void Postfix(Player __instance, DamageInfoStruct damageInfo)
        {
            CloseNextFrame();
        }


        private static IEnumerator CloseNextFrame()
        {
            yield return null;

            var screen = InventoryScreenAwake_Patch.inventoryScreen;
            screen?.method_8();
        }
    }
}