using PaintRoom.Room;

namespace PaintRoom.Paint
{
    public class Paint
    {
        private Enums.PaintColor _color;
        private float _price;
        
        public Paint(Enums.PaintColor color, float price)
        {
            _color = color;
            _price = price;
        }
    }
}