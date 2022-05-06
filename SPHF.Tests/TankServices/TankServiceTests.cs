using SPHF.Models;
using SPHF.Models.Repos;
using SPHF.Models.Services;
using SPHF.Models.ViewModels;
using System.Collections.Generic;
using System;
using Moq;
using Xunit;

namespace SPHF.Tests
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
                this.mockCountryRepo.Object
                );
        }
        [Fact]
        public void CreateCorrectInputReturnNewTank()
        {
            // Arrange
            var service = this.CreateService();
            mockTankRepo.Setup(t => t.Create(It.IsAny<Tank>())).Returns(new Tank());
            TankCreateViewModel createTank = new TankCreateViewModel()
            { CountryId = 1, Name = "Str S1", TankInfo = "Tillverkade en prototyp", TankType = TankType.TankDestroyer };

            // Act
            var result = service.Create(createTank);

            // Assert
            Assert.NotNull(result);
            mockTankRepo.Verify(t => t.Create(It.IsAny<Tank>()), Times.Once);
        }
        [Fact]
        public void GetAllReturnAllTanksOkResult()
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

        public void TankFindByIdReturnTank()
        {
            // Arrange
            var service = this.CreateService();
            mockTankRepo.Setup(t => t.FindById(It.IsAny<int>())).Returns(new Tank());
            int id = 0;
            // Act
            var result = service.FindById(id);
            // Assert
            Assert.NotNull(result);
            mockTankRepo.Verify(c => c.FindById(It.IsAny<int>()), Times.Once);
        }

        //[Fact]
        //public void Edit_UpdatesExsistingCar_ReturnUpdatedCar()
        //{
        //    // Arrange
        //    var service = this.CreateService();
        //    Tank originalTank = new Tank() { CountryId = 1, Name = "Str S1", TankInfo = "Tillverkade en prototyp", TankType = TankType.TankDestroyer } ;
        //    Tank returnTank = null;

        //    mockTankRepo.Setup(c => c.FindById(It.IsAny<int>())).Returns(originalTank);
        //    mockCountryRepo.Setup(b => b.FindById(It.IsAny<int>())).Returns(new Country());
        //    mockTankRepo.Setup(t => t.Update(It.IsAny<Tank>())).Callback<Tank>(t=> returnTank = t);

        //    int id = 1;
        //    int CountryId = 1;
        //    TankType.TankDestroyer=3;
        //    string Name = "Udes 03";
        //    string TankInfo = "Prototyp";

        //    TankCreateViewModel editTank = new TankCreateViewModel()
        //    {
        //        CountryId = newCountryId,


        //    };

        //    // Act
        //    service.(
        //        id,
        //        editTank);//Edit method is a void so here Moq lets us to get hold of the data sent to Repo.Edit with the CallBack method and our returnCar varible.

        //    // Assert
        //    Assert.Equal(CountryId, returnTank.CountryId);
        //    Assert.Equal(Name, returnTank.Name);
        //    Assert.Equal(TankInfo, returnTank.TankInfo);
        //    Assert.Equal(TankType.TankDestroyer, returnTank.TankType );

        //    mockTankRepo.Verify(t => t.FindById(It.IsAny<int>()), Times.Once);
        //    mockCountryRepo.Verify(c => c.FindById(It.IsAny<int>()), Times.Once);
        //    mockTankRepo.Verify(c => c.Update(It.IsAny<Tank>()), Times.Once);
        //}
        [Fact]
        public void RemoveExsistingTankDeleteCallRepoDelete()
        {
            // Arrange
            var service = this.CreateService();
            Tank tank = new Tank();
            mockTankRepo.Setup(t => t.FindById(It.IsAny<int>())).Returns(tank);
            mockTankRepo.Setup(t => t.Delete(It.IsAny<Tank>()));
            int id = 1;

            // Act
            service.Remove(
                id);

            // Assert

            mockTankRepo.Verify(t => t.FindById(It.IsAny<int>()), Times.Once);
            mockTankRepo.Verify(t => t.Delete(It.IsAny<Tank>()), Times.Once);
        }
    }
}