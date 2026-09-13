using AU3DPort.VanillaPort.Events;
using AU3DPort.VanillaPort.Gamemodes.Tag;
using AU3DPort.VanillaPort.Options;
using AU3DPort.VanillaPort.Roles.Crewmate;
using HarmonyLib;
using MiraAPI.GameEnd;
using MiraAPI.GameModes;
using MiraAPI.GameOptions;
/*
 TODO: Reenable if needed else remove before release
[HarmonyPatch(typeof(GameManager), nameof(GameManager.RpcEndGame))]
public class CheckEndGamePatch
{
    public static bool Prefix(GameOverReason endReason, bool showAd)
    {
        if (!AmongUsClient.Instance.AmHost) return true;
        if (CustomGameModeManager.ActiveMode is not TagGamemode)
        {
            return true;
        }

        return TagGamemode.shouldEndGame;
    }
}
*/
