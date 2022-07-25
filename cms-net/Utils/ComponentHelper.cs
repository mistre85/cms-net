using cms_net.Context;

namespace cms_net.Utils
{
    public static class ComponentHelper
    {
        internal static readonly string COMPONENT_PATH = Directory.GetCurrentDirectory() + "/Views/Page/Components";

        public static List<string> GetComponentDirectoryList()
        {
            

            //todo: gestire exception su mancaze dir
            string[] dirs = Directory.GetDirectories(COMPONENT_PATH, "*", SearchOption.TopDirectoryOnly);

            List<string> componentNameList = new List<string>();

            foreach (string dir in dirs)
            {
                string[] dirSplit = dir.Split("\\");
                string componentName = dirSplit.Last();

                componentNameList.Add(componentName);
            }

            return componentNameList;
        }

        public static string[] GetFieldsFromComponentFile(string componentName)
        {

            string componentData = COMPONENT_PATH + "/" + componentName + "/data" + ".csv";

            //todo: gestire exception su mancaze dir
            string[] fieldsLine = File.ReadAllLines(componentData);
            string[] fields = fieldsLine[0].Split(",");

            return fields;
        }


        public static bool isComponentInstalled(string componentName)
        {

            using(CMSContext ctx = new CMSContext())
            {
                return ctx.ComponentsDefinitions.Where(c => c.Key == componentName).Count() > 0;
            }
            
        }
    }
}
