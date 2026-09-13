using AU3DPort.VanillaPort.Assets;
using System.Collections.Generic;
using AU3DPort.VanillaPort.Buttons;
using UnityEngine;

namespace AU3DPort.VanillaPort.Managers
{
    public static class ScanIndicatorManager
    {
        private static readonly Dictionary<byte, GameObject> _icons = new();

        public static void AttachTo(PlayerControl player, ScanResult result)
        {
            Remove(player.PlayerId);

            GameObject iconObj = new GameObject("ScanIndicator");
            iconObj.transform.SetParent(player.transform, false);

            TMPro.TMP_Text nameText = player.cosmetics.nameText;
            float nameWidth = nameText != null ? nameText.preferredWidth * 0.5f : 0.5f;
            iconObj.transform.localPosition = new Vector3(nameWidth + 0.235f, 1f, 0f);

            SpriteRenderer sr = iconObj.AddComponent<SpriteRenderer>();
            sr.sortingLayerName = "Player";
            sr.sortingOrder = 10;
            sr.transform.localScale = Vector3.one * 0.4f;
            sr.sprite = result switch
            {
                ScanResult.Crewmate => AssetManager.Checkmark.LoadAsset(),
                ScanResult.ImpostorOrNeutral => AssetManager.Exclamation.LoadAsset(),
                ScanResult.Failed => AssetManager.TryAgain.LoadAsset(),
                _ => null
            };

            _icons[player.PlayerId] = iconObj;
        }

        public static void Remove(byte playerId)
        {
            if (_icons.TryGetValue(playerId, out var obj))
            {
                if (obj != null) UnityEngine.Object.Destroy(obj);
                _icons.Remove(playerId);
            }
        }

        public static void ClearAll()
        {
            foreach (var obj in _icons.Values)
                if (obj != null) UnityEngine.Object.Destroy(obj);
            _icons.Clear();
        }
    }
}