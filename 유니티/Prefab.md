프리팹 = Class
각 인스턴스 = Instance 와 같다.

Unity 에서는 프리팹으로 여러개의 인스턴스를 만든다면.

스크립트로 하면 이렇다.
```c#
Class Tank
{
 speed = 10;
}
Class CreateManager
{
	void Start()
	{
	  Tank tank1 = New Tank();
	  Tank tank2 = New Tank();
	  Tank tank3 = New Tank();
	  Tank tank4 = New Tank();
	}
}
```

그리고 각각의 인스턴스마다 Speed 를 조절하고싶다면 유니티에선 각 프리팹의 스크립트의 값을 수정할수있고

스크립트에서는
```c#
Class Tank
{
 speed = 10;
}
Class CreateManager
{
	void Start()
	{
	  Tank tank1 = New Tank();
	   tank1.speed = 21;
	  Tank tank2 = New Tank();
	   tank1.speed = 1;
	  Tank tank3 = New Tank();
	  Tank tank4 = New Tank();
	}
}
```
이런식으로 수정할수있다.
