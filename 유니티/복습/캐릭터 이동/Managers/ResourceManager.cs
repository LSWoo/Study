using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // 사용 이유 : 프로젝트 규모가 커질수록 툴로 한개씩 연결해주기에는 무리가 있기때문이다.
    // 경로는 Asset 폴더 산하의 Resources 폴더를 기준으로 한다.

    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
        // 랩핑을 한 이유 : 혹시라도 로드를 하게되면 Manager 를 통해 접근을 하게되서 알수있기때문에.
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        return Object.Instantiate(prefab, parent);
    }
    public void Destory(GameObject go)
    {
        if (go == null)
            return;
        Object.Destroy(go);
    }
}

