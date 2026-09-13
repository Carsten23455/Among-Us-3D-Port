using AU3DPort.VanillaPort.Roles.Impostor;
using AmongUs.GameOptions;
using MiraAPI.GameEnd;
using MiraAPI.Networking;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Events;
using UnityEngine;

namespace AU3DPort.VanillaPort.Roles.Neutral
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class Jester : CrewmateRole, ICustomRole
    {
        public string RoleName => "Jester";
        public string RoleLongDescription => "Get ejected to win, your tasks are fake";
        public string RoleDescription => "Get Ejected to win";
        public Color RoleColor => Palette.PlayerColors[8];
        public ModdedRoleTeams Team => ModdedRoleTeams.Custom;
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            MaxRoleCount = 1,
            UseVanillaKillButton = false,
            TasksCountForProgress = false,
        };

        public override void OnDeath(DeathReason reason)
        {
            if (reason == DeathReason.Exile)
            {
                CustomGameOver.Trigger<JesterWin>([Player.Data]);
            }
        }
    }
}
