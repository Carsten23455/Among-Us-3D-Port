using AmongUs.GameOptions;
using MiraAPI.GameEnd;
using MiraAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AU3DPort.VanillaPort.GameEnd
{
    internal class GameOverCriticalCrewmate : CustomGameOver
    {

        public override void AfterEndGameSetup(EndGameManager endGameManager)
        {
            endGameManager.WinText.text = "All Critical Crewmates Died!";
            endGameManager.WinText.color = Color.white;
            endGameManager.BackgroundBar.material.SetColor(ShaderID.Color, Color.black);
        }
    }
}
