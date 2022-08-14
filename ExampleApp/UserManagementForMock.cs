using ExampleApp.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp
{
    public interface IUserManagement
    {
        UserRecord Add(UserRecord record);
        UserRecord Update(UserRecord record);
        bool Delete(UserRecord record);
        List<UserRecord> GetAll();
    }
    public class UserManagementForMock
    {
        private IUserManagement userManagement;

        private int idCounter=1;
        public UserManagementForMock(IUserManagement userManagement)
        {
            this.userManagement = userManagement;
        }
        public UserRecord? AddUser(UserRecord userRecord)
        {
            userManagement.Add(userRecord with { Id = idCounter++ });
            return userRecord;
        }
        public bool DeleteUser(UserRecord userRecord)
        {
            return userManagement.Delete(userRecord);
        }
        public UserRecord? UpdateUser(UserRecord userRecord)
        {
            return userManagement.Update(userRecord);
        }

        public List<UserRecord> GetAllUser()
        {
            return userManagement.GetAll();
        }
    }
}
