namespace DesignPatterns.Creational.Builder;

public class Car
{
  public string? Make { get; set; }
  public string? Model { get; set; }
  public int Year { get; set; }
  public string? Color { get; set; }
  public string? EngineType { get; set; }

  public override string ToString()
  {
    return $"{Year} {Color} {Make} {Model} with {EngineType} engine.";
  }
}