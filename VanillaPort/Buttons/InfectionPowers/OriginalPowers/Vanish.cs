using AU3DPort.VanillaPort.Modifiers;
using AU3DPort.VanillaPort.Assets;
using AmongUs.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Modifiers;
using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Roles.Crewmate;
using AU3DPort.VanillaPort.Roles.Infection.Crewmate;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace AU3DPort.VanillaPort.Buttons.InfectionPowers.OriginalPowers
{
    public class Vanish : CustomActionButton
    {
        public override string Name => "Vanish";
        public override float Cooldown => 0f;
        public override float EffectDuration => 10;
        public override LoadableAsset<Sprite> Sprite => AssetManager.Vanish;
        public override bool PauseTimerInVent => true;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.ModifierPrimaryAbility;
        public override int MaxUses => 1;

        protected override void OnClick()
        {
            if (AmongUsClient.Instance.AmHost)
            {

            }
            var player = PlayerControl.LocalPlayer;
            player.SetInvisibility(true);
        }
        public override void OnEffectEnd()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                var player = PlayerControl.LocalPlayer;
                var roleID = RoleId.Get<Chef>();
                var roleType = (RoleTypes)roleID;
                PlayerControl.LocalPlayer.SetInvisibility(false);
                PlayerControl.LocalPlayer.RpcSetRole(roleType);
            }
        }
        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            UsesLeft = 0;
            return false;
            //bool hasChefRole = ((role is Chef));
            //bool hasChefModifier = PlayerControl.LocalPlayer.HasModifier<ChefModifier>();

            //return hasChefRole && role is not ChefEngineer  || hasChefModifier && role is not ChefEngineer;
        }
    }
}
