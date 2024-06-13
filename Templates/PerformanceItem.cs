using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.Layouts;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;
using OpcUa = UAManagedCore.OpcUa;

namespace Mikron_MOAB_HMI.Templates
{
    public class PerformanceItem : TemplateTypeBaseClass
    {
        private string performanceItemKeyName;
        private string performanceItemValueName;

        private string performanceItemKeyTextVariableName;
        private string performanceItemValueTextlVariableName;

        public PerformanceItem()
        {
            SetNames("PerformanceItem", UIFolders.LayoutTemplatesGeneric, ModelFolders.ObjectsHomePerformance);

            performanceItemKeyName = "PerformanceItemKey";
            performanceItemValueName = "PerformanceItemValue";

            performanceItemKeyTextVariableName = CreateVariableNameString(performanceItemKeyName, "Text");
            performanceItemValueTextlVariableName = CreateVariableNameString(performanceItemValueName, "Text");
        }

        public void CreateAndStoreType()
        {
            SetPropertiesFromBase();
            CreatePerformanceItemObjectType();
            CreatePerformanceItemTemplateType();
        }

        public void CreatePerformanceItemTemplateType()
        {
            Label keyLabel = MakeDefaultLabel(performanceItemKeyName);
            SetPropertyDynamicLink(keyLabel.TextVariable, performanceItemKeyTextVariableName);

            Label valueLabel = MakeDefaultLabel(performanceItemValueName);
            SetPropertyDynamicLink(valueLabel.TextVariable, performanceItemValueTextlVariableName);

            RowLayout performanceItemColumnLayout = CreateDynamicLabelKeyValueLeftAlignedColumnLayout(NameOfType, keyLabel, valueLabel);

            TemplateType.Add(performanceItemColumnLayout);
        }

        public void CreatePerformanceItemObjectType()
        {
            IUAVariable performanceItemKey_Text = InformationModel.MakeVariable(performanceItemKeyTextVariableName, OpcUa.DataTypes.String);
            IUAVariable performanceItemValue_Text = InformationModel.MakeVariable(performanceItemValueTextlVariableName, OpcUa.DataTypes.String);

            ObjectType.Add(performanceItemKey_Text);
            ObjectType.Add(performanceItemValue_Text);
        }

        public void MakePerformanceItemObjectInstance(string instanceID, string performanceItemKey, string performanceItemValue)
        {
            IUAObject objectInstance = CreateObjectInstance(instanceID);

            objectInstance.FindVariable(performanceItemKeyTextVariableName).Value = performanceItemKey;
            objectInstance.FindVariable(performanceItemValueTextlVariableName).Value = performanceItemValue;
        }

        public override void CreateTemplateInstanceContainer()
        {
            //TemplateInstanceContainer = CreatePanelWithFlyoutButtonLayoutType("PerformanceItemListPanelType", SettingsIconPath, CreateSettingsWidgetSelectionFlyout().NodeId);
            TemplateInstanceContainer = CreatePanelWithFlyoutButtonLayoutType("PerformanceItemListPanelType", SettingsIconPath);

            AddNodeToProject(TemplateInstancesFolder, TemplateInstanceContainer);
        }

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
    }
}