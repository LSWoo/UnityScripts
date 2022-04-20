using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfo
{
    public int m_ID;
    public string m_Name;

    public ItemInfo(int _id, string _name)
    {
        m_ID = _id;
        m_Name = _name;
    }
}

interface IItem
{
    void Equip();
    void Use();
}