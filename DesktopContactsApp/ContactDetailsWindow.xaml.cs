using DesktopContactsApp.Classes;
using SQLite;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// ContactDetailsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.contact = contact;
            NameTextBox.Text = contact.Name;
            EmailTextBox.Text = contact.Email;
            PhoneTextBox.Text = contact.PhoneNumber;
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            contact.Name = NameTextBox.Text;
            contact.Email = EmailTextBox.Text;
            contact.PhoneNumber = PhoneTextBox.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }


            this.Close();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }


            this.Close();
        }

    }
}
