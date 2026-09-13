using AchievementsAPI.API;
using AU3DPort.VanillaPort.Achievements;
using AU3DPort.VanillaPort.Buttons;
using AU3DPort.VanillaPort.Buttons.InfectionPowers.OriginalPowers;
using AU3DPort.VanillaPort.Managers;
using AU3DPort.VanillaPort.Options;
using AU3DPort.VanillaPort.Roles.Impostor;
using HarmonyLib;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Gamemodes.Tag;
using MiraAPI.GameModes;
using UnityEngine;

namespace AU3DPort.VanillaPort.Patches
{
    [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.FixedUpdate))]
    public static class ShipStatusUpdatePatch
    {
        public static void Postfix()
        {
            /*
            switch (AmongUsClient.Instance.AmHost)
            {
                case true when ContainmentManager.ContainmentEnabled:
                    ContainmentManager.RandomSabSystem();
                    break;
                case false:
                    return;
            }
            */
            var infectButton = CustomButtonSingleton<Infect>.Instance;

            foreach (var player in PlayerControl.AllPlayerControls)
            {
                KnowledgePowerManager.UpdateCooldown(player.PlayerId, infectButton.Timer);
            }
        }
    }


    [HarmonyPatch(typeof(GameManager), nameof(GameManager.RpcEndGame))]
    public static class EndGamePatch
    {
        public static void PostFix()
        {
            /*
            if (AmongUsClient.Instance.AmHost && ContainmentManager.ContainmentEnabled)
            {
                ContainmentManager.SabotageCooldown = 35;
            }
            */
            if (CustomGameModeManager.ActiveMode is TagGamemode && AmongUsClient.Instance.AmClient && !AchievementsTabSingleton<AU3DTag>.Instance.freeloader.Unlocked && AchievementHandler.CanUnlockFreeloader)
            {
                AchievementsTabSingleton<AU3DTag>.Instance.freeloader.Unlock();
            }
        }
    }
}
