using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager
{
    const string ItemDataURL = "https://docs.google.com/spreadsheets/d/1vDSMODTegnx3M7vqFJDa7e9X7FTm4uds5kAyllxysuo/export?format=tsv&gid=2130708142&range=A2:D";

    public static IEnumerator SetItemData()
    {
        UnityWebRequest www = UnityWebRequest.Get(ItemDataURL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] row = data.Split('\n');
        int rowSize = row.Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            bool _equip;

            if (column[2] == "false")
                _equip = false;
            else
                _equip = true;

            Managers._data.ItemDataList.Add(new ItemInfo(int.Parse(column[0]), column[1], _equip));
        }
    }
}