```C++ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo

{
    // ----------------------------------------------------------- Stats -------------------------------------------------------------
    public float m_hungry = 100f;
    public float m_thirsty = 100f;
    public float m_stamina = 100f;

    public void ShowMetabolism()
    {
        Managers._UI.HungryUI.fillAmount = m_hungry / 100f;
        Managers._UI.ThirstyUI.fillAmount = m_thirsty / 100f;
        Managers._UI.StaminaUI.fillAmount = m_stamina / 100f;
    }
}
```
