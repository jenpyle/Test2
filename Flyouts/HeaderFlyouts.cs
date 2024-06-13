using FTOptix.UI;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.Layouts;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Flyouts
{
    public class HeaderFlyouts
    {
        public PanelType UserInfoFlyoutPanelType;
        public PanelType BatchInfoFlyoutPanelType;
        public PanelType EmptyFlyoutPanelType;

        public HeaderFlyouts()
        {
        }

        public void CreateAndStoreFlyouts()
        {
            CreateUserFlyoutType();
            CreateMachineStatusFlyoutType();
            CreateEmptyFlyoutPanelType();
        }

        public void CreateUserFlyoutType()
        {
            UserInfoFlyoutPanelType = MakeDefaultDropdownPanelContainerType("UserInfoFlyoutPanelType");
            ColumnLayout topSection = MakeDefaultVerticalLayout("UserInfo");
            Label username = MakeDefaultLabel("Username", "Jennifer P", TextHorizontalAlignment.Left, TextVerticalAlignment.Top);
            Label userLevel = MakeDefaultLabel("UserLevel", "Operator", TextHorizontalAlignment.Left, TextVerticalAlignment.Top);
            Label userStats = MakeDefaultLabel("UserStats", "User Stats: 10000", TextHorizontalAlignment.Left, TextVerticalAlignment.Top);
            topSection.Add(username);
            topSection.Add(userLevel);
            topSection.Add(userStats);

            Button userSettingsButton = MakeDefaultButton("UserSettingsButton");
            Button logOutButton = MakeDefaultButton("LogOutButton");
            userSettingsButton.Text = "User Settings";
            logOutButton.Text = "Log Out";
            RowLayout bottomSection = CreateLeftRightLayout(userSettingsButton, logOutButton, "UserFlyoutButtons");
            bottomSection.VerticalAlignment = VerticalAlignment.Bottom;
            ColumnLayout userFlyoutVerticalLayout = CreateTopBottomLayout("UserFlyoutLayout", topSection, bottomSection);

            UserInfoFlyoutPanelType.Add(userFlyoutVerticalLayout);
            AddNodeToProject(UIFolders.PageFlyouts, UserInfoFlyoutPanelType);
        }

        public void CreateMachineStatusFlyoutType()
        {
            BatchInfoFlyoutPanelType = MakeDefaultDropdownPanelContainerType("BatchInfoFlyoutPanelType");
            ColumnLayout verticalLayout = MakeDefaultVerticalLayout();
            RowLayout editBatchRow = MakeRowWithIconAndKeyValuePairs("EditBatchName", "edit.svg", "Batch Name", "test");
            RowLayout editVariantRow = MakeRowWithIconAndKeyValuePairs("EditVariant", "edit.svg", "Variant", "DEMO1");
            RowLayout editToProduceRow = MakeRowWithIconAndKeyValuePairs("EditToProduce", "edit.svg", "To Produce", "500");

            verticalLayout.Add(editBatchRow);
            verticalLayout.Add(editVariantRow);
            verticalLayout.Add(editToProduceRow);
            BatchInfoFlyoutPanelType.Add(verticalLayout);

            AddNodeToProject(UIFolders.PageFlyouts, BatchInfoFlyoutPanelType);
        }

        public RowLayout MakeRowWithIconAndKeyValuePairs(string browseName, string imageName, string imageText, string valueText)
        {
            RowLayout editBatchNameIconWithText = MakeIconWithTextLayout(browseName + "Key", imageName, imageText);
            Label batchNameValue = MakeDefaultLabel(browseName + "Value", valueText);
            RowLayout rowHorizontalLayout = CreateKeyValueLeftAlignedColumnLayout(browseName, editBatchNameIconWithText, batchNameValue);

            return rowHorizontalLayout;
        }

        public RowLayout MakeIconWithTextLayout(string browseName, string imageName, string imageText)
        {
            RowLayout buttonWithTextLayout = MakeDefaultHorizontalLayout(browseName);
            var iconImage = MakeDefaultImage(browseName + "Image", imageName);
            Label textLabel = MakeDefaultLabel(browseName + "Label", imageText);

            iconImage.FillMode = FillMode.Fit;
            iconImage.VerticalAlignment = VerticalAlignment.Center;
            iconImage.HorizontalAlignment = HorizontalAlignment.Left;

            buttonWithTextLayout.Add(iconImage);
            buttonWithTextLayout.Add(textLabel);

            return buttonWithTextLayout;
        }

        public void CreateEmptyFlyoutPanelType()
        {
            EmptyFlyoutPanelType = MakeDefaultDropdownPanelContainerType("EmptyFlyoutPanelType");

            AddNodeToProject(UIFolders.PageFlyouts, EmptyFlyoutPanelType);
        }
    }
}