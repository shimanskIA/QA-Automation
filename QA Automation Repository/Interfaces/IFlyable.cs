using Task5.Entities;

namespace Task5.Interfaces
{
    public interface IFlyable
    {
        public void FlyTo(Coordinate coordinate);
        public double GetFlyTime(Coordinate coordinate);

    }
}
