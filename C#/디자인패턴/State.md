# State Pattern
```C#

Animator animator;

Public Void Start()
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
