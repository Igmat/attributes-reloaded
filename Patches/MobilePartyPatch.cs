using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace AttributesReloaded
{
    [HarmonyPatch(typeof(MobileParty))]
    class MobilePartyPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("RecentEventsMorale", MethodType.Setter)]
        public static void RecentEventsMorale(MobileParty __instance, ref float value)
        {
            var dif = value - __instance.RecentEventsMorale;
            value += dif > 0
                ? MoraleHelpers.increaseMoralGain(dif, __instance)
                : MoraleHelpers.decreaseMoralLoss(dif, __instance);
        }
    }

    internal static class MoraleHelpers
    {
        public static float decreaseMoralLoss(float __result, MobileParty party)
        {
            if (party.Leader == null) return __result;
            var bonuses = new CharacterAttributeBonuses(party.Leader);
            var bonus = __result * bonuses.NegativeMoraleMultiplier;
            Logger.Log("Decrased morale loss by " + bonus + " for CON", party.Leader);
            return __result + bonus;
        }
        public static float increaseMoralGain(float __result, MobileParty party)
        {
            if (party.Leader == null) return __result;
            var bonuses = new CharacterAttributeBonuses(party.Leader);
            var bonus = __result * bonuses.PositiveMoraleMultiplier;
            Logger.Log("Increase morale gain by " + bonus + " for VIG", party.Leader);
            return __result + bonus;
        }
    }
}
