using AmongUs.GameOptions;
using AU3DPort.VanillaPort.Assets;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AU3DPort.VanillaPort.Roles.Impostor
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class WraithGhostRole : ImpostorGhostRole, ICustomRole
    {
        public string RoleName => "Wraith";
        public string RoleLongDescription => "Once dead, haunt and kill Crewmates.";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.ImpostorRed;
        public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            UseVanillaKillButton = false,
            CanModifyChance = false,
            HideSettings = true,
            CanUseVent = false,
            Icon = AssetManager.WraithIcon,
        };
    }
}
