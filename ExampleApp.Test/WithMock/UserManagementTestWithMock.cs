using ExampleApp.Records;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExampleApp.Test.WithoutMock
{
    public class UserManagmentTestWithMock
    {
        public readonly Mock<IUserManagement> userManagementMock = new();
        [Fact]
        public void Add_User()
        {
            UserManagementForMock userManagementForMock = new(userManagementMock.Object);

            var yodaRecord = new UserRecord("baby", "yoda");

            userManagementMock.Setup(x => x.Add(yodaRecord)).Returns(yodaRecord);

            var result = userManagementForMock.AddUser(yodaRecord);

            Assert.NotNull(result);
            Assert.Equal(yodaRecord, result);
            userManagementMock.Verify(x => x.Add(It.IsAny<UserRecord>()), Times.Once);

        }

        [Fact]
        public void Delete_User()
        {
            UserManagementForMock userManagementForMock = new(userManagementMock.Object);

            var yodaRecord = new UserRecord("baby", "yoda");

            userManagementMock.Setup(x => x.Delete(yodaRecord)).Returns(true);

            var result = userManagementForMock.DeleteUser(yodaRecord);

            Assert.True(result);
            userManagementMock.Verify(x => x.Delete(It.IsAny<UserRecord>()), Times.Once);

        }

        [Fact]
        public void Update_User()
        {


            UserManagementForMock userManagementForMock = new(userManagementMock.Object);

            var yodaRecord = new UserRecord("baby", "yoda");

            userManagementMock.Setup(x => x.Update(yodaRecord)).Returns(() =>
            {
                yodaRecord.Phone = "222222222222222";
                return yodaRecord;
            });

            var result = userManagementForMock.UpdateUser(yodaRecord);

            Assert.NotNull(result);
            Assert.Equal("222222222222222", result.Phone);

            userManagementMock.Verify(x => x.Update(It.IsAny<UserRecord>()), Times.Once);
        }
    }
}
