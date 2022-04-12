```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Util
{
    // parents 에 최상위 부모와 name 에 이름을 받아줍니다.
    // name 에 이름을 입력하지 않으면 이름은 비교하지 않고 Type 에만 해당하면 return 을 해줍니다.
    // recursive 는 재귀적으로 찾을것인지 true 라면 자식의 자식까지 false 라면 parents 의 하위 자식만 찾아줍니다.
    // where T : UnityEngine.Object 를 사용해 UnityEngine.Object 인것만 찾아줍니다.
    
    public static T FindChild<T>(GameObject parents, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (parents == null)
            return null;

        if (!recursive)
        {
            for(int i = 0; i < parents.transform.childCount; i++)
            {
                Transform transform = parents.transform.GetChild(i);
                
                // string.IsNullOrEmpty 를 사용해 name 이 Null 이거나 transform.name의 이름과 name 이 같다면 transform 에서 T 타입을 가져옵니다.
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
            // GetComponentsInChildren 의 includeInactive 를 true 로 설정해 활성화되지 않은 오브젝트들도 찾아줍니다.
            foreach(T component in parents.GetComponentsInChildren<T>(true))
            {
                // string.IsNullOrEmpty 를 사용해 name 이 Null 이거나 비어있으면 component 를 return 해줍니다.
                if (string.IsNullOrEmpty(name) || component.name == name) 
                    return component;
            }
        }

        return null;
    }
    
    public static GameObject FindChild(GameObject parents, string name = null, bool recursive = false)
    {
        // GameObject 는 컴포넌트가 아니기때문에 Transform 을 먼저 찾아 Transform 의 GameObject 를 return 해줍니다.
        Transform transform = FindChild<Transform>(parents, name, recursive);

        if (transform == null)
            return null;

        return transform.gameObject;
    }
}

```
