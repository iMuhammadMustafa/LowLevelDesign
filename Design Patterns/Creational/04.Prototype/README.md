# Prototype Pattern

- If we want to create a new object by copying an existing object, we can use the Prototype pattern.
- The Prototype pattern involves implementing a `clone()` method that creates a copy of the object. Either by creating an interface or adding a method to the base class.

```csharp
public class Vehicle : ICloneable
{
		public string Brand { get; set; }
		public string Model { get; set; }

		public Vehicle(Vehicle vehicle)
		{
				Brand = vehicle.Brand;
				Model = vehicle.Model;
		}

		public override Vehicle Clone()
		{
				return new Vehicle(this);
		}
}

public class Car : Vehicle
{
		public int NumberOfDoors { get; set; }

		public Car(Car car) : base(car)
		{
				NumberOfDoors = car.NumberOfDoors;
		}

		public override Car Clone()
		{
				return new Car(this);
		}
}
```

## Problem with Shallow Copy

- If the object contains references to other objects, a shallow copy will copy the reference to the object and not create a new object.
- To solve this problem, we can implement a deep copy by cloning the referenced objects as well.

```csharp
public class Engine
{
		public int HorsePower { get; set; }
}
public class Car : ICloneable
{
		public string Brand { get; set; }
		public Engine Engine { get; set; }

		public Car(Car car)
		{
				Brand = car.Brand;
				// Engine = car.Engine; // Shallow copy
				Engine = new Engine { HorsePower = car.Engine.HorsePower }; // Deep copy
		}

		public override Car Clone()
		{
				return new Car(this);
		}
}
```

## Problem with Circular References

- If the object graph contains circular references, we need to keep track of the objects that have already been cloned to avoid infinite loops.

```csharp
public class Node : ICloneable
{
		public string Name { get; set; }
		public Node Next { get; set; }

		public Node(Node node, Dictionary<Node, Node> clonedNodes)
		{
				Name = node.Name;
				if (node.Next != null)
				{
						if (clonedNodes.ContainsKey(node.Next))
						{
								Next = clonedNodes[node.Next];
						}
						else
						{
								Next = new Node(node.Next, clonedNodes);
								clonedNodes[node.Next] = Next;
						}
				}
		}

		public override Node Clone()
		{
				var clonedNodes = new Dictionary<Node, Node>();
				return new Node(this, clonedNodes);
		}
}
```

## Prototype Registry

- Is a central place to store and manage prototypes, that you need often.

```csharp
public static class PrototypeRegistry
{
		private static Dictionary<string, ICloneable> prototypes = new Dictionary<string, ICloneable>();

		public static void RegisterPrototype(string key, ICloneable prototype)
		{
				prototypes[key] = prototype;
		}

		public static ICloneable GetPrototype(string key)
		{
				if (prototypes.ContainsKey(key))
				{
						return prototypes[key].Clone();
				}
				throw new ArgumentException("Prototype not found");
		}
}
```

## Usage

```csharp
class Program
{
		static void Main(string[] args)
		{
				var car1 = new Car
				{
						Brand = "Toyota",
						Engine = new Engine { HorsePower = 150 }
				};

				var car2 = car1.Clone();
				car2.Brand = "Honda";
				car2.Engine.HorsePower = 200;

				PrototypeRegistry.RegisterPrototype("car1", car1);
				PrototypeRegistry.RegisterPrototype("car2", car2);

				var clonedCar1 = (Car)PrototypeRegistry.GetPrototype("car1");
				var clonedCar2 = (Car)PrototypeRegistry.GetPrototype("car2");

				Console.WriteLine($"Car1: {car1.Brand}, Engine HP: {car1.Engine.HorsePower}");
				Console.WriteLine($"Car2: {car2.Brand}, Engine HP: {car2.Engine.HorsePower}");
				Console.WriteLine($"Cloned Car1: {clonedCar1.Brand}, Engine HP: {clonedCar1.Engine.HorsePower}");
				Console.WriteLine($"Cloned Car2: {clonedCar2.Brand}, Engine HP: {clonedCar2.Engine.HorsePower}");
		}
}
```
