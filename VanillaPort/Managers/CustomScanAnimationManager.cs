using AU3DPort;
using AU3DPort.VanillaPort.Assets;
using PowerTools;
using Reactor.Utilities.Extensions;
using UnityEngine;

public class CustomScanAnimationManager
{
    public static AssetBundle Bundle = null!;
    public static Dictionary<PlayerControl, GameObject> ScanObjects = new Dictionary<PlayerControl, GameObject>();

    public static void CreateScanHandler(PlayerControl player)
    {
        if (Core.IsMobile)
        {
            if (Bundle == null)
                Bundle = AssetManager.LoadMobileAssetBundle();
            
            string path = $"{player.name}/Animations/Scanner/ScanFront";
            GameObject scanFront = GameObject.Find(path);
            GameObject customScan = UnityEngine.Object.Instantiate(scanFront);
            customScan.transform.parent = scanFront.transform.parent;
            customScan.SetActive(true);
            customScan.GetComponent<SpriteAnim>()
                .Play(Bundle.LoadAsset<AnimationClip>("assets/animations/scanning_scan.anim"));
            customScan.name = "Scan Animation";
            customScan.transform.localPosition = new Vector3(-0.02f, -0.02f, -0.001f);
            customScan.transform.localScale = new Vector3(0.52f, 0.51f, 1);
            ScanObjects[player] = customScan;
        }
        else
        {
            if (Bundle == null)
                Bundle = AssetManager.LoadAssetBundle();

            string path = $"{player.name}/Animations/Scanner/ScanFront";
            GameObject scanFront = GameObject.Find(path);
            GameObject customScan = UnityEngine.Object.Instantiate(scanFront);
            customScan.transform.parent = scanFront.transform.parent;
            customScan.SetActive(true);
            customScan.GetComponent<SpriteAnim>()
                .Play(Bundle.LoadAsset<AnimationClip>("assets/animations/scanning_scan.anim"));
            customScan.name = "Scan Animation";
            customScan.transform.localPosition = new Vector3(-0.02f, -0.02f, -0.001f);
            customScan.transform.localScale = new Vector3(0.52f, 0.51f, 1);
            ScanObjects[player] = customScan;
        }
    }

    public static void DisableScanObject(PlayerControl player)
    {
        if (ScanObjects.TryGetValue(player, out GameObject scanObj))
        {
            scanObj.SetActive(false);
        }
    }

    public static void ActivateScanObject(PlayerControl player)
    {

        if (ScanObjects.TryGetValue(player, out GameObject scanObj))
        {
            scanObj.SetActive(true);
            scanObj.GetComponent<SpriteAnim>()
                .Play(Bundle.LoadAsset<AnimationClip>("assets/animations/scanning_scan.anim"));
        }
        else
        {
            CreateScanHandler(player);
        }
    }
}