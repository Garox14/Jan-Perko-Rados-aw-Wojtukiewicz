namespace PaintRoom.Room
{
    public class Window
    {
        private float _width;
        private float _height;

        public Window()
        {
            _width = 0;
            _height = 0;
        }

        public Window(float w, float h)
        {
            _width = w;
            _height = h;
        }

        public (float width, float height) GetWindowSize() => (_width, _height);
        public float GetWindowsSurface() => _width * _height;
    }
}