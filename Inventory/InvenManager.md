```C#
public class Inventory : MonoBehaviour
{
    List<GameObject> Slots = new List<GameObject>();
    List<ItemInfo> SelectInvenList = new List<ItemInfo>();
  
    public GameObject Contents;
    public Button[] Menu_Btn
    public Text Empty_txt;
    
    GameObject SelectBtn;
    string SelectPanel;
    
    private void Start()
    {
        SetSlots();
        AddButtonListener();
    }
  
    void SetSlots()
    {
        for (int i = 0; i < Contents.transform.childCount; i++)
            Slots.Add(Contents.transform.GetChild(i).gameObject);
    }
                                                          
    void AddButtonListener()
    {
        for (int i = 0; i < Menu_Btn.Length; i++)
        {
            Menu_Btn[i].onClick.AddListener(GetClicKButton);
        }
        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i].GetComponent<Button>().onClick.AddListener(GetClicKButton);
            Slots[i].GetComponent<Button>().onClick.AddListener(SelectFuniture);
        }
    }
    
    void GetClicKButton()
    {
        SelectBtn = EventSystem.current.currentSelectedGameObject;
        switch (SelectBtn.name)
        {
            case "Menu_Btn_01":
                SelectPanel = "Menu01";
                break;
            case "Menu_Btn_02":
                SelectPanel = "Menu02";
                break;
            case "Menu_Btn_03":
                SelectPanel = "Menu03";
                break;
            case "Menu_Btn_04":
                SelectPanel = "Menu04";
                break;
            case "Menu_Btn_05":
                SelectPanel = "Menu05";
                break;
        }
        InvenSlotUpdate();
    }
  
    void InvenSlotUpdate()
    {
        int _itemCode = 2;
        int _targetIndex = 1;
        int _startIndex = 1;

        SelectInvenList.RemoveRange(0, SelectInvenList.Count);
        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i].SetActive(false);
            Slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            Slots[i].transform.GetChild(2).GetComponent<Image>().sprite = null;
        }

        if (Managers._data.InvenList.Count == 0)
            Empty_txt.gameObject.SetActive(true);
        else
        {
            Empty_txt.gameObject.SetActive(false);

            switch (SelectPanel)
            {
                case "Menu01":
                            for (int i = 0; i < _data.FunitureInvenList.Count; i++)
                            {
                                if (0 == _data.FunitureInvenList[i].m_ID.ToString().IndexOf($"{ItemCode}"))
                                {
                                    if (_targetIndex == _data.FunitureInvenList[i].m_ID.ToString().IndexOf("1", StartIndex))
                                    {
                                        SelectInvenList.Add(_data.FunitureInvenList[i]);
                                    }
                                }
                            }
                    break;                                                                                                  
                case "Menu02":

                            for (int i = 0; i < _data.FunitureInvenList.Count; i++)
                            {
                                if (0 == _data.FunitureInvenList[i].m_ID.ToString().IndexOf($"{ItemCode}"))
                                {
                                    if (_targetIndex == _data.FunitureInvenList[i].m_ID.ToString().IndexOf("2", StartIndex))
                                    {
                                        SelectInvenList.Add(_data.FunitureInvenList[i]);
                                    }
                                }
                            }
                    break;                                                                                                  
                case "Menu03":                                                                                              

                            for (int i = 0; i < _data.FunitureInvenList.Count; i++)
                            {
                                if (0 == _data.FunitureInvenList[i].m_ID.ToString().IndexOf($"{ItemCode}"))
                                {
                                    if (_targetIndex == _data.FunitureInvenList[i].m_ID.ToString().IndexOf("3", StartIndex))
                                    {
                                        SelectInvenList.Add(_data.FunitureInvenList[i]);
                                    }
                                }
                            }
                    break;                                                                                                  
                case "Menu04":                                                                                              

                            for (int i = 0; i < _data.FunitureInvenList.Count; i++)
                            {
                                if (0 == _data.FunitureInvenList[i].m_ID.ToString().IndexOf($"{ItemCode}"))
                                {
                                    if (_targetIndex == _data.FunitureInvenList[i].m_ID.ToString().IndexOf("4", StartIndex))
                                    {
                                        SelectInvenList.Add(_data.FunitureInvenList[i]);
                                    }
                                }
                            }
                    break;                                                                                                  
                case "Menu05":                                                                                              

                            for (int i = 0; i < _data.FunitureInvenList.Count; i++)
                            {
                                if (0 == _data.FunitureInvenList[i].m_ID.ToString().IndexOf($"{ItemCode}"))
                                {
                                    if (_targetIndex == _data.FunitureInvenList[i].m_ID.ToString().IndexOf("5", StartIndex))
                                    {
                                        SelectInvenList.Add(_data.FunitureInvenList[i]);
                                    }
                                }
                            }
                    break;
            }
  
            for (int i = 0; i < SelectItemList.Count; i++)
            {
                Slots[i].SetActive(true);
                Slots[i].transform.GetChild(1).GetComponent<Text>().text = SelectItemList[i].m_Name;
                Slots[i].transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Items/{SelectItemList[i].m_ID}");
                if (SelectItemList[i].m_isEquip)
                    Slots[i].transform.GetChild(3).gameObject.SetActive(true);
                else
                    Slots[i].transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }
    
  
}
```
