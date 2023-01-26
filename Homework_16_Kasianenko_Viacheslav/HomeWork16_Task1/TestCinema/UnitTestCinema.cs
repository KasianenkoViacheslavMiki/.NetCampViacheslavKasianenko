using HomeWork16_Task1.Model;

namespace TestCinema
{
    public class UnitTestCinema
    {
        [Fact]
        public void Assign_ValueNull_ReturnException()
        {
            // Arrange
            Client client = new Client();
            // act & assert
            Assert.Throws<Exception>(() => client.Email = null);
        }

        [Fact]
        public void Assign_ValueEmptyString_ReturnException()
        {
            // Arrange
            Client client = new Client();
            // act & assert
            Assert.Throws<Exception>(() => client.Email = "");
        }

        [Theory]
        [InlineData("slava.avals.2001@gmail.com")]
        [InlineData("s.s@gmail.com")]
        [InlineData("sigma@gmail.com")]
        public void Assign_ValueValidEmail_ReturnClientWithEmail(string email)
        {
            // Arrange
            Client client = new Client();
            // act
            client.Email = email;
            // assert
            Assert.Matches(client.Email, email);
        }
        [Theory]
        [InlineData("slava.avals.2001gmail.com")]
        [InlineData("slava.amail.com")]
        [InlineData("slava.amail@com")]
        public void Assign_ValueNotValidEmail_ReturnException(string email)
        {
            // Arrange
            Client client = new Client();
            // act & assert
            Assert.Throws<Exception>(() => client.Email = email);
        }
    }
}