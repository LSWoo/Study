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
### [ 1. 마우스 좌표(2d)의 World 좌표(3d) 를 구하는 과정 ]
```c#
   Vector3 mousepos3d = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x, mousepos.y, Camera.main.nearClipPlane));
```
**Z좌표에 Input.mousePosition.z 를 넣지않고 Camera.main.nearClipPlane (카메라에 near값)을 넣어주는 이유**  
Screen 좌표는 Z값이 0이기때문에 0(Input.mousePosition.z)을 넣게되면 무조건 카메라의 위치를 반환하기때문이다.  
정확한 위치를 알기위해서는 카메라와 스크린좌표사이의 깊이를 알아야하는데 그 깊이가 Near값이기 때문에 Z값에 Camera.main.nearClipPlane를 넣어준다.  
깊이를 구하는 이유는 2D에서 3D로 변환할때 깊이인 z값이 0이면 어떤 물체를 가르키는지 정확하게 알수가없기때문이다.  
### [ 2. 마우스가 가르키는 방향을 구하는 과정 ]
```c#
   Vector3 dir = mousePos - Camera.main.transform.position;
   dir = dir.normalized;
```
거리를 구하는 공식은 방향(dir) = 가야할곳(mousePos) - 현재위치(Camera.main.transform.position) 이기때문이다.  
dir 을 normalized(정규화) 해주는 이유는 normalized 를 하게되면 크기가 1로 통일되기때문이다.  
만약 크기가 1이아닌 각기 다른 크기를 가지게된다면 직선은 1의 속도로 이동하지만 대각선은 1.4의 속도로 이동하는것처럼 각자 다른 속도로 이동하기때문이다.  
### [ 3. Ray를 사용하여 마우스 Wolrd 좌표 구하기 ]
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red, 1.0f);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
```
### [ 4. LayerMask를 사용하여 필요한 오브젝트만 구분하기 ]
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red, 1.0f);

            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Monster");
            
            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
```
