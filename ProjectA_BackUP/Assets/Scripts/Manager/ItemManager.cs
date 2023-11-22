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
                        curImage.gameObject.SetActive(true);
                        count++;
                    }
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

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    ItemGet.GetItem();
        //    Debug.Log("a");
        //}
        //if (SceneManager.GetActiveScene().name == "Village")
        //{
        //    using (StreamReader reader = new StreamReader(Application.dataPath + "/Resources/ITEM/ItemManager.csv")) // 없으면 생성함
        //    {
        //        int count = 0;
        //        string[] split;
        //        string read = reader.ReadLine();
        //        while ((read = reader.ReadLine()) != null)
        //        {
        //            split = read.Split(',');
        //            if (int.Parse(split[0]).Equals(count))
        //            {
        //                Image curImage = ItemInventory.transform.GetChild(count).transform.GetChild(0).GetComponentInChildren<Image>();
        //                curImage.sprite = Resources.Load<Sprite>(CompareItemType(split[1], int.Parse(split[2])));
        //                curImage.gameObject.SetActive(true);
        //                count++;
        //            }
        //        }
        //    }
        //}
    }

}
