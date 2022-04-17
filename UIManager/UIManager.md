- 리플렉션 기능을 사용해 UI 를 맵핑하는 스크립트  

## Bind 함수 설명  
```Text
T 형식을 받는 함수 Bind를 만들어.
Bind 함수는 string[] 변수 names 에 Enum.GetNames 함수를 사용해 Enum 이 가지고 있는 값들을 넣어줍니다.  
namse 의 값을 이용해 최상위 객체인 UnityEngine.Object[] 형식의 변수 objects를 names.Length 만큼 선언하고
Dictionary 에 키값에는 T 형식을 Value 값에는 objects를 추가해줍니다.  
names.Length 길이만큼 for 문을 돌면서 T 가 GameObject 인지 아닌지 확인해주고 null 인지 아닌지 확인해줍니다.
( 여기서 GameObject 인지 아닌지를 확인하는 이유는 GameObject 는 컴포넌트가 아니기때문에 )
```

```C#
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    // 딕셔너리를 사용해 각 타입마다 오브젝트 배열에 타입에 맞는 오브젝트들을 넣어줍니다.
    // 여러 자식 클래스에서 UIManager 를 상속 받게된다면 static 을 붙여 공유해주도록합니다.
    static Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>(); 
    
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
        Bind<GameObject>(typeof(GameObjectS)); // Text 컴포넌트를 찾아 맵핑해줍니다.
    }
    
    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        // C# 의 리플렉션 기능을 이용하여 Enum 값이 가지고있는 정보를 가져옵니다.
        // 원하는 형식을 찾기위해 <T> 제너릭으로 만들어줍니다.
        string[] names = Enum.GetNames(type); // GetNames 를 사용하면 string[] 형식을 반환하는데 반환값은 type의 목록들이 들어가게됩니다.

        // names.Length 의 길이만큼 Object[] 을 만들어 딕셔너리의 value 값에 넣어줍니다.
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

        return objects[_index] as T; // _objects[_index] 가 가지고 있는 타입은 UnityEngine.Object 이기 떄문에 T 로 캐스팅을 해줘야합니다.
    }

    protected Button GetButton(int _index) { return Get<Button>(_index); }
    protected Text GetText(int _index) { return Get<Text>(_index); }
    protected Image GetImage(int _index) { return Get<Image>(_index); }
    protected GameObject GetGameObject(int _index) { return Get<GameObject>(_index); }
    
}
```
