- 리플렉션 기능을 사용해 UI 를 맵핑하는 스크립트입니다.
- 
```C#
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    // 딕셔너리를 사용해 각 타입마다 오브젝트 배열안에 타입에 맞는 오브젝트들을 넣어줍니다.
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>(); 
    
    enum Buttons
    {
        Test1_btn,
        Test2_btn,
    }
    enum Texts
    {
     Test1_txt,
     Test2_txt,
    }
    enum GameObjects
    {
     Test1_obj,
     Test2_obj,
    }
    
    private void Start()
    {
        Bind<Button>(typeof(Buttons)); // 리플렉션을 사용해서 enum 타입을 넘겨줍니다. Button 컴포넌트를 찾아 맵핑해줍니다.
        Bind<Text>(typeof(Texts)); // Text 컴포넌트를 찾아 맵핑해줍니다.
        Bind<GameObject>(typeof(GameObject)); // Text 컴포넌트를 찾아 맵핑해줍니다.
    }
    
    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        // C# 의 리플렉션 기능을 이용하여 Enum 값이 가지고있는 정보를 가져옵니다.
        // 원하는 형식을 찾기위해 <T> 제너릭으로 만들어줍니다.
        string[] names = Enum.GetNames(type); // GetNames 를 사용하면 string[] 형식을 반환하는데 반환값은 type의 목록들이 들어가게됩니다.

        // names.Length 의 길이만큼 Object[] 을 만들어 딕셔너리의 value 값에 넣어줍니다.
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for(int i = 0; i < names.Length; i++)
        {
            objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }
}
```
