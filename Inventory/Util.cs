using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Util
{
    public static T FindChild<T>(GameObject parents, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (parents == null)
            return null;

        if (!recursive)
        {
            for (int i = 0; i < parents.transform.childCount; i++)
            {
                Transform transform = parents.transform.GetChild(i);

                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach (T component in parents.GetComponentsInChildren<T>(true))
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    public static GameObject FindChild(GameObject parents, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(parents, name, recursive);

        if (transform == null)
            return null;

        return transform.gameObject;
    }

    public static string GetButtonName()
    {
        return EventSystem.current.currentSelectedGameObject.name;
    }
}
