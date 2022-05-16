### transform.Translate

transform.Translate(Vector3 translation) 함수는 이렇게 생겼는데

transform의 설명을 보면 transform 컴포넌트를 이 오브젝트에 붙이겠다고 적혀있다.

Translate는 방향과 거리로 transform 을 이동하겠다이다.

매개변수인 Vector3 형식을 가진 translation 은 옮김이라는 뜻을 가지고 있기 때문에

설명을 합쳐보면 transform 을 Vector3 방향과 거리로 옮김이라는 명령을 하는 함수로 보인다.

그 설명이 맞는지 확인하기 위해 아래 코드를 실행시켜본 결과

Cube 오브젝트가 상당히 빠른 속도로 움직이는걸 확인 할 수있었다.

```C#
    void Update()
    {
        transform.Translate(Vector3.forward);
    }
```

### transform.eulerAngles

transform.eulerAngles 의 설명은 방향을 eulerAngles만큼 회전 시킨다이다.

유니티 공식 문서의 설명을 보면 eulerAngles의 값에는 절대값인 경우에만 사용하도록 나와있다.

해당 각도가 360도를 넘어서면 계산에 실패할 수 있기 때문에 값을 증가 시키지 말라고 설명이 되어있다.

만약 각도가 360도를 넘어서는 경우라면 transform.Rotate 를 사용하도록 나와있다.

eulerAngles를 사용하여 각도가 360도를 넘어 계산에 실패할때가 궁금해 아래 코드를 사용해 한번 실패해 보았다.

당연한 결과지만 정말 계산에 실패하여 회전이 안된다..

```C#
    public float turnspeed = 90f;

    void Update()
    {
        transform.eulerAngles = new Vector3(0.0f, Time.deltaTime * turnspeed, 0.0f);
    }
```

하지만 a 라는 절대값을 사용하여 코드를 실행해본 결과 회전이 잘된다.

```C#
    public float turnspeed = 90f;
    float a = 0;

    void Update()
    {
        a += Time.deltaTime * turnspeed;
        transform.eulerAngles = new Vector3(0.0f, a, 0.0f);
    }
```

차이점은 eulerAngles에 절대값을 대입했느냐 아니면 연산값을 대입했느냐의 차이인데

실행 결과는 많이 달랐다. 이유가 궁금하다..

### transform.Rotate

Rotate의 설명은 x 축을 중심으로 eulerAngles.x 도만큼 y 축을 중심으로 eulerAngles.y 도만큼 z 축을 중심으로 eulerAngles.z 도만큼 회전을 적용한다고 해석할 수 있다.

### transform.rotation

```C#
    public float turnspeed = 90f;

    void Update()
    {
        transform.eulerAngles = new Vector3(0.0f, a, 0.0f);
    }
```

### Quaternion

```C#
    public float turnspeed = 90f;

    void Update()
    {
        transform.eulerAngles = new Vector3(0.0f, a, 0.0f);
    }
```
