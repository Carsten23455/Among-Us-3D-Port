using MiraAPI.GameOptions;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Options.RoleOptions;
using UnityEngine;

namespace AU3DPort.VanillaPort.Roles.Crewmate
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class DoubleAgent : CrewmateRole, ICustomRole
    {
        public string RoleName => "Double Agent";
        public string RoleLongDescription => "Blend in to catch the Impostors";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.ImpostorRed;
        public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;
        DoubleAgentSettings doubleAgent = OptionGroupSingleton<DoubleAgentSettings>.Instance;
        public bool CanLocalPlayerSeeRole(PlayerControl player)
        {
            var localPlayer = PlayerControl.LocalPlayer;

            if (localPlayer.Data.Role.TeamType == RoleTeamTypes.Impostor) return true;

            return false;
        }
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            MaxRoleCount = 1,
            CanUseVent = doubleAgent.CanVent,
        };
    }
}
