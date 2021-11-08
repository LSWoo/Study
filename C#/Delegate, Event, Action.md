## Delegate
```c#
delegate void KeyAction;
```
## Event
```c#
delegate void KeyAction;
```
## Action
```c#
Action KeyAction;
```
## Func
```c#
Func KeyAction;
```
```c#
void Start()
{
 KeyAction += Move;
}
void Move()
{
// 이동
}
```
**Action 과 Func 의 차이점**
- Action 은 반환값이 없지만 Func 는 반환값이 있어야한다.

