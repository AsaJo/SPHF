using Moq;
using SPHF.Models;
using SPHF.Models.Repos;
using SPHF.Models.Services;
using SPHF.Models.ViewModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace SPHF.Tests.Models.Services
{
    public class TankServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ITankRepo> mockTankRepo;
        private Mock<ICountryRepo> mockCountryRepo;

        public TankServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockTankRepo = this.mockRepository.Create<ITankRepo>();
            this.mockCountryRepo = this.mockRepository.Create<ICountryRepo>();
        }

        private TankService CreateService()
        {
            return new TankService(
                this.mockTankRepo.Object,
                this.mockCountryRepo.Object);
        }

        [Fact]
        public void Create_A_New_Tank_With_Correct_Input_Return_A_NewTank()
        {
            // Arrange
            var service = this.CreateService();
            mockTankRepo.Setup(t => t.Create(It.IsAny<Tank>())).Returns(new Tank());
            TankCreateViewModel createTank = new TankCreateViewModel()
            { CountryId = 1, Name = "Str S1", TankInfo = "Prototyp", TankType = TankType.TankDestroyer }; 

            // Act
            var result = service.Create(
                createTank);

            // Assert
            Assert.NotNull(result);
            mockTankRepo.Verify(t => t.Create(It.IsAny<Tank>()), Times.Once);

        }

        [Fact]
        public void GetAll_Tanks_And_Return_All_Tanks()
        {
            // Arrange
            var service = this.CreateService();
            mockTankRepo.Setup(t => t.GetAll()).Returns(new List<Tank>());

            // Act
            var result = service.GetAll();

            // Assert
            Assert.NotNull(result);
            mockTankRepo.Verify(t => t.GetAll(), Times.Once);
        }

        [Fact]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
           

            // Act


            // Assert

        }

        [Fact]
        public void FindById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

            // Act
            var result = service.FindById(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;

            // Act
            service.Remove(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Search_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string search = null;

            // Act
            var result = service.Search(
                search);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
