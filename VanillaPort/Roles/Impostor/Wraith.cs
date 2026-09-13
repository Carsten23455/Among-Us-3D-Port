using AU3DPort.VanillaPort.Assets;
using AmongUs.GameOptions;
using AU3DPort.VanillaPort.Gamemodes.Tag;
using MiraAPI;
using MiraAPI.GameModes;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;

namespace AU3DPort.VanillaPort.Roles.Impostor
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class Wraith : ImpostorRole, ICustomRole
    {
        public string RoleName => "Wraith";
        public string RoleLongDescription => "Once dead, haunt and kill Crewmates.";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.ImpostorRed;
        public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;
        public RoleHintType RoleHint => RoleHintType.TaskHint;
        public RoleTypes GetRole()
        {
            var roleID = RoleId.Get<WraithGhostRole>();
            return (RoleTypes)roleID;
        }

        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is not TagGamemode or HideAndSeekMode;

        public override void OnDeath(DeathReason reason)
        {

        }

        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            MaxRoleCount = 1,
            UseVanillaKillButton = false,
            CanModifyChance = true,
            DefaultChance = 50,
            IntroSound = AssetManager.WraithRoleReveal,
            GhostRole = GetRole(),
            Icon = AssetManager.WraithIcon,
        };
    }
}
