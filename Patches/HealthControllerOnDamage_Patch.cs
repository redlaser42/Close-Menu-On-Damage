using EFT;
using EFT.UI;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using CloseMenuOnDamage;

namespace CloseMenuOnDamage.Patches
{
    internal class HealthControllerOnDamage_Patch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(Player), "ApplyDamageInfo", new System.Type[] { typeof(DamageInfoStruct), typeof(EBodyPart), typeof(EBodyPartColliderType), typeof(float) });
        }

        [PatchPostfix]
        static void Postfix(Player __instance, DamageInfoStruct damageInfo)
        {
            bool isBulletDamage = (damageInfo.DamageType == EDamageType.Bullet);
            if (isBulletDamage)
            {
                if (InventoryScreenAwake_Patch.inventoryScreen != null && Plugin.Enabled.Value)
                {
                    InventoryScreenAwake_Patch.inventoryScreen.method_8();
                }
            }
        }
    }
}