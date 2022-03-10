using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryPanel;
    [SerializeField] GameObject[] Slot;

    private void Start()
    {
        Managers._Input.KeyAction -= InventoryOnOff;
        Managers._Input.KeyAction += InventoryOnOff;
    }

    void InventoryOnOff()
    {
        if (Input.GetKeyDown(Managers._Input.InventoryKey))
        {
            if (!InventoryPanel.activeSelf)
            {
                Managers._UI.is2D = true;
                Refresh_InvenSlot();
                InventoryPanel.SetActive(true);
            }
            else
            {
                InventoryPanel.SetActive(false);
                Managers._UI.is2D = false;
            }
        }
    }
    void Refresh_InvenSlot()
    {
        Image ItemImg;
        Text ItemCount;
        for (int i = 0; i < Slot.Length; i++)
        {
            ItemImg = Slot[i].transform.GetChild(0).GetComponent<Image>();
            ItemCount = Slot[i].transform.GetChild(1).GetComponent<Text>();
            ItemCount.text = $"{Managers._data.WeaponList[0].m_Count}/{Managers._data.WeaponList[0].m_MaxCount}";
        }
        ShowItemCount();
    }
    void ShowItemCount()
    { 
    }
}

