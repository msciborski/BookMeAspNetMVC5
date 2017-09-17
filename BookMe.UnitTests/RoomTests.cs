using System;
using System.Collections.Generic;
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
    public class RoomTests {
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
    }
}
