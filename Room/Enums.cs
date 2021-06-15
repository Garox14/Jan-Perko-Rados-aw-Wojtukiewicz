namespace PaintRoom.Room
{
    public static class Enums
    {
        public enum RoomType
        {
            None,
            Salon,
            Garage,
            Corridor,
            Bedroom,
            Bathroom
        }

        public enum PaintColor
        {
            White,
            Black,
            Red,
            Blue,
            Yellow,
            Green,
            Violet,
            Purple
        }

        public enum RoomAction
        {
            None,
            EditSize,
            EditColor
        }

    }
}