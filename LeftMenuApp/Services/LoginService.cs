using LeftMenuApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeftMenuApp.Services
{
    public class LoginService
    {
        private User authorizedUser;

        public event EventHandler OnLoginChanged;

        private static readonly List<User> users = new()
        {
            new User
            {
                Name = "John",
                Email = "john@gmail.com",
                Password = "Password_1",
                Role = Roles.Teacher
            },
            new User
            {
                Name = "Sara",
                Email = "sara@gmail.com",
                Password = "Terminator_1",
                Role = Roles.Student
            },
            new User
            {
                Name = "1",
                Email = "1",
                Password = "1",
                Role = Roles.Teacher
            },
            new User
            {
                Name = "2",
                Email = "2",
                Password = "2",
                Role = Roles.Student
            }
        };

        public void Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            authorizedUser = users.Find(x => x.Email == email && x.Password == password)
                              ?? throw new InvalidOperationException();

            RaiseOnLoginChanged();
        }

        public User GetAuthorizedUser()
            => authorizedUser;

        public void LogoutAuthorizedUser()
        {
            authorizedUser = null;
            RaiseOnLoginChanged();
        }

        private void RaiseOnLoginChanged()
            => OnLoginChanged?.Invoke(this, EventArgs.Empty);
    }
}
