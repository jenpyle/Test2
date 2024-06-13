using FTOptix.Core;
using FTOptix.HMIProject;
using FTOptix.UI;
using Mikron_MOAB_HMI.Flyouts;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiColors;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Helpers
{
    /// <summary>
    /// Default elements like Rectangle, Panel, etc. So they automatically have desired style
    /// </summary>
    public class HmiStyledElements
    {
        #region Basic elements without children

        public static Button MakeDefaultButton(string browseName)
        {
            Button button = InformationModel.Make<Button>(browseName);
            button.Width = -1;
            button.Height = -1;
            button.HorizontalAlignment = HorizontalAlignment.Stretch;
            button.VerticalAlignment = VerticalAlignment.Stretch;
            button.BackgroundColor = SecondaryColor;
            button.TextColor = White;
            button.FontSize = ButtonFontSize;
            button.ImagePath = PlaceholderIconPath;

            return button;
        }

        public static Button MakeDefaultButton(string browseName, float buttonSize, string icon, string text)
        {
            Button button = MakeDefaultButton(browseName);
            button.ImageHeight = buttonSize;
            button.ImagePath = icon;
            button.Text = text;
            button.ImagePosition = Position.Top;
            button.TextPosition = Position.Bottom;

            return button;
        }

        public static Button MakeDefaultButton(string browseName, float buttonSize, string icon)
        {
            Button button = MakeDefaultButton(browseName);
            button.ImageHeight = buttonSize;
            button.ImagePath = icon;

            return button;
        }

        public static Rectangle MakeDefaultRectangle(string browseName)
        {
            Rectangle rectangle = InformationModel.Make<Rectangle>(browseName);
            rectangle.Width = -1;
            rectangle.Height = -1;
            rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;
            rectangle.VerticalAlignment = VerticalAlignment.Stretch;
            rectangle.FillColor = PrimaryColor;
            rectangle.BorderColor = PrimaryBorder;
            rectangle.BorderThickness = DefaultShapeBorderThickness;
            rectangle.CornerRadius = DefaultRectangleCornerRadius;

            return rectangle;
        }

        public static Rectangle MakeDefaultColorRectangle(string browseName, Color fillColor)
        {
            Rectangle rectangle = InformationModel.Make<Rectangle>(browseName);
            rectangle.Width = -1;
            rectangle.Height = -1;
            rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;
            rectangle.VerticalAlignment = VerticalAlignment.Stretch;
            rectangle.FillColor = fillColor;

            return rectangle;
        }

        public static RadioButton MakeDefaultOptionButton(string browseName, string text)
        {
            RadioButton radioButton = InformationModel.Make<RadioButton>(browseName);
            radioButton.Width = -1;
            radioButton.Height = -1;
            radioButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            radioButton.VerticalAlignment = VerticalAlignment.Stretch;
            radioButton.TextColor = White;
            radioButton.FontSize = ButtonFontSize;
            radioButton.WordWrap = true;

            return radioButton;
        }

        public static Rectangle MakeDefaultWhiteRectangle(string browseName = "Outline")
        {
            Rectangle rectangle = InformationModel.Make<Rectangle>(browseName);
            rectangle.Width = -1;
            rectangle.Height = -1;
            rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;
            rectangle.VerticalAlignment = VerticalAlignment.Stretch;
            rectangle.FillColor = Transparent;
            rectangle.BorderColor = White;
            rectangle.BorderThickness = 1;

            return rectangle;
        }

        public static Ellipse MakeDefaultEllipse(string browseName)
        {
            Ellipse ellipse = InformationModel.Make<Ellipse>(browseName);
            ellipse.BorderColor = White;
            ellipse.FillColor = Transparent;
            ellipse.BorderThickness = DefaultShapeBorderThickness;
            ellipse.Height = 45;
            ellipse.Width = 45;

            return ellipse;
        }

        public static Label MakeDefaultLabel(string browseName, string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", TextHorizontalAlignment textHorizontalAlignment = TextHorizontalAlignment.Left, TextVerticalAlignment textVerticalAlignment = TextVerticalAlignment.Center)
        {
            Label label = InformationModel.Make<Label>(browseName);
            label.Text = text;
            label.TextColor = White;
            label.HorizontalAlignment = HorizontalAlignment.Stretch;
            label.VerticalAlignment = VerticalAlignment.Stretch;
            label.TextHorizontalAlignment = textHorizontalAlignment;
            label.TextVerticalAlignment = textVerticalAlignment;

            return label;
        }

        //TODO need way to handle null folder
        /// <summary>
        /// Stretch to fill container WITHOUT locked aspect ratio
        /// </summary>
        public static Image MakeDefaultImageStretch(string browseName, string imageName = "placeholder.svg")
        {
            Image image = InformationModel.Make<Image>(browseName);
            string imageResourceUri = GetRelativeImagePath(imageName);
            image.Path = imageResourceUri;
            image.FillMode = FillMode.Stretch;
            image.HorizontalAlignment = HorizontalAlignment.Stretch;
            image.VerticalAlignment = VerticalAlignment.Stretch;

            return image;
        }

        /// <summary>
        /// Stretch WITH locked aspect ratio
        /// </summary>
        public static Image MakeDefaultImage(string browseName, string imageName = "placeholder.svg")
        {
            Image image = InformationModel.Make<Image>(browseName);
            string imageResourceUri = GetRelativeImagePath(imageName);
            image.Path = imageResourceUri;
            image.FillMode = FillMode.Fit;
            image.HorizontalAlignment = HorizontalAlignment.Stretch;
            image.VerticalAlignment = VerticalAlignment.Stretch;
            image.BottomMargin = SmallMargin;
            image.TopMargin = SmallMargin;
            image.RightMargin = SmallMargin;
            image.LeftMargin = SmallMargin;

            return image;
        }

        /// <summary>
        /// No Stretch. Defaults to a small size
        /// </summary>
        public static Image MakeDefaultImageNoStretch(string browseName, string imageName = "placeholder.svg")
        {
            Image image = InformationModel.Make<Image>(browseName);
            string imageResourceUri = GetRelativeImagePath(imageName);
            image.Path = imageResourceUri;
            image.FillMode = FillMode.Stretch;
            image.HorizontalAlignment = HorizontalAlignment.Center;
            image.VerticalAlignment = VerticalAlignment.Center;

            return image;
        }

        public static Panel MakeDefaultPanel(string browseName)
        {
            Panel panel = InformationModel.Make<Panel>(browseName);
            panel.Width = -1;
            panel.Height = -1;
            panel.HorizontalAlignment = HorizontalAlignment.Stretch;
            panel.VerticalAlignment = VerticalAlignment.Stretch;

            return panel;
        }

        public static PanelLoader MakeDefaultPanelLoader(string browseName)
        {
            PanelLoader panelLoader = InformationModel.Make<PanelLoader>(browseName);
            panelLoader.Width = -1;
            panelLoader.Height = -1;
            panelLoader.HorizontalAlignment = HorizontalAlignment.Stretch;
            panelLoader.VerticalAlignment = VerticalAlignment.Stretch;

            return panelLoader;
        }

        public static PanelLoaderType MakeDefaultPanelLoaderType(string browseName)
        {
            PanelLoaderType panelLoaderType = InformationModel.Make<PanelLoaderType>(browseName);
            panelLoaderType.Width = -1;
            panelLoaderType.Height = -1;
            panelLoaderType.HorizontalAlignment = HorizontalAlignment.Stretch;
            panelLoaderType.VerticalAlignment = VerticalAlignment.Stretch;

            return panelLoaderType;
        }

        public static ColumnLayout MakeDefaultVerticalLayout(string browseName = "VerticalLayout")
        {
            ColumnLayout column = InformationModel.Make<ColumnLayout>(browseName);
            column.Width = -1;
            column.Height = -1;
            column.HorizontalAlignment = HorizontalAlignment.Stretch;
            column.VerticalAlignment = VerticalAlignment.Stretch;

            return column;
        }

        public static RowLayout MakeDefaultHorizontalLayout(string browseName = "HorizontalLayout")
        {
            RowLayout row = InformationModel.Make<RowLayout>(browseName);
            row.Width = -1;
            row.Height = -1;
            row.HorizontalAlignment = HorizontalAlignment.Stretch;
            row.VerticalAlignment = VerticalAlignment.Stretch;

            return row;
        }

        #endregion

        #region Basic Elements with children

        public static Panel MakeDefaultPanelSection(string browseName)
        {
            Panel panel = MakeDefaultPanel(browseName);
            Rectangle panelBackground = MakeDefaultRectangle("Background");

            panel.Add(panelBackground);

            return panel;
        }

        public static PanelLoader MakeDefaultPanelLoaderSection(string browseName)
        {
            PanelLoader panelLoader = MakeDefaultPanelLoader(browseName);
            Rectangle panelBackground = MakeDefaultRectangle("Background");

            panelLoader.Add(panelBackground);

            return panelLoader;
        }

        public static PanelLoader MakeDefaultPanelLoaderLocalPageNavigationSection(string browseName)
        {
            PanelLoader panelLoader = MakeDefaultPanelLoader(browseName);
            Rectangle panelBackground = MakeDefaultRectangle("Background");
            panelBackground.BorderColor = SecondaryColor;
            panelBackground.FillColor = Transparent;

            panelLoader.Add(panelBackground);

            return panelLoader;
        }

        public static DropDownButton MakeDefaultDropdownButton(string browseName, string imageName = null, bool isStandardSize = false)
        {
            DropDownButton dropdownButton = InformationModel.Make<DropDownButton>(browseName);
            dropdownButton.Width = -1;
            dropdownButton.Height = -1;
            dropdownButton.HorizontalAlignment = HorizontalAlignment.Center;
            dropdownButton.VerticalAlignment = VerticalAlignment.Center;
            dropdownButton.BackgroundColor = SecondaryColor;
            dropdownButton.TextColor = White;
            dropdownButton.FontSize = ButtonFontSize;
            //dropdownButton.Panel = MakeDefaultDropdownPanelType("ButtonDropdownPanel").NodeId;

            //TODO - change to not make it a double negative
            if (!string.IsNullOrEmpty(imageName))
            {
                string iconPath = GetRelativeImagePath(imageName);
                dropdownButton.ImagePath = iconPath;

                if (isStandardSize)
                {
                    dropdownButton.Width = LargeSize;
                    //dropdownButton.ImageWidth = ButtonWidth;
                }
            }
            return dropdownButton;
        }

        public static Rectangle MakeDefaultSecondaryBackground(string browseName = "SecondaryBackground")
        {
            Rectangle rectangle = MakeDefaultRectangle(browseName);
            rectangle.FillColor = PrimaryColor;
            rectangle.BorderColor = PrimaryBorder;
            rectangle.BorderThickness = DefaultShapeBorderThickness;
            rectangle.CornerRadius = DefaultRectangleCornerRadius;

            return rectangle;
        }

        public static Rectangle MakeDefaultPlaceholder(string browseName, string text = "Placeholder")
        {
            Rectangle placeholder = MakeDefaultRectangle(browseName);
            placeholder.TopMargin = 10;
            placeholder.BottomMargin = 10;
            placeholder.LeftMargin = 10;
            placeholder.RightMargin = 10;
            placeholder.FillColor = PrimaryColor;
            placeholder.BorderColor = PrimaryBorder;
            placeholder.BorderThickness = DefaultShapeBorderThickness;
            placeholder.CornerRadius = DefaultRectangleCornerRadius;
            Label label = InformationModel.Make<Label>("Label");
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.Text = text;
            label.FontSize = 25;
            placeholder.Add(label);

            return placeholder;
        }

        #endregion

        #region Default Types

        public static PanelType MakeDefaultPanelType(string browseName)
        {
            PanelType panel = InformationModel.Make<PanelType>(browseName);
            panel.Width = -1;
            panel.Height = -1;
            panel.HorizontalAlignment = HorizontalAlignment.Stretch;
            panel.VerticalAlignment = VerticalAlignment.Stretch;

            return panel;
        }

        public static PanelType MakeDefaultPanelTypeColor(string browseName, Color backgroundColor, float opacity = 100)
        {
            PanelType panel = InformationModel.Make<PanelType>(browseName);
            panel.Width = -1;
            panel.Height = -1;
            panel.HorizontalAlignment = HorizontalAlignment.Stretch;
            panel.VerticalAlignment = VerticalAlignment.Stretch;
            Rectangle rectangle = MakeDefaultColorRectangle("Background", backgroundColor);
            rectangle.Opacity = opacity;
            panel.Add(rectangle);
            return panel;
        }

        public static ButtonType MakeDefaultButtonType(string browseName)
        {
            ButtonType buttonType = InformationModel.Make<ButtonType>(browseName);
            buttonType.Width = -1;
            buttonType.Height = -1;
            buttonType.HorizontalAlignment = HorizontalAlignment.Stretch;
            buttonType.VerticalAlignment = VerticalAlignment.Stretch;
            buttonType.BackgroundColor = SecondaryColor;
            buttonType.TextColor = White;
            buttonType.FontSize = ButtonFontSize;

            return buttonType;
        }

        public static ColumnLayoutType MakeDefaultVerticalLayoutType(string browseName)
        {
            ColumnLayoutType columnType = InformationModel.Make<ColumnLayoutType>(browseName);
            columnType.Width = -1;
            columnType.Height = -1;
            columnType.HorizontalAlignment = HorizontalAlignment.Stretch;
            columnType.VerticalAlignment = VerticalAlignment.Stretch;

            return columnType;
        }

        public static RowLayoutType MakeDefaultHorizontalLayoutType(string browseName)
        {
            RowLayoutType rowType = InformationModel.Make<RowLayoutType>(browseName);
            rowType.Width = -1;
            rowType.Height = -1;
            rowType.HorizontalAlignment = HorizontalAlignment.Stretch;
            rowType.VerticalAlignment = VerticalAlignment.Stretch;

            return rowType;
        }

        public static ImageType MakeDefaultImageType(string browseName, string imageName = "placeholder.svg")
        {
            ImageType imageType = InformationModel.Make<ImageType>(browseName);
            string imageResourceUri = GetRelativeImagePath(imageName);
            imageType.Path = imageResourceUri;
            imageType.FillMode = FillMode.Stretch;
            imageType.HorizontalAlignment = HorizontalAlignment.Center;
            imageType.VerticalAlignment = VerticalAlignment.Center;

            return imageType;
        }

        public static DialogType MakeDefaultDialogBoxType(string browseName)
        {
            DialogType dialogType = InformationModel.Make<DialogType>(browseName);
            dialogType.Width = -1;
            dialogType.Height = -1;
            dialogType.HorizontalAlignment = HorizontalAlignment.Stretch;
            dialogType.VerticalAlignment = VerticalAlignment.Stretch;

            return dialogType;
        }

        public DialogType MakeDefaultDialogBoxType()
        {
            DialogType dialogType = MakeDefaultDialogBoxType("d");
            Rectangle backgroundBlur = MakeDefaultRectangle("BackgroundBlur");
            backgroundBlur.BorderThickness = 0;
            backgroundBlur.FillColor = Black;
            backgroundBlur.Opacity = 75F;
            // PanelLoader dialogPanelLoader = MakeDefaultPanelLoader

            return dialogType;
        }

        public static PanelType MakeDefaultDropdownPanelType(string browseName)
        {
            HeaderFlyouts headerFlyouts = new HeaderFlyouts();
            PanelType panelType = InformationModel.Make<PanelType>(browseName);
            PanelLoader panelLoader = MakeDefaultPanelLoader("FlyoutPanelLoader");

            panelType.Width = 300;
            panelType.Height = 300;
            panelType.HorizontalAlignment = HorizontalAlignment.Right;
            panelType.VerticalAlignment = VerticalAlignment.Top;
            Rectangle borderOverlay = MakeDefaultRectangle("BorderOverlay");
            panelLoader.Panel = NodeLookup(NodeName.UserInfoFlyoutPanelType).NodeId;

            panelType.Add(GradientBackground);
            panelType.Add(borderOverlay);
            panelType.Add(panelLoader);

            return panelType;
        }

        public static PanelType MakeDefaultDropdownPanelContainerType(string browseName)
        {
            PanelType panelType = InformationModel.Make<PanelType>(browseName);

            panelType.Width = 300;
            panelType.Height = 300;
            panelType.HorizontalAlignment = HorizontalAlignment.Right;
            panelType.VerticalAlignment = VerticalAlignment.Top;
            Rectangle borderOverlay = MakeDefaultRectangle("BorderOverlay");

            panelType.Add(GradientBackground);
            panelType.Add(borderOverlay);

            return panelType;
        }

        #endregion
    }
}