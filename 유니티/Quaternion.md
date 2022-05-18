### Quaternion

transform.rotation 은 Quaternion 이라는 형식으로 저장되는데

저장할때 Vector3 를 사용하지않고 Quaternion 으로 저장하는 이유는

x, y, z 만 사용하여 만들게 되면 짐벌록 이라는 현상이 생기기 때문이다.

짐벌록은 x축 y축 z축이 각각 회전 하다보면 겹치는 축이 생기는데

그 축이 겹치게 되면서 회전이 먹통이 되는 현상을 얘기한다.

### Quaternion.Euler

Quaternion.Euler 함수는 매개변수로 Vector3 형식을 받게되는데

이 함수는 Vector3 형식을 Quaternion 으로 변환 시켜주는 함수이다.

Quaternion.Euler(0.0f, Time.deltaTime \* turnspeed, 0.0f) 를 사용하지 않고

Quaternion.Euler(0.0f, a, 0.0f) 를 사용한 이유는  
직접적으로 연산을 하게되면 360도가 넘어가면 계산에 실패하는 경우가 생기기 때문에 절대값을 넣어주었다.

```c#
    public float turnspeed = 90f;
    flaot a = 0;

    void Update()
    {
        a += Time.deltaTime * turnspeed;
        transform.rotation = transform.rotation = Quaternion.Euler(0.0f, a, 0.0f);
    }
```

### Quaternion.LookRotation

Quaternion.LookRotation 함수는 매개변수로 Vector3 를 받고 Vector3 방향으로 바라보게하는 함수이다.

아래 코드들을 사용하여 간단한 캐릭터 회전을 구현해 보았다.

```c#
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        else if (Input.GetKey(KeyCode.A))
            transform.rotation = Quaternion.LookRotation(Vector3.left);
        else if (Input.GetKey(KeyCode.S))
            transform.rotation = Quaternion.LookRotation(Vector3.back);
        else if (Input.GetKey(KeyCode.D))
            transform.rotation = Quaternion.LookRotation(Vector3.right);
        else
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
    }
```

### Quaternion.Slerp

Quaternion.Slerp 함수는 매개변수로 Quaternion A, Quternion B, float t 를 받는데

캐릭터가 Vector3.forward 방향을 바라보고 있다고 가정해보겠다.

A값이 현재 바라보는 방향 B 값이 Vector3.left 라고 한다면

t 는 A값과 B값의 비율 이라고 생각하면 되는데 0f ~ 1f 까지의 값을 넣을 수 있다.

예를 들어 t 를 0.5f 를 넣는다고 가정하면 A 와 B 의 비율으 5:5 이므로 조금 더 부드러운 회전을 볼 수 있다.

만약 t 에 0을 넣는다면 forward 의 비율이 1이므로 forward 방향을 바라볼것이고

만약 t 에 1을 넣는다면 Quaternion.LookRotation(Vector3.left)를 사용한 것과 결과가 같을것이다.

아래 코드를 통해 실험해 본 결과 설명과 같이 t값에 0을 넣게되면 방향 전환이 이루어 지지 않고

t값에 1을 넣게 되면 Quaternion.LookRotation(Vector3.left)를 사용한 것과 결과가 같다.

t값에 0.5를 넣은 경우 Quaternion.LookRotation(Vector3.left)를 사용한것 보다 조금 더 부드러운 회전을 보여준다.

```c#
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 1f);
        else if (Input.GetKey(KeyCode.A))
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 1f);
        else if (Input.GetKey(KeyCode.S))
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 1f);
        else if (Input.GetKey(KeyCode.D))
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 1f);
    }
```


