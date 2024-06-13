using FTOptix.CoreBase;
using FTOptix.HMIProject;
using FTOptix.UI;
using Mikron_MOAB_HMI.Helpers;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Templates
{
    public class ReusableTypes
    {
        private FlyoutButton flyoutButton = new FlyoutButton();
        private ItemIterator itemIterator = new ItemIterator();
        private NavigationButton navigationButton = new NavigationButton();
        private AlarmItemRow alarmItemRow = new AlarmItemRow();
        private LocalPageNavigationTab localPageNavigationTab = new LocalPageNavigationTab();
        private StationRow stationRow = new StationRow();

        public ReusableTypes()
        {
        }

        public Panel MakeItemIteratorTemplateInstance(string instanceID, NodeId panelContainingItemToIterateNodeId)
        {
            IUAObject objectInstance = itemIterator.MakeItemIteratorObjectInstance(instanceID, panelContainingItemToIterateNodeId);
            NodeProfile typeNode = NodeLookup(NodeName.ItemIterator);
            IUAObject templateInstance = GenerateTemplateInstanceFromObjectInstance(typeNode.TemplateType, objectInstance, typeNode.ObjectAliasName);
            return (Panel)templateInstance;
        }

        public Panel MakeFlyoutButtonTemplateInstance(string instanceID, string icon, NodeId panelNodeId, float buttonSize)
        {
            IUAObject objectInstance = flyoutButton.MakeFlyoutButtonObjectInstance(instanceID, icon, panelNodeId, buttonSize);
            NodeProfile typeNode = NodeLookup(NodeName.FlyoutButton);
            IUAObject templateInstance = GenerateTemplateInstanceFromObjectInstance(typeNode.TemplateType, objectInstance, typeNode.ObjectAliasName);
            return (Panel)templateInstance;
        }

        public Panel MakeNavigationButtonTemplateInstance(string instanceID, NavigationEnum pageType = NavigationEnum.None)
        {
            IUAObject objectInstance = navigationButton.MakeNavigationButtonObjectInstance(instanceID, pageType);
            NodeProfile typeNode = NodeLookup(NodeName.NavigationButton);
            IUAObject templateInstance = GenerateTemplateInstanceFromObjectInstance(typeNode.TemplateType, objectInstance, typeNode.ObjectAliasName);
            return (Panel)templateInstance;
        }

        public Panel MakeAlarmItemRowTemplateInstance(string instanceID, StationNumberEnum stationNumber, StatusTypeEnum alarmKind, AlarmMessageType alarmMessageType)
        {
            IUAObject objectInstance = alarmItemRow.MakeAlarmObjectInstance(instanceID, stationNumber, alarmKind, alarmMessageType);
            NodeProfile typeNode = NodeLookup(NodeName.AlarmItemRow);
            IUAObject templateInstance = GenerateTemplateInstanceFromObjectInstance(typeNode.TemplateType, objectInstance, typeNode.ObjectAliasName);
            return (Panel)templateInstance;
        }

        public Panel MakeLocalPageNavigationTabTemplateInstance(string instanceID, string option, NodeId panelToLoad, NodeId targetPanelLoader, IUAObject x)
        {
            IUAObject objectInstance = localPageNavigationTab.MakeLocalNavigationTabObjectInstance(instanceID, option, panelToLoad, targetPanelLoader, x);
            NodeProfile typeNode = NodeLookup(NodeName.LocalNavigationTab);
            IUAObject templateInstance = GenerateTemplateInstanceFromObjectInstance(typeNode.TemplateType, objectInstance, typeNode.ObjectAliasName);

            var aliasVariable = templateInstance.FindVariable("LocalNavigationTabOption_UIObjectAlias");

            IUAVariable temp = null;
            aliasVariable.SetDynamicLink(temp, DynamicLinkMode.ReadWrite);
            aliasVariable.GetVariable("DynamicLink").Value = "{LocalContentPanelLoaderTEST}";
            //GetAlias??

            // templateInstance.SetAlias("LocalNavigationTabOption_UIObjectAlias", targetPanelLoader);

            return (Panel)templateInstance;
        }

        public Panel MakeStationRowTemplateInstance(string instanceID, string stationNumber, StatusTypeEnum statusKind, string stationName,
            string palletNumber, PalletStatusEnum palletStatus, string numberAlerts, string timeDown, string badParts)
        {
            IUAObject objectInstance = stationRow.MakeStationRowObjectInstance(instanceID, stationNumber, statusKind, stationName, palletNumber, palletStatus, numberAlerts, timeDown, badParts);
            NodeProfile typeNode = NodeLookup(NodeName.StationRowItem);
            IUAObject templateInstance = GenerateTemplateInstanceFromObjectInstance(typeNode.TemplateType, objectInstance, typeNode.ObjectAliasName);
            return (Panel)templateInstance;
        }

        public IUAObject GenerateTemplateInstanceFromObjectInstance(PanelType templateType, IUAObject objectInstance, string aliasName)
        {
            IUAObject templateInstance;
            string templateInstanceName = objectInstance.BrowseName.Replace("Object", "Template");

            //checks to make sure it hasn't been made yet
            //if (Project.Current.Find(templateInstanceName) == null)
            //{
            templateInstance = InformationModel.MakeObject(templateInstanceName, (templateType).NodeId);
            templateInstance.SetAlias(aliasName, objectInstance);
            //}
            return templateInstance;
        }
    }
}