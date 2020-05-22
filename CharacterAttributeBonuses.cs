using System;
using System.Runtime.Remoting;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace AttributesReloaded
{
    public class CharacterAttributeBonuses
    {
        public CharacterAttributeBonuses(CharacterObject character)
        {
            this.character = character;
        }

        // unlike others, this multiplier should use cleanBonus, because usual bonus function uses this multiplier itself
        public float AttributeEffectMultiplier => 1 + clenBonus(config.attribute_effects, cunning);
        public float MeleeDamageMultiplier => bonus(config.melee_bonus_dmg, vigor);
        public float MeleeSpeedMultiplier => bonus(config.melee_bonus_speed, vigor);
        public float PositiveMoraleMultiplier => bonus(config.bonus_positive_morale, vigor);
        public float RangeDamageMultiplier => bonus(config.rng_bonus_dmg, control);
        public float RangeSpeedMultiplier => bonus(config.rng_bonus_speed, control);
        public float NegativeMoraleMultiplier => -Math.Min(bonus(config.bonus_negative_morale, control), config.max_bonus_negative_morale);
        public float HPMultiplier => bonus(config.bonus_hp, endurance);
        public float MoveSpeedMultiplier => bonus(config.bonus_movespeed, endurance);
        public float PartySizeMultiplier => bonus(config.bonus_partysize, social);
        public float PersuadeAddition => bonus(config.bonus_persuade, social);
        public float RenownMultiplier => bonus(config.bonus_renown, social);
        public float InfluenceMultiplier => bonus(config.bonus_influence, social);
        public float XPMultiplier => bonus(config.bonus_xp, intelligence);
        public float IncomeMultiplier => bonus(config.bonus_income, intelligence);
        public float ExpensesMultiplier => -Math.Min(bonus(config.bonus_decreas, intelligence), config.max_bonus_decreas);

        private Config config => Config.Instance;
        private CharacterObject character;
        private bool isEnabled =>
            character.IsPlayerCharacter ||
            (!character.IsHero
                ? !config.disable_troops
                : character.HeroObject.IsPlayerCompanion
                    ? !config.disable_companions
                    : !config.disable_lords);

        private int vigor => character.GetAttributeValue(CharacterAttributesEnum.Vigor);
        private int control => character.GetAttributeValue(CharacterAttributesEnum.Control);
        private int endurance => character.GetAttributeValue(CharacterAttributesEnum.Endurance);
        private int cunning => character.GetAttributeValue(CharacterAttributesEnum.Cunning);
        private int social => character.GetAttributeValue(CharacterAttributesEnum.Social);
        private int intelligence => character.GetAttributeValue(CharacterAttributesEnum.Intelligence);

        // for better precision we use integers, where 1 represnts 1/8 actually
        // so later on we must to divide result by 8 to get actual floats
        private int curveNegativeMultiplier(int attr) =>
            attr == 1
                ? -config.small_penalty * 8
                : -config.big_penalty * 8;
        // so this function actually represents next formula: y = (1/8)x^2 + (1/4)x
        // which gives us Y range from 0 to 10 for X range from 0 to 8
        private int curvePositiveMultiplier(int attr) => attr * attr + attr * 2;
        private int curveMultiplier(int attr) =>
            attr < 2
                ? curveNegativeMultiplier(attr)
                : curvePositiveMultiplier(attr - 2);
        // here we moving from using integers as 1/8 to actual float numbers
        private float curveBonus(float effect, int attr) => effect * curveMultiplier(attr) / 8;
        private float linearBonus(float effect, int attr) => effect * attr;
        private float clenBonus(float effect, int attr) =>
            isEnabled
                ? config.nonlinear_progress
                    ? curveBonus(effect, attr)
                    : linearBonus(effect, attr)
                : 0;
        private float bonus(float effect, int attr) => clenBonus(effect, attr) * AttributeEffectMultiplier;
    }
}
