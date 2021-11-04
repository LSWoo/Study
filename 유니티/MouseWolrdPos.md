```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycasting : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos = Input.mousePosition; // 마우스 2D좌표 (스크린은 2D 이기때문에 Z값은 0이다.)
            Vector3 mousepos3d = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x, mousepos.y, Camera.main.nearClipPlane));
            
            Vector3 dir = mousepos - Camera.main.transform.position;
            dir = dir.normalized;
            Debug.DrawRay(Camera.main.transform.position, dir * 100f, Color.red, 1.0f);

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100f))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
```
###[ 1. 마우스 좌표(2d)의 World 좌표(3d) 를 구하는 과정 ]
```c#
Vector3 mousepos3d = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x, mousepos.y, Camera.main.nearClipPlane));
```
**Z좌표에 Input.mousePosition.z 를 넣지않고 Camera.main.nearClipPlane (카메라에 near값)을 넣어주는 이유**  
Screen 좌표는 x값과 y값만 존재하기때문에 z값에 0(Input.mousePosition.z)을 넣게되면 무조건 카메라의 위치를 반환하기때문이다.  
그렇기때문에 정확한 위치를 알기위해서는 카메라와 스크린좌표사이의 깊이를 알아야하는데 그 깊이가 Near값이기 때문이다.  
깊이를 구하는 이유는 3d상에서 2d 좌표로 변환할때 깊이인 z값이 0이면 어떤 물체를 가르키는지 정확하게 알수가없기때문이다.  
