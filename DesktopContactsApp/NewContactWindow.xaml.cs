using DesktopContactsApp.Classes;
using SQLite;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// NewContactWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                PhoneNumber = PhoneTextBox.Text
            };

            //string databaseName = "Contacts.db";
            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string databasePath = Path.Combine(folderPath, databaseName);
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }


            this.Close();
        }
    }
}
