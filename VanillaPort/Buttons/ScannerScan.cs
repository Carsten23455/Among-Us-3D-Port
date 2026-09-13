using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Options;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using Reactor.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Managers;
using AU3DPort.VanillaPort.Options.RoleOptions;
using AU3DPort.VanillaPort.Roles.Crewmate;
using AU3DPort.VanillaPort.Roles.Neutral;
using UnityEngine;

namespace AU3DPort.VanillaPort.Buttons
{
    public class ScannerScan : CustomActionButton<PlayerControl>
    {
        ScannerOption scanner = OptionGroupSingleton<ScannerOption>.Instance;
        public override string Name => "Scan";
        public override float Cooldown => scanner.ScanCoolDown;
        public override float EffectDuration => 0f;
        public override int MaxUses => (int)scanner.MaxUses;
        public override ButtonUsesMode UsesMode => ButtonUsesMode.PerGame;
        public override LoadableAsset<Sprite> Sprite => AssetManager.ScannerAsset;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.PrimaryAbility;
        public AudioClip ScanSFX = null!;
        public AudioClip ScanCompleteSFX = null!;

        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            return role is Scanner;
        }

        protected override void OnClick()
        {
            if (Target == null) return;
            Coroutines.Start(ScanRoutine(Target));
        }

        public IEnumerator ScanRoutine(PlayerControl target)
        {
            if (ScanSFX == null && ScanCompleteSFX == null)
            {
                ScanSFX = AssetManager.ScanSfx.LoadAsset();
                ScanCompleteSFX = AssetManager.ScanCompleteSfx.LoadAsset();
            }
            float timer = 0f;
            Vector3 lastPos = target.transform.position;
            CustomScanAnimationManager.ActivateScanObject(target);
            SoundManager.Instance.PlaySound(ScanSFX, false);
            while (timer < 3f)
            {
                if (target == null)
                {
                    CustomScanAnimationManager.DisableScanObject(target);
                    SoundManager.Instance.StopSound(ScanSFX);
                    IncreaseUses(1);
                    yield break;
                }
                if (Vector3.Distance(target.transform.position, lastPos) > 0.01f)
                {
                    CustomScanAnimationManager.DisableScanObject(target);
                    SoundManager.Instance.StopSound(ScanSFX);
                    IncreaseUses(1);
                    yield break;
                }
                timer += Time.deltaTime;
                yield return null;
            }

            SoundManager.Instance.StopSound(ScanSFX);
            SoundManager.Instance.PlaySound(ScanCompleteSFX, false);

            ScanResult result;
            if (target.Data.Role.IsImpostor || target.Data.Role is Jester)
                result = ScanResult.ImpostorOrNeutral;
            else
                result = ScanResult.Crewmate;

            ScanResultStorageManager.Store(target.PlayerId, result);
            ScanIndicatorManager.AttachTo(target, result);
            CustomScanAnimationManager.DisableScanObject(target);
            Debug.Log($"Stored scan result for player {target.PlayerId}: {result}");
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
