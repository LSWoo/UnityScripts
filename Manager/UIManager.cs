using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool is2D = false;
    [SerializeField] GameObject Cursor;
    [SerializeField] GameObject PickUpPanel;
    [SerializeField] GameObject PickUpItem;

    public bool isOpen = false;

    private void Start()
    {
        Managers._Input.KeyAction -= PickUpItemUI;
        Managers._Input.KeyAction += PickUpItemUI;
        Managers._Input.KeyAction -= GetItem;
        Managers._Input.KeyAction += GetItem;
        Managers._Input.KeyAction -= GetOpen;
        Managers._Input.KeyAction += GetOpen;
    }

    void GetItem()
    {
        float TotalTime = 3f;
        Image Fill = PickUpPanel.transform.GetChild(1).GetComponent<Image>();


        if (Input.GetKey(Managers._Input.GetItemKey))
        {
            if (PickUpPanel.activeSelf)
            {
                if (Fill.fillAmount == 1)
                {
                    Destroy(PickUpItem);
                    Fill.gameObject.SetActive(false);
                    Fill.fillAmount = 0;
                    Managers._Inven.ItemList.Add(Managers._data.ItemnList[0]);
                }
                else
                {
                    Fill.gameObject.SetActive(true);
                    Fill.fillAmount += Time.deltaTime / TotalTime;
                }
            }
        }
        else
        {
            Fill.gameObject.SetActive(false);
            Fill.fillAmount = 0;
        }
    }
    void GetOpen()
    {
        float TotalTime = 1.5f;
        Image Fill = PickUpPanel.transform.GetChild(1).GetComponent<Image>();

        if (Input.GetKey(Managers._Input.GetItemKey))
        {
            if (PickUpPanel.activeSelf)
            {
                if (Fill.fillAmount == 1)
                {
                    isOpen = true;
                    PickUpPanel.SetActive(false);
                    Fill.gameObject.SetActive(false);
                    Fill.fillAmount = 0;
                }
                else
                {
                    Fill.gameObject.SetActive(true);
                    Fill.fillAmount += Time.deltaTime / TotalTime;
                }
            }
        }
        else
        {
            Fill.gameObject.SetActive(false);
            Fill.fillAmount = 0;
        }
    }
    void PickUpItemUI()
    {
        Ray ray = Camera.main.ScreenPointToRay(Cursor.transform.position);
        RaycastHit hit;
        float _ItemrayDistance = 100f;
        LayerMask ItemMask = 1 << LayerMask.NameToLayer("Item");
        LayerMask BoxMask = 1 << LayerMask.NameToLayer("Box");

        Text PickUpItemNametxt = PickUpPanel.transform.GetChild(0).GetComponent<Text>();
        Image Fill = PickUpPanel.transform.GetChild(1).GetComponent<Image>();

        if (!is2D)
        {
            if (Physics.Raycast(ray, out hit, _ItemrayDistance, ItemMask))
            {
                Debug.DrawRay(Cursor.transform.position, ray.direction * 10, Color.blue);
                PickUpItemNametxt.text = $"{hit.collider.gameObject.name}";
                PickUpPanel.transform.position = Cursor.transform.position;
                PickUpItem = hit.collider.gameObject;
                PickUpPanel.SetActive(true);
            }
            else if (Physics.Raycast(ray, out hit, _ItemrayDistance, BoxMask))
            {
                if (!isOpen)
                {
                    PickUpItemNametxt.text = "열기";
                    PickUpPanel.transform.position = Cursor.transform.position;
                    PickUpPanel.SetActive(true);
                }
            }
            else
            {
                PickUpItem = null;
                Fill.fillAmount = 0;
                PickUpPanel.SetActive(false);
            }
        }
        else
            PickUpPanel.SetActive(false);
    }
}
