# State Pattern
```C#

Animator animator;

public void Start()
{
  animator = Player.GetComponent<Animator>();
}

public enum State
{
  Idle,
  Walk,
  Run,
  Jump,
  Drive  
}


```
