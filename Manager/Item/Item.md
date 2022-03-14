```C++
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string m_Name;
    public int m_ID;
    public ItemType m_ItemType;
    public Sprite m_ItemIcon;
    public double m_MaxHealth;
    public float m_ATK;
    public int m_RepairCount;
    public int m_Count;
    public int m_MaxCount;
    public enum ItemType
    {
        Use,
        Build,
        Melee,
        HandGun,
        AssultRifle,
        SniperRifle
    }

    public Item(string _name, int _id, ItemType _itemType,double _maxHealth, float _ATK, int _repairCount, int _count, int _maxCount)
    {
        m_Name = _name;
        m_ID = _id;
        m_ItemType = _itemType;
        m_ItemIcon = Resources.Load<Sprite>($"{m_ItemType}/{m_ID}");
        m_MaxHealth = _maxHealth;
        m_ATK = _ATK;
        m_RepairCount = _repairCount;
        m_Count = _count;
        m_MaxCount = _maxCount;
    }
}
```
