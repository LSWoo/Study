
# return
- return 은 x 가 0 ~ 11번째 루프까지 돌고 12번째에서 함수를 완전히 빠져나온다.
```c#
void Test()
{ 
  int Count = 10;

  for(int i = 0; i < Count; i++)
  {
    for(int x = 0; x < Count; x++)
    {
        if(x == 12)
           return;
 -------- return 후에는 실행되지않음 --------   
        Console.WriteLine("x");
    }
    Console.WriteLine("i");
  }
 Console.WriteLine("return Test");
}
```

# break  
- break의 결과는 x 가 0 ~ 5 번째 루프까지 돌고 break 가 있는 for문을 빠져나온 후 다시 i 번째 for문을 돈다.
```c#
void Test()
{ 
    int Count = 10;

    for (int i = 0; i < Count; i++)
    {
        for (int x = 0; x < Count; x++)
        {
            if (x == 5)
                break;
            Debug.Log($" x값 {x}");
        }
        Debug.Log($" i값 {i}");
    }
    Debug.Log($" for문 밖");
}
```
# continue  
- continue 의 결과는 x 가 5인 루프를 제외한 나머지 루프들은 모두 정상적으로 실행된다.
- x 가 5인 루프는 break 를 만나기전까지 정상적으로 실행된다.
```c#
    void Test()
    { 
        int Count = 10;

        for (int i = 0; i < Count; i++)
        {
            for (int x = 0; x < Count; x++)
            {
                Debug.Log($"x 값 {x}");
                if (x == 5)
                    continue;

                Debug.Log($"x 값 {x}");
            }
            Debug.Log($"i 값 {i}");
        }
    }
```
