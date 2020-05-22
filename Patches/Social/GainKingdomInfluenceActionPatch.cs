using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace AttributesReloaded.Patches.Social
{
    [HarmonyPatch(typeof(GainKingdomInfluenceAction))]
    class GainKingdomInfluenceActionPatch
    {
        private static class Helpers
        {
            public static float ApplyToHero(Hero hero, float value) =>
                hero.IsPartyLeader
                    ? value * hero.PartyBelongedTo.GetPartyBonus(
                        bonuses => bonuses.InfluenceMultiplier,
                        (bonus, name) => Logger.Log("Increase influence by " + bonus * value + " for " + name + "'s SOC", hero.CharacterObject))
                    : value;

            public static float ApplyToParty(MobileParty side1Party, float value) =>
                value * side1Party.GetPartyBonus(
                    bonuses => bonuses.InfluenceMultiplier,
                    (bonus, name) => Logger.Log("Increase influence by " + bonus * value + " for " + name + "'s SOC", side1Party.Leader));
        }

        [HarmonyPrefix]
        [HarmonyPatch("ApplyForBattle")]
        public static void ApplyForBattle(Hero hero, ref float value) =>
            value = Helpers.ApplyToHero(hero, value);

        [HarmonyPrefix]
        [HarmonyPatch("ApplyForBeingAtArmy")]
        public static void ApplyForBeingAtArmy(MobileParty side1Party, ref float value) =>
            value = Helpers.ApplyToParty(side1Party, value);

        [HarmonyPrefix]
        [HarmonyPatch("ApplyForBesiegingEnemySettlement")]
        public static void ApplyForBesiegingEnemySettlement(MobileParty side1Party, ref float value) =>
            value = Helpers.ApplyToParty(side1Party, value);

        [HarmonyPrefix]
        [HarmonyPatch("ApplyForBoardGameWon")]
        public static void ApplyForBoardGameWon(Hero hero, ref float value) =>
            value = Helpers.ApplyToHero(hero, value);

        [HarmonyPrefix]
        [HarmonyPatch("ApplyForCapturingEnemySettlement")]
        public static void ApplyForCapturingEnemySettlement(MobileParty side1Party, ref float value) =>
            value = Helpers.ApplyToParty(side1Party, value);

        //[HarmonyPrefix]
        //[HarmonyPatch("ApplyForClanSupport")]
        //public static void ApplyForClanSupport(Hero hero);

        [HarmonyPrefix]
        [HarmonyPatch("ApplyForDefault")]
        public static void ApplyForDefault(Hero hero, ref float value) =>
            value = Helpers.ApplyToHero(hero, value);

        //[HarmonyPrefix]
        //[HarmonyPatch("ApplyForGivingFood")]
        //public static void ApplyForGivingFood(Hero hero1, Hero hero2, ref float value);

        [HarmonyPrefix]
        [HarmonyPatch("ApplyForJoiningFaction")]
        public static void ApplyForJoiningFaction(Hero hero, ref float value) =>
            value = Helpers.ApplyToHero(hero, value);

        [HarmonyPrefix]
        [HarmonyPatch("ApplyForLeavingTroopToGarrison")]
        public static void ApplyForLeavingTroopToGarrison(Hero hero, ref float value) =>
            value = Helpers.ApplyToHero(hero, value);

        [HarmonyPrefix]
        [HarmonyPatch("ApplyForRaidingEnemyVillage")]
        public static void ApplyForRaidingEnemyVillage(MobileParty side1Party, ref float value) =>
            value = Helpers.ApplyToParty(side1Party, value);
    }
}
