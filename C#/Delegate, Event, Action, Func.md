## Delegate
- Delegate 선언 : delegate 리턴타입 델리게이트명(파라미터타입 변수);
  ex) delegate void TestDelegate(int Num);
  
```c#
delegate void KeyAction;

void Start()
{
 KeyAction += Move;
}
void Move()
{
// 이동
}
```

## Event
```c#
delegate void KeyAction;

void Start()
{
 KeyAction += Move;
}
void Move()
{
// 이동
}
```

## Action
```c#
Action KeyAction;

void Start()
{
 KeyAction += Move;
}
void Move()
{
// 이동
}
```

## Func
- Func 의 선언 : Func<매개변수 타입, 반환 타입> Func이름 = 참조함수; 
```c#
Func<int, string> FuncTest = Move;

string Move(int Num)
{
  return $"Num 은 : {Num} 입니다.";
}

Console.WriteLine(FuncTest(10));
```
**Action 과 Func 의 차이점**
- Action 은 반환값이 없지만 Func 는 반환값이 있어야한다.

