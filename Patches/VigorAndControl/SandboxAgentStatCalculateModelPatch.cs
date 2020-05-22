using SandBox;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using HarmonyLib;
using System;

namespace AttributesReloaded.Patches.VigorAndControl
{
	[HarmonyPatch(typeof(SandboxAgentStatCalculateModel))]
	class SandboxAgentStatCalculateModelPatch
	{
		[HarmonyPostfix]
		[HarmonyPatch("InitializeAgentStats")]
		public static void InitializeAgentStats(Agent agent, Equipment spawnEquipment, AgentDrivenProperties agentDrivenProperties, AgentBuildData agentBuildData)
		{
            if (!agent.IsHuman) return;

			var characterObject = CharacterObject.Find(agent.Character.StringId);
			var speedMultiplier = new CharacterAttributeBonuses(characterObject).MoveSpeedMultiplier;
            Logger.Log("Bonus " + speedMultiplier.ToString("P") + " Movement Speed from END", characterObject);
            agentDrivenProperties.CombatMaxSpeedMultiplier *= 1 + speedMultiplier;
		}

        [HarmonyPostfix]
		[HarmonyPatch("UpdateAgentStats")]
		public static void UpdateAgentStats(Agent agent, AgentDrivenProperties agentDrivenProperties)
		{
            if (!agent.IsHuman) return;
			
			var characterObject = CharacterObject.Find(agent.Character.StringId);
			var characterBonuses = new CharacterAttributeBonuses(characterObject);
            var weapon = agent.GetWieldedWeaponInfo(Agent.HandIndex.MainHand);
            var isMelee = weapon != null && !weapon.IsRangedWeapon;
            float speedMultiplier = isMelee
				? characterBonuses.MeleeSpeedMultiplier
                : characterBonuses.RangeSpeedMultiplier;
            Logger.Log("Bonus " + speedMultiplier.ToString("P") + " Attack Speed from " + (isMelee ? "VIG" : "CON"), characterObject);
            speedMultiplier++;
            agentDrivenProperties.ThrustOrRangedReadySpeedMultiplier *= speedMultiplier;
			agentDrivenProperties.ReloadSpeed *= speedMultiplier;
			agentDrivenProperties.SwingSpeedMultiplier *= speedMultiplier;
		}
	}
}
