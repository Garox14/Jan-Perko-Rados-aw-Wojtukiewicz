using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintRoom.Paint;
using PaintRoom.Room;

namespace PaintRoom
{
	class Program
	{
		private List<Room.Room> rooms;
		
		static void Main(string[] args)
		{
			Program mainProgram = new Program();


			//poczatek programu gdzie wywolujemy pierwsza funkcje 
			

			PaintCalculator calculator = new PaintCalculator();
			mainProgram.rooms = new List<Room.Room>();
			
			Console.WriteLine("Ile pomieszczen chcesz pomalowac ?");

			int roomsCount = 0;
			while (!int.TryParse(Console.ReadLine(), out roomsCount) || roomsCount <= 0)
			{
				Console.WriteLine("Liczba pokoi musi byc wieksza niz 0 !");
			}

			float totalPrice = 0f;
			
			for (int i = 0; i < roomsCount; i++)
			{
				Console.Clear();
				var room = mainProgram.AddRoom();
				mainProgram.rooms.Add(room);
			}

			string edit = String.Empty;
			
			do
			{
				Console.Clear();
				Console.WriteLine("Chcesz zmienic jakas sciane? t/n");
				edit = Console.ReadLine();

			} while (edit != "t" && edit != "n");

			if (edit == "t") mainProgram.ProcessEditRooms(mainProgram.rooms);

			for (int i = 0; i < mainProgram.rooms.Count; i++)
			{
				Console.WriteLine($"Pokoj {i} ({mainProgram.rooms[i].GetRoomType()}) powierzchnia => {mainProgram.rooms[i].GetSurfaceSize()}");
			}
			
			foreach (var room in mainProgram.rooms)
			{
				totalPrice += calculator.GetPrice(room, room.GetColorsCount());
			}
			
			Console.WriteLine($"Cena => {totalPrice}");
			
			Console.ReadKey();
		}

		private void ProcessEditRooms(List<Room.Room> rooms)
		{
			string repeat = String.Empty;

			do
			{
				if (rooms.Count == 0) return;
				Console.Clear();
				Console.WriteLine("Ktore pomieszczenie chcesz zmienic ?");

				for (int i = 0; i < rooms.Count; i++)
				{
					Console.WriteLine($"{i}. {rooms[i].GetRoomType()}");
				}

				int selectedRoom = -1;
				while (!int.TryParse(Console.ReadLine(), out selectedRoom) ||
				       selectedRoom < 0 || selectedRoom >= rooms.Count)
				{
					Console.WriteLine("Nie ma pomieszczenia z takim numerem !");
					Console.WriteLine("Dostepne numery: ");
					for (int i = 0; i < rooms.Count; i++)
					{
						Console.WriteLine($"{i}. {rooms[i].GetRoomType()}");
					}
				}

				rooms[selectedRoom].EditRoom();
				
				do
				{
					Console.Clear();
					Console.WriteLine("Chcesz kontynuowac zmiane pomieszczen ? t/n");
					repeat = Console.ReadLine();
					
				} while (repeat != "t" && repeat != "n");

			} while (repeat == "t");
		}

		private Room.Room AddRoom()
		{
			Console.WriteLine("Jaki typ pomieszczenia chcesz malowac  ?");
			Console.WriteLine("Salon => 1");
			Console.WriteLine("Garaz => 2");
			Console.WriteLine("Korytarz  => 3");
			Console.WriteLine("Sypialnie => 4");
			Console.WriteLine("Lazienke => 5");

			int roomTypeIndex = -1;

			while (!int.TryParse(Console.ReadLine(), out roomTypeIndex) || !(roomTypeIndex >= 1 && roomTypeIndex <= 5))
			{
				Console.WriteLine("Liczba musi byc od 1 do 5 !");
			}

			var type = (Enums.RoomType) roomTypeIndex;

			Console.WriteLine("Ile kolorow chcesz w pomieszczeniu?");
			
			int colorsCount;
			while (!int.TryParse(Console.ReadLine(), out colorsCount))
			{
				Console.WriteLine("Ilosc kolorow musi byc liczba !");
			}
			
			
			Console.Clear();
			Console.WriteLine("Ile jest scian w pomieszczeniu ?");

			int wallsCount = 0;
			while (!int.TryParse(Console.ReadLine(), out wallsCount))
			{
				Console.WriteLine("Liczba scian musi byc liczba !");
			}
			
			Room.Room room = new Room.Room(type, wallsCount, colorsCount);

			return room;
		}
	}
}
