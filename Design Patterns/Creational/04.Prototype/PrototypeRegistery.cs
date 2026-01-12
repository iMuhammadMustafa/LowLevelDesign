namespace DesignPatterns.Creational.Prototype;

public static class PrototypeRegistery
{
  public static Dictionary<string, Vehicle> Vehicles = new Dictionary<string, Vehicle>();


  public static void Register(string key, Vehicle vehicle)
  {
    Vehicles[key] = vehicle;
  }
  public static Vehicle? Get(string key)
  {
    if (Vehicles.ContainsKey(key))
    {
      return Vehicles[key].Clone();
    }
    return null;
  }
}