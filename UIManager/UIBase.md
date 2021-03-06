- 리플렉션을 사용해 UI 맵핑

### Bind 함수 
```Text
T 형식을 받는 함수 Bind를 만들어줍니다.
여기서 매개변수로 Type 형식을 받는 이유는 Enum값의 이름들은 원래 가져올수 없지만 리플렉션 기능을 활용해 Enum 값들을 받아오기 위해서입니다.
string[] 변수 names 를 선언하고 값으로 Enum 이 가지고 있는 값들을 Enum.GetNames 함수를 사용해 넣어줍니다.  
최상위 객체인 UnityEngine.Object[] 형식의 변수 objects를 names.Length 만큼 선언합니다.
Dictionary.Add(typeof(T), objects); Key값은 T 를 Value값은 UnityEngine.Object[] 를 추가해줍니다. 
타입 별로 분류하기 위해 Key값에 리플렉션을 사용하여 T 의 타입을 가져옵니다. 
for 문을 사용하여 T 가 GameObject 인지 아닌지 null 인지 아닌지 확인해줍니다.
( 여기서 GameObject 인지 아닌지를 확인하는 이유는 GameObject 는 컴포넌트가 아니기때문입니다. )
```


### Get 함수
```Text
T 타입을 받아 T 타입으로 반환하는 함수 Get 함수를 만들어줍니다.
UnityEngine.Object[] 타입의 objects 변수를 선언하고 objects[_index] 를 as 를 사용해 T 타입으로 캐스팅해 반환해줍니다.
TryGetValue 함수는 반환값으로 Bool 값을 첫번째 매개변수로 Key 값을 두번째 매개변수로 Value 값을 받아 Dictionary 에 해당 Key 값에 Value 가 True 인지 False 인지를 반환하는 함수입니다.
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
