using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.Icons;
using OpcUa = UAManagedCore.OpcUa;

namespace Mikron_MOAB_HMI.Templates
{
    public class ItemIterator : TemplateTypeBaseClass
    {
        private string selectedItemElementName;
        private string selectedItemVariableName;

        public ItemIterator()
        {
            SetNames("ItemIterator", UIFolders.LayoutTemplatesGeneric, ModelFolders.ObjectsStation);

            selectedItemElementName = "SelectedItem";
            selectedItemVariableName = CreateVariableNameString(selectedItemElementName, "Panel");
        }

        public void CreateAndStoreType()
        {
            //SetPropertiesFromBase("ItemIterator", UIFolders.LayoutTemplatesGeneric, ModelFolders.ObjectsStation);
            SetPropertiesFromBase();
            CreateItemIteratorObjectType();
            CreateItemIteratorTemplateType();
        }

        public void CreateItemIteratorObjectType()
        {
            IUAVariable selectedItemPanelVariable = InformationModel.MakeVariable(selectedItemVariableName, OpcUa.DataTypes.NodeId);

            ObjectType.Add(selectedItemPanelVariable);
        }

        public void CreateItemIteratorTemplateType()
        {
            TemplateType.Height = SmallContainerHeight;
            TemplateType.Width = MediumContainerWidth;
            TemplateType.HorizontalAlignment = HorizontalAlignment.Center;
            TemplateType.VerticalAlignment = VerticalAlignment.Center;

            RowLayout itemIteratorHorizontalLayout = MakeDefaultHorizontalLayout("ItemIteratorHorizontalLayout");
            Button leftArrowButton = MakeDefaultButton("LeftArrowButton", MediumSize, LeftCaretIconPath);
            Button rightArrowButton = MakeDefaultButton("RightArrowButton", MediumSize, RightCaretIconPath);

            PanelLoader selectedItemPanelLoader = MakeDefaultPanelLoader("SelectedItemPanelLoader");
            SetPropertyDynamicLink(selectedItemPanelLoader.PanelVariable, selectedItemVariableName);

            itemIteratorHorizontalLayout.Add(leftArrowButton);
            itemIteratorHorizontalLayout.Add(selectedItemPanelLoader);
            itemIteratorHorizontalLayout.Add(rightArrowButton);

            TemplateType.Add(itemIteratorHorizontalLayout);
        }

        public IUAObject MakeItemIteratorObjectInstance(string instanceID, NodeId panelNodeId)
        {
            IUAObject objectInstance = CreateObjectInstance(instanceID);
            objectInstance.FindVariable(selectedItemVariableName).Value = panelNodeId;
            return objectInstance;
        }
    }
}