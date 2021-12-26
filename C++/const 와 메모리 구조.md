# const
- constant 의 약자, 한번 정지면 절대 바뀌지 않을 값들, 변수르 상수화 한다고 함.
- const 를 붙였으면 초기값을 반드시 지정해야한다.
# 메모리 구조 
```Assembly
[데이터 영역]
// .data
int a = 2;

// .bss
int b;

// .rodata
const char* msg = "HelloWorld";

[스택 영역]
int main()
{
  int c = 3;
}
```
