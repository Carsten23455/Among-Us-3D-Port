using AmongUs.GameOptions;
using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Modifiers;
using AU3DPort.VanillaPort.Modifiers.OGInfection;
using AU3DPort.VanillaPort.Options;
using AU3DPort.VanillaPort.Roles.Crewmate;
using AU3DPort.VanillaPort.Roles.Impostor;
using AU3DPort.VanillaPort.Roles.Infection.Crewmate;
using AU3DPort.VanillaPort.Roles.Infection.Impostor;
using BepInEx.Logging;
using InnerNet;
using MiraAPI.GameModes;
using MiraAPI.GameOptions;
using MiraAPI.Modifiers;
using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using Reactor.Utilities;
using Sentry.Unity;
using UnityEngine;

namespace AU3DPort.VanillaPort.Gamemodes.Tag;

public class TagGamemode : AbstractGameMode
{
    public override string Name => "Tag";
    public override string Description => "A port of the Tag Gamemode from Among Us 3D";
    public override LoadableAsset<Sprite>? Icon => AssetManager.InfectIcon;
    public override Color Color => Color.green;
    public static bool shouldEndGame = false;

    public override bool CanReport(DeadBody body) => false;

    public override bool CanVent(Vent vent, NetworkedPlayerInfo playerInfo)
    {
        return playerInfo.Role is not Infected;
    }

    public override PlayerBodyTypes GetBodyType(PlayerControl player)
    {
        return player.Data.Role is Infected ? PlayerBodyTypes.Seeker : base.GetBodyType(player);
    }

    public override float DefaultImpostorKillCooldown => 1f;
    
    public override bool GameModeBodyTypeOverride => true;
    public override bool ShowNormalGameSettings => false;
    public override bool ShowNormalRoleSettings => false;
    public override bool ShouldShowSabotageMap(MapBehaviour map) => false;
    public override bool ShowGameModeIntroCutscene => false;
    
    
    public override void AssignRoles(out bool runOriginal, LogicRoleSelectionNormal instance)
    {
        var settings = OptionGroupSingleton<Infection>.Instance;

        if (!settings.LTEEnabled)
        {
            runOriginal = false;

            var infectionOptions = OptionGroupSingleton<Infection>.Instance;
            int infectedCount = (int)infectionOptions.InfectedAmount;

            Il2CppSystem.Collections.Generic.List<ClientData> clients = new();
            AmongUsClient.Instance.GetAllClients(clients);

            Il2CppSystem.Collections.Generic.List<NetworkedPlayerInfo> players = new();
            foreach (var c in clients.ToArray())
            {
                if (c.Character != null && c.Character.Data != null &&
                    !c.Character.Data.Disconnected && !c.Character.Data.IsDead)
                {
                    players.Add(c.Character.Data);
                }
            }

            IGameOptions currentGameOptions = GameOptionsManager.Instance.CurrentGameOptions;
            infectedCount = Math.Clamp(infectedCount, 1, players.Count);

            var infectedType = (RoleTypes)RoleId.Get<Infected>();
            var crewType = (RoleTypes)RoleId.Get<CrewmateTag>();

            instance.AssignRolesForTeam(players, currentGameOptions, RoleTeamTypes.Impostor,
                infectedCount, new Il2CppSystem.Nullable<RoleTypes>(infectedType));
            instance.AssignRolesForTeam(players, currentGameOptions, RoleTeamTypes.Crewmate,
                int.MaxValue, new Il2CppSystem.Nullable<RoleTypes>(crewType));

            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (player.Data == null || player.Data.Disconnected) continue;

                if (player.Data.Role is Infected)
                {
                    player.AddModifier<InfectedModifier>();
                }
            }
        }
        else
        {
            runOriginal = false;

            var infectionOptions = OptionGroupSingleton<Infection>.Instance;
            int infectedCount = (int)infectionOptions.InfectedAmount;

            Il2CppSystem.Collections.Generic.List<ClientData> clients = new();
            AmongUsClient.Instance.GetAllClients(clients);

            Il2CppSystem.Collections.Generic.List<NetworkedPlayerInfo> players = new();
            foreach (var c in clients.ToArray())
            {
                if (c.Character != null && c.Character.Data != null &&
                    !c.Character.Data.Disconnected && !c.Character.Data.IsDead)
                {
                    players.Add(c.Character.Data);
                }
            }

            IGameOptions currentGameOptions = GameOptionsManager.Instance.CurrentGameOptions;
            infectedCount = Math.Clamp(infectedCount, 1, players.Count);

            var infectedType = (RoleTypes)RoleId.Get<Zomburrito>();
            var crewType = (RoleTypes)RoleId.Get<Chef>();

            instance.AssignRolesForTeam(players, currentGameOptions, RoleTeamTypes.Impostor,
                infectedCount, new Il2CppSystem.Nullable<RoleTypes>(infectedType));
            instance.AssignRolesForTeam(players, currentGameOptions, RoleTeamTypes.Crewmate,
                int.MaxValue, new Il2CppSystem.Nullable<RoleTypes>(crewType));

            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (player.Data == null || player.Data.Disconnected) continue;

                if (player.Data.Role is Zomburrito)
                {
                    player.AddModifier<ZomburritoModifier>();
                }
                else
                {
                    player.AddModifier<ChefModifier>();
                }
            }
        }
    }

    public override void CheckGameEnd(out bool runOriginal, LogicGameFlowNormal instance)
    {
        bool allInfected = true;
        bool allTasksComplete = true;

        foreach (var player in PlayerControl.AllPlayerControls)
        {
            if (player.Data.Disconnected) continue;

            if (player.Data.Role is not Infected)
            {
                allInfected = false;
                break;
            }
        }

        foreach (var player in PlayerControl.AllPlayerControls)
        {
            if (player.Data.Disconnected) continue;
            if (player.Data.Role is not Infected && !player.AllTasksCompleted())
            {
                allTasksComplete = false;
                break;
            }
        }

        if (allInfected || allTasksComplete)
        {
            runOriginal = true;
        }
        else
        {
            runOriginal = false;
        }
    }
}