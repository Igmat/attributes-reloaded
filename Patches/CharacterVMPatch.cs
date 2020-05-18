
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Core;

namespace AttributesReloaded
{
    [HarmonyPatch(typeof(CharacterVM))]
    [HarmonyPatch("CurrentSkill", MethodType.Getter)]
    class HeroDeveloperPatch
    {
        public static SkillVM Postfix(SkillVM __result, CharacterVM __instance)
        {
            if (__result == null) return __result;
            var bonuses = new CharacterAttributeBonuses(__instance.Hero.CharacterObject);
            var lerningRate = __result.LearningRate;
            var bonus = lerningRate * bonuses.XPMultiplier;
            __result.CurrentLearningRateText = "Learning Rate: x " + (lerningRate + bonus).ToString("F2");

            return __result;
        }
    }
}
