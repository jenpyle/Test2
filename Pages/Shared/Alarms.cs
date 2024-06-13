using FTOptix.UI;
using Mikron_MOAB_HMI.Templates;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.Layouts;

namespace Mikron_MOAB_HMI.Pages.Shared
{
    public class Alarms
    {
        private ReusableTypes reusableTypes;

        public Alarms()
        {
            reusableTypes = new ReusableTypes();
        }

        public PanelType GenerateDashboardAlarmList()
        {
            ColumnLayout alarmList = CreateAlarmItemList("AlarmList");
            PanelType dashboardAlarms = CreatePanelWithFlyoutButtonLayoutType("AlarmListPanelType", ExpandIconPath, alarmList);

            return dashboardAlarms;
        }

        private ColumnLayout CreateAlarmItemList(string browseName)
        {
            ColumnLayout alarmList = MakeDefaultVerticalLayout(browseName);
            Panel alarm1 = GenerateAlarmItemRow("Short", StationNumberEnum.Station10, StatusTypeEnum.Error, AlarmMessageType.Short);
            Panel alarm2 = GenerateAlarmItemRow("Medium", StationNumberEnum.Station6, StatusTypeEnum.Error, AlarmMessageType.Medium);
            Panel alarm3 = GenerateAlarmItemRow("Long", StationNumberEnum.Station7, StatusTypeEnum.Warning, AlarmMessageType.Long);

            alarmList.Add(alarm1);
            alarmList.Add(alarm2);
            alarmList.Add(alarm3);

            return alarmList;
        }

        private Panel GenerateAlarmItemRow(string instanceID, StationNumberEnum stationNumber, StatusTypeEnum alarmKind, AlarmMessageType alarmMessageType)
        {
            return reusableTypes.MakeAlarmItemRowTemplateInstance(instanceID, stationNumber, alarmKind, alarmMessageType);
        }
    }
}