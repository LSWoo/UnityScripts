using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Managers : MonoBehaviour
{
    private static Managers Instance;
    private static Managers instance { get { Init(); return Instance; } set { } }

    public DataManager dataManager = new DataManager();
    public static DataManager _data { get { return instance.dataManager; } }

    public GoogleSheetManager sheetManager = new GoogleSheetManager();
    public static GoogleSheetManager _sheet { get { return instance.sheetManager; } }

    public static Action OnUpdate;

    static void Init()
    {
        if (Instance == null)
        {
            GameObject Manager = GameObject.Find("@Managers");

            if (Manager == null)
            {
                Manager = new GameObject("@Managers");
                Manager.AddComponent<Managers>();
            }
            DontDestroyOnLoad(Manager);
            Instance = Manager.GetComponent<Managers>();
        }
    }

    private void Awake()
    {
        StartCoroutine(GoogleSheetManager.SetItemData());
    }

    private void Update()
    {
        if (OnUpdate != null)
            OnUpdate.Invoke();
    }
}
