# Singleton Pattern

Singleton 디자인 패턴은 언어에따라 구현하는 방식이 조금씩 다르지만 
중점은 
 
- ex) A 라는 Singleton 을 사용한 클래스가 있다면 A 를 사용해 AA, AB, AC 의 객체를 만들어도 3가지 객체 모두 처음 호출한 AA 를 가르킨다.

```c#
public class Cat
{
   public string Name;
   
   public Cat(string _name)
   {
       Name = _name; 
   }	
}

new Cat AA = new Cat();
new Cat AB = new Cat();
new Cat AC = new Cat();
```
AA, AB, AC 의 이름은 Navi 이다.
