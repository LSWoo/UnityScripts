using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    #region KeySetting
    public KeyCode InventoryKey = KeyCode.Tab; // 인벤토리 열기
    public KeyCode GetItemKey = KeyCode.E; // 아이템 줍기
    #endregion

    public Action KeyAction = null;
    
    public void OnKeyUpdate()
    {
        if (!Input.anyKey)
        {
            if (KeyAction != null)
                KeyAction.Invoke();

            return;
        }

        if (KeyAction != null)
            KeyAction.Invoke();
    }
}
