#region Using directives

using FTOptix.Core;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using Mikron_MOAB_HMI.Clean;
using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

#endregion

public class FolderSetup : BaseNetLogic
{
    private CleanProject cleanProject = new CleanProject();

    public FolderSetup()
    {
    }

    public void GenerateFolderLayout()
    {
        cleanProject.CleanAll();
        GenerateUIFolderLayout();
        GenerateModelFolderLayout();
        //LogPathsForEnums();
    }

    private void AddFolders(string filepath, string[] subfolderNames, bool hasInstances = false)
    {
        foreach (string folderName in subfolderNames)
        {
            Project.Current.Get(filepath).Add(InformationModel.Make<Folder>(folderName));

            string newFolderPath = filepath + "/" + folderName;

            if (hasInstances)
            {
                AddInstanceFolders(newFolderPath);
            }

            AddToFolderLookupDictionary(newFolderPath);
        }
    }

    private void AddInstanceFolders(string newFolderPath)
    {
        string instanceFolderName = newFolderPath.Contains("Model") ? "ObjectInstances" : "TemplateInstances";

        Project.Current.Get(newFolderPath).Add(InformationModel.Make<Folder>(instanceFolderName));

        string newInstanceFolderPath = newFolderPath + "/" + instanceFolderName;
        AddToFolderLookupDictionary(newInstanceFolderPath);
    }

    private void AddToFolderLookupDictionary(string folderPath)
    {
        AllFolderPaths.Add(folderPath);
        Folder folder = Project.Current.Get<Folder>(folderPath);

        string lookupName = CleanPathString(folderPath);

        if (!string.IsNullOrEmpty(lookupName))
        {
            FolderLookupDictionary.Add(lookupName, folder);
        }
    }

    private void GenerateUIFolderLayout()
    {
        string[] uIComponentFolder = { "Components" };
        string[] uIBaseFolders = { "Layout", "Page", "VisionViewer", "DigitalServices", "Devices" };
        string[] uILayoutSubFolders = { "Templates", "Navigation" };
        string[] uILayoutTemplatesSubFolders = { "Generic", "Home", "Station" };
        string[] uILayoutTemplatesGenericSubFolders = { "Alarm" };

        string[] uIPageSubFolders = { "Templates", "Home", "Station", "Flyouts" };
        string[] uIPageHomeSubFolders = { "Line", "Cell", "Module" };
        string[] uIPageStationSubFolders = { "Overview", "Cams", "Manual", "Configuration", "Data" };

        // To do: Check for existing folders so that duplicate folders are not created
        AddFolders("UI", uIComponentFolder);

        AddFolders("UI/Components", uIBaseFolders);

        AddFolders("UI/Components/Layout", uILayoutSubFolders);
        AddFolders("UI/Components/Page", uIPageSubFolders);

        AddFolders("UI/Components/Layout/Templates", uILayoutTemplatesSubFolders, true);

        AddFolders("UI/Components/Layout/Templates/Generic", uILayoutTemplatesGenericSubFolders, true);

        AddFolders("UI/Components/Page/Home", uIPageHomeSubFolders);
        AddFolders("UI/Components/Page/Station", uIPageStationSubFolders, true);
    }

    private void GenerateModelFolderLayout()
    {
        string[] modelComponentFolder = { "Components" };
        string[] modelComponentSubFolders = { "Objects", "Variables" };
        string[] modelObjectsSubFolders = { "Home", "Station", "Alarm", "Navigation", "LocalPageNavigation", "SecondaryLocalPageNavigation", "Header", "DeviceObjects" };
        string[] modelVariablesSubFolders = { "Navigation" };

        string[] modelComponentHomeSubFolders = { "Performance" };

        AddFolders("Model", modelComponentFolder);
        AddFolders("Model/Components", modelComponentSubFolders);
        AddFolders("Model/Components/Objects", modelObjectsSubFolders, true);
        AddFolders("Model/Components/Variables", modelVariablesSubFolders);

        AddFolders("Model/Components/Objects/Home", modelComponentHomeSubFolders, true);
    }

    public Folder GenerateAndGetTestFolderLayout(bool cleanProjectFirst)
    {
        if (cleanProjectFirst)
        {
            cleanProject.CleanAll();
        }
        string[] testFolders = { "TestFolder" };

        AddFolders("UI", testFolders);
        Folder testFolder = Project.Current.Get<Folder>("UI/TestFolder");
        return testFolder;
    }

    public void GenerateTestFolderLayout2()
    {
        cleanProject.CleanAll();
        string[] testFolders = { "TestFolder" };

        AddFolders("UI", testFolders);
    }
}