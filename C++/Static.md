# Static
```Text
Static 변수는 Class 에서 실체화 하는 변수이다.
인스턴스화를 할때에는 new 를 하면서 인스턴스화 된 오브젝트가 실체화 되면서 각각 변수를 가졌지만
Static 변수는 Class 에서 실체화 하기 때문에 오브젝트에서 실체화 되지 않는다.
```
```C++
public class Test()
{
  int Main()
  {
    // 원형(Class)을 사용하여 인스턴스화한다.
    Dog Jack = new Dog(); 
    Dog Pack = new Dog();
    Dog Kack = new Dog();
    // Jack, Pack, Kack 인스턴스화 된 3개의 오브젝트들은 각각 독립적이다.
    // Jack, Pack, Kack 각각 Name, Age, Weight, Sound 변수를 가지고있고 메모리에는 총 Name 3개 Age 3개 Weight 3개 Sound 3개가 올라가게된다.
    Console.WriteLine(Jack.Name);
    Console.WriteLine(Pakc.Name);
  }
}

public class Dog()
{
  public string Name;
  public string Sound;
  public int Age;
  public int Weight;
  public static Count;
  
  public static void DogCount()
  {
    Console.WriteLine(Count);
  }
}
```
