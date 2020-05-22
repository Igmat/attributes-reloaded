using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using HarmonyLib;

namespace AttributesReloaded.Patches.VigorAndControl
{
	[HarmonyPatch(typeof(SandboxAgentApplyDamageModel))]
	class SandboxAgentApplyDamageModelPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("CalculateDamage")]
        public static int CalculateDamage(int __result, ref AttackInformation attackInformation, ref AttackCollisionData collisionData, WeaponComponentData weapon)
		{
			if (!attackInformation.IsVictimAgentNull &&
                !attackInformation.IsAttackerAgentNull &&
                attackInformation.IsAttackerAgentHuman &&
                attackInformation.IsVictimAgentHuman &&
                !collisionData.IsFallDamage &&
                attackInformation.AttackerAgentCharacter is CharacterObject atacker &&
                attackInformation.VictimAgentCharacter is CharacterObject &&
                !collisionData.IsAlternativeAttack)
            {
                var bonuses = new CharacterAttributeBonuses(atacker);
                var isMelee = weapon != null && !weapon.IsRangedWeapon;
                float damageMultiplier = isMelee
                    ? bonuses.MeleeDamageMultiplier
                    : bonuses.RangeDamageMultiplier;
                var bonusDamage = (int)(__result * damageMultiplier);
                Logger.Log("Bonus " + bonusDamage + " damage from " + (isMelee ? "VIG" : "CON"), atacker);
                __result += bonusDamage;
            }
            return __result;
		}
	}
}
