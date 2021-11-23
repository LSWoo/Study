```c#
int Count = 100;
```

# return
return 의 결과는 이다.
```c#
for(int i = 0; i < Count; i++)
{
  if(i == 12)
    return;
   
  Console.WriteLine("i");
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
