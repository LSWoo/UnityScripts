using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool is2D = false;
    [SerializeField] GameObject PickUpPanel;
    [SerializeField] Text PickUpItemNametxt;

    private void Update()
    {
        PickUpItemUI();
    }

    void PickUpItemUI()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float _ItemrayDistance = 3.5f;
        LayerMask ItemMask = 1 << LayerMask.NameToLayer("Item");

        if (!is2D)
        {
            if (Physics.Raycast(ray, out hit, _ItemrayDistance, ItemMask))
            {
                Debug.DrawRay(Camera.main.transform.position, ray.direction * 10, Color.blue);
                PickUpItemNametxt.text = $"{hit.collider.gameObject.name}";
                PickUpPanel.transform.position = Input.mousePosition;
                PickUpPanel.SetActive(true);
            }
            else
                PickUpPanel.SetActive(false);
        }
        else
            PickUpPanel.SetActive(false);
    }
}
