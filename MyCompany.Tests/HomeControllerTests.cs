using Microsoft.AspNetCore.Mvc;
using MyCompany.Controllers;
using Xunit;

using MyCompany.Domain.Entities;
using Moq;
using MyCompany.Domain.Repositories.Abstract;



namespace MyCompany.Tests
{
    public class HomeControllerTests
    {
        #region Index

        [Fact]
        public void IndexViewDataMessage()
        {
            // Arrange
            const string codeWord = "PageIndex";
            var expected = new TextField
            {
                Title = "Информаційна сторінка",
                Text = "Зміст заповнюється адміністратором"
            };

            var textFieldRepositoryMock = new Mock<ITextFieldsRepository>();

            textFieldRepositoryMock.Setup(r => r.GetTextFieldByCodeWord(codeWord)).Returns(expected);
            //It.IsAny<string>() ??
            var sut = new HomeController(textFieldRepositoryMock.Object);

            // Act
            var result = sut.Index() as ViewResult;
            var actualResult = result.Model as TextField;

            // Assert
            Assert.Equal(expected, actualResult);
        }

        [Fact]
        public void IndexViewResultNotNull()
        {
            // Arrange
            var textFieldRepositoryMock = new Mock<ITextFieldsRepository>();
            var sut = new HomeController(textFieldRepositoryMock.Object);
            
            // Act
            var result = sut.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        
        #endregion

        #region Contacts

        [Fact]
        public void ContactsViewDataMessage()
        {
            // Arrange
            const string codeWord = "PageContacts";
            var expected = new TextField
            {
                Title = "Контакти",
                Text = "Контакти заповнюються адміністратором"
            };

            var textFieldRepositoryMock = new Mock<ITextFieldsRepository>();

            textFieldRepositoryMock.Setup(r => r.GetTextFieldByCodeWord(codeWord)).Returns(expected);
            //It.IsAny<string>() ??
            var sut = new HomeController(textFieldRepositoryMock.Object);

            // Act
            var result = sut.Contacts() as ViewResult;
            var actualResult = result.Model as TextField;

            // Assert
            Assert.Equal(expected, actualResult);
        }

        [Fact]
        public void ContactsViewResultNotNull()
        {
            // Arrange
            var textFieldRepositoryMock = new Mock<ITextFieldsRepository>();
            HomeController controller = new HomeController(textFieldRepositoryMock.Object);

            // Act
            var result = controller.Contacts() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

       
        #endregion
    }
}
