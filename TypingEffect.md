```C++
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text TextUI;
    string Contents = "Test";
    
    IEnumerator StartLetter()
    {
        float StartSec = 2f;
        float TypeSec = 0.1f;
        
        yield return new WaitForSeconds(StartSec);
        for(int i = 0; i < Contents.Length; i++)
        {
           TextUI.text = Contents.Substring(0, i);
            yield return new WaitForSeconds(TypeSec);
        }
    }
}

```
