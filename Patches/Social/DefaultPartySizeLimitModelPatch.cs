using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Core;
using HarmonyLib;
using TaleWorlds.Library;

namespace AttributesReloaded.Patches.Social
{
	[HarmonyPatch(typeof(DefaultPartySizeLimitModel))]
	class DefaultPartySizeLimitModelPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("GetPartyMemberSizeLimit")]
        public static int GetPartyMemberSizeLimit(int __result, PartyBase party, StatExplainer explanation = null) =>
		    (int)(__result * party.GetPartyBonus(
                bonuses => bonuses.PartySizeMultiplier,
                (explanation != null)
                    ? (bonus, name) => explanation.AddLine(name + "'s SOC", bonus * __result)
                    : (LogBonusDelegate)null));
		
	}
}
