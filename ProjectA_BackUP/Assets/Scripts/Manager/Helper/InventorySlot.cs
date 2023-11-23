using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    public List<ItemSlot> inventory;
    public Image selectImg;
    ItemData selectdata;
    int itemIndex;
    float timer;
    bool onTimer;
    // Start is called before the first frame update
    void Start()
    {
        onTimer = false;
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

    public string SeparateItemFolder(Image itemName)
    {
        string r = "ITEM/";
        string[] split;
        split = itemName.sprite.name.Split(" ");
        if (split[split.Length-1] == "Sword")
            r += "Weapon/" + itemName.sprite.name;
        else
            r += "Equipment/" + itemName.sprite.name;
        return r;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].PtInRect(eventData.position) /*&& inventory[i].icon.IsActive()*/)
            {
                if (inventory[i].icon.gameObject.activeSelf == true)
                {
                    itemIndex = i;
                    Debug.Log(i + "slot");
                    selectImg.transform.position = eventData.position;
                    selectImg.sprite = Resources.Load<Sprite>(SeparateItemFolder(inventory[i].icon));
                    selectdata = inventory[i].GetComponent<ItemData>();
                    selectImg.gameObject.SetActive(true);
                    timer = 0;
                    onTimer = true;
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
                if (itemIndex != -1 && itemIndex == i) // 동일한 슬롯에서 눌렀다 뗄 경우
                {
                    selectImg.gameObject.SetActive(false);
                    selectImg.sprite = null;
                    itemIndex = -1;
                    selectdata = null;
                    onTimer = false;
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
                    if (inventory[i].icon.sprite == null) // 옮기는 곳에 아이템이 없을 때
                    {
                        inventory[i].icon.sprite = Resources.Load<Sprite>(SeparateItemFolder(inventory[itemIndex].icon));
                        //inventory[i].GetComponentInChildren<ItemData>().changeIndex(inventory[itemIndex].GetComponent<ItemData>());
                        //inventory[i].GetComponentInChildren<ItemData>().changeType(inventory[itemIndex].GetComponent<ItemData>());
                        //inventory[i].GetComponentInChildren<ItemData>().changeData(inventory[itemIndex].GetComponent<ItemData>());
                        inventory[i].icon.gameObject.SetActive(true);
                        inventory[itemIndex].icon.gameObject.SetActive(false);
                        inventory[itemIndex].icon.sprite = null;
                        Destroy(inventory[itemIndex].GetComponentInChildren<ItemData>());
                        inventory[itemIndex].transform.GetChild(0).gameObject.AddComponent<ItemData>();



                    }
                    else // 아이템이 있을 때
                    {
                        inventory[itemIndex].icon.sprite = Resources.Load<Sprite>(SeparateItemFolder(inventory[i].icon)); // 첫 아이템 데이터를 현재 데이터로
                        inventory[itemIndex].GetComponentInChildren<ItemData>().changeIndex(inventory[i].GetComponent<ItemData>());
                        inventory[itemIndex].GetComponentInChildren<ItemData>().changeType(inventory[i].GetComponent<ItemData>());
                        inventory[itemIndex].GetComponentInChildren<ItemData>().changeData(inventory[i].GetComponent<ItemData>());

                        inventory[i].icon.sprite = Resources.Load<Sprite>(SeparateItemFolder(selectImg));               // 현재 아이템 데이터를 저장된 데이터로
                        inventory[i].GetComponent<ItemData>().changeIndex(selectdata.GetComponent<ItemData>());
                        inventory[i].GetComponent<ItemData>().changeType(selectdata.GetComponent<ItemData>());
                        inventory[i].GetComponent<ItemData>().changeData(selectdata.GetComponent<ItemData>());
                    }
                    break;
                }
            }
            if (itemIndex != -1)
            {
                selectImg.gameObject.SetActive(false);
                selectImg.sprite = null;
                selectdata = null;
                itemIndex = -1;
            }
        }
    }

    public void PopupOption()
    {
        Debug.Log("!!!!");
        timer = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (onTimer)
            timer += Time.deltaTime;
        if ( timer !=0 && timer < 1f && !onTimer)
            PopupOption();
    }
}
