using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Roles.Crewmate;

namespace AU3DPort.VanillaPort.Options.RoleOptions
{
    public class ScannerOption : AbstractOptionGroup<Scanner>
    {
        public override string GroupName => "Scanner Options";

        [ModdedNumberOption("Scan Cooldown", 10, 60, 5, MiraAPI.Utilities.MiraNumberSuffixes.Seconds)]
        public float ScanCoolDown { get; set; } = 45f;
        [ModdedNumberOption("Max Uses", 1, 3, 1)]
        public float MaxUses { get; set; } = 1f;
        [ModdedToggleOption("Impostors Can See Scanner")]
        public bool ImpSeeScan { get; set; }
    }
}
