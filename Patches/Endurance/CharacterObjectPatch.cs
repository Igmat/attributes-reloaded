using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AttributesReloaded.Patches.Endurance
{
    [HarmonyPatch(typeof(CharacterObject))]
    class CharacterObjectPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("MaxHitPoints")]
        public static int MaxHitPoints(int __result, CharacterObject __instance) =>
            (int)(__result * (1 + new CharacterAttributeBonuses(__instance).HPMultiplier));

        [HarmonyPostfix]
        [HarmonyPatch("MaxHitpointsExplanation", MethodType.Getter)]
        public static StatExplainer MaxHitpointsExplanation(StatExplainer __result, CharacterObject __instance)
        {
            var bonuses = new CharacterAttributeBonuses(__instance);
            var bonusHP = (int)(__instance.MaxHitPoints() * bonuses.HPMultiplier / (1 + bonuses.HPMultiplier));
            __result.AddLine("Endurance modifier", bonusHP);
            return __result;
        }
    }
}
