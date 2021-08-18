using Task10.Entities;

namespace Task10.Managers
{
    class InputManager
    {
        public void Input(string manufacturer, string model, uint amount, double price)
        {
            CarDealer carDealer = CarDealer.GetInstance();
            for (int i = 0; i < amount; i++)
            {
                carDealer.AddCar(new Car(manufacturer, model, price));
            }
        }
    }
}
