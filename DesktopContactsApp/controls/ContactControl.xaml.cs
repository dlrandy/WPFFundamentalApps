using DesktopContactsApp.Classes;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp.controls
{
    /// <summary>
    /// ContactControl.xaml 的交互逻辑
    /// </summary>
    public partial class ContactControl : UserControl
    {

        //private Contact _Contact;

        //public Contact Contact
        //{
        //    get
        //    {
        //        return _Contact;
        //    }
        //    set
        //    {
        //        _Contact = value;
        //        NameTextBlock.Text = _Contact.Name;
        //        EmailTextBlock.Text = _Contact.Email;
        //        PhoneNumberTextBlock.Text = _Contact.PhoneNumber;
        //    }
        //}

        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }
        public static readonly DependencyProperty ContactProperty = DependencyProperty.Register(nameof(Contact), typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact(), SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            if (control != null)
            {
                control.NameTextBlock.Text = (e.NewValue as Contact).Name;
                control.EmailTextBlock.Text = (e.NewValue as Contact).Email;
                control.PhoneNumberTextBlock.Text = (e.NewValue as Contact).PhoneNumber;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
