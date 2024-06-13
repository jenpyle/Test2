using UAManagedCore;

namespace Mikron_MOAB_HMI.Pages.Shared
{
    public class ChangePanelButton
    {
        public ChangePanelButton(string buttonText, NodeId panelToLoad)
        {
            ButtonText = buttonText;
            PanelToLoad = panelToLoad;
        }
        public string ButtonText { get; set; }
        public NodeId PanelToLoad { get; set; }
    }
}