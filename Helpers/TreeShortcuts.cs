using FTOptix.Core;
using FTOptix.HMIProject;
using FTOptix.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using UAManagedCore;

namespace Mikron_MOAB_HMI.Helpers
{
    public class TreeShortcuts
    {
        /// <summary>
        /// Use to get the Folder, the key is the filepath without "/", "UI", "Model", or "Components"
        /// </summary>
        public static Dictionary<string, Folder> FolderLookupDictionary = new Dictionary<string, Folder>();
        public static ObservableDictionary<string, IUAVariable> VariableLookupDictionary = new ObservableDictionary<string, IUAVariable>();
        public static ObservableDictionary<string, NodeProfile> NodeLookupDictionary = new ObservableDictionary<string, NodeProfile>();
        public static List<string> UIFolderNamesListToCopyPasteInFolderEnums = new List<string>();
        public static List<string> ModelFolderNamesListToCopyPasteInFolderEnums = new List<string>();
        public static List<string> AllFolderPaths = new List<string>();

        public TreeShortcuts()
        {
        }

        public static void AddToMainWindow(Item args)
        {
            Project.Current.Get("UI/MainWindow").Add(args);
        }

        public static void AddToMainWindow(ItemType args)
        {
            Project.Current.Get("UI/MainWindow").Add(args);
        }

        //public static void TestOnMainWindow(Item args)
        //{
        //    FolderSetup folderSetup = new FolderSetup();
        //    CleanProject cleanProject = new CleanProject();
        //    cleanProject.CleanAll();
        //    folderSetup.GenerateFolderLayout();
        //    AddToMainWindow(args);
        //}

        public static void AddToLayoutTemplates(Item args)
        {
            Project.Current.Get("UI/Layout/Templates").Add(args);
        }

        /// <summary>
        /// Use to retrieve a folder from the tree. Pass in the matching filepath enum
        /// Ex: if you want to get Model/Components/Objects/Alarm/ObjectInstances
        /// You would call FolderLookup(ModelFolders.ObjectsAlarmObjectInstances)
        /// </summary>
        /// <param name="folderName">Select from pre-generated list in Enumerations class</param>
        /// <returns>Existing folder from the tree</returns>
        public static Folder FolderEnumLookup(Enum folderName)
        {
            string folderNameString = folderName.ToString();
            if (FolderLookupDictionary.TryGetValue(folderNameString, out Folder folder))
            {
                return folder;
            }
            else
            {
                return InformationModel.Make<Folder>("temp");
            }
        }

        public static NodeProfile NodeLookup(Enum nodeName)
        {
            string nodeNameString = nodeName.ToString();
            if (NodeLookupDictionary.TryGetValue(nodeNameString, out NodeProfile node))
            {
                return node;
            }
            else
            {
                //NodeProfile newNodeProfile = new();
                //newNodeProfile.BrowseName = nodeNameString;
                //return newNodeProfile;
                Log.Error("In Else-----------------------------------------");
                LogErrorCaller(2);
                Log.Error("Node " + nodeName + " Not Valid! Dictionary count: " + NodeLookupDictionary.Count.ToString());
                LogDictionary(NodeLookupDictionary);
                Log.Error("Before the Exception-----------------------------------------");
                throw new Exception("NodeLookup not valid for " + nodeName);
            }
        }

        public static IUAVariable VariableLookup(Enum variableName)
        {
            string variableNameString = variableName.ToString();
            if (VariableLookupDictionary.TryGetValue(variableNameString, out IUAVariable variable))
            {
                return variable;
            }
            else
            {
                Log.Error("Before the Exception-----------------------------------------");
                throw new Exception("VariableLookup not valid for " + variableName);
            }
        }

        public static void AddVariableToProject(Enum folderName, IUAVariable variable)
        {
            FolderEnumLookup(folderName).Add(variable);
            VariableLookupDictionary.Add(variable.BrowseName, variable);
        }

        /// <summary>
        /// Adds the node to the Optix Designer tree and records information to global Node Lookup Dictionary for access
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="node"></param>
        public static void AddNodeToProject(Enum folderName, UANode node, NodeProfile nodeProfile = null)
        {
            FolderEnumLookup(folderName).Add(node);
            AddNodeToDictionary(folderName, node, nodeProfile);
        }

        public static void AddNodeToDictionary(Enum folderName, UANode node, NodeProfile nodeProfile = null)
        {
            nodeProfile ??= new NodeProfile();

            nodeProfile.UANode ??= node;
            nodeProfile.NodeId ??= node.NodeId;
            nodeProfile.NodePath ??= GetCurrentProjectBroswePath(node);
            nodeProfile.FolderEnum ??= folderName;
            nodeProfile.BrowseName ??= node.BrowseName;

            NodeLookupDictionary.Add(nodeProfile.BrowseName, nodeProfile);
        }

        //come back and write a method that searches the dictionary and updates the values that aren't full
        public static void SetPanel(PanelLoader panelLoader, NodeProfile nodeProfile)
        {
            panelLoader.Panel = nodeProfile.NodeId;
        }

        public static string GetCurrentProjectBroswePath(IUANode node)
        {
            //Build an absolute path of a node
            if (node.Owner == Project.Current || node.BrowseName == "Root") return node.BrowseName;
            return GetCurrentProjectBroswePath(node.Owner) + "/" + node.BrowseName;
        }

        public static string CreateRelativePath(IUANode source, IUANode target)
        {
            //Build relative path between source and target nodeProfile
            string result = "";
            var srcPath = GetCurrentProjectBroswePath(source);
            var tarPath = GetCurrentProjectBroswePath(target);
            var srcArr = srcPath.Split("/");
            var tarArr = tarPath.Split("/");
            var max = Math.Max(srcPath.Count(), tarPath.Count());
            int i = 0;
            for (; i < max; i++)
            {
                result = "..";
                if (srcArr[i] != tarArr[i])
                {
                    break;
                }
            }
            for (int j = srcArr.Count() - 1; j > i; j--)
            {
                result = result + "/..";
            }
            for (int k = i; k < tarArr.Count(); k++)
            {
                result = result + "/" + tarArr[k];
            }
            return result;
        }

        public static PanelLoader GetMainContentPanelLoader(bool resetPanel = false)
        {
            PanelLoader mainContentPanelLoader = Project.Current.Find<PanelLoader>("MainContentPanelLoader");
            if (resetPanel)
            {
                mainContentPanelLoader.Panel = null;
            }

            return mainContentPanelLoader;
        }

        public static Rectangle GetBackgroundOfPanelLoaderSection(string panelLoaderSectionBrowseName)
        {
            PanelLoader panelLoaderSection = Project.Current.Find<PanelLoader>(panelLoaderSectionBrowseName);
            Rectangle background = panelLoaderSection.Find<Rectangle>("Background");

            return background;
        }

        public static PanelLoader GetLeftDashboardPanelLoader(bool hideBackground = false, bool resetPanel = false, bool isHidden = false)
        {
            PanelLoader dashboardLeftPanelLoader = Project.Current.Find<PanelLoader>("DashboardLeftPanelLoader");
            Rectangle backgroundOfPanelLoader = GetBackgroundOfPanelLoaderSection("DashboardLeftPanelLoader");
            if (hideBackground)
            {
                backgroundOfPanelLoader.Visible = false;
            }
            else
            {
                backgroundOfPanelLoader.Visible = true;
            }
            return dashboardLeftPanelLoader;
        }

        public static PanelLoader GetRightDashboardPanelLoader(bool resetPanel = false, bool isHidden = false)
        {
            PanelLoader dashboardRightPanelLoader = Project.Current.Find<PanelLoader>("DashboardRightPanelLoader");
            if (resetPanel)
            {
                dashboardRightPanelLoader.Panel = null;
            }
            if (isHidden)
            {
                dashboardRightPanelLoader.Visible = false;
            }
            else
            {
                dashboardRightPanelLoader.Visible = true;
            }
            return dashboardRightPanelLoader;
        }

        public static void SetMainContentPanelLoaderPanel(NodeId newContentToLoad)
        {
            PanelLoader mainContentPanelLoader = Project.Current.Find<PanelLoader>("MainContentPanelLoader");
            mainContentPanelLoader.Panel = newContentToLoad;
        }

        public static string GetRelativeImagePath(string imageName)
        {
            if (imageName.Contains("Images"))
            {
                imageName = GetLastPartOfPath(imageName);
            }

            string imageRelativePath = "Images/" + imageName;
            ResourceUri projectFileResourceUri = ResourceUri.FromProjectRelativePath(imageRelativePath);

            return projectFileResourceUri;
        }

        public static string GetLastPartOfPath(string path)
        {
            string[] components = path.Split('/');

            string lastComponent = components[components.Length - 1];

            string fileName = Path.GetFileName(lastComponent);

            return fileName;
        }

        public static string CleanPathString(string folderPath)
        {
            string lookupName = folderPath;
            string[] stringsToRemove = { "/", "UI", "Model", "Components" };

            foreach (string item in stringsToRemove)
            {
                lookupName = lookupName.Replace(item, "");
            }

            return lookupName;
        }

        public static string RandomNumString()
        {
            Random rnd = new Random();
            return rnd.Next(10).ToString();
        }

        public static void LogDictionary<T1, T2>(Dictionary<T1, T2> genericDictionary)
        {
            string dictionaryPrintOutLine = "";

            Log.Info("Generic Dictionary Contents:");
            foreach (var pair in genericDictionary)
            {
                dictionaryPrintOutLine += ($"{pair.Key}, ");
                Log.Info($"Key: {pair.Key}, Value: {GetValueAsString(pair.Value)}___");
            }
            Log.Info(dictionaryPrintOutLine);
        }

        public static void LogErrorCaller(int levelsBackInTheStackFrame)
        {
            StackFrame frame = new StackFrame(levelsBackInTheStackFrame); // Get the caller's stack frame
            var callerMethod = frame.GetMethod(); // Get the caller's method
            var callerClassName = callerMethod.DeclaringType.Name; // Get the caller's class name
            var callerMethodName = callerMethod.Name; // Get the caller's method name

            Log.Error($"Caller: {callerClassName}.{callerMethodName}");
        }

        // Helper method to get string representation of the value
        private static string GetValueAsString<T>(T value)
        {
            // If the value is null, return "null"
            if (value == null)
            {
                return "null";
            }
            // If the value is a string, return it directly
            else if (typeof(T) == typeof(string))
            {
                return (string)(object)value;
            }
            // If the value is an IEnumerable, you can customize the output based on its type
            else if (value is IEnumerable<object>)
            {
                var list = (IEnumerable<object>)value;
                return string.Join(", ", list);
            }
            // If the value is an object, print out all its properties
            else
            {
                Type type = value.GetType();
                PropertyInfo[] properties = type.GetProperties();
                var propertyValues = properties.Select(prop => $"{prop.Name}: {prop.GetValue(value)}");
                return string.Join(", ", propertyValues);
            }
        }
    }
}