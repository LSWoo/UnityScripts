using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public List<Weapon> WeaponList = new List<Weapon>();

    public void SetWeapon()
    {
// 구글 쓰레드시트를 이용해 구현
        WeaponList.Add(new Weapon("Axe", 100001, 100f, 15f, 0, 0, 0));
        WeaponList.Add(new Weapon("Knife", 100002, 100f, 10f, 0, 0, 0));
        WeaponList.Add(new Weapon("Shovel", 100003, 100f, 10f, 0, 0, 0));
    }
    public static void Save()
    {
    }
    public static void Load()
    {
    }
}
