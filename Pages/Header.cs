using FTOptix.UI;
using Mikron_MOAB_HMI.Flyouts;
using Mikron_MOAB_HMI.Templates;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiColors;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.Layouts;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Pages
{
    public class Header
    {
        private ReusableTypes reusableTypes;

        public Header()
        {
            reusableTypes = new ReusableTypes();
        }

        public DialogType GenerateDialogBox()
        {
            DialogType dialogType = MakeDefaultDialogBoxType("DialogBoxExample");
            dialogType.Width = 1000;
            dialogType.Height = 1000;
            Rectangle backgroundBlur = MakeDefaultRectangle("BackgroundBlur");
            backgroundBlur.BorderThickness = 0;
            backgroundBlur.FillColor = Black;
            backgroundBlur.Opacity = 75F;

            Button closeButton = MakeDefaultButton("CloseDialog", MediumSize, CloseIconPath);
            Rectangle placeholder = MakeDefaultPlaceholder("DialogBoxExamplePlaceholder");
            placeholder.HorizontalAlignment = HorizontalAlignment.Center;
            placeholder.VerticalAlignment = VerticalAlignment.Center;
            placeholder.Width = 500;
            placeholder.Height = 500;
            closeButton.VerticalAlignment = VerticalAlignment.Top;
            closeButton.HorizontalAlignment = HorizontalAlignment.Right;
            placeholder.Add(closeButton);

            dialogType.Add(backgroundBlur);
            dialogType.Add(placeholder);

            AddNodeToProject(UIFolders.Page, dialogType);

            return dialogType;
        }

        public PanelType GenerateHeader()
        {
            PanelType headerPanelType = MakeDefaultPanelType("HeaderPanelType");
            headerPanelType.Height = 50;
            RowLayout left = CreateHeaderLeft();
            RowLayout right = CreateHeaderRight();
            right.HorizontalAlignment = HorizontalAlignment.Right;
            RowLayout headerHorizontalLayout = CreateLeftRightLayout(left, right, "HeaderHorizontalLayout");

            headerPanelType.Add(headerHorizontalLayout);
            AddNodeToProject(UIFolders.LayoutTemplatesGeneric, headerPanelType);

            return headerPanelType;
        }

        public RowLayout CreateHeaderLeft()
        {
            RowLayout headerLeft = MakeDefaultHorizontalLayout("HeaderLeft");
            Label timeLabel = MakeDefaultLabel("TimeLabel", "11:30", TextHorizontalAlignment.Center);
            Label dateLabel = MakeDefaultLabel("DateLabel", "02/21/2024");
            ColumnLayout dateTime = CreateTopBottomLayout("DateTime", timeLabel, dateLabel);
            dateTime.HorizontalAlignment = HorizontalAlignment.Left;
            MikronAutomationLogo.HorizontalAlignment = HorizontalAlignment.Left;
            MikronAutomationLogo.VerticalAlignment = VerticalAlignment.Center;

            headerLeft.Add(MikronAutomationLogo);
            headerLeft.Add(dateTime);

            return headerLeft;
        }

        public RowLayout CreateHeaderRight()
        {
            HeaderFlyouts headerFlyouts = new HeaderFlyouts();
            headerFlyouts.CreateAndStoreFlyouts();
            RowLayout headerRight = MakeDefaultHorizontalLayout("HeaderRight");
            Panel camAngle = GenerateHeaderFlyoutButton("CamAngle", CamAngleIconPath, NodeLookup(NodeName.EmptyFlyoutPanelType).NodeId);
            Panel user = GenerateHeaderFlyoutButton("User", UserIconPath, NodeLookup(NodeName.UserInfoFlyoutPanelType).NodeId);
            Panel machineStatus = GenerateHeaderFlyoutButton("Status", PlaceholderIconPath, NodeLookup(NodeName.BatchInfoFlyoutPanelType).NodeId);
            Panel partsSection = CreatePartsSection();

            headerRight.Add(partsSection);
            headerRight.Add(camAngle);
            headerRight.Add(user);
            headerRight.Add(machineStatus);

            return headerRight;
        }

        private Panel GenerateHeaderFlyoutButton(string instanceID, string icon, NodeId panelNodeId)
        {
            return reusableTypes.MakeFlyoutButtonTemplateInstance(instanceID, icon, panelNodeId, IconSizeForLargeButton);
        }

        public Panel CreatePartsSection()
        {
            Panel partsSectionPanel = MakeDefaultPanel("PartsSectionPanel");
            partsSectionPanel.Width = 100;
            partsSectionPanel.HorizontalAlignment = HorizontalAlignment.Right;
            ColumnLayout verticalLayout = MakeDefaultVerticalLayout();
            Label productionLabel = MakeDefaultLabel("ProductionLabel", "Production");
            RowLayout productionPercentages = MakeDefaultHorizontalLayout("ProductionChartPercentages");
            Label productionLabel1 = MakeDefaultLabel("PercentageLabel1", "33%");
            Label productionLabel2 = MakeDefaultLabel("PercentageLabel2", "33%");
            Label productionLabel3 = MakeDefaultLabel("PercentageLabel3", "33%");
            productionPercentages.Add(productionLabel1);
            productionPercentages.Add(productionLabel2);
            productionPercentages.Add(productionLabel3);

            RowLayout productionChart = MakeDefaultHorizontalLayout("ProductionChart");
            Rectangle rectangle1 = MakeDefaultRectangle("rectangle1");
            Rectangle rectangle2 = MakeDefaultRectangle("rectangle2");
            Rectangle rectangle3 = MakeDefaultRectangle("rectangle3");
            rectangle1.FillColor = Failure;
            rectangle2.FillColor = Alert;
            rectangle3.FillColor = Ready;
            productionChart.Add(rectangle1);
            productionChart.Add(rectangle2);
            productionChart.Add(rectangle3);

            verticalLayout.Add(productionLabel);
            verticalLayout.Add(productionPercentages);
            verticalLayout.Add(productionChart);
            partsSectionPanel.Add(verticalLayout);

            return partsSectionPanel;
        }
    }
}