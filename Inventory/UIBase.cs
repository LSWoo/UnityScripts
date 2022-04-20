using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIBase : MonoBehaviour
{
    static Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

   public enum Buttons
    {
        Menu_Btn,

    }
   public enum Texts
    {
        Empty_txt,

    }
   public enum GameObjects
    {
        InvenContents,

    }
   public enum Images
    {

    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);

            if (objects[i] == null)
                Debug.Log($"Failed to bind {names[i]}");
        }
    }

    T Get<T>(int _index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;

        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[_index] as T;
    }

    protected Button GetButton(int _index) { return Get<Button>(_index); }
    protected Text GetText(int _index) { return Get<Text>(_index); }
    protected Image GetImage(int _index) { return Get<Image>(_index); }
    protected GameObject GetGameObject(int _index) { return Get<GameObject>(_index); }

}
