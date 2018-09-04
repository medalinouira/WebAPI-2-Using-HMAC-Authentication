using Moq;
using SampleWebAPI.API.Controllers;
using SampleWebAPI.Domain.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleWebAPI.API.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Authenticate()
        {
            var iUserServicesMock = new Mock<IUserServices>();
            iUserServicesMock.Setup(service => service.IsUserExist("test1@service.com", "password1"))
                        .Returns(true);
            iUserServicesMock.Setup(service => service.IsUserExist("test2@service.com", "password2"))
                        .Returns(false);

            // Arrange
            UserController controller = new UserController(iUserServicesMock.Object);

            // Act
            bool exist = controller.Authenticate("test1@service.com", "password1");
            bool notExist = controller.Authenticate("test2@service.com", "password2");

            // Assert
            Assert.IsNotNull(exist);
            Assert.IsNotNull(notExist);
            Assert.AreEqual(true, exist);
            Assert.AreEqual(false, notExist);
        }

        [TestMethod]
        public void Confidentials()
        {
            var iUserServicesMock = new Mock<IUserServices>();
            iUserServicesMock.Setup(service => service.IsConfidentials("test1@service.com"))
                        .Returns(true);
            iUserServicesMock.Setup(service => service.IsConfidentials("test2@service.com"))
                        .Returns(false);

            // Arrange
            UserController controller = new UserController(iUserServicesMock.Object);

            // Act
            bool isConfidentials = controller.Confidentials("test1@service.com");
            bool isNotConfidentials = controller.Confidentials("test2@service.com");

            // Assert
            Assert.IsNotNull(isConfidentials);
            Assert.IsNotNull(isNotConfidentials);
            Assert.AreEqual(true, isConfidentials);
            Assert.AreEqual(false, isNotConfidentials);
        }
    }
}
