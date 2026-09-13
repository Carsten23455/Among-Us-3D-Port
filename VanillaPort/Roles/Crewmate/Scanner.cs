using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.GameEnd;
using MiraAPI.GameEnd;
using MiraAPI.GameOptions;
using MiraAPI.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Options;
using AU3DPort.VanillaPort.Options.RoleOptions;
using UnityEngine;

namespace AU3DPort.VanillaPort.Roles.Crewmate
{
    public class Scanner : CrewmateRole, ICustomRole
    {
        public string RoleName => "Scanner";
        public string RoleLongDescription => "Complete tasks and Scan the Impostors";
        public string RoleDescription => "Do Tasks and Scan";
        public Color RoleColor => Palette.PlayerColors[5];
        public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;
        public List<NetworkedPlayerInfo> winnerslist = new System.Collections.Generic.List<NetworkedPlayerInfo>();
        ScannerOption scanner = OptionGroupSingleton<ScannerOption>.Instance;

        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            UseVanillaKillButton = false,
            DefaultChance = 50,
            DefaultRoleCount = 0,
            IntroSound = AssetManager.ScannerRoleReveal,
            HideSettings = !OptionGroupSingleton<CriticalCargo>.Instance.Enabled,
            Icon = AssetManager.CriticalCrewmateIcon,
        };
        public bool CanLocalPlayerSeeRole(PlayerControl player)
        {
            var localPlayer = PlayerControl.LocalPlayer;

            return localPlayer.Data.Role.TeamType == RoleTeamTypes.Impostor && scanner.ImpSeeScan;
        }
    }
}
