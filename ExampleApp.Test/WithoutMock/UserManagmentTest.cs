using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExampleApp.Test.WithoutMock
{
    public class UserManagementTest
    {
        [Fact]
        public void Add_User()
        {
            var userManagement = new UserManagement();
            userManagement.AllUsers.Clear();
            userManagement.AddUser(new("baby", "yoda"));

            var savedYoda = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedYoda);
            Assert.Equal("baby", savedYoda.FirstName);
            Assert.Equal("yoda", savedYoda.LastName);
            Assert.False(savedYoda.VerifiedEmail);
            Assert.Null(savedYoda.Phone);
        }

        [Fact]
        public void Delete_User()
        {
            var userManagement = new UserManagement();

            userManagement.AllUsers.Clear();
            userManagement.AddUser(new("baby", "yoda"));

            var savedYoda = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedYoda);
            Assert.Equal("baby", savedYoda.FirstName);
            Assert.Equal("yoda", savedYoda.LastName);
            Assert.False(savedYoda.VerifiedEmail);
            Assert.Null(savedYoda.Phone);

            userManagement.DeleteUser(savedYoda);
            var users = userManagement.GetAllUser();
            Assert.Empty(userManagement.AllUsers);
            Assert.Empty(users);
        }

        [Fact]
        public void Update_User()
        {
            var userManagement = new UserManagement();

            userManagement.AllUsers.Clear();
            userManagement.AddUser(new("mandalorian", "silver beskar"));
            var userMando = userManagement.AllUsers.First();
            userMando.Phone = "+44000000032";
            userManagement.UpdateUser(userMando);

            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("+44000000032", savedUser.Phone);
        }
    }
}
