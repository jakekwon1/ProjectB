using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemGet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetItem();
    }

    public void GetItem()
    {
        string Item = RandomItem();
        int range = Random.Range(1, 20);
        string line;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/Resources/ITEM/ItemManager.csv"))
        {
            line = reader.ReadToEnd();
            using (StreamWriter writer = new StreamWriter(Application.dataPath + "/Resources/ITEM/ItemManager.csv")) // 없으면 생성함
            {
                writer.WriteLine("Index,ItemParts,Attack/Defence");
                writer.WriteLine(line);
            }
        }

    }

    public string RandomItem()
    {
        int index = Random.Range(0, 3);
        string item = null;
        switch (index)
        {
            case 0:
                item = "Sword";
                break;
            case 1:
                item = "Helmet";
                break;
            case 2:
                item = "TopArmor";
                break;
            case 3:
                item = "BottomArmor";
                break;
        }
        return item;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
