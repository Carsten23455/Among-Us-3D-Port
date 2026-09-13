using UnityEngine;

namespace AU3DPort.VanillaPort.Utils;

public static class VentUtils
{
    public static List<Vent> GetClosestVents(
        PlayerControl source,
        float distance = 2f,
        bool ignoreColliders = true)
    {
        if (!ShipStatus.Instance)
        {
            return [];
        }

        var myPos = source.GetTruePosition();
        return GetClosestVents(myPos, distance, ignoreColliders);
    }
    
    public static Vent? GetClosestVent(
        this PlayerControl playerControl,
        float distance,
        bool ignoreColliders = true,
        Predicate<Vent>? predicate = null)
    {
        var filteredVents = GetClosestVents(playerControl, distance, ignoreColliders);
        return predicate != null ? filteredVents.Find(predicate) : filteredVents.FirstOrDefault();
    }

    public static List<Vent> GetClosestVents(
        Vector2 position,
        float distance = 2f,
        bool ignoreColliders = true)
    {
        if (!ShipStatus.Instance)
        {
            return [];
        }

        var vents = ShipStatus.Instance.AllVents
            .Where(vent => vent != null)
            .Where(vent =>
            {
                var ventPos = vent.transform.position;
                if (Vector2.Distance(position, ventPos) > distance) return false;

                if (!ignoreColliders)
                {
                    return !PhysicsHelpers.AnythingBetween(position, ventPos, Constants.ShipAndObjectsMask, false);
                }

                return true;
            })
            .OrderBy(vent => Vector2.Distance(position, vent.transform.position))
            .ToList();

        return vents;
    }
}