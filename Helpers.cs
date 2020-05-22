using MBOptionScreen.ExtensionMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TaleWorlds.CampaignSystem;

namespace AttributesReloaded
{
    public delegate float GetBonusDelegate(CharacterAttributeBonuses bonuses);
    public delegate void LogBonusDelegate(float bonus, string name);
    public static class Helpers
    {
        private static float GetPartyBonus(this IEnumerable<CharacterObject> party, GetBonusDelegate getBonusDelegate, LogBonusDelegate logBonusDelegate) =>
            1 + party
                .Where(troop => troop != null && troop.IsHero)
                .Distinct()
                .Select(troop => new
                {
                    bonus = getBonusDelegate(new CharacterAttributeBonuses(troop)),
                    name = troop.Name.ToString()
                })
                .Do(troop => logBonusDelegate?.Invoke(troop.bonus, troop.name))
                .Sum(troop => troop.bonus);

        public static float GetPartyBonus(this IEnumerable<CharacterObject> party, CharacterObject leader, GetBonusDelegate getBonusDelegate, LogBonusDelegate logBonusDelegate) =>
            (Config.Instance.applye_bonuses_from_companions
                ? new CharacterObject[] { leader }.Concat(party)
                : new CharacterObject[] { leader })
            .GetPartyBonus(getBonusDelegate, logBonusDelegate);

        public static float GetPartyBonus(this PartyBase party, GetBonusDelegate getBonusDelegate, LogBonusDelegate logBonusDelegate) =>
            party.MemberRoster.Troops
                .GetPartyBonus(party.Leader, getBonusDelegate, logBonusDelegate);

        public static float GetPartyBonus(this MobileParty party, GetBonusDelegate getBonusDelegate, LogBonusDelegate logBonusDelegate) =>
            party.Party
                .GetPartyBonus(getBonusDelegate, logBonusDelegate);
        public static float GetPartyBonus(this Clan party, GetBonusDelegate getBonusDelegate, LogBonusDelegate logBonusDelegate) =>
            party.Companions
                .Select(companion => companion.CharacterObject)
                .GetPartyBonus(party.Leader.CharacterObject, getBonusDelegate, logBonusDelegate);
    }
}
