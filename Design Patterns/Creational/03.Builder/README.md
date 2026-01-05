# Builder Pattern

- If we have an entity with many fields, the constructor will get out of hand and some properties might not even be needed all the time.

- We move the code for the constructor in another _Builder_ class.
- To Ensure that the builder is used, we can make the constructor of the entity private.
- To Ensure that the properties are set correctly, we can add validation in the `build()` method.

- Use the Builder pattern when you want your code to be able to create different representations of some product (for example, stone and wooden houses).

```csharp
public class Car
{
	private int id;
	private string brand;
	private string model;
	//....

	internal Car(int _id, string _brand, string _model /*...*/)
	{
		id = _id;
		brand = _brand;
		model = _model;
		//....
	}
}
```

```csharp
public class CarBuilder
{
	private int _id;
	private string _brand;
	private string _model;
	//....

	public CarBuilder id(int id)
	{
		_id = id;
		return this;
	}
	public CarBuilder brand(string brand)
	{
		_brand = brand;
		return this;
	}
	public CarBuilder model(string model)
	{
		_model = model;
		return this;
	}

	public Car build()
	{
    if (string.IsNullOrEmpty(brand))
    {
      throw new InvalidOperationException("Brand must be set");
    }
    // Other validations...
		return new Car(id, brand, model /*...*/);
	}
}
```

## Director

- The Director is an optional class that is responsible for managing the construction process.

```csharp
public class CarDirector
{
  public Car constructSportsCar(CarBuilder _builder)
  {
    return _builder
      .brand("Ferrari")
      .model("488 Spider")
      //...
      .build();
  }

  public Car constructSUV(CarBuilder _builder)
  {
    return _builder
      .brand("Toyota")
      .model("RAV4")
      //...
      .build();
  }
}
```

## Usage

```csharp
CarBuilder builder = new CarBuilder();
CarDirector director = new CarDirector(builder);
Car sportsCar = director.constructSportsCar();
Car suv = director.constructSUV();
```
