using FTOptix.UI;
using Mikron_MOAB_HMI.Flyouts;
using Mikron_MOAB_HMI.Templates;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.Layouts;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Pages
{
    public class Sidebar
    {
        private ReusableTypes reusableTypes;
        private HeaderFlyouts headerFlyouts;

        public Sidebar()
        {//TODO- where do I put these constructors?
            reusableTypes = new ReusableTypes();
            headerFlyouts = new HeaderFlyouts();
        }

        public PanelType GenerateSidebar()
        {
            PanelType sidebarPanelType = MakeDefaultPanelType("SidebarPanelType");
            ColumnLayout top = CreateSidebarTop();
            Panel bottom = CreateSidebarBottom();
            ColumnLayout sidebarVerticalLayout = CreateTopBottomLayout("SidebarVerticalLayout", top, bottom);

            sidebarPanelType.Add(sidebarVerticalLayout);

            AddNodeToProject(UIFolders.LayoutTemplatesGeneric, sidebarPanelType);

            return sidebarPanelType;
        }

        private ColumnLayout CreateSidebarTop()
        {
            ColumnLayout sidebarTop = MakeDefaultVerticalLayout("SidebarTop");
            Panel home = GenerateNavigationButton("Home", NavigationEnum.Home);
            Panel station = GenerateNavigationButton("Station", NavigationEnum.Station);

            sidebarTop.Add(home);
            sidebarTop.Add(station);
            CreatePlaceholderButtons(sidebarTop);

            return sidebarTop;
        }

        private Panel GenerateNavigationButton(string instanceID, NavigationEnum pageType = NavigationEnum.None)
        {
            return reusableTypes.MakeNavigationButtonTemplateInstance(instanceID, pageType);
        }

        public void CreatePlaceholderButtons(ColumnLayout sidebarTop)
        {
            for (int i = 1; i < 7; i++)
            {
                string name = "PlaceholderButton" + i.ToString();
                Panel placeholderButton = GenerateNavigationButton(name);
                sidebarTop.Add(placeholderButton);
            }
        }

        private Panel CreateSidebarBottom()
        {
            Panel powerFlyoutButton = MakePowerFlyoutButton();
            powerFlyoutButton.VerticalAlignment = VerticalAlignment.Bottom;
            return powerFlyoutButton;
        }

        private Panel MakePowerFlyoutButton()
        {
            Panel powerButton = reusableTypes.MakeFlyoutButtonTemplateInstance("PowerButton", PowerIconPath, NodeLookup(NodeName.EmptyFlyoutPanelType).NodeId, IconSizeForLargeButton);

            return powerButton;
        }
    }
}