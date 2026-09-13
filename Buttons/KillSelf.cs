using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Roles.Impostor;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Networking;
using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace AU3DPort.VanillaPort.Buttons
{
    public class KillSelf : CustomActionButton
    {
        public override string Name => "Unleash Wraith";
        public override float Cooldown => 10f;
        public override float EffectDuration => 0f;
        public override int MaxUses => 0;
        public override LoadableAsset<Sprite> Sprite => AssetManager.UnleashWraithAsset;

        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            return role is Wraith;
        }

        public override BaseKeybind? Keybind => MiraGlobalKeybinds.PrimaryAbility;

        protected override void OnClick()
        {
            PlayerControl.LocalPlayer.RpcCustomMurder(PlayerControl.LocalPlayer, true, true, true, true, false);
        }
    }
}