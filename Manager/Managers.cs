using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers Instance;
    private static Managers instance { get { Init(); return Instance;}}

    InputManager inputManager = new InputManager();
    public static InputManager _Input { get { return instance.inputManager; } }

    DataManager dataManager = new DataManager();
    public static DataManager _data { get { return instance.dataManager; } }
    public static UIManager _UI { get { return GameObject.Find("@UIManager").GetComponent<UIManager>(); } }

    private void Start()
    {
        Init();
        _data.SetWeapon();
    }
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
    private void Update()
    {
        inputManager.OnKeyUpdate();
    }
}
