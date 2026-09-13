//using _3dport_for_2d.Assets;
//using _3dport_for_2d.Modifiers;
//using _3dport_for_2d.Options;
//using _3dport_for_2d.Roles.Crewmate;
//using _3dport_for_2d.Roles.Impostor;
//using MiraAPI.Hud;
//using MiraAPI.Keybinds;
//using MiraAPI.Utilities.Assets;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine;

//namespace _3dport_for_2d.Buttons.InfectionPowers.OriginalPowers
//{
//    internal class Detect : CustomActionButton
//    {
//        public override string Name => "Detect";
//        public override float Cooldown => 0f;
//        public override LoadableAsset<Sprite> Sprite => AssetManager.Detect;
//        public override bool PauseTimerInVent => true;
//        public override BaseKeybind? Keybind => MiraGlobalKeybinds.PrimaryAbility;

//        protected override void OnClick()
//        {
//            SOMEONE HELP ME IDK HOW TO DO MORE THAN ONE TRACKER TARGET THING LMAO
//            good god wtf was i on
//        }
//        public override bool Enabled(RoleBehaviour? role)
//        {
//            SetButtonLocation(ButtonLocation.BottomRight);
//            return role is Chef;
//        }
//    }
//}
