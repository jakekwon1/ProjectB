using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Image ItemInventory;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            ReloadInventoryItem();
        }
    }

    public void ReloadInventoryItem() // 초반 한번 실행
    {
        using (StreamReader reader = new StreamReader(Application.dataPath + "/Resources/ITEM/ItemManager.csv")) // 없으면 생성함
        {
            int count = 0;
            string[] split;
            string read = reader.ReadLine();
            while ((read = reader.ReadLine()) != null)
            {
                split = read.Split(',');
                if (int.Parse(split[0]).Equals(count))
                {
                    Image curImage = ItemInventory.transform.GetChild(count).transform.GetChild(0).GetComponentInChildren<Image>();
                    curImage.sprite = Resources.Load<Sprite>(CompareItemType(split[1], int.Parse(split[2])));
                    ItemData item = curImage.gameObject.GetComponent<ItemData>();
                    item.index = int.Parse(split[0]); item.type = split[1]; item.data =int.Parse(split[2]);
                    Village.instance.item = item;
                    curImage.gameObject.SetActive(true);
                    count++;
                }
            }
        }
    }

    public string CompareItemType(string type, int num)
    {
        string r = "ITEM/";
        if(type.Equals("Sword"))
        {
            r += "Weapon/";
            if (num < 6)
            {
                r += "Wooden Sword";
            }
            else if(num < 11)
            {
                r += "Silver Sword";
            }
            else if (num < 16)
            {
                r += "Iron Sword";
            }
            else
            {
                r += "Golden Sword";
            }
        }
        else
        {
            r += "Equipment/";
            if (type.Equals("Helmet"))
            {
                if (num < 11)
                    r += "Leather Helmet";
                else
                    r += "Iron Helmet";
            }
            else if (type.Equals("TopArmor"))
            {
                if (num < 11)
                    r += "Leather Armor";
                else
                    r += "Iron Armor";
            }
            else if (type.Equals("BottomArmor"))
            {
                if (num < 11)
                    r += "Leather Boot";
                else
                    r += "Iron Boot";
            }
        }
        return r;
    }

    public static void RemoveItemFromBehind()
    {
        string line = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/Resources/ITEM/ItemManager.csv"))
        {
            string read = string.Empty;
            string nextread;
            while ((nextread = reader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(nextread))
                    break;
                if (string.IsNullOrEmpty(read))
                {
                    read = nextread;
                    continue;
                }
                line += read + "//";
                read = nextread;
            }
        }
        using (StreamWriter writer = new StreamWriter(Application.dataPath + "/Resources/ITEM/ItemManager.csv"))
        {
            if (!string.IsNullOrEmpty(line))
            {
                string[] split = line.Split("//");
                for (int i = 0; i < split.Length - 1; i++)
                {
                    writer.WriteLine(split[i]);
                }
            }
            else
            {
                writer.WriteLine("index,type,atk/def");
            }
        }
    }

    public void organizeItemIndex()
    {
        for (int i = 0; i < ItemInventory.transform.childCount - 1; i++)
        {
            if (transform.GetChild(i).GetComponent<ItemSlot>() == null)
            {
                transform.GetChild(i).gameObject.AddComponent<ItemSlot>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ItemGet.GetItem();
            Debug.Log("a");
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            RemoveItemFromBehind();
            Debug.Log("b");
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            ReloadInventoryItem();
            Debug.Log("c");
        }
    }

}
