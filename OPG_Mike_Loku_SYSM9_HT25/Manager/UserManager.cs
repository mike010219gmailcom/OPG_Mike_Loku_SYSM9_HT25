using OPG_Mike_Loku_SYSM9_HT25.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPG_Mike_Loku_SYSM9_HT25.Manager
{
    internal class UserManager : INotifyPropertyChanged
    {
        private List<User> _users;

        public List <User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        private User? _currentUser;

        public User? CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        // Konstruktor
        public UserManager()
        {
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            Users.Add(new User
            {
                Username = "admin",
                DisplayName = "Administrator",
                Role = "Admin",
                Password = "password"
            });

            Users.Add(new User
            {
                Username = "user",
                DisplayName = "Standard User",
                Role = "User",
                Password = "password"
            });

        }

        public bool Login(string username, string password)
        {
            foreach (User u in Users)
            {
                if (u.Username == username && u.Password == password)
                {
                    CurrentUser = u;

                    return true;
                }
            }
            return false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
