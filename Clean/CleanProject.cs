#region Using directives

using FTOptix.Core;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using UAManagedCore;

#endregion

namespace Mikron_MOAB_HMI.Clean
{
    public class CleanProject : BaseNetLogic
    {
        //TODO - Ask Keith about Folder layout
        //All folders are within one containing folder
        public CleanProject()
        {
        }

        [ExportMethod]
        public void CleanAll()
        {
            CleanMainWindow();
            CleanFolders();
        }

        [ExportMethod]
        public void CleanMainWindow()
        {
            Project.Current.Get("UI/MainWindow").Children.Clear();
        }

        [ExportMethod]
        public void CleanFolders()
        {
            // To do: Add recursiveness so that duplicate folders also get deleted
            var folder = Project.Current.Get<Folder>("UI/Components");
            if (folder != null)
            {
                folder.Delete();
            }

            var modelComponentsFolder = Project.Current.Get<Folder>("Model/Components");
            if (modelComponentsFolder != null)
            {
                modelComponentsFolder.Delete();
            }

            var testFolder = Project.Current.Get<Folder>("UI/TestFolder");
            if (testFolder != null)
            {
                testFolder.Delete();
            }
        }

        // Commenting out temporarily, posssibly need later
        //private void CheckAndRemoveFolders(IList<Folder> folderList)
        //{
        //    foreach (Folder folder in folderList)
        //    {
        //        if (folder != null)
        //        {
        //            folder.Delete();
        //        }
        //    }
        //}
    }
}
//EXAMPLE