using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance;
    public static Managers instance { get { Init(); return Instance; } }
    

    InputManager _input = new InputManager();
    public static InputManager Input { get { return instance._input; } }

    private void Update()
    {
        _input.OnUpdate(); // PlayerController 에서 마우스나 키보드를 체크하던 Update 문을 _input.OnUpdate 가 대표로 체크해주게되므로 성능상 이득이 있다.
    }

    static void Init()
    {
        if (Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject("@Managers");
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            Instance = go.GetComponent<Managers>();
        }
    }
}
