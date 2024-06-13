using FTOptix.UI;
using System;
using UAManagedCore;

namespace Mikron_MOAB_HMI.Helpers
{
    public class NodeProfile
    {
        public NodeProfile()
        {
            //NodeId = NodeId.Empty;
        }
        public PanelType TemplateType { get; set; }
        public IUAObjectType ObjectType { get; set; }
        public string ObjectNodePath { get; set; }
        public string TemplateNodePath { get; set; }
        public UANode UANode { get; set; }
        public ItemType ItemType { get; set; }
        public string NodePath { get; set; }
        public NodeId NodeId { get; set; }
        public bool IsWidget { get; set; }
        public Enum FolderEnum { get; set; }
        public NodeId ObjectNodeId { get; set; }
        public string BrowseName { get; set; }
        public string ObjectAliasName { get; set; }
    }
}