using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace AttributesReloaded.Patches.Social
{
    [HarmonyPatch(typeof(ConversationManager))]
    class ConversationManagerPatch
    {
        private static class Helpers
        {
            public static void AddRenown(CharacterObject character)
            {
                if (!character.IsHero || character.HeroObject != character.HeroObject.Clan.Leader) return;
                
                var renown = character.HeroObject.Clan.GetPartyBonus(
                    bonus => bonus.RenownAddition,
                    (value, name) => Logger.Log("Get " + value + " renown for " + name + "'s SOC", character));
                character.HeroObject.Clan.AddRenown(renown);
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch("BeginConversation")]
        public static void BeginConversation(ConversationManager __instance)
        {
            if (!__instance.CurrentConversationIsFirst) return;

            var speaker = CharacterObject.Find(__instance.SpeakerAgent.Character.StringId);
            var listener = CharacterObject.Find(__instance.ListenerAgent.Character.StringId);
            Helpers.AddRenown(speaker);
            Helpers.AddRenown(listener);
        }
    }
}
