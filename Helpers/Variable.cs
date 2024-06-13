using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTOptix.HMIProject;
using FTOptix.UI;
using Mikron_MOAB_HMI.Helpers;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.HmiStyledElements;
using static Mikron_MOAB_HMI.Helpers.HmiStyles;
using static Mikron_MOAB_HMI.Helpers.Icons;
using static Mikron_MOAB_HMI.Helpers.Placeholders;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;
using OpcUa = UAManagedCore.OpcUa;

namespace Mikron_MOAB_HMI.Helpers
{
    public class Variable
    {
        public Variable(string variableBrowseName, NodeId variableDataType)
        {
            VariableBrowseName = variableBrowseName;
            VariableDataType = variableDataType;
        }

        public string VariableBrowseName { get; set; }
        public NodeId VariableDataType { get; set; }
    }
}