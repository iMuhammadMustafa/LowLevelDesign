namespace DesignPatterns.Creational.Builder;

public class ToyotaCarBuilder
{

  private string? _model;
  private int _year;
  private string? _color;
  private string? _engineType;

  public ToyotaCarBuilder SetModel(string model)
  {
    _model = model;
    return this;
  }

  public ToyotaCarBuilder SetYear(int year)
  {
    _year = year;
    return this;
  }

  public ToyotaCarBuilder SetColor(string color)
  {
    _color = color;
    return this;
  }

  public ToyotaCarBuilder SetEngineType(string engineType)
  {
    _engineType = engineType;
    return this;
  }

  public Car Build()
  {
    var _car = new Car()
    {
      Make = "Toyota",
      Model = _model,
      Year = _year,
      Color = _color,
      EngineType = _engineType
    };
    return _car;
  }
}