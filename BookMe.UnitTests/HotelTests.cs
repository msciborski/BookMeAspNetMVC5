using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookMe.Domain.Concrete;
using BookMe.Domain.Concrete.Repository;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;
using BookMe.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookMe.UnitTests {
    [TestClass]
    public class HotelTests {
        [TestMethod]
        public void CanReturnTop6MostPoppularCities(){
            //Arrange
            Hotel[] data = new Hotel[]{
                new Hotel() {HotelID = 1, Name = "H1", AddDate = DateTime.Parse("21.08.2016")},
                new Hotel() {HotelID = 2, Name = "H2", AddDate = DateTime.Parse("22.08.2016")},
                new Hotel() {HotelID = 3, Name = "H3", AddDate = DateTime.Parse("23.08.2016")},
                new Hotel() {HotelID = 4, Name = "H4", AddDate = DateTime.Parse("24.08.2016")},
                new Hotel() {HotelID = 5, Name = "H5", AddDate = DateTime.Parse("25.08.2016")},
                new Hotel() {HotelID = 6, Name = "H6", AddDate = DateTime.Parse("26.08.2016")},
                new Hotel() {HotelID = 7, Name = "H7", AddDate = DateTime.Parse("27.08.2016")},       
            };
            var mockContext = new Mock<BookMeContext>();
            mockContext.Setup(m => m.Set<Hotel>()).ReturnsDbSet(data);
            mockContext.Setup(m => m.Hotels).ReturnsDbSet(data);
            IHotelRepository repo = new HotelRepository(mockContext.Object);
            HotelController target = new HotelController(repo);

            //Act
            Hotel[] result = ((IEnumerable<Hotel>) target.MostPopularCities().Model).ToArray();

            //Assert
            Assert.AreEqual(result.Length, 6);
            Assert.AreEqual(result[0].Name, "H7");
            Assert.AreEqual(result[1].Name, "H6");
            Assert.AreEqual(result[2].Name, "H5");
            Assert.AreEqual(result[3].Name, "H4");
            Assert.AreEqual(result[4].Name, "H3");
            Assert.AreEqual(result[5].Name, "H2");
        }
    }
}
