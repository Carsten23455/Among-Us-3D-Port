using AchievementsAPI.API;
using AU3DPort.VanillaPort.Assets;
using AU3DPort.VanillaPort.Buttons;
using AU3DPort.VanillaPort.Roles.Impostor;
using Il2CppSystem.Web;
using System.Reflection;
using UnityEngine;

namespace AU3DPort.VanillaPort.Achievements
{
    public class AU3DClassic : AchievementsTab
    {
        public override bool IsSelectable => true;
        public override string Name => "AU3D/Classic";
        public override Color GetTabColor()
        {
            return Color.black;
        }
        public override Sprite GetIcon()
        {
            return AssetManager.WraithKillAsset.LoadAsset();
        }
        public BaseAchievement a1v2 { get; set; } = new BaseAchievement("1v2", "win the game as Vigilante and have killed 2 Impostors", AssetManager.VigiKillIcon.LoadAsset());
        public BaseAchievement JusticeServed { get; set; } = new BaseAchievement("Justice has been served", "win a round after killing an impostor as a vigilante", AssetManager.VigiKillIcon.LoadAsset());
        public BaseAchievement futileEfforts { get; set; } = new BaseAchievement("Futile Efforts", "scan a crewmate as a scanner and then have that crewmate ejected", AssetManager.ScannerAsset.LoadAsset());
        public BaseAchievement falsePositive { get; set; } = new BaseAchievement("False Positive", "scan a vigilante as a scanner and then die to that vigilante", AssetManager.ScannerAsset.LoadAsset());
        public BaseAchievement unlucky { get; set; } = new BaseAchievement("Unlucky", "scan an impostor as a scanner and then die to that impostor", AssetManager.ScannerAsset.LoadAsset());
        public BaseAchievement iminnocent { get; set; } = new BaseAchievement("I'm Innocent!", "win a match without dying as the wraith", AssetManager.WraithIcon.LoadAsset());
        public BaseAchievement haunted { get; set; } = new BaseAchievement("Haunted", "kill 5 crewmates as the wraith", AssetManager.WraithIcon.LoadAsset());
        //public BaseAchievement OnlyOne { get; set; } = new BaseAchievement("There can only be one...", "eject another impostor as an impostor deputy", "AU3DPort.VanillaPort.Assets.Sprites.Buttons.DeputyIcon.png");
        //public BaseAchievement BestSheriff { get; set; } = new BaseAchievement("Best sheriff in the west", "eject 5 impostors as a crewmate deputy", "AU3DPort.VanillaPort.Assets.Sprites.Buttons.DeputyIcon.png");
        public BaseAchievement Reprotected { get; set; } = new BaseAchievement("Reprotected", "protect a crewmate from the same killer twice", AssetManager.GuardPink.LoadAsset());

    }
}
