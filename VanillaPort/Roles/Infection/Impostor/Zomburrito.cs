using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Gamemodes.Tag;
using AU3DPort.VanillaPort.Modifiers;
using AU3DPort.VanillaPort.Modifiers.OGInfection;
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
    public class Zomburrito : ImpostorRole, ICustomRole
    {
        Options.Infection infection = OptionGroupSingleton<Options.Infection>.Instance;
        public string RoleName => "Zomburrito";
        public string RoleLongDescription => "Spread the infection to win";
        public string RoleDescription => "Spread the infection to win";
        public Color RoleColor => Palette.PlayerColors[11];
        public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;
        public bool CanLocalPlayerSeeRole(PlayerControl player) => true;
        public static bool Enabled = false;
        public int _originalColor;
        public string _originalHat = "";
        public override void OnRoleSet()
        {

        }

        public override void Initialize(PlayerControl player)
        {
            
        }
        
        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is TagGamemode;

        public override void Deinitialize(PlayerControl targetPlayer)
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
            CanModifyChance = false,
            HideSettings = true,
            ShowInFreeplay = false
        };
    }
}