using ExampleApp.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    public class UserManagement
    {
        private static List<UserRecord> records = new();
        private int idCounter = 1;
        public List<UserRecord> AllUsers => records;
        public UserRecord? AddUser(UserRecord userRecord)
        {
            records.Add(userRecord with { Id = idCounter++ });
            return AllUsers.FirstOrDefault(x => x.Id.Equals(idCounter - 1));
        }
        public void DeleteUser(UserRecord userRecord)
        {
            records.Remove(userRecord);
        }
        public UserRecord? UpdateUser(UserRecord userRecord)
        {
            var user = records.FirstOrDefault(x => x.Id.Equals(userRecord.Id));
            user.Phone = userRecord.Phone;
            user.VerifiedEmail = userRecord.VerifiedEmail;
            return user;
        }

        public List<UserRecord> GetAllUser()
        {
            return AllUsers;
        }
    }
}
