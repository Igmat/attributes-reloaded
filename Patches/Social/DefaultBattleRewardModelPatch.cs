using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace AttributesReloaded.Patches.Social
{
    //[HarmonyPatch(typeof(DefaultBattleRewardModel))]
    //class DefaultBattleRewardModelPatch
    //{
    //    [HarmonyPostfix]
    //    [HarmonyPatch("CalculateInfluenceGain")]
    //    public static float CalculateInfluenceGain(float __result, PartyBase party, float influenceValueOfBattle, float contributionShare, StatExplainer explanation = null) =>
    //        __result * party.GetPartyBonus(
    //            bonuses => bonuses.InfluenceMultiplier,
    //            (bonus, name) => Logger.Log("Increase influence by " + bonus * __result + " for " + name + "'s SOC", party.Leader));

    //    [HarmonyPostfix]
    //    [HarmonyPatch("CalculateRenownGain")]
    //    public static float CalculateRenownGain(float __result, PartyBase party, float renownValueOfBattle, float contributionShare, StatExplainer explanation = null) =>
    //        __result * party.GetPartyBonus(
    //            bonuses => bonuses.RenownMultiplier,
    //            (bonus, name) => Logger.Log("Increase renown by " + bonus * __result + " for " + name + "'s SOC", party.Leader));
    //}
}
