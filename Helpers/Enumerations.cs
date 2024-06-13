namespace Mikron_MOAB_HMI.Helpers
{
    public static class Enumerations
    {
        //Why can I access this without having the static declaration?
        public enum StatusTypeEnum
        {
            Ready,
            Warning,
            Error
        }

        public enum AlarmMessageType
        {
            Short,
            Medium,
            Long
        }

        public enum HomeNavigationEnum
        {
            Line,
            Cell,
            Module
        }

        public enum CustomWidgetSelectionEnum
        {
            PerformanceOverview,
            PlaceholderWidget
        }

        public enum NavigationEnum
        {
            Home,
            Station,
            None
        }

        public enum StationNavigationEnum
        {
            Summary,
        }

        public enum PalletStatusEnum
        {
            Good,
            Bad
        }

        public enum StationNumberEnum
        {
            Station1,
            Station2,
            Station3,
            Station4,
            Station5,
            Station6,
            Station7,
            Station8,
            Station9,
            Station10,
            Station11,
            Station12,
            Station13,
            Station14,
            Station15,
            Station16,
            Station17,
            Station18,
            Station19,
            Station20
        }

        public enum ModelFolders
        {
            Objects, Variables, ObjectsHomeObjectInstances, ObjectsHome, ObjectsStationObjectInstances, ObjectsStation, ObjectsAlarmObjectInstances, ObjectsAlarm, ObjectsNavigationObjectInstances, ObjectsNavigation, ObjectsLocalPageNavigationObjectInstances, ObjectsLocalPageNavigation, ObjectsSecondaryLocalPageNavigationObjectInstances, ObjectsSecondaryLocalPageNavigation, ObjectsHeaderObjectInstances, ObjectsHeader, ObjectsDeviceObjectsObjectInstances, ObjectsDeviceObjects, VariablesNavigation, ObjectsHomePerformanceObjectInstances, ObjectsHomePerformance
        }

        public enum UIFolders
        {
            MainWindow, Layout, Page, VisionViewer, DigitalServices, Devices, LayoutTemplates, LayoutNavigation, PageTemplates, PageHome, PageStation, PageFlyouts, LayoutTemplatesGenericTemplateInstances, LayoutTemplatesGeneric, LayoutTemplatesHomeTemplateInstances, LayoutTemplatesHome, LayoutTemplatesStationTemplateInstances, LayoutTemplatesStation, LayoutTemplatesGenericAlarmTemplateInstances, LayoutTemplatesGenericAlarm, PageHomeLine, PageHomeCell, PageHomeModule, PageStationOverviewTemplateInstances, PageStationOverview, PageStationCamsTemplateInstances, PageStationCams, PageStationManualTemplateInstances, PageStationManual, PageStationConfigurationTemplateInstances, PageStationConfiguration, PageStationDataTemplateInstances, PageStationData
        }

        public enum TopBottomLayout
        {
            TopSection, BottomSection
        }

        public enum LeftRightLayout
        {
            LeftSection, RightSection
        }

        public enum NodeName
        {
            StationDataPanelType, StationSetupPanelType, StationCamsPanelType, HomeLocalPageNavigation, StationLocalPageNavigation, Page, AlarmItemRow, FlyoutButton, ItemIterator, LocalNavigationTab, NavigationButton, PerformanceItem, StationRowItem, UserInfoFlyoutPanelType, BatchInfoFlyoutPanelType, EmptyFlyoutPanelType, LineSVGPanel, CellSVGPanel, ModuleSVGPanel, SidebarPanelType, AlarmListPanelType, HeaderPanelType, AllStationsSummaryPanelType, StationManualPanelType, StationSelectedItemIterator
        }

        public enum VariableName
        {
            ActivePage
        }
    }
}