using System.Collections.Generic;

namespace Mikron_MOAB_HMI.Helpers
{
    public class TargetElement
    {
        public TargetElement(string browseName, List<Variable> variablesToSet)
        {
            BrowseName = browseName;
            PropertiesToSet = variablesToSet;
        }
        public string BrowseName { get; set; }
        public List<Variable> PropertiesToSet { get; set; }
    }
}