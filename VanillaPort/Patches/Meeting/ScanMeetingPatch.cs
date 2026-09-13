using AU3DPort.VanillaPort.Assets;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Buttons;
using AU3DPort.VanillaPort.Managers;
using UnityEngine;

namespace AU3DPort.VanillaPort.Patches.Meeting
{

    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Start))]
    public static class MeetingHudStartPatch
    {
        public static void Postfix(MeetingHud __instance)
        {
            foreach (var voteArea in __instance.playerStates)
            {
                byte playerId = voteArea.PlayerId;
                var result = ScanResultStorageManager.Get(playerId);

                if (result == null) continue;
                if (voteArea.AmDead) continue;

                var iconObj = new GameObject($"ScanIcon_{playerId}");
                iconObj.transform.SetParent(voteArea.transform, false);
                iconObj.transform.localPosition = new Vector3(-0.4f, 0.1f, -1f);
                iconObj.layer = LayerMask.NameToLayer("UI");

                var sr = iconObj.AddComponent<SpriteRenderer>();
                sr.sortingOrder = 20;

                switch (result)
                {
                    case ScanResult.Crewmate:
                        sr.sprite = AssetManager.Checkmark.LoadAsset();
                        break;
                    case ScanResult.ImpostorOrNeutral:
                        sr.sprite = AssetManager.Exclamation.LoadAsset();
                        break;
                    case ScanResult.Failed:
                        sr.sprite = AssetManager.TryAgain.LoadAsset();
                        break;
                }

                iconObj.transform.localScale = Vector3.one * 0.35f;
            }
        }
    }

    [HarmonyPatch(typeof(GameManager), nameof(GameManager.RpcEndGame))]
    public class EndGameCleanUpPatch
    {
        public static void PostFix()
        {
            ScanResultStorageManager.Clear();
            ScanIndicatorManager.ClearAll();
        }
    }
}
