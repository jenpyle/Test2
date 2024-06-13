using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using OpcUa = UAManagedCore.OpcUa;

namespace Mikron_MOAB_HMI.Templates
{
    public class FlyoutButton : TemplateTypeBaseClass
    {
        private string flyoutButtonElementName;

        private string flyoutButtonImagePathVariableName;
        private string flyoutButtonPanelVariableName;
        private string flyoutButtonSizeVariableName;

        public FlyoutButton()
        {
            SetNames("FlyoutButton", UIFolders.LayoutTemplatesGeneric, ModelFolders.ObjectsHeader);
            flyoutButtonElementName = "Button";
            flyoutButtonImagePathVariableName = "ImagePath";
            flyoutButtonPanelVariableName = "PanelName";
            flyoutButtonSizeVariableName = "FlyoutButtonSize";
        }

        public void CreateAndStoreType()
        {
            SetPropertiesFromBase();
            CreateFlyoutButtonObjectType();
            CreateFlyoutButtonTemplateType();
        }

        public void CreateFlyoutButtonObjectType()
        {
            IUAVariable buttonIcon = InformationModel.MakeVariable(flyoutButtonImagePathVariableName, FTOptix.Core.DataTypes.ResourceUri);
            IUAVariable buttonFlyout = InformationModel.MakeVariable(flyoutButtonPanelVariableName, OpcUa.DataTypes.NodeId);
            IUAVariable buttonSize = InformationModel.MakeVariable(flyoutButtonSizeVariableName, OpcUa.DataTypes.Float);

            ObjectType.Add(buttonIcon);
            ObjectType.Add(buttonFlyout);
            ObjectType.Add(buttonSize);
        }

        //Need way to make sure "Type" only gets created once
        public void CreateFlyoutButtonTemplateType()
        {
            TemplateType.HorizontalAlignment = HorizontalAlignment.Right;

            DropDownButton flyoutButton = MakeDefaultDropdownButton(flyoutButtonElementName);
            //flyoutButton.ImageHeight = 40;

            SetPropertyDynamicLink(flyoutButton.ImagePathVariable, flyoutButtonImagePathVariableName);
            SetPropertyDynamicLink(flyoutButton.PanelVariable, flyoutButtonPanelVariableName);
            SetPropertyDynamicLink(flyoutButton.ImageWidthVariable, flyoutButtonSizeVariableName);

            TemplateType.Add(flyoutButton);
        }

        public IUAObject MakeFlyoutButtonObjectInstance(string instanceID, string icon, NodeId panelNodeId, float buttonSize)
        {
            IUAObject objectInstance = CreateObjectInstance(instanceID);
            objectInstance.FindVariable(flyoutButtonImagePathVariableName).Value = icon;
            objectInstance.FindVariable(flyoutButtonPanelVariableName).Value = panelNodeId;
            objectInstance.FindVariable(flyoutButtonSizeVariableName).Value = buttonSize;

            return objectInstance;
        }
    }
}