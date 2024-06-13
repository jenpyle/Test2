using FTOptix.Core;
using System;

namespace Mikron_MOAB_HMI.Helpers
{
    public static class HmiColors
    {
        public static Color PrimaryColor => GetHexToColor("#FFFFFF4D");

        public static Color PrimaryBorder => GetHexToColor("#4dd8ff97");

        public static Color SecondaryColor => GetHexToColor("003399");

        public static Color SecondaryBorder => GetHexToColor("#000000");

        public static Color Failure => GetHexToColor("#ff1a4c");

        public static Color Ready => GetHexToColor("#08c008");

        public static Color Alert => GetHexToColor("#fed42a");

        public static Color Black => GetHexToColor("#000000");

        public static Color White => GetHexToColor("#ffffff");

        public static Color DarkGrey => GetHexToColor("#000000");

        public static Color Transparent => GetHexToColor("#ffffff00");
        public static Color TempColor1 => GetHexToColor("#B2EBF2");
        public static Color TempColor2 => GetHexToColor("#DCEDC8");
        public static Color TempColor3 => GetHexToColor("#F8BBD0");

        private static Color GetHexToColor(string hex)
        {
            if (hex.StartsWith("#"))
            {
                hex = hex.Substring(1);
            }

            byte red = Convert.ToByte(hex.Substring(0, 2), 16);
            byte green = Convert.ToByte(hex.Substring(2, 2), 16);
            byte blue = Convert.ToByte(hex.Substring(4, 2), 16);
            byte alpha = hex.Length > 6 ? Convert.ToByte(hex.Substring(6, 2), 16) : (byte)255;

            return new Color(alpha, red, green, blue);
        }
    }
}