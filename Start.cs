#region Using directives

using FTOptix.UI;
using Mikron_MOAB_HMI.Clean;
using Mikron_MOAB_HMI.Pages.Shared;
using Mikron_MOAB_HMI.Pages.Station;
using Mikron_MOAB_HMI.Templates;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;
using static Mikron_MOAB_HMI.Navigation.Navigation;

#endregion

public class Start
{
    //private NodeCreationUnitOfWork unitOfWork = new NodeCreationUnitOfWork();

    private FolderSetup folderSetup = new FolderSetup();
    private CleanProject cleanProject = new CleanProject();

    private PanelLoader HeaderPanelLoader = MakeDefaultPanelLoader("HeaderPanelLoader");
    private PanelLoader SidebarPanelLoader = MakeDefaultPanelLoader("SidebarPanelLoader");
    private PanelLoader PagePanelLoader = MakeDefaultPanelLoader("PagePanelLoader");

    private PanelType PageType;

    public Start()
    {
    }

    public void CleanAndRun()
    {
        ProjectSetup();
        CreateTemplateTypes();
        CreateBasicRegions();
        CreateHmiPages();
        AddStationViewToTree();
    }

    public void CleanAll()
    {
        cleanProject.CleanAll();
    }

    public void ProjectSetup()
    {
        cleanProject.CleanAll();
        folderSetup.GenerateFolderLayout();
        NavigationSetup();
        AddBaseLayoutToMainWindow();
    }

    /// <summary>
    /// Creating the Types (both template and object)
    /// The Template types are the optix visual elements, instances can be made from the type
    /// Object type gets its properties that
    /// When both the object and template type are created, then an alias node can be attached
    /// </summary>

    public void CreateTemplateTypes()
    {
        AlarmItemRow alarmItemRow = new AlarmItemRow();
        FlyoutButton flyoutButton = new FlyoutButton();
        ItemIterator itemIterator = new ItemIterator();
        LocalPageNavigationTab localPageNavigationTab = new LocalPageNavigationTab();
        NavigationButton navigationButton = new NavigationButton();
        PerformanceItem performanceItem = new PerformanceItem();
        StationRow stationRow = new StationRow();

        alarmItemRow.CreateAndStoreType();
        flyoutButton.CreateAndStoreType();
        itemIterator.CreateAndStoreType();
        localPageNavigationTab.CreateAndStoreType();
        navigationButton.CreateAndStoreType();
        performanceItem.CreateAndStoreType();
        stationRow.CreateAndStoreType();
    }

    public void CreateBasicRegions()
    {
        BasicRegions basicRegions = new();
        basicRegions.CreateAndStoreBasicRegions();
    }

    public void CreateHmiPages()
    {
        StationView stationView = new StationView();
        stationView.CreateStationPanelTypes();

        Alarms alarms = new Alarms();
        AddNodeToProject(UIFolders.LayoutTemplatesGeneric, alarms.GenerateDashboardAlarmList());
    }

    public void AddStationViewToTree()
    {
        SetPanel(PagePanelLoader, NodeLookup(NodeName.Page));

        SetPanel(HeaderPanelLoader, NodeLookup(NodeName.HeaderPanelType));

        SetPanel(SidebarPanelLoader, NodeLookup(NodeName.SidebarPanelType));

        PanelLoader rightDashboardPanelLoader = GetRightDashboardPanelLoader();
        SetPanel(rightDashboardPanelLoader, NodeLookup(NodeName.AlarmListPanelType));

        PanelLoader leftDashboardPanelLoader = GetLeftDashboardPanelLoader(true);
        SetPanel(leftDashboardPanelLoader, NodeLookup(NodeName.StationSelectedItemIterator));

        SetMainContentPanelLoaderPanel(NodeLookup(NodeName.StationLocalPageNavigation).NodeId);
    }

    public void AddBaseLayoutToMainWindow()
    {
        Panel baseLayout = MakeDefaultPanel("Base");
        baseLayout.Height = 768;
        baseLayout.Width = 1024;
        ColumnLayout baseVerticalLayout = MakeDefaultVerticalLayout("BaseVerticalLayout");
        RowLayout baseHorizontalLayout = MakeDefaultHorizontalLayout("BaseHorizontalLayout");

        HeaderPanelLoader.Height = LargeSize;
        SidebarPanelLoader.Width = LargeSize;
        HeaderPanelLoader.VerticalAlignment = VerticalAlignment.Top;
        SidebarPanelLoader.HorizontalAlignment = HorizontalAlignment.Left;

        baseLayout.Add(BaseBackground);
        baseLayout.Add(baseVerticalLayout);
        baseVerticalLayout.Add(HeaderPanelLoader);
        baseVerticalLayout.Add(baseHorizontalLayout);
        baseHorizontalLayout.Add(SidebarPanelLoader);
        baseHorizontalLayout.Add(PageBackground);
        PageBackground.Add(PagePanelLoader);
        AddToMainWindow(baseLayout);
    }
}