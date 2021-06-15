using System;
using System.Collections.Generic;

namespace PaintRoom.Room
{
    public class Room
    {
        private Enums.RoomType _roomType;
        private int _paintAbleWallsCount;
        private float _surfaceArea;

        private List<Wall> paintAbleWalls;

        private int _colorsCount;

        // Deklarujemy akcje ktore mozna wybrac
        // Przykład: [1] [ Zmien szerokosc]
        //  To znaczy, ze jezeli wybierzemy 1 to chcemy zmienic szerokosc sciany
        private Dictionary<int, Enums.RoomAction> _roomActions;

        public Room(Enums.RoomType roomType, int paintAbleWallsCount, int colorsCount)
        {
            _roomType = roomType;
            _paintAbleWallsCount = paintAbleWallsCount;

            paintAbleWalls = new List<Wall>();

            _colorsCount = colorsCount;
            
            //Deklarowanie zdarzeń pokojow
            _roomActions = new Dictionary<int, Enums.RoomAction>();
            _roomActions.Add(0, Enums.RoomAction.EditSize);
            _roomActions.Add(1, Enums.RoomAction.EditColor);
            
            for (int i = 0; i < _paintAbleWallsCount; i++)
            {
                Console.Clear();
                Console.WriteLine($"Dodawanie numeru sciany => {i + 1}");
                AddPaintAbleWall();
            }
            
            SetRoomSurfaceSize();
        }

        private void AddPaintAbleWall()
        {
            Console.WriteLine("Jaka jest szerokosc sciany ?");

            float width;
            //Petla aby szerokosc sciany byla liczba
            while (!float.TryParse(Console.ReadLine(), out width) || width <= 0)
            {
                Console.WriteLine("Szerokosc sciany muis byc liczba wieksza od 0 !");
            }
            
            Console.WriteLine("Jaka jest wysokosc sciany ?");
            
            float height;
            //Petla aby wysokosc sciany byla liczba
            while (!float.TryParse(Console.ReadLine(), out height) || height <= 0)
            {
                Console.WriteLine("Wysokosc sciany muis byc liczba wieksza od 0 0!");
            }
            
            Console.Clear();
            Console.WriteLine("Jaka jest liczba okien na scianie ?");

            int windowsCount;
            //Petla aby ilosc okien byla liczba
            while (!int.TryParse(Console.ReadLine(), out windowsCount))
            {
                Console.WriteLine("Ilosc okien musi byc liczba !");
            }
            
            paintAbleWalls.Add(new Wall(width, height, windowsCount));
        }

        private void SetRoomSurfaceSize()
        {
            _surfaceArea = 0;

            foreach (var wall in paintAbleWalls)
            {
                _surfaceArea += wall.GetSurfaceSize();
            }
            
            Console.WriteLine($"Powierzchnia ktora moze byc pomalowana => {_surfaceArea}");
        }

        private void EditSize(Wall wall)
        {
            wall.EditSize();
        }

        private void EditColor(Wall wall)
        {
            wall.EditColor();
        }
        
        public Enums.RoomType GetRoomType() => _roomType;
        public int GetPaintAbleWallsCount() => _paintAbleWallsCount;
        public int GetColorsCount() => _colorsCount;
        public float GetSurfaceSize() => _surfaceArea;

        public void EditRoom()
        {
            Console.Clear();
            Console.WriteLine("Ktora sciane chcesz zmienic?");
            for (int i = 0; i < paintAbleWalls.Count; i++)
            {
                Console.WriteLine($"{i}");
            }

            int wallIndex = -1;
            while (!int.TryParse(Console.ReadLine(), out wallIndex) || wallIndex < 0 || wallIndex >= paintAbleWalls.Count)
            {
                Console.WriteLine("Nie mamy sciany z takim numerem ! Sprobuj ponownie");
            }
            
            Console.Clear();
            Console.WriteLine("Co checsz zmienic ?");
            
            foreach (var action in _roomActions)
            {
                Console.WriteLine($"{action.Key}. {action.Value}");
            }

            int actionIndex;
            while (!int.TryParse(Console.ReadLine(), out actionIndex) || !_roomActions.ContainsKey(actionIndex))
            {
                Console.WriteLine("Taka akcja nie instnieje ! Sprobuj ponownie");
            }

            switch (_roomActions[actionIndex])
            {
                case Enums.RoomAction.EditColor:
                {
                    EditColor(paintAbleWalls[wallIndex]);
                    break;
                }

                case Enums.RoomAction.EditSize:
                {
                    EditSize(paintAbleWalls[wallIndex]);
                    SetRoomSurfaceSize();
                    break;
                }
            }

        }
    }
}