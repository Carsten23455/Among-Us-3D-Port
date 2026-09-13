using MiraAPI.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AU3DPort.VanillaPort.CustomColors
{
    [RegisterCustomColors]
    public static class CustomColors
    {
        public static CustomColor Infected { get; } = new("Infected", new Color(1.2f, 1.44f, 0.11f))
        {
            MainColor = new Color(0.68f, 0.65f, 0.03f),
            ShadowColor = new Color(0.46f, 0.54f, 0.019f),
            ColorBrightness = CustomColorBrightness.Darker,
        };
        // Unused 3D
        public static CustomColor HeatValue { get; } = new("Temperature", new Color(0, 0, 0))
        {
            MainColor = new Color(1f, 0.55f, 0f),
            ShadowColor = new Color(0.4f, 0f, 0.8f), 
            ColorBrightness = CustomColorBrightness.Lighter,
        };
        public static CustomColor Silver { get; } = new("Silver", new Color(0, 0, 0))
        {
            MainColor = new Color(0.9f, 0.9f, 0.9f),
            ShadowColor = new Color(0.4f, 0.4f, 0.4f),
            ColorBrightness = CustomColorBrightness.Lighter,
        };
        public static CustomColor Gold { get; } = new("Gold", new Color(0, 0, 0))
        {
            MainColor = new Color(1f, 0.85f, 0f),
            ShadowColor = new Color(0.6f, 0.45f, 0f),
            ColorBrightness = CustomColorBrightness.Lighter,
        };
        public static CustomColor GradientRose { get; } = new("Gradient Rose", new Color(0, 0, 0))
        {
            MainColor = new Color(0.95f, 0.6f, 0.85f),
            ShadowColor = new Color(0.65f, 0.3f, 0.55f),
            ColorBrightness = CustomColorBrightness.Lighter,
        };
        public static CustomColor GradientLime { get; } = new("Gradient Green", new Color(0, 0, 0))
        {
            MainColor = new Color(0.1f, 0.85f, 0.1f),
            ShadowColor = new Color(0.0f, 0.4f, 0.0f),
            ColorBrightness = CustomColorBrightness.Lighter,
        };
        // Unused 2D
        public static CustomColor Olive { get; } = new("Olive", new Color(0, 0, 0))
        {
            MainColor = new Color(0.38f, 0.44f, 0.09f),
            ShadowColor = new Color(0.25f, 0.35f, 0.05f),
            ColorBrightness = CustomColorBrightness.Lighter,
        };
        public static CustomColor ForteGreen { get; } = new("ForteGreen", new Color(0, 0, 0))
        {
            MainColor = new Color(0.14f, 0.65f, 0.38f),
            ShadowColor = new Color(0.07f, 0.24f, 0.1f),
            ColorBrightness = CustomColorBrightness.Lighter,
        };
        public static CustomColor SaturatedYellow { get; } = new("Saturated Yellow", new Color(0, 0, 0))
        {
            MainColor = new Color(1f, 1f, 0.05f),
            ShadowColor = new Color(0.99f, 0f, 0f),
            ColorBrightness = CustomColorBrightness.Lighter,
        };
        // Custom
        public static CustomColor Darker_Black { get; } = new("Dark Black", new Color(0f, 0f, 0f))
        {
            MainColor = new Color(0f, 0f, 0f),
            ShadowColor = new Color(0f, 0f, 0f),
        };
        public static CustomColor Bright_White { get; } = new("White", new Color(1f, 1f, 1f))
        {
            MainColor = new Color(1f, 1f, 1f),
            ShadowColor = new Color(1f, 1f, 1f),
        };
        // Helper Methods
        public static byte CheckWatermelon()
        {
            if ((Color)Palette.PlayerColors[18] == (Color)new Color32(168, 50, 62, 255))
            {
                return 52; // this really only works if the mod used is TownOfUsMira will check for that assembly later
            }
            else
            {
                return 18;
            }
        }
    }
}
