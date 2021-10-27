using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action Keyfalse = null;


    // �Է��� üũ�� ������ �Է��� �־��ٸ� �̺�Ʈ�� ���ĸ� ���ִ� ������ ����
    public void OnUpdate()
    {
        if (Input.anyKey == false) // ����ڰ� �Ű�� �Է��� �ߴ��� Ȯ��.
        {
            if (Keyfalse != null)
                Keyfalse.Invoke();
            return;
        }

        if (KeyAction != null)
            KeyAction.Invoke();
    }
}
