using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public List<Item> ItemnList = new List<Item>();

    public void Start()
    {
        // 구글 스프레드시트로 관리
        // ----------------------------------------------------------- Weapons -----------------------------------------------------------
        ItemnList.Add(new Item("Axe"           , 100001, Item.ItemType.Melee, 100f, 15f, 0, 0, 0)) ;
        ItemnList.Add(new Item("Knife"         , 100002, Item.ItemType.Melee, 100f, 10f, 0, 0, 0));
        ItemnList.Add(new Item("Shovel"        , 100003, Item.ItemType.Melee, 100f, 10f, 0, 0, 0));
        // ----------------------------------------------------------- Build -----------------------------------------------------------
        ItemnList.Add(new Item("Storage"       , 400001, Item.ItemType.Build, 100f, 15f, 0, 0, 0));
        ItemnList.Add(new Item("Sleeping Bag"  , 400002, Item.ItemType.Build, 100f, 10f, 0, 0, 0));
        ItemnList.Add(new Item("Campfire"      , 400003, Item.ItemType.Build, 100f, 10f, 0, 0, 0));
        ItemnList.Add(new Item("Standing Torch", 400004, Item.ItemType.Build, 100f, 10f, 0, 0, 0));
        ItemnList.Add(new Item("Workbench"     , 400005, Item.ItemType.Build, 100f, 10f, 0, 0, 0));
    }
    public static void Save()
    {
    }
    public static void Load()
    {
    }
}
