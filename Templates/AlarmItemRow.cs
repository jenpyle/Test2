using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.Placeholders;
using OpcUa = UAManagedCore.OpcUa;

namespace Mikron_MOAB_HMI.Templates
{
    public class AlarmItemRow : TemplateTypeBaseClass
    {
        private string stationNumberIconElementName;
        private string alarmKindIconElementName;
        private string alarmMessageElementName;

        private string stationNumberIconPathVariableName;
        private string alarmKindIconPathVariableName;
        private string alarmMessageLabelVariableName;

        public AlarmItemRow()
        {
            SetNames("AlarmItemRow", UIFolders.LayoutTemplatesGenericAlarm, ModelFolders.ObjectsAlarm);
            stationNumberIconElementName = "StationNumberIcon";
            alarmKindIconElementName = "AlarmKindIcon";
            alarmMessageElementName = "AlarmMessage";

            stationNumberIconPathVariableName = CreateVariableNameString(stationNumberIconElementName, "Path");
            alarmKindIconPathVariableName = CreateVariableNameString(alarmKindIconElementName, "Path");
            alarmMessageLabelVariableName = CreateVariableNameString(alarmMessageElementName, "Text");
        }

        public void CreateAndStoreType()
        {
            SetPropertiesFromBase();
            CreateAlarmObjectType();
            CreateAlarmTemplateType();
        }

        public void CreateAlarmObjectType()
        {
            IUAVariable stationNumberIcon = InformationModel.MakeVariable(stationNumberIconPathVariableName, FTOptix.Core.DataTypes.ResourceUri);
            IUAVariable alarmKindIcon = InformationModel.MakeVariable(alarmKindIconPathVariableName, FTOptix.Core.DataTypes.ResourceUri);
            IUAVariable alarmMessage = InformationModel.MakeVariable(alarmMessageLabelVariableName, OpcUa.DataTypes.String);

            ObjectType.Add(stationNumberIcon);
            ObjectType.Add(alarmKindIcon);
            ObjectType.Add(alarmMessage);
        }

        public void CreateAlarmTemplateType()
        {
            TemplateType.Height = SmallSize;
            RowLayout alarmHorizontalLayout = MakeDefaultHorizontalLayout("AlarmHorizontalLayout");
            Image stationNumberIcon = MakeDefaultImage(stationNumberIconElementName);
            SetPropertyDynamicLink(stationNumberIcon.PathVariable, stationNumberIconPathVariableName);

            Image alarmKindIcon = MakeDefaultImage(alarmKindIconElementName);
            SetPropertyDynamicLink(alarmKindIcon.PathVariable, alarmKindIconPathVariableName);

            Label alarmMessageLabel = MakeDefaultLabel(alarmMessageElementName);
            SetPropertyDynamicLink(alarmMessageLabel.TextVariable, alarmMessageLabelVariableName);

            stationNumberIcon.HorizontalAlignment = HorizontalAlignment.Left;
            alarmKindIcon.HorizontalAlignment = HorizontalAlignment.Left;
            alarmHorizontalLayout.Add(stationNumberIcon);
            alarmHorizontalLayout.Add(alarmKindIcon);
            alarmHorizontalLayout.Add(alarmMessageLabel);

            TemplateType.Add(alarmHorizontalLayout);
        }

        public IUAObject MakeAlarmObjectInstance(string instanceID, StationNumberEnum stationNumber, StatusTypeEnum alarmKind, AlarmMessageType alarmMessageType)
        {
            IUAObject objectInstance = CreateObjectInstance(instanceID);
            objectInstance.FindVariable(stationNumberIconPathVariableName).Value = GetStationNumberIconPath(stationNumber);
            objectInstance.FindVariable(alarmKindIconPathVariableName).Value = GetAlarmKindIconPath(alarmKind);
            objectInstance.FindVariable(alarmMessageLabelVariableName).Value = GetAlarmMessage(alarmMessageType);
            return objectInstance;
        }

        private string GetAlarmKindIconPath(StatusTypeEnum alarmKind)
        {
            switch (alarmKind)
            {
                case StatusTypeEnum.Ready:
                    return ReadyIconPath;

                case StatusTypeEnum.Warning:
                    return WarningIconPath;

                case StatusTypeEnum.Error:
                    return ErrorIconPath;

                default:
                    return PlaceholderIconPath;
            }
        }

        private string GetAlarmMessage(AlarmMessageType alarmMessageType)
        {
            switch (alarmMessageType)
            {
                case AlarmMessageType.Short:
                    return AlarmMessageShort;

                case AlarmMessageType.Medium:
                    return AlarmMessageMedium;

                case AlarmMessageType.Long:
                    return AlarmMessageLong;

                default:
                    return PlaceholderText;
            }
        }

        private string GetStationNumberIconPath(StationNumberEnum stationNumber)
        {
            switch (stationNumber)
            {
                case StationNumberEnum.Station1:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station2:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station3:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station4:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station5:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station6:
                    return StationIcon6ErrorPath;

                case StationNumberEnum.Station7:
                    return StationIcon7WarningPath;

                case StationNumberEnum.Station8:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station9:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station10:
                    return StationIcon10ErrorPath;

                case StationNumberEnum.Station11:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station12:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station13:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station14:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station15:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station16:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station17:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station18:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station19:
                    return PlaceholderIconPath;

                case StationNumberEnum.Station20:
                    return PlaceholderIconPath;

                default:
                    return PlaceholderIconPath;
            }
        }
    }
}