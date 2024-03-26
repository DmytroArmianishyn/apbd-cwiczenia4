using System.Runtime.InteropServices.JavaScript;

namespace LegacyApp.Tests;


public class UserServiceTests
{
    [Fact]
    public void Test1()
    {
        
        
        // Arrange
        var userServise = new UserService();
       
     
        //Act
        var result = userServise.AddUser("Jan", "Kowalski", "kowalski@wp.pl", DateTime.Parse("2004-12-12"), 1);


//Asert

Assert.False(result);


    }
}