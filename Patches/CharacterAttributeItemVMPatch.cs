using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Core;
using TaleWorlds.Library;


namespace AttributesReloaded.Patches
{
    [HarmonyPatch(typeof(CharacterAttributeItemVM), MethodType.Constructor)]
    [HarmonyPatch(new Type[] { typeof(Hero), typeof(CharacterAttributesEnum), typeof(CharacterVM), typeof(Action<CharacterAttributeItemVM>), typeof(Action<CharacterAttributeItemVM>) })]
    class CharacterAttributeItemVMPatch
    {
        public static void Postfix(CharacterAttributeItemVM __instance, Hero hero, CharacterAttributesEnum currAtt, CharacterVM developerVM, Action<CharacterAttributeItemVM> onInpectAttribute, Action<CharacterAttributeItemVM> onAddAttributePoint)
        {
            var bonuses = new CharacterAttributeBonuses(hero.CharacterObject);
            var text = "";
            switch (currAtt)
            {
                case CharacterAttributesEnum.Vigor:
                    text += bonuses.MeleeDamageMultiplier > 0
                        ? "Increases melee damage by " + bonuses.MeleeDamageMultiplier.ToString("P") + "\n"
                        : "";
                    text += bonuses.MeleeSpeedMultiplier > 0
                        ? "Increases melee atack speed by " + bonuses.MeleeSpeedMultiplier.ToString("P") + "\n"
                        : "";
                    text += bonuses.PositiveMoraleMultiplier > 0
                        ? "Increases morale gain by " + bonuses.PositiveMoraleMultiplier.ToString("P") + "\n"
                        : "";
                    break;
                case CharacterAttributesEnum.Control:
                    text += bonuses.RangeDamageMultiplier > 0
                        ? "Increases range damage by " + bonuses.RangeDamageMultiplier.ToString("P") + "\n"
                        : "";
                    text += bonuses.RangeSpeedMultiplier > 0
                        ? "Increases range atack speed by " + bonuses.RangeSpeedMultiplier.ToString("P") + "\n"
                        : "";
                    text += bonuses.NegativeMoraleMultiplier < 0
                        ? "Decrease morale loss by " + (-bonuses.NegativeMoraleMultiplier).ToString("P") + "\n"
                        : "";
                    break;
                case CharacterAttributesEnum.Endurance:
                    text += bonuses.HPMultiplier > 0
                        ? "Increases HP by " + bonuses.HPMultiplier.ToString("P") + "\n"
                        : "";
                    text += bonuses.MoveSpeedMultiplier > 0
                        ? "Increases move speed by " + bonuses.MoveSpeedMultiplier.ToString("P") + "\n"
                        : "";
                    break;
                case CharacterAttributesEnum.Cunning:
                    text += bonuses.AttributeEffectMultiplier > 0
                        ? "Increases effect of other attributes by " + (bonuses.AttributeEffectMultiplier - 1).ToString("P") + "\n"
                        : "";
                    break;
                case CharacterAttributesEnum.Social:
                    text += bonuses.PartySizeMultiplier > 0
                        ? "Increases party size limit by " + bonuses.PartySizeMultiplier.ToString("P") + "\n"
                        : "";
                    text += bonuses.PersuadeAddition > 0
                        ? "Increases persuade chance by " + bonuses.PersuadeAddition.ToString("P") + "\n"
                        : "";
                    text += bonuses.RenownMultiplier > 0
                        ? "Increases renown gain by " + bonuses.RenownMultiplier.ToString("P") + "\n"
                        : "";
                    text += bonuses.InfluenceMultiplier > 0
                        ? "Increases influnce gain by " + bonuses.InfluenceMultiplier.ToString("P") + "\n"
                        : "";
                    text += bonuses.RenownAddition > 0
                        ? "Increases renown by " + bonuses.RenownAddition.ToString("F2") + " when you meet somebody at first\n"
                        : "";
                    break;
                case CharacterAttributesEnum.Intelligence:
                    text += bonuses.XPMultiplier > 0
                        ? "Increases learning rate for all skills by " + bonuses.XPMultiplier.ToString("P") + "\n"
                        : "";
                    text += bonuses.IncomeMultiplier > 0
                        ? "Increases clan income by " + bonuses.IncomeMultiplier.ToString("P") + "\n"
                        : "";
                    text += bonuses.ExpensesMultiplier < 0
                        ? "Decrease clan spendings by " + (-bonuses.ExpensesMultiplier).ToString("P") + "\n"
                        : "";
                    break;
            }
            __instance.IncreaseHelpText = text + __instance.IncreaseHelpText;
        }
    }
}
