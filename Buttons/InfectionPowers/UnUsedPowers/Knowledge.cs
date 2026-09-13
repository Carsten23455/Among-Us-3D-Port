using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Gamemodes.Tag;
using AU3DPort.VanillaPort.Managers;
using AU3DPort.VanillaPort.Options;
using AU3DPort.VanillaPort.Roles.Crewmate;
using AU3DPort.VanillaPort.Roles.Impostor;
using AU3DPort.VanillaPort.Roles.Infection.Crewmate;
using AU3DPort.VanillaPort.Roles.Infection.Impostor;
using MiraAPI.GameModes;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace AU3DPort.VanillaPort.Buttons.InfectionPowers.UnUsedPowers
{
    public class Knowledge : CustomActionButton
    {
        public override string Name => "Knowledge";
        public override float Cooldown => 0f;
        public override LoadableAsset<Sprite> Sprite => AssetManager.Vanish;
        public override bool PauseTimerInVent => true;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.ModifierSecondaryAbility;
        public override int MaxUses => 1;

        protected override void OnClick()
        {
            if (!AmongUsClient.Instance.AmHost) return;

            KnowledgePowerManager.ClearAll();

            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
            {
                if (player.Data.Role is Infected)
                {
                    KnowledgePowerManager.AttachTo(player);
                }
            }
        }
        public override bool Enabled(RoleBehaviour? role)
        {
            var Knowledge = OptionGroupSingleton<InfectionUnusedOrRemovePowers>.Instance;
            SetButtonLocation(ButtonLocation.BottomRight);
            return role is CrewmateTag && Knowledge.KnowledgeEnabled && CustomGameModeManager.ActiveMode is TagGamemode;
        }
    }
}
