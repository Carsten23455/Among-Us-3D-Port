using AU3DPort.VanillaPort.Roles;
using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Gamemodes.Tag;

namespace AU3DPort.VanillaPort.Options
{
    public class Infection : AbstractOptionGroup<TagGamemode>
    {
        public override string GroupName => "Infection";
        public override uint GroupPriority => 0;

        [ModdedNumberOption("Starting Infected Amount", 1, 3, 1)]
        public float InfectedAmount { get; set; } = 1;

        [ModdedNumberOption("Infected KillCoolDown", 5, 15, 5, MiraAPI.Utilities.MiraNumberSuffixes.Seconds)]
        public float InfectedKCD { get; set; } = 10f;

        [ModdedToggleOption("LTE Infection")] 
        public bool LTEEnabled { get; set; } = false;
    }
    public class InfectionUnusedOrRemovePowers : AbstractOptionGroup<TagGamemode>
    {
        public override string GroupName => "Unused/Removed Powers";
        public override uint GroupPriority => 0;
        [ModdedToggleOption("Guard Retexture")]
        public bool PinkGuard { get; set; }
        [ModdedToggleOption("Disinfect PowerUp")]
        public bool DisinfectEnabled { get; set; }
        [ModdedToggleOption("Knowledge PowerUp")]
        public bool KnowledgeEnabled { get; set; }
        [ModdedToggleOption("Sabotage PowerUp")]
        public bool SabotageEnabled { get; set; }
    }
}
