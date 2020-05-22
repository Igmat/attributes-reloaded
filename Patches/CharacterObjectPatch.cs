using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AttributesReloaded.Patches
{
    [HarmonyPatch(typeof(CharacterObject))]
    class CharacterObjectPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("GetAttributeValue")]
        public static int GetAttributeValue(int __result, CharacterObject __instance, CharacterAttributesEnum charAttribute)
        {
            var attribute = __result;
            // if following is true, then this attribute is already set by developers/other mods
            if (attribute >= 2) return attribute;
            // we use maximum skill level to determine how big attribute should be
            var maxSkill = CharacterAttributes.GetCharacterAttribute(charAttribute).Skills.Select(skill => __instance.GetSkillValue(skill)).Max();
            // 0 - is minimal for any skill and we consider this amount as 2 for repsective attribute
            // 240 is a soft cap for skill leveling in Mount & Blade, so we consider this amount as 10 for  repsective attribute
            // between them we assume linear growth of attributes
            attribute = 2 + maxSkill / (240 / (10 - 2));

            return (attribute < 10)
                ? attribute
                : 10;
        }
    }
}
