using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Roles.Crewmate;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Utilities.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace AU3DPort.VanillaPort.Buttons.InfectionPowers.UnUsedPowers
{
    public class LightsOut : CustomActionButton
    {
        public override string Name => "LightsOut";
        public override float Cooldown => 0f;
        public override LoadableAsset<Sprite> Sprite => AssetManager.LightsOut;
        public override bool PauseTimerInVent => true;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.ModifierTertiaryAbility;
        public override int MaxUses => 1;

        protected override void OnClick()
        {
            if (AmongUsClient.Instance.AmHost && !IsSabotageActiveOrCoolingDown())
            {
                CheckMap().RpcUpdateSystem(SystemTypes.Sabotage, 7);
            }
        }
        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            return false;
            //return role is Chef;
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
