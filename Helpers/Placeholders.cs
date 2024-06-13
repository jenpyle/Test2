using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.HmiColors;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.Placeholders;

namespace Mikron_MOAB_HMI.Helpers
{
    public static class Placeholders
    {
        public static string PlaceholderText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

        public static string AlarmMessageShort = "(10041) S06 Widget: Widget Scrap Bin Present [=S06.DL1+C01-B8 Not On]";

        public static string AlarmMessageMedium = "(10022) S02 Check Widget: Widget Present in Nest 1 [=S02.DM1+FU1-K1 Not Off]";

        public static string AlarmMessageLong = "(10001) S01 ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMN: ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMN [=S01.DM1+FU1-K1-K1-K1 Not On]";
    }
}