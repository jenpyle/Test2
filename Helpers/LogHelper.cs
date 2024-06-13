using UAManagedCore;
using static Mikron_MOAB_HMI.Helpers.TreeShortcuts;

namespace Mikron_MOAB_HMI.Helpers
{
    public class LogHelper
    {
        public LogHelper()
        {
            NodeLookupDictionary.DictionaryUpdated += NodeLookupDictionary_DictionaryUpdated;
        }

        private void NodeLookupDictionary_DictionaryUpdated()
        {
            //Log.Info("-------------------------Dictionary updated!");
            //Console.WriteLine("Dictionary updated!");
            // Call your method here that you want to execute every time the dictionary is updated
        }

        public static void LogPathsForEnums()
        {
            string stringOfUIEnumsToCopy = "";
            string stringOfModelEnumsToCopy = "";

            foreach (string folderPath in AllFolderPaths)
            {
                if (folderPath.Contains("Model"))
                {
                    stringOfModelEnumsToCopy = stringOfModelEnumsToCopy + "," + CleanPathString(folderPath);
                }
                else
                {
                    stringOfUIEnumsToCopy = stringOfUIEnumsToCopy + "," + CleanPathString(folderPath);
                }
            }

            Log.Info("UI folder Enums to copy/paste ------------" + stringOfUIEnumsToCopy);
            Log.Info("Model folder Enums to copy/paste ------------" + stringOfModelEnumsToCopy);
        }
    }
}