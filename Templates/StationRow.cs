using FTOptix.HMIProject;
using FTOptix.UI;
using System.Collections.Generic;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.Layouts;
using OpcUa = UAManagedCore.OpcUa;

namespace Mikron_MOAB_HMI.Templates
{
    public class StationRow : TemplateTypeBaseClass
    {
        private string stationNumberLabelElementName;
        private string stationStatusIconElementName;
        private string stationNameLabelElementName;
        private string palletNumberLabelElementName;
        private string palletStatusIconElementName;
        private string numberAlertsLabelElementName;
        private string timeDownLabelElementName;
        private string badPartsSumLabelElementName;

        private string stationNumberLabelVariableName;
        private string stationStatusIconVariableName;
        private string stationNameLabelVariableName;
        private string palletNumberLabelVariableName;
        private string palletStatusIconVariableName;
        private string numberAlertsLabelVariableName;
        private string timeDownLabelVariableName;
        private string badPartsSumLabelVariableName;

        public StationRow()
        {
            SetNames("StationRowItem", UIFolders.LayoutTemplatesStation, ModelFolders.ObjectsStation);

            stationNumberLabelElementName = "StationNumberLabel";
            stationStatusIconElementName = "StationStatusIcon";
            stationNameLabelElementName = "StationNameLabel";
            palletNumberLabelElementName = "StationPalletLabel";
            palletStatusIconElementName = "PalletStatusIcon";
            numberAlertsLabelElementName = "NumberAlertsLabel";
            timeDownLabelElementName = "TimeDownLabel";
            badPartsSumLabelElementName = "BadPartsSumLabel";

            stationNumberLabelVariableName = CreateVariableNameString(stationNumberLabelElementName, "Text");
            stationStatusIconVariableName = CreateVariableNameString(stationStatusIconElementName, "Path");
            stationNameLabelVariableName = CreateVariableNameString(stationNameLabelElementName, "Text");
            palletNumberLabelVariableName = CreateVariableNameString(palletNumberLabelElementName, "Text");
            palletStatusIconVariableName = CreateVariableNameString(palletStatusIconElementName, "Path");
            numberAlertsLabelVariableName = CreateVariableNameString(numberAlertsLabelElementName, "Text");
            timeDownLabelVariableName = CreateVariableNameString(timeDownLabelElementName, "Text");
            badPartsSumLabelVariableName = CreateVariableNameString(badPartsSumLabelElementName, "Text");
        }

        public void CreateAndStoreType()
        {
            SetPropertiesFromBase();
            CreateStationRowObjectType();
            CreateStationRowTemplateType();
        }

        public void CreateStationRowObjectType()
        {
            IUAVariable stationNumber = InformationModel.MakeVariable(stationNumberLabelVariableName, OpcUa.DataTypes.String);
            IUAVariable statusIcon = InformationModel.MakeVariable(stationStatusIconVariableName, FTOptix.Core.DataTypes.ResourceUri);
            IUAVariable stationName = InformationModel.MakeVariable(stationNameLabelVariableName, OpcUa.DataTypes.String);
            IUAVariable palletNumber = InformationModel.MakeVariable(palletNumberLabelVariableName, OpcUa.DataTypes.String);
            IUAVariable palletStatus = InformationModel.MakeVariable(palletStatusIconVariableName, FTOptix.Core.DataTypes.ResourceUri);
            IUAVariable numberAlerts = InformationModel.MakeVariable(numberAlertsLabelVariableName, OpcUa.DataTypes.String);
            IUAVariable timeDown = InformationModel.MakeVariable(timeDownLabelVariableName, OpcUa.DataTypes.String);
            IUAVariable badParts = InformationModel.MakeVariable(badPartsSumLabelVariableName, OpcUa.DataTypes.String);

            ObjectType.Add(stationNumber);
            ObjectType.Add(statusIcon);
            ObjectType.Add(stationName);
            ObjectType.Add(palletNumber);
            ObjectType.Add(palletStatus);
            ObjectType.Add(numberAlerts);
            ObjectType.Add(timeDown);
            ObjectType.Add(badParts);
        }

        public void CreateStationRowTemplateType()
        {
            TemplateType.Height = SmallSize;

            RowLayout stationRowHorizontalLayout = MakeDefaultHorizontalLayout("StationRowHorizontalLayout");

            Label stationNumberLabel = MakeDefaultLabel(stationNumberLabelElementName);
            SetPropertyDynamicLink(stationNumberLabel.TextVariable, stationNumberLabelVariableName);
            Image statusIcon = MakeDefaultImage(stationStatusIconElementName);
            SetPropertyDynamicLink(statusIcon.PathVariable, stationStatusIconVariableName);
            List<Item> stationNumberAndStatus = new List<Item> { stationNumberLabel, statusIcon };
            Rectangle outlineStationNumber = CreateWhiteOutlinedRectangleFromMultipleElementsHorizontal("OutlinedStationNumberAndStatus", stationNumberAndStatus);

            Label stationName = MakeDefaultLabel(stationNameLabelElementName);
            SetPropertyDynamicLink(stationName.TextVariable, stationNameLabelVariableName);
            Rectangle outlineStationName = CreateElementWithWhiteRectangleOutline("OutlinedStationName", stationName);

            Label palletNumber = MakeDefaultLabel(palletNumberLabelElementName);
            SetPropertyDynamicLink(palletNumber.TextVariable, palletNumberLabelVariableName);
            Image palletStatus = MakeDefaultImage(palletStatusIconElementName);
            SetPropertyDynamicLink(palletStatus.PathVariable, palletStatusIconVariableName);
            List<Item> palletNumberAndStatus = new List<Item> { palletNumber, palletStatus };
            Rectangle outlinePalletNumber = CreateWhiteOutlinedRectangleFromMultipleElementsHorizontal("OutlinedPalletNumberAndStatus", palletNumberAndStatus);

            Label numberAlerts = MakeDefaultLabel(numberAlertsLabelElementName);
            SetPropertyDynamicLink(numberAlerts.TextVariable, numberAlertsLabelVariableName);
            Rectangle outlineNumberAlerts = CreateElementWithWhiteRectangleOutline("OutlinedNumberAlerts", numberAlerts);

            Label timeDown = MakeDefaultLabel(timeDownLabelElementName);
            SetPropertyDynamicLink(timeDown.TextVariable, timeDownLabelVariableName);
            Rectangle outlineTimeDown = CreateElementWithWhiteRectangleOutline("OutlinedTimeDown", timeDown);

            Label badParts = MakeDefaultLabel(badPartsSumLabelElementName);
            SetPropertyDynamicLink(badParts.TextVariable, badPartsSumLabelVariableName);
            Rectangle outlineBadParts = CreateElementWithWhiteRectangleOutline("OutlinedBadParts", badParts);

            stationRowHorizontalLayout.Add(outlineStationNumber);
            stationRowHorizontalLayout.Add(outlineStationName);
            stationRowHorizontalLayout.Add(outlinePalletNumber);
            stationRowHorizontalLayout.Add(outlineNumberAlerts);
            stationRowHorizontalLayout.Add(outlineTimeDown);
            stationRowHorizontalLayout.Add(outlineBadParts);
            TemplateType.Add(stationRowHorizontalLayout);
        }

        public IUAObject MakeStationRowObjectInstance(string instanceID, string stationNumber, StatusTypeEnum statusKind, string stationName,
            string palletNumber, PalletStatusEnum palletStatus, string numberAlerts, string timeDown, string badParts)
        {
            IUAObject objectInstance = CreateObjectInstance(instanceID);
            objectInstance.FindVariable(stationNumberLabelVariableName).Value = stationNumber;
            objectInstance.FindVariable(stationStatusIconVariableName).Value = GetStatusKindIconPath(statusKind);
            objectInstance.FindVariable(stationNameLabelVariableName).Value = stationName;
            objectInstance.FindVariable(palletNumberLabelVariableName).Value = palletNumber;
            objectInstance.FindVariable(palletStatusIconVariableName).Value = GetPalletStatusIconPath(palletStatus);
            objectInstance.FindVariable(numberAlertsLabelVariableName).Value = numberAlerts;
            objectInstance.FindVariable(timeDownLabelVariableName).Value = timeDown;
            objectInstance.FindVariable(badPartsSumLabelVariableName).Value = badParts;

            return objectInstance;
        }

        //TODO move this to base class
        private string GetStatusKindIconPath(StatusTypeEnum statusKind)
        {
            switch (statusKind)
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

        private string GetPalletStatusIconPath(PalletStatusEnum palletStatus)
        {
            switch (palletStatus)
            {
                case PalletStatusEnum.Good:
                    return GoodPalletStatusIconPath;

                case PalletStatusEnum.Bad:
                    return BadPalletStatusIconPath;

                default:
                    return PlaceholderIconPath;
            }
        }
    }
}