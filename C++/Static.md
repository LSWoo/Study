# Static
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
}
```
