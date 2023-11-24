using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    public List<ItemSlot> inventory;
    public GameObject ItemOption;
    int OptionIndex;
    public Image selectImg;
    ItemData selectdata;
    Vector2 dir;
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
                    onTimer = true;
                    break;
                }
            }
        }
        PopupOption(false);
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
                    OptionIndex = itemIndex;
                    selectImg.gameObject.SetActive(false);
                    selectImg.sprite = null;
                    itemIndex = -1;
                    selectdata = null;
                    onTimer = false;
                    dir = eventData.position;
                    if (timer != 0 && timer < 1f && !onTimer)
                        PopupOption(true);
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
                        inventory[i].icon.gameObject.GetComponent<ItemData>().getIndex = inventory[itemIndex].icon.gameObject.GetComponent<ItemData>().index;
                        inventory[i].icon.gameObject.GetComponent<ItemData>().getType = inventory[itemIndex].icon.gameObject.GetComponent<ItemData>().type;
                        inventory[i].icon.gameObject.GetComponent<ItemData>().getData = inventory[itemIndex].icon.gameObject.GetComponent<ItemData>().data;
                        inventory[i].icon.gameObject.SetActive(true);
                        inventory[itemIndex].icon.gameObject.SetActive(false);
                        inventory[itemIndex].icon.sprite = null;
                        Destroy(inventory[itemIndex].icon.gameObject.GetComponent<ItemData>());
                        inventory[itemIndex].transform.GetChild(0).gameObject.AddComponent<ItemData>();
                    }
                    else // 아이템이 있을 때
                    {
                        inventory[itemIndex].icon.sprite = Resources.Load<Sprite>(SeparateItemFolder(inventory[i].icon)); // 첫 아이템 데이터를 현재 데이터로
                        inventory[itemIndex].icon.gameObject.GetComponent<ItemData>().getIndex = inventory[i].icon.gameObject.GetComponent<ItemData>().index;
                        inventory[itemIndex].icon.gameObject.GetComponent<ItemData>().getType = inventory[i].icon.gameObject.GetComponent<ItemData>().type;
                        inventory[itemIndex].icon.gameObject.GetComponent<ItemData>().getData = inventory[i].icon.gameObject.GetComponent<ItemData>().data;

                        inventory[i].icon.sprite = Resources.Load<Sprite>(SeparateItemFolder(selectImg));               // 현재 아이템 데이터를 저장된 데이터로
                        inventory[i].icon.gameObject.GetComponent<ItemData>().getIndex = selectdata.GetComponent<ItemData>().index;
                        inventory[i].icon.gameObject.GetComponent<ItemData>().getType = selectdata.GetComponent<ItemData>().type;
                        inventory[i].icon.gameObject.GetComponent<ItemData>().getData = selectdata.GetComponent<ItemData>().data;
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

    public void PopupOption(bool sw)
    {
        Debug.Log("!!!!");
        ItemOption.transform.position = dir;
        ItemOption.SetActive(sw);
        timer = 0;
    }

    public void Equipment()
    {



        ItemOption.SetActive(false);
    }

    public void DestroyItem()
    {
        string line = string.Empty;
        using(StreamReader reader = new StreamReader(Application.dataPath + "/Resources/ITEM/ItemManager.csv"))
        {
            bool skip = false;
            string read = reader.ReadLine();
            while((read = reader.ReadLine()) !=null)
            {
                if (string.IsNullOrEmpty(read))
                    break;
                string[] split = read.Split(',');
                if (OptionIndex == int.Parse(split[0]))
                {
                    skip = true;
                    continue;
                }
                if (skip)
                {
                    int a = int.Parse(split[0]) - 1;
                    split[0] = a.ToString();
                    read = string.Join(',', split);
                }
                line += read + "//";
            }
        }
        using(StreamWriter writer = new StreamWriter(Application.dataPath + "/Resources/ITEM/ItemManager.csv"))
        {
            writer.WriteLine("index,type,atk/def//");
            string[] splitline = line.Split("//");
            for(int i = 0; i < splitline.Length-1; i++)
                writer.WriteLine(splitline[i]);
        }
        ItemOption.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (onTimer)    
            timer += Time.deltaTime;

    }
}
