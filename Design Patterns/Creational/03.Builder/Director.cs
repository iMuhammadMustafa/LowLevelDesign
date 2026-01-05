namespace DesignPatterns.Creational.Builder;

public class CarBuilderDirector
{
  public Car ConstructHondaCivic()
  {
    return new HondaCarBuilder()
      .SetModel("Civic")
      .SetYear(2022)
      .SetColor("Blue")
      .SetEngineType("I4")
      .Build();
  }

  public Car ConstructToyotaCamry()
  {
    return new ToyotaCarBuilder()
      .SetModel("Camry")
      .SetYear(2022)
      .SetColor("Red")
      .SetEngineType("V6")
      .Build();
  }
}