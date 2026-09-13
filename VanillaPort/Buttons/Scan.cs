using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Options.RoleOptions;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using System.Collections.Generic;
using AU3DPort.VanillaPort.Managers;
using AU3DPort.VanillaPort.Options;
using AU3DPort.VanillaPort.Roles.Crewmate;
using UnityEngine;
using xCloud;

namespace AU3DPort.VanillaPort.Buttons
{
    public enum ScanResult
    {
        Crewmate,
        ImpostorOrNeutral,
        Failed
    }

    public class Scan : CustomActionButton<PlayerControl>
    {
        public override string Name => "Scan";
        public override float Cooldown => 0;
        public override float EffectDuration => 0f;
        public override int MaxUses => 1;
        public override ButtonUsesMode UsesMode => ButtonUsesMode.PerRound;
        public override LoadableAsset<Sprite> Sprite => AssetManager.ScannerAsset;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.PrimaryAbility;

        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            return role is CriticalCrewmate;
        }

        protected override void OnClick()
        {
            var CritCrew = OptionGroupSingleton<CriticalCargo>.Instance;
            if (Target == null) return;

            ScanResult result;
            if (UnityEngine.Random.RandomRange(1, 101) <= CritCrew.ScanFailChance)
                result = ScanResult.Failed;
            else if (Target.Data.Role.IsImpostor)
                result = ScanResult.ImpostorOrNeutral;
            else if (Target.Data.Role is CriticalCrewmate)
                result = ScanResult.ImpostorOrNeutral;
            else
                result = ScanResult.Crewmate;

            ScanResultStorageManager.Store(Target.PlayerId, result);
            ScanIndicatorManager.AttachTo(Target, result);
            Debug.Log($"Stored scan result for player {Target.PlayerId}: {result}");
        }


        public override PlayerControl? GetTarget()
        {
            return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);
        }

        public override void SetOutline(bool active)
        {
            Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.PlayerColors[5]));
        }
    }
}