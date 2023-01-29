using HomeWork17_Task1.Controller;
using HomeWork17_Task1.Model;
using HomeWork17_Task1.Validators;
using Moq;

namespace TestClient
{
    public class UnitTestClient
    {
        [Fact]
        public void Assign_ValueEmailNull_ReturnFalse()
        {
            // Arrange
            ClientController clientController = new ClientController(new EmailValidator(),new MobileValidator());
            string message;
            // Act
            bool result = clientController.ValidateClient(clientController.CreateClient("Jack", null, "0961677883"), out message);
            // Assert
            Assert.False(result);
            Assert.Matches(message, "Not valid email!");
        }

        [Fact]
        public void Assign_ValueMobileNull_ReturnFalse()
        {
            // Arrange
            ClientController clientController = new ClientController(new EmailValidator(), new MobileValidator());
            string message;
            // Act
            bool result = clientController.ValidateClient(clientController.CreateClient("Jack", "slava@sss.sss", null), out message);
            // Assert
            Assert.False(result);
            Assert.Matches(message, "Not valid mobile!");
        }

        [Theory]
        [InlineData("Jack","slava.avals.2001@gmail.com","096167783")]
        [InlineData("Nick", "slava2001@gmail.com", "096227783")]
        [InlineData("Miki", "avals.2001@gmail.com", "096161183")]
        public void Assign_ValueValidEmail_ReturnTrueAndMessangeSuccess(string name,string email,string mobile)
        {
            // Arrange
            var mock = new Mock<IMobileValidator>();
            mock.Setup(x => x.IsValid(mobile)).Returns(true);
            ClientController clientController = new ClientController(new EmailValidator(), mock.Object);
            string message;
            // Act
            bool result = clientController.ValidateClient(clientController.CreateClient(name, email, mobile), out message);
            // Assert
            Assert.True(result);
            Assert.Matches(message, "Success!");
        }

        [Theory]
        [InlineData("Jack", "slava.avals.2001", "096167783")]
        [InlineData("Nick", "slava2001gmail.com", "096227783")]
        [InlineData("Miki", "avals.2001@gmail", "096161183")]
        public void Assign_ValueNotValidEmail_ReturnFalseAndMessangeNotValidEmail(string name, string email, string mobile)
        {
            // Arrange
            var mock = new Mock<IMobileValidator>();
            ClientController clientController = new ClientController(new EmailValidator(), mock.Object);
            string message;
            // Act
            bool result = clientController.ValidateClient(clientController.CreateClient(name, email, mobile), out message);
            // Assert
            Assert.False(result);
            Assert.Matches(message, "Not valid email!");
        }
        [Theory]
        [InlineData("Jack", "slava.avals.2001@gmail.com", "096167783")]
        [InlineData("Nick", "slava2001@gmail.com", "096227783")]
        [InlineData("Miki", "avals.2001@gmail.com", "096161183")]
        public void Assign_ValueValidMobile_ReturnTrueAndMessangeSuccess(string name, string email, string mobile)
        {
            // Arrange
            var mock = new Mock<IEmailValidator>();
            mock.Setup(x => x.IsValid(email)).Returns(true);
            ClientController clientController = new ClientController(mock.Object, new MobileValidator());
            string message;
            // Act
            bool result = clientController.ValidateClient(clientController.CreateClient(name, email, mobile), out message);
            // Assert
            Assert.True(result);
            Assert.Matches(message, "Success!");
        }

        [Theory]
        [InlineData("Jack", "slava.avals.2001@gmail.com", "096112121167783")]
        [InlineData("Nick", "slava2001@gmail.com", "096asdasd227783")]
        [InlineData("Miki", "avals.2001@gmail.com", "")]
        public void Assign_ValueNotValidMobile_ReturnFalseAndMessangeNotValidEmail(string name, string email, string mobile)
        {
            // Arrange
            var mock = new Mock<IEmailValidator>();
            mock.Setup(x=>x.IsValid(email)).Returns(true);
            ClientController clientController = new ClientController(mock.Object, new MobileValidator());
            string message;
            // Act
            bool result = clientController.ValidateClient(clientController.CreateClient(name, email, mobile), out message);
            // Assert
            Assert.False(result);
            Assert.Matches(message, "Not valid mobile!");
        }
    }
}