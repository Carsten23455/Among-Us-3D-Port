using MiraAPI.GameOptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Options;
using UnityEngine;

namespace AU3DPort.VanillaPort.Managers
{
    public class ContainmentManager
    {
        public static SkeldShipStatus Skeld = null;
        public static MiraShipStatus Mira = null;
        public static PolusShipStatus Polus = null;
        public static AirshipStatus AirShip = null;
        public static FungleShipStatus Fungle = null;
        public static ShipStatus __instance;
        /*
        public static Containment _containment => OptionGroupSingleton<Containment>.Instance;
        */
        public static bool FoundMaps = false;
        public static string SceneName = "";
        public static byte sabotage = 0;
        public static Coroutine _sabotageCoroutine = null;
        public static float SabotageCooldown = 35;
        /*
        public static bool ContainmentEnabled => _containment.Enabled;
        */

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

        public static void RandomSabSystem()
        {
            SabotageCooldown -= Time.deltaTime;
            if (!AmongUsClient.Instance.AmHost) return;
            if (SabotageCooldown > 0) return;

            if (IsSabotageActiveOrCoolingDown())
            {
                SabotageCooldown = 35;
                Debug.Log("[ContainmentManager] Sabotage blocked — active or cooling down.");
                return;
            }

            sabotage = (byte)(UnityEngine.Random.Range(0, 2) == 0 ? 3 : 8);

            ShipStatus instance = CheckMap();
            if (instance == null)
            {

                Debug.LogWarning("[ContainmentManager] ShipStatus instance is null or map is not mira or skeld (soon submerged).");
                return;
            }

            instance.RpcUpdateSystem(SystemTypes.Sabotage, sabotage);
            SabotageCooldown = 35;
        }
    }
}
