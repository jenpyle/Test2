using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;
using OpcUa = UAManagedCore.OpcUa;

namespace Mikron_MOAB_HMI.Templates
{
    public class NavigationButton : TemplateTypeBaseClass
    {
        private string navigationButtonName = "NavigationButton";
        private string navigationButtonImagePathVariableName;
        private string navigationButtonPageTypeVariableName;

        public NavigationButton()
        {
            SetNames("NavigationButton", UIFolders.LayoutTemplatesGeneric, ModelFolders.ObjectsNavigation);

            navigationButtonImagePathVariableName = CreateVariableNameString(navigationButtonName, "ImagePath");
            navigationButtonPageTypeVariableName = CreateVariableNameString(navigationButtonName, "PageTypeEnum");
        }

        public void CreateAndStoreType()
        {
            SetPropertiesFromBase();
            CreateNavigationButtonObjectType();
            CreateNavigationButtonTemplateType();
        }

        private void CreateNavigationButtonObjectType()
        {
            IUAVariable navigationIcon = InformationModel.MakeVariable(navigationButtonImagePathVariableName, FTOptix.Core.DataTypes.ResourceUri);
            navigationIcon.Value = PlaceholderIconPath;
            IUAVariable pageType = InformationModel.MakeVariable(navigationButtonPageTypeVariableName, OpcUa.DataTypes.Int32);

            ObjectType.Add(navigationIcon);
            ObjectType.Add(pageType);
        }

        private void CreateNavigationButtonTemplateType()
        {
            TemplateType.Height = LargeSize;
            TemplateType.VerticalAlignment = VerticalAlignment.Top;

            Button navigationButton = MakeDefaultButton(navigationButtonName);
            navigationButton.ImageHeight = IconSizeForLargeButton;
            SetPropertyDynamicLink(navigationButton.ImagePathVariable, navigationButtonImagePathVariableName);

            TemplateType.Add(navigationButton);

            AttachClickEvents(navigationButton);
        }

        public IUAObject MakeNavigationButtonObjectInstance(string instanceID, NavigationEnum pageType)
        {
            IUAObject objectInstance = CreateObjectInstance(instanceID);
            objectInstance.FindVariable(navigationButtonImagePathVariableName).Value = GetPageIcon(pageType);
            objectInstance.FindVariable(navigationButtonPageTypeVariableName).Value = GetPageIndex(pageType);

            return objectInstance;
        }

        public void AttachClickEvents(Button navigationButton)
        {
            var eventHandler = MakeEventHandler(navigationButton, FTOptix.UI.ObjectTypes.MouseClickEvent);
        }

        private void MakeDynamicLink(IUAVariable parent)
        {
            var dynamicLink = InformationModel.MakeVariable<DynamicLink>("DynamicLink", FTOptix.Core.DataTypes.NodePath);
            dynamicLink.Value = "{" + ObjectAliasName + "}";
            dynamicLink.Mode = DynamicLinkMode.ReadWrite;
            parent.Refs.AddReference(FTOptix.CoreBase.ReferenceTypes.HasDynamicLink, dynamicLink);
        }

        private FTOptix.CoreBase.EventHandler MakeEventHandler(IUANode parentNode_Button, NodeId listenEventTypeId)
        {
            // Create event handler object
            var eventHandler = InformationModel.MakeObject<FTOptix.CoreBase.EventHandler>("EventHandler");
            parentNode_Button.Add(eventHandler);

            // Set the ListenEventType variable value to the Node ID of the event to be listened
            eventHandler.ListenEventType = listenEventTypeId;

            // Create method container
            IUAObject methodContainer = InformationModel.MakeObject("MethodContainer1");
            eventHandler.MethodsToCall.Add(methodContainer);

            // Create the ObjectPointer variable and set its value to the object on which the method is to be executed
            var objectPointerVariable = InformationModel.MakeVariable<NodePointer>("ObjectPointer", OpcUa.DataTypes.NodeId);
            objectPointerVariable.Value = InformationModel.GetObject(FTOptix.CoreBase.Objects.VariableCommands).NodeId;
            methodContainer.Add(objectPointerVariable);

            // Create the Method variable and set its value to the name of the method to be called
            IUAVariable method = InformationModel.MakeVariable("Method", OpcUa.DataTypes.String);
            method.Value = "Set";
            methodContainer.Add(method);

            CreateInputArguments(methodContainer);

            return eventHandler;
        }

        private void CreateInputArguments(IUANode methodContainer)
        {
            NodePointer variableToModify = InformationModel.MakeVariable<NodePointer>("VariableToModify", FTOptix.Core.DataTypes.VariablePointer);
            IUAVariable variable = VariableLookup(VariableName.ActivePage);
            variableToModify.Value = variable.NodeId;

            IUAVariable value = InformationModel.MakeVariable("Value", OpcUa.DataTypes.Int32);
            SetPropertyDynamicLink(value, navigationButtonPageTypeVariableName);

            IUAVariable arrayIndex = InformationModel.MakeVariable("ArrayIndex", OpcUa.DataTypes.UInt32);

            IUAObject inputArguments = InformationModel.MakeObject("InputArguments");
            inputArguments.Add(variableToModify);
            inputArguments.Add(value);
            inputArguments.Add(arrayIndex);

            methodContainer.Add(inputArguments);
        }

        private string GetPageIcon(NavigationEnum pageType)
        {
            switch (pageType)
            {
                case NavigationEnum.Home:
                    return HomeIconPath;

                case NavigationEnum.Station:
                    return StationIconPath;

                case NavigationEnum.None:
                    return PlaceholderIconPath;

                default:
                    return PlaceholderIconPath;
            }
        }

        private int GetPageIndex(NavigationEnum pageType)
        {
            switch (pageType)
            {
                case NavigationEnum.Home:
                    return 0;

                case NavigationEnum.Station:
                    return 1;

                case NavigationEnum.None:
                    return 2;

                default:
                    return 2;
            }
        }
    }
}