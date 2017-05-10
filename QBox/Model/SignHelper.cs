using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Model
{
    public static class SignHelper
    {
        public static void Usersetter(string name, string family)
        {
            ApplicationData.Current.LocalSettings.Values["FirstRun"] = "1";
            ApplicationData.Current.LocalSettings.Values["Name"] = name;
            ApplicationData.Current.LocalSettings.Values["Family"] = family;
        }
        public static string GetName()
        {
            return ApplicationData.Current.LocalSettings.Values["Name"] as string;
        }
         public static string GetFamily()
        {
            return ApplicationData.Current.LocalSettings.Values["Family"] as string;
        }
        
        public static bool IsLoged()
        {
            bool logged = false;
            if (ApplicationData.Current.LocalSettings.Values["FirstRun"] as string == "1")
                logged = true;

            return logged;
        }

    }
}
