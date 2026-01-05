namespace DesignPatterns.Creational.Builder;

public class HondaCarBuilder
{
  private Car _car = new Car()
  {
    Make = "Honda"
  };

  public HondaCarBuilder SetModel(string model)
  {
    _car.Model = model;
    return this;
  }

  public HondaCarBuilder SetYear(int year)
  {
    _car.Year = year;
    return this;
  }

  public HondaCarBuilder SetColor(string color)
  {
    _car.Color = color;
    return this;
  }

  public HondaCarBuilder SetEngineType(string engineType)
  {
    _car.EngineType = engineType;
    return this;
  }

  public Car Build()
  {
    return _car;
  }
}