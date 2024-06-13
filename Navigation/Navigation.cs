using FTOptix.HMIProject;
using System;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.Enumerations;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;
using OpcUa = UAManagedCore.OpcUa;

namespace Mikron_MOAB_HMI.Navigation
{
    public static class Navigation
    {
        public static int ActivePage { get; set; }
        public static IUAVariable ActivePageVariable { get; set; }

        public static void NavigationSetup()
        {
            ActivePageVariable = InformationModel.MakeVariable("ActivePage", OpcUa.DataTypes.Int32);
            ActivePageVariable.VariableChange += ActivePageVariable_VariableChange;
            ActivePage = ActivePageVariable.Value;
            AddVariableToProject(ModelFolders.VariablesNavigation, ActivePageVariable);
        }

        private static void ActivePageVariable_VariableChange(object sender, VariableChangeEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}