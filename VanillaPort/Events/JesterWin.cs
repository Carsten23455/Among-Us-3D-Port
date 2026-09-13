using MiraAPI.GameEnd;
using MiraAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Roles.Neutral;
using UnityEngine;

namespace AU3DPort.VanillaPort.Events
{
    public class JesterWin : CustomGameOver
    {
        public override bool VerifyCondition(PlayerControl playerControl, NetworkedPlayerInfo[] winners)
        {
            return winners is [{ Role: Jester }];
        }

        public override void AfterEndGameSetup(EndGameManager endGameManager)
        {
            endGameManager.WinText.text = $"Jester Wins!";
            endGameManager.WinText.color = Color.magenta;
            endGameManager.BackgroundBar.material.SetColor(ShaderID.Color, Color.magenta);
            endGameManager.ImpostorStinger = Assets.AssetManager.VigiIntro.LoadAsset();
        }
        public override bool BeforeEndGameSetup(EndGameManager endGameManager)
        {
            endGameManager.ImpostorStinger = Assets.AssetManager.VigiIntro.LoadAsset();
            return true;
        }
    }
}
