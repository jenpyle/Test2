using FTOptix.UI;
using Mikron_MOAB_HMI.Templates;
using System.Collections.Generic;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiColors;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Pages.Shared
{
    public class LocalPageNavigation : TemplateTypeBaseClass
    {
        public PanelType LocalPageNavigationContainer;

        public PanelLoader LocalContentPanelLoader;
        private PanelLoader localContentPanelLoader;
        private ReusableTypes reusableTypes;

        public LocalPageNavigation()
        {
            reusableTypes = new ReusableTypes();
        }

        public PanelType GenerateLocalPageNavigation(string browseName, List<ChangePanelButton> changePanelButtonsList, NodeId landingTab)
        {
            LocalPageNavigationContainer = CreateLocalPageNavigationContainer(browseName);

            RowLayout localPageNavigationOptionsHorizontalLayout = AddNavigationButtons(changePanelButtonsList);
            var locationToAdd = LocalPageNavigationContainer.Find<RowLayout>("HorizontalLayout");
            locationToAdd.Add(localPageNavigationOptionsHorizontalLayout);
            Temp(landingTab);

            return LocalPageNavigationContainer;
        }

        public PanelType CreateLocalPageNavigationContainer(string browseName)
        {
            PanelType localPageNavigationContainer = MakeDefaultPanelType(browseName);
            ColumnLayout verticalLayout = MakeDefaultVerticalLayout("LocalPageNavigationContainer");
            RowLayout localPageNavigationOptionsHorizontalLayout = MakeDefaultHorizontalLayout();
            localPageNavigationOptionsHorizontalLayout.VerticalAlignment = VerticalAlignment.Bottom;
            //LocalContentPanelLoader = MakeDefaultPanelLoaderSection(browseName + "LocalContentPanelLoader");
            LocalContentPanelLoader = MakeDefaultPanelLoaderSection("LocalContentPanelLoaderTEST");
            LocalContentPanelLoader.ExitAnimation = PanelLoaderAnimationType.SlideLeft;
            LocalContentPanelLoader.EnterAnimation = PanelLoaderAnimationType.SlideRight;
            localPageNavigationContainer.Add(verticalLayout);
            verticalLayout.Add(localPageNavigationOptionsHorizontalLayout);
            verticalLayout.Add(LocalContentPanelLoader);
            AddNodeToProject(UIFolders.LayoutTemplatesGeneric, localPageNavigationContainer);
            //AddNodeToProject(UIFolders.LayoutTemplatesGeneric, LocalContentPanelLoader);

            return localPageNavigationContainer;
        }

        private RowLayout AddNavigationButtons(List<ChangePanelButton> changePanelButtonsList)
        {
            RowLayout localPageNavigationOptionsHorizontalLayout = MakeDefaultHorizontalLayout("LocalPageNavigationOptionsHorizontalLayout");
            IUAObject panelLoaderObj = LocalPageNavigationContainer.GetObject("LocalPageNavigationContainer/LocalContentPanelLoaderTEST");
            foreach (ChangePanelButton item in changePanelButtonsList)
            {
                Panel navigationButton = GenerateLocalPageNavigationTab(item.ButtonText, item.ButtonText, item.PanelToLoad, LocalContentPanelLoader.NodeId, panelLoaderObj);

                localPageNavigationOptionsHorizontalLayout.Add(navigationButton);
            }
            localPageNavigationOptionsHorizontalLayout.VerticalAlignment = VerticalAlignment.Top;
            localPageNavigationOptionsHorizontalLayout.Height = 35;

            return localPageNavigationOptionsHorizontalLayout;
        }

        private Panel GenerateLocalPageNavigationTab(string instanceID, string option, NodeId panelToLoad, NodeId targetPanelLoader, IUAObject x)
        {
            return reusableTypes.MakeLocalPageNavigationTabTemplateInstance(instanceID, option, panelToLoad, targetPanelLoader, x);
        }

        private void Temp(NodeId landingTab)
        {
            Rectangle backgroundOfMainPanelLoader = GetBackgroundOfPanelLoaderSection("MainContentPanelLoader");
            backgroundOfMainPanelLoader.Visible = false;
            LocalContentPanelLoader.Panel = landingTab;
        }

        private PanelType GetPanelTypeTest()
        {
            PanelType panelToLoad = MakeDefaultPanelTypeColor("PanelToLoad", Black);

            AddNodeToProject(UIFolders.Layout, panelToLoad);

            return panelToLoad;
        }

        private PanelLoader GetPanelLoaderTest()
        {
            PanelLoader panelLoaderTest = MakeDefaultPanelLoader("PanelLoaderTest");
            AddNodeToProject(UIFolders.Layout, panelLoaderTest);
            return panelLoaderTest;
        }
    }
}