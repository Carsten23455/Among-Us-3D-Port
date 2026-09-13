using AmongUs.GameOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU3DPort.VanillaPort.Managers
{
    public class DebugManager
    {
        public static void SetRole(PlayerControl player, RoleTypes role, bool canoverride)
        {
            player.RpcSetRole(role, canoverride);
        }
    }
}
