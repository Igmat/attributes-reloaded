
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace AttributesReloaded.Patches.Intelligence
{
	[HarmonyPatch(typeof(DefaultCharacterDevelopmentModel))]
	public class DefaultCharacterDevelopmentModelPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("CalculateLearningRate", typeof(Hero), typeof(SkillObject), typeof(StatExplainer))]
        public static float CalculateLearningRate(float __result, Hero hero, SkillObject skill, StatExplainer explainer = null)
		{
			var bonus = __result * new CharacterAttributeBonuses(hero.CharacterObject).XPMultiplier;
            if (explainer != null)
            {
                explainer.AddLine("INT bonus", bonus); // TODO: Why this explainer stuff doesn't work?
            }
            Logger.Log("Bonus " + bonus.ToString("F2") + " learning rate from INT", hero.CharacterObject);
            return __result + bonus;
		}
	}
}
