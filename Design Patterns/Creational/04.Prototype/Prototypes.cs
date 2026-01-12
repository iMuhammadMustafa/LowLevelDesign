namespace DesignPatterns.Creational.Prototype;

public class Vehicle : IClonable<Vehicle>
{
  public required string Model { get; set; }
  public required string Color { get; set; }

  public Vehicle()
  {
  }
  public Vehicle(Vehicle vehicle)
  {
    this.Model = vehicle.Model;
    this.Color = vehicle.Color;
  }

  public virtual Vehicle Clone()
  {
    return this.Clone();
  }
}

public class Engine
{
  public required int HorsePower { get; set; }
}

public class Car : Vehicle
{
  public required Engine Engine { get; set; }

  public override Car Clone()
  {
    return new Car
    {
      Model = this.Model,
      Color = this.Color,
      Engine = new Engine { HorsePower = this.Engine.HorsePower }
    };
  }
}