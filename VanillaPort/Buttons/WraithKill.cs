using AU3DPort.VanillaPort.Assets;
using AmongUs.GameOptions;
using AU3DPort.VanillaPort.Roles.Impostor;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Networking;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace AU3DPort.VanillaPort.Buttons
{
    public class WraithKill : CustomActionButton<PlayerControl>
    {
        public override string Name => "Kill";
        public override float Cooldown => 25;
        public override LoadableAsset<Sprite> Sprite => AssetManager.WraithKillAsset;
        public override bool PauseTimerInVent => true;

        public override BaseKeybind? Keybind => MiraGlobalKeybinds.SecondaryAbility;

        protected override void OnClick()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                PlayerControl.LocalPlayer.RpcCustomMurder(Target, !Target.ProtectedByGa(), true, true, true, true, true);
            }
        }

        public override PlayerControl? GetTarget()
        {
            return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);
        }

        public override void SetOutline(bool active)
        {
            Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.ImpostorRed));
        }

        public override bool IsTargetValid(PlayerControl? target)
        {
            return true;
        }

        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            return role is WraithGhostRole && PlayerControl.LocalPlayer.Data.IsDead;
        }
    }
}