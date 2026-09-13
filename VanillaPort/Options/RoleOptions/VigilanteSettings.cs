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
    public class VigilanteSettings : AbstractOptionGroup<Vigilante>
    {
        public override string GroupName => "Vigilante Options";

        [ModdedNumberOption("Vigi Kill CoolDown", 10, 60, 5, MiraAPI.Utilities.MiraNumberSuffixes.Seconds)]
        public float KillCoolDown { get; set; } = 45f;
        [ModdedToggleOption("Infinite Kills")]
        public bool InfiniteKills { get; set; }
    }
}
