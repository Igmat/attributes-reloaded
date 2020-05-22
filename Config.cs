using MBOptionScreen.Settings;
using MBOptionScreen.Attributes;
using MBOptionScreen.Attributes.v2;

namespace AttributesReloaded
{
    public class Config : AttributeSettings<Config>
    {
        public override string Id { get; set; } = "Igmat.AttributesReloaded_v1";
        public override string ModName => "Attributes Reloaded";
        public override string ModuleFolderName => "AttributesReloaded";

        [SettingPropertyGroup("Vigor", order: 0)]
        [SettingPropertyFloatingInteger("Bonus Melee Damage", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 0, HintText = "How much more damage you deal in melee for each Vigor point", RequireRestart = false)]
        public float melee_bonus_dmg { get; set; } = 0.025f;

        [SettingPropertyGroup("Vigor", order: 0)]
        [SettingPropertyFloatingInteger("Bonus Melee Speed", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 1, HintText = "How much faster you are in melee for each Vigor point", RequireRestart = false)]
        public float melee_bonus_speed { get; set; } = 0;

        [SettingPropertyGroup("Vigor", order: 0)]
        [SettingPropertyFloatingInteger("Increase Positive Morale", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 2, HintText = "How much more morale you get on positive events for each Vigor point", RequireRestart = false)]
        public float bonus_positive_morale { get; set; } = 0.05f;

        [SettingPropertyGroup("Control", order: 1)]
        [SettingPropertyFloatingInteger("Bonus Range Damage", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 0, HintText = "How much more damage you deal in range for each Control point", RequireRestart = false)]
        public float rng_bonus_dmg { get; set; } = 0;
        
        [SettingPropertyGroup("Control", order: 1)]
        [SettingPropertyFloatingInteger("Bonus Range Speed", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 1, HintText = "How much faster you are in range for each Control point", RequireRestart = false)]
        public float rng_bonus_speed { get; set; } = 0.025f;

        [SettingPropertyGroup("Control", order: 1)]
        [SettingPropertyFloatingInteger("Decrease Negative Morale", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 2, HintText = "How much less morale you loose on negative events for each Control point", RequireRestart = false)]
        public float bonus_negative_morale { get; set; } = 0.05f;

        [SettingPropertyGroup("Control", order: 1)]
        [SettingPropertyFloatingInteger("Decrease Negative Morale Maximum", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 3, HintText = "It's a maximum value for decreasing negative morale", RequireRestart = false)]
        public float max_bonus_negative_morale { get; set; } = 0.75f;

        [SettingPropertyGroup("Endurance", order: 2)]
        [SettingPropertyFloatingInteger("Bonus HP", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 0, HintText = "How much more HP you get for each Endurance point", RequireRestart = false)]
        public float bonus_hp { get; set; } = 0.025f;
        
        [SettingPropertyGroup("Endurance", order: 2)]
        [SettingPropertyFloatingInteger("Bonus Move Speed", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 1, HintText = "How much faster you move for each Endurance point", RequireRestart = false)]
        public float bonus_movespeed { get; set; } = 0.01f;
        
        [SettingPropertyGroup("Cunning", order: 3)]
        [SettingPropertyFloatingInteger("Bonus Attribute Effects", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 0, HintText = "How much better your attributes work for each Cunning point", RequireRestart = false)]
        public float attribute_effects { get; set; } = 0.05f;
        
        [SettingPropertyGroup("Social", order: 4)]
        [SettingPropertyFloatingInteger("Bonus Persuation", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 0, HintText = "How much higher your change to persuade for each Social point", RequireRestart = false)]
        public float bonus_persuade { get; set; } = 0.01f;
        
        [SettingPropertyGroup("Social", order: 4)]
        [SettingPropertyFloatingInteger("Bonus Party Size *", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 1, HintText = "How much bigger your party size limit for each Social point", RequireRestart = false)]
        public float bonus_partysize { get; set; } = 0.025f;

        [SettingPropertyGroup("Social", order: 4)]
        [SettingPropertyInteger("Bonus Renown on meet (doesn't work yet) *", minValue: 0, maxValue: 10, Order = 2, HintText = "How many renown points you get upon meeting new character for each Social point", RequireRestart = false)]
        public int bonus_meet_renown { get; set; } = 1;

        [SettingPropertyGroup("Social", order: 4)]
        [SettingPropertyFloatingInteger("Bonus Renown *", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 3, HintText = "How much more renown you get for each Social point", RequireRestart = false)]
        public float bonus_renown { get; set; } = 0.025f;

        [SettingPropertyGroup("Social", order: 4)]
        [SettingPropertyFloatingInteger("Bonus Influence *", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 4, HintText = "How much more influence you get for each Social point", RequireRestart = false)]
        public float bonus_influence { get; set; } = 0.025f;

        [SettingPropertyGroup("Intelligence", order: 5)]
        [SettingPropertyFloatingInteger("Bonus XP", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 0, HintText = "How much more XP you get for each Intelligence point", RequireRestart = false)]
        public float bonus_xp { get; set; } = 0.05f;
        
        [SettingPropertyGroup("Intelligence", order: 5)]
        [SettingPropertyFloatingInteger("Increase Income *", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", Order = 1, HintText = "How much more gold you get for each Intelligence point", RequireRestart = false)]
        public float bonus_income { get; set; } = 0.01f;

        [SettingPropertyGroup("Intelligence", order: 5)]
        [SettingPropertyFloatingInteger("Decrease Expenses *", minValue: 0f, maxValue: 0.1f, valueFormat: "#0.0%", Order = 2, HintText = "How much less gold you spent for each Intelligence point", RequireRestart = false)]
        public float bonus_decreas { get; set; } = 0.01f;
        
        [SettingPropertyGroup("Intelligence", order: 5)]
        [SettingPropertyFloatingInteger("Decrease Expenses Maximum", minValue: 0f, maxValue: 0.1f, valueFormat: "#0.0%", Order = 3, HintText = "It's a maximum value for decreasing Expenses", RequireRestart = false)]
        public float max_bonus_decreas { get; set; } = 0.75f;

        [SettingPropertyGroup("Progress model", order: 6)]
        [SettingPropertyBool("Nonlinear progress", Order = 0, HintText = "Enable this option to get bonuses for attributes point (AP) in nonlinear way. 3AP: 0.375, 4AP: 1, 5AP: 1.875, 6AP: 3, 7AP: 4.375, 8AP: 6, 9AP: 7.875, 10AP: 10(equal to max bonus in linear model)", RequireRestart = false)]
        public bool nonlinear_progress { get; set; } = true;

        [SettingPropertyGroup("Progress model", order: 6)]
        [SettingPropertyInteger("Small Penalty", minValue: 0, maxValue: 10, Order = 1, HintText = "How many times related bonus will be applied as a penalty when your attribute equals to 1", RequireRestart = false)]
        public int small_penalty { get; set; } = 2;

        [SettingPropertyGroup("Progress model", order: 6)]
        [SettingPropertyInteger("Small Penalty", minValue: 0, maxValue: 10, Order = 2, HintText = "How many times related bonus will be applied as a penalty when your attribute equals to 0", RequireRestart = false)]
        public int big_penalty { get; set; } = 4;

        [SettingPropertyGroup("Additional", order: 7)]
        [SettingPropertyBool("Include bonuses from Companions", Order = 0, HintText = "Enable this to include attribute points from your Companions to calculate related bonuses marked with *", RequireRestart = false)]
        public bool applye_bonuses_from_companions { get; set; } = true;

        [SettingPropertyGroup("Additional", order: 7)]
        [SettingPropertyBool("Disable effect on troops", Order = 1, HintText = "Enable this option to get troops work like in vanilla (they'll be weaker than you)", RequireRestart = false)]
        public bool disable_troops { get; set; } = false;

        [SettingPropertyGroup("Additional", order: 7)]
        [SettingPropertyBool("Disable effect on lords", Order = 2, HintText = "Enable this option to get lords work like in vanilla (they'll be weaker than you)", RequireRestart = false)]
        public bool disable_lords { get; set; } = false;

        [SettingPropertyGroup("Additional", order: 7)]
        [SettingPropertyBool("Disable effect on companions", Order = 3, HintText = "Enable this option to get companions work like in vanilla (they'll be weaker than you)", RequireRestart = false)]
        public bool disable_companions { get; set; } = false;

        [SettingPropertyGroup("Additional", order: 7)]
        [SettingPropertyBool("Show info messages", Order = 4, HintText = "Enable this to see how much bonuses you get from attributes", RequireRestart = false)]
        public bool enable_messages { get; set; } = false;
    }
}
