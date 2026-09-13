using AU3DPort.VanillaPort.Modifiers;
using AU3DPort.VanillaPort.Roles;
using MiraAPI.GameEnd;
using MiraAPI.Modifiers;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AU3DPort.VanillaPort.Events
{
    public class AllPlayersInfectedGameOver : CustomGameOver
    {
        public override void AfterEndGameSetup(EndGameManager endGameManager)
        {
            endGameManager.WinText.text = "Infected Win!";
            endGameManager.WinText.color = Color.green;
            endGameManager.BackgroundBar.material.SetColor(ShaderID.Color, Color.black);
        }
    }
}
