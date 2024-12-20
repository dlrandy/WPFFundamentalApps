﻿using SQLite;

namespace DesktopContactsApp.Classes
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{Name} - {Email} - {PhoneNumber}";
        }
    }
}
