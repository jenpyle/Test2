using FTOptix.UI;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Helpers
{
    //TODO - Have seperate icon and image classes
    public static class Icons
    {
        #region Icon Images
        public static Image MikronAutomationLogo = MakeDefaultImageStretch("MikronLogo", "MikronAutomationLogo.svg");
        public static Image BaseBackground = MakeDefaultImageStretch("BaseBackground", "MikronGradient.jpg");
        public static Image PageBackground = MakeDefaultImageStretch("BasePageBackground", "MikronBaseBackground.jpg");
        public static Image GradientBackground => MakeDefaultImageStretch("GradientBackgroundImage", "MikronGradientBackground.svg");

        public static Image StationIcon10Error = MakeDefaultImage("StationIcon10Error", "Red10.svg");
        public static Image StationIcon6Error = MakeDefaultImage("StationIcon6Error", "Red6.svg");
        public static Image StationIcon7Warning = MakeDefaultImage("StationIcon7EWarning", "Orange7.svg");

        public static Image ReadyIcon = MakeDefaultImage("ReadyIcon", "ready.svg");
        public static Image ErrorIcon = MakeDefaultImage("ErrorIcon", "Error.svg");
        public static Image WarningIcon = MakeDefaultImage("WarningIcon", "warning.svg");

        #endregion

        #region Icon Image paths

        public static string ReadyIconPath = GetRelativeImagePath("ready.svg");
        public static string ErrorIconPath = GetRelativeImagePath("Error.svg");
        public static string WarningIconPath = GetRelativeImagePath("warning.svg");
        public static string GoodPalletStatusIconPath = GetRelativeImagePath("BoxesWithCheck.svg");
        public static string BadPalletStatusIconPath = GetRelativeImagePath("BoxesWithX.svg");
        public static string BadPalletStatusTrashIconPath = GetRelativeImagePath("BoxesWithTrash.svg");

        public static string StationIcon10ErrorPath = GetRelativeImagePath("Red10.svg");
        public static string StationIcon6ErrorPath = GetRelativeImagePath("Red6.svg");
        public static string StationIcon7WarningPath = GetRelativeImagePath("Orange7.svg");

        public static string HomeIconPath = GetRelativeImagePath("home.svg");
        public static string StationIconPath = GetRelativeImagePath("station.svg");
        public static string PlaceholderIconPath = GetRelativeImagePath("placeholder.svg");
        public static string PowerIconPath = GetRelativeImagePath("power.svg");
        public static string ExpandIconPath = GetRelativeImagePath("Expand.svg");
        public static string SettingsIconPath = GetRelativeImagePath("gear-fill.svg");
        public static string CloseIconPath = GetRelativeImagePath("WhiteX.svg");
        public static string ClockIconPath = GetRelativeImagePath("Clock.svg");
        public static string LeftCaretIconPath = GetRelativeImagePath("LeftCaret.svg");
        public static string RightCaretIconPath = GetRelativeImagePath("RightCaret.svg");
        public static string PlusIconPath = GetRelativeImagePath("Plus.svg");
        public static string PlusCircleIconPath = GetRelativeImagePath("PlusCircle.svg");

        public static string StatusIconPath = GetRelativeImagePath("GearsWithStatus2.svg");
        public static string UserIconPath = GetRelativeImagePath("User.svg");
        public static string CamAngleIconPath = GetRelativeImagePath("CamAngle.svg");

        public static string EditIconPath = GetRelativeImagePath("edit.svg");

        #endregion
    }
}