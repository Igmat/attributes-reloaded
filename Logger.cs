using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AttributesReloaded
{
    static class Logger
    {
        public static void Log(string message, CharacterObject characterObject = null)
        {
            if (characterObject != null && characterObject.IsPlayerCharacter && Config.Instance.enable_messages)
            {
                InformationManager.DisplayMessage(new InformationMessage(message, Colors.Red));
            }
        }
    }
}
