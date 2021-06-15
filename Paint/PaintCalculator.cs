using System;
using System.Collections.Generic;
using PaintRoom.Room;

namespace PaintRoom.Paint
{
    public class PaintCalculator
    {
        /// <summary>
        ///  int => multiplier for specific room
        ///  RoomType => type of the room
        /// </summary>
        private Dictionary<Enums.RoomType, float> roomsMultiplier;

        private Dictionary<Enums.PaintColor, float> paintsPrice;

        private Dictionary<int, float> paintsVolumeMultiplier;

        private float paintBucketVolume;
        
        public PaintCalculator()
        {
            InitMultipliers();
            paintBucketVolume = 5f;
            CreatePaints();
        }

        private void InitMultipliers()
        {
            roomsMultiplier = new Dictionary<Enums.RoomType, float>();
            
            roomsMultiplier.Add(Enums.RoomType.Bathroom, 1.5f);
            roomsMultiplier.Add(Enums.RoomType.Bedroom, 1f);
            roomsMultiplier.Add(Enums.RoomType.Corridor, 1f);
            roomsMultiplier.Add(Enums.RoomType.Garage, 1.2f);
            roomsMultiplier.Add(Enums.RoomType.Salon, 1f);

            paintsVolumeMultiplier = new Dictionary<int, float>();
            
            paintsVolumeMultiplier.Add(5, 5);
            paintsVolumeMultiplier.Add(10, 9);
            paintsVolumeMultiplier.Add(15, 13);
        }

        private void CreatePaints()
        {
            paintsPrice = new Dictionary<Enums.PaintColor, float>();
            
            paintsPrice.Add(Enums.PaintColor.Black, 10);
            paintsPrice.Add(Enums.PaintColor.Blue, 20);
            paintsPrice.Add(Enums.PaintColor.Green, 15);
            paintsPrice.Add(Enums.PaintColor.Purple, 20);
            paintsPrice.Add(Enums.PaintColor.Red, 30);
            paintsPrice.Add(Enums.PaintColor.Violet, 10);
            paintsPrice.Add(Enums.PaintColor.White, 5);
            paintsPrice.Add(Enums.PaintColor.Yellow, 10);
        }
        
        public float GetPrice(Room.Room room, int colorsCount)
        {
            var roomType = room.GetRoomType();
            var multiplier = roomsMultiplier[roomType];

            var roomSize = room.GetSurfaceSize();

            var price = GetBasePrice(roomSize);

            price *= colorsCount;

            price *= multiplier;

            return price;
        }

        private float GetBasePrice(float surfaceSize)
        {
            float price = 0;

            //ile 15l pojemnikow mozemy miec
            var bigBuckets = (int)(surfaceSize / 15);

            surfaceSize -= bigBuckets * 15;

            //ile 10l pojemnikow mozemy miec
            var mediumBuckets = (int) (surfaceSize / 10);

            surfaceSize -= mediumBuckets * 10;

            //ile 5l pojemnikow mozemy miec
            var smallBuckets = 0;
            
            if (surfaceSize > 0)
            {
                if (surfaceSize > 5)
                {
                    //przyklad
                    //jezeli mamy 7m to lepiej kupic 1x 10l  niz 2x 5l 
                    mediumBuckets++;
                }
                else
                {
                    //przyklad:
                    //jezeli mamy 2m to musimy kupic pojemnik 5l 
                    smallBuckets++;
                }
            }
            
            Console.WriteLine("Wynik: ");
            Console.WriteLine($"Duze pojemniki => {bigBuckets}");
            Console.WriteLine($"Srednie pojemniki => {mediumBuckets}");
            Console.WriteLine($"Male pojemniki => {smallBuckets}");

            price += bigBuckets * paintsVolumeMultiplier[15];
            price += mediumBuckets * paintsVolumeMultiplier[10];
            price += smallBuckets * paintsVolumeMultiplier[5];

            return price;

        }
    }
}