using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU3DPort.VanillaPort.Buttons;

namespace AU3DPort.VanillaPort.Managers
{
    public static class ScanResultStorageManager
    {
        public static readonly Dictionary<byte, ScanResult> Results = new();

        public static void Store(byte playerId, ScanResult result)
        {
            Results[playerId] = result;
        }

        public static ScanResult? Get(byte playerId)
        {
            return Results.TryGetValue(playerId, out var result) ? result : null;
        }

        public static void Clear()
        {
            Results.Clear();
        }
    }
}
