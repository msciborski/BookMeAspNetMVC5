using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookMe.Domain.Concrete;
using BookMe.Domain.Concrete.Repository;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;
using BookMe.WebUI.Controllers;
using BookMe.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookMe.UnitTests {
    [TestClass]
    public class CityTests {
        //Rano do ogarnięcia
        [TestMethod]
        public void CanReturnMostPopularCities(){
            //Arrange
            var cities = new City[]{
                new City(){CityID = 1, Name = "Poznań"},
                new City(){CityID = 2, Name = "Warszawa"},
                new City(){CityID = 3, Name = "Gdańsk"}
            };
            var data = new Hotel[]{
                new Hotel() {HotelID = 1, Name = "H1", City = cities[0]},
                new Hotel() {HotelID = 2, Name = "H2", City = cities[0]},
                new Hotel() {HotelID = 3, Name = "H3", City = cities[0]},
                new Hotel() {HotelID = 4, Name = "H4", City = cities[0]},
                new Hotel() {HotelID = 5, Name = "H5", City = cities[1]},
                new Hotel() {HotelID = 6, Name = "H6", City = cities[1]},
                new Hotel() {HotelID = 7, Name = "H7", City = cities[1]},
                new Hotel() {HotelID = 8, Name = "H8", City = cities[2]},
                new Hotel() {HotelID = 9, Name = "H9", City = cities[2]},
            };
            var mockCitySet = GetMockDbSet(data.AsQueryable());
            mockCitySet.Setup(m => m.Include("City")).Returns(mockCitySet.Object);
            var mockContext = new Mock<BookMeContext>();
            mockContext.Setup(m => m.Set<Hotel>()).Returns(mockCitySet.Object);
            mockContext.Setup(m => m.Hotels).Returns(mockCitySet.Object);
            ICityRepository repository = new CityRepository(mockContext.Object);
            CityController target = new CityController(repository);

            //Act
            CityViewModel[] result = ((IEnumerable<CityViewModel>) target.MostPopularCities().Model).ToArray();

            //Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0].City.CityID, 1);
            Assert.AreEqual(result[0].Count, 4);
            Assert.AreEqual(result[1].City.CityID, 2);
            Assert.AreEqual(result[1].Count, 3);
            Assert.AreEqual(result[2].City.CityID, 3);
            Assert.AreEqual(result[2].Count, 2);
        }
        private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
            return mockSet;
        }
    }
}
