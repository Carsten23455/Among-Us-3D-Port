using System.Reflection;
using AchievementsAPI;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using CorsacCosmetics;
using CorsacCosmetics.Cosmetics;
using HarmonyLib;
using MiraAPI;
using MiraAPI.PluginLoading;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using Reactor.Utilities;
using xCloud;

namespace AU3DPort
{
    [BepInPlugin("TeamMessHall.AmongUs3DPort", "Among Us: 3D Port", "0.0.0")]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency(MiraApiPlugin.Id)]
    [BepInDependency(AchievementsAPIPlugin.Id)]
    [BepInDependency(CorsacCosmeticsPlugin.Id)]
    [BepInDependency(ModCompatibility.SubmergedId, BepInDependency.DependencyFlags.SoftDependency)]
    [ReactorModFlags(ModFlags.RequireOnAllClients | ModFlags.DisableServerAuthority)]
    public class Core : BasePlugin, IMiraPlugin
    {

        public Harmony Harmony { get; } = new("com.teammesshall.AmongUs3DPort");
        public string OptionsTitleText => "AU3D";
        public ConfigFile GetConfigFile() => Config;
        public static bool IsMobile = OperatingSystem.IsAndroid() || OperatingSystem.IsIOS();

        public override void Load()
        {
            ReactorCredits.Register("AU3DPort", "Dev-Production", true, ReactorCredits.AlwaysShow);
            Harmony.PatchAll();
            byte[] bundleData;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AU3DPort.VanillaPort.Assets.Bundles.au3dhats.ccb"))
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                bundleData = ms.ToArray();
            }

            PluginCompat.AddBundleBytes(bundleData);
        }

    }
}