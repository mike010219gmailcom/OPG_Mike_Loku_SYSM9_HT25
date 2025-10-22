using OPG_Mike_Loku_SYSM9_HT25.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPG_Mike_Loku_SYSM9_HT25.Manager
{
    public class UserManager : INotifyPropertyChanged
    {
        private List<User> _users;

        public List<User> Users
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

        public string Username { get; set; }
        public string Password { get; set; }


        // Konstruktor
        public UserManager()
        {
            _users = new List<User>();
            ExistingUsers();
        }

        private void ExistingUsers()
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
                DisplayName = Username,
                Role = "User",
                Password = "password"
            });

        }

        public bool RegisterUser(User newUser)
        {
            if (Users.Any(u => u.Username == newUser.Username))
            {
                return false;
            }
            Users.Add(newUser);
            return true;
        }


        public bool Login()
        {
            foreach (User u in Users)
            {
                if (u.Username == Username && u.Password == Password)
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
