namespace DesignPatterns.Creational.Prototype;

public static class PrototypeMain
{
  public static void Run()
  {
    var car1 = new Car
    {
      Model = "Model S",
      Color = "Red",
      Engine = new Engine { HorsePower = 670 }
    };

    var car2 = car1.Clone();
    car2.Color = "Blue";

    PrototypeRegistery.Register("Car1", car1);
    PrototypeRegistery.Register("Car2", car2);

    var retrievedCar1 = (Car)PrototypeRegistery.Get("Car1")!;
    retrievedCar1!.Color = "Green";
    var retrievedCar2 = (Car)PrototypeRegistery.Get("Car2")!;
    retrievedCar2!.Engine.HorsePower = 750;

    Console.WriteLine($"Car 1: Model={car1.Model}, Color={car1.Color}, HorsePower={car1.Engine.HorsePower}, Reference {car1.GetHashCode()}");
    Console.WriteLine($"Car 2: Model={car2.Model}, Color={car2.Color}, HorsePower={car2.Engine.HorsePower}, Reference {car2.GetHashCode()}");
    Console.WriteLine($"Retrieved Car 1: Model={retrievedCar1.Model}, Color={retrievedCar1.Color}, HorsePower={retrievedCar1.Engine.HorsePower}, Reference {retrievedCar1.GetHashCode()}");
    Console.WriteLine($"Retrieved Car 2: Model={retrievedCar2.Model}, Color={retrievedCar2.Color}, HorsePower={retrievedCar2.Engine.HorsePower}, Reference {retrievedCar2.GetHashCode()}");

  }
}