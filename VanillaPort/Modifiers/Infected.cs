using AU3DPort.VanillaPort.Events;
using AU3DPort.VanillaPort.Roles.Impostor;
using AmongUs.GameOptions;
using MiraAPI.GameEnd;
using MiraAPI.Modifiers;
using MiraAPI.Modifiers.Types;
using MiraAPI.Roles;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using static AU3DPort.VanillaPort.Networking.RpcManager;

namespace AU3DPort.VanillaPort.Modifiers
{
    public class InfectedModifier : GameModifier
    {
        public override string ModifierName => "";
        private int _originalColor;
        
        public override void OnActivate()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                _originalColor = Player.Data.DefaultOutfit.ColorId;
                Player.RpcSetColor(CustomColors.CustomColors.CheckWatermelon());
                RpcSetBody(Player, PlayerBodyTypes.Seeker);
            }
        }

        public override int GetAssignmentChance() => 0;
        public override int GetAmountPerGame() => 0;

        public override void OnDeactivate()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                if (!GameManager.Instance.GameHasStarted)
                {
                    Player.RpcSetColor((byte)_originalColor);
                }
            }
        }

        public override string GetDescription() => "";
    }
}