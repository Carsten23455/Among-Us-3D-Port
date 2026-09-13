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
    public class DoubleAgentSettings : AbstractOptionGroup<DoubleAgent>
    {
        public override string GroupName => "Double Agent Options";
        [ModdedToggleOption("Can Vent")]
        public bool CanVent { get; set; }
    }
}
