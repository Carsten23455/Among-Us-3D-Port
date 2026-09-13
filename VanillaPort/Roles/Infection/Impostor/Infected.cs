using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Gamemodes.Tag;
using AU3DPort.VanillaPort.Modifiers;
using MiraAPI.GameModes;
using MiraAPI.GameOptions;
using MiraAPI.Modifiers;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;

namespace AU3DPort.VanillaPort.Roles.Infection.Impostor
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class Infected : ImpostorRole, ICustomRole
    {
        public string RoleName => "Infected";
        public string RoleLongDescription => "You are an Infected Spread the infection to win";
        public string RoleDescription => "Spread the infection to win";
        public Color RoleColor => Palette.PlayerColors[CustomColors.CustomColors.CheckWatermelon()];
        public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;
        public bool CanLocalPlayerSeeRole(PlayerControl player) => true;
        
        public override void OnRoleSet()
        {
            
        }
        
        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is TagGamemode;

        public override void Initialize(PlayerControl player)
        {
            
        }

        public override PlayerControl? FindClosestTarget()
        {
            return null;
        }

        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            UseVanillaKillButton = false,
            CanUseVent = false,
            CanUseSabotage = false,
            KillButtonOutlineColor = Palette.PlayerColors[11],
            MaxRoleCount = 0,
            IntroSound = AssetManager.InfectedRoleReveal,
            DefaultChance = 0,
            CanModifyChance = true,
            HideSettings = true,
            DefaultRoleCount = 0,
            ShowInFreeplay = false
        };
    }
}