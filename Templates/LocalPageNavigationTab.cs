using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiColors;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using OpcUa = UAManagedCore.OpcUa;

namespace Mikron_MOAB_HMI.Templates
{
    public class LocalPageNavigationTab : TemplateTypeBaseClass
    {
        private string navigationTabElementName;
        private string localNavigationTabOptionTextVariableName;
        private string panelToLoadVariableName;
        private string targetPanelLoaderVariableName;
        private string uIObjectAliasName;
        private Alias panelLoaderObjectAlias;

        public LocalPageNavigationTab()
        {
            SetNames("LocalNavigationTab", UIFolders.LayoutTemplatesGeneric, ModelFolders.ObjectsLocalPageNavigation);

            navigationTabElementName = "LocalNavigationTabOption";
            localNavigationTabOptionTextVariableName = CreateVariableNameString(navigationTabElementName, "Text");
            panelToLoadVariableName = CreateVariableNameString(navigationTabElementName, "PanelToLoad");
            targetPanelLoaderVariableName = CreateVariableNameString(navigationTabElementName, "TargetPanelLoader");
            uIObjectAliasName = CreateVariableNameString(navigationTabElementName, "UIObjectAlias");
        }

        public void CreateAndStoreType()
        {
            SetPropertiesFromBase();
            CreateLocalNavigationTabObjectType();
            CreateLocalNavigationTabTemplateType();
        }

        public void CreateLocalNavigationTabObjectType()
        {
            IUAVariable tabOption = InformationModel.MakeVariable(localNavigationTabOptionTextVariableName, OpcUa.DataTypes.String);
            IUAVariable panelToLoad = InformationModel.MakeVariable(panelToLoadVariableName, OpcUa.DataTypes.NodeId);
            IUAVariable targetPanelLoader = InformationModel.MakeVariable(targetPanelLoaderVariableName, OpcUa.DataTypes.NodeId);

            ObjectType.Add(tabOption);
            ObjectType.Add(panelToLoad);
            ObjectType.Add(targetPanelLoader);
        }

        public void CreateLocalNavigationTabTemplateType()
        {
            SetObjectPointerAlias();
            TemplateType.HorizontalAlignment = HorizontalAlignment.Left;
            Button tabOption = MakeDefaultButton(navigationTabElementName);
            SetPropertyDynamicLink(tabOption.TextVariable, localNavigationTabOptionTextVariableName);
            tabOption.ImagePath = string.Empty;
            tabOption.TextColor = White;
            tabOption.Height = MediumSize;
            tabOption.VerticalAlignment = VerticalAlignment.Bottom;
            tabOption.HorizontalAlignment = HorizontalAlignment.Left;

            TemplateType.Add(tabOption);

            AttachClickEvents(tabOption);
        }

        public void SetObjectPointerAlias()
        {
            panelLoaderObjectAlias = (Alias)InformationModel.MakeAlias(uIObjectAliasName);
            PanelLoaderType panelLoaderObjectType = InformationModel.GetObjectType<PanelLoaderType>();
            panelLoaderObjectAlias.Kind = panelLoaderObjectType.NodeId;
            TemplateType.Add(panelLoaderObjectAlias);
            //TODO use SetAlias to set the node to which the alias points to??
        }

        public IUAObject MakeLocalNavigationTabObjectInstance(string instanceID, string option, NodeId panelToLoad, NodeId targetPanelLoader, IUAObject targetPL)
        {
            IUAObject objectInstance = CreateObjectInstance(instanceID);
            objectInstance.FindVariable(localNavigationTabOptionTextVariableName).Value = option;
            objectInstance.FindVariable(panelToLoadVariableName).Value = panelToLoad;
            objectInstance.FindVariable(targetPanelLoaderVariableName).Value = targetPanelLoader;

            return objectInstance;
        }

        public void AttachClickEvents(Button tabOption)
        {
            var eventHandler = MakeEventHandler(tabOption, FTOptix.UI.ObjectTypes.MouseClickEvent);
        }

        private void MakeDynamicLink(IUAVariable parent)
        {
            var dynamicLink = InformationModel.MakeVariable<DynamicLink>("DynamicLink", FTOptix.Core.DataTypes.NodePath);
            dynamicLink.Value = "{" + ObjectAliasName + "}";
            dynamicLink.Mode = DynamicLinkMode.ReadWrite;
            parent.Refs.AddReference(FTOptix.CoreBase.ReferenceTypes.HasDynamicLink, dynamicLink);
        }

        //public NodePointer MakeObjectPointerToAccessMethodOwnedByObject(IUAObject methodContainer, IUANode parentNode_Button)
        //{
        //    var testPanelLoader = MakeTestPanelLoader();

        //    // Create the ObjectPointer variable and set its value to the object on which the method is to be executed
        //    NodePointer objectPointerVariable = InformationModel.MakeVariable<NodePointer>("ObjectPointer", OpcUa.DataTypes.NodeId);
        //    objectPointerVariable.Value = testPanelLoader.NodeId;

        //    string resultPath = CreateRelativePath(parentNode_Button, testPanelLoader);
        //    var isCore = resultPath.Contains("Root");
        //    //If it is not a core object find relative path and create dynamic link
        //    if (!isCore)
        //    {
        //        IUAVariable temp = null;
        //        objectPointerVariable.SetDynamicLink(temp, DynamicLinkMode.ReadWrite);
        //        objectPointerVariable.GetVariable("DynamicLink").Value = "../../../../" + resultPath;
        //    }

        //    return objectPointerVariable;
        //}

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
            IUAVariable temp = null;
            objectPointerVariable.SetDynamicLink(temp, DynamicLinkMode.ReadWrite);
            objectPointerVariable.GetVariable("DynamicLink").Value = "{" + uIObjectAliasName + "}@NodeId";
            methodContainer.Add(objectPointerVariable);

            // Create the Method variable and set its value to the name of the method to be called
            IUAVariable method = InformationModel.MakeVariable("Method", OpcUa.DataTypes.String);
            method.Value = "ChangePanel";
            methodContainer.Add(method);

            CreateInputArguments(methodContainer);

            return eventHandler;
        }

        private void CreateInputArguments(IUANode methodContainer)
        {
            NodePointer newPanelVariable = MakeDynamicLinkNewPanel();
            NodePointer aliasNodeVariable = MakeDynamicLinkAliasNode();

            IUAObject inputArguments = InformationModel.MakeObject("InputArguments");
            inputArguments.Add(newPanelVariable);
            inputArguments.Add(aliasNodeVariable);

            methodContainer.Add(inputArguments);
        }

        private NodePointer MakeDynamicLinkNewPanel()
        {
            NodePointer newPanelVariable = InformationModel.MakeVariable<NodePointer>("NewPanel", OpcUa.DataTypes.NodeId);
            SetPropertyDynamicLink(newPanelVariable, panelToLoadVariableName);

            return newPanelVariable;
        }

        private NodePointer MakeDynamicLinkAliasNode()
        {
            NodePointer aliasNodeVariable = InformationModel.MakeVariable<NodePointer>("AliasNode", OpcUa.DataTypes.NodeId);
            aliasNodeVariable.Value = NodeId.Empty;

            return aliasNodeVariable;
        }
    }
}