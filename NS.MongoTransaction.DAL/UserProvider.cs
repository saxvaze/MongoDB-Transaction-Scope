using NS.MongoTransaction.Common.Entities;
using NS.MongoTransaction.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.MongoTransaction.DAL
{
    public class UserProvider : BaseProvider
    {
        public void RegisterUser(User user)
        {
            GetUserCollection.Save(user);
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            var currentUsers = GetUserCollection.FindAll();

            foreach (var user in currentUsers)
            {
                users.Add(new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PersonalNumber = user.PersonalNumber,
                    BirthDate = user.BirthDate,
                    UserInfo = user.UserInfo
                });
            }

            return users;
        }
    }
}
