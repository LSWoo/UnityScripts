using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public List<Item> ItemList = new List<Item>();

    [SerializeField] GameObject InventoryPanel;
    [SerializeField] GameObject[] Slot;
    [SerializeField] Image[] ItemImg;
    [SerializeField] Text[] ItemCount;
    [SerializeField] GameObject SelectedPanel;
    Item SelectedItem;
    [SerializeField] Text ItemName;

    private void Start()
    {
        Managers._Input.KeyAction -= InventoryOnOff;
        Managers._Input.KeyAction += InventoryOnOff;

        ItemImg = new Image[Slot.Length];
        ItemCount = new Text[Slot.Length];
        for (int i = 0; i < Slot.Length; i++)
        {
            ItemImg[i] = Slot[i].transform.GetChild(0).GetComponent<Image>();
            ItemCount[i] = Slot[i].transform.GetChild(1).GetComponent<Text>();
        }
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
        for (int i = 0; i < Slot.Length; i++)
        {
            if (ItemImg[i].gameObject.activeSelf)
                ItemImg[i].gameObject.SetActive(false);
            if (ItemCount[i].gameObject.activeSelf)
                ItemCount[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < ItemList.Count; i++)
        {
            ItemImg[i].sprite = ItemList[i].m_ItemIcon;
            ItemCount[i].text = $"{ItemList[i].m_Count}/{ItemList[i].m_MaxCount}";
            ItemImg[i].gameObject.SetActive(true);

            if (ItemList[i].m_MaxCount != 0)
                ItemCount[i].gameObject.SetActive(true);
        }
    }

    public void SelectPanelOn(int _index)
    {
        if (ItemList.Count != 0 && ItemList[_index].m_ID != 0)
        {
            SelectedItem = Util.GetSlotItemInfo(_index);
            ItemName.text = SelectedItem.m_Name;
            SelectedPanel.SetActive(true);
        }
    }
    public void SelectPanelOff()
    {
        ItemName.text = "";
        SelectedPanel.SetActive(false);
    }
}
