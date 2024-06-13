using FTOptix.UI;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.Layouts;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Pages.Shared
{
    public class WidgetOptions
    {
        public WidgetOptions()
        {
        }

        public PanelType GenerateWidgetSelector()
        {
            var placeholder = MakeDefaultPlaceholder("tempPlaceholder");
            PanelLoader x = MakeDefaultPanelLoader("WidgetPanelLoader");
            x.Panel = GetCustomWidgetSelection(CustomWidgetSelectionEnum.PerformanceOverview);
            PanelType customWidgetSelector = CreatePanelWithFlyoutButtonLayoutType("CustomWidgetSelection", SettingsIconPath, x, CreateSettingsWidgetSelectionFlyout().NodeId);
            AddNodeToProject(UIFolders.LayoutTemplatesGeneric, customWidgetSelector);

            return customWidgetSelector;
        }

        public PanelType GeneratePerformanceOverviewWidget()
        {
            PanelType performanceOverviewWidget = MakeDefaultPanelType("PerformanceOverviewWidget");
            ColumnLayout verticalLayout = MakeDefaultVerticalLayout();
            RowLayout highestScrap = CreateKeyValueLeftAlignedColumnLayout("HighestScrap", "Highest Scrap", "10");
            RowLayout lowestEfficiency = CreateKeyValueLeftAlignedColumnLayout("LowestEfficiency", "Lowest Efficiency", "10");
            RowLayout performance = CreateKeyValueLeftAlignedColumnLayout("Performance", "Performance", "80%");
            RowLayout quality = CreateKeyValueLeftAlignedColumnLayout("Quality", "Quality", "75%");

            verticalLayout.Add(highestScrap);
            verticalLayout.Add(lowestEfficiency);
            verticalLayout.Add(performance);
            verticalLayout.Add(quality);
            performanceOverviewWidget.Add(verticalLayout);

            AddNodeToProject(UIFolders.LayoutTemplatesGeneric, performanceOverviewWidget);
            return performanceOverviewWidget;
        }

        //public PanelType CreateSettingsWidgetSelectionFlyout()
        //{
        //    PanelType addWidgetFlyoutPanelType = MakeDefaultDropdownPanelContainerType("AddWidgetFlyoutPanelType");
        //    ColumnLayout verticalLayout = MakeDefaultVerticalLayout();
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Rectangle placeholder = MakeDefaultPlaceholder("AddWidget2" + i.ToString(), "+");
        //        ColumnLayout placeholderVerticalLayout = MakeDefaultVerticalLayout();
        //        if (i == 0)
        //        {
        //            Button performanceWidget = MakeDefaultButton("AddPerformanceWidget", LargeSize, PlusCircleIconPath, "Performance Overview");
        //            placeholder.Add(performanceWidget);
        //            placeholderVerticalLayout.Add(placeholder);
        //        }
        //        else
        //        {
        //            Label label = MakeDefaultLabel("Widget" + i.ToString(), "Widget " + i.ToString());
        //            placeholderVerticalLayout.Add(label);
        //        }

        //        //placeholder.Add(placeholderVerticalLayout);
        //        verticalLayout.Add(placeholder);
        //    }

        //    //Button performanceWidget = MakeDefaultButton("AddPerformanceWidget", LargeSize, PlusCircleIconPath, "Performance Overview");
        //    //verticalLayout.Add(performanceWidget);
        //    //for (int i = 0; i < 4; i++)
        //    //{
        //    //    Button placeholder = MakeDefaultButton("AddWidget" + i.ToString(), LargeSize, PlusCircleIconPath, "Widget" + i.ToString());
        //    //    verticalLayout.Add(placeholder);
        //    //}

        //    addWidgetFlyoutPanelType.Add(verticalLayout);
        //    AddNodeToProject(UIFolders.PageFlyouts, addWidgetFlyoutPanelType);
        //    return addWidgetFlyoutPanelType;
        //}

        public PanelType CreateSettingsWidgetSelectionFlyout()
        {
            PanelType addWidgetFlyoutPanelType = MakeDefaultDropdownPanelContainerType("AddWidgetFlyoutPanelType");
            ColumnLayout verticalLayout = MakeDefaultVerticalLayout();
            for (int i = 0; i < 4; i++)
            {
                Rectangle placeholder = MakeDefaultPlaceholder("AddWidget" + i.ToString(), "+");
                ColumnLayout placeholderVerticalLayout = MakeDefaultVerticalLayout();
                Label label = MakeDefaultLabel("Widget" + i.ToString(), "Widget " + i.ToString());

                placeholderVerticalLayout.Add(label);
                placeholder.Add(placeholderVerticalLayout);
                verticalLayout.Add(placeholder);
            }
            addWidgetFlyoutPanelType.Add(verticalLayout);
            AddNodeToProject(UIFolders.PageFlyouts, addWidgetFlyoutPanelType);
            return addWidgetFlyoutPanelType;
        }

        public NodeId GetCustomWidgetSelection(CustomWidgetSelectionEnum widgetSelection)
        {
            switch (widgetSelection)
            {
                case CustomWidgetSelectionEnum.PerformanceOverview:
                    return GeneratePerformanceOverviewWidget().NodeId;

                case CustomWidgetSelectionEnum.PlaceholderWidget:
                    return GeneratePerformanceOverviewWidget().NodeId;

                default:
                    return GeneratePerformanceOverviewWidget().NodeId;
            }
        }
    }
}