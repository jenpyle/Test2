using FTOptix.UI;
using Mikron_MOAB_HMI.Flyouts;
using Mikron_MOAB_HMI.Templates;
using System.Collections.Generic;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Helpers
{
    public class Layouts
    {
        public Layouts()
        {
        }

        public static ColumnLayout CreateTopBottomLayout(string browseName)
        {
            ColumnLayout verticalLayoutTopBottom = MakeDefaultVerticalLayout(browseName);
            ColumnLayout topVerticalLayout = MakeDefaultVerticalLayout("Top");
            ColumnLayout bottomVerticalLayout = MakeDefaultVerticalLayout("Bottom");

            topVerticalLayout.ContentAlignment = ContentVerticalAlignment.Top;
            bottomVerticalLayout.ContentAlignment = ContentVerticalAlignment.Bottom;

            verticalLayoutTopBottom.Add(topVerticalLayout);
            verticalLayoutTopBottom.Add(bottomVerticalLayout);

            return verticalLayoutTopBottom;
        }

        public static ColumnLayout CreateTopBottomLayout(string browseName, Item topElement, Item bottomElement)
        {
            ColumnLayout verticalLayoutTopBottom = MakeDefaultVerticalLayout(browseName);

            ColumnLayout topVerticalLayout = MakeDefaultVerticalLayout("Top");
            ColumnLayout bottomVerticalLayout = MakeDefaultVerticalLayout("Bottom");

            topVerticalLayout.ContentAlignment = ContentVerticalAlignment.Top;
            bottomVerticalLayout.ContentAlignment = ContentVerticalAlignment.Bottom;

            topVerticalLayout.Add(topElement);
            bottomVerticalLayout.Add(bottomElement);
            verticalLayoutTopBottom.Add(topVerticalLayout);
            verticalLayoutTopBottom.Add(bottomVerticalLayout);

            return verticalLayoutTopBottom;
        }

        public static RowLayout CreateLeftRightLayout(string browseName, string leftName = "Left", string rightName = "Right")
        {
            RowLayout horizontalLayoutLeftRight = MakeDefaultHorizontalLayout(browseName);

            RowLayout leftHorizontalLayout = MakeDefaultHorizontalLayout(leftName);
            RowLayout rightHorizontalLayout = MakeDefaultHorizontalLayout(rightName);

            leftHorizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;
            rightHorizontalLayout.ContentAlignment = ContentHorizontalAlignment.Right;
            leftHorizontalLayout.VerticalAlignment = VerticalAlignment.Center;
            rightHorizontalLayout.VerticalAlignment = VerticalAlignment.Center;
            leftHorizontalLayout.HorizontalAlignment = HorizontalAlignment.Stretch;
            rightHorizontalLayout.HorizontalAlignment = HorizontalAlignment.Stretch;

            horizontalLayoutLeftRight.Add(leftHorizontalLayout);
            horizontalLayoutLeftRight.Add(rightHorizontalLayout);

            return horizontalLayoutLeftRight;
        }

        public static RowLayout CreateLeftRightLayout(Item leftElement, Item rightElement, string browseName)
        {
            RowLayout horizontalLayoutLeftRight = MakeDefaultHorizontalLayout(browseName);

            RowLayout leftHorizontalLayout = MakeDefaultHorizontalLayout();
            RowLayout rightHorizontalLayout = MakeDefaultHorizontalLayout();

            leftHorizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;
            rightHorizontalLayout.ContentAlignment = ContentHorizontalAlignment.Right;
            leftHorizontalLayout.VerticalAlignment = VerticalAlignment.Center;
            rightHorizontalLayout.VerticalAlignment = VerticalAlignment.Center;
            leftHorizontalLayout.HorizontalAlignment = HorizontalAlignment.Stretch;
            rightHorizontalLayout.HorizontalAlignment = HorizontalAlignment.Stretch;

            leftHorizontalLayout.Add(leftElement);
            rightHorizontalLayout.Add(rightElement);
            horizontalLayoutLeftRight.Add(leftHorizontalLayout);
            horizontalLayoutLeftRight.Add(rightHorizontalLayout);

            return horizontalLayoutLeftRight;
        }

        public static RowLayout CreateKeyValueLeftAlignedColumnLayout(string browseName, string key,
            string value, TextHorizontalAlignment
            keyTextHorizontalAlignment = TextHorizontalAlignment.Left,
            TextHorizontalAlignment valueTextHorizontalAlignment = TextHorizontalAlignment.Left)
        {
            RowLayout horizontalLayout = MakeDefaultHorizontalLayout(browseName);
            Panel keyContainerPanel = MakeDefaultPanel("KeyContainerPanel");
            Panel valueContainerPanel = MakeDefaultPanel("ValueContainerPanel");
            Label keyLabel = MakeDefaultLabel("Key", key);
            Label valueLabel = MakeDefaultLabel("Value", value);

            horizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;
            keyLabel.TextHorizontalAlignment = keyTextHorizontalAlignment;
            valueLabel.TextHorizontalAlignment = valueTextHorizontalAlignment;

            keyContainerPanel.Add(keyLabel);
            valueContainerPanel.Add(valueLabel);
            horizontalLayout.Add(keyContainerPanel);
            horizontalLayout.Add(valueContainerPanel);

            return horizontalLayout;
        }

        public static RowLayout CreateDynamicLabelKeyValueLeftAlignedColumnLayout(string browseName, Label keyLabel, Label valueLabel)
        {
            RowLayout horizontalLayout = MakeDefaultHorizontalLayout(browseName);
            Panel keyContainerPanel = MakeDefaultPanel("KeyContainerPanel");
            Panel valueContainerPanel = MakeDefaultPanel("ValueContainerPanel");

            horizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;
            keyLabel.TextHorizontalAlignment = TextHorizontalAlignment.Left;
            valueLabel.TextHorizontalAlignment = TextHorizontalAlignment.Left;

            keyContainerPanel.Add(keyLabel);
            valueContainerPanel.Add(valueLabel);
            horizontalLayout.Add(keyContainerPanel);
            horizontalLayout.Add(valueContainerPanel);

            return horizontalLayout;
        }

        public static RowLayout CreateKeyValueLeftAlignedColumnLayout(string browseName, string keyName, string valueName, string key, string value)
        {
            RowLayout horizontalLayout = MakeDefaultHorizontalLayout(browseName);
            Panel keyContainerPanel = MakeDefaultPanel("KeyContainerPanel");
            Panel valueContainerPanel = MakeDefaultPanel("ValueContainerPanel");
            Label keyLabel = MakeDefaultLabel(keyName);
            Label valueLabel = MakeDefaultLabel(valueName);

            horizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;
            keyLabel.TextHorizontalAlignment = TextHorizontalAlignment.Left;
            valueLabel.TextHorizontalAlignment = TextHorizontalAlignment.Left;
            keyLabel.Text = key;
            valueLabel.Text = value;

            keyContainerPanel.Add(keyLabel);
            valueContainerPanel.Add(valueLabel);
            horizontalLayout.Add(keyContainerPanel);
            horizontalLayout.Add(valueContainerPanel);

            return horizontalLayout;
        }

        public static RowLayout CreateKeyValueLeftAlignedColumnLayout(string browseName, Item keyElement, Item valueElement)
        {
            RowLayout horizontalLayout = MakeDefaultHorizontalLayout(browseName);
            Panel keyContainerPanel = MakeDefaultPanel("KeyContainerPanel");
            Panel valueContainerPanel = MakeDefaultPanel("ValueContainerPanel");

            horizontalLayout.ContentAlignment = ContentHorizontalAlignment.Left;

            keyContainerPanel.Add(keyElement);
            valueContainerPanel.Add(valueElement);
            horizontalLayout.Add(keyContainerPanel);
            horizontalLayout.Add(valueContainerPanel);

            return horizontalLayout;
        }

        public static Panel CreatePanelWithUpperRightButtonLayout(string browseName, string buttonIcon)
        {
            Panel containerPanel = MakeDefaultPanel("ContainerPanel");

            Button upperRightHandButton = MakeDefaultButton("UpperRightHandButton");
            string buttonIconPath = GetRelativeImagePath(buttonIcon);
            upperRightHandButton.ImagePath = buttonIconPath;
            upperRightHandButton.HorizontalAlignment = HorizontalAlignment.Right;
            upperRightHandButton.VerticalAlignment = VerticalAlignment.Top;

            ColumnLayout contentVerticalLayout = MakeDefaultVerticalLayout("PanelContentVerticalLayout");

            containerPanel.Add(upperRightHandButton);
            containerPanel.Add(contentVerticalLayout);

            return containerPanel;
        }

        public static PanelType CreatePanelWithFlyoutButtonLayoutType(string browseName, string iconPath, Item panelContent = null, NodeId flyoutPanel = null)
        {
            HeaderFlyouts headerFlyouts = new HeaderFlyouts();
            ReusableTypes reusableTypes = new ReusableTypes();
            string buttonBrowseName = browseName + "FlyoutButton";

            PanelType containerPanel = MakeDefaultPanelType(browseName);
            ColumnLayout contentVerticalLayout = MakeDefaultVerticalLayout("PanelContentVerticalLayout");

            if (flyoutPanel == null)
            {
                flyoutPanel = NodeLookup(NodeName.EmptyFlyoutPanelType).NodeId;
            }

            Panel button = reusableTypes.MakeFlyoutButtonTemplateInstance(buttonBrowseName, iconPath, flyoutPanel, SmallSize);
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.VerticalAlignment = VerticalAlignment.Top;

            if (panelContent != null)
            {
                contentVerticalLayout.Add(panelContent);
            }

            containerPanel.Add(contentVerticalLayout);
            containerPanel.Add(button);

            return containerPanel;
        }

        public static PanelType CreatePanelWithFlyoutAndPanelLoaderLayoutType(string browseName, string iconPath, Item panelContent = null, NodeId flyoutPanel = null)
        {
            HeaderFlyouts headerFlyouts = new HeaderFlyouts();
            ReusableTypes reusableTypes = new ReusableTypes();
            string buttonBrowseName = browseName + "FlyoutButton";

            PanelType containerPanel = MakeDefaultPanelType(browseName);
            ColumnLayout contentVerticalLayout = MakeDefaultVerticalLayout("PanelContentVerticalLayout");
            PanelLoader contentPanelLoader = MakeDefaultPanelLoader("ContentPanelLoader");
            if (flyoutPanel == null)
            {
                flyoutPanel = NodeLookup(NodeName.EmptyFlyoutPanelType).NodeId;
            }

            Panel button = reusableTypes.MakeFlyoutButtonTemplateInstance(buttonBrowseName, iconPath, flyoutPanel, SmallSize);
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.VerticalAlignment = VerticalAlignment.Top;

            if (panelContent != null)
            {
                contentVerticalLayout.Add(panelContent);
            }

            containerPanel.Add(button);
            containerPanel.Add(contentVerticalLayout);

            return containerPanel;
        }

        public static PanelType CreatePanelWithUpperRightButtonLayoutType(string browseName, string buttonIcon)
        {
            PanelType containerPanel = MakeDefaultPanelType(browseName);

            Button upperRightHandButton = MakeDefaultButton("UpperRightHandButton");
            string buttonIconPath = GetRelativeImagePath(buttonIcon);
            upperRightHandButton.ImagePath = buttonIconPath;
            upperRightHandButton.HorizontalAlignment = HorizontalAlignment.Right;
            upperRightHandButton.VerticalAlignment = VerticalAlignment.Top;

            ColumnLayout contentVerticalLayout = MakeDefaultVerticalLayout("PanelContentVerticalLayout");

            containerPanel.Add(upperRightHandButton);
            containerPanel.Add(contentVerticalLayout);

            return containerPanel;
        }

        public static PanelType CreatePageHeaderWithIteratorLayoutType(string browseName, string buttonIcon, Panel itemIterator)
        {
            PanelType containerPanel = MakeDefaultPanelType(browseName);

            RowLayout horizontalLayout = MakeDefaultHorizontalLayout();
            Panel iconContainer = MakeDefaultPanel("IconContainer");
            iconContainer.HorizontalAlignment = HorizontalAlignment.Left;
            iconContainer.Width = SmallContainerWidth;
            Image icon = MakeDefaultImage(browseName + "Icon", buttonIcon);
            icon.Height = IconSizeForLargeButton;
            icon.HorizontalAlignment = HorizontalAlignment.Left;
            icon.VerticalAlignment = VerticalAlignment.Top;

            iconContainer.Add(icon);
            horizontalLayout.Add(iconContainer);
            horizontalLayout.Add(itemIterator);
            containerPanel.Add(horizontalLayout);

            return containerPanel;
        }

        public static Rectangle CreateElementWithWhiteRectangleOutline(string browseName, Item element, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Center, VerticalAlignment verticalAlignment = VerticalAlignment.Center)
        {
            Rectangle whiteOutline = MakeDefaultWhiteRectangle(browseName);
            if (element.GetType() != typeof(Image))
            {
                element.HorizontalAlignment = horizontalAlignment;
                element.VerticalAlignment = verticalAlignment;
            }
            whiteOutline.Add(element);

            return whiteOutline;
        }

        public static Rectangle CreateWhiteOutlinedRectangleFromMultipleElementsHorizontal(
            string browseName,
            List<Item> elementList,
            ContentHorizontalAlignment contentAlignment = ContentHorizontalAlignment.Center,
            HorizontalAlignment horizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment verticalAlignment = VerticalAlignment.Center)
        {
            Rectangle whiteOutline = MakeDefaultWhiteRectangle(browseName);
            RowLayout rowLayout = MakeDefaultHorizontalLayout();
            rowLayout.ContentAlignment = contentAlignment;

            foreach (Item item in elementList)
            {
                if (item.GetType() != typeof(Image))
                {
                    //don't do vertical alignment when type image because it takes away from the stretch
                    //when you leave one of them (like verticalAlignment.Stretch) it retains it's stretching with aspect ratio quality
                    item.VerticalAlignment = verticalAlignment;
                }
                item.HorizontalAlignment = horizontalAlignment;

                rowLayout.Add(item);
            }
            whiteOutline.Add(rowLayout);

            return whiteOutline;
        }

        public static Rectangle CreateWhiteOutlinedRectangleFromMultipleElementsVertical(
            string browseName,
            List<Item> elementList,
            ContentVerticalAlignment contentAlignment = ContentVerticalAlignment.Center,
            HorizontalAlignment horizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment verticalAlignment = VerticalAlignment.Center)
        {
            Rectangle whiteOutline = MakeDefaultWhiteRectangle(browseName);
            ColumnLayout columnLayout = MakeDefaultVerticalLayout();
            columnLayout.ContentAlignment = contentAlignment;

            for (int i = 0; i < elementList.Count; i++)
            {
                columnLayout.Add(elementList[i]);
                columnLayout.Children[i].HorizontalAlignment = horizontalAlignment;
                columnLayout.Children[i].VerticalAlignment = verticalAlignment;
            }
            whiteOutline.Add(columnLayout);

            return whiteOutline;
        }
    }
}