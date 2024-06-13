using FTOptix.UI;
using Mikron_MOAB_HMI.Pages.Shared;
using Mikron_MOAB_HMI.Templates;
using System;
using System.Collections.Generic;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiColors;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.Layouts;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Pages.Station
{
    public class StationView
    {
        private ReusableTypes reusableTypes;

        public PanelType StationLocalPageNavigation;
        public PanelType SecondarylocalPageNavigation;

        public PanelType AllStationsSummaryPanelType;
        public PanelType StationsManualSecondaryNavPanelType;

        public PanelType StationPageHeaderPanelType;
        public LocalPageNavigation LocalPageNavigation;

        public StationView()
        {
            reusableTypes = new ReusableTypes();
        }

        //Could I make a list of these methods and call the add unit of work?
        public void CreateStationPanelTypes()
        {
            CreateStationPlaceholderPanelTypes();
            CreateAllStationsSummaryPanelType();
            CreateStationSelectedItemPanelType();
            CreateManualDevicePanelType();
            CreateStationLocalNavigationPanelType();
        }

        public void SetStationPage_1_Summary()
        {
            SetStationPageDashboard_2();
            SetStationPageMainContent_3();
            AllStationsSummary_4();
        }

        public void SetStationPage_1_Manual()
        {
            SetStationPageDashboard_2();
            SetStationPageMainContent_3();
            StationManual_4();
        }

        public PanelType CreateManualDevicePanelType()
        {
            PanelType stationManualPanelType = MakeDefaultPanelType("StationManualPanelType");
            ColumnLayout verticalLayout = MakeDefaultVerticalLayout();
            verticalLayout.VerticalGap = DefaultVerticalLayoutGap;
            RowLayout firstRow = MakeDefaultHorizontalLayout("FirstRow");
            firstRow.HorizontalGap = DefaultHorizontalLayoutGap;
            RowLayout secondRow = MakeDefaultHorizontalLayout("SecondRow");
            secondRow.HorizontalGap = DefaultHorizontalLayoutGap;
            RowLayout thirdRow = MakeDefaultHorizontalLayout("ThirdRow");
            thirdRow.HorizontalGap = DefaultHorizontalLayoutGap;

            for (int i = 1; i < 4; i++)
            {
                Rectangle background = MakeDefaultSecondaryBackground("DeviceBackground" + i.ToString());
                Image device = MakeDefaultImage("DeviceImage" + i.ToString(), "Device.png");

                device.LeftMargin = SmallSize;
                device.RightMargin = SmallSize;
                background.Add(device);
                firstRow.Add(background);
            }
            for (int i = 1; i < 4; i++)
            {
                Rectangle background = MakeDefaultSecondaryBackground("DeviceBackground" + i.ToString());
                Image device = MakeDefaultImage("DeviceImage" + i.ToString(), "Device.png");
                device.LeftMargin = SmallSize;
                device.RightMargin = SmallSize;
                background.Add(device);
                secondRow.Add(background);
            }
            for (int i = 1; i < 4; i++)
            {
                Rectangle background = MakeDefaultSecondaryBackground("DeviceBackground" + i.ToString());
                Image device = MakeDefaultImage("DeviceImage" + i.ToString(), "Device.png");
                device.LeftMargin = SmallSize;
                device.RightMargin = SmallSize;
                background.Add(device);
                thirdRow.Add(background);
            }

            verticalLayout.Add(firstRow);
            verticalLayout.Add(secondRow);
            verticalLayout.Add(thirdRow);
            stationManualPanelType.Add(verticalLayout);
            AddNodeToProject(UIFolders.PageStation, stationManualPanelType);
            return stationManualPanelType;
        }

        public void CreateAllStationsSummaryPanelType()
        {
            AllStationsSummaryPanelType = MakeDefaultPanelType("AllStationsSummaryPanelType");
            ColumnLayout stationChartVerticalLayout = MakeDefaultVerticalLayout("StationChartVerticalLayout");
            RowLayout stationSummaryChartHeaderRow = CreateStationsSummaryChartHeader();
            ColumnLayout stationsChart = CreateStationRowsChart(stationSummaryChartHeaderRow);

            stationChartVerticalLayout.Add(stationsChart);
            AllStationsSummaryPanelType.Add(stationChartVerticalLayout);

            AddNodeToProject(UIFolders.LayoutTemplatesGeneric, AllStationsSummaryPanelType);
        }

        public void CreateStationPlaceholderPanelTypes()
        {
            PanelType stationCamsPanelType = MakeDefaultPanelTypeColor("StationCamsPanelType", TempColor1, 50);
            Label camsLabel = MakeDefaultLabel("CamsLabel", "Station Cams");
            camsLabel.TextColor = Black;
            camsLabel.Height = 200;
            camsLabel.FontSize = 100;
            camsLabel.HorizontalAlignment = HorizontalAlignment.Center;
            stationCamsPanelType.Add(camsLabel);
            AddNodeToProject(UIFolders.PageStation, stationCamsPanelType);

            PanelType stationSetupPanelType = MakeDefaultPanelTypeColor("StationSetupPanelType", TempColor3, 50);
            Label setupLabel = MakeDefaultLabel("SetupLabel", "Station Setup");
            stationSetupPanelType.Add(setupLabel);
            setupLabel.TextColor = Black;
            setupLabel.Height = 200;
            setupLabel.HorizontalAlignment = HorizontalAlignment.Center;
            setupLabel.FontSize = 100;
            AddNodeToProject(UIFolders.PageStation, stationSetupPanelType);

            PanelType stationDataPanelType = MakeDefaultPanelTypeColor("StationDataPanelType", TempColor2, 50);
            Label dataLabel = MakeDefaultLabel("DataLabel", "Station Data");
            stationDataPanelType.Add(dataLabel);
            dataLabel.TextColor = Black;
            dataLabel.Height = 200;
            dataLabel.FontSize = 100;
            dataLabel.HorizontalAlignment = HorizontalAlignment.Center;

            AddNodeToProject(UIFolders.PageStation, stationDataPanelType);
        }

        public PanelType CreateStationSelectedItemPanelType()
        {
            Panel stationIterator = reusableTypes.MakeItemIteratorTemplateInstance("Station", CreateSelectedItemPanelType().NodeId);
            PanelType stationSelectedItemIterator = CreatePageHeaderWithIteratorLayoutType("StationSelectedItemIterator", StationIconPath, stationIterator);
            AddNodeToProject(UIFolders.PageStation, stationSelectedItemIterator);

            return stationSelectedItemIterator;
        }

        public void CreateStationLocalNavigationPanelType()
        {
            LocalPageNavigation = new LocalPageNavigation();

            List<ChangePanelButton> stationLocalPageNavigationItems = new List<ChangePanelButton>();
            ChangePanelButton allStationSummaryTab = new ChangePanelButton("Summary", NodeLookup(NodeName.AllStationsSummaryPanelType).NodeId);
            ChangePanelButton stationManualTab = new ChangePanelButton("Manual", NodeLookup(NodeName.StationManualPanelType).NodeId);
            ChangePanelButton placeholder1 = new ChangePanelButton("Cams", NodeLookup(NodeName.StationCamsPanelType).NodeId);
            ChangePanelButton placeholder2 = new ChangePanelButton("Setup", NodeLookup(NodeName.StationSetupPanelType).NodeId);
            ChangePanelButton placeholder3 = new ChangePanelButton("Data", NodeLookup(NodeName.StationDataPanelType).NodeId);

            stationLocalPageNavigationItems.Add(allStationSummaryTab);
            stationLocalPageNavigationItems.Add(stationManualTab);
            stationLocalPageNavigationItems.Add(placeholder1);
            stationLocalPageNavigationItems.Add(placeholder2);
            stationLocalPageNavigationItems.Add(placeholder3);
            StationLocalPageNavigation = LocalPageNavigation.GenerateLocalPageNavigation("StationLocalPageNavigation", stationLocalPageNavigationItems, NodeLookup(NodeName.AllStationsSummaryPanelType).NodeId);
            //AddNodeToDictionary(UIFolders.PageStation, StationLocalPageNavigation);
        }

        private void SetStationPageDashboard_2()
        {
            // PanelType stationPageLeftDashboard = CreateStationSelectedItemPanelType();
            PanelLoader leftDashboardPanelLoader = GetLeftDashboardPanelLoader(true);
            leftDashboardPanelLoader.Panel = NodeLookup(NodeName.StationSelectedItemIterator).NodeId;
        }

        private void SetStationPageMainContent_3()
        {
            SetMainContentPanelLoaderPanel(NodeLookup(NodeName.StationLocalPageNavigation).NodeId);
        }

        private void AllStationsSummary_4()
        {
            //CreateAllStationsSummaryPanelType();
            SetStationMainContentPanelLoader(NodeLookup(NodeName.AllStationsSummaryPanelType).NodeId);
        }

        private void StationManual_4()
        {
            CreateStationManualSecondaryLocalNavigation();
            SetStationMainContentPanelLoader(SecondarylocalPageNavigation.NodeId);

            PanelLoader secondaryNavigationPanelLoader = SecondarylocalPageNavigation.Find<PanelLoader>("LocalContentPanelLoader");

            secondaryNavigationPanelLoader.Panel = CreateManualDevicePanelType().NodeId;
        }

        private void StationCams_4()
        {
            throw new NotImplementedException();
        }

        private void CreateStationManualSecondaryLocalNavigation()
        {
            string[] stationManualTabOptions = new string[] { "Main", "InnerPnP", "IntTest", "OuterPnP", "Scanner", "Data" };
            //SecondarylocalPageNavigation = LocalPageNavigation.GenerateLocalPageNavigation("StationSecondarylocalPageNavigation", stationManualTabOptions);
        }

        public RowLayout CreateStationsSummaryChartHeader()
        {
            RowLayout headerHorizontalLayout = MakeDefaultHorizontalLayout("StationSummaryChartHeaderRow");

            Label stationColumnHeader = MakeDefaultLabel("StationColumnHeader", "Station");
            Rectangle outlineStationColumnHeader = CreateElementWithWhiteRectangleOutline("OutlineStationColumnHeader", stationColumnHeader);

            Label nameColumnHeader = MakeDefaultLabel("NameColumnHeader", "Name");
            Rectangle outlineNameColumnHeader = CreateElementWithWhiteRectangleOutline("OutlineNameColumnHeader", nameColumnHeader);

            Label palletStatusColumnHeader = MakeDefaultLabel("PalletStatusColumnHeader", "Pallet/Status");
            Rectangle outlinePalletStatusColumnHeader = CreateElementWithWhiteRectangleOutline("OutlinePalletStatusColumnHeader", palletStatusColumnHeader);

            Image numberNumberAlertsColumnHeader = MakeDefaultImage("NumberAlertsColumnHeader", ErrorIconPath);
            Rectangle outlineNumberAlertsColumnHeader = CreateElementWithWhiteRectangleOutline("OutlineNumberAlertsColumnHeader", numberNumberAlertsColumnHeader);

            Image timeDownColumnHeader = MakeDefaultImage("TimeDownColumnHeader", ClockIconPath);
            Rectangle outlineTimeDownColumnHeader = CreateElementWithWhiteRectangleOutline("OutlineTimeDownColumnHeader", timeDownColumnHeader);

            Image badPartsIcon = MakeDefaultImage("BadPartsTrashIcon", BadPalletStatusTrashIconPath);
            Rectangle outlineSumBadPartsColumnHeader = CreateElementWithWhiteRectangleOutline("OutlineSumBadPartsColumnHeader", badPartsIcon);

            headerHorizontalLayout.Add(outlineStationColumnHeader);
            headerHorizontalLayout.Add(outlineNameColumnHeader);
            headerHorizontalLayout.Add(outlinePalletStatusColumnHeader);
            headerHorizontalLayout.Add(outlineNumberAlertsColumnHeader);
            headerHorizontalLayout.Add(outlineTimeDownColumnHeader);
            headerHorizontalLayout.Add(outlineSumBadPartsColumnHeader);
            return headerHorizontalLayout;
        }

        public ColumnLayout CreateStationRowsChart(RowLayout headerRow)
        {
            ColumnLayout verticalLayout = MakeDefaultVerticalLayout("StationRowsVerticalLayout");
            verticalLayout.Add(headerRow);
            verticalLayout.Add(GenerateStationRow("1", "1", StatusTypeEnum.Ready, "TestName", "4", PalletStatusEnum.Good, "6", "3", "0"));
            verticalLayout.Add(GenerateStationRow("2", "2", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("3", "3", StatusTypeEnum.Warning, "TestName", RandomNumString(), PalletStatusEnum.Bad, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("4", "4", StatusTypeEnum.Warning, "TestName", RandomNumString(), PalletStatusEnum.Bad, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("5", "5", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("6", "6", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("7", "7", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("8", "8", StatusTypeEnum.Error, "TestName", RandomNumString(), PalletStatusEnum.Bad, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("9", "9", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("10", "10", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("11", "11", StatusTypeEnum.Warning, "TestName", RandomNumString(), PalletStatusEnum.Bad, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("12", "12", StatusTypeEnum.Error, "TestName", RandomNumString(), PalletStatusEnum.Bad, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("13", "13", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("14", "14", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("15", "15", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("16", "16", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("17", "17", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            verticalLayout.Add(GenerateStationRow("18", "18", StatusTypeEnum.Ready, "TestName", RandomNumString(), PalletStatusEnum.Good, RandomNumString(), RandomNumString(), RandomNumString()));
            return verticalLayout;
        }

        public Panel GenerateStationRow(string instanceID, string stationNumber, StatusTypeEnum statusKind, string stationName,
            string palletNumber, PalletStatusEnum palletStatus, string numberAlerts, string timeDown, string badParts)
        {
            return reusableTypes.MakeStationRowTemplateInstance(instanceID, stationNumber, statusKind, stationName, palletNumber, palletStatus, numberAlerts, timeDown, badParts);
        }

        //TODO move this
        public PanelType CreateSelectedItemPanelType()
        {
            PanelType selectedStationPanelType = MakeDefaultPanelType("SelectedStationPanelType");
            RowLayout selectedStationHorizontalLayout = MakeDefaultHorizontalLayout("SelectedStationHorizontalLayout");
            Image stationNumberIcon = MakeDefaultImage("SelectedStation", StationIcon10ErrorPath);
            Image stationStatus = MakeDefaultImage("StationStatus", ErrorIconPath);

            selectedStationHorizontalLayout.Add(stationNumberIcon);
            selectedStationHorizontalLayout.Add(stationStatus);
            selectedStationPanelType.Add(selectedStationHorizontalLayout);
            AddNodeToProject(UIFolders.PageStation, selectedStationPanelType);
            return selectedStationPanelType;
        }

        public void SetStationMainContentPanelLoader(NodeId contentNodeId)
        {
            PanelLoader stationLocalPageNavigationPanelLoader = StationLocalPageNavigation.Find<PanelLoader>("LocalContentPanelLoader");
            stationLocalPageNavigationPanelLoader.Panel = contentNodeId;
        }
    }
}