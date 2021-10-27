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
        _input.OnUpdate(); // PlayerController ���� ���콺�� Ű���带 üũ�ϴ� Update ���� _input.OnUpdate �� ��ǥ�� üũ���ְԵǹǷ� ���ɻ� �̵��� �ִ�.
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
