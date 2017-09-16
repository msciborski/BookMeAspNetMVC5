using System;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookMe.UnitTests {
    [TestClass]
    public class HotelTests {
        [TestMethod]
        public void CanReturnTop6MostPoppularCities(){
            //Arrange
            Mock<IHotelRepository> mockHotelRepository = new Mock<IHotelRepository>();
            mockHotelRepository.Setup(m => m.)
            Mock<IUnitOfWork> mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(m => m.Hotels)
            HotelController target = new HotelController();
        }
    }
}
