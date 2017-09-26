using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookMe.Domain.Concrete;
using BookMe.Domain.Concrete.Repository;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;
using BookMe.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookMe.UnitTests {
    [TestClass]
    public class PhotoTests {
        [TestMethod]
        public void CanReturnPhotoForId(){
            //Arrange
            var sevenItems = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var photo = new Photo() {PhotoID = 1, ImageData = sevenItems, ImageMimeType = "image/jpeg"};
            Mock<IPhotoRepository> mockRepo = new Mock<IPhotoRepository>();
            mockRepo.Setup(m => m.Get(1)).Returns(photo).Verifiable();
            PhotoController target = new PhotoController(mockRepo.Object);

            //Act
            ActionResult result = target.Index(1);
            FileResult fileResult = (FileResult) result;

            //Assert
            Assert.IsNotNull(fileResult);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual(fileResult.ContentType,"image/jpeg");
        }
    }
}
