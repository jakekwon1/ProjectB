using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    public List<ItemSlot> inventory;
    public Image selectImg;
    int itemIndex;
    // Start is called before the first frame update
    void Start()
    {
        itemIndex = -1;
        for (int i = 0; i < transform.childCount-1; i++)
        {
            if (transform.GetChild(i).GetComponent<ItemSlot>() == null)
            {
                transform.GetChild(i).gameObject.AddComponent<ItemSlot>();
            }
        }
        inventory.AddRange(transform.GetComponentsInChildren<ItemSlot>());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].PtInRect(eventData.position))
            {
                if (inventory[i].icon.gameObject.activeSelf == true)
                {
                    itemIndex = i;
                    Debug.Log(i + "slot");
                    selectImg.transform.position = eventData.position;
                    selectImg.sprite = Resources.Load<Sprite>("UI/" + inventory[i].name);
                    selectImg.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemIndex != -1)
            selectImg.transform.position = eventData.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (itemIndex != -1)
            selectImg.transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].PtInRect(eventData.position))
            {
                if (itemIndex != -1 && itemIndex == i) // µ¿ÀÏÇÑ ½½·Ô¿¡¼­ ´­·¶´Ù ¶¿ °æ¿ì
                {
                    selectImg.gameObject.SetActive(false);
                    selectImg.sprite = null;
                    itemIndex = -1;
                    break;
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (itemIndex != -1)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].PtInRect(eventData.position))
                {
                    if (inventory[i].icon.sprite == null)
                    {
                        inventory[i].icon.sprite = Resources.Load<Sprite>("UI/" + inventory[itemIndex].name);
                        inventory[i].icon.gameObject.SetActive(true);
                        inventory[itemIndex].icon.gameObject.SetActive(false);
                        inventory[itemIndex].icon.sprite = null;
                    }
                    else
                    {
                        inventory[itemIndex].icon.sprite = Resources.Load<Sprite>("UI/" + inventory[i].name);
                        inventory[i].icon.sprite = Resources.Load<Sprite>("UI/" + selectImg.sprite.name);
                    }
                    break;
                }
            }
            if (itemIndex != -1)
            {
                selectImg.gameObject.SetActive(false);
                selectImg.sprite = null;
                itemIndex = -1;
            }
        }
    }




    // Update is called once per frame
    void Update()
    {

    }
}
