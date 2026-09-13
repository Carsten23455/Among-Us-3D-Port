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
    public class CriticalCrewmateOption : AbstractOptionGroup<CriticalCrewmate>
    {
        public override string GroupName => "Crit Crew Options";
        
        [ModdedNumberOption("Scan Fail Chance", 0, 50, 10)]
        public float ScanFailChance { get; set; } = 30f;
    }
}