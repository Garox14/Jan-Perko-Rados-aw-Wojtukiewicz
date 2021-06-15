using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PaintRoom.Room
{
    public class Wall
    {
        private float _width;
        private float _height;

        private List<Window> _windowsOnWall;

        private Enums.PaintColor _wallColor;

        private float _surfaceSize;

        public Wall(float w, float h, int windowsOnWall)
        {
            _width = w;
            _height = h;

            _windowsOnWall = new List<Window>();

            for (int i = 0; i < windowsOnWall; i++)
            {
                AddWindow();
            }
            
            Console.Clear();
            AddWallColor();
            SetSurfaceSize();
        }

        private void AddWindow()
        {
            Console.WriteLine("Jaka jest szeroskosc okna ?");

            //Chcemy aby szerokosc okna byla liczba
            if(!float.TryParse(Console.ReadLine(), out float width))
            {
                Console.WriteLine("Szerokosc musi byc liczba!");
                _windowsOnWall.Add(new Window());
                return;
            }

            Console.WriteLine("Jaka jest wysokosc okna ?");
            //Chcemy aby wysokosc okna byla liczba
            if (!float.TryParse(Console.ReadLine(), out float height))
            {
                Console.WriteLine("Wysokosc musi byc liczba !");
                _windowsOnWall.Add(new Window());
                return;
            }

            // jezeli wartosci sa wczytane poprawnie,
            // tworzymy okno z podanymi wartosciami
            _windowsOnWall.Add(new Window(width, height));
        }

        private void AddWallColor()
        {
            Console.WriteLine("Jaki chesz wybrac kolor sciany ?");
            Console.WriteLine("Bialy => 0");
            Console.WriteLine("Czarny => 1");
            Console.WriteLine("Czerwony => 2");
            Console.WriteLine("Niebieski => 3");
            Console.WriteLine("Zolty => 4");
            Console.WriteLine("Zielony => 5");
            Console.WriteLine("Fioletowy => 6");
            Console.WriteLine("Rozowy => 7");

            int colorIndex = -1;

            while (!int.TryParse(Console.ReadLine(), out colorIndex) || !(colorIndex >= 0 && colorIndex <= 7))
            {
                Console.WriteLine("Kolor musi byc liczba od 0 do 7 !");
            }

            _wallColor = (Enums.PaintColor)colorIndex;
        }

        private void SetSurfaceSize()
        {
            _surfaceSize = _width * _height;

            float windowsTotalSurface = 0;

            // dla kazdego okna na scianie
            // chcemy odjac wielkosc okna od tej sciany
           foreach (var window in _windowsOnWall)
            {
                var windowSurface = window.GetWindowsSurface();

                windowsTotalSurface += windowSurface;
            }

            _surfaceSize -= windowsTotalSurface;
            
        }

        public void EditSize()
        {
            Console.WriteLine("Jaka jest nowa szerokosc sciany ?");
            float w = -1;
            while (!float.TryParse(Console.ReadLine(), out w) || w <= 0)
            {
                Console.WriteLine("Szerokosc musi byc wieksza liczba od 0  !");
            }
            
            Console.WriteLine("Jaka jest nowa wysokosc sciany ?");
            float h = -1;
            while (!float.TryParse(Console.ReadLine(), out h) || h <= 0)
            {
                Console.WriteLine("Wysokosc musi byc wieksza od 0 !");
            }
            
            _width = w;
            _height = h;

            // zliczanie ilosci okien 
            var windowsOnWall = _windowsOnWall.Count;

            _windowsOnWall = new List<Window>();

            for (int i = 0; i < windowsOnWall; i++)
            {
                AddWindow();
            }
            
            SetSurfaceSize();
        }

        public void EditColor()
        {
            AddWallColor();
        }

        public float GetSurfaceSize() => _surfaceSize;
    }
}