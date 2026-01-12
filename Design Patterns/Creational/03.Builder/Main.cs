namespace DesignPatterns.Creational.Builder;

public static class BuilderMain
{
  public static void Run()
  {
    var director = new CarBuilderDirector();

    Car hondaCivic = director.ConstructHondaCivic();
    Console.WriteLine("Built Car: " + hondaCivic);

    Car toyotaCamry = director.ConstructToyotaCamry();
    Console.WriteLine("Built Car: " + toyotaCamry);
  }
}