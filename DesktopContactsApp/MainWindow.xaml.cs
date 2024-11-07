using DesktopContactsApp.Classes;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase();
        }

        private void NewContactButton_OnClick(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            //newContactWindow.Show();
            newContactWindow.ShowDialog();
            ReadDatabase();
        }

        void ReadDatabase()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                contacts = conn.Table<Contact>().ToList().OrderBy(x => x.Name).ToList();

            }

            if (contacts != null)
            {
                //ContactsListView.Items.Clear();
                //foreach (var contact in contacts)
                //{
                //    ContactsListView.Items.Add(new ListViewItem()
                //    {
                //        Content = contact
                //    });
                //}

                ContactsListView.ItemsSource = contacts;
            }
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox searchTextBox)
            {
                var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                var filteredList2 = from c2 in contacts
                                    where c2.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                                    orderby c2.Email
                                    select c2.Id;
                ContactsListView.ItemsSource = filteredList;
            }
        }

        private void ContactsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContactsListView.SelectedItem is Contact selectedContact)
            {
                ContactDetailsWindow newContactWindow = new ContactDetailsWindow(selectedContact);
                //newContactWindow.Show();
                newContactWindow.ShowDialog();
                ReadDatabase();
            }
        }
    }
}
