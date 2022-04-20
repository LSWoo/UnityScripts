using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfo
{
    public int m_ID;
    public string m_Name;
    public bool m_isEquip;

    public ItemInfo(int _id, string _name, bool _equip = false)
    {
        m_ID = _id;
        m_Name = _name;
        m_isEquip = _equip;
    }
}

interface IItem
{
    void Equip();
    void Use();
}