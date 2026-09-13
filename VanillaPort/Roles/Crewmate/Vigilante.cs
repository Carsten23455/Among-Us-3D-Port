using AU3DPort.VanillaPort.Buttons;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static AU3DPort.VanillaPort.Assets.AssetManager;

namespace AU3DPort.VanillaPort.Roles.Crewmate
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class Vigilante : CrewmateRole, ICustomRole
    {
        public string RoleName => "Vigilante";
        public string RoleLongDescription => "Do your Tasks and Kill";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.PlayerColors[10];
        public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            MaxRoleCount = 3,
            Icon = VigiIcon,
            IntroSound = VigiIntro,
        };
        public override void OnRoleSet()
        {

        }
        public bool CanLocalPlayerSeeRole(PlayerControl player) => false;
    }
}
