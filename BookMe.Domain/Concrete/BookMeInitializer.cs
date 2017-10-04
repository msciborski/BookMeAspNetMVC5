using System;
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
                new Room() {Name = "Pokój 3-osobowy", RoomType = RoomType.Pokój, Capacity = 3, KidsCapacity = 1, Price = 45.5M, HotelID = 1, AddDate = DateTime.Parse("16.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 1, Price = 30.0M, HotelID = 1, AddDate = DateTime.Parse("17.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Apartament, Capacity = 2, KidsCapacity = 1, Price = 300.0M, HotelID = 1, AddDate = DateTime.Parse("18.07.2016")},
                new Room() {Name = "Pokój 3-osobowy", RoomType = RoomType.Pokój, Capacity = 3, KidsCapacity = 1, Price = 43.0M, HotelID = 2, AddDate = DateTime.Parse("19.07.2016")},
                new Room() {Name = "Pokój 4-osobowy", RoomType = RoomType.Dom, Capacity = 4, KidsCapacity = 1, Price = 400.0M, HotelID = 2, AddDate = DateTime.Parse("20.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 2, Price = 30.0M, HotelID = 2, AddDate = DateTime.Parse("21.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 2, Price = 30.0M, HotelID = 3, AddDate = DateTime.Parse("22.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 3, Price = 30.0M, HotelID = 3, AddDate = DateTime.Parse("23.07.2016")},
                new Room() {Name = "Pokój 3-osobowy", RoomType = RoomType.Pokój, Capacity = 3, KidsCapacity = 0, Price = 50.0M, HotelID = 4, AddDate = DateTime.Parse("24.07.2016")},
                new Room() {Name = "Pokój 4-osobowy", RoomType = RoomType.Dom, Capacity = 2, KidsCapacity = 1, Price = 300.0M, HotelID = 4, AddDate = DateTime.Parse("25.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 1, Price = 30.0M, HotelID = 4, AddDate = DateTime.Parse("26.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 2, Price = 30.0M, HotelID = 5, AddDate = DateTime.Parse("27.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 0, Price = 30.0M, HotelID = 5, AddDate = DateTime.Parse("28.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 1, Price = 30.0M, HotelID = 5, AddDate = DateTime.Parse("29.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 1, Price = 30.0M, HotelID = 6, AddDate = DateTime.Parse("30.07.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 1, Price = 30.0M, HotelID = 6, AddDate = DateTime.Parse("01.08.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 0, Price = 30.0M, HotelID = 6, AddDate = DateTime.Parse("02.08.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 0, Price = 30.0M, HotelID = 7, AddDate = DateTime.Parse("03.08.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 1, Price = 30.0M, HotelID = 7, AddDate = DateTime.Parse("04.08.2016")},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, KidsCapacity = 2, Price = 30.0M, HotelID = 7, AddDate = DateTime.Parse("05.08.2016")}
            };
            roomList.ForEach(r => context.Rooms.Add(r));
            context.SaveChanges();

            var reservationsList = new List<Reservation>(){
                new Reservation() {StartDate = DateTime.Parse("21.08.2017"), EndDate = DateTime.Parse("24.08.2017"), RoomID = 1},
                new Reservation() {StartDate = DateTime.Parse("25.08.2016"), EndDate = DateTime.Parse("30.08.2016"), RoomID = 1},
                new Reservation() {StartDate = DateTime.Parse("04.09.2016"), EndDate = DateTime.Parse("08.09.2016"), RoomID = 1},
                new Reservation() {StartDate = DateTime.Parse("21.08.2017"), EndDate = DateTime.Parse("24.08.2017"), RoomID = 2},
                new Reservation() {StartDate = DateTime.Parse("18.09.2016"), EndDate = DateTime.Parse("20.09.2016"), RoomID = 2},
                new Reservation() {StartDate = DateTime.Parse("24.09.2016"), EndDate = DateTime.Parse("27.09.2016"), RoomID = 2},
                new Reservation() {StartDate = DateTime.Parse("21.08.2017"), EndDate = DateTime.Parse("24.08.2017"), RoomID = 3},
                new Reservation() {StartDate = DateTime.Parse("12.10.2016"), EndDate = DateTime.Parse("16.10.2016"), RoomID = 3},
                new Reservation() {StartDate = DateTime.Parse("19.10.2016"), EndDate = DateTime.Parse("25.10.2016"), RoomID = 3},
                new Reservation() {StartDate = DateTime.Parse("24.09.2016"), EndDate = DateTime.Parse("27.09.2016"), RoomID = 3},
            };
            reservationsList.ForEach(r => context.Reservations.Add(r));
            context.SaveChanges();

            String fileHotelName = @"C:\Users\mscib\Documents\hotel.jpg";
            String fileRoomName = @"C:\Users\mscib\Documents\room.jpg";
            byte[] bytePhoto = GetImageByteArray(fileHotelName);
            string mimeType = GetMimeType(fileHotelName);
            byte[] byteRoomPhoto = GetImageByteArray(fileRoomName);
            String mimeRoomType = GetMimeType(fileRoomName);
            List<Photo> photos = new List<Photo>();
            CreatePhotoList(7, bytePhoto, mimeType, "hotel", photos);
            CreatePhotoList(20, byteRoomPhoto, mimeRoomType, "room", photos);
            foreach (var photo in photos){
                context.Photos.Add(photo);
            }
            context.SaveChanges();
        }
        


        private void CreatePhotoList(int count, byte[] bytePhoto, String mimeType, String type, List<Photo> photos){
            int startIndex = photos.Count;
            switch (type){
                case "hotel":
                    int hotelID = 1;
                    for (int i = startIndex+1; i <= (count + startIndex); i++){
                        photos.Add(new Photo(){
                            PhotoID = i,
                            HotelID = hotelID,
                            ImageData = bytePhoto,
                            ImageMimeType = mimeType
                        });
                        hotelID++;
                    }
                    break;
                case "room":
                    int roomID = 1;
                    for (int i = startIndex; i < (count + startIndex); i++){
                        photos.Add(new Photo(){
                            PhotoID = i,
                            RoomID = roomID,
                            ImageData = bytePhoto,
                            ImageMimeType = mimeType
                        });
                        roomID++;
                    }
                    break;
            }
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
