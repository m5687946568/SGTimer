using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Windows.Storage;

namespace SGTimer
{
    internal class INIFunction
    {
        static INIFunction()
        {
            string dir = Path.GetDirectoryName(ProfilePath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string name, string key, string val, string filePath);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static readonly string ProfilePath =
            //Path.Combine(ApplicationData.Current.LocalFolder.Path, "settings.ini");
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                $"m5687946568_Project/{Assembly.GetEntryAssembly().GetName().Name}",
                "settings.ini");

        public static string GPPS(string ClassName, string KeyName)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(ClassName, KeyName, "", sb, 255, ProfilePath);
            return sb.ToString();
        }

        public static void WPPS(string ClassName, string KeyName, string KeyValue)
        {
            WritePrivateProfileString(ClassName, KeyName, KeyValue, ProfilePath);
        }

    }
}
