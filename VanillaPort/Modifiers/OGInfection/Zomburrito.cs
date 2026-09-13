using MiraAPI.Modifiers;
using MiraAPI.Modifiers.Types;

namespace AU3DPort.VanillaPort.Modifiers.OGInfection
{
    public class ZomburritoModifier : GameModifier
    {
        public override string ModifierName => "";
        private int _originalColor;
        
        public override void OnActivate()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                _originalColor = Player.Data.DefaultOutfit.ColorId;
                Player.RpcSetHat("6038d7f9-fd38-be49-bb32-6b72cb445102");
                Player.RpcSetColor(11);
                if (Player.GetModifier<ChefModifier>() != null)
                {
                    Player.RpcRemoveModifier<ChefModifier>();
                }
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