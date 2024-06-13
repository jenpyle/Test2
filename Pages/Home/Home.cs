using FTOptix.UI;
using Mikron_MOAB_HMI.Pages.Shared;
using System.Collections.Generic;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Pages.Home
{
    public class Home
    {
        public PanelType LinePanelType;
        public PanelType CellPanelType;
        public PanelType ModulePanelType;
        private LocalPageNavigation localPageNavigation;
        public PanelType HomeLocalPageNavigation;

        public Home()
        {
        }

        public void CreateHomePanelTypes()
        {
            //loads dashboard panels and main content panel
            CreateLineSVGPanelType();
            CreateCellSVGPanelType();
            CreateModuleSVGPanelType();
        }

        public void SetHomePage_1_Cell()
        {
            //CreateHomePanelTypes();

            SetHomePageDashboard_2();
            SetHomePageMainContent_2();
        }

        private void SetHomePageDashboard_2()
        {
            WidgetOptions widgetOptions = new WidgetOptions();
            PanelType homePageLeftDashboard = widgetOptions.GenerateWidgetSelector();

            PanelLoader leftDashboardPanelLoader = GetLeftDashboardPanelLoader();
            leftDashboardPanelLoader.Panel = homePageLeftDashboard.NodeId;
            //don't forget to set the right dashboard(maybe? or somewhere else?)
        }

        private void SetHomePageMainContent_2()
        {
            localPageNavigation = new LocalPageNavigation();

            List<ChangePanelButton> homeLocalPageNavigationItems = new List<ChangePanelButton>();
            ChangePanelButton lineTab = new ChangePanelButton("Line", NodeLookup(NodeName.LineSVGPanel).NodeId);
            ChangePanelButton cellTab = new ChangePanelButton("Cell", NodeLookup(NodeName.CellSVGPanel).NodeId);
            ChangePanelButton moduleTab = new ChangePanelButton("Module", NodeLookup(NodeName.ModuleSVGPanel).NodeId);
            homeLocalPageNavigationItems.Add(lineTab);
            homeLocalPageNavigationItems.Add(cellTab);
            homeLocalPageNavigationItems.Add(moduleTab);
            HomeLocalPageNavigation = localPageNavigation.GenerateLocalPageNavigation("HomeLocalPageNavigation", homeLocalPageNavigationItems, NodeLookup(NodeName.CellSVGPanel).NodeId);
            SetMainContentPanelLoaderPanel(NodeLookup(NodeName.HomeLocalPageNavigation).NodeId);
        }

        public PanelType CreateLineSVGPanelType()
        {
            LinePanelType = MakeDefaultPanelType("LineSVGPanel");
            Image lineSvg = MakeDefaultImage("LineSVG", "LineView.svg");
            lineSvg.LeftMargin = MediumMargin;
            lineSvg.RightMargin = MediumMargin;

            LinePanelType.Add(lineSvg);
            AddNodeToProject(UIFolders.PageHomeLine, LinePanelType);
            return LinePanelType;
        }

        public void CreateCellSVGPanelType()
        {
            CellPanelType = MakeDefaultPanelType("CellSVGPanel");
            Image cellSvg = MakeDefaultImage("CellSVG", "NEWCellSIMPLIFIED.svg");
            CellPanelType.Add(cellSvg);
            AddNodeToProject(UIFolders.PageHomeCell, CellPanelType);
        }

        public void CreateModuleSVGPanelType()
        {
            ModulePanelType = MakeDefaultPanelType("ModuleSVGPanel");
            Image moduleSvg = MakeDefaultImage("ModuleSVG", "NEWStationsWithNumbers.svg");
            ModulePanelType.Add(moduleSvg);
            AddNodeToProject(UIFolders.PageHomeModule, ModulePanelType);
        }

        public void SetHomeMainContentPanelLoader(NodeId contentNodeId)
        {
            //PanelLoader homeLocalPageNavigationPanelLoader = HomeLocalPageNavigation.Find<PanelLoader>("LocalContentPanelLoader");
            //homeLocalPageNavigationPanelLoader.Panel = contentNodeId;
        }
    }
}