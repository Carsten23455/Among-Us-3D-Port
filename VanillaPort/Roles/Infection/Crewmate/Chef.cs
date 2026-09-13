using AU3DPort.VanillaPort.Gamemodes.Tag;
using AU3DPort.VanillaPort.Modifiers;
using MiraAPI.GameModes;
using MiraAPI.GameOptions;
using MiraAPI.Modifiers;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;

namespace AU3DPort.VanillaPort.Roles.Infection.Crewmate
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class Chef : CrewmateRole, ICustomRole
    {
        Options.Infection infection = OptionGroupSingleton<Options.Infection>.Instance;
        public string RoleName => "Crewmate";
        public string RoleLongDescription => "Complete tasks and Survive the Infected";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.PlayerColors[20];
        public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;
        private int _originalColor;
        private string _originalHat;
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            AffectedByLightOnAirship = false,
            MaxRoleCount = 0,
            CanModifyChance = false,
            HideSettings = true,
            ShowInFreeplay = false
        };
        
        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is TagGamemode;

        public override void OnRoleSet()
        {

        }
        public override void Initialize(PlayerControl player)
        {
          
        }

        public override void Deinitialize(PlayerControl targetPlayer)
        {

        }

        public bool CanLocalPlayerSeeRole(PlayerControl player) => true;
    }
}
