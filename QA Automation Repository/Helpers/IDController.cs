namespace Task8.Helpers
{
    public class IDController
    {
        private static int _id = 0;

        public static int GetId()
        {
            int id = _id;
            _id++;
            return id;
        }
    }
}
