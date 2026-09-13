using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU3DPort.VanillaPort.Options
{
    public class CriticalCargo : AbstractOptionGroup
    {
        public override string GroupName => "Critical Cargo";
        public override uint GroupPriority => 0;

        [ModdedToggleOption("Enabled")]
        public bool Enabled { get; set; }
        //[ModdedNumberOption("Crit Crew Amount", 1, 3, 1)]
        //public float CriticalCrewmateAmount { get; set; }

        [ModdedNumberOption("Scan Fail Chance", 0, 50, 10)]
        public float ScanFailChance { get; set; } = 30f;
    }
}
