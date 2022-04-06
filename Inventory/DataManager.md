```C#
sing System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataManager
{
    public List<ItemInfo> ItemInvenList = new List<ItemInfo>();

    public List<ItemInfo> ItemData = new List<ItemInfo>();
    
    void SetItem()
    {
        ItemInvenList.Add(new ItemData(110001, "기본 칼"));
        ItemInvenList.Add(new ItemData(120002, "기본 갑옷"));
        ItemInvenList.Add(new ItemData(130003, "기본 장갑"));
    }
}
```
