Class 는 크게 기본 클래스 와 제네릭 클래스 형식 을 가진다.
클래스는 여러 인터페이스를 구현할 수 있습니다. 
클래스는 기본 클래스를 상속하고 하나 이상의 인터페이스를 구현할 수도 있습니다.

   [ 기본 클래스 ]
```C#
public class Point
{
	int X = { get; }
	int Y = { get; }

	public Point(int x, int y) => (X, Y) = (x, y);
}
```
  [ 제네릭 클래스 ]
```C#
public class Point<TFirst, TSecond>
{
	TFirst = { get; }
	TSecond = { get; }

	public Point(TFirst x, TSecond y) => (TFirst , TSecond ) = (x, y);
}
```
  [ 상속 ]
```C#
public class Point3D : Point
{
	int Z = { get; }

	public Point(int x, int y, int z) : base(x, y)
	{
	 Z = z;
	}
}
```

