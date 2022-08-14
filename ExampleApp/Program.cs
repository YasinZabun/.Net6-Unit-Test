// See https://aka.ms/new-console-template for more information
using ExampleApp;
using ExampleApp.Records;

Console.WriteLine("Welcome to UserManagment Example!");


UserManagement userManagment = new UserManagement();


var userYoda = userManagment.AddUser(new UserRecord("baby", "yoda"));
var userMando = userManagment.AddUser(new UserRecord("Mandalorian", "Silver Beskar"));


userManagment.GetAllUser().ForEach(user => Console.WriteLine(user.ToString()));

userYoda.VerifiedEmail = true;
userYoda.Phone = "666666666";
userYoda = userManagment.UpdateUser(userYoda);

userManagment.GetAllUser().ForEach(user => Console.WriteLine(user.ToString()));

userManagment.DeleteUser(userMando);

userManagment.GetAllUser().ForEach(user => Console.WriteLine(user.ToString()));

Console.ReadLine();