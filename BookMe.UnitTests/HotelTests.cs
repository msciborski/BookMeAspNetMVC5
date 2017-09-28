using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
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
    public class HotelTests {
        [TestMethod]
        public void CanReturnListOfHotelsForCityName(){
            //Arrange
            var cities = new City[]{
                new City{CityID = 1, Name = "Poznań"},
                new City(){CityID = 2, Name = "Warszawa"}
            };
            var data = new Hotel[]{
                new Hotel(){HotelID = 1, Name = "H1", City = cities[0]},
                new Hotel(){HotelID = 2, Name = "H2", City = cities[0]},
                new Hotel(){HotelID = 3, Name = "H3", City = cities[1]},
            };
            Mock<BookMeContext> mockContext = new Mock<BookMeContext>();
            mockContext.Setup(m => m.Set<Hotel>()).ReturnsDbSet(data);
            mockContext.Setup(m => m.Hotels).ReturnsDbSet(data);
            IHotelRepository repository = new HotelRepository(mockContext.Object);
            HotelController target = new HotelController(repository);

            //Act
            HotelListViewModel result = (HotelListViewModel) target.List("Poznań").Model;
            Hotel[] resultHotels = result.Hotels.ToArray();
            //Assert
            Assert.AreEqual(resultHotels.Length,2);
            Assert.AreEqual(resultHotels[0].HotelID, 2);
            Assert.AreEqual(resultHotels[1].HotelID, 1);
        }
        [TestMethod]
        public void CanReturnListOfHotelsForHotelName(){
            //Arrange
            var city = new City(){CityID = 1, Name = "Poznań"};
            var data = new Hotel[]{
                new Hotel(){HotelID = 1, Name = "Plaza Hotel", City = city},
                new Hotel(){HotelID = 2, Name = "Hotel Plaza 2", City = city},
                new Hotel(){HotelID = 3, Name = "Na pewno Cię nie wybiore Hotel", City = city}
            };
            Mock<BookMeContext> mockContext = new Mock<BookMeContext>();
            mockContext.Setup(m => m.Set<Hotel>()).ReturnsDbSet(data);
            mockContext.Setup(m => m.Hotels).ReturnsDbSet(data);
            IHotelRepository repository = new HotelRepository(mockContext.Object);
            HotelController target = new HotelController(repository);
            
            //Act
            HotelListViewModel result = (HotelListViewModel) target.List("Plaza").Model;
            Hotel[] resultHotels = result.Hotels.ToArray();

            //Assert
            Assert.AreEqual(resultHotels.Length,2);
            Assert.AreEqual(resultHotels[0].Name, "Hotel Plaza 2");
            Assert.AreEqual(resultHotels[1].Name, "Plaza Hotel");
        }
        //Test do poprawy
        [TestMethod]
        public void CanReturnAllHotels(){
            //Arrange
            var city = new City() {CityID = 1, Name = "Poznań"};
            var photos = new Photo[]{
                new Photo(),
                new Photo()
            };
            var data = new Hotel[]{
                new Hotel(){HotelID = 1, Name = "H1", City = city, Photos = photos},
                new Hotel(){HotelID = 2, Name = "H2", City = city, Photos = photos},
                new Hotel(){HotelID = 3, Name = "H3", City = city, Photos = photos},
                new Hotel(){HotelID = 4, Name = "H4", City = city, Photos = photos},
                new Hotel(){HotelID = 5, Name = "H5", City = city, Photos = photos},
                new Hotel(){HotelID = 6, Name = "H6", City = city, Photos = photos},
            };
            Mock<BookMeContext> mockContext = new Mock<BookMeContext>();
            mockContext.Setup(m => m.Set<Hotel>()).ReturnsDbSet(data);
            mockContext.Setup(m => m.Hotels).ReturnsDbSet(data);
            IHotelRepository repository = new HotelRepository(mockContext.Object);
            HotelController target = new HotelController(repository);

            //Act
            HotelListViewModel result = (HotelListViewModel) target.List().Model;

            //Assert
            Assert.AreEqual(result.Hotels.Count(), 3);
            Assert.AreEqual(result.PagingInfo.TotalItems, 6);
        }
        [TestMethod]
        public void CanReturnTop6MostLatestHotels(){
            //Arrange
            var city = new City(){CityID = 1, Name = "C1"};
            var photos = new List<Photo>(){
                new Photo(){PhotoID = 1}
            };
            Hotel[] data = new Hotel[]{
                new Hotel() {HotelID = 1, Name = "H1", City = city, Photos = photos, AddDate = DateTime.Parse("21.08.2016")},
                new Hotel() {HotelID = 2, Name = "H2", City = city, Photos = photos, AddDate = DateTime.Parse("22.08.2016")},
                new Hotel() {HotelID = 3, Name = "H3", City = city, Photos = photos, AddDate = DateTime.Parse("23.08.2016")},
                new Hotel() {HotelID = 4, Name = "H4", City = city, Photos = photos, AddDate = DateTime.Parse("24.08.2016")},
                new Hotel() {HotelID = 5, Name = "H5", City = city, Photos = photos, AddDate = DateTime.Parse("25.08.2016")},
                new Hotel() {HotelID = 6, Name = "H6", City = city, Photos = photos, AddDate = DateTime.Parse("26.08.2016")},
                new Hotel() {HotelID = 7, Name = "H7", City = city, Photos = photos, AddDate = DateTime.Parse("27.08.2016")},       
            };
            var mockHotelSet = GetMockDbSet(data.AsQueryable());
            mockHotelSet.Setup(m => m.Include("City")).Returns(mockHotelSet.Object);
            mockHotelSet.Setup(m => m.Include("Photos")).Returns(mockHotelSet.Object);
            var mockContext = new Mock<BookMeContext>();
            mockContext.Setup(m => m.Hotels).Returns(mockHotelSet.Object);
            mockContext.Setup(m => m.Set<Hotel>()).Returns(mockHotelSet.Object);
            IHotelRepository repo = new HotelRepository(mockContext.Object);
            HotelController target = new HotelController(repo);

            //Act
            Hotel[] result = ((IEnumerable<Hotel>) target.LatestHotels().Model).ToArray();

            //Assert
            Assert.AreEqual(result.Length, 6);
            Assert.AreEqual(result[0].Name, "H7");
            Assert.AreEqual(result[1].Name, "H6");
            Assert.AreEqual(result[2].Name, "H5");
            Assert.AreEqual(result[3].Name, "H4");
            Assert.AreEqual(result[4].Name, "H3");
            Assert.AreEqual(result[5].Name, "H2");
        }
        [TestMethod]
        public void CanReturnSelectedHotel(){
            //Assert
            var hotel = new Hotel() {HotelID = 1, Name = "H1"};
            Mock<IHotelRepository> mockRepo = new Mock<IHotelRepository>();
            mockRepo.Setup(m => m.Get(1)).Returns(hotel).Verifiable();
            HotelController target = new HotelController(mockRepo.Object);

            //Act
            ActionResult result = target.Hotel(1);
            Hotel hotelResult = (Hotel) (((ViewResult) result).Model);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsNotNull(hotelResult);
            Assert.AreEqual(hotelResult.HotelID, 1);
        }

        [TestMethod]
        public void RedirectToIndexMethodIfHotelDosentExist(){
            //Assert
            Hotel[] data = new Hotel[]{
                new Hotel() {HotelID = 1, Name = "H1"},
                new Hotel() {HotelID = 2, Name = "H2"},
                new Hotel() {HotelID = 3, Name = "H3"}   
            };
            var mockContext = new Mock<BookMeContext>();
            mockContext.Setup(m => m.Set<Hotel>()).ReturnsDbSet(data);
            mockContext.Setup(m => m.Hotels).ReturnsDbSet(data);
            IHotelRepository repo = new HotelRepository(mockContext.Object);
            HotelController target = new HotelController(repo);
            
            //Act
            ActionResult result = target.Hotel(10);

            //Assert
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
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
