using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace AttributesReloaded.Patches.Social
{
    [HarmonyPatch(typeof(Clan))]
    class ClanPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("AddRenown")]
        public static void AddRenown(Clan __instance, ref float value, bool shouldNotify = true) =>
            value = Helpers.AddRenown(__instance, value);

        private class Helpers
        {
            public static float AddRenown(Clan clan, float value) =>
                value * clan.GetPartyBonus(
                    bonuses => bonuses.RenownMultiplier,
                    (bonus, name) => Logger.Log("Increase renown by " + bonus * value + " for " + name + "'s SOC", clan.Leader.CharacterObject));
        }
    }
}
