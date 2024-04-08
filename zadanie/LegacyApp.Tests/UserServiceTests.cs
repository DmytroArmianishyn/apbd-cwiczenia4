using System.Runtime.InteropServices.JavaScript;

namespace LegacyApp.Tests;


public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null,
            "Kowalski",
            "kowalski@wp.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        //Arrange
        var userService = new UserService();
        //Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalskemailpl",
            DateTime.Parse("2000-01-01"),
            1
        );
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        //Arrange
        var userService = new UserService();
        //Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@wp.pl",
            DateTime.Parse("2004-01-01"),
            1
        );
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        //Arrange
        var userService = new UserService();
        //Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            2
        );
        //Assert
        Assert.True(result);
    }


    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {

        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("Jan",
            "Kwiatkowski",
            "kwiatkowski@wp.pl",
            DateTime.Parse("2000-01-01"),
            1
            );

        //Asert
        Assert.True(result);

    }

    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser("Jan",
            "Kowalski",
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        //Asert
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        // Arrange
        var userService = new UserService();
        // Act
        Action action = () => userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            100
        );
        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        // Arrange
        var userService = new UserService();
        // Act
        Action action = () => userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            100
        );
        // Assert
        Assert.Throws<ArgumentException>(action);
    }
    
}