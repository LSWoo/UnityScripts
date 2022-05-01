using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : UIBase
{
    List<Button> Menu_btn = new List<Button>();
    List<GameObject> Slots = new List<GameObject>();
    List<ItemInfo> SelectedInvenList = new List<ItemInfo>();

    ItemInfo SelectedItem;

    Menu SelectMenu = Menu.Weapon;
    enum Menu
    {
        Weapon,
        Cloth,
        Use,
    }

    private void Start()
    {
        SetGameObject();
        AddButtonListener();
    }

    void SetGameObject()
    {
        for (int i = 0; i < Enum.GetValues(typeof(Buttons)).Length; i++)
        {
            if (Enum.GetName(typeof(Buttons), i).Contains("Menu0"))
                Menu_btn.Add(GetButton(i));
        }

        for (int i = 0; i < GetGameObject((int)GameObjects.Inventory_Contents).transform.childCount; i++)
            Slots.Add(GetGameObject((int)GameObjects.Inventory_Contents).transform.GetChild(i).gameObject);
    }

    void AddButtonListener()
    {
        GetButton((int)Buttons.Inventory_On_btn).onClick.AddListener(OnInventory);
        GetButton((int)Buttons.Inventory_Close_btn).onClick.AddListener(CloseInventory);
        for (int i = 0; i < Menu_btn.Count; i++)
        {
            Menu_btn[i].onClick.AddListener(ChangedMenu);
            Menu_btn[i].onClick.AddListener(InvenSlotUpdate);
        }
        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i].GetComponent<Button>().onClick.AddListener(GetSlotItem);
        }
    }
    void OnInventory()
    {
        GetGameObject((int)GameObjects.Inventory_Panel).SetActive(true);
        InvenSlotUpdate();
    }
    void CloseInventory()
    {
        GetGameObject((int)GameObjects.Inventory_Panel).SetActive(false);
    }
    void GetClicKButton()
    {

    }
    void ChangedMenu()
    {
        for (int i = 0; i < Menu_btn.Count; i++)
            if (Util.GetButton().name == Menu_btn[i].name)
                SelectMenu = (Menu)i;
    }
    void GetSlotItem()
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            if (Util.GetButtonName() == Slots[i].name)
               SelectedItem = Managers._data.ItemDataList[i];
        }
    }
    void InvenSlotUpdate()
    {
        SelectedInvenList.RemoveRange(0, SelectedInvenList.Count);
        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i].SetActive(false);
            Slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            Slots[i].transform.GetChild(2).GetComponent<Image>().sprite = null;
        }

        if (Managers._data.ItemInvenList.Count == 0)
            GetText((int)Texts.Inventory_Empty_txt).gameObject.SetActive(true);
        else
        {
            GetText((int)Texts.Inventory_Empty_txt).gameObject.SetActive(false);

            SelectedInvenListUpdate(SelectMenu.ToString());

            for (int i = 0; i < SelectedInvenList.Count; i++)
            {
                Slots[i].SetActive(true);
                Slots[i].transform.GetChild(1).GetComponent<Text>().text = SelectedInvenList[i].m_Name;
                Slots[i].transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Items/{SelectedInvenList[i].m_ID}");
                if (SelectedInvenList[i].m_isEquip)
                    Slots[i].transform.GetChild(3).gameObject.SetActive(true);
                else
                    Slots[i].transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }
    void SelectedInvenListUpdate(string _itemCode)
    {
        // _targetIndex = 
        // _startIndex = 
        int _targetIndex = 1;
        int _startIndex = 1;

        for (int i = 0; i < Managers._data.ItemDataList.Count; i++)

            if (0 == Managers._data.ItemDataList[i].m_ID.ToString().IndexOf($"{_itemCode}"))
            {
                if (_targetIndex == Managers._data.ItemDataList[i].m_ID.ToString().IndexOf(_itemCode, _startIndex))
                {
                    SelectedInvenList.Add(Managers._data.ItemDataList[i]);
                }
            }
    }
}
