using AchievementsAPI.API;
using AU3DPort.VanillaPort.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AU3DPort.VanillaPort.Achievements
{
    public class AU3DTag : AchievementsTab
    {
        public override bool IsSelectable => true;
        public override string Name => "AU3D/Tag";
        public override Color GetTabColor()
        {
            return Color.black;
        }
        public override Sprite GetIcon()
        {
            return AssetManager.InfectIcon.LoadAsset();
        }
        public CountAchievement Tastey { get; set; } = new CountAchievement("Tasty", "infect your first crewmate", "AU3DPort.VanillaPort.Assets.Sprites.Buttons.InfectIcon.png", 0, 1, true, 1);
        public CountAchievement Infectious { get; set; } = new CountAchievement("Infectious", "infect 5 crewmates", "AU3DPort.VanillaPort.Assets.Sprites.Buttons.InfectIcon.png", 0, 5, true,3);
        public CountAchievement Spoiled { get; set; } = new CountAchievement("Spoiled", "infect 50 crewmates", "AU3DPort.VanillaPort.Assets.Sprites.Buttons.InfectIcon.png", 0, 50, true,5);
        public CountAchievement Contaminated { get; set; } = new CountAchievement("Contaminated", "infect 150 crewmates", "AU3DPort.VanillaPort.Assets.Sprites.Buttons.InfectIcon.png", 0, 150, true,10);
        public BaseAchievement TrueInfected { get; set; } = new BaseAchievement("Patient Zero", "win a game as infected starting as an infected", "AU3DPort.VanillaPort.Assets.Sprites.Buttons.InfectIcon.png", 1);
        public BaseAchievement TrueHero { get; set; } = new BaseAchievement("True Hero", "complete a game of tag without using any powers", "AU3DPort.VanillaPort.Assets.Sprites.Buttons.InfectIcon.png", 10);
        public BaseAchievement freeloader { get; set; } = new BaseAchievement("Freeloader", "win a game of tag as a crewmate without completing any tasks", "AU3DPort.VanillaPort.Assets.Sprites.Buttons.InfectIcon.png", 10);
        public BaseAchievement Clutched { get; set; } = new BaseAchievement("Clutched", "win as the last crewmate in tag", "AU3DPort.VanillaPort.Assets.Sprites.Buttons.InfectIcon.png", 10);
    }
}
