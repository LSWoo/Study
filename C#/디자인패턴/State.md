# State Pattern
```C#

Animator animator;

Public void Start()
{
  animator = Player.GetComponent<Animator>();
}

Public enum State
{
  Idle,
  Walk,
  Run,
  Jump,
  Drive  
}


```
