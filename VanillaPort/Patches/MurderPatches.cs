using HarmonyLib;
using MiraAPI.Networking;
using MiraAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Managers;

namespace AU3DPort.VanillaPort.Patches
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CheckMurder))]
    public static class RpcMurderPatch
    {
        public static void Postfix(PlayerControl __instance, PlayerControl target)
        {
            if (!target.ProtectedByGa())
            {
                ScanIndicatorManager.Remove(target.PlayerId);
            }
        }
    }
}
