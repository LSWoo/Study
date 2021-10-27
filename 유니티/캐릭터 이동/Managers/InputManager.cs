using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action Keyfalse = null;


    // 입력을 체크한 다음에 입력이 있었다면 이벤트로 전파를 해주는 리스너 패턴
    public void OnUpdate()
    {
        if (Input.anyKey == false) // 사용자가 어떤키를 입력을 했는지 확인.
        {
            if (Keyfalse != null)
                Keyfalse.Invoke();
            return;
        }

        if (KeyAction != null)
            KeyAction.Invoke();
    }
}
