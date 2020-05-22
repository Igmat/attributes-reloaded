using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace AttributesReloaded.Patches.VigorAndControl
{
    [HarmonyPatch(typeof(MobileParty))]
    class MobilePartyPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("RecentEventsMorale", MethodType.Setter)]
        public static void RecentEventsMorale(MobileParty __instance, ref float value) =>
            value += value > __instance.RecentEventsMorale
                ? MoraleHelpers.increaseMoralGain(value - __instance.RecentEventsMorale, __instance)
                : MoraleHelpers.decreaseMoralLoss(value - __instance.RecentEventsMorale, __instance);
    }

    internal static class MoraleHelpers
    {
        public static float decreaseMoralLoss(float dif, MobileParty party)
        {
            if (party.Leader == null) return dif;
            var bonuses = new CharacterAttributeBonuses(party.Leader);
            var bonus = dif * bonuses.NegativeMoraleMultiplier;
            Logger.Log("Decrased morale loss by " + bonus + " for CON", party.Leader);
            return dif + bonus;
        }
        public static float increaseMoralGain(float dif, MobileParty party)
        {
            if (party.Leader == null) return dif;
            var bonuses = new CharacterAttributeBonuses(party.Leader);
            var bonus = dif * bonuses.PositiveMoraleMultiplier;
            Logger.Log("Increase morale gain by " + bonus + " for VIG", party.Leader);
            return dif + bonus;
        }
    }
}
