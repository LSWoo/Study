
# return
return 은 0 ~ 11번째 루프까지 돌고 12번째에서 함수를 완전히 빠져나온다.
```c#
void Test()
{ 
  int Count = 10;

  for(int i = 0; i < Count; i++)
  {
    if(i == 12)
      return;
   
    Console.WriteLine("i");
  }
}
```

# break  
break 의 결과는 이다.
```c#
for(int i = 0; i < Count; i++)
{
  if(i == 12)
    break;
    
  Console.WriteLine("i");
}
```
# continue  
continue 의 결과는 12를 제외한 나머지 숫자들은 모두 로그가 찍힌다.
```c#
for(int i = 0; i < Count; i++)
{
  if(i == 12)
    continue;
    
  Console.WriteLine("i");
}
```
