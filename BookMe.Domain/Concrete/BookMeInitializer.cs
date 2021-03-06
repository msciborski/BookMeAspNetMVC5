﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete {
    public class BookMeInitializer : DropCreateDatabaseAlways<BookMeContext>{
        protected override void Seed(BookMeContext context){
            var cityList = new List<City>(){
                new City(){Name = "Poznań", ZipCode = "62-010"},
                new City(){Name = "Warszawa", ZipCode = "80-010"},
                new City(){Name = "Gdańsk", ZipCode = "70-010"}
            };
            cityList.ForEach(c => context.Cities.Add(c));
            context.SaveChanges();

            var hotelList = new List<Hotel>(){
                new Hotel() {Name = "Hotel Trójka", Address = "Dworcowa 25", CityID = 1, ContactNumber = "999888777", AddDate = DateTime.Parse("21.08.2016")},
                new Hotel() {Name = "Euro Hotel", Address = "Cegielskiego 32/24", CityID = 1, ContactNumber = "333444555", AddDate = DateTime.Parse("23.03.2016")},
                new Hotel() {Name = "Royal Hotel Poznań", Address = "Warszawska 24", CityID = 1, ContactNumber = "987456123", AddDate = DateTime.Parse("25.04.2016")},
                new Hotel() {Name = "Grand Palace", Address = "Marszałkowska 24", CityID = 2, ContactNumber = "345123345", AddDate = DateTime.Parse("03.08.2016")},
                new Hotel() {Name = "Novotel", Address = "Puławskiego 22", CityID = 2, ContactNumber = "983123456", AddDate = DateTime.Parse("04.08.2016")},
                new Hotel() {Name = "Diamond Hotel", Address = "Pszczelna 22", CityID = 2, ContactNumber = "123444555", AddDate = DateTime.Parse("20.10.2016")},
                new Hotel() {Name = "Hamilton", Address = "Gdyńska 33", CityID = 3, ContactNumber = "123456777", AddDate = DateTime.Parse("29.03.2017")}
            };
            hotelList.ForEach(h => context.Hotels.Add(h));
            context.SaveChanges();



            var roomList = new List<Room>(){
                new Room() {Name = "Pokój 3-osobowy", RoomType = RoomType.Pokój, Capacity = 3, Price = 45.5M, HotelID = 1, AddDate = DateTime.Parse("16.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 1, AddDate = DateTime.Parse("17.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Apartament, Capacity = 2, Price = 300.0M, HotelID = 1, AddDate = DateTime.Parse("18.07.2016")},
                new Room() {Name = "Pokój 3-osobowy", RoomType = RoomType.Pokój, Capacity = 3, Price = 43.0M, HotelID = 2, AddDate = DateTime.Parse("19.07.2016")},
                new Room() {Name = "Pokój 4-osobowy", RoomType = RoomType.Dom, Capacity = 4, Price = 400.0M, HotelID = 2, AddDate = DateTime.Parse("20.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 2, AddDate = DateTime.Parse("21.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 3, AddDate = DateTime.Parse("22.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 3, AddDate = DateTime.Parse("23.07.2016")},
                new Room() {Name = "Pokój 3-osobowy", RoomType = RoomType.Pokój, Capacity = 3, Price = 50.0M, HotelID = 4, AddDate = DateTime.Parse("24.07.2016")},
                new Room() {Name = "Pokój 4-osobowy", RoomType = RoomType.Dom, Capacity = 2, Price = 300.0M, HotelID = 4, AddDate = DateTime.Parse("25.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 4, AddDate = DateTime.Parse("26.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 5, AddDate = DateTime.Parse("27.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 5, AddDate = DateTime.Parse("28.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 5, AddDate = DateTime.Parse("29.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 6, AddDate = DateTime.Parse("30.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 6, AddDate = DateTime.Parse("01.08.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 6, AddDate = DateTime.Parse("02.08.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 7, AddDate = DateTime.Parse("03.08.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 7, AddDate = DateTime.Parse("04.08.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 7, AddDate = DateTime.Parse("05.08.2016")}
            };
            roomList.ForEach(r => context.Rooms.Add(r));
            context.SaveChanges();

            String fileHotelName = @"C:\Users\mscib\Documents\hotel.jpg";
            String fileRoomName = @"C:\Users\mscib\Documents\room.jpg";
            byte[] bytePhoto = GetImageByteArray(fileHotelName);
            string mimeType = GetMimeType(fileHotelName);
            byte[] byteRoomPhoto = GetImageByteArray(fileRoomName);
            String mimeRoomType = GetMimeType(fileRoomName);
            var hotelPhotos = new List<Photo>(){
                new Photo(){PhotoID = 1, ImageData = bytePhoto, ImageMimeType = mimeType, HotelID = 1},
                new Photo(){PhotoID = 2, ImageData = bytePhoto, ImageMimeType = mimeType, HotelID = 2},
                new Photo(){PhotoID = 3, ImageData = bytePhoto, ImageMimeType = mimeType, HotelID = 3},
                new Photo(){PhotoID = 4, ImageData = bytePhoto, ImageMimeType = mimeType, HotelID = 4},
                new Photo(){PhotoID = 5, ImageData = bytePhoto, ImageMimeType = mimeType, HotelID = 5},
                new Photo(){PhotoID = 6, ImageData = bytePhoto, ImageMimeType = mimeType, HotelID = 6},
                new Photo(){PhotoID = 7, ImageData = bytePhoto, ImageMimeType = mimeType, HotelID = 7},
                new Photo(){PhotoID = 8, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 1},
                new Photo(){PhotoID = 9, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 2},
                new Photo(){PhotoID = 10, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 3},
                new Photo(){PhotoID = 11, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 4},
                new Photo(){PhotoID = 12, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 5},
                new Photo(){PhotoID = 13, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 6},
                new Photo(){PhotoID = 14, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 7},
                new Photo(){PhotoID = 15, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 8},
                new Photo(){PhotoID = 16, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 9},
                new Photo(){PhotoID = 17, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 10},
                new Photo(){PhotoID = 18, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 11},
                new Photo(){PhotoID = 19, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 12},
                new Photo(){PhotoID = 20, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 13},
                new Photo(){PhotoID = 21, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 14},
                new Photo(){PhotoID = 22, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 15},
                new Photo(){PhotoID = 23, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 16},
                new Photo(){PhotoID = 24, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 17},
                new Photo(){PhotoID = 25, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 18},
                new Photo(){PhotoID = 26, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 19},
                new Photo(){PhotoID = 27, ImageData = byteRoomPhoto,ImageMimeType = mimeRoomType, RoomID = 20}
            };
            hotelPhotos.ForEach(p => context.Photos.Add(p));
            context.SaveChanges();
        }


        private byte[] GetImageByteArray(string imageFile){
            MemoryStream stream = new MemoryStream();
            Image image = Image.FromFile(imageFile);
            image.Save(stream, ImageFormat.Jpeg);
            return stream.ToArray();
        }

        private string GetMimeType(string imageFile){
            Image image = Image.FromFile(imageFile);
            ImageFormat format = image.RawFormat;
            ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);
            return codec.MimeType;
        }
    }
}
