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
    public class RoomTests{
        [TestMethod]
        public void CanReturnRoomsForSelectedHotel(){
            //Arrange
            var data = new Room[]{
                new Room(){RoomID = 1, HotelID = 1},
                new Room(){RoomID = 2, HotelID = 1},
                new Room(){RoomID = 3, HotelID = 3},
                new Room(){RoomID = 4, HotelID = 51}
            };
            var mockContext = new Mock<BookMeContext>();
            mockContext.Setup(m => m.Set<Room>()).ReturnsDbSet(data);
            mockContext.Setup(m => m.Rooms).ReturnsDbSet(data);
            IRoomRepository repository = new RoomRepository(mockContext.Object);
            RoomController target = new RoomController(repository);

            //Act
            Room[] result = ((IEnumerable<Room>) target.RoomsForSelectedHotel(1).Model).ToArray();

            //Assert
            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].RoomID, 1);
            Assert.AreEqual(result[1].RoomID, 2);
        }
        //Ogarnąć ten test
        [TestMethod]
        public void CanReturn6LatestRooms(){
            //Arrange
            var city = new City() {
                CityID = 1,
                Name = "C1"
            };
            var hotel = new Hotel() {
                HotelID = 1,
                Name = "H1",
                City = city
            };
            var data = new Room[]{
                new Room(){RoomID = 1, Name = "R1", AddDate = DateTime.Parse("21.08.2017"), Hotel = hotel},
                new Room(){RoomID = 2, Name = "R2", AddDate = DateTime.Parse("22.08.2017"), Hotel = hotel},
                new Room(){RoomID = 3, Name = "R3", AddDate = DateTime.Parse("23.08.2017"), Hotel = hotel},
                new Room(){RoomID = 4, Name = "R4", AddDate = DateTime.Parse("24.08.2017"), Hotel = hotel},
                new Room(){RoomID = 5, Name = "R5", AddDate = DateTime.Parse("25.08.2017"), Hotel = hotel},
                new Room(){RoomID = 6, Name = "R6", AddDate = DateTime.Parse("26.08.2017"), Hotel = hotel},
                new Room(){RoomID = 7, Name = "R4", AddDate = DateTime.Parse("27.08.2017"), Hotel = hotel},
            };
            var mockRoomSet = GetMockDbSet(data.AsQueryable());
            mockRoomSet.Setup(m => m.Include("Hotel")).Returns(mockRoomSet.Object);
            mockRoomSet.Setup(m => m.Include("Hotel.City")).Returns(mockRoomSet.Object);
            var mockContex = new Mock<BookMeContext>();
            mockContex.Setup(m => m.Set<Room>()).Returns(mockRoomSet.Object);
            mockContex.Setup(m => m.Rooms).Returns(mockRoomSet.Object);
            IRoomRepository repository = new RoomRepository(mockContex.Object);
            RoomController target = new RoomController(repository);

            //Act
            Room[] result = ((IEnumerable<Room>) target.LatestRooms().Model).ToArray();

            //Assert
            Assert.AreEqual(result.Length, 6);
            Assert.AreEqual(result[0].RoomID, 7);
            Assert.AreEqual(result[1].RoomID, 6);
            Assert.AreEqual(result[2].RoomID, 5);
            Assert.AreEqual(result[3].RoomID, 4);
            Assert.AreEqual(result[4].RoomID, 3);
            Assert.AreEqual(result[5].RoomID, 2);

        }
        //Pomysleć czy idzie to jakoś wydzielić do osobnej klasy
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
