using AU3DPort.VanillaPort.Assets;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Modifiers;
using MiraAPI.Networking;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Options.RoleOptions;
using AU3DPort.VanillaPort.Roles.Crewmate;
using UnityEngine;

namespace AU3DPort.VanillaPort.Buttons
{
    public class VigiKill : CustomActionButton<PlayerControl>
    {
        public override string Name => "Kill";
        public override float Cooldown => vigisettings.KillCoolDown;
        public override float EffectDuration => 0f;
        public override int MaxUses => vigisettings.InfiniteKills ? 0 : 1;
        public override LoadableAsset<Sprite> Sprite => AssetManager.VigiKillIcon;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.PrimaryAbility;
        VigilanteSettings vigisettings = OptionGroupSingleton<VigilanteSettings>.Instance;
        protected override void OnClick()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                PlayerControl.LocalPlayer.RpcCustomMurder(Target, !Target.ProtectedByGa(), true, true, true, true, true);
            }
        }
        public override PlayerControl? GetTarget()
            => PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);
        public override void SetOutline(bool active)
            => Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.PlayerColors[10]));
        public override bool IsTargetValid(PlayerControl? target)
        {
            if (target == null) return false;
            if (target.PlayerId == PlayerControl.LocalPlayer.PlayerId) return false;
            if (target.Data.IsDead) return false;
            return true;
        }
        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            return role is Vigilante;
        }
    }
}
