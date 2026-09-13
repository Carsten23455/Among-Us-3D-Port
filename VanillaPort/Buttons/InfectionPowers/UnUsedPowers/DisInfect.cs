using AU3DPort.VanillaPort.Assets;
using AmongUs.GameOptions;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Modifiers;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Gamemodes.Tag;
using AU3DPort.VanillaPort.Modifiers;
using AU3DPort.VanillaPort.Options;
using AU3DPort.VanillaPort.Roles.Crewmate;
using AU3DPort.VanillaPort.Roles.Impostor;
using AU3DPort.VanillaPort.Roles.Infection.Crewmate;
using AU3DPort.VanillaPort.Roles.Infection.Impostor;
using MiraAPI.GameModes;
using UnityEngine;

namespace AU3DPort.VanillaPort.Buttons.InfectionPowers.UnUsedPowers
{
    public class DisInfect : CustomActionButton<PlayerControl>
    {
        Infection infection = OptionGroupSingleton<Infection>.Instance;
        public override string Name => "DisInfect";
        public override float Cooldown => 0;
        public override LoadableAsset<Sprite> Sprite => AssetManager.DisInfect;
        public override bool PauseTimerInVent => true;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.SecondaryAbility;
        public override int MaxUses => 1;

        protected override void OnClick()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                if (Target.Data.Role is Infected && UnityEngine.Object.FindObjectsOfType<Infected>().Count > 1)
                {
                    var roleID = RoleId.Get<Chef>();
                    var roleType = (RoleTypes)roleID;
                    Target.RpcSetRole(roleType);
                    Target.RpcRemoveModifier<InfectedModifier>();
                    Target.RpcAddModifier<ChefModifier>();
                }
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
            if (target.Data.Role is not Infected) return false;
            if (target.Data.IsDead) return false;
            return true;
        }

        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            var DisInfect = OptionGroupSingleton<InfectionUnusedOrRemovePowers>.Instance;
            return role is CrewmateTag && DisInfect.DisinfectEnabled && CustomGameModeManager.ActiveMode is TagGamemode;
        }
    }
}
