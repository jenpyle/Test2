using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.UI;
using Mikron_MOAB_HMI.Helpers;
using System;
using System.Collections.Generic;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Templates
{
    public class TemplateTypeBaseClass : BaseNetLogic
    {
        public TemplateTypeBaseClass()
        {
        }

        public string NameOfType;
        public UIFolders TemplateFolder;
        public ModelFolders ObjectFolder;

        public PanelType TemplateType;
        public IUAObjectType ObjectType;

        public UIFolders TemplateInstancesFolder;
        public ModelFolders ObjectInstancesFolder;

        public string TemplateTypeName;
        public string ObjectTypeName;

        public string ObjectAliasName;
        public string ObjectInstanceNamePrefix;

        public PanelType TemplateInstanceContainer;
        public ColumnLayout LocationFromDefaultContainerToAddInstances;

        public List<TargetElement> TypeTargetElements = new List<TargetElement>();

        public void CreateVariablesForElement(string elementBrowseName, string[] elementProperties)
        {
            foreach (string property in elementProperties)
            {
                string variable = CreateVariableNameString(elementBrowseName, property);
            }
        }

        public void SetNames(string nameOfType, UIFolders templateFolder, ModelFolders objectFolder)
        {
            NameOfType = nameOfType;
            TemplateFolder = templateFolder;
            ObjectFolder = objectFolder;

            TemplateInstancesFolder = GetTemplateInstanceFolderEnum(templateFolder);
            ObjectInstancesFolder = GetObjectInstanceFolderEnum(objectFolder);

            TemplateTypeName = CreateTemplateTypeName(nameOfType);
            ObjectTypeName = CreateObjectTypeName(nameOfType);

            ObjectAliasName = CreateObjectAliasName(nameOfType);
            ObjectInstanceNamePrefix = GetObjectInstanceNamePrefix(nameOfType);
        }

        public void SetPropertiesFromBase()
        {
            CreateObjectType();
            StoreObjectType();
            CreateTemplateType();
            AddTypeNodeToProject(TemplateFolder, TemplateType);
        }

        public void CreateObjectType()
        {
            ObjectType = InformationModel.MakeObjectType(ObjectTypeName);
        }

        public void StoreObjectType()
        {
            FolderEnumLookup(ObjectFolder).Add(ObjectType);
        }

        public void CreateTemplateType()
        {
            TemplateType = MakeDefaultPanelType(TemplateTypeName);
            Alias alias = (Alias)InformationModel.MakeAlias(ObjectAliasName);
            alias.Kind = ObjectType.NodeId;
            TemplateType.Add(alias);
        }

        private void AddTypeNodeToProject(Enum folderName, UANode node)
        {
            NodeProfile nodeProfile = new NodeProfile();
            nodeProfile.BrowseName = NameOfType;
            nodeProfile.UANode = node;
            nodeProfile.NodeId = node.NodeId;
            nodeProfile.IsWidget = true;
            nodeProfile.TemplateType = TemplateType;
            nodeProfile.ObjectType = ObjectType;
            nodeProfile.ObjectNodeId = ObjectType.NodeId;
            nodeProfile.ObjectNodePath = GetCurrentProjectBroswePath(ObjectType);
            nodeProfile.ObjectAliasName = ObjectAliasName;

            AddNodeToProject(folderName, node, nodeProfile);
        }

        public IUAObject CreateObjectInstance(string instanceID)
        {
            NodeName enumValue;
            if (Enum.TryParse<NodeName>(NameOfType, out enumValue))
            {
                NodeProfile typeNode = NodeLookup(enumValue);
                IUAObject objectInstance = InformationModel.MakeObject(ObjectInstanceNamePrefix + instanceID, typeNode.ObjectType.NodeId);
                FolderEnumLookup(ObjectInstancesFolder).Add(objectInstance);
                return objectInstance;
            }
            else
            {
                throw new Exception("NodeName enum parsing not valid for " + NameOfType + " during CreateObjectInstance");
            }
        }

        public virtual void SetPropertyDynamicLink(IUAVariable propertyNameVariable, string objectAliasVariableName)
        {
            IUAVariable temp = null;
            //this adds a dynamic link hook?
            propertyNameVariable.SetDynamicLink(temp, DynamicLinkMode.ReadWrite);

            propertyNameVariable.GetVariable("DynamicLink").Value = "{" + ObjectAliasName + "}/" + objectAliasVariableName;
        }

        public virtual void CreateTemplateInstanceContainer()
        {
            //PanelType defaultContainerPanelType = MakeDefaultPanelType(TemplateTypeName + "DefaultInstancesContainer");
            //ColumnLayout columnLayout = MakeDefaultVerticalLayout("VerticalLayout");

            //defaultContainerPanelType.VerticalAlignment = VerticalAlignment.Center;
            //defaultContainerPanelType.HorizontalAlignment = HorizontalAlignment.Center;
            //defaultContainerPanelType.Height = 100;
            //defaultContainerPanelType.Width = 100;

            //defaultContainerPanelType.Add(columnLayout);

            //TemplateInstanceContainer = defaultContainerPanelType;
            //LocationFromDefaultContainerToAddInstances = TemplateInstanceContainer.Find<ColumnLayout>("VerticalLayout");

            //AddNodeToProject(TemplateInstancesFolder, TemplateInstanceContainer);
        }

        public UIFolders GetTemplateInstanceFolderEnum(UIFolders templateFolder)
        {
            string templateInstanceFolderString = templateFolder.ToString() + "TemplateInstances";
            UIFolders templateInstanceFolderEnum = (UIFolders)System.Enum.Parse(typeof(UIFolders), templateInstanceFolderString);
            return templateInstanceFolderEnum;
        }

        public ModelFolders GetObjectInstanceFolderEnum(ModelFolders objectFolder)
        {
            string objectInstanceFolderString = objectFolder.ToString() + "ObjectInstances";
            ModelFolders objectInstanceFolderEnum = (ModelFolders)System.Enum.Parse(typeof(ModelFolders), objectInstanceFolderString);
            return objectInstanceFolderEnum;
        }

        public string CreateTemplateTypeName(string name)
        {
            return name + "TemplateType";
        }

        public string CreateObjectTypeName(string name)
        {
            return name + "ObjectType";
        }

        public string GetObjectInstanceNamePrefix(string name)
        {
            return name + "Object";
        }

        public string CreateObjectAliasName(string name)
        {
            return name + "ObjectAlias";
        }

        public string CreateVariableNameString(string elementName, string propertyType)
        {
            return elementName + "_" + propertyType;
        }
    }
}