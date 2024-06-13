using FTOptix.UI;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Pages.Shared
{
    public class BasicRegions
    {
        public BasicRegions()
        {
        }

        public void CreateAndStoreBasicRegions()
        {
            GenerateEmptyPageType();

            Header header = new Header();
            header.GenerateHeader();

            Sidebar sidebar = new Sidebar();
            sidebar.GenerateSidebar();
        }

        public PanelType GenerateEmptyPageType()
        {
            PanelType page = MakeDefaultPanelType("Page");
            ColumnLayout pageVerticalLayout = MakeDefaultVerticalLayout("PageVerticalLayout");
            RowLayout dashboard = GenerateDashboard("Dashboard");
            PanelLoader mainContent = MakeDefaultPanelLoaderSection("MainContentPanelLoader");

            page.Add(pageVerticalLayout);
            pageVerticalLayout.Add(dashboard);
            pageVerticalLayout.Add(mainContent);

            AddNodeToProject(UIFolders.LayoutTemplatesGeneric, page);
            return page;
        }

        public static RowLayout GenerateDashboard(string browseName)
        {
            RowLayout dashboard = MakeDefaultHorizontalLayout(browseName);
            dashboard.VerticalAlignment = VerticalAlignment.Top;
            dashboard.Height = 100;

            PanelLoader Left = MakeDefaultPanelLoaderSection("DashboardLeftPanelLoader");
            Left.Width = 300;
            PanelLoader Right = MakeDefaultPanelLoaderSection("DashboardRightPanelLoader");

            dashboard.Add(Left);
            dashboard.Add(Right);
            return dashboard;
        }
    }
}