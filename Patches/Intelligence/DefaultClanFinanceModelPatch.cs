using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using HarmonyLib;
using System.Linq;
using System;

namespace AttributesReloaded.Patches.Intelligence
{
    [HarmonyPatch(typeof(DefaultClanFinanceModel))]
    class DefaultClanFinanceModelPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("CalculateClanIncome")]
        public static void CalculateClanIncome(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals = false) =>
            goldChange.AddFactor(
                clan.GetPartyBonus(bonuses => bonuses.IncomeMultiplier, null) - 1,
                new TextObject("Additional income for Leaders' INT"));

        [HarmonyPostfix]
        [HarmonyPatch("CalculateClanExpenses")]
        public static void CalculateClanExpenses(Clan clan, ref ExplainedNumber goldChange, bool applyWithdrawals = false) =>
            goldChange.AddFactor(
                Math.Min(
                    clan.GetPartyBonus(bonuses => bonuses.ExpensesMultiplier, null) - 1,
                    Config.Instance.max_bonus_decreas),
                new TextObject("Decreasing expenses for Leaders' INT"));
    }
}
