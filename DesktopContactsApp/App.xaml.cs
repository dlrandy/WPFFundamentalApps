using System;
using System.IO;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Contacts.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string databasePath = Path.Combine(folderPath, databaseName);
    }
}
