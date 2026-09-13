using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Managers;
using AU3DPort.VanillaPort.Roles.Impostor;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Utilities.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Gamemodes.Tag;
using AU3DPort.VanillaPort.Options;
using AU3DPort.VanillaPort.Roles.Crewmate;
using AU3DPort.VanillaPort.Roles.Infection.Crewmate;
using MiraAPI.GameModes;
using UnityEngine;

namespace AU3DPort.VanillaPort.Buttons.InfectionPowers.UnUsedPowers
{
    public class Sabotage : CustomActionButton
    {
        public override string Name => "Sabotage";
        public override float Cooldown => 0f;
        public override LoadableAsset<Sprite> Sprite => AssetManager.Sabotage;
        public override bool PauseTimerInVent => true;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.TertiaryAbility;
        public override int MaxUses => 1;

        protected override void OnClick()
        {
            if (!AmongUsClient.Instance.AmHost && IsSabotageActiveOrCoolingDown()) return;

            foreach (SystemTypes room in CheckMap().FastRooms._keys)
            {
                CheckMap().RpcCloseDoorsOfType(room);
            }
        }
        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            var sabotage = OptionGroupSingleton<InfectionUnusedOrRemovePowers>.Instance;
            return role is CrewmateTag && sabotage.SabotageEnabled && CustomGameModeManager.ActiveMode is TagGamemode;
        }
        public static ShipStatus CheckMap()
        {
            return ShipStatus.Instance;
        }

        public static bool IsSabotageActiveOrCoolingDown()
        {
            ShipStatus instance = CheckMap();
            if (instance == null) return false;

            if (instance.Systems.TryGetValue(SystemTypes.Sabotage, out ISystemType system))
            {
                SabotageSystemType sabSystem = system.TryCast<SabotageSystemType>();
                if (sabSystem == null) return false;

                bool isActive = sabSystem.AnyActive;
                bool isCoolingDown = sabSystem.Timer > 0f && !sabSystem.AnyActive;

                return isActive || isCoolingDown;
            }

            return false;
        }
    }
}
