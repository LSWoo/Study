[ Collison 충돌 조건 ]
```Text
Unity Documentation >> Unity Manual >> Colliders >> Collision action matrix 에 표가 있다.
IsKinematic : 유니티 물리엔진에 영향을 받을건인지에대한 여부
1) 자신 or 상대에게 RigidBody 가 있어야 한다. (IsKinematic : Off)
2) 자신에게 Collider 가 있어야 한다. (IsTrigger : Off)
3) 상대에게 Collider 가 있어야 한다. (IsTrigger : Off)  
```

[ Trigger 충돌 조건 ]
```Text
1) 둘다 Collider 가 있어야 한다.
2) 둘중 하나는 IsTrigger : On
3) 둘중 하나는 RigidBody가 있어야 한다. 
```
Trigger  와 Collison 의 차이점 : Collider는 유니티 물리엔진을 적용시키지만 Trigger는 적용시키지않는다.


