namespace DesignPatterns.Creational.Builder;

public class ToyotaCarBuilder
{
  private Car _car = new Car()
  {
    Make = "Toyota"
  };

  public ToyotaCarBuilder SetModel(string model)
  {
    _car.Model = model;
    return this;
  }

  public ToyotaCarBuilder SetYear(int year)
  {
    _car.Year = year;
    return this;
  }

  public ToyotaCarBuilder SetColor(string color)
  {
    _car.Color = color;
    return this;
  }

  public ToyotaCarBuilder SetEngineType(string engineType)
  {
    _car.EngineType = engineType;
    return this;
  }

  public Car Build()
  {
    return _car;
  }
}