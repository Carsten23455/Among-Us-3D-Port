using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace AU3DPort.VanillaPort.Managers
{
    public class KnowledgePowerManager
    {
        private static readonly Dictionary<byte, TextMeshPro> _cooldownTexts = new();

        public static void AttachTo(PlayerControl player)
        {
            if (_cooldownTexts.ContainsKey(player.PlayerId)) return;

            GameObject iconObj = new GameObject("KnowledgeCooldown");
            iconObj.transform.SetParent(player.transform, false);

            TMPro.TMP_Text nameText = player.cosmetics.nameText;
            float nameWidth = nameText != null ? nameText.preferredWidth * 0.5f : 0.5f;
            iconObj.transform.localPosition = new Vector3(nameWidth + 0.235f, 1f, 0f);

            TextMeshPro tmp = iconObj.AddComponent<TextMeshPro>();
            tmp.fontSize = 2f;
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.text = "";
            tmp.color = new Color(0.68f, 0.65f, 0.03f);

            _cooldownTexts[player.PlayerId] = tmp;
        }

        public static void UpdateCooldown(byte playerId, float cooldownRemaining)
        {
            if (!_cooldownTexts.TryGetValue(playerId, out var tmp) || tmp == null) return;

            tmp.text = Mathf.CeilToInt(cooldownRemaining).ToString();
        }

        public static void RemoveFor(byte playerId)
        {
            if (_cooldownTexts.TryGetValue(playerId, out var tmp) && tmp != null)
                UnityEngine.Object.Destroy(tmp.gameObject);

            _cooldownTexts.Remove(playerId);
        }

        public static void ClearAll()
        {
            foreach (var tmp in _cooldownTexts.Values)
                if (tmp != null) UnityEngine.Object.Destroy(tmp.gameObject);

            _cooldownTexts.Clear();
        }
    }
}
