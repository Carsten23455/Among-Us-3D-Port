using AU3DPort.VanillaPort.Assets;
using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Meeting.Voting;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;

namespace AU3DPort.VanillaPort.Roles.Neutral
{
    //TODO: Decide if i should keep or scrap this
    /*
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class Deputy : CrewmateRole, ICustomRole
    {
        public string RoleName => "Deputy";
        public string RoleLongDescription => "You are a Deputy. You can force eject other players during meetings";
        public string RoleDescription => "Complete Tasks to Control Meetings";
        public RoleHintType RoleHint => RoleHintType.TaskHint;
        public Color RoleColor => Palette.PlayerColors[4];
        public ModdedRoleTeams Team => ModdedRoleTeams.Custom;
        public static byte? PendingEjectId = null;
        public static byte? MarkedPlayerId = null;
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            MaxRoleCount = 1,
            UseVanillaKillButton = false,
            TasksCountForProgress = true,
            Icon = AssetManager.DeputyIcon,
        };

        [RegisterEvent(15)]
        public static void OnHandleVote(HandleVoteEvent @event)
        {
            if (@event.VoteData.Owner.Data.Role is not Deputy) return;
            if (!@event.VoteData.Owner.AllTasksCompleted()) return;

            @event.Cancel();

            @event.VoteData.SetRemainingVotes(0);

            for (var i = 0; i < 15; i++)
            {
                @event.VoteData.VoteForPlayer(@event.TargetId);
            }

            foreach (var player in PlayerControl.AllPlayerControls.ToArray())
            {
                if (player == @event.VoteData.Owner) continue;
                player.GetVoteData().Votes.Clear();
                player.GetVoteData().VotesRemaining = 0;
            }
        }
    }
    */
}
